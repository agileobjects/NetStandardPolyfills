namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Linq;
    using TestClasses;
#if FEATURE_XUNIT
    using Xunit;
#else
    using Fact = NUnit.Framework.TestAttribute;

    [NUnit.Framework.TestFixture]
#endif
    public class WhenRetrievingTypeFields
    {
        [Fact]
        public void ShouldRetrievePublicStaticFields()
        {
            typeof(TestHelper)
                .GetPublicStaticFields()
                .ShouldHaveSingleItem()
                .Name.ShouldBe("PublicStaticField");
        }

        [Fact]
        public void ShouldRetrieveAPublicStaticFieldByName()
        {
            typeof(TestHelper)
                .GetPublicStaticField("PublicStaticField")
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldExcludeAPublicStaticFieldByName()
        {
            typeof(TestHelper)
                .GetPublicStaticField("PublicInstanceField")
                .ShouldBeNull();
        }

        [Fact]
        public void ShouldRetrieveNonPublicStaticFields()
        {
            typeof(TestHelper)
                .GetNonPublicStaticFields()
                .ShouldHaveSingleItem()
                .Name.ShouldBe("NonPublicStaticField");
        }

        [Fact]
        public void ShouldRetrieveANonPublicStaticFieldByName()
        {
            typeof(TestHelper)
                .GetNonPublicStaticField("NonPublicStaticField")
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldExcludeANonPublicStaticFieldByName()
        {
            typeof(TestHelper)
                .GetNonPublicStaticField("NonPublicInstanceField")
                .ShouldBeNull();
        }

        [Fact]
        public void ShouldRetrievePublicInstanceFields()
        {
            typeof(TestHelper)
                .GetPublicInstanceFields()
                .ShouldHaveSingleItem()
                .Name.ShouldBe("PublicInstanceField");
        }

        [Fact]
        public void ShouldRetrieveAPublicInstanceFieldByName()
        {
            typeof(TestHelper)
                .GetPublicInstanceField("PublicInstanceField")
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldExcludeAPublicInstanceFieldByName()
        {
            typeof(TestHelper)
                .GetPublicInstanceField("xxx")
                .ShouldBeNull();
        }

        [Fact]
        public void ShouldRetrieveNonPublicInstanceFields()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceFields()
                .FirstOrDefault(f => f.Name == "NonPublicInstanceField")
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldRetrieveANonPublicInstanceFieldByName()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceField("NonPublicInstanceField")
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldExcludeANonPublicInstanceFieldByName()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceField("yyy")
                .ShouldBeNull();
        }
    }
}