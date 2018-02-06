namespace AgileObjects.NetStandardPolyfills.UnitTests.Net40
{
    using NUnit.Framework;

    [TestFixture]
    public class WhenCheckingTypeData : TypeDataTestsBase
    {
        [Test]
        public override void ShouldDetermineThatATypeIsPublic() => DoShouldDetermineThatATypeIsPublic();

        [Test]
        public override void ShouldDetermineThatATypeIsNonPublic() => DoShouldDetermineThatATypeIsNonPublic();

        [Test]
        public override void ShouldFlagAParamsArray() => DoShouldFlagAParamsArray();

        [Test]
        public override void ShouldFlagANonParamsArray() => DoShouldFlagANonParamsArray();

        [Test]
        public override void ShouldFindATypeAttribute() => DoShouldFindATypeAttribute();

        [Test]
        public override void ShouldNotFindATypeAttribute() => DoShouldNotFindATypeAttribute();

        [Test]
        public override void ShouldFlagAnAnonymousType() => DoShouldFlagAnAnonymousType();

        [Test]
        public override void ShouldFlagANonAnonymousType() => DoShouldFlagANonAnonymousType();

        [Test]
        public override void ShouldFlagAPrimitiveType() => DoShouldFlagAPrimitiveType();

        [Test]
        public override void ShouldFlagANonPrimitiveType() => DoShouldFlagANonPrimitiveType();

        [Test]
        public override void ShouldGetGenericArguments() => DoShouldGetGenericArguments();

        [Test]
        public override void ShouldGetEmptyGenericArguments() => DoShouldGetEmptyGenericArguments();

        [Test]
        public override void ShouldDetermineThatATypeIsDerived() => DoShouldDetermineThatATypeIsDerived();

        [Test]
        public override void ShouldDetermineThatATypeIsNotDerived() => DoShouldDetermineThatATypeIsNotDerived();

        [Test]
        public override void ShouldDetermineThatATypeIsAssignable() => DoShouldDetermineThatATypeIsAssignable();

        [Test]
        public override void ShouldDetermineThatATypeIsNotAssignable() => DoShouldDetermineThatATypeIsNotAssignable();

        [Test]
        public override void ShouldRetrieveAllInterfaces() => DoShouldRetrieveAllInterfaces();

        [Test]
        public override void ShouldDetermineThatATypeIsAClosedType() => DoShouldDetermineThatATypeIsAClosedType();

        [Test]
        public override void ShouldDetermineThatATypeIsNotAClosedType() => DoShouldDetermineThatATypeIsNotAClosedType();
    }
}
