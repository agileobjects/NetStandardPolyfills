﻿namespace AgileObjects.NetStandardPolyfills.UnitTests.Net40
{
    using NUnit.Framework;

    [TestFixture]
    public class WhenCheckingTypeData : TypeDataTestsBase
    {
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
    }
}