using NUnit.Framework;

namespace AgileObjects.NetStandardPolyfills.UnitTests.Net35
{
    [TestFixture]
    public class WhenRetrievingTypeOperators : OperatorTestsBase
    {
        [Test]
        public override void ShouldRetrieveOperators() => DoShouldRetrieveOperators();

        [Test]
        public override void ShouldRetrieveFilteredOperators() => DoShouldRetrieveFilteredOperators();

        [Test]
        public override void ShouldRetrieveImplicitOperators() => DoShouldRetrieveImplicitOperators();

        [Test]
        public override void ShouldRetrieveImplicitOperator() => DoShouldRetrieveImplicitOperator();

        [Test]
        public override void ShouldRetrieveExplicitOperators() => DoShouldRetrieveExplicitOperators();

        [Test]
        public override void ShouldRetrieveExplicitOperator() => DoShouldRetrieveExplicitOperator();

        [Test]
        public override void ShouldHandleMissingOperator() => DoShouldHandleMissingOperator();
    }
}
