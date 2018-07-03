namespace AgileObjects.NetStandardPolyfills.UnitTests.Net35
{
    using NUnit.Framework;

    [TestFixture]
    public class WhenCheckingAssemblyData : AssemblyDataTestsBase
    {
        [Test]
        public override void ShouldFindTypes() => DoShouldFindTypes();
    }
}
