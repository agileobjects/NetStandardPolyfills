namespace AgileObjects.NetStandardPolyfills.UnitTests.Net40
{
    using NUnit.Framework;

    [TestFixture]
    public class WhenRetrievingTypeProperties : PropertyTestsBase
    {
        [Test]
        public override void ShouldRetrievePublicStaticProperties() => DoShouldRetrievePublicStaticProperties();

        [Test]
        public override void ShouldRetrieveAPublicStaticPropertyByName() => DoShouldRetrieveAPublicStaticPropertyByName();

        [Test]
        public override void ShouldExcludeAPublicStaticPropertyByName() => DoShouldExcludeAPublicStaticPropertyByName();

        [Test]
        public override void ShouldRetrieveNonPublicStaticProperties() => DoShouldRetrieveNonPublicStaticProperties();

        [Test]
        public override void ShouldRetrieveANonPublicStaticPropertyByName() =>
            DoShouldRetrieveANonPublicStaticPropertyByName();

        [Test]
        public override void ShouldExcludeANonPublicStaticPropertyByName() => DoShouldExcludeANonPublicStaticPropertyByName();

        [Test]
        public override void ShouldRetrievePublicInstanceProperties() => DoShouldRetrievePublicInstanceProperties();

        [Test]
        public override void ShouldRetrieveAPublicInstancePropertyByName() => DoShouldRetrieveAPublicInstancePropertyByName();

        [Test]
        public override void ShouldExcludeAPublicInstancePropertyByName() => DoShouldExcludeAPublicInstancePropertyByName();

        [Test]
        public override void ShouldRetrieveNonPublicInstanceProperties() => DoShouldRetrieveNonPublicInstanceProperties();

        [Test]
        public override void ShouldRetrieveANonPublicInstancePropertyByName() =>
            DoShouldRetrieveANonPublicInstancePropertyByName();

        [Test]
        public override void ShouldExcludeANonPublicInstancePropertyByName() =>
            DoShouldExcludeANonPublicInstancePropertyByName();
    }
}