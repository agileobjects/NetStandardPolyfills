namespace AgileObjects.NetStandardPolyfills.UnitTests.NetCore
{
    using Xunit;

    public class WhenRetrievingTypeProperties : PropertyTestsBase
    {
        [Fact]
        public override void ShouldRetrievePublicStaticProperties() => DoShouldRetrievePublicStaticProperties();

        [Fact]
        public override void ShouldRetrieveAPublicStaticPropertyByName() => DoShouldRetrieveAPublicStaticPropertyByName();

        [Fact]
        public override void ShouldExcludeAPublicStaticPropertyByName() => DoShouldExcludeAPublicStaticPropertyByName();

        [Fact]
        public override void ShouldRetrieveNonPublicStaticProperties() => DoShouldRetrieveNonPublicStaticProperties();

        [Fact]
        public override void ShouldRetrieveANonPublicStaticPropertyByName() =>
            DoShouldRetrieveANonPublicStaticPropertyByName();

        [Fact]
        public override void ShouldExcludeANonPublicStaticPropertyByName() => DoShouldExcludeANonPublicStaticPropertyByName();

        [Fact]
        public override void ShouldRetrievePublicInstanceProperties() => DoShouldRetrievePublicInstanceProperties();

        [Fact]
        public override void ShouldRetrieveAPublicInstancePropertyByName() => DoShouldRetrieveAPublicInstancePropertyByName();

        [Fact]
        public override void ShouldExcludeAPublicInstancePropertyByName() => DoShouldExcludeAPublicInstancePropertyByName();

        [Fact]
        public override void ShouldRetrieveNonPublicInstanceProperties() => DoShouldRetrieveNonPublicInstanceProperties();

        [Fact]
        public override void ShouldRetrieveANonPublicInstancePropertyByName() =>
            DoShouldRetrieveANonPublicInstancePropertyByName();

        [Fact]
        public override void ShouldExcludeANonPublicInstancePropertyByName() =>
            DoShouldExcludeANonPublicInstancePropertyByName();
    }
}