namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Linq;

    public abstract class TypeMemberTestsBase
    {
        public abstract void ShouldFindAnImplicitPublicInstanceConstructor();

        protected void DoShouldFindAnImplicitPublicInstanceConstructor()
        {
            var constructor = typeof(TestHelper)
                .GetPublicInstanceConstructors()
                .FirstOrDefault();

            constructor.ShouldNotBeNull();
        }

        public abstract void ShouldFindAPublicInstanceConstructor();

        protected void DoShouldFindAPublicInstanceConstructor()
        {
            var constructor = typeof(TestHelper)
                .GetPublicInstanceConstructors()
                .FirstOrDefault();

            constructor.ShouldNotBeNull();
        }

        public abstract void ShouldFindANonPublicInstanceConstructor();

        protected void DoShouldFindANonPublicInstanceConstructor()
        {
            var constructor = typeof(TestHelper)
                .GetNonPublicInstanceConstructors()
                .FirstOrDefault();

            constructor.ShouldNotBeNull();
        }

        public abstract void ShouldRetrieveAPublicInstanceField();

        protected void DoShouldRetrieveAPublicInstanceField()
        {
            var fields = typeof(TestHelper).GetPublicInstanceFields();

            fields.ShouldNotBeNull();
            fields.ShouldHaveSingleItem();
            fields.First().Name.ShouldBe("PublicInstanceField");
        }

        public abstract void ShouldRetrieveAPublicInstanceProperty();

        protected void DoShouldRetrieveAPublicInstanceProperty()
        {
            var properties = typeof(TestHelper).GetPublicInstanceProperties();

            properties.ShouldNotBeNull();
            properties.ShouldHaveSingleItem();
            properties.First().Name.ShouldBe("PublicInstanceProperty");
        }

        public abstract void ShouldFindAPublicInstanceMethod();

        protected void DoShouldFindAPublicInstanceMethod()
        {
            var paramsStuff = typeof(TestHelper)
                .GetPublicInstanceMethods()
                .FirstOrDefault(m => m.Name == "DoParamsStuff");

            paramsStuff.ShouldNotBeNull();
        }

        public abstract void ShouldFindAnInheritedPublicInstanceMethod();

        protected void DoShouldFindAnInheritedPublicInstanceMethod()
        {
            var parameterlessToString = typeof(MyTestEnum)
                .GetPublicInstanceMethods()
                .FirstOrDefault(m => m.Name == "ToString" && m.GetParameters().Length == 0);

            parameterlessToString.ShouldNotBeNull();
        }

        public abstract void ShouldFindANonPublicInstanceMethod();

        protected void DoShouldFindANonPublicInstanceMethod()
        {
            var method = typeof(TestHelper)
                .GetNonPublicInstanceMethods()
                .FirstOrDefault();

            method.ShouldNotBeNull();
            method.Name.ShouldBe("NonPublicMethod");
        }

        public abstract void ShouldFindAPublicStaticMethod();

        protected void DoShouldFindAPublicStaticMethod()
        {
            var method = typeof(TestHelper)
                .GetPublicStaticMethod("PublicStaticMethod");

            method.ShouldNotBeNull();
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