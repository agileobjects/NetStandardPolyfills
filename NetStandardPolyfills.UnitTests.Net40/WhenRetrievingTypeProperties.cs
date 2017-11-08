namespace AgileObjects.NetStandardPolyfills.UnitTests.Net40
{
    using NUnit.Framework;

    [TestFixture]
    public class WhenRetrievingTypeProperties : PropertyTestsBase
    {
        [Test]
        public override void ShouldRetrieveAPublicInstanceProperty() => DoShouldRetrieveAPublicInstanceProperty();
    }
}