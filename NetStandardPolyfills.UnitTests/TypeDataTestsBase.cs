namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Linq;
    using TestClasses;

    public abstract class TypeDataTestsBase
    {
        public abstract void ShouldFlagAParamsArray();

        protected void DoShouldFlagAParamsArray()
        {
            var paramsParameter = typeof(TestHelper)
                .GetPublicInstanceMethod("DoParamsStuff")
                .GetParameters()
                .First();

            paramsParameter.IsParamsArray().ShouldBeTrue();
        }

        public abstract void ShouldFlagANonParamsArray();

        protected void DoShouldFlagANonParamsArray()
        {
            var paramsParameter = typeof(TestHelper)
                .GetPublicInstanceMethod("DoNonParamsStuff")
                .GetParameters()
                .First();

            paramsParameter.IsParamsArray().ShouldBeFalse();
        }

        public abstract void ShouldFindATypeAttribute();

        protected void DoShouldFindATypeAttribute()
        {
            typeof(TestHelper).HasAttribute<MyAttribute>().ShouldBeTrue();
        }

        public abstract void ShouldNotFindATypeAttribute();

        protected void DoShouldNotFindATypeAttribute()
        {
            typeof(TypeDataTestsBase).HasAttribute<MyAttribute>().ShouldBeFalse();
        }

        public abstract void ShouldFlagAnAnonymousType();

        protected void DoShouldFlagAnAnonymousType()
        {
            var anon = new { Value = "Value!" };

            anon.GetType().IsAnonymous().ShouldBeTrue();
        }

        public abstract void ShouldFlagANonAnonymousType();

        protected void DoShouldFlagANonAnonymousType()
        {
            typeof(IOrderedEnumerable<int>).IsAnonymous().ShouldBeFalse();
        }

        public abstract void ShouldFlagAPrimitiveType();

        protected void DoShouldFlagAPrimitiveType()
        {
            typeof(int).IsPrimitive().ShouldBeTrue();
        }

        public abstract void ShouldFlagANonPrimitiveType();

        protected void DoShouldFlagANonPrimitiveType()
        {
            typeof(object).IsPrimitive().ShouldBeFalse();
        }
    }
}
