namespace AgileObjects.AgileMapper.UnitTests.Polyfills
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NetStandardPolyfills;
    using Shouldly;
    using Xunit;

    public class WhenCheckingTypeData
    {
        [Fact]
        public void ShouldFlagAParamsArray()
        {
            var paramsParameter = typeof(TestHelper)
                .GetMethod("DoParamsStuff")
                .GetParameters()
                .First();

            paramsParameter.IsParamsArray().ShouldBeTrue();
        }

        [Fact]
        public void ShouldFlagANonParamsArray()
        {
            var paramsParameter = typeof(TestHelper)
                .GetMethod("DoNonParamsStuff")
                .GetParameters()
                .First();

            paramsParameter.IsParamsArray().ShouldBeFalse();
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
        public void ShouldFindANonPublicInstanceMethod()
        {
            var method = typeof(TestHelper).GetNonPublicInstanceMethods().FirstOrDefault();

            method.ShouldNotBeNull();
            method.Name.ShouldBe("NonPublicMethod");
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

        [MyAttribute]
        private class TestHelper
        {
            // ReSharper disable once UnusedMember.Local
            // ReSharper disable once UnusedParameter.Local
            public void DoParamsStuff(params int[] ints)
            {
            }

            // ReSharper disable once UnusedMember.Local
            // ReSharper disable once UnusedParameter.Local
            public void DoNonParamsStuff(int[] ints)
            {

            }

            // ReSharper disable once UnusedMember.Local
            internal void NonPublicMethod()
            {
            }
        }

        internal class MyAttribute : Attribute { }
    }
}
