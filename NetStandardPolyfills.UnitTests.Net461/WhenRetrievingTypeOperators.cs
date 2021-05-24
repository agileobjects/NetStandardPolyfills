namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System;
    using System.Linq;
    using TestClasses;
#if FEATURE_XUNIT
    using Xunit;
#else
    using Fact = NUnit.Framework.TestAttribute;

    [NUnit.Framework.TestFixture]
#endif
    public class WhenRetrievingTypeOperators
    {
        [Fact]
        public void ShouldFlagAnImplicitOperator()
        {
            typeof(TestHelper)
                .GetOperators(m => m.To<string>())
                .FirstOrDefault()
                .ShouldNotBeNull()
                .IsImplicitOperator()
                .ShouldBeTrue();
        }

        [Fact]
        public void ShouldFlagANonImplicitOperator()
        {
            typeof(TestHelper)
                .GetOperators(m => m.To<int>())
                .FirstOrDefault()
                .ShouldNotBeNull()
                .IsImplicitOperator()
                .ShouldBeFalse();
        }

        [Fact]
        public void ShouldFlagAnExplicitOperator()
        {
            typeof(TestHelper)
                .GetOperators(m => m.To<int>())
                .FirstOrDefault()
                .ShouldNotBeNull()
                .IsExplicitOperator()
                .ShouldBeTrue();
        }

        [Fact]
        public void ShouldFlagANonExplicitOperator()
        {
            typeof(TestHelper)
                .GetOperators(m => m.To<string>())
                .FirstOrDefault()
                .ShouldNotBeNull()
                .IsExplicitOperator()
                .ShouldBeFalse();
        }

        [Fact]
        public void ShouldRetrieveOperators()
        {
            var operators = typeof(TestHelper)
                .GetOperators()
                .OrderBy(o => o.ReturnType.Name)
                .ThenBy(o => o.GetParameters()[0].ParameterType.Name)
                .ToArray();

            operators.Length.ShouldBe(6);
            operators[0].ReturnType.ShouldBe(typeof(DateTime));
            operators[1].ReturnType.ShouldBe(typeof(int));
            operators[2].ReturnType.ShouldBe(typeof(int[]));
            operators[3].ReturnType.ShouldBe(typeof(string));
            operators[4].ReturnType.ShouldBe(typeof(TestHelper));
            operators[4].GetParameters()[0].ParameterType.ShouldBe(typeof(long));
            operators[5].ReturnType.ShouldBe(typeof(TestHelper));
            operators[5].GetParameters()[0].ParameterType.ShouldBe(typeof(string));
        }

        [Fact]
        public void ShouldRetrieveFilteredOperators()
        {
            var fromOperators = typeof(TestHelper)
                .GetOperators(o => o.From<TestHelper>())
                .OrderBy(o => o.ReturnType.Name)
                .ToArray();

            fromOperators.Length.ShouldBe(4);
            fromOperators[0].ReturnType.ShouldBe(typeof(DateTime));
            fromOperators[0].GetParameters()[0].ParameterType.ShouldBe(typeof(TestHelper));
            fromOperators[1].ReturnType.ShouldBe(typeof(int));
            fromOperators[1].GetParameters()[0].ParameterType.ShouldBe(typeof(TestHelper));
            fromOperators[2].ReturnType.ShouldBe(typeof(int[]));
            fromOperators[2].GetParameters()[0].ParameterType.ShouldBe(typeof(TestHelper));
            fromOperators[3].ReturnType.ShouldBe(typeof(string));
            fromOperators[3].GetParameters()[0].ParameterType.ShouldBe(typeof(TestHelper));

            var toOperators = typeof(TestHelper)
                .GetOperators(o => o.To<TestHelper>())
                .OrderBy(o => o.GetParameters()[0].ParameterType.Name)
                .ToArray();

            toOperators.Length.ShouldBe(2);
            toOperators[0].ReturnType.ShouldBe(typeof(TestHelper));
            toOperators[0].GetParameters()[0].ParameterType.ShouldBe(typeof(long));
            toOperators[1].ReturnType.ShouldBe(typeof(TestHelper));
            toOperators[1].GetParameters()[0].ParameterType.ShouldBe(typeof(string));
        }

        [Fact]
        public void ShouldRetrieveImplicitOperators()
        {
            var operators = typeof(TestHelper)
                .GetImplicitOperators()
                .OrderBy(o => o.ReturnType.Name)
                .ThenBy(o => o.GetParameters()[0].ParameterType.Name)
                .ToArray();

            operators.Length.ShouldBe(3);
            operators[0].ReturnType.ShouldBe(typeof(DateTime));
            operators[1].ReturnType.ShouldBe(typeof(string));
            operators[2].ReturnType.ShouldBe(typeof(TestHelper));
            operators[2].GetParameters()[0].ParameterType.ShouldBe(typeof(string));
        }

        [Fact]
        public void ShouldRetrieveImplicitOperator()
        {
            typeof(TestHelper)
                .GetImplicitOperator(o => o.To<string>())
                .ShouldNotBeNull()
                .ReturnType.ShouldBe(typeof(string));
        }

        [Fact]
        public void ShouldRetrieveExplicitOperators()
        {
            var operators = typeof(TestHelper)
                .GetExplicitOperators()
                .OrderBy(o => o.ReturnType.Name)
                .ThenBy(o => o.GetParameters()[0].ParameterType.Name)
                .ToArray();

            operators.Length.ShouldBe(3);
            operators[0].ReturnType.ShouldBe(typeof(int));
            operators[1].ReturnType.ShouldBe(typeof(int[]));
            operators[2].ReturnType.ShouldBe(typeof(TestHelper));
            operators[2].GetParameters()[0].ParameterType.ShouldBe(typeof(long));
        }

        [Fact]
        public void ShouldRetrieveExplicitOperator()
        {
            typeof(TestHelper)
                .GetExplicitOperator(o => o.To<int>())
                .ShouldNotBeNull()
                .ReturnType.ShouldBe(typeof(int));
        }

        [Fact]
        public void ShouldHandleMissingOperator()
        {
            typeof(TestHelper)
                .GetExplicitOperator(o => o.From<byte[]>())
                .ShouldBeNull();
        }
    }
}
