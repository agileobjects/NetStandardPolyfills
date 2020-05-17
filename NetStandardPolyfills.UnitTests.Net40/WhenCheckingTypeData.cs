namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using TestClasses;
#if FEATURE_XUNIT
    using Xunit;
#else
    using Fact = NUnit.Framework.TestAttribute;

    [NUnit.Framework.TestFixture]
#endif
    public class WhenCheckingTypeData
    {
        [Fact]
        public void ShouldDetermineThatATypeIsPublic()
        {
            typeof(TestHelper).IsPublic().ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineThatATypeIsNonPublic()
        {
            typeof(Should).IsPublic().ShouldBeFalse();
        }

        [Fact]
        public void ShouldFlagAParamsArray()
        {
            var paramsParameter = typeof(TestHelper)
                .GetPublicInstanceMethod("DoParamsStuff")
                .GetParameters()
                .First();

            paramsParameter.IsParamsArray().ShouldBeTrue();
        }

        [Fact]
        public void ShouldFlagANonParamsArray()
        {
            var paramsParameter = typeof(TestHelper)
                .GetPublicInstanceMethod("DoNonParamsStuff")
                .GetParameters()
                .First();

            paramsParameter.IsParamsArray().ShouldBeFalse();
        }

        [Fact]
        public void ShouldFindATypeAttribute()
        {
            typeof(TestHelper).HasAttribute<MyAttribute>().ShouldBeTrue();
        }

        [Fact]
        public void ShouldNotFindATypeAttribute()
        {
            typeof(WhenCheckingTypeData).HasAttribute<MyAttribute>().ShouldBeFalse();
        }

        [Fact]
        public void ShouldFlagAnAnonymousType()
        {
            var anon = new { Value = "Value!" };

            anon.GetType().IsAnonymous().ShouldBeTrue();
        }

        [Fact]
        public void ShouldFlagANonAnonymousType()
        {
            typeof(IOrderedEnumerable<int>).IsAnonymous().ShouldBeFalse();
        }

        [Fact]
        public void ShouldFlagAPrimitiveType()
        {
            typeof(int).IsPrimitive().ShouldBeTrue();
        }

        [Fact]
        public void ShouldFlagANonPrimitiveType()
        {
            typeof(object).IsPrimitive().ShouldBeFalse();
        }

        [Fact]
        public void ShouldGetGenericArguments()
        {
            typeof(Dictionary<string, int>)
                .GetGenericTypeArguments()
                .SequenceEqual(new[] { typeof(string), typeof(int) })
                .ShouldBeTrue();
        }

        [Fact]
        public void ShouldGetOpenGenericArguments()
        {
            typeof(Dictionary<,>)
                .GetGenericTypeArguments()
                .Length
                .ShouldBe(2);
        }

        [Fact]
        public void ShouldGetEmptyGenericArguments()
        {
            typeof(string).GetGenericTypeArguments().ShouldBeEmpty();
        }

        [Fact]
        public void ShouldDetermineThatATypeIsDerived()
        {
            typeof(TestHelper).IsDerivedFrom(typeof(object)).ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineThatATypeIsNotDerived()
        {
            typeof(TestHelper).IsDerivedFrom(typeof(string)).ShouldBeFalse();
        }

        [Fact]
        public void ShouldDetermineThatATypeIsAssignable()
        {
            typeof(TestHelper).IsAssignableTo(typeof(object)).ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineThatATypeIsNotAssignable()
        {
            typeof(TestHelper).IsAssignableTo(typeof(string)).ShouldBeFalse();
        }

        [Fact]
        public void ShouldRetrieveAllInterfaces()
        {
            var interfaces = typeof(Dictionary<string, string>).GetAllInterfaces();

            (interfaces.Length > 0).ShouldBeTrue();
            interfaces.ShouldContain(typeof(IEnumerable));
            interfaces.ShouldContain(typeof(IDictionary<string, string>));
            interfaces.ShouldContain(typeof(ICollection<KeyValuePair<string, string>>));
        }

        [Fact]
        public void ShouldDetermineThatATypeIsAClosedType()
        {
            typeof(List<string>).IsClosedTypeOf(typeof(List<>)).ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineThatATypeIsNotAClosedType()
        {
            typeof(List<string>).IsClosedTypeOf(typeof(IEnumerable<>)).ShouldBeFalse();
        }
    }
}
