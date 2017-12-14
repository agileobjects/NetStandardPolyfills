namespace AgileObjects.NetStandardPolyfills
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
#if !NET_STANDARD
    using static System.Reflection.BindingFlags;
#endif

    /// <summary>
    /// Provides a set of static methods for obtaining property information in .NET Standard 1.0 and .NET 4.0.
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
            return GetProperties(type, isPublic: true, isStatic: true);
#else
            return GetProperties(type, Public | Static);
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
            return GetProperties(type, name, isPublic: true, isStatic: true).FirstOrDefault();
#else
            return GetProperties(type, name, Public | Static).FirstOrDefault();
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
            return GetProperties(type, isPublic: true, isStatic: false);
#else
            return GetProperties(type, Public | Instance);
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
            return GetProperties(type, name, isPublic: true, isStatic: false).FirstOrDefault();
#else
            return GetProperties(type, name, Public | Instance).FirstOrDefault();
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
            return GetProperties(type, isPublic: false, isStatic: true);
#else
            return GetProperties(type, NonPublic | Static);
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
            return GetProperties(type, name, isPublic: false, isStatic: true).FirstOrDefault();
#else
            return GetProperties(type, name, NonPublic | Static).FirstOrDefault();
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
            return GetProperties(type, isPublic: false, isStatic: false);
#else
            return GetProperties(type, NonPublic | Instance);
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
            return GetProperties(type, name, isPublic: false, isStatic: false).FirstOrDefault();
#else
            return GetProperties(type, name, NonPublic | Instance).FirstOrDefault();
#endif
        }

        /// <summary>
        /// Determines whether the given <paramref name="property"/> has a public getter or setter.
        /// </summary>
        /// <param name="property">The property for which to make the determination.</param>
        /// <returns>True if the given <paramref name="property"/> has a public getter or setter, otherwise falsek.</returns>
        public static bool IsPublic(this PropertyInfo property) => property.GetAccessors().Length != 0;

        /// <summary>
        /// Determines whether the given <paramref name="property"/> is static.
        /// </summary>
        /// <param name="property">The property for which to make the determination.</param>
        /// <returns>True if the given <paramref name="property"/> is static, otherwise false.</returns>
        public static bool IsStatic(this PropertyInfo property)
            => property.GetAccessors(nonPublic: true).Any(m => m.IsStatic);

        /// <summary>
        /// Determines whether the given <paramref name="property"/> is an indexer.
        /// </summary>
        /// <param name="property">The property for which to make the determination.</param>
        /// <returns>True if the given <paramref name="property"/> is an indexer, otherwise false.</returns>
        public static bool IsIndexer(this PropertyInfo property)
        {
            return property.GetIndexParameters().Length != 0;
        }

        /// <summary>
        /// Returns an array whose elements reflect the public and, if specified, non-public get, set, and 
        /// other accessors of the property reflected by the current instance.
        /// </summary>
        /// <param name="property">The property for which to make the determination.</param>
        /// <param name="nonPublic">
        /// Whether non-public methods should be returned in the MethodInfo array: true if non-public methods 
        /// should be included; otherwise false. Defaults to false if not supplied.
        /// </param>
        /// <returns>
        /// An array of System.Reflection.MethodInfo objects whose elements reflect the get, set, and other 
        /// accessors of the property reflected by the current instance. If <paramref name="nonPublic"/> is 
        /// true, this array contains public and non-public get, set, and other accessors. If 
        /// <paramref name="nonPublic"/> is false, this array contains only public get, set, and other 
        /// accessors. If no accessors with the specified visibility are found, this method returns an empty array.
        /// </returns>
        public static MethodInfo[] GetAccessors(this PropertyInfo property, bool nonPublic = false)
        {
#if NET_STANDARD
            var accessors = new List<MethodInfo>(2);

            if ((property.GetMethod != null) && (nonPublic || property.GetMethod.IsPublic))
            {
                accessors.Add(property.GetMethod);
            }

            if ((property.SetMethod != null) && (nonPublic || property.SetMethod.IsPublic))
            {
                accessors.Add(property.SetMethod);
            }

            return accessors.ToArray();
#else
            return property.GetAccessors(nonPublic);
#endif
        }

        /// <summary>
        /// Returns the public or non-public get accessor for this <paramref name="property"/>.
        /// </summary>
        /// <param name="property">The property for which to retrieve the accessor.</param>
        /// <param name="nonPublic">
        /// Whether a non-public get accessor should be returned: true if a non-public accessor should be 
        /// returned, otherwise false.
        /// </param>
        /// <returns>
        /// A MethodInfo representing the get accessor for this <paramref name="property"/>, if 
        /// <paramref name="nonPublic"/> is true. Returns null if <paramref name="nonPublic"/> is false and 
        /// the get accessor is non-public, or if <paramref name="nonPublic"/> is true but no get accessors exist.
        /// </returns>
        public static MethodInfo GetGetter(this PropertyInfo property, bool nonPublic = false)
        {
#if NET_STANDARD
            if (property.GetMethod != null && (nonPublic || property.GetMethod.IsPublic))
            {
                return property.GetMethod;
            }

            return null;
#else
            return property.GetGetMethod(nonPublic);
#endif
        }

        /// <summary>
        /// Returns the public or non-public set accessor for this <paramref name="property"/>.
        /// </summary>
        /// <param name="property">The property for which to retrieve the accessor.</param>
        /// <param name="nonPublic">
        /// Whether a non-public set accessor should be returned: true if a non-public accessor should be 
        /// returned, otherwise false.
        /// </param>
        /// <returns>
        /// A MethodInfo representing the set accessor for this <paramref name="property"/>, if 
        /// <paramref name="nonPublic"/> is true. Returns null if <paramref name="nonPublic"/> is false and 
        /// the set accessor is non-public, or if <paramref name="nonPublic"/> is true but no set accessors exist.
        /// </returns>
        public static MethodInfo GetSetter(this PropertyInfo property, bool nonPublic = false)
        {
#if NET_STANDARD
            if (property.SetMethod != null && (nonPublic || property.SetMethod.IsPublic))
            {
                return property.SetMethod;
            }

            return null;
#else
            return property.GetSetMethod(nonPublic);
#endif
        }

        #region Helper Methods

#if NET_STANDARD
        internal static IEnumerable<PropertyInfo> GetProperties(this Type type, bool isPublic, bool isStatic)
            => GetProperties(type, name: null, isPublic: isPublic, isStatic: isStatic);

        private static IEnumerable<PropertyInfo> GetProperties(Type type, string name, bool isPublic, bool isStatic)
        {
            return GetProperties(
                type,
                t => t.GetTypeInfo().DeclaredProperties,
                name,
                p => p.IsPublic() == isPublic && (p.IsStatic() == isStatic));
        }
#else
        private static IEnumerable<PropertyInfo> GetProperties(Type type, BindingFlags bindingFlags)
            => GetProperties(type, name: null, bindingFlags: bindingFlags);

        private static IEnumerable<PropertyInfo> GetProperties(Type type, string name, BindingFlags bindingFlags)
            => GetProperties(type, t => t.GetProperties(bindingFlags), name);
#endif
        private static IEnumerable<PropertyInfo> GetProperties(
            Type type,
            Func<Type, IEnumerable<PropertyInfo>> propertiesFactory,
            string name,
            Func<PropertyInfo, bool> propertyFilter = null)
        {
            return MemberFinder<PropertyInfo>.EnumerateMembers(
                type,
                propertiesFactory,
                name,
                propertyFilter,
                PropertyNotAlreadyIncluded);
        }

        private static bool PropertyNotAlreadyIncluded(PropertyInfo property, ICollection<PropertyInfo> propertiesSoFar)
            => (propertiesSoFar.Count == 0) || propertiesSoFar.All(p => p.Name != property.Name);

        #endregion
    }
}