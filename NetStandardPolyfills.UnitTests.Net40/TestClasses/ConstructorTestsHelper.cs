namespace AgileObjects.NetStandardPolyfills.UnitTests.TestClasses
{
    using System;

    public class ConstructorTestsHelper
    {
        public ConstructorTestsHelper()
        {
        }

        public ConstructorTestsHelper(int intValue, string stringValue)
        {
        }

        private ConstructorTestsHelper(int intValue)
        {
        }

        private ConstructorTestsHelper(int intValue, string stringValue, DateTime dateValue)
        {
        }

        static ConstructorTestsHelper()
        {
            Console.WriteLine("Static!");
        }
    }
}