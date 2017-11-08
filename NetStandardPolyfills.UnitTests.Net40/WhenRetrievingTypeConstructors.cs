namespace AgileObjects.NetStandardPolyfills.UnitTests.Net40
{
    using NUnit.Framework;

    [TestFixture]
    public class WhenRetrievingTypeConstructors : ConstructorTestsBase
    {
        [Test]
        public override void ShouldFindPublicInstanceConstructors() => DoShouldFindPublicInstanceConstructors();

        [Test]
        public override void ShouldFindAnImplicitPublicInstanceConstructor() => DoShouldFindAnImplicitPublicInstanceConstructor();

        [Test]
        public override void ShouldFindAnExplicitPublicInstanceConstructor() =>
            DoShouldFindAnExplicitPublicInstanceConstructor();

        [Test]
        public override void ShouldFindAPublicInstanceConstructorByParameterTypes() =>
            DoShouldFindAPublicInstanceConstructorByParameterTypes();

        [Test]
        public override void ShouldExcludeAPublicInstanceConstructorByParameterTypes() =>
            DoShouldExcludeAPublicInstanceConstructorByParameterTypes();

        [Test]
        public override void ShouldFindNonPublicInstanceConstructors() => DoShouldFindNonPublicInstanceConstructors();

        [Test]
        public override void ShouldFindANonPublicInstanceConstructor() => DoShouldFindANonPublicInstanceConstructor();

        [Test]
        public override void ShouldExcludeANonPublicInstanceConstructor() =>
            DoShouldExcludeANonPublicInstanceConstructor();

        [Test]
        public override void ShouldFindANonPublicInstanceConstructorByParameterTypes() =>
            DoShouldFindANonPublicInstanceConstructorByParameterTypes();

        [Test]
        public override void ShouldExcludeANonPublicInstanceConstructorByParameterTypes() =>
            DoShouldExcludeANonPublicInstanceConstructorByParameterTypes();
    }
}