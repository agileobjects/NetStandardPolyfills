namespace AgileObjects.NetStandardPolyfills.UnitTests.NetCore
{
    using Xunit;

    public class WhenRetrievingTypeConstructors : ConstructorTestsBase
    {
        [Fact]
        public override void ShouldFindPublicInstanceConstructors() => DoShouldFindPublicInstanceConstructors();

        [Fact]
        public override void ShouldFindAnImplicitPublicInstanceConstructor() => DoShouldFindAnImplicitPublicInstanceConstructor();

        [Fact]
        public override void ShouldFindAnExplicitPublicInstanceConstructor() =>
            DoShouldFindAnExplicitPublicInstanceConstructor();

        [Fact]
        public override void ShouldFindAPublicInstanceConstructorByParameterTypes() =>
            DoShouldFindAPublicInstanceConstructorByParameterTypes();

        [Fact]
        public override void ShouldExcludeAPublicInstanceConstructorByParameterTypes() =>
            DoShouldExcludeAPublicInstanceConstructorByParameterTypes();

        [Fact]
        public override void ShouldFindNonPublicInstanceConstructors() => DoShouldFindNonPublicInstanceConstructors();

        [Fact]
        public override void ShouldFindANonPublicInstanceConstructor() => DoShouldFindANonPublicInstanceConstructor();

        [Fact]
        public override void ShouldExcludeANonPublicInstanceConstructor() =>
            DoShouldExcludeANonPublicInstanceConstructor();

        [Fact]
        public override void ShouldFindANonPublicInstanceConstructorByParameterTypes() =>
            DoShouldFindANonPublicInstanceConstructorByParameterTypes();

        [Fact]
        public override void ShouldExcludeANonPublicInstanceConstructorByParameterTypes() =>
            DoShouldExcludeANonPublicInstanceConstructorByParameterTypes();
    }
}