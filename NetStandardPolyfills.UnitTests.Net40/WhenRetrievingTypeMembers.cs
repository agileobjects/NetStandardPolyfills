namespace AgileObjects.NetStandardPolyfills.UnitTests.Net40
{
    using NUnit.Framework;

    [TestFixture]
    public class WhenRetrievingTypeMembers : MemberTestsBase
    {
        [Test]
        public override void ShouldFlagAMemberWithAnAttribute() => DoShouldFlagAMemberWithAnAttribute();

        [Test]
        public override void ShouldFlagAMemberWithoutAnAttribute() => DoShouldFlagAMemberWithoutAnAttribute();

        [Test]
        public override void ShouldRetrievePublicStaticMembers() => DoShouldRetrievePublicStaticMembers();

        [Test]
        public override void ShouldRetrievePublicStaticMembersByName() => DoShouldRetrievePublicStaticMembersByName();

        [Test]
        public override void ShouldExcludePublicStaticMembersByName() => DoShouldExcludePublicStaticMembersByName();

        [Test]
        public override void ShouldRetrievePublicStaticMemberByName() => DoShouldRetrievePublicStaticMemberByName();

        [Test]
        public override void ShouldRetrievePublicInstanceMembers() => DoShouldRetrievePublicInstanceMembers();

        [Test]
        public override void ShouldRetrievePublicInstanceMembersByName() => DoShouldRetrievePublicInstanceMembersByName();

        [Test]
        public override void ShouldExcludePublicInstanceMembersByName() => DoShouldExcludePublicInstanceMembersByName();

        [Test]
        public override void ShouldRetrievePublicInstanceMemberByName() => DoShouldRetrievePublicInstanceMemberByName();

        [Test]
        public override void ShouldRetrieveNonPublicStaticMembers() => DoShouldRetrieveNonPublicStaticMembers();

        [Test]
        public override void ShouldRetrieveNonPublicStaticMembersByName() => DoShouldRetrieveNonPublicStaticMembersByName();

        [Test]
        public override void ShouldExcludeNonPublicStaticMembersByName() => DoShouldExcludeNonPublicStaticMembersByName();

        [Test]
        public override void ShouldRetrieveNonPublicStaticMemberByName() =>
            DoShouldRetrieveNonPublicStaticMemberByName();

        [Test]
        public override void ShouldRetrieveNonPublicInstanceMembers() => DoShouldRetrieveNonPublicInstanceMembers();

        [Test]
        public override void ShouldRetrieveNonPublicInstanceMembersByName() => DoShouldRetrieveNonPublicInstanceMembersByName();

        [Test]
        public override void ShouldExcludeNonPublicInstanceMembersByName() => DoShouldExcludeNonPublicInstanceMembersByName();

        [Test]
        public override void ShouldRetrieveNonPublicInstanceMemberByName() =>
            DoShouldRetrieveNonPublicInstanceMemberByName();
    }
}