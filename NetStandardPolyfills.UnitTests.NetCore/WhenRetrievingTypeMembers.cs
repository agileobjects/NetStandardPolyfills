namespace AgileObjects.NetStandardPolyfills.UnitTests.NetCore
{
    using Xunit;

    public class WhenRetrievingTypeMembers : TypeMemberTestsBase
    {
        [Fact]
        public override void ShouldFindAnImplicitPublicInstanceConstructor() => DoShouldFindAnImplicitPublicInstanceConstructor();

        [Fact]
        public override void ShouldFindAPublicInstanceConstructor() => DoShouldFindAPublicInstanceConstructor();

        [Fact]
        public override void ShouldFindANonPublicInstanceConstructor() => DoShouldFindANonPublicInstanceConstructor();

        [Fact]
        public override void ShouldRetrieveAPublicInstanceField() => DoShouldRetrieveAPublicInstanceField();

        [Fact]
        public override void ShouldRetrieveAPublicInstanceProperty() => DoShouldRetrieveAPublicInstanceProperty();

        [Fact]
        public override void ShouldFindAPublicInstanceMethod() => DoShouldFindAPublicInstanceMethod();

        [Fact]
        public override void ShouldFindAnInheritedPublicInstanceMethod() => DoShouldFindAnInheritedPublicInstanceMethod();

        [Fact]
        public override void ShouldFindANonPublicInstanceMethod() => DoShouldFindANonPublicInstanceMethod();

        [Fact]
        public override void ShouldFindAPublicStaticMethod() => DoShouldFindAPublicStaticMethod();

        [Fact]
        public override void ShouldFindANonPublicStaticMethod() => DoShouldFindANonPublicStaticMethod();
    }
}