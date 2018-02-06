namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System;
    using System.Linq;
    using TestClasses;

    public abstract class OperatorTestsBase
    {
        public abstract void ShouldRetrieveOperators();

        public abstract void ShouldRetrieveImplicitOperators();

        public abstract void ShouldRetrieveImplicitOperator();

        public abstract void ShouldRetrieveExplicitOperators();

        public abstract void ShouldRetrieveExplicitOperator();

        public abstract void ShouldHandleMissingOperator();

        #region Test Implementations

        protected void DoShouldRetrieveOperators()
        {
            var operators = typeof(TestHelper)
                .GetOperators()
                .OrderBy(o => o.ReturnType.Name)
                .ToArray();

            operators.Length.ShouldBe(4);
            operators[0].ReturnType.ShouldBe(typeof(DateTime));
            operators[1].ReturnType.ShouldBe(typeof(int));
            operators[2].ReturnType.ShouldBe(typeof(int[]));
            operators[3].ReturnType.ShouldBe(typeof(string));
        }

        protected void DoShouldRetrieveImplicitOperators()
        {
            var operators = typeof(TestHelper)
                .GetImplicitOperators()
                .OrderBy(o => o.ReturnType.Name)
                .ToArray();

            operators.Length.ShouldBe(2);
            operators[0].ReturnType.ShouldBe(typeof(DateTime));
            operators[1].ReturnType.ShouldBe(typeof(string));
        }

        protected void DoShouldRetrieveImplicitOperator()
        {
            typeof(TestHelper)
                .GetImplicitOperator<string>()
                .ShouldNotBeNull()
                .ReturnType.ShouldBe(typeof(string));
        }

        protected void DoShouldRetrieveExplicitOperators()
        {
            var operators = typeof(TestHelper)
                .GetExplicitOperators()
                .OrderBy(o => o.ReturnType.Name)
                .ToArray();

            operators.Length.ShouldBe(2);
            operators[0].ReturnType.ShouldBe(typeof(int));
            operators[1].ReturnType.ShouldBe(typeof(int[]));
        }

        protected void DoShouldRetrieveExplicitOperator()
        {
            typeof(TestHelper)
                .GetExplicitOperator<int>()
                .ShouldNotBeNull()
                .ReturnType.ShouldBe(typeof(int));
        }

        protected void DoShouldHandleMissingOperator()
        {
            typeof(TestHelper)
                .GetExplicitOperator<byte[]>()
                .ShouldBeNull();
        }

        #endregion
    }
}
