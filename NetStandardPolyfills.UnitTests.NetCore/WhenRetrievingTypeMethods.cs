namespace AgileObjects.NetStandardPolyfills.UnitTests.NetCore
{
    using Xunit;

    public class WhenRetrievingTypeMethods : MethodTestsBase
    {
        [Fact]
        public override void ShouldFindPublicStaticMethods() => DoShouldFindPublicStaticMethods();

        [Fact]
        public override void ShouldFindAPublicStaticMethodByName() => DoShouldFindAPublicStaticMethodByName();

        [Fact]
        public override void ShouldFindPublicInstanceMethods() => DoShouldFindPublicInstanceMethods();

        [Fact]
        public override void ShouldFindAPublicInstanceMethod() => DoShouldFindAPublicInstanceMethod();

        [Fact]
        public override void ShouldFindAnInheritedPublicInstanceMethod() =>
            DoShouldFindAnInheritedPublicInstanceMethod();

        [Fact]
        public override void ShouldFindANonPublicInstanceMethod() => DoShouldFindANonPublicInstanceMethod();

        [Fact]
        public override void ShouldFindNonPublicStaticMethods() => DoShouldFindNonPublicStaticMethods();

        [Fact]
        public override void ShouldFindANonPublicStaticMethod() => DoShouldFindANonPublicStaticMethod();
    }
}