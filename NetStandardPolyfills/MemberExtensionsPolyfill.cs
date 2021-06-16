namespace AgileObjects.NetStandardPolyfills
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
#if NETSTANDARD1_0
    using Extensions;
#endif

    /// <summary>
    /// Provides a set of static methods for obtaining member information in .NET Standard 1.0+ and .NET 3.5+.
    /// </summary>
    public static class MemberExtensionsPolyfill
    {
        /// <summary>
        /// Returns a value indicating if this <paramref name="memberInfo"/> has the Attribute given
        /// in the <typeparamref name="TAttribute"/> type argument.
        /// </summary>
        /// <typeparam name="TAttribute">The Attribute type for which to make the determination.</typeparam>
        /// <param name="memberInfo">The MemberInfo for which to make the determination.</param>
        /// <returns>
        /// True if this <paramref name="memberInfo"/> has the given <typeparamref name="TAttribute"/>,
        /// otherwise false.
        /// </returns>
        public static bool HasAttribute<TAttribute>(this MemberInfo memberInfo)
        {
#if NETSTANDARD1_0
            return memberInfo
                .CustomAttributes
                .Any(a => a.AttributeType == typeof(TAttribute));
#else
            return memberInfo
                .GetCustomAttributes(typeof(TAttribute), inherit: false)
                .Any();
#endif
        }

        /// <summary>
        /// Gets the public, static-scoped members for this <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the member.</param>
        /// <returns>
        /// The public, static-scoped members for this <paramref name="type"/>.
        /// </returns>
        public static IEnumerable<MemberInfo> GetPublicStaticMembers(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetMembers(isPublic: true, isStatic: true);
#else
            return type.GetMembers(BindingFlags.Public | BindingFlags.Static);
#endif
        }

        /// <summary>
        /// Gets the public, static-scoped members with the given <paramref name="name"/>
        /// for this <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the members.</param>
        /// <param name="name">The name of the members to find.</param>
        /// <returns>
        /// The public, static-scoped members with the given <paramref name="name"/> for 
        /// this <paramref name="type"/>.
        /// </returns>
        public static IEnumerable<MemberInfo> GetPublicStaticMembers(this Type type, string name)
        {
#if NETSTANDARD1_0
            return type.GetPublicStaticMembers().Filter(m => m.Name == name);
#else
            return type.GetMember(name, BindingFlags.Public | BindingFlags.Static);
#endif
        }

        /// <summary>
        /// Gets the public, static-scoped member with the given <paramref name="name"/> for this 
        /// <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the named member.</param>
        /// <param name="name">The name of the member to find.</param>
        /// <returns>
        /// The public, static-scoped member with the given <paramref name="name"/> for this 
        /// <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MemberInfo GetPublicStaticMember(this Type type, string name)
            => type.GetPublicStaticMembers(name).GetSingleMember(name);

        /// <summary>
        /// Gets the public, instance-scoped members for this <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the member.</param>
        /// <returns>
        /// The public, instance-scoped members for this <paramref name="type"/>.
        /// </returns>
        public static IEnumerable<MemberInfo> GetPublicInstanceMembers(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetMembers(isPublic: true, isStatic: false);
#else
            return type.GetMembers(BindingFlags.Public | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped members with the given <paramref name="name"/> for this
        /// <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the members.</param>
        /// <param name="name">The name of the members to find.</param>
        /// <returns>
        /// The public, instance-scoped members with the given <paramref name="name"/> for this
        /// <paramref name="type"/>.
        /// </returns>
        public static IEnumerable<MemberInfo> GetPublicInstanceMembers(this Type type, string name)
        {
#if NETSTANDARD1_0
            return type.GetPublicInstanceMembers().Filter(m => m.Name == name);
#else
            return type.GetMember(name, BindingFlags.Public | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped member with the given <paramref name="name"/> for this 
        /// <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the named member.</param>
        /// <param name="name">The name of the member to find.</param>
        /// <returns>
        /// The public, instance-scoped member with the given <paramref name="name"/> for this 
        /// <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MemberInfo GetPublicInstanceMember(this Type type, string name)
            => type.GetPublicInstanceMembers(name).GetSingleMember(name);

        /// <summary>
        /// Gets the non-public, static-scoped members for this <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the member.</param>
        /// <returns>
        /// The non-public, static-scoped members for this <paramref name="type"/>.
        /// </returns>
        public static IEnumerable<MemberInfo> GetNonPublicStaticMembers(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetMembers(isPublic: false, isStatic: true);
#else
            return type.GetMembers(BindingFlags.NonPublic | BindingFlags.Static);
#endif
        }

        /// <summary>
        /// Gets the non-public, static-scoped members with the given <paramref name="name"/> for
        /// this <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the members.</param>
        /// <param name="name">The name of the members to find.</param>
        /// <returns>
        /// The non-public, static-scoped members with the given <paramref name="name"/> for this
        /// <paramref name="type"/>.
        /// </returns>
        public static IEnumerable<MemberInfo> GetNonPublicStaticMembers(this Type type, string name)
        {
#if NETSTANDARD1_0
            return type.GetNonPublicStaticMembers().Filter(m => m.Name == name);
#else
            return type.GetMember(name, BindingFlags.NonPublic | BindingFlags.Static);
#endif
        }

        /// <summary>
        /// Gets the non-public, static-scoped member with the given <paramref name="name"/> for this 
        /// <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the named member.</param>
        /// <param name="name">The name of the member to find.</param>
        /// <returns>
        /// The non-public, static-scoped member with the given <paramref name="name"/> for this 
        /// <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MemberInfo GetNonPublicStaticMember(this Type type, string name)
            => type.GetNonPublicStaticMembers(name).GetSingleMember(name);

        /// <summary>
        /// Gets the non-public, instance-scoped members for this <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the member.</param>
        /// <returns>
        /// The non-public, instance-scoped members for this <paramref name="type"/>.
        /// </returns>
        public static IEnumerable<MemberInfo> GetNonPublicInstanceMembers(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetMembers(isPublic: false, isStatic: false);
#else
            return type.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the non-public, instance-scoped members with the given <paramref name="name"/> for
        /// this <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the members.</param>
        /// <param name="name">The name of the members to find.</param>
        /// <returns>
        /// The non-public, instance-scoped members with the given <paramref name="name"/> for this
        /// <paramref name="type"/>.
        /// </returns>
        public static IEnumerable<MemberInfo> GetNonPublicInstanceMembers(this Type type, string name)
        {
#if NETSTANDARD1_0
            return type.GetNonPublicInstanceMembers().Filter(m => m.Name == name);
#else
            return type.GetMember(name, BindingFlags.NonPublic | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the non-public, instance-scoped member with the given <paramref name="name"/> for
        /// this <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the named member.</param>
        /// <param name="name">The name of the member to find.</param>
        /// <returns>
        /// The non-public, instance-scoped member with the given <paramref name="name"/> for this 
        /// <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MemberInfo GetNonPublicInstanceMember(this Type type, string name)
            => type.GetNonPublicInstanceMembers(name).GetSingleMember(name);

        #region Helper Members

#if NETSTANDARD1_0
        private static IEnumerable<MemberInfo> GetMembers(this Type type, bool isPublic, bool isStatic)
            => type.GetTypeInfo().DeclaredMembers.Filter(m => IsMatch(m, isPublic, isStatic));

        private static bool IsMatch(MemberInfo memberInfo, bool isPublic, bool isStatic)
        {
            switch (memberInfo)
            {
                case PropertyInfo property:
                    return property.IsPublic() == isPublic && property.IsStatic() == isStatic;

                case MethodInfo method:
                    return method.IsPublic == isPublic && method.IsStatic == isStatic;

                case ConstructorInfo ctor:
                    return ctor.IsPublic == isPublic && ctor.IsStatic == isStatic;

                case FieldInfo field:
                    return field.IsPublic == isPublic && field.IsStatic == isStatic;
            }

            return false;
        }
#endif
        private static MemberInfo GetSingleMember(this IEnumerable<MemberInfo> members, string name)
        {
            var membersArray = members.ToArray();

            if (membersArray.Length > 1)
            {
                throw new AmbiguousMatchException("Multiple members found named " + name);
            }

            return membersArray.FirstOrDefault();
        }

        #endregion
    }
}