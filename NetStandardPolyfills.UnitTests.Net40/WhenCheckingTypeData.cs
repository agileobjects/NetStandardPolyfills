namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using TestClasses;
#if FEATURE_XUNIT
    using Xunit;
    using static System.Reflection.GenericParameterAttributes;
#else
    using static System.Reflection.GenericParameterAttributes;
    using Fact = NUnit.Framework.TestAttribute;

    [NUnit.Framework.TestFixture]
#endif
    public class WhenCheckingTypeData
    {
        [Fact]
        public void ShouldFlagAPublicType()
        {
            typeof(TestHelper).IsPublic().ShouldBeTrue();
        }

        [Fact]
        public void ShouldFlagANonPublicType()
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
        public void ShouldFlagAGenericParameterType()
        {
            typeof(List<>)
                .GetGenericTypeArguments()[0]
                .IsGenericParameter()
                .ShouldBeTrue();
        }

        [Fact]
        public void ShouldFlagANonGenericParameterType()
        {
            typeof(List<>)
                .IsGenericParameter()
                .ShouldBeFalse();
        }

        [Fact]
        public void ShouldGetGenericParameterClassConstraint()
        {
            var constraints = typeof(ClassConstraint<>)
                .GetGenericTypeArguments()[0]
                .GetConstraints();

            constraints.ShouldBe(ReferenceTypeConstraint);
        }

        [Fact]
        public void ShouldGetGenericParameterStructConstraint()
        {
            var constraints = typeof(StructConstraint<>)
                .GetGenericTypeArguments()[0]
                .GetConstraints();

            (constraints & NotNullableValueTypeConstraint).ShouldBe(NotNullableValueTypeConstraint);
        }

        [Fact]
        public void ShouldGetGenericParameterClassAndInterfaceConstraints()
        {
            var constraints = typeof(DisposableClassConstraint<>)
                .GetGenericTypeArguments()[0]
                .GetConstraints();

            constraints.ShouldBe(ReferenceTypeConstraint);
        }

        [Fact]
        public void ShouldGetGenericParameterTypeAndInterfaceConstraints()
        {
            var constraints = typeof(ComparableStreamConstraint<>)
                .GetGenericTypeArguments()[0]
                .GetConstraints();

            constraints.ShouldBe(None);
        }

        [Fact]
        public void ShouldGetGenericParameterUnconstrainedConstraints()
        {
            var constraints = typeof(Unconstrained<>)
                .GetGenericTypeArguments()[0]
                .GetConstraints();

            constraints.ShouldBe(None);
        }

        [Fact]
        public void ShouldGetNonGenericParameterConstraints()
        {
            var constraints = typeof(Unconstrained<>).GetConstraints();
            constraints.ShouldBe(None);
        }

        [Fact]
        public void ShouldGetGenericParameterNonTypeConstrainedConstraintTypes()
        {
            var constraints = typeof(ClassConstraint<>)
                .GetGenericTypeArguments()[0]
                .GetConstraintTypes();

            constraints.ShouldBeEmpty();
        }

        [Fact]
        public void ShouldGetGenericParameterInterfaceConstraintTypes()
        {
            var constraints = typeof(DisposableClassConstraint<>)
                .GetGenericTypeArguments()[0]
                .GetConstraintTypes();

            constraints.ShouldHaveSingleItem().ShouldBe(typeof(IDisposable));
        }

        [Fact]
        public void ShouldGetGenericParameterTypeAndInterfaceConstraintTypes()
        {
            var genericArgument = typeof(ComparableStreamConstraint<>).GetGenericTypeArguments()[0];
            var constraints = genericArgument.GetConstraintTypes();

            constraints.Length.ShouldBe(2);
            constraints.First().ShouldBe(typeof(Stream));
            constraints.Last().ShouldBe(typeof(IComparable<>).MakeGenericType(genericArgument));
        }

        [Fact]
        public void ShouldGetGenericParameterUnconstrainedConstraintTypes()
        {
            var constraints = typeof(Unconstrained<>)
                .GetGenericTypeArguments()[0]
                .GetConstraintTypes();

            constraints.ShouldBeEmpty();
        }

        [Fact]
        public void ShouldGetNonGenericParameterConstraintTypes()
        {
            var constraints = typeof(Unconstrained<>).GetConstraintTypes();
            constraints.ShouldBeEmpty();
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

        #region Helper Members

        // ReSharper disable UnusedTypeParameter
        private class ClassConstraint<TClass>
            where TClass : class
        {
        }

        private class StructConstraint<TStruct>
            where TStruct : struct
        {
        }

        private class DisposableClassConstraint<T>
            where T : class, IDisposable
        {
        }

        private class ComparableStreamConstraint<TStream>
            where TStream : Stream, IComparable<TStream>
        {
        }

        private class Unconstrained<T>
        {
        }
        // ReSharper restore UnusedTypeParameter

        #endregion
    }
}
