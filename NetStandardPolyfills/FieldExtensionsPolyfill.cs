namespace AgileObjects.NetStandardPolyfills
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
#if !NETSTANDARD1_0
    using static System.Reflection.BindingFlags;
#endif

    /// <summary>
    /// Provides a set of static methods for obtaining field information in .NET Standard 1.0+ and .NET 3.5+.
    /// </summary>
    public static class FieldExtensionsPolyfill
    {
        /// <summary>
        /// Gets the public, static-scoped fields for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the fields.</param>
        /// <returns>The given <paramref name="type"/>'s public, static-scoped fields.</returns>
        public static IEnumerable<FieldInfo> GetPublicStaticFields(this Type type)
        {
#if NETSTANDARD1_0
            return GetFields(type, isPublic: true, isStatic: true);
#else
            return GetFields(type, Public | Static);
#endif
        }

        /// <summary>
        /// Gets the public, static-scoped field with the given <paramref name="name"/>, for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the field.</param>
        /// <param name="name">The name of the field to retrieve.</param>
        /// <returns>
        /// The given <paramref name="type"/>'s matching public, static-scoped field, or null if none exists.
        /// </returns>
        public static FieldInfo GetPublicStaticField(this Type type, string name)
        {
#if NETSTANDARD1_0
            return GetFields(type, name, isPublic: true, isStatic: true).FirstOrDefault();
#else
            return GetFields(type, name, Public | Static).FirstOrDefault();
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped fields for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the fields.</param>
        /// <returns>The given <paramref name="type"/>'s public, instance-scoped fields.</returns>
        public static IEnumerable<FieldInfo> GetPublicInstanceFields(this Type type)
        {
#if NETSTANDARD1_0
            return GetFields(type, isPublic: true, isStatic: false);
#else
            return GetFields(type, Public | Instance);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped field with the given <paramref name="name"/>, for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the field.</param>
        /// <param name="name">The name of the field to retrieve.</param>
        /// <returns>
        /// The given <paramref name="type"/>'s matching public, instance-scoped field, or null if none exists.
        /// </returns>
        public static FieldInfo GetPublicInstanceField(this Type type, string name)
        {
#if NETSTANDARD1_0
            return GetFields(type, name, isPublic: true, isStatic: false).FirstOrDefault();
#else
            return GetFields(type, name, Public | Instance).FirstOrDefault();
#endif
        }

        /// <summary>
        /// Gets the non-public, static-scoped fields for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the fields.</param>
        /// <returns>The given <paramref name="type"/>'s non-public, static-scoped fields.</returns>
        public static IEnumerable<FieldInfo> GetNonPublicStaticFields(this Type type)
        {
#if NETSTANDARD1_0
            return GetFields(type, isPublic: false, isStatic: true);
#else
            return GetFields(type, NonPublic | Static);
#endif
        }

        /// <summary>
        /// Gets the non-public, static-scoped field with the given <paramref name="name"/>, for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the field.</param>
        /// <param name="name">The name of the field to retrieve.</param>
        /// <returns>
        /// The given <paramref name="type"/>'s matching non-public, static-scoped field, or null if none exists.
        /// </returns>
        public static FieldInfo GetNonPublicStaticField(this Type type, string name)
        {
#if NETSTANDARD1_0
            return GetFields(type, name, isPublic: false, isStatic: true).FirstOrDefault();
#else
            return GetFields(type, name, NonPublic | Static).FirstOrDefault();
#endif
        }

        /// <summary>
        /// Gets the non-public, instance-scoped fields for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the fields.</param>
        /// <returns>The given <paramref name="type"/>'s non-public, instance-scoped fields.</returns>
        public static IEnumerable<FieldInfo> GetNonPublicInstanceFields(this Type type)
        {
#if NETSTANDARD1_0
            return GetFields(type, isPublic: false, isStatic: false);
#else
            return GetFields(type, NonPublic | Instance);
#endif
        }

        /// <summary>
        /// Gets the non-public, instance-scoped field with the given <paramref name="name"/>, for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the field.</param>
        /// <param name="name">The name of the field to retrieve.</param>
        /// <returns>
        /// The given <paramref name="type"/>'s matching non-public, instance-scoped field, or null if none exists.
        /// </returns>
        public static FieldInfo GetNonPublicInstanceField(this Type type, string name)
        {
#if NETSTANDARD1_0
            return GetFields(type, name, isPublic: false, isStatic: false).FirstOrDefault();
#else
            return GetFields(type, name, NonPublic | Instance).FirstOrDefault();
#endif
        }

        #region Helper Methods

#if NETSTANDARD1_0
        internal static IEnumerable<FieldInfo> GetFields(this Type type, bool isPublic, bool isStatic)
            => GetFields(type, name: null, isPublic: isPublic, isStatic: isStatic);

        private static IEnumerable<FieldInfo> GetFields(Type type, string name, bool isPublic, bool isStatic)
        {
            return GetFields(
                type,
                t => t.GetTypeInfo().DeclaredFields,
                name,
                f => (f.IsPublic == isPublic) && (f.IsStatic == isStatic));
        }
#else
        private static IEnumerable<FieldInfo> GetFields(Type type, BindingFlags bindingFlags)
            => GetFields(type, name: null, bindingFlags: bindingFlags);

        private static IEnumerable<FieldInfo> GetFields(Type type, string name, BindingFlags bindingFlags)
            => GetFields(type, t => t.GetFields(bindingFlags), name);
#endif
        private static IEnumerable<FieldInfo> GetFields(
            Type type,
            Func<Type, IEnumerable<FieldInfo>> fieldsFactory,
            string name,
            Func<FieldInfo, bool> fieldFilter = null)
        {
            fieldFilter ??= _ => true;

            return MemberFinder<FieldInfo>.EnumerateMembers(
                type,
                fieldsFactory,
                name,
                f => IsNotAutoGeneratedBackingField(f) && fieldFilter.Invoke(f),
                FieldNotAlreadyIncluded);
        }

        private static bool IsNotAutoGeneratedBackingField(this MemberInfo field) => field.Name[0] != '<';

        private static bool FieldNotAlreadyIncluded(FieldInfo field, ICollection<FieldInfo> fieldsSoFar)
            => (fieldsSoFar.Count == 0) || fieldsSoFar.All(f => f.Name != field.Name);

        #endregion
    }
}