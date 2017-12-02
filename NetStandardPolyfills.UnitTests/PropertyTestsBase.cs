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

        public abstract void ShouldRetrievePublicPropertyAccessors();

        public abstract void ShouldExcludeNonPublicPropertyAccessorsByDefault();

        public abstract void ShouldIncludeNonPublicPropertyAccessors();

        public abstract void ShouldRetrieveIndexAccessors();

        public abstract void ShouldRetrieveNonPublicIndexAccessors();

        public abstract void ShouldRetrieveAGetAccessor();

        public abstract void ShouldRetrieveANonPublicSetAccessor();

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
                .FirstOrDefault(p => p.Name == "PublicInstanceProperty")
                .ShouldNotBeNull();
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

        protected void DoShouldRetrievePublicPropertyAccessors()
        {
            var accessors = typeof(TestHelper)
                .GetPublicInstanceProperty("PublicInstanceProperty")
                .ShouldNotBeNull()
                .GetAccessors();

            accessors.Length.ShouldBe(2);
            accessors[0].IsSpecialName.ShouldBeTrue();
            accessors[0].Name.ShouldBe("get_PublicInstanceProperty");
            accessors[1].IsSpecialName.ShouldBeTrue();
            accessors[1].Name.ShouldBe("set_PublicInstanceProperty");
        }

        protected void DoShouldExcludeNonPublicPropertyAccessorsByDefault()
        {
            var accessors = typeof(TestHelper)
                .GetNonPublicInstanceProperty("NonPublicInstanceProperty")
                .ShouldNotBeNull()
                .GetAccessors();

            accessors.ShouldBeEmpty();
        }

        protected void DoShouldIncludeNonPublicPropertyAccessors()
        {
            var accessors = typeof(TestHelper)
                .GetNonPublicInstanceProperty("NonPublicInstanceProperty")
                .ShouldNotBeNull()
                .GetAccessors(nonPublic: true);

            accessors.Length.ShouldBe(2);
            accessors[0].IsSpecialName.ShouldBeTrue();
            accessors[0].Name.ShouldBe("get_NonPublicInstanceProperty");
            accessors[1].IsSpecialName.ShouldBeTrue();
            accessors[1].Name.ShouldBe("set_NonPublicInstanceProperty");
        }

        protected void DoShouldRetrieveIndexAccessors()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperties()
                .FirstOrDefault(p => p.IsIndexer())
                .ShouldNotBeNull()
                .GetAccessors()
                .ShouldHaveSingleItem()
                .Name.ShouldBe("get_Item");
        }

        protected void DoShouldRetrieveNonPublicIndexAccessors()
        {
            var accessors = typeof(TestHelper)
                .GetPublicInstanceProperties()
                .FirstOrDefault(p => p.IsIndexer())
                .ShouldNotBeNull()
                .GetAccessors(nonPublic: true);

            accessors.Length.ShouldBe(2);
            accessors[0].IsSpecialName.ShouldBeTrue();
            accessors[0].Name.ShouldBe("get_Item");
            accessors[1].IsSpecialName.ShouldBeTrue();
            accessors[1].Name.ShouldBe("set_Item");
        }

        protected void DoShouldRetrieveAGetAccessor()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperties()
                .FirstOrDefault(p => p.IsIndexer())
                .ShouldNotBeNull()
                .GetGetter()
                .ShouldNotBeNull()
                .Name.ShouldBe("get_Item");
        }

        protected void DoShouldRetrieveANonPublicSetAccessor()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperties()
                .FirstOrDefault(p => p.IsIndexer())
                .ShouldNotBeNull()
                .GetSetter(nonPublic: true)
                .ShouldNotBeNull()
                .Name.ShouldBe("set_Item");
        }

        #endregion
    }
}