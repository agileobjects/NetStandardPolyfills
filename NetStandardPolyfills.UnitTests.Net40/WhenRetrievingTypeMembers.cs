namespace AgileObjects.NetStandardPolyfills.UnitTests.Net40
{
    using NUnit.Framework;

    [TestFixture]
    public class WhenRetrievingTypeMembers : TypeMemberTestsBase
    {
        [Test]
        public override void ShouldFindAnImplicitPublicInstanceConstructor() => DoShouldFindAnImplicitPublicInstanceConstructor();

        [Test]
        public override void ShouldFindAPublicInstanceConstructor() => DoShouldFindAPublicInstanceConstructor();

        [Test]
        public override void ShouldFindANonPublicInstanceConstructor() => DoShouldFindANonPublicInstanceConstructor();

        [Test]
        public override void ShouldRetrieveAPublicInstanceField() => DoShouldRetrieveAPublicInstanceField();

        [Test]
        public override void ShouldRetrieveAPublicInstanceProperty() => DoShouldRetrieveAPublicInstanceProperty();

        [Test]
        public override void ShouldFindAPublicInstanceMethod() => DoShouldFindAPublicInstanceMethod();

        [Test]
        public override void ShouldFindAnInheritedPublicInstanceMethod() => DoShouldFindAnInheritedPublicInstanceMethod();

        [Test]
        public override void ShouldFindANonPublicInstanceMethod() => DoShouldFindANonPublicInstanceMethod();

        [Test]
        public override void ShouldFindAPublicStaticMethod() => DoShouldFindAPublicStaticMethod();

        [Test]
        public override void ShouldFindANonPublicStaticMethod() => DoShouldFindANonPublicStaticMethod();
    }
}