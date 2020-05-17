namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Linq;
    using System.Reflection;
    using TestClasses;
#if FEATURE_XUNIT
    using Xunit;
#else
    using Fact = NUnit.Framework.TestAttribute;

    [NUnit.Framework.TestFixture]
#endif
    public class WhenRetrievingTypeMembers
    {
        [Fact]
        public void ShouldFlagAMemberWithAnAttribute()
        {
            typeof(TestHelper)
                .GetPublicInstanceMember(nameof(TestHelper.PublicInstanceProperty))
                .HasAttribute<MyAttribute>()
                .ShouldBeTrue();
        }

        [Fact]
        public void ShouldFlagAMemberWithoutAnAttribute()
        {
            typeof(TestHelper)
                .GetPublicStaticMember(nameof(TestHelper.PublicStaticProperty))
                .HasAttribute<MyAttribute>()
                .ShouldBeFalse();
        }

        [Fact]
        public void ShouldRetrievePublicStaticMembers()
        {
            var members = typeof(TestHelper)
                .GetPublicStaticMembers()
                .ToDictionary(m => m is MethodInfo method && m.Name.StartsWith("op_")
                    ? m.Name + ": " + method.ReturnType.Name
                    : m.Name);

            members["PublicStaticField"].ShouldBeOfType<FieldInfo>();
            members["PublicStaticProperty"].ShouldBeOfType<PropertyInfo>();
            members["op_Implicit: String"].ShouldBeOfType<MethodInfo>();
            members.ContainsKey("DoParamsStuff").ShouldBeFalse();
            members.ContainsKey("PublicInstanceProperty").ShouldBeFalse();
            members.ContainsKey("NonPublicStaticMethod").ShouldBeFalse();
        }

        [Fact]
        public void ShouldRetrievePublicStaticMembersByName()
        {
            typeof(TestHelper)
                .GetPublicStaticMembers("PublicStaticProperty")
                .ShouldHaveSingleItem();
        }

        [Fact]
        public void ShouldExcludePublicStaticMembersByName()
        {
            typeof(TestHelper)
                .GetPublicStaticMembers("PublicInstanceField")
                .ShouldBeEmpty();
        }

        [Fact]
        public void ShouldRetrievePublicStaticMemberByName()
        {
            typeof(TestHelper)
                .GetPublicStaticMember("PublicStaticProperty")
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldRetrievePublicInstanceMembers()
        {
            var members = typeof(TestHelper)
                .GetPublicInstanceMembers()
                .ToDictionary(m => m.Name);

            members["PublicInstanceField"].ShouldBeOfType<FieldInfo>();
            members["PublicInstanceProperty"].ShouldBeOfType<PropertyInfo>();
            members["DoParamsStuff"].ShouldBeOfType<MethodInfo>();
            members.ContainsKey("PublicStaticProperty").ShouldBeFalse();
            members.ContainsKey("NonPublicStaticMethod").ShouldBeFalse();
        }

        [Fact]
        public void ShouldRetrievePublicInstanceMembersByName()
        {
            typeof(TestHelper)
                .GetPublicInstanceMembers("PublicInstanceField")
                .ShouldHaveSingleItem()
                .ShouldBeOfType<FieldInfo>();
        }

        [Fact]
        public void ShouldExcludePublicInstanceMembersByName()
        {
            typeof(TestHelper)
                .GetPublicInstanceMembers("PublicStaticProperty")
                .ShouldBeEmpty();
        }

        [Fact]
        public void ShouldRetrievePublicInstanceMemberByName()
        {
            typeof(TestHelper)
                .GetPublicInstanceMember(".ctor")
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldRetrieveNonPublicStaticMembers()
        {
            var members = typeof(TestHelper)
                .GetNonPublicStaticMembers()
                .ToDictionary(m => m.Name);

            members["NonPublicStaticField"].ShouldBeOfType<FieldInfo>();
            members["NonPublicStaticProperty"].ShouldBeOfType<PropertyInfo>();
            members["NonPublicStaticMethod"].ShouldBeOfType<MethodInfo>();
            members.ContainsKey("DoParamsStuff").ShouldBeFalse();
            members.ContainsKey("PublicInstanceProperty").ShouldBeFalse();
        }

        [Fact]
        public void ShouldRetrieveNonPublicStaticMembersByName()
        {
            typeof(TestHelper)
                .GetNonPublicStaticMembers("NonPublicStaticField")
                .ShouldHaveSingleItem();
        }

        [Fact]
        public void ShouldExcludeNonPublicStaticMembersByName()
        {
            typeof(TestHelper)
                .GetNonPublicStaticMembers("NonPublicInstanceField")
                .ShouldBeEmpty();
        }

        [Fact]
        public void ShouldRetrieveNonPublicStaticMemberByName()
        {
            typeof(TestHelper)
                .GetNonPublicStaticMember("NonPublicStaticField")
                .ShouldNotBeNull()
                .Name.ShouldBe("NonPublicStaticField");
        }

        [Fact]
        public void ShouldRetrieveNonPublicInstanceMembers()
        {
            var members = typeof(TestHelper)
                .GetNonPublicInstanceMembers()
                .ToDictionary(m => m.Name);

            members[".ctor"].ShouldBeOfType<ConstructorInfo>();
            members["NonPublicInstanceField"].ShouldBeOfType<FieldInfo>();
            members["NonPublicInstanceProperty"].ShouldBeOfType<PropertyInfo>();
            members.ContainsKey("DoParamsStuff").ShouldBeFalse();
            members.ContainsKey("PublicStaticProperty").ShouldBeFalse();
            members.ContainsKey("NonPublicStaticMethod").ShouldBeFalse();
        }

        [Fact]
        public void ShouldRetrieveNonPublicInstanceMembersByName()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceMembers(".ctor")
                .ShouldHaveSingleItem();
        }

        [Fact]
        public void ShouldExcludeNonPublicInstanceMembersByName()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceMembers("NonPublicStaticProperty")
                .ShouldBeEmpty();
        }

        [Fact]
        public void ShouldRetrieveNonPublicInstanceMemberByName()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceMember("NonPublicInstanceField")
                .ShouldNotBeNull();
        }
    }
}