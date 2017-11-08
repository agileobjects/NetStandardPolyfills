namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System.Linq;
    using System.Reflection;
    using TestClasses;

    public abstract class MemberTestsBase
    {
        public abstract void ShouldRetrievePublicInstanceMembers();

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

        public abstract void ShouldRetrievePublicInstanceMembersByName();

        protected void DoShouldRetrievePublicInstanceMembersByName()
        {
            var members = typeof(TestHelper).GetPublicInstanceMembers("PublicInstanceField").ToArray();

            members.ShouldNotBeNull();
            members.ShouldHaveSingleItem();
            members.First().ShouldBeOfType<FieldInfo>();
        }

        public abstract void ShouldExcludePublicStaticMembersByName();

        protected void DoShouldExcludePublicStaticMembersByName()
        {
            var members = typeof(TestHelper).GetPublicInstanceMembers("PublicStaticField").ToArray();

            members.ShouldBeEmpty();
        }
    }
}