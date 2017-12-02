namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using TestClasses;

    public abstract class MethodTestsBase
    {
        public abstract void ShouldFindPublicMethods();

        public abstract void ShouldFindAPublicMethodByName();

        public abstract void ShouldExcludeAPublicMethodByName();

        public abstract void ShouldFindAPublicMethodByNameAndParamCount();

        public abstract void ShouldFindAPublicMethodByNameAndParamTypes();

        public abstract void ShouldFindPublicStaticMethods();

        public abstract void ShouldFindAPublicStaticMethodByName();

        public abstract void ShouldExcludeAPublicStaticMethodByName();

        public abstract void ShouldFindAPublicStaticMethodByNameAndParamCount();

        public abstract void ShouldFindAPublicStaticMethodByNameAndParamTypes();

        public abstract void ShouldFindPublicInstanceMethods();

        public abstract void ShouldFindAPublicInstanceMethodByName();

        public abstract void ShouldFindAPublicInstanceMethodByNameAndParamCount();

        public abstract void ShouldExcludeAPublicInstanceMethodByParamCount();

        public abstract void ShouldFindAPublicInstanceMethodByNameAndParamTypes();

        public abstract void ShouldErrorIfPublicInstanceMethodsHaveSameNameAndParamCount();

        public abstract void ShouldFindAnInheritedPublicInstanceMethodByName();

        public abstract void ShouldFindAnInheritedPublicInstanceMethodByNameAndParamCount();

        public abstract void ShouldFindNonPublicStaticMethods();

        public abstract void ShouldFindANonPublicStaticMethodByName();

        public abstract void ShouldFindANonPublicStaticMethodByNameAndParamCount();

        public abstract void ShouldFindANonPublicStaticMethodByNameAndParamTypes();

        public abstract void ShouldFindNonPublicInstanceMethods();

        public abstract void ShouldFindANonPublicInstanceMethodByName();

        public abstract void ShouldFindANonPublicInstanceMethodByNameAndParamCount();

        public abstract void ShouldFindANonPublicInstanceMethodByNameAndParamTypes();

        public abstract void ShouldExcludeANonPublicInstanceMethodByNameAndParamTypes();

        #region Test Implementations

        protected void DoShouldFindPublicMethods()
        {
            var methods = typeof(TestHelper)
                .GetPublicMethods()
                .Select(m => m.Name)
                .ToList();

            methods.ShouldContain("GetHashCode");
            methods.ShouldContain("PublicStaticMethod");
            methods.ShouldContain("ReferenceEquals");
        }

        protected void DoShouldFindAPublicMethodByName()
        {
            typeof(TestHelper)
                .GetPublicMethod("PublicStaticMethod")
                .ShouldNotBeNull()
                .Name.ShouldBe("PublicStaticMethod");
        }

        protected void DoShouldExcludeAPublicMethodByName()
        {
            typeof(TestHelper)
                .GetPublicMethod("NonPublicMethod")
                .ShouldBeNull();
        }

        protected void DoShouldFindAPublicMethodByNameAndParamCount()
        {
            var method = typeof(MethodTestsHelper)
                .GetPublicMethod("PublicStatic", 1);

            method.ShouldNotBeNull();
            method.Name.ShouldBe("PublicStatic");
            method.GetParameters().ShouldHaveSingleItem();
        }

        protected void DoShouldFindAPublicMethodByNameAndParamTypes()
        {
            var method = typeof(MethodTestsHelper)
                .GetPublicMethod("PublicStatic", typeof(int));

            method.ShouldNotBeNull();
            method.Name.ShouldBe("PublicStatic");
            method.GetParameters().ShouldHaveSingleItem();
            method.GetParameters()[0].ParameterType.ShouldBe(typeof(int));
        }

        protected void DoShouldFindPublicStaticMethods()
        {
            var methods = typeof(TestHelper)
                .GetPublicStaticMethods()
                .Select(m => m.Name)
                .ToList();

            methods.ShouldContain("PublicStaticMethod");
            methods.ShouldContain("ReferenceEquals");
        }

        protected void DoShouldFindAPublicStaticMethodByName()
        {
            typeof(TestHelper)
                .GetPublicStaticMethod("PublicStaticMethod")
                .ShouldNotBeNull()
                .Name.ShouldBe("PublicStaticMethod");
        }

        protected void DoShouldExcludeAPublicStaticMethodByName()
        {
            typeof(TestHelper)
                .GetPublicStaticMethod("PublicInstanceMethod")
                .ShouldBeNull();
        }

        protected void DoShouldFindAPublicStaticMethodByNameAndParamCount()
        {
            var method = typeof(MethodTestsHelper)
                .GetPublicStaticMethod("PublicStatic", 1);

            method.ShouldNotBeNull();
            method.Name.ShouldBe("PublicStatic");
            method.GetParameters().ShouldHaveSingleItem();
        }

        protected void DoShouldFindAPublicStaticMethodByNameAndParamTypes()
        {
            var method = typeof(MethodTestsHelper)
                .GetPublicStaticMethod("PublicStatic", typeof(int));

            method.ShouldNotBeNull();
            method.Name.ShouldBe("PublicStatic");
            method.GetParameters().ShouldHaveSingleItem();
            method.GetParameters()[0].ParameterType.ShouldBe(typeof(int));
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

        protected void DoShouldExcludeAPublicInstanceMethodByParamCount()
        {
            typeof(MethodTestsHelper)
                .GetPublicInstanceMethod("PublicInstance", 20)
                .ShouldBeNull();
        }

        protected void DoShouldFindAPublicInstanceMethodByNameAndParamTypes()
        {
            var method = typeof(MethodTestsHelper)
                .GetPublicInstanceMethod("PublicInstanceTypeOverload", typeof(string));

            method.ShouldNotBeNull();
            method.Name.ShouldBe("PublicInstanceTypeOverload");
            method.GetParameters().ShouldHaveSingleItem();
        }

        protected void DoShouldErrorIfPublicInstanceMethodsHaveSameNameAndParamCount()
        {
            Should.Throw<AmbiguousMatchException>(() =>
            {
                typeof(MethodTestsHelper)
                    .GetPublicInstanceMethod("PublicInstanceTypeOverload", 1);
            });
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

        protected void DoShouldFindANonPublicStaticMethodByNameAndParamTypes()
        {
            var method = typeof(MethodTestsHelper)
                .GetNonPublicStaticMethod("NonPublicStatic", typeof(int), typeof(string));

            method.ShouldNotBeNull();
            method.Name.ShouldBe("NonPublicStatic");
            method.GetParameters().Length.ShouldBe(2);
            method.GetParameters()[0].ParameterType.ShouldBe(typeof(int));
            method.GetParameters()[1].ParameterType.ShouldBe(typeof(string));
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

        protected void DoShouldFindANonPublicInstanceMethodByNameAndParamTypes()
        {
            var method = typeof(MethodTestsHelper)
                .GetNonPublicInstanceMethod("NonPublicInstance", typeof(int));

            method.ShouldNotBeNull();
            method.Name.ShouldBe("NonPublicInstance");
            method.GetParameters().ShouldHaveSingleItem();
            method.GetParameters()[0].ParameterType.ShouldBe(typeof(int));
        }

        protected void DoShouldExcludeANonPublicInstanceMethodByNameAndParamTypes()
        {
            typeof(MethodTestsHelper)
                .GetNonPublicInstanceMethod("NonPublicInstance", typeof(DateTime))
                .ShouldBeNull();
        }

        #endregion
    }
}