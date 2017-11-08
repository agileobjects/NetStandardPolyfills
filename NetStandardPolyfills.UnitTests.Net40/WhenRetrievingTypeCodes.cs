namespace AgileObjects.NetStandardPolyfills.UnitTests.Net40
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class WhenRetrievingTypeCodes : TypeCodeTestsBase
    {
        [Test]
        public override void ShouldReturnEmpty() => DoShouldReturnEmpty();

        [Test]
        public override void ShouldReturnDbNull() => DoShouldReturnDbNull(typeof(DBNull));

        [Test]
        public override void ShouldReturnBoolean() => DoShouldReturnBoolean();

        [Test]
        public override void ShouldReturnString() => DoShouldReturnString();

        [Test]
        public override void ShouldReturnUnderlyingTypeForAnEnum() => DoShouldReturnUnderlyingTypeForAnEnum();

        [Test]
        public override void ShouldFallbackToObject() => DoShouldFallbackToObject();
    }
}
