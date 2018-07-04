namespace AgileObjects.NetStandardPolyfills.UnitTests.TestClasses
{
    using System;
    using System.Collections.Generic;

    [My]
    // ReSharper disable UnusedMember.Local
    // ReSharper disable UnusedParameter.Local
#pragma warning disable 169
    public class TestHelper
    {
        public int PublicInstanceField;
        public static int PublicStaticField;
        internal int NonPublicInstanceField = 0;
        internal static int NonPublicStaticField = 0;
        private readonly Dictionary<string, string> _dictionary;
        private int _value;

        public TestHelper()
        {
            _dictionary = new Dictionary<string, string>();
        }

        protected TestHelper(string something)
        {
        }

        public static implicit operator string(TestHelper testHelper) => testHelper.ToString();
        public static implicit operator DateTime(TestHelper testHelper) => DateTime.Now;
        public static implicit operator TestHelper(string value) => new TestHelper();

        public static explicit operator int(TestHelper testHelper) => testHelper.GetHashCode();
        public static explicit operator int[] (TestHelper testHelper) => new[] { 1, 2, 3 };
        public static explicit operator TestHelper(long value) => new TestHelper();

        [My]
        public int PublicInstanceProperty { get; set; }

        public int PublicReadOnlyProperty => _value;

        public int PublicWriteOnlyProperty
        {
            set => _value = value;
        }

        public static int PublicStaticProperty { get; set; }

        internal int NonPublicInstanceProperty { get; set; }

        internal static int NonPublicStaticProperty { get; set; }

        public string this[string key]
        {
            get => _dictionary[key];
            private set => _dictionary[key] = value;
        }

        public void DoParamsStuff(params int[] ints)
        {
        }

        public void DoNonParamsStuff(int[] ints)
        {

        }

        internal void NonPublicMethod()
        {
        }

        public static void PublicStaticMethod()
        {
        }

        internal static void NonPublicStaticMethod()
        {
        }
#pragma warning restore 169
        // ReSharper restore UnusedParameter.Local
        // ReSharper restore UnusedMember.Local
    }
}