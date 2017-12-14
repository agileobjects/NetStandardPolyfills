namespace AgileObjects.NetStandardPolyfills
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal static class MemberFinder<TMember>
        where TMember : MemberInfo
    {
        public static IEnumerable<TMember> EnumerateMembers(
            Type type,
            Func<Type, IEnumerable<TMember>> membersFactory,
            string name,
            Func<TMember, bool> memberFilter,
            Func<TMember, ICollection<TMember>, bool> uniqueMemberFilter)
        {
            if (memberFilter == null)
            {
                memberFilter = m => true;
            }

            var membersSoFar = new List<TMember>();

            while (type != null)
            {
                var members = membersFactory
                    .Invoke(type)
                    .Where(memberFilter.Invoke)
                    .Where(m => uniqueMemberFilter.Invoke(m, membersSoFar));

                if (name != null)
                {
                    members = members.Where(m => m.Name == name);
                }

                var matchingMembers = members.ToArray();

                membersSoFar.AddRange(matchingMembers);

                foreach (var member in matchingMembers)
                {
                    yield return member;
                }

                type = type.GetBaseType();
            }
        }
    }
}