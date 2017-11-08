namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Linq;
    using System.Reflection;
    using TestClasses;

    public abstract class MemberTestsBase
    {
        public abstract void ShouldRetrievePublicStaticMembers();

        public abstract void ShouldRetrievePublicStaticMembersByName();

        public abstract void ShouldExcludePublicStaticMembersByName();

        public abstract void ShouldRetrievePublicInstanceMembers();

        public abstract void ShouldRetrievePublicInstanceMembersByName();

        public abstract void ShouldExcludePublicInstanceMembersByName();

        public abstract void ShouldRetrievePublicInstanceMemberByName();

        public abstract void ShouldRetrieveNonPublicStaticMembers();

        public abstract void ShouldRetrieveNonPublicStaticMembersByName();

        public abstract void ShouldExcludeNonPublicStaticMembersByName();

        public abstract void ShouldRetrieveNonPublicInstanceMembers();

        public abstract void ShouldRetrieveNonPublicInstanceMembersByName();

        public abstract void ShouldExcludeNonPublicInstanceMembersByName();

        public abstract void ShouldRetrieveNonPublicInstanceMemberByName();

        #region Test Implementations

        protected void DoShouldRetrievePublicStaticMembers()
        {
            var members = typeof(TestHelper)
                .GetPublicStaticMembers()
                .ToDictionary(m => m.Name);

            members["PublicStaticField"].ShouldBeOfType<FieldInfo>();
            members["PublicStaticProperty"].ShouldBeOfType<PropertyInfo>();
            members.ContainsKey("DoParamsStuff").ShouldBeFalse();
            members.ContainsKey("PublicInstanceProperty").ShouldBeFalse();
            members.ContainsKey("NonPublicStaticMethod").ShouldBeFalse();
        }

        protected void DoShouldRetrievePublicStaticMembersByName()
        {
            typeof(TestHelper)
                .GetPublicStaticMembers("PublicStaticProperty")
                .ShouldHaveSingleItem();
        }

        protected void DoShouldExcludePublicStaticMembersByName()
        {
            typeof(TestHelper)
                .GetPublicStaticMembers("PublicInstanceField")
                .ShouldBeEmpty();
        }

        protected void DoShouldRetrievePublicInstanceMembers()
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

        protected void DoShouldRetrievePublicInstanceMembersByName()
        {
            typeof(TestHelper)
                .GetPublicInstanceMembers("PublicInstanceField")
                .ShouldHaveSingleItem()
                .ShouldBeOfType<FieldInfo>();
        }

        protected void DoShouldExcludePublicInstanceMembersByName()
        {
            typeof(TestHelper)
                .GetPublicInstanceMembers("PublicStaticProperty")
                .ShouldBeEmpty();
        }

        protected void DoShouldRetrievePublicInstanceMemberByName()
        {
            typeof(TestHelper)
                .GetPublicInstanceMember(".ctor")
                .ShouldNotBeNull();
        }

        protected void DoShouldRetrieveNonPublicStaticMembers()
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

        protected void DoShouldRetrieveNonPublicStaticMembersByName()
        {
            typeof(TestHelper)
                .GetNonPublicStaticMembers("NonPublicStaticField")
                .ShouldHaveSingleItem();
        }

        protected void DoShouldExcludeNonPublicStaticMembersByName()
        {
            typeof(TestHelper)
                .GetNonPublicStaticMembers("NonPublicInstanceField")
                .ShouldBeEmpty();
        }

        protected void DoShouldRetrieveNonPublicInstanceMembers()
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

        protected void DoShouldRetrieveNonPublicInstanceMembersByName()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceMembers(".ctor")
                .ShouldHaveSingleItem();
        }

        protected void DoShouldExcludeNonPublicInstanceMembersByName()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceMembers("NonPublicStaticProperty")
                .ShouldBeEmpty();
        }

        protected void DoShouldRetrieveNonPublicInstanceMemberByName()
        {
            typeof(TestHelper)
                .GetNonPublicInstanceMember("NonPublicInstanceField")
                .ShouldNotBeNull();
        }

        #endregion
    }
}