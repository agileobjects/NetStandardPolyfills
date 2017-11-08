namespace AgileObjects.NetStandardPolyfills.UnitTests.NetCore
{
    using Xunit;

    public class WhenRetrievingTypeMembers : MemberTestsBase
    {
        [Fact]
        public override void ShouldRetrievePublicStaticMembers() => DoShouldRetrievePublicStaticMembers();

        [Fact]
        public override void ShouldRetrievePublicStaticMembersByName() => DoShouldRetrievePublicStaticMembersByName();

        [Fact]
        public override void ShouldExcludePublicStaticMembersByName() => DoShouldExcludePublicStaticMembersByName();

        [Fact]
        public override void ShouldRetrievePublicStaticMemberByName() => DoShouldRetrievePublicStaticMemberByName();

        [Fact]
        public override void ShouldRetrievePublicInstanceMembers() => DoShouldRetrievePublicInstanceMembers();

        [Fact]
        public override void ShouldRetrievePublicInstanceMembersByName() => DoShouldRetrievePublicInstanceMembersByName();

        [Fact]
        public override void ShouldExcludePublicInstanceMembersByName() => DoShouldExcludePublicInstanceMembersByName();

        [Fact]
        public override void ShouldRetrievePublicInstanceMemberByName() => DoShouldRetrievePublicInstanceMemberByName();

        [Fact]
        public override void ShouldRetrieveNonPublicStaticMembers() => DoShouldRetrieveNonPublicStaticMembers();

        [Fact]
        public override void ShouldRetrieveNonPublicStaticMembersByName() => DoShouldRetrieveNonPublicStaticMembersByName();

        [Fact]
        public override void ShouldExcludeNonPublicStaticMembersByName() => DoShouldExcludeNonPublicStaticMembersByName();

        [Fact]
        public override void ShouldRetrieveNonPublicStaticMemberByName() =>
            DoShouldRetrieveNonPublicStaticMemberByName();

        [Fact]
        public override void ShouldRetrieveNonPublicInstanceMembers() => DoShouldRetrieveNonPublicInstanceMembers();

        [Fact]
        public override void ShouldRetrieveNonPublicInstanceMembersByName() => DoShouldRetrieveNonPublicInstanceMembersByName();

        [Fact]
        public override void ShouldExcludeNonPublicInstanceMembersByName() => DoShouldExcludeNonPublicInstanceMembersByName();

        [Fact]
        public override void ShouldRetrieveNonPublicInstanceMemberByName() =>
            DoShouldRetrieveNonPublicInstanceMemberByName();
    }
}