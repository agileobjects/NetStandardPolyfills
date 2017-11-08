namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System;
    using NetStandardPolyfills;

    public abstract class TypeCodeTestsBase
    {
        public abstract void ShouldReturnEmpty();

        protected void DoShouldReturnEmpty()
        {
            var typeCode = default(Type).GetTypeCode();

            typeCode.ShouldBe(NetStandardTypeCode.Empty);
        }

        public abstract void ShouldReturnDbNull();

        protected void DoShouldReturnDbNull(Type dbNull)
        {
            var typeCode = dbNull.GetTypeCode();

            typeCode.ShouldBe(NetStandardTypeCode.DBNull);
        }

        public abstract void ShouldReturnBoolean();

        protected void DoShouldReturnBoolean()
        {
            var typeCode = typeof(bool).GetTypeCode();

            typeCode.ShouldBe(NetStandardTypeCode.Boolean);
        }

        public abstract void ShouldReturnString();

        protected void DoShouldReturnString()
        {
            var typeCode = typeof(string).GetTypeCode();

            typeCode.ShouldBe(NetStandardTypeCode.String);
        }

        public abstract void ShouldReturnUnderlyingTypeForAnEnum();

        protected void DoShouldReturnUnderlyingTypeForAnEnum()
        {
            var typeCode = typeof(MyTestEnum).GetTypeCode();

            typeCode.ShouldBe(NetStandardTypeCode.Int32);
        }

        public abstract void ShouldFallbackToObject();

        protected void DoShouldFallbackToObject()
        {
            var typeCode = typeof(IComparable).GetTypeCode();

            typeCode.ShouldBe(NetStandardTypeCode.Object);
        }
    }
}
