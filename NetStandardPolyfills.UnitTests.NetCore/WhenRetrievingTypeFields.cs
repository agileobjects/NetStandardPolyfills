namespace AgileObjects.NetStandardPolyfills.UnitTests.NetCore
{
    using Xunit;

    public class WhenRetrievingTypeFields : FieldTestsBase
    {
        [Fact]
        public override void ShouldRetrievePublicStaticFields() => DoShouldRetrievePublicStaticFields();

        [Fact]
        public override void ShouldRetrieveAPublicStaticFieldByName() => DoShouldRetrieveAPublicStaticFieldByName();

        [Fact]
        public override void ShouldExcludeAPublicStaticFieldByName() => DoShouldExcludeAPublicStaticFieldByName();

        [Fact]
        public override void ShouldRetrieveNonPublicStaticFields() => DoShouldRetrieveNonPublicStaticFields();

        [Fact]
        public override void ShouldRetrieveANonPublicStaticFieldByName() =>
            DoShouldRetrieveANonPublicStaticFieldByName();

        [Fact]
        public override void ShouldExcludeANonPublicStaticFieldByName() => DoShouldExcludeANonPublicStaticFieldByName();

        [Fact]
        public override void ShouldRetrievePublicInstanceFields() => DoShouldRetrievePublicInstanceFields();

        [Fact]
        public override void ShouldRetrieveAPublicInstanceFieldByName() => DoShouldRetrieveAPublicInstanceFieldByName();

        [Fact]
        public override void ShouldExcludeAPublicInstanceFieldByName() => DoShouldExcludeAPublicInstanceFieldByName();

        [Fact]
        public override void ShouldRetrieveNonPublicInstanceFields() => DoShouldRetrieveNonPublicInstanceFields();

        [Fact]
        public override void ShouldRetrieveANonPublicInstanceFieldByName() =>
            DoShouldRetrieveANonPublicInstanceFieldByName();

        [Fact]
        public override void ShouldExcludeANonPublicInstanceFieldByName() =>
            DoShouldExcludeANonPublicInstanceFieldByName();
    }
}