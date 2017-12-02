namespace AgileObjects.NetStandardPolyfills.UnitTests.Net40
{
    using NUnit.Framework;

    [TestFixture]
    public class WhenCheckingAssemblyData : AssemblyDataTestsBase
    {
        [Test]
        public override void ShouldFindTypes() => DoShouldFindTypes();
    }
}
