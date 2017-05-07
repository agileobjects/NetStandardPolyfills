namespace AgileObjects.NetStandardPolyfills.UnitTests
{
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

        public TestHelper()
        {
        }

        protected TestHelper(string something)
        {
        }

        public int PublicInstanceProperty { get; set; }

        public static int PublicStaticProperty { get; set; }

        internal int NonPublicInstanceProperty { get; set; }

        internal static int NonPublicStaticProperty { get; set; }

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