namespace AgileObjects.NetStandardPolyfills.UnitTests.NetCore
{
    using Xunit;

    public class WhenRetrievingTypeFields : FieldTestsBase
    {
        [Fact]
        public override void ShouldRetrieveAPublicInstanceField() => DoShouldRetrieveAPublicInstanceField();
    }
}