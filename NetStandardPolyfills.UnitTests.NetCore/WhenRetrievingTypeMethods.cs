namespace AgileObjects.NetStandardPolyfills.UnitTests.NetCore
{
    using Xunit;

    public class WhenRetrievingTypeMethods : MethodTestsBase
    {
        [Fact]
        public override void ShouldFlagAnExtensionMethod() => DoShouldFlagAnExtensionMethod();
        
        [Fact]
        public override void ShouldFlagANonExtensionMethod() => DoShouldFlagANonExtensionMethod();

        [Fact]
        public override void ShouldFindPublicMethods() => DoShouldFindPublicMethods();

        [Fact]
        public override void ShouldFindAPublicMethodByName() => DoShouldFindAPublicMethodByName();

        [Fact]
        public override void ShouldExcludeAPublicMethodByName() => DoShouldExcludeAPublicMethodByName();

        [Fact]
        public override void ShouldFindAPublicMethodByNameAndParamCount() =>
            DoShouldFindAPublicMethodByNameAndParamCount();

        [Fact]
        public override void ShouldFindAPublicMethodByNameAndParamTypes() =>
            DoShouldFindAPublicMethodByNameAndParamTypes();

        [Fact]
        public override void ShouldFindPublicStaticMethods() => DoShouldFindPublicStaticMethods();

        [Fact]
        public override void ShouldFindAPublicStaticMethodByName() => DoShouldFindAPublicStaticMethodByName();

        [Fact]
        public override void ShouldExcludeAPublicStaticMethodByName() => DoShouldExcludeAPublicStaticMethodByName();

        [Fact]
        public override void ShouldFindAPublicStaticMethodByNameAndParamCount() =>
            DoShouldFindAPublicStaticMethodByNameAndParamCount();

        [Fact]
        public override void ShouldFindAPublicStaticMethodByNameAndParamTypes() =>
            DoShouldFindAPublicStaticMethodByNameAndParamTypes();

        [Fact]
        public override void ShouldFindPublicInstanceMethods() => DoShouldFindPublicInstanceMethods();

        [Fact]
        public override void ShouldFindAPublicInstanceMethodByName() => DoShouldFindAPublicInstanceMethodByName();

        [Fact]
        public override void ShouldFindAPublicInstanceMethodByNameAndParamCount() =>
            DoShouldFindAPublicInstanceMethodByNameAndParamCount();

        [Fact]
        public override void ShouldExcludeAPublicInstanceMethodByParamCount() =>
            DoShouldExcludeAPublicInstanceMethodByParamCount();

        [Fact]
        public override void ShouldFindAPublicInstanceMethodByNameAndParamTypes() =>
            DoShouldFindAPublicInstanceMethodByNameAndParamTypes();

        [Fact]
        public override void ShouldErrorIfPublicInstanceMethodsHaveSameNameAndParamCount() =>
            DoShouldErrorIfPublicInstanceMethodsHaveSameNameAndParamCount();

        [Fact]
        public override void ShouldFindAnInheritedPublicInstanceMethodByName() =>
            DoShouldFindAnInheritedPublicInstanceMethodByName();

        [Fact]
        public override void ShouldFindAnInheritedPublicInstanceMethodByNameAndParamCount() =>
            DoShouldFindAnInheritedPublicInstanceMethodByNameAndParamCount();

        [Fact]
        public override void ShouldFindNonPublicStaticMethods() => DoShouldFindNonPublicStaticMethods();

        [Fact]
        public override void ShouldFindANonPublicStaticMethodByName() => DoShouldFindANonPublicStaticMethodByName();

        [Fact]
        public override void ShouldFindANonPublicStaticMethodByNameAndParamCount() =>
            DoShouldFindANonPublicStaticMethodByNameAndParamCount();

        [Fact]
        public override void ShouldFindANonPublicStaticMethodByNameAndParamTypes() =>
            DoShouldFindANonPublicStaticMethodByNameAndParamTypes();

        [Fact]
        public override void ShouldFindNonPublicInstanceMethods() => DoShouldFindNonPublicInstanceMethods();

        [Fact]
        public override void ShouldFindANonPublicInstanceMethodByName() => DoShouldFindANonPublicInstanceMethodByName();

        [Fact]
        public override void ShouldFindANonPublicInstanceMethodByNameAndParamCount() =>
            DoShouldFindANonPublicInstanceMethodByNameAndParamCount();

        [Fact]
        public override void ShouldFindANonPublicInstanceMethodByNameAndParamTypes() =>
            DoShouldFindANonPublicInstanceMethodByNameAndParamTypes();

        [Fact]
        public override void ShouldExcludeANonPublicInstanceMethodByNameAndParamTypes() =>
            DoShouldExcludeANonPublicInstanceMethodByNameAndParamTypes();
    }
}