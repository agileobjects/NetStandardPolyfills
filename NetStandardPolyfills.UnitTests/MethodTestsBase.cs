namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Linq;
    using TestClasses;

    public abstract class MethodTestsBase
    {
        public abstract void ShouldFindPublicStaticMethods();

        public abstract void ShouldFindAPublicStaticMethodByName();

        public abstract void ShouldFindPublicInstanceMethods();

        public abstract void ShouldFindAPublicInstanceMethod();

        public abstract void ShouldFindAnInheritedPublicInstanceMethod();

        public abstract void ShouldFindANonPublicInstanceMethod();

        public abstract void ShouldFindNonPublicStaticMethods();

        public abstract void ShouldFindANonPublicStaticMethod();

        #region Test Implementations

        protected void DoShouldFindPublicStaticMethods()
        {
            var methods = typeof(TestHelper)
                .GetPublicStaticMethods()
                .Select(m => m.Name)
                .ToList();

            methods.ShouldContain("PublicStaticMethod");
        }

        protected void DoShouldFindAPublicStaticMethodByName()
        {
            typeof(TestHelper)
                .GetPublicStaticMethod("PublicStaticMethod")
                .ShouldNotBeNull();
        }

        protected void DoShouldFindPublicInstanceMethods()
        {
            var methods = typeof(TestHelper)
                .GetPublicInstanceMethods()
                .Select(m => m.Name)
                .ToList();

            methods.ShouldContain("DoParamsStuff");
            methods.ShouldContain("DoNonParamsStuff");
        }

        protected void DoShouldFindAPublicInstanceMethod()
        {
            typeof(TestHelper)
                .GetPublicInstanceMethod("DoParamsStuff")
                .ShouldNotBeNull();
        }

        protected void DoShouldFindAnInheritedPublicInstanceMethod()
        {
            var parameterlessToString = typeof(MyTestEnum)
                .GetPublicInstanceMethods()
                .First(m => m.Name == "ToString" && m.GetParameters().Length == 0);

            parameterlessToString.ShouldNotBeNull();
        }

        protected void DoShouldFindANonPublicInstanceMethod()
        {
            var method = typeof(TestHelper)
                .GetNonPublicInstanceMethods()
                .First();

            method.Name.ShouldBe("NonPublicMethod");
        }

        protected void DoShouldFindNonPublicStaticMethods()
        {
            var method = typeof(TestHelper)
                .GetNonPublicStaticMethods()
                .First();

            method.Name.ShouldBe("NonPublicStaticMethod");
        }

        protected void DoShouldFindANonPublicStaticMethod()
        {
            var method = typeof(TestHelper)
                .GetNonPublicStaticMethod("NonPublicStaticMethod");

            method.ShouldNotBeNull();
        }

        #endregion
    }
}