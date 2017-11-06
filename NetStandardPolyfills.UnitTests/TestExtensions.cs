namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System;
    using System.Collections.Generic;

    internal static class TestExtensions
    {
        public static void ShouldBeTrue(this bool boolValue)
        {
            if (boolValue != true)
            {
                Asplode("true", "false");
            }
        }

        public static void ShouldBeFalse(this bool boolValue)
        {
            if (boolValue)
            {
                Asplode("false", "true");
            }
        }

        public static void ShouldBe<T>(this T actual, T expected)
        {
            if (Comparer<T>.Default.Compare(expected, actual) != 0)
            {
                Asplode(expected.ToString(), actual.ToString());
            }
        }

        public static void ShouldNotBeNull<T>(this T actual)
            where T : class
        {
            if (actual == null)
            {
                Asplode("non-null", "null");
            }
        }

        public static void ShouldHaveSingleItem<T>(this IEnumerable<T> actualItems)
            where T : class
        {
            using (var enumerator = actualItems.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    Asplode("a single item", "no items");
                }

                if (enumerator.MoveNext())
                {
                    Asplode("a single item", "multiple items");
                }
            }
        }

        private static void Asplode(string expected, string actual)
        {
            throw new Exception($"Expected {expected}, but was {actual}");
        }
    }
}
