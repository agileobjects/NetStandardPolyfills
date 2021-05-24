namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class FluentAssertionExtensions
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

        public static T ShouldNotBeNull<T>(this T actual)
            where T : class
        {
            if (actual == null)
            {
                Asplode("non-null", "null");
            }

            return actual;
        }

        public static void ShouldBeNull<T>(this T actual)
            where T : class
        {
            if (actual != null)
            {
                Asplode("null", "non-null");
            }
        }

        public static T ShouldHaveSingleItem<T>(this IEnumerable<T> actualItems)
            where T : class
        {
            using (var enumerator = actualItems.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    Asplode("a single item", "no items");
                }

                var singleItem = enumerator.Current;

                if (enumerator.MoveNext())
                {
                    Asplode("a single item", "multiple items");
                }

                return singleItem;
            }
        }

        public static void ShouldBeEmpty<T>(this IEnumerable<T> actual)
            where T : class
        {
            if (actual.Any())
            {
                Asplode("an empty collection", "non-empty");
            }
        }

        public static void ShouldBeOfType<TExpected>(this object actual)
        {
            if (!(actual is TExpected))
            {
                Asplode("An object of type " + typeof(TExpected).Name, actual.GetType().Name);
            }
        }

        public static void ShouldContain<T>(this IList<T> actual, T expected)
        {
            if (!actual.Contains(expected))
            {
                Asplode(expected.ToString(), "No match");
            }
        }

        public static void ShouldNotContain<T>(this IList<T> actual, T expected)
        {
            if (actual.Contains(expected))
            {
                Asplode("No match", expected.ToString());
            }
        }

        private static void Asplode(string expected, string actual)
        {
            throw new Exception($"Expected {expected}, but was {actual}");
        }
    }
}
