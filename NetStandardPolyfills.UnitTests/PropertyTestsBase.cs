namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Linq;
    using TestClasses;

    public abstract class PropertyTestsBase
    {
        public abstract void ShouldRetrieveAPublicInstanceProperty();

        protected void DoShouldRetrieveAPublicInstanceProperty()
        {
            var properties = typeof(TestHelper).GetPublicInstanceProperties().ToArray();

            properties.ShouldNotBeNull();
            properties.ShouldHaveSingleItem();
            properties.First().Name.ShouldBe("PublicInstanceProperty");
        }
    }
}