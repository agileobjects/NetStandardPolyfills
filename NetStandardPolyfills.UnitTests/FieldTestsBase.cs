namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Linq;
    using TestClasses;

    public abstract class FieldTestsBase
    {
        public abstract void ShouldRetrievePublicStaticFields();

        public abstract void ShouldRetrieveAPublicStaticFieldByName();

        public abstract void ShouldExcludeAPublicStaticFieldByName();

        public abstract void ShouldRetrieveNonPublicStaticFields();

        public abstract void ShouldRetrieveANonPublicStaticFieldByName();

        public abstract void ShouldExcludeANonPublicStaticFieldByName();

        public abstract void ShouldRetrievePublicInstanceFields();

        public abstract void ShouldRetrieveAPublicInstanceFieldByName();

        public abstract void ShouldExcludeAPublicInstanceFieldByName();

        public abstract void ShouldRetrieveNonPublicInstanceFields();

        public abstract void ShouldRetrieveANonPublicInstanceFieldByName();

        public abstract void ShouldExcludeANonPublicInstanceFieldByName();

        #region Test Implementations

        protected void DoShouldRetrievePublicStaticFields()
        {
            var fields = typeof(TestHelper).GetPublicStaticFields().ToArray();

            fields.ShouldHaveSingleItem();
            fields.First().Name.ShouldBe("PublicStaticField");
        }

        protected void DoShouldRetrieveAPublicStaticFieldByName()
        {
            typeof(TestHelper)
                .GetPublicStaticField("PublicStaticField")
                .ShouldNotBeNull();
        }

        protected void DoShouldExcludeAPublicStaticFieldByName()
        {
            typeof(TestHelper)
                .GetPublicStaticField("PublicInstanceField")
                .ShouldBeNull();
        }

        protected void DoShouldRetrieveNonPublicStaticFields()
        {
            var fields = typeof(TestHelper).GetNonPublicStaticFields().ToArray();

            fields.ShouldHaveSingleItem();
            fields.First().Name.ShouldBe("NonPublicStaticField");
        }

        protected void DoShouldRetrieveANonPublicStaticFieldByName()
        {
            typeof(TestHelper)
                .GetNonPublicStaticField("NonPublicStaticField")
                .ShouldNotBeNull();
        }

        protected void DoShouldExcludeANonPublicStaticFieldByName()
        {
            typeof(TestHelper)
                .GetNonPublicStaticField("NonPublicInstanceField")
                .ShouldBeNull();
        }

        protected void DoShouldRetrievePublicInstanceFields()
        {
            var fields = typeof(TestHelper).GetPublicInstanceFields().ToArray();

            fields.ShouldHaveSingleItem();
            fields.First().Name.ShouldBe("PublicInstanceField");
        }

        protected void DoShouldRetrieveAPublicInstanceFieldByName()
        {
            typeof(TestHelper)
                .GetPublicInstanceField("PublicInstanceField")
                .ShouldNotBeNull();
        }

        protected void DoShouldExcludeAPublicInstanceFieldByName()
        {
            typeof(TestHelper)
                .GetPublicInstanceField("xxx")
                .ShouldBeNull();
        }

        protected void DoShouldRetrieveNonPublicInstanceFields()
        {
            var fields = typeof(TestHelper).GetNonPublicInstanceFields().ToArray();

            fields.ShouldHaveSingleItem();
            fields.First().Name.ShouldBe("NonPublicInstanceField");
        }

        protected void DoShouldRetrieveANonPublicInstanceFieldByName()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceField("NonPublicInstanceField")
                .ShouldNotBeNull();
        }

        protected void DoShouldExcludeANonPublicInstanceFieldByName()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceField("yyy")
                .ShouldBeNull();
        }

        #endregion
    }
}