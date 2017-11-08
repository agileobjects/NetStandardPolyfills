namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Linq;
    using TestClasses;

    public abstract class FieldTestsBase
    {
        public abstract void ShouldRetrieveAPublicInstanceField();

        protected void DoShouldRetrieveAPublicInstanceField()
        {
            var fields = typeof(TestHelper).GetPublicInstanceFields();

            fields.ShouldNotBeNull();
            fields.ShouldHaveSingleItem();
            fields.First().Name.ShouldBe("PublicInstanceField");
        }
    }
}