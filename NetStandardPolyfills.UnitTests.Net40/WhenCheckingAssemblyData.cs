namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using TestClasses;
#if FEATURE_XUNIT
    using Xunit;
#else
    using Fact = NUnit.Framework.TestAttribute;

    [NUnit.Framework.TestFixture]
#endif
    public class WhenCheckingAssemblyData
    {
        public void ShouldFindTypes()
        {
            var types = typeof(WhenCheckingAssemblyData).GetAssembly().GetAllTypes();

            types.ShouldContain(typeof(WhenCheckingAssemblyData));
            types.ShouldContain(typeof(ConstructorTestsHelper));
            types.ShouldContain(typeof(MyAttribute));
        }
    }
}
