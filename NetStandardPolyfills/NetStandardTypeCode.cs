namespace AgileObjects.NetStandardPolyfills
{
    /// <summary>
    /// Provides a replacement for the TypeCode enum, which is missing in .NETStandard 1.0.
    /// </summary>
    public enum NetStandardTypeCode
    {
        /// <summary>
        /// 0. A null reference.
        /// </summary>
        Empty = 0,
        
        /// <summary>
        /// 1. A general type representing any reference or value type not explicitly represented 
        /// by another TypeCode.
        /// </summary>
        Object = 1,

        /// <summary>
        /// 2. A database null (column) value.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        DBNull = 2,

        /// <summary>
        /// 3. A simple type representing Boolean values of true or false.
        /// </summary>
        Boolean = 3,

        /// <summary>
        /// 4. An integral type representing unsigned 16-bit integers with values between 0 and 65535. 
        /// The set of possible values for the System.TypeCode.Char type corresponds to the Unicode 
        /// character set.
        /// </summary>
        Char = 4,

        /// <summary>
        /// 5. An integral type representing signed 8-bit integers with values between -128 and 127.
        /// </summary>
        SByte = 5,

        /// <summary>
        /// 6. An integral type representing unsigned 8-bit integers with values between 0 and 255.
        /// </summary>
        Byte = 6,

        /// <summary>
        /// 7. An integral type representing signed 16-bit integers with values between -32768 and 32767.
        /// </summary>
        Int16 = 7,

        /// <summary>
        /// 8. An integral type representing unsigned 16-bit integers with values between 0 and 65535.
        /// </summary>
        UInt16 = 8,

        /// <summary>
        /// 9. An integral type representing signed 32-bit integers with values between -2147483648 and 2147483647.
        /// </summary>
        Int32 = 9,

        /// <summary>
        /// 10. An integral type representing unsigned 32-bit integers with values between 0 and 4294967295.
        /// </summary>
        UInt32 = 10,

        /// <summary>
        /// 11. An integral type representing signed 64-bit integers with values between -9223372036854775808 and 
        /// 9223372036854775807.
        /// </summary>
        Int64 = 11,

        /// <summary>
        /// 12. An integral type representing unsigned 64-bit integers with values between 0 and 
        /// 18446744073709551615.
        /// </summary>
        UInt64 = 12,

        /// <summary>
        /// 13. A floating point type representing values ranging from approximately 1.5 x 10 -45 
        /// to 3.4 x 10 38 with a precision of 7 digits.
        /// </summary>
        Single = 13,

        /// <summary>
        /// 14. A floating point type representing values ranging from approximately 5.0 x 10 -324 to 
        /// 1.7 x 10 308 with a precision of 15-16 digits.
        /// </summary>
        Double = 14,

        /// <summary>
        /// 15. A simple type representing values ranging from 1.0 x 10 -28 to approximately 
        /// 7.9 x 10 28 with 28-29 significant digits.
        /// </summary>
        Decimal = 15,

        /// <summary>
        /// 16. A type representing a date and time value.
        /// </summary>
        DateTime = 16,

        /// <summary>
        /// 18. A sealed class type representing Unicode character strings.
        /// </summary>
        String = 18
    }
}
