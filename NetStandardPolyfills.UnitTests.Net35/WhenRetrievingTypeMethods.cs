using NUnit.Framework;

namespace AgileObjects.NetStandardPolyfills.UnitTests.Net35
{
    [TestFixture]
    public class WhenRetrievingTypeMethods : MethodTestsBase
    {
        [Test]
        public override void ShouldFindPublicMethods() => DoShouldFindPublicMethods();

        [Test]
        public override void ShouldFindAPublicMethodByName() => DoShouldFindAPublicMethodByName();

        [Test]
        public override void ShouldExcludeAPublicMethodByName() => DoShouldExcludeAPublicMethodByName();

        [Test]
        public override void ShouldFindAPublicMethodByNameAndParamCount() =>
            DoShouldFindAPublicMethodByNameAndParamCount();

        [Test]
        public override void ShouldFindAPublicMethodByNameAndParamTypes() =>
            DoShouldFindAPublicMethodByNameAndParamTypes();

        [Test]
        public override void ShouldFindPublicStaticMethods() => DoShouldFindPublicStaticMethods();

        [Test]
        public override void ShouldFindAPublicStaticMethodByName() => DoShouldFindAPublicStaticMethodByName();

        [Test]
        public override void ShouldExcludeAPublicStaticMethodByName() => DoShouldExcludeAPublicStaticMethodByName();

        [Test]
        public override void ShouldFindAPublicStaticMethodByNameAndParamCount() =>
            DoShouldFindAPublicStaticMethodByNameAndParamCount();

        [Test]
        public override void ShouldFindAPublicStaticMethodByNameAndParamTypes() =>
            DoShouldFindAPublicStaticMethodByNameAndParamTypes();

        [Test]
        public override void ShouldFindPublicInstanceMethods() => DoShouldFindPublicInstanceMethods();

        [Test]
        public override void ShouldFindAPublicInstanceMethodByName() => DoShouldFindAPublicInstanceMethodByName();

        [Test]
        public override void ShouldFindAPublicInstanceMethodByNameAndParamCount() =>
            DoShouldFindAPublicInstanceMethodByNameAndParamCount();

        [Test]
        public override void ShouldExcludeAPublicInstanceMethodByParamCount() =>
            DoShouldExcludeAPublicInstanceMethodByParamCount();

        [Test]
        public override void ShouldFindAPublicInstanceMethodByNameAndParamTypes() =>
            DoShouldFindAPublicInstanceMethodByNameAndParamTypes();

        [Test]
        public override void ShouldErrorIfPublicInstanceMethodsHaveSameNameAndParamCount() =>
            DoShouldErrorIfPublicInstanceMethodsHaveSameNameAndParamCount();

        [Test]
        public override void ShouldFindAnInheritedPublicInstanceMethodByName() =>
            DoShouldFindAnInheritedPublicInstanceMethodByName();

        [Test]
        public override void ShouldFindAnInheritedPublicInstanceMethodByNameAndParamCount() =>
            DoShouldFindAnInheritedPublicInstanceMethodByNameAndParamCount();

        [Test]
        public override void ShouldFindNonPublicStaticMethods() => DoShouldFindNonPublicStaticMethods();

        [Test]
        public override void ShouldFindANonPublicStaticMethodByName() => DoShouldFindANonPublicStaticMethodByName();

        [Test]
        public override void ShouldFindANonPublicStaticMethodByNameAndParamCount() =>
            DoShouldFindANonPublicStaticMethodByNameAndParamCount();

        [Test]
        public override void ShouldFindANonPublicStaticMethodByNameAndParamTypes() =>
            DoShouldFindANonPublicStaticMethodByNameAndParamTypes();

        [Test]
        public override void ShouldFindNonPublicInstanceMethods() => DoShouldFindNonPublicInstanceMethods();

        [Test]
        public override void ShouldFindANonPublicInstanceMethodByName() => DoShouldFindANonPublicInstanceMethodByName();

        [Test]
        public override void ShouldFindANonPublicInstanceMethodByNameAndParamCount() =>
            DoShouldFindANonPublicInstanceMethodByNameAndParamCount();

        [Test]
        public override void ShouldFindANonPublicInstanceMethodByNameAndParamTypes() =>
            DoShouldFindANonPublicInstanceMethodByNameAndParamTypes();

        [Test]
        public override void ShouldExcludeANonPublicInstanceMethodByNameAndParamTypes() =>
            DoShouldExcludeANonPublicInstanceMethodByNameAndParamTypes();
    }
}