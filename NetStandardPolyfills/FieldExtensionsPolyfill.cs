﻿namespace AgileObjects.NetStandardPolyfills
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides a set of static methods for obtaining field information in .NET Standard 1.0 and .NET 4.0.
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
#if NET_STANDARD
            return type.GetTypeInfo().DeclaredFields.Where(f => f.IsPublic && f.IsStatic);
#else
            return type.GetFields(BindingFlags.Public | BindingFlags.Static);
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
#if NET_STANDARD
            return type.GetPublicStaticFields().FirstOrDefault(f => f.Name == name);
#else
            return type.GetField(name, BindingFlags.Public | BindingFlags.Static);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped fields for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the fields.</param>
        /// <returns>The given <paramref name="type"/>'s public, instance-scoped fields.</returns>
        public static IEnumerable<FieldInfo> GetPublicInstanceFields(this Type type)
        {
#if NET_STANDARD
            return type.GetTypeInfo().DeclaredFields.Where(f => f.IsPublic && !f.IsStatic);
#else
            return type.GetFields(BindingFlags.Public | BindingFlags.Instance);
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
#if NET_STANDARD
            return type.GetPublicInstanceFields().FirstOrDefault(f => f.Name == name);
#else
            return type.GetField(name, BindingFlags.Public | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the non-public, static-scoped fields for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the fields.</param>
        /// <returns>The given <paramref name="type"/>'s non-public, static-scoped fields.</returns>
        public static IEnumerable<FieldInfo> GetNonPublicStaticFields(this Type type)
        {
#if NET_STANDARD
            return type
                .GetTypeInfo()
                .DeclaredFields
                .Where(f => !f.IsPublic && f.IsStatic)
                .WithoutAutoGeneratedBackingFields();
#else
            return type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Static)
                .WithoutAutoGeneratedBackingFields();
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
#if NET_STANDARD
            return type.GetNonPublicStaticFields().FirstOrDefault(f => f.Name == name);
#else
            return type.GetField(name, BindingFlags.NonPublic | BindingFlags.Static);
#endif
        }

        /// <summary>
        /// Gets the non-public, instance-scoped fields for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the fields.</param>
        /// <returns>The given <paramref name="type"/>'s non-public, instance-scoped fields.</returns>
        public static IEnumerable<FieldInfo> GetNonPublicInstanceFields(this Type type)
        {
#if NET_STANDARD
            return type
                .GetTypeInfo()
                .DeclaredFields
                .Where(f => !f.IsPublic && !f.IsStatic)
                .WithoutAutoGeneratedBackingFields();
#else
            return type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .WithoutAutoGeneratedBackingFields();
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
#if NET_STANDARD
            return type.GetNonPublicInstanceFields().FirstOrDefault(f => f.Name == name);
#else
            return type.GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);
#endif
        }

        private static IEnumerable<FieldInfo> WithoutAutoGeneratedBackingFields(this IEnumerable<FieldInfo> fields)
        {
            return fields.Where(f => f.Name[0] != '<');
        }
    }
}