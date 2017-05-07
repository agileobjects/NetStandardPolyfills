namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Linq;
    using Shouldly;
    using Xunit;

    public class WhenRetrievingTypeMembers
    {
        [Fact]
        public void ShouldFindAPublicInstanceConstructor()
        {
            var constructor = typeof(TestHelper)
                .GetPublicInstanceConstructors()
                .FirstOrDefault();

            constructor.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldFindANonPublicInstanceConstructor()
        {
            var constructor = typeof(TestHelper)
                .GetNonPublicInstanceConstructors()
                .FirstOrDefault();

            constructor.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldRetrieveAPublicInstanceField()
        {
            var fields = typeof(TestHelper).GetPublicInstanceFields();

            fields.ShouldNotBeNull();
            fields.ShouldHaveSingleItem();
            fields.First().Name.ShouldBe("PublicInstanceField");
        }

        [Fact]
        public void ShouldRetrieveAPublicInstanceProperty()
        {
            var properties = typeof(TestHelper).GetPublicInstanceProperties();

            properties.ShouldNotBeNull();
            properties.ShouldHaveSingleItem();
            properties.First().Name.ShouldBe("PublicInstanceProperty");
        }

        [Fact]
        public void ShouldFindAPublicInstanceMethod()
        {
            var paramsStuff = typeof(TestHelper)
                .GetPublicInstanceMethods()
                .FirstOrDefault(m => m.Name == "DoParamsStuff");

            paramsStuff.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldFindAnInheritedPublicInstanceMethod()
        {
            var parameterlessToString = typeof(MyTestEnum)
                .GetPublicInstanceMethods()
                .FirstOrDefault(m => m.Name == "ToString" && m.GetParameters().Length == 0);

            parameterlessToString.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldFindANonPublicInstanceMethod()
        {
            var method = typeof(TestHelper)
                .GetNonPublicInstanceMethods()
                .FirstOrDefault();

            method.ShouldNotBeNull();
            method.Name.ShouldBe("NonPublicMethod");
        }

        [Fact]
        public void ShouldFindAPublicStaticMethod()
        {
            var method = typeof(TestHelper)
                .GetPublicStaticMethod("PublicStaticMethod");

            method.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldFindANonPublicStaticMethod()
        {
            var method = typeof(TestHelper)
                .GetNonPublicStaticMethod("NonPublicStaticMethod");

            method.ShouldNotBeNull();
        }
    }
}