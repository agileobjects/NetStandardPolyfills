namespace AgileObjects.NetStandardPolyfills.UnitTests
{
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
            typeof(TestHelper)
                .GetPublicStaticProperties()
                .ShouldHaveSingleItem()
                .Name.ShouldBe("PublicStaticProperty");
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
            typeof(TestHelper)
                .GetNonPublicStaticProperties()
                .ShouldHaveSingleItem()
                .Name.ShouldBe("NonPublicStaticProperty");
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
            typeof(TestHelper)
                .GetPublicInstanceProperties()
                .ShouldHaveSingleItem()
                .Name.ShouldBe("PublicInstanceProperty");
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
            typeof(TestHelper)
                .GetNonPublicInstanceProperties()
                .ShouldHaveSingleItem()
                .Name.ShouldBe("NonPublicInstanceProperty");
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