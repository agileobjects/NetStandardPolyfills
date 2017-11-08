namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System;
    using System.Linq;
    using TestClasses;

    public abstract class ConstructorTestsBase
    {
        public abstract void ShouldFindPublicInstanceConstructors();

        public abstract void ShouldFindAnImplicitPublicInstanceConstructor();

        public abstract void ShouldFindAnExplicitPublicInstanceConstructor();

        public abstract void ShouldFindAPublicInstanceConstructorByParameterTypes();

        public abstract void ShouldExcludeAPublicInstanceConstructorByParameterTypes();

        public abstract void ShouldFindNonPublicInstanceConstructors();

        public abstract void ShouldFindANonPublicInstanceConstructor();

        public abstract void ShouldExcludeANonPublicInstanceConstructor();

        public abstract void ShouldFindANonPublicInstanceConstructorByParameterTypes();

        public abstract void ShouldExcludeANonPublicInstanceConstructorByParameterTypes();

        #region Test Implementations

        protected void DoShouldFindPublicInstanceConstructors()
        {
            var constructors = typeof(ConstructorTestsHelper)
                .GetPublicInstanceConstructors()
                .ToArray();

            constructors.Length.ShouldBe(2);
        }

        protected void DoShouldFindAnImplicitPublicInstanceConstructor()
        {
            typeof(TestHelper)
                .GetPublicInstanceConstructors()
                .ShouldHaveSingleItem();
        }

        protected void DoShouldFindAnExplicitPublicInstanceConstructor()
        {
            typeof(ConstructorTestsHelper)
                .GetPublicInstanceConstructor()
                .ShouldNotBeNull();
        }

        protected void DoShouldFindAPublicInstanceConstructorByParameterTypes()
        {
            var constructor = typeof(ConstructorTestsHelper)
                .GetPublicInstanceConstructor(typeof(int), typeof(string));

            constructor.ShouldNotBeNull();
        }

        protected void DoShouldExcludeAPublicInstanceConstructorByParameterTypes()
        {
            var constructor = typeof(ConstructorTestsHelper)
                .GetPublicInstanceConstructor(typeof(int));

            constructor.ShouldBeNull();
        }

        protected void DoShouldFindNonPublicInstanceConstructors()
        {
            var constructors = typeof(ConstructorTestsHelper)
                .GetNonPublicInstanceConstructors()
                .ToArray();

            constructors.Length.ShouldBe(2);
        }

        protected void DoShouldFindANonPublicInstanceConstructor()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceConstructors()
                .ShouldHaveSingleItem();
        }

        protected void DoShouldExcludeANonPublicInstanceConstructor()
        {
            typeof(ConstructorTestsHelper)
                .GetNonPublicInstanceConstructor()
                .ShouldBeNull();
        }

        protected void DoShouldFindANonPublicInstanceConstructorByParameterTypes()
        {
            var constructor = typeof(ConstructorTestsHelper)
                .GetNonPublicInstanceConstructor(typeof(int), typeof(string), typeof(DateTime));

            constructor.ShouldNotBeNull();
        }

        protected void DoShouldExcludeANonPublicInstanceConstructorByParameterTypes()
        {
            var constructor = typeof(ConstructorTestsHelper)
                .GetNonPublicInstanceConstructor(typeof(TimeSpan));

            constructor.ShouldBeNull();
        }

        #endregion
    }
}