namespace AgileObjects.NetStandardPolyfills.UnitTests.Net40
{
    using NUnit.Framework;

    [TestFixture]
    public class WhenRetrievingTypeMembers : MemberTestsBase
    {
        [Test]
        public override void ShouldRetrievePublicInstanceMembers() => DoShouldRetrievePublicInstanceMembers();

        [Test]
        public override void ShouldRetrievePublicInstanceMembersByName() => DoShouldRetrievePublicInstanceMembersByName();

        [Test]
        public override void ShouldExcludePublicStaticMembersByName() => DoShouldExcludePublicStaticMembersByName();
    }
}