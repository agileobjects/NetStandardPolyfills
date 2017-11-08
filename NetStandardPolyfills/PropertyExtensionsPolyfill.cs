namespace AgileObjects.NetStandardPolyfills
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides a set of static methods methods for obtaining property information in .NET Standard 1.0 and .NET 4.0.
    /// </summary>
    public static class PropertyExtensionsPolyfill
    {
        /// <summary>
        /// Gets the public, static-scoped properties for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the properties.</param>
        /// <returns>The given <paramref name="type"/>'s public, static-scoped properties.</returns>
        public static IEnumerable<PropertyInfo> GetPublicStaticProperties(this Type type)
        {
#if NET_STANDARD
            return type.GetTypeInfo().DeclaredProperties.Where(p => p.IsPublic() && p.IsStatic());
#else
            return type.GetProperties(BindingFlags.Public | BindingFlags.Static);
#endif
        }

        /// <summary>
        /// Gets the public, static-scoped property with the given <paramref name="name"/>, for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the property.</param>
        /// <param name="name">The name of the property to retrieve.</param>
        /// <returns>
        /// The given <paramref name="type"/>'s matching public, static-scoped property, or null if none exists.
        /// </returns>
        public static PropertyInfo GetPublicStaticProperty(this Type type, string name)
        {
#if NET_STANDARD
            return type.GetPublicStaticProperties().FirstOrDefault(p => p.Name == name);
#else
            return type.GetProperty(name, BindingFlags.Public | BindingFlags.Static);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped properties for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the properties.</param>
        /// <returns>The given <paramref name="type"/>'s public, instance-scoped properties.</returns>
        public static IEnumerable<PropertyInfo> GetPublicInstanceProperties(this Type type)
        {
#if NET_STANDARD
            return type
                .GetTypeInfo()
                .DeclaredProperties
                .Where(p => p.IsPublic() && !p.IsStatic());
#else
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped property with the given <paramref name="name"/>, for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the property.</param>
        /// <param name="name">The name of the property to retrieve.</param>
        /// <returns>
        /// The given <paramref name="type"/>'s matching public, instance-scoped property, or null if none exists.
        /// </returns>
        public static PropertyInfo GetPublicInstanceProperty(this Type type, string name)
        {
#if NET_STANDARD
            return type.GetPublicInstanceProperties().FirstOrDefault(p => p.Name == name);
#else
            return type.GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the non-public, static-scoped properties for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the properties.</param>
        /// <returns>The given <paramref name="type"/>'s non-public, static-scoped properties.</returns>
        public static IEnumerable<PropertyInfo> GetNonPublicStaticProperties(this Type type)
        {
#if NET_STANDARD
            return type
                .GetTypeInfo()
                .DeclaredProperties
                .Where(p => !p.IsPublic() && p.IsStatic());
#else
            return type.GetProperties(BindingFlags.NonPublic | BindingFlags.Static);
#endif
        }

        /// <summary>
        /// Gets the non-public, static-scoped property with the given <paramref name="name"/>, for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the property.</param>
        /// <param name="name">The name of the property to retrieve.</param>
        /// <returns>
        /// The given <paramref name="type"/>'s matching non-public, static-scoped property, or null if none exists.
        /// </returns>
        public static PropertyInfo GetNonPublicStaticProperty(this Type type, string name)
        {
#if NET_STANDARD
            return type.GetNonPublicStaticProperties().FirstOrDefault(p => p.Name == name);
#else
            return type.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Static);
#endif
        }

        /// <summary>
        /// Gets the non-public, instance-scoped properties for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the properties.</param>
        /// <returns>The given <paramref name="type"/>'s non-public, instance-scoped properties.</returns>
        public static IEnumerable<PropertyInfo> GetNonPublicInstanceProperties(this Type type)
        {
#if NET_STANDARD
            return type
                .GetTypeInfo()
                .DeclaredProperties
                .Where(p => !p.IsPublic() && !p.IsStatic());
#else
            return type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the non-public, instance-scoped property with the given <paramref name="name"/>, for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the property.</param>
        /// <param name="name">The name of the property to retrieve.</param>
        /// <returns>
        /// The given <paramref name="type"/>'s matching non-public, instance-scoped property, or null if none exists.
        /// </returns>
        public static PropertyInfo GetNonPublicInstanceProperty(this Type type, string name)
        {
#if NET_STANDARD
            return type.GetNonPublicInstanceProperties().FirstOrDefault(p => p.Name == name);
#else
            return type.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Determines whether the given <paramref name="property"/> has a public getter or setter.
        /// </summary>
        /// <param name="property">The property for which to make the determination.</param>
        /// <returns>True if the given <paramref name="property"/> has a public getter or setter, otherwise falsek.</returns>
        public static bool IsPublic(this PropertyInfo property)
        {
#if NET_STANDARD
            return ((property.GetMethod != null && property.GetMethod.IsPublic) ||
                    (property.SetMethod != null && property.SetMethod.IsPublic));
#else
            return property.GetAccessors(nonPublic: false).Length != 0;
#endif
        }

        /// <summary>
        /// Determines whether the given <paramref name="property"/> is static.
        /// </summary>
        /// <param name="property">The property for which to make the determination.</param>
        /// <returns>True if the given <paramref name="property"/> is static, otherwise falsek.</returns>
        public static bool IsStatic(this PropertyInfo property)
        {
#if NET_STANDARD
            return (property.GetMethod ?? property.SetMethod).IsStatic;
#else
            return property.GetAccessors(nonPublic: true).Any(m => m.IsStatic);
#endif
        }
    }
}