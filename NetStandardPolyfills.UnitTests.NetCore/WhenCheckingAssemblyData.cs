namespace AgileObjects.NetStandardPolyfills.UnitTests.NetCore
{
    using Xunit;

    public class WhenCheckingAssemblyData : AssemblyDataTestsBase
    {
        [Fact]
        public override void ShouldFindTypes() => DoShouldFindTypes();
    }
}
