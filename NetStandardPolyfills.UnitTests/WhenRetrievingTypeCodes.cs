namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System;
    using System.Data;
    using System.Reflection;
    using NetStandardPolyfills;
    using Shouldly;
    using Xunit;

    public class WhenRetrievingTypeCodes
    {
        [Fact]
        public void ShouldReturnEmpty()
        {
            var typeCode = default(Type).GetTypeCode();

            typeCode.ShouldBe(NetStandardTypeCode.Empty);
        }

        [Fact]
        public void ShouldReturnDbNull()
        {
            var typeCode = typeof(DBNull).GetTypeCode();

            typeCode.ShouldBe(NetStandardTypeCode.DBNull);
        }

        [Fact]
        public void ShouldReturnBoolean()
        {
            var typeCode = typeof(bool).GetTypeCode();

            typeCode.ShouldBe(NetStandardTypeCode.Boolean);
        }

        [Fact]
        public void ShouldReturnString()
        {
            var typeCode = typeof(string).GetTypeCode();

            typeCode.ShouldBe(NetStandardTypeCode.String);
        }

        [Fact]
        public void ShouldReturnUnderlyingTypeForAnEnum()
        {
            var typeCode = typeof(BindingFlags).GetTypeCode();

            typeCode.ShouldBe(NetStandardTypeCode.Int32);
        }

        [Fact]
        public void ShouldFallbackToObject()
        {
            var typeCode = typeof(IDataReader).GetTypeCode();

            typeCode.ShouldBe(NetStandardTypeCode.Object);
        }
    }
}
