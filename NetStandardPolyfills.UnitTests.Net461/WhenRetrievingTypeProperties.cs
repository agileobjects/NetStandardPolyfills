namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Linq;
    using TestClasses;
#if FEATURE_XUNIT
    using Xunit;
#else
    using Fact = NUnit.Framework.TestAttribute;

    [NUnit.Framework.TestFixture]
#endif
    public class WhenRetrievingTypeProperties
    {
        [Fact]
        public void ShouldFlagAReadableProperty()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperty(nameof(TestHelper.PublicInstanceProperty))
                .IsReadable()
                .ShouldBeTrue();
        }

        [Fact]
        public void ShouldFlagANonReadableProperty()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperty(nameof(TestHelper.PublicWriteOnlyProperty))
                .IsReadable()
                .ShouldBeFalse();
        }

        [Fact]
        public void ShouldFlagAWritableProperty()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperty(nameof(TestHelper.PublicInstanceProperty))
                .IsWritable()
                .ShouldBeTrue();
        }

        [Fact]
        public void ShouldFlagANonWritableProperty()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperty(nameof(TestHelper.PublicReadOnlyProperty))
                .IsWritable()
                .ShouldBeFalse();
        }

        [Fact]
        public void ShouldRetrievePublicStaticProperties()
        {
            typeof(TestHelper)
                .GetPublicStaticProperties()
                .ShouldHaveSingleItem()
                .Name.ShouldBe("PublicStaticProperty");
        }

        [Fact]
        public void ShouldRetrieveAPublicStaticPropertyByName()
        {
            typeof(TestHelper)
                .GetPublicStaticProperty("PublicStaticProperty")
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldExcludeAPublicStaticPropertyByName()
        {
            typeof(TestHelper)
                .GetPublicStaticProperty("PublicInstanceProperty")
                .ShouldBeNull();
        }

        [Fact]
        public void ShouldRetrieveNonPublicStaticProperties()
        {
            typeof(TestHelper)
                .GetNonPublicStaticProperties()
                .ShouldHaveSingleItem()
                .Name.ShouldBe("NonPublicStaticProperty");
        }

        [Fact]
        public void ShouldRetrieveANonPublicStaticPropertyByName()
        {
            typeof(TestHelper)
                .GetNonPublicStaticProperty("NonPublicStaticProperty")
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldExcludeANonPublicStaticPropertyByName()
        {
            typeof(TestHelper)
                .GetNonPublicStaticProperty("NonPublicInstanceProperty")
                .ShouldBeNull();
        }

        [Fact]
        public void ShouldRetrievePublicInstanceProperties()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperties()
                .FirstOrDefault(p => p.Name == "PublicInstanceProperty")
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldRetrieveInheritedPublicInstanceProperties()
        {
            typeof(Derived)
                .GetPublicInstanceProperties()
                .Where(p => p.Name == "Id")
                .ShouldHaveSingleItem();
        }

        [Fact]
        public void ShouldRetrieveOverriddenPublicInstanceProperties()
        {
            typeof(DerivedOverridden)
                .GetPublicInstanceProperties()
                .Where(p => p.Name == "Id")
                .ShouldHaveSingleItem();
        }

        [Fact]
        public void ShouldRetrieveAPublicInstancePropertyByName()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperty("PublicInstanceProperty")
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldExcludeAPublicInstancePropertyByName()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperty("xxx")
                .ShouldBeNull();
        }

        [Fact]
        public void ShouldRetrieveNonPublicInstanceProperties()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceProperties()
                .ShouldHaveSingleItem()
                .Name.ShouldBe("NonPublicInstanceProperty");
        }

        [Fact]
        public void ShouldRetrieveANonPublicInstancePropertyByName()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceProperty("NonPublicInstanceProperty")
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldExcludeANonPublicInstancePropertyByName()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceProperty("yyy")
                .ShouldBeNull();
        }

        [Fact]
        public void ShouldRetrievePublicPropertyAccessors()
        {
            var accessors = typeof(TestHelper)
                .GetPublicInstanceProperty("PublicInstanceProperty")
                .ShouldNotBeNull()
                .GetAccessors();

            accessors.Length.ShouldBe(2);
            accessors[0].IsSpecialName.ShouldBeTrue();
            accessors[0].Name.ShouldBe("get_PublicInstanceProperty");
            accessors[1].IsSpecialName.ShouldBeTrue();
            accessors[1].Name.ShouldBe("set_PublicInstanceProperty");
        }

        [Fact]
        public void ShouldExcludeNonPublicPropertyAccessorsByDefault()
        {
            var accessors = typeof(TestHelper)
                .GetNonPublicInstanceProperty("NonPublicInstanceProperty")
                .ShouldNotBeNull()
                .GetAccessors();

            accessors.ShouldBeEmpty();
        }

        [Fact]
        public void ShouldIncludeNonPublicPropertyAccessors()
        {
            var accessors = typeof(TestHelper)
                .GetNonPublicInstanceProperty("NonPublicInstanceProperty")
                .ShouldNotBeNull()
                .GetAccessors(nonPublic: true);

            accessors.Length.ShouldBe(2);
            accessors[0].IsSpecialName.ShouldBeTrue();
            accessors[0].Name.ShouldBe("get_NonPublicInstanceProperty");
            accessors[1].IsSpecialName.ShouldBeTrue();
            accessors[1].Name.ShouldBe("set_NonPublicInstanceProperty");
        }

        [Fact]
        public void ShouldRetrieveIndexAccessors()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperties()
                .FirstOrDefault(p => p.IsIndexer())
                .ShouldNotBeNull()
                .GetAccessors()
                .ShouldHaveSingleItem()
                .Name.ShouldBe("get_Item");
        }

        [Fact]
        public void ShouldRetrieveNonPublicIndexAccessors()
        {
            var accessors = typeof(TestHelper)
                .GetPublicInstanceProperties()
                .FirstOrDefault(p => p.IsIndexer())
                .ShouldNotBeNull()
                .GetAccessors(nonPublic: true);

            accessors.Length.ShouldBe(2);
            accessors[0].IsSpecialName.ShouldBeTrue();
            accessors[0].Name.ShouldBe("get_Item");
            accessors[1].IsSpecialName.ShouldBeTrue();
            accessors[1].Name.ShouldBe("set_Item");
        }

        [Fact]
        public void ShouldRetrieveAGetAccessor()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperties()
                .FirstOrDefault(p => p.IsIndexer())
                .ShouldNotBeNull()
                .GetGetter()
                .ShouldNotBeNull()
                .Name.ShouldBe("get_Item");
        }

        [Fact]
        public void ShouldRetrieveANonPublicSetAccessor()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperties()
                .FirstOrDefault(p => p.IsIndexer())
                .ShouldNotBeNull()
                .GetSetter(nonPublic: true)
                .ShouldNotBeNull()
                .Name.ShouldBe("set_Item");
        }

        [Fact]
        public void ShouldRetrieveAPublicInstanceGetterMethodProperty()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperty("PublicInstanceProperty")
                .GetGetter()
                .GetProperty()
                .ShouldNotBeNull()
                .Name.ShouldBe("PublicInstanceProperty");
        }

        [Fact]
        public void ShouldRetrieveAPublicStaticSetterMethodProperty()
        {
            typeof(TestHelper)
                .GetPublicStaticProperty("PublicStaticProperty")
                .GetSetter()
                .GetProperty()
                .ShouldNotBeNull()
                .Name.ShouldBe("PublicStaticProperty");
        }

        [Fact]
        public void ShouldRetrieveANonPublicStaticGetterMethodProperty()
        {
            typeof(TestHelper)
                .GetNonPublicStaticProperty("NonPublicStaticProperty")
                .GetSetter(nonPublic: true)
                .GetProperty()
                .ShouldNotBeNull()
                .Name.ShouldBe("NonPublicStaticProperty");
        }

        [Fact]
        public void ShouldRetrieveANonPublicInstanceSetterMethodProperty()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceProperty("NonPublicInstanceProperty")
                .GetSetter(nonPublic: true)
                .GetProperty()
                .ShouldNotBeNull()
                .Name.ShouldBe("NonPublicInstanceProperty");
        }

        [Fact]
        public void ShouldRetrieveAPublicInstanceGetOnlyGetterMethodProperty()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperty("PublicReadOnlyProperty")
                .GetGetter()
                .GetProperty()
                .ShouldNotBeNull()
                .Name.ShouldBe("PublicReadOnlyProperty");
        }

        [Fact]
        public void ShouldRetrieveAPublicInstanceSetOnlySetterMethodProperty()
        {
            typeof(TestHelper)
                .GetPublicInstanceProperty("PublicWriteOnlyProperty")
                .GetSetter()
                .GetProperty()
                .ShouldNotBeNull()
                .Name.ShouldBe("PublicWriteOnlyProperty");
        }

        [Fact]
        public void ShouldReturnNullForAPublicInstanceMethodProperty()
        {
            typeof(TestHelper)
                .GetPublicInstanceMethod("DoParamsStuff")
                .GetProperty()
                .ShouldBeNull();
        }

        [Fact]
        public void ShouldReturnNullForANonPublicStaticMethodProperty()
        {
            typeof(TestHelper)
                .GetNonPublicStaticMethod("NonPublicStaticMethod")
                .GetProperty()
                .ShouldBeNull();
        }

        #region Helper Classes

        // ReSharper disable UnusedMember.Local
        private abstract class EntityBase
        {
            public virtual int Id { get; set; }
        }

        private class Derived : EntityBase
        {
            public string Name { get; set; }
        }

        private class DerivedOverridden : EntityBase
        {
            public override int Id { get; set; }

            public string Name { get; set; }
        }

        // ReSharper restore UnusedMember.Local

        #endregion
    }
}