namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System;
#if FEATURE_XUNIT
    using Xunit;
#else
    using Fact = NUnit.Framework.TestAttribute;

    [NUnit.Framework.TestFixture]
#endif
    public class WhenRetrievingTypeCodes
    {
        [Fact]
        public void ShouldReturnEmpty()
        {
            var typeCode = default(Type).GetTypeCode();

            typeCode.ShouldBe(NetStandardTypeCode.Empty);
        }

#if FEATURE_DBNULL
        [Fact]
        public void ShouldReturnDbNull()
        {
            var typeCode = typeof(DBNull).GetTypeCode();

            typeCode.ShouldBe(NetStandardTypeCode.DBNull);
        }
#endif
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
            var typeCode = typeof(MyTestEnum).GetTypeCode();

            typeCode.ShouldBe(NetStandardTypeCode.Int32);
        }
        
        [Fact]
        public void ShouldFallbackToObject()
        {
            var typeCode = typeof(IComparable).GetTypeCode();

            typeCode.ShouldBe(NetStandardTypeCode.Object);
        }
    }
}
