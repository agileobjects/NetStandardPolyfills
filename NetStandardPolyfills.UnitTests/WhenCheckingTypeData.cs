namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Linq;
    using System.Reflection;
    using Shouldly;
    using Xunit;

    public class WhenCheckingTypeData
    {
        [Fact]
        public void ShouldFlagAParamsArray()
        {
            var paramsParameter = typeof(TestHelper)
                .GetMethod("DoParamsStuff")
                .GetParameters()
                .First();

            paramsParameter.IsParamsArray().ShouldBeTrue();
        }

        [Fact]
        public void ShouldFlagANonParamsArray()
        {
            var paramsParameter = typeof(TestHelper)
                .GetMethod("DoNonParamsStuff")
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


    }
}
