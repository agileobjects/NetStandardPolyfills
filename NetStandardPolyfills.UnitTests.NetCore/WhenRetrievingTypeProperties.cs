namespace AgileObjects.NetStandardPolyfills.UnitTests.NetCore
{
    using Xunit;

    public class WhenRetrievingTypeProperties : PropertyTestsBase
    {
        [Fact]
        public override void ShouldRetrieveAPublicInstanceProperty() => DoShouldRetrieveAPublicInstanceProperty();
    }
}