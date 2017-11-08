namespace AgileObjects.NetStandardPolyfills.UnitTests.Net40
{
    using NUnit.Framework;

    [TestFixture]
    public class WhenRetrievingTypeMethods : MethodTestsBase
    {
        [Test]
        public override void ShouldFindPublicStaticMethods() => DoShouldFindPublicStaticMethods();

        [Test]
        public override void ShouldFindAPublicStaticMethodByName() => DoShouldFindAPublicStaticMethodByName();

        [Test]
        public override void ShouldFindAPublicStaticMethodByNameAndParamCount() =>
            DoShouldFindAPublicStaticMethodByNameAndParamCount();

        [Test]
        public override void ShouldFindPublicInstanceMethods() => DoShouldFindPublicInstanceMethods();

        [Test]
        public override void ShouldFindAPublicInstanceMethodByName() => DoShouldFindAPublicInstanceMethodByName();

        [Test]
        public override void ShouldFindAPublicInstanceMethodByNameAndParamCount() =>
            DoShouldFindAPublicInstanceMethodByNameAndParamCount();

        [Test]
        public override void ShouldFindAnInheritedPublicInstanceMethodByName() =>
            DoShouldFindAnInheritedPublicInstanceMethodByName();

        [Test]
        public override void ShouldFindAnInheritedPublicInstanceMethodByNameAndParamCount() =>
            DoShouldFindAnInheritedPublicInstanceMethodByNameAndParamCount();

        [Test]
        public override void ShouldFindNonPublicStaticMethods() => DoShouldFindNonPublicStaticMethods();

        [Test]
        public override void ShouldFindANonPublicStaticMethodByName() => DoShouldFindANonPublicStaticMethodByName();

        [Test]
        public override void ShouldFindANonPublicStaticMethodByNameAndParamCount() =>
            DoShouldFindANonPublicStaticMethodByNameAndParamCount();

        [Test]
        public override void ShouldFindNonPublicInstanceMethods() => DoShouldFindNonPublicInstanceMethods();

        [Test]
        public override void ShouldFindANonPublicInstanceMethodByName() => DoShouldFindANonPublicInstanceMethodByName();

        [Test]
        public override void ShouldFindANonPublicInstanceMethodByNameAndParamCount() =>
            DoShouldFindANonPublicInstanceMethodByNameAndParamCount();
    }
}