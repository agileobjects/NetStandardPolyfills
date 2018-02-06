namespace AgileObjects.NetStandardPolyfills.UnitTests.NetCore
{
    using Xunit;

    public class WhenRetrievingTypeOperators : OperatorTestsBase
    {
        [Fact]
        public override void ShouldRetrieveOperators() => DoShouldRetrieveOperators();

        [Fact]
        public override void ShouldRetrieveFilteredOperators() => DoShouldRetrieveFilteredOperators();

        [Fact]
        public override void ShouldRetrieveImplicitOperators() => DoShouldRetrieveImplicitOperators();

        [Fact]
        public override void ShouldRetrieveImplicitOperator() => DoShouldRetrieveImplicitOperator();

        [Fact]
        public override void ShouldRetrieveExplicitOperators() => DoShouldRetrieveExplicitOperators();

        [Fact]
        public override void ShouldRetrieveExplicitOperator() => DoShouldRetrieveExplicitOperator();

        [Fact]
        public override void ShouldHandleMissingOperator() => DoShouldHandleMissingOperator();
    }
}
