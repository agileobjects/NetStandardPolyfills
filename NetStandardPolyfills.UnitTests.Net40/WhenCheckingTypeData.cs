namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using TestClasses;
#if FEATURE_XUNIT
    using Xunit;
#else
    using Fact = NUnit.Framework.TestAttribute;

    [NUnit.Framework.TestFixture]
#endif
    public class WhenCheckingTypeData
    {
        [Fact]
        public void ShouldDetermineThatATypeIsPublic()
        {
            typeof(TestHelper).IsPublic().ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineThatATypeIsNonPublic()
        {
            typeof(Should).IsPublic().ShouldBeFalse();
        }

        [Fact]
        public void ShouldFindATypeAttribute()
        {
            typeof(TestHelper).HasAttribute<MyAttribute>().ShouldBeTrue();
        }

        [Fact]
        public void ShouldNotFindATypeAttribute()
        {
            typeof(WhenCheckingTypeData).HasAttribute<MyAttribute>().ShouldBeFalse();
        }

        [Fact]
        public void ShouldFlagAnAnonymousType()
        {
            var anon = new { Value = "Value!" };

            anon.GetType().IsAnonymous().ShouldBeTrue();
        }

        [Fact]
        public void ShouldFlagANonAnonymousType()
        {
            typeof(IOrderedEnumerable<int>).IsAnonymous().ShouldBeFalse();
        }

        [Fact]
        public void ShouldFlagAPrimitiveType()
        {
            typeof(int).IsPrimitive().ShouldBeTrue();
        }

        [Fact]
        public void ShouldFlagANonPrimitiveType()
        {
            typeof(object).IsPrimitive().ShouldBeFalse();
        }

        [Fact]
        public void ShouldGetGenericArguments()
        {
            typeof(Dictionary<string, int>)
                .GetGenericTypeArguments()
                .SequenceEqual(new[] { typeof(string), typeof(int) })
                .ShouldBeTrue();
        }

        [Fact]
        public void ShouldGetOpenGenericArguments()
        {
            typeof(Dictionary<,>)
                .GetGenericTypeArguments()
                .Length
                .ShouldBe(2);
        }

        [Fact]
        public void ShouldGetEmptyGenericArguments()
        {
            typeof(string).GetGenericTypeArguments().ShouldBeEmpty();
        }

        [Fact]
        public void ShouldDetermineThatATypeIsDerived()
        {
            typeof(TestHelper).IsDerivedFrom(typeof(object)).ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineThatATypeIsNotDerived()
        {
            typeof(TestHelper).IsDerivedFrom(typeof(string)).ShouldBeFalse();
        }

        [Fact]
        public void ShouldDetermineThatATypeIsAssignable()
        {
            typeof(TestHelper).IsAssignableTo(typeof(object)).ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineThatATypeIsNotAssignable()
        {
            typeof(TestHelper).IsAssignableTo(typeof(string)).ShouldBeFalse();
        }

        [Fact]
        public void ShouldRetrieveAllInterfaces()
        {
            var interfaces = typeof(Dictionary<string, string>).GetAllInterfaces();

            (interfaces.Length > 0).ShouldBeTrue();
            interfaces.ShouldContain(typeof(IEnumerable));
            interfaces.ShouldContain(typeof(IDictionary<string, string>));
            interfaces.ShouldContain(typeof(ICollection<KeyValuePair<string, string>>));
        }

        [Fact]
        public void ShouldDetermineThatATypeIsAClosedType()
        {
            typeof(List<string>).IsClosedTypeOf(typeof(List<>)).ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineThatATypeIsNotAClosedType()
        {
            typeof(List<string>).IsClosedTypeOf(typeof(IEnumerable<>)).ShouldBeFalse();
        }

        [Fact]
        public void ShouldDetermineAClassCanBeNull()
        {
            typeof(object).CanBeNull().ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineAnInterfaceCanBeNull()
        {
            typeof(IDisposable).CanBeNull().ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineANullableIntCanBeNull()
        {
            typeof(int?).CanBeNull().ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineAStringCanBeNull()
        {
            typeof(string).CanBeNull().ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineADateTimeCannotBeNull()
        {
            typeof(DateTime).CanBeNull().ShouldBeFalse();
        }

        [Fact]
        public void ShouldDetermineANullableLongIsNullable()
        {
            typeof(long?).IsNullableType().ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineALongIsNotNullable()
        {
            typeof(long).IsNullableType().ShouldBeFalse();
        }

        [Fact]
        public void ShouldGetAShortFromANullablehort()
        {
            typeof(short?).GetNonNullableType().ShouldBe(typeof(short));
        }

        [Fact]
        public void ShouldGetATimeSpanFromATimeSpan()
        {
            typeof(TimeSpan).GetNonNullableType().ShouldBe(typeof(TimeSpan));
        }

        [Fact]
        public void ShouldDetermineAGenericListIsEnumerable()
        {
            typeof(List<string>).IsEnumerable().ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineAnIntArrayIsEnumerable()
        {
            typeof(int[]).IsEnumerable().ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineAGenericIEnumerableIsEnumerable()
        {
            typeof(IEnumerable<object>).IsEnumerable().ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineAnICollectionIsEnumerable()
        {
            typeof(ICollection).IsEnumerable().ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineACollectionIsEnumerable()
        {
            typeof(Collection<string>).IsEnumerable().ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineADictionaryIsEnumerable()
        {
            typeof(Dictionary<string, object>).IsEnumerable().ShouldBeTrue();
        }

        [Fact]
        public void ShouldDetermineAStringIsNotEnumerable()
        {
            typeof(string).IsEnumerable().ShouldBeFalse();
        }

        [Fact]
        public void ShouldDetermineAnObjectIsNotEnumerable()
        {
            typeof(object).IsEnumerable().ShouldBeFalse();
        }
    }
}
