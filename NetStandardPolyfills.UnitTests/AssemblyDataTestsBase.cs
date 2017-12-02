namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using TestClasses;

    public abstract class AssemblyDataTestsBase
    {
        public abstract void ShouldFindTypes();

        protected void DoShouldFindTypes()
        {
            var types = typeof(AssemblyDataTestsBase).GetAssembly().GetAllTypes();

            types.ShouldContain(typeof(AssemblyDataTestsBase));
            types.ShouldContain(typeof(ConstructorTestsHelper));
            types.ShouldContain(typeof(MyAttribute));
        }
    }
}
