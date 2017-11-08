namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Linq;
    using TestClasses;

    public abstract class MethodTestsBase
    {
        public abstract void ShouldFindAPublicInstanceMethod();

        protected void DoShouldFindAPublicInstanceMethod()
        {
            var paramsStuff = typeof(TestHelper)
                .GetPublicInstanceMethods()
                .First(m => m.Name == "DoParamsStuff");

            paramsStuff.ShouldNotBeNull();
        }

        public abstract void ShouldFindAnInheritedPublicInstanceMethod();

        protected void DoShouldFindAnInheritedPublicInstanceMethod()
        {
            var parameterlessToString = typeof(MyTestEnum)
                .GetPublicInstanceMethods()
                .First(m => m.Name == "ToString" && m.GetParameters().Length == 0);

            parameterlessToString.ShouldNotBeNull();
        }

        public abstract void ShouldFindANonPublicInstanceMethod();

        protected void DoShouldFindANonPublicInstanceMethod()
        {
            var method = typeof(TestHelper)
                .GetNonPublicInstanceMethods()
                .First();

            method.Name.ShouldBe("NonPublicMethod");
        }

        public abstract void ShouldFindPublicStaticMethods();

        protected void DoShouldFindPublicStaticMethods()
        {
            var method = typeof(TestHelper)
                .GetPublicStaticMethods()
                .First();

            method.Name.ShouldBe("PublicStaticMethod");
        }

        public abstract void ShouldFindAPublicStaticMethod();

        protected void DoShouldFindAPublicStaticMethod()
        {
            var method = typeof(TestHelper)
                .GetPublicStaticMethod("PublicStaticMethod");

            method.ShouldNotBeNull();
        }

        public abstract void ShouldFindNonPublicStaticMethods();

        protected void DoShouldFindNonPublicStaticMethods()
        {
            var method = typeof(TestHelper)
                .GetNonPublicStaticMethods()
                .First();

            method.Name.ShouldBe("NonPublicStaticMethod");
        }

        public abstract void ShouldFindANonPublicStaticMethod();

        protected void DoShouldFindANonPublicStaticMethod()
        {
            var method = typeof(TestHelper)
                .GetNonPublicStaticMethod("NonPublicStaticMethod");

            method.ShouldNotBeNull();
        }
    }
}