namespace AgileObjects.NetStandardPolyfills.UnitTests.NetCore
{
    using Xunit;

    public class WhenRetrievingTypeMembers : MemberTestsBase
    {
        [Fact]
        public override void ShouldRetrievePublicInstanceMembers() => DoShouldRetrievePublicInstanceMembers();

        [Fact]
        public override void ShouldRetrievePublicInstanceMembersByName() => DoShouldRetrievePublicInstanceMembersByName();

        [Fact]
        public override void ShouldExcludePublicStaticMembersByName() => DoShouldExcludePublicStaticMembersByName();
    }
}