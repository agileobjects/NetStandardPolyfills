namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;
    using TestClasses;

    public abstract class TypeDataTestsBase
    {
        public abstract void ShouldFlagAParamsArray();

        public abstract void ShouldFlagANonParamsArray();

        public abstract void ShouldFindATypeAttribute();

        public abstract void ShouldNotFindATypeAttribute();

        public abstract void ShouldFlagAnAnonymousType();

        public abstract void ShouldFlagANonAnonymousType();

        public abstract void ShouldFlagAPrimitiveType();

        public abstract void ShouldFlagANonPrimitiveType();

        public abstract void ShouldGetGenericArguments();

        public abstract void ShouldGetEmptyGenericArguments();

        public abstract void ShouldDetermineThatATypeIsDerived();

        public abstract void ShouldDetermineThatATypeIsNotDerived();

        public abstract void ShouldDetermineThatATypeIsAssignable();

        public abstract void ShouldDetermineThatATypeIsNotAssignable();

        #region Test implementations

        protected void DoShouldFlagAParamsArray()
        {
            var paramsParameter = typeof(TestHelper)
                .GetPublicInstanceMethod("DoParamsStuff")
                .GetParameters()
                .First();

            paramsParameter.IsParamsArray().ShouldBeTrue();
        }

        protected void DoShouldFlagANonParamsArray()
        {
            var paramsParameter = typeof(TestHelper)
                .GetPublicInstanceMethod("DoNonParamsStuff")
                .GetParameters()
                .First();

            paramsParameter.IsParamsArray().ShouldBeFalse();
        }

        protected void DoShouldFindATypeAttribute()
        {
            typeof(TestHelper).HasAttribute<MyAttribute>().ShouldBeTrue();
        }

        protected void DoShouldNotFindATypeAttribute()
        {
            typeof(TypeDataTestsBase).HasAttribute<MyAttribute>().ShouldBeFalse();
        }

        protected void DoShouldFlagAnAnonymousType()
        {
            var anon = new { Value = "Value!" };

            anon.GetType().IsAnonymous().ShouldBeTrue();
        }

        protected void DoShouldFlagANonAnonymousType()
        {
            typeof(IOrderedEnumerable<int>).IsAnonymous().ShouldBeFalse();
        }

        protected void DoShouldFlagAPrimitiveType()
        {
            typeof(int).IsPrimitive().ShouldBeTrue();
        }

        protected void DoShouldFlagANonPrimitiveType()
        {
            typeof(object).IsPrimitive().ShouldBeFalse();
        }

        protected void DoShouldGetGenericArguments()
        {
            typeof(Dictionary<string, int>)
                .GetGenericArguments()
                .SequenceEqual(new[] { typeof(string), typeof(int) })
                .ShouldBeTrue();
        }

        protected void DoShouldGetEmptyGenericArguments()
        {
            typeof(string).GetGenericArguments().ShouldBeEmpty();
        }

        protected void DoShouldDetermineThatATypeIsDerived()
        {
            typeof(TestHelper).IsDerivedFrom(typeof(object)).ShouldBeTrue();
        }

        protected void DoShouldDetermineThatATypeIsNotDerived()
        {
            typeof(TestHelper).IsDerivedFrom(typeof(string)).ShouldBeFalse();
        }

        protected void DoShouldDetermineThatATypeIsAssignable()
        {
            typeof(object).IsAssignableFrom(typeof(TestHelper)).ShouldBeTrue();
        }

        protected void DoShouldDetermineThatATypeIsNotAssignable()
        {
            typeof(string).IsAssignableFrom(typeof(TestHelper)).ShouldBeFalse();
        }

        #endregion
    }
}
