namespace AgileObjects.NetStandardPolyfills.UnitTests.NetCore
{
    using System;
    using Xunit;

    public class WhenRetrievingTypeCodes : TypeCodeTestsBase
    {
        [Fact]
        public override void ShouldReturnEmpty() => DoShouldReturnEmpty();

        [Fact]
        public override void ShouldReturnDbNull() => DoShouldReturnDbNull(typeof(DBNull));

        [Fact]
        public override void ShouldReturnBoolean() => DoShouldReturnBoolean();

        [Fact]
        public override void ShouldReturnString() => DoShouldReturnString();

        [Fact]
        public override void ShouldReturnUnderlyingTypeForAnEnum() => DoShouldReturnUnderlyingTypeForAnEnum();

        [Fact]
        public override void ShouldFallbackToObject() => DoShouldFallbackToObject();
    }
}
