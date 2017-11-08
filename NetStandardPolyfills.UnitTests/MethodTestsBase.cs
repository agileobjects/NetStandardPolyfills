namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Linq;
    using TestClasses;

    public abstract class MethodTestsBase
    {
        public abstract void ShouldFindPublicStaticMethods();

        public abstract void ShouldFindAPublicStaticMethodByName();

        public abstract void ShouldFindAPublicStaticMethodByNameAndParamCount();

        public abstract void ShouldFindPublicInstanceMethods();

        public abstract void ShouldFindAPublicInstanceMethodByName();

        public abstract void ShouldFindAPublicInstanceMethodByNameAndParamCount();

        public abstract void ShouldFindAnInheritedPublicInstanceMethodByName();

        public abstract void ShouldFindAnInheritedPublicInstanceMethodByNameAndParamCount();

        public abstract void ShouldFindNonPublicStaticMethods();

        public abstract void ShouldFindANonPublicStaticMethodByName();

        public abstract void ShouldFindANonPublicStaticMethodByNameAndParamCount();

        public abstract void ShouldFindNonPublicInstanceMethods();

        public abstract void ShouldFindANonPublicInstanceMethodByName();

        public abstract void ShouldFindANonPublicInstanceMethodByNameAndParamCount();

        #region Test Implementations

        protected void DoShouldFindPublicStaticMethods()
        {
            var methods = typeof(TestHelper)
                .GetPublicStaticMethods()
                .Select(m => m.Name)
                .ToList();

            methods.ShouldContain("PublicStaticMethod");
            methods.ShouldNotContain("ReferenceEquals");
        }

        protected void DoShouldFindAPublicStaticMethodByName()
        {
            typeof(TestHelper)
                .GetPublicStaticMethod("PublicStaticMethod")
                .ShouldNotBeNull()
                .Name.ShouldBe("PublicStaticMethod");
        }

        protected void DoShouldFindAPublicStaticMethodByNameAndParamCount()
        {
            var method = typeof(MethodTestsHelper)
                .GetPublicStaticMethod("PublicStatic", 1);

            method.ShouldNotBeNull();
            method.Name.ShouldBe("PublicStatic");
            method.GetParameters().ShouldHaveSingleItem();
        }

        protected void DoShouldFindPublicInstanceMethods()
        {
            var methods = typeof(TestHelper)
                .GetPublicInstanceMethods()
                .Select(m => m.Name)
                .ToList();

            methods.ShouldContain("DoParamsStuff");
            methods.ShouldContain("DoNonParamsStuff");
            methods.ShouldContain("GetHashCode");
        }

        protected void DoShouldFindAPublicInstanceMethodByName()
        {
            typeof(TestHelper)
                .GetPublicInstanceMethod("DoParamsStuff")
                .ShouldNotBeNull();
        }

        protected void DoShouldFindAPublicInstanceMethodByNameAndParamCount()
        {
            var method = typeof(MethodTestsHelper)
                .GetPublicInstanceMethod("PublicInstance", 2);

            method.ShouldNotBeNull();
            method.Name.ShouldBe("PublicInstance");
            method.GetParameters().Length.ShouldBe(2);
        }

        protected void DoShouldFindAnInheritedPublicInstanceMethodByName()
        {
            typeof(MyTestEnum)
                .GetPublicInstanceMethod("GetHashCode")
                .ShouldNotBeNull()
                .Name.ShouldBe("GetHashCode");
        }

        protected void DoShouldFindAnInheritedPublicInstanceMethodByNameAndParamCount()
        {
            var method = typeof(MyTestEnum)
                .GetPublicInstanceMethod("ToString", 0);

            method.ShouldNotBeNull();
            method.Name.ShouldBe("ToString");
            method.GetParameters().ShouldBeEmpty();
        }

        protected void DoShouldFindNonPublicStaticMethods()
        {
            var methods = typeof(TestHelper)
                .GetNonPublicStaticMethods()
                .Select(m => m.Name)
                .ToList();

            methods.ShouldContain("NonPublicStaticMethod");
            methods.ShouldNotContain("ReferenceEquals");
        }

        protected void DoShouldFindANonPublicStaticMethodByName()
        {
            typeof(TestHelper)
                .GetNonPublicStaticMethod("NonPublicStaticMethod")
                .ShouldNotBeNull()
                .Name.ShouldBe("NonPublicStaticMethod");
        }

        protected void DoShouldFindANonPublicStaticMethodByNameAndParamCount()
        {
            var method = typeof(MethodTestsHelper)
                .GetNonPublicStaticMethod("NonPublicStatic", 2);

            method.ShouldNotBeNull();
            method.Name.ShouldBe("NonPublicStatic");
            method.GetParameters().Length.ShouldBe(2);
        }

        protected void DoShouldFindNonPublicInstanceMethods()
        {
            var methods = typeof(MethodTestsHelper)
                .GetNonPublicInstanceMethods()
                .Select(m => m.Name)
                .ToList();

            methods[0].ShouldBe("NonPublicInstance");
            methods[1].ShouldBe("NonPublicInstance");
            methods[2].ShouldBe("NonPublicInstance");
        }

        protected void DoShouldFindANonPublicInstanceMethodByName()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceMethod("NonPublicMethod")
                .ShouldNotBeNull()
                .Name.ShouldBe("NonPublicMethod");
        }

        protected void DoShouldFindANonPublicInstanceMethodByNameAndParamCount()
        {
            var method = typeof(MethodTestsHelper)
                .GetNonPublicInstanceMethod("NonPublicInstance", 2);

            method.ShouldNotBeNull();
            method.Name.ShouldBe("NonPublicInstance");
            method.GetParameters().Length.ShouldBe(2);
        }

        #endregion
    }
}