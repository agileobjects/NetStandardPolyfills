namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Linq;
    using TestClasses;

    public abstract class PropertyTestsBase
    {
        public abstract void ShouldRetrievePublicStaticProperties();

        public abstract void ShouldRetrieveAPublicStaticPropertyByName();

        public abstract void ShouldExcludeAPublicStaticPropertyByName();

        public abstract void ShouldRetrieveNonPublicStaticProperties();

        public abstract void ShouldRetrieveANonPublicStaticPropertyByName();

        public abstract void ShouldExcludeANonPublicStaticPropertyByName();

        public abstract void ShouldRetrievePublicInstanceProperties();

        public abstract void ShouldRetrieveAPublicInstancePropertyByName();

        public abstract void ShouldExcludeAPublicInstancePropertyByName();

        public abstract void ShouldRetrieveNonPublicInstanceProperties();

        public abstract void ShouldRetrieveANonPublicInstancePropertyByName();

        public abstract void ShouldExcludeANonPublicInstancePropertyByName();

        #region Test Implementations

        protected void DoShouldRetrievePublicStaticProperties()
        {
            var fields = typeof(TestHelper).GetPublicStaticProperties().ToArray();

            fields.ShouldHaveSingleItem();
            fields.First().Name.ShouldBe("PublicStaticProperty");
        }

        protected void DoShouldRetrieveAPublicStaticPropertyByName()
        {
            typeof(TestHelper)
                .GetPublicStaticProperty("PublicStaticProperty")
                .ShouldNotBeNull();
        }

        protected void DoShouldExcludeAPublicStaticPropertyByName()
        {
            typeof(TestHelper)
                .GetPublicStaticProperty("PublicInstanceProperty")
                .ShouldBeNull();
        }

        protected void DoShouldRetrieveNonPublicStaticProperties()
        {
            var fields = typeof(TestHelper).GetNonPublicStaticProperties().ToArray();

            fields.ShouldHaveSingleItem();
            fields.First().Name.ShouldBe("NonPublicStaticProperty");
        }

        protected void DoShouldRetrieveANonPublicStaticPropertyByName()
        {
            typeof(TestHelper)
                .GetNonPublicStaticProperty("NonPublicStaticProperty")
                .ShouldNotBeNull();
        }

        protected void DoShouldExcludeANonPublicStaticPropertyByName()
        {
            typeof(TestHelper)
                .GetNonPublicStaticProperty("NonPublicInstanceProperty")
                .ShouldBeNull();
        }

        protected void DoShouldRetrievePublicInstanceProperties()
        {
            var fields = typeof(TestHelper).GetPublicInstanceProperties().ToArray();

            fields.ShouldHaveSingleItem();
            fields.First().Name.ShouldBe("PublicInstanceProperty");
        }

        protected void DoShouldRetrieveAPublicInstancePropertyByName()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperty("PublicInstanceProperty")
                .ShouldNotBeNull();
        }

        protected void DoShouldExcludeAPublicInstancePropertyByName()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperty("xxx")
                .ShouldBeNull();
        }

        protected void DoShouldRetrieveNonPublicInstanceProperties()
        {
            var fields = typeof(TestHelper).GetNonPublicInstanceProperties().ToArray();

            fields.ShouldHaveSingleItem();
            fields.First().Name.ShouldBe("NonPublicInstanceProperty");
        }

        protected void DoShouldRetrieveANonPublicInstancePropertyByName()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceProperty("NonPublicInstanceProperty")
                .ShouldNotBeNull();
        }

        protected void DoShouldExcludeANonPublicInstancePropertyByName()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceProperty("yyy")
                .ShouldBeNull();
        }

        #endregion
    }
}