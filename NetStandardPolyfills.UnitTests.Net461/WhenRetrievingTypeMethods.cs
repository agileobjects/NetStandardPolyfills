namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using TestClasses;
#if FEATURE_XUNIT
    using Xunit;
#else
    using Fact = NUnit.Framework.TestAttribute;

    [NUnit.Framework.TestFixture]
#endif
    public class WhenRetrievingTypeMethods
    {
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
        public void ShouldFlagAnExtensionMethod()
        {
            typeof(Enumerable)
                .GetPublicStaticMethod(nameof(Enumerable.Cast))
                .ShouldNotBeNull()
                .IsExtensionMethod()
                .ShouldBeTrue();
        }

        [Fact]
        public void ShouldFlagANonExtensionMethod()
        {
            typeof(object)
                .GetPublicStaticMethod(nameof(ReferenceEquals))
                .ShouldNotBeNull()
                .IsExtensionMethod()
                .ShouldBeFalse();
        }

        [Fact]
        public void ShouldFlagAPublicStaticGetterAccessor()
        {
            typeof(TestHelper)
                .GetPublicStaticProperty("PublicStaticProperty")
                .GetGetter()
                .IsAccessor()
                .ShouldBeTrue();
        }

        [Fact]
        public void ShouldFlagANonPublicInstanceSetterAccessor()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceProperty("NonPublicInstanceProperty")
                .GetSetter(nonPublic: true)
                .IsAccessor()
                .ShouldBeTrue();
        }

        [Fact]
        public void ShouldFindAPublicInstanceGetterAccessor()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperty("PublicInstanceProperty")
                .GetGetter()
                .IsAccessor(out var property)
                .ShouldBeTrue();

            property
                .ShouldNotBeNull()
                .Name.ShouldBe("PublicInstanceProperty");
        }

        [Fact]
        public void ShouldFindANonPublicStaticSetterAccessor()
        {
            typeof(TestHelper)
                .GetNonPublicStaticProperty("NonPublicStaticProperty")
                .GetSetter(nonPublic: true)
                .IsAccessor(out var property)
                .ShouldBeTrue();

            property
                .ShouldNotBeNull()
                .Name.ShouldBe("NonPublicStaticProperty");
        }

        [Fact]
        public void ShouldFindAPublicInstanceIndexGetAccessorProperty()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperties()
                .FirstOrDefault(p => p.IsIndexer())
                .ShouldNotBeNull()
                .GetAccessors()
                .ShouldHaveSingleItem()
                .IsAccessor(out var property)
                .ShouldBeTrue();

            property
                .ShouldNotBeNull()
                .Name.ShouldBe("Item");
        }

        [Fact]
        public void ShouldFindANonPublicInstanceIndexSetAccessorProperty()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperties()
                .FirstOrDefault(p => p.IsIndexer())
                .ShouldNotBeNull()
                .GetSetter(nonPublic: true)
                .ShouldNotBeNull()
                .IsAccessor(out var property)
                .ShouldBeTrue();

            property
                .ShouldNotBeNull()
                .Name.ShouldBe("Item");
        }

        [Fact]
        public void ShouldFindPublicMethods()
        {
            var methods = typeof(TestHelper)
                .GetPublicMethods()
                .Select(m => m.Name)
                .ToList();

            methods.ShouldContain("GetHashCode");
            methods.ShouldContain("PublicStaticMethod");
            methods.ShouldContain("ReferenceEquals");
        }

        [Fact]
        public void ShouldFindAPublicMethodByName()
        {
            typeof(TestHelper)
                .GetPublicMethod("PublicStaticMethod")
                .ShouldNotBeNull()
                .Name.ShouldBe("PublicStaticMethod");
        }

        [Fact]
        public void ShouldExcludeAPublicMethodByName()
        {
            typeof(TestHelper)
                .GetPublicMethod("NonPublicMethod")
                .ShouldBeNull();
        }

        [Fact]
        public void ShouldFindAPublicMethodByNameAndParamCount()
        {
            var method = typeof(MethodTestsHelper)
                .GetPublicMethod("PublicStatic", 1);

            method.ShouldNotBeNull();
            method.Name.ShouldBe("PublicStatic");
            method.GetParameters().ShouldHaveSingleItem();
        }

        [Fact]
        public void ShouldFindAPublicMethodByNameAndParamTypes()
        {
            var method = typeof(MethodTestsHelper)
                .GetPublicMethod("PublicStatic", typeof(int));

            method.ShouldNotBeNull();
            method.Name.ShouldBe("PublicStatic");
            method.GetParameters().ShouldHaveSingleItem();
            method.GetParameters()[0].ParameterType.ShouldBe(typeof(int));
        }

        [Fact]
        public void ShouldFindPublicStaticMethods()
        {
            var methods = typeof(TestHelper)
                .GetPublicStaticMethods()
                .Select(m => m.Name)
                .ToList();

            methods.ShouldContain("PublicStaticMethod");
            methods.ShouldContain("ReferenceEquals");
        }

        [Fact]
        public void ShouldFindAPublicStaticMethodByName()
        {
            typeof(TestHelper)
                .GetPublicStaticMethod("PublicStaticMethod")
                .ShouldNotBeNull()
                .Name.ShouldBe("PublicStaticMethod");
        }

        [Fact]
        public void ShouldExcludeAPublicStaticMethodByName()
        {
            typeof(TestHelper)
                .GetPublicStaticMethod("PublicInstanceMethod")
                .ShouldBeNull();
        }

        [Fact]
        public void ShouldFindAPublicStaticMethodByNameAndParamCount()
        {
            var method = typeof(MethodTestsHelper)
                .GetPublicStaticMethod("PublicStatic", 1);

            method.ShouldNotBeNull();
            method.Name.ShouldBe("PublicStatic");
            method.GetParameters().ShouldHaveSingleItem();
        }

        [Fact]
        public void ShouldFindAPublicStaticMethodByNameAndParamTypes()
        {
            var method = typeof(MethodTestsHelper)
                .GetPublicStaticMethod("PublicStatic", typeof(int));

            method.ShouldNotBeNull();
            method.Name.ShouldBe("PublicStatic");
            method.GetParameters().ShouldHaveSingleItem();
            method.GetParameters()[0].ParameterType.ShouldBe(typeof(int));
        }

        [Fact]
        public void ShouldFindPublicInstanceMethods()
        {
            var methods = typeof(TestHelper)
                .GetPublicInstanceMethods()
                .Select(m => m.Name)
                .ToList();

            methods.ShouldContain("DoParamsStuff");
            methods.ShouldContain("DoNonParamsStuff");
            methods.ShouldContain("GetHashCode");
        }

        [Fact]
        public void ShouldFindAPublicInstanceMethodByName()
        {
            typeof(TestHelper)
                .GetPublicInstanceMethod("DoParamsStuff")
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldFindAPublicInstanceMethodByNameAndParamCount()
        {
            var method = typeof(MethodTestsHelper)
                .GetPublicInstanceMethod("PublicInstance", 2);

            method.ShouldNotBeNull();
            method.Name.ShouldBe("PublicInstance");
            method.GetParameters().Length.ShouldBe(2);
        }

        [Fact]
        public void ShouldExcludeAPublicInstanceMethodByParamCount()
        {
            typeof(MethodTestsHelper)
                .GetPublicInstanceMethod("PublicInstance", 20)
                .ShouldBeNull();
        }

        [Fact]
        public void ShouldFindAPublicInstanceMethodByNameAndParamTypes()
        {
            var method = typeof(MethodTestsHelper)
                .GetPublicInstanceMethod("PublicInstanceTypeOverload", typeof(string));

            method.ShouldNotBeNull();
            method.Name.ShouldBe("PublicInstanceTypeOverload");
            method.GetParameters().ShouldHaveSingleItem();
        }

        [Fact]
        public void ShouldErrorIfPublicInstanceMethodsHaveSameNameAndParamCount()
        {
            Should.Throw<AmbiguousMatchException>(() =>
            {
                typeof(MethodTestsHelper)
                    .GetPublicInstanceMethod("PublicInstanceTypeOverload", 1);
            });
        }

        [Fact]
        public void ShouldFindAnInheritedPublicInstanceMethodByName()
        {
            typeof(MyTestEnum)
                .GetPublicInstanceMethod("GetHashCode")
                .ShouldNotBeNull()
                .Name.ShouldBe("GetHashCode");
        }

        [Fact]
        public void ShouldFindAnInheritedPublicInstanceMethodByNameAndParamCount()
        {
            var method = typeof(MyTestEnum)
                .GetPublicInstanceMethod("ToString", 0);

            method.ShouldNotBeNull();
            method.Name.ShouldBe("ToString");
            method.GetParameters().ShouldBeEmpty();
        }

        [Fact]
        public void ShouldFindNonPublicStaticMethods()
        {
            var methods = typeof(TestHelper)
                .GetNonPublicStaticMethods()
                .Select(m => m.Name)
                .ToList();

            methods.ShouldContain("NonPublicStaticMethod");
            methods.ShouldNotContain("ReferenceEquals");
        }

        [Fact]
        public void ShouldFindANonPublicStaticMethodByName()
        {
            typeof(TestHelper)
                .GetNonPublicStaticMethod("NonPublicStaticMethod")
                .ShouldNotBeNull()
                .Name.ShouldBe("NonPublicStaticMethod");
        }

        [Fact]
        public void ShouldFindANonPublicStaticMethodByNameAndParamCount()
        {
            var method = typeof(MethodTestsHelper)
                .GetNonPublicStaticMethod("NonPublicStatic", 2);

            method.ShouldNotBeNull();
            method.Name.ShouldBe("NonPublicStatic");
            method.GetParameters().Length.ShouldBe(2);
        }

        [Fact]
        public void ShouldFindANonPublicStaticMethodByNameAndParamTypes()
        {
            var method = typeof(MethodTestsHelper)
                .GetNonPublicStaticMethod("NonPublicStatic", typeof(int), typeof(string));

            method.ShouldNotBeNull();
            method.Name.ShouldBe("NonPublicStatic");
            method.GetParameters().Length.ShouldBe(2);
            method.GetParameters()[0].ParameterType.ShouldBe(typeof(int));
            method.GetParameters()[1].ParameterType.ShouldBe(typeof(string));
        }

        [Fact]
        public void ShouldFindNonPublicInstanceMethods()
        {
            var methods = typeof(MethodTestsHelper)
                .GetNonPublicInstanceMethods()
                .Select(m => m.Name)
                .ToList();

            methods[0].ShouldBe("NonPublicInstance");
            methods[1].ShouldBe("NonPublicInstance");
            methods[2].ShouldBe("NonPublicInstance");
        }

        [Fact]
        public void ShouldFindANonPublicInstanceMethodByName()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceMethod("NonPublicMethod")
                .ShouldNotBeNull()
                .Name.ShouldBe("NonPublicMethod");
        }

        [Fact]
        public void ShouldFindANonPublicInstanceMethodByNameAndParamCount()
        {
            var method = typeof(MethodTestsHelper)
                .GetNonPublicInstanceMethod("NonPublicInstance", 2);

            method.ShouldNotBeNull();
            method.Name.ShouldBe("NonPublicInstance");
            method.GetParameters().Length.ShouldBe(2);
        }

        [Fact]
        public void ShouldFindANonPublicInstanceMethodByNameAndParamTypes()
        {
            var method = typeof(MethodTestsHelper)
                .GetNonPublicInstanceMethod("NonPublicInstance", typeof(int));

            method.ShouldNotBeNull();
            method.Name.ShouldBe("NonPublicInstance");
            method.GetParameters().ShouldHaveSingleItem();
            method.GetParameters()[0].ParameterType.ShouldBe(typeof(int));
        }

        [Fact]
        public void ShouldExcludeANonPublicInstanceMethodByNameAndParamTypes()
        {
            typeof(MethodTestsHelper)
                .GetNonPublicInstanceMethod("NonPublicInstance", typeof(DateTime))
                .ShouldBeNull();
        }
    }
}