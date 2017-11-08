namespace AgileObjects.NetStandardPolyfills.UnitTests.Net40
{
    using NUnit.Framework;

    [TestFixture]
    public class WhenRetrievingTypeMethods : MethodTestsBase
    {
        [Test]
        public override void ShouldFindAPublicInstanceMethod() => DoShouldFindAPublicInstanceMethod();

        [Test]
        public override void ShouldFindAnInheritedPublicInstanceMethod() => DoShouldFindAnInheritedPublicInstanceMethod();

        [Test]
        public override void ShouldFindANonPublicInstanceMethod() => DoShouldFindANonPublicInstanceMethod();

        [Test]
        public override void ShouldFindPublicStaticMethods() => DoShouldFindPublicStaticMethods();

        [Test]
        public override void ShouldFindAPublicStaticMethod() => DoShouldFindAPublicStaticMethod();

        [Test]
        public override void ShouldFindNonPublicStaticMethods() => DoShouldFindNonPublicStaticMethods();

        [Test]
        public override void ShouldFindANonPublicStaticMethod() => DoShouldFindANonPublicStaticMethod();
    }
}