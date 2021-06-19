namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.IO;
    using TestClasses;
#if FEATURE_XUNIT
    using Xunit;
#else
    using Fact = NUnit.Framework.TestAttribute;

    [NUnit.Framework.TestFixture]
#endif
    public class WhenCheckingAssemblyData
    {
        [Fact]
        public void ShouldRetrieveAnAssemblyLocation()
        {
            var assembly = typeof(WhenCheckingAssemblyData).GetAssembly();
            var location = assembly.GetLocation();

            location
                .ShouldNotBeNull()
                .EndsWith(Path.GetFileName(location))
                .ShouldBeTrue();
        }

        [Fact]
        public void ShouldFindTypes()
        {
            var types = typeof(WhenCheckingAssemblyData).GetAssembly().GetAllTypes();

            types.ShouldContain(typeof(WhenCheckingAssemblyData));
            types.ShouldContain(typeof(ConstructorTestsHelper));
            types.ShouldContain(typeof(MyAttribute));
        }
    }
}
