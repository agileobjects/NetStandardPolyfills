namespace AgileObjects.NetStandardPolyfills
{
    using System;
    using System.Collections.Generic;
#if NETSTANDARD1_0
    using System.Linq;
#endif
    using System.Reflection;
#if NETSTANDARD1_0
    using Extensions;
#endif

    /// <summary>
    /// Provides a set of static methods methods for obtaining constructor information in .NET Standard 1.0 and .NET 4.0.
    /// </summary>
    public static class ConstructorExtensionsPolyfill
    {
        /// <summary>
        /// Gets the public, instance-scoped constructors for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type for which to retrieve the constructors.</param>
        /// <returns>The given <paramref name="type"/>'s public, instance-scoped constructors.</returns>
        public static IEnumerable<ConstructorInfo> GetPublicInstanceConstructors(this Type type)
        {
#if NETSTANDARD1_0
            return GetConstructors(type, isPublic: true, isStatic: false);
#else
            return type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped constructor for the given <paramref name="type"/> which has the 
        /// given <paramref name="parameterTypes"/>.
        /// </summary>
        /// <param name="type">The type for which to retrieve the constructor.</param>
        /// <param name="parameterTypes">
        /// Zero or more Types representing the number, order, and type of the parameters for the constructor 
        /// to retrieve. This parameter is optional.
        /// </param>
        /// <returns>
        /// The given <paramref name="type"/>'s matching public, instance-scoped constructor, or null if none exists.
        /// </returns>
        public static ConstructorInfo GetPublicInstanceConstructor(this Type type, params Type[] parameterTypes)
        {
#if NETSTANDARD1_0
            return type
                .GetPublicInstanceConstructors()
                .GetConstructorWithTypes(parameterTypes);
#else
            return type.GetConstructor(parameterTypes);
#endif
        }

        /// <summary>
        /// Gets the non-public, instance-scoped constructors for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type for which to retrieve the constructors.</param>
        /// <returns>The given <paramref name="type"/>'s non-public, instance-scoped constructors.</returns>
        public static IEnumerable<ConstructorInfo> GetNonPublicInstanceConstructors(this Type type)
        {
#if NETSTANDARD1_0
            return GetConstructors(type, isPublic: false, isStatic: false);
#else
            return type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the non-public, instance-scoped constructor for the given <paramref name="type"/> which has the 
        /// given <paramref name="parameterTypes"/>.
        /// </summary>
        /// <param name="type">The type for which to retrieve the constructor.</param>
        /// <param name="parameterTypes">
        /// Zero or more Types representing the number, order, and type of the parameters for the constructor 
        /// to retrieve. This parameter is optional.
        /// </param>
        /// <returns>
        /// The given <paramref name="type"/>'s matching non-public, instance-scoped constructor, or null if none exists.
        /// </returns>
        public static ConstructorInfo GetNonPublicInstanceConstructor(this Type type, params Type[] parameterTypes)
        {
#if NETSTANDARD1_0
            return type
                .GetNonPublicInstanceConstructors()
                .GetConstructorWithTypes(parameterTypes);
#else
            return type.GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                parameterTypes,
                null);
#endif
        }

#if NETSTANDARD1_0
        internal static IEnumerable<ConstructorInfo> GetConstructors(this Type type, bool isPublic, bool isStatic)
            => type.GetTypeInfo().DeclaredConstructors.Filter(c => (c.IsPublic == isPublic) && (c.IsStatic == isStatic));

        private static ConstructorInfo GetConstructorWithTypes(this IEnumerable<ConstructorInfo> constructors, Type[] parameterTypes)
        {
            return constructors
                .Project(c => new
                {
                    Constructor = c,
                    ParameterTypes = c.GetParameters().Project(p => p.ParameterType)
                })
                .Filter(d => d.ParameterTypes.SequenceEqual(parameterTypes))
                .Project(d => d.Constructor)
                .FirstOrDefault();
        }
#endif
    }
}
