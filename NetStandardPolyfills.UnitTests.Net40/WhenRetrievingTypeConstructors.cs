namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System;
    using System.Linq;
    using TestClasses;
#if FEATURE_XUNIT
    using Xunit;
#else
    using Fact = NUnit.Framework.TestAttribute;

    [NUnit.Framework.TestFixture]
#endif
    public class WhenRetrievingTypeConstructors
    {
        [Fact]
        public void ShouldFindPublicInstanceConstructors()
        {
            var constructors = typeof(ConstructorTestsHelper)
                .GetPublicInstanceConstructors()
                .ToArray();

            constructors.Length.ShouldBe(2);
        }

        [Fact]
        public void ShouldFindAnImplicitPublicInstanceConstructor()
        {
            typeof(TestHelper)
                .GetPublicInstanceConstructors()
                .ShouldHaveSingleItem();
        }

        [Fact]
        public void ShouldFindAnExplicitPublicInstanceConstructor()
        {
            typeof(ConstructorTestsHelper)
                .GetPublicInstanceConstructor()
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldFindAPublicInstanceConstructorByParameterTypes()
        {
            var constructor = typeof(ConstructorTestsHelper)
                .GetPublicInstanceConstructor(typeof(int), typeof(string));

            constructor.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldExcludeAPublicInstanceConstructorByParameterTypes()
        {
            var constructor = typeof(ConstructorTestsHelper)
                .GetPublicInstanceConstructor(typeof(int));

            constructor.ShouldBeNull();
        }

        [Fact]
        public void ShouldFindNonPublicInstanceConstructors()
        {
            var constructors = typeof(ConstructorTestsHelper)
                .GetNonPublicInstanceConstructors()
                .ToArray();

            constructors.Length.ShouldBe(2);
        }

        [Fact]
        public void ShouldFindANonPublicInstanceConstructor()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceConstructors()
                .ShouldHaveSingleItem();
        }

        [Fact]
        public void ShouldExcludeANonPublicInstanceConstructor()
        {
            typeof(ConstructorTestsHelper)
                .GetNonPublicInstanceConstructor()
                .ShouldBeNull();
        }

        [Fact]
        public void ShouldFindANonPublicInstanceConstructorByParameterTypes()
        {
            var constructor = typeof(ConstructorTestsHelper)
                .GetNonPublicInstanceConstructor(typeof(int), typeof(string), typeof(DateTime));

            constructor.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldExcludeANonPublicInstanceConstructorByParameterTypes()
        {
            var constructor = typeof(ConstructorTestsHelper)
                .GetNonPublicInstanceConstructor(typeof(TimeSpan));

            constructor.ShouldBeNull();
        }

        [Fact]
        public void ShouldFindAStaticConstructor()
        {
            typeof(ConstructorTestsHelper)
                .GetStaticConstructor()
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldHandleNoStaticConstructor()
        {
            typeof(TestHelper)
                .GetStaticConstructor()
                .ShouldBeNull();
        }
    }
}