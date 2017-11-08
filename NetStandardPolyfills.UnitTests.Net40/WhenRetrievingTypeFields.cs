namespace AgileObjects.NetStandardPolyfills.UnitTests.Net40
{
    using NUnit.Framework;

    [TestFixture]
    public class WhenRetrievingTypeFields : FieldTestsBase
    {
        [Test]
        public override void ShouldRetrieveAPublicInstanceField() => DoShouldRetrieveAPublicInstanceField();
    }
}