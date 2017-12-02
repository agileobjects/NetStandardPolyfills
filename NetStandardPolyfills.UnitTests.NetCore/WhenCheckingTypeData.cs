﻿namespace AgileObjects.NetStandardPolyfills.UnitTests.NetCore
{
    using Xunit;

    public class WhenCheckingTypeData : TypeDataTestsBase
    {
        [Fact]
        public override void ShouldFlagAParamsArray() => DoShouldFlagAParamsArray();

        [Fact]
        public override void ShouldFlagANonParamsArray() => DoShouldFlagANonParamsArray();

        [Fact]
        public override void ShouldFindATypeAttribute() => DoShouldFindATypeAttribute();

        [Fact]
        public override void ShouldNotFindATypeAttribute() => DoShouldNotFindATypeAttribute();

        [Fact]
        public override void ShouldFlagAnAnonymousType() => DoShouldFlagAnAnonymousType();

        [Fact]
        public override void ShouldFlagANonAnonymousType() => DoShouldFlagANonAnonymousType();

        [Fact]
        public override void ShouldFlagAPrimitiveType() => DoShouldFlagAPrimitiveType();

        [Fact]
        public override void ShouldFlagANonPrimitiveType() => DoShouldFlagANonPrimitiveType();

        [Fact]
        public override void ShouldGetGenericArguments() => DoShouldGetGenericArguments();

        [Fact]
        public override void ShouldGetEmptyGenericArguments() => DoShouldGetEmptyGenericArguments();

        [Fact]
        public override void ShouldDetermineThatATypeIsDerived() => DoShouldDetermineThatATypeIsDerived();

        [Fact]
        public override void ShouldDetermineThatATypeIsNotDerived() => DoShouldDetermineThatATypeIsNotDerived();

        [Fact]
        public override void ShouldDetermineThatATypeIsAssignable() => DoShouldDetermineThatATypeIsAssignable();

        [Fact]
        public override void ShouldDetermineThatATypeIsNotAssignable() => DoShouldDetermineThatATypeIsNotAssignable();

        [Fact]
        public override void ShouldRetrieveAllInterfaces() => DoShouldRetrieveAllInterfaces();
    }
}
