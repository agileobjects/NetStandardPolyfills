using NUnit.Framework;

namespace AgileObjects.NetStandardPolyfills.UnitTests.Net35
{
    [TestFixture]
    public class WhenRetrievingTypeFields : FieldTestsBase
    {
        [Test]
        public override void ShouldRetrievePublicStaticFields() => DoShouldRetrievePublicStaticFields();

        [Test]
        public override void ShouldRetrieveAPublicStaticFieldByName() => DoShouldRetrieveAPublicStaticFieldByName();

        [Test]
        public override void ShouldExcludeAPublicStaticFieldByName() => DoShouldExcludeAPublicStaticFieldByName();

        [Test]
        public override void ShouldRetrieveNonPublicStaticFields() => DoShouldRetrieveNonPublicStaticFields();

        [Test]
        public override void ShouldRetrieveANonPublicStaticFieldByName() =>
            DoShouldRetrieveANonPublicStaticFieldByName();

        [Test]
        public override void ShouldExcludeANonPublicStaticFieldByName() => DoShouldExcludeANonPublicStaticFieldByName();

        [Test]
        public override void ShouldRetrievePublicInstanceFields() => DoShouldRetrievePublicInstanceFields();

        [Test]
        public override void ShouldRetrieveAPublicInstanceFieldByName() => DoShouldRetrieveAPublicInstanceFieldByName();

        [Test]
        public override void ShouldExcludeAPublicInstanceFieldByName() => DoShouldExcludeAPublicInstanceFieldByName();

        [Test]
        public override void ShouldRetrieveNonPublicInstanceFields() => DoShouldRetrieveNonPublicInstanceFields();

        [Test]
        public override void ShouldRetrieveANonPublicInstanceFieldByName() =>
            DoShouldRetrieveANonPublicInstanceFieldByName();

        [Test]
        public override void ShouldExcludeANonPublicInstanceFieldByName() =>
            DoShouldExcludeANonPublicInstanceFieldByName();
    }
}