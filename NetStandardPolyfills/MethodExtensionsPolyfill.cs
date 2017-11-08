namespace AgileObjects.NetStandardPolyfills
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides a set of static methods for obtaining method and parameter information in .NET Standard 1.0 and .NET 4.0.
    /// </summary>
    public static class MethodExtensionsPolyfill
    {
        /// <summary>
        /// Returns a value indicating if the given <paramref name="parameter"/> is a params array.
        /// </summary>
        /// <param name="parameter">The type for which to make the determination.</param>
        /// <returns>True if the given <paramref name="parameter"/> is a params array, otherwise false.</returns>
        public static bool IsParamsArray(this ParameterInfo parameter)
        {
#if NET_STANDARD
            return parameter.GetCustomAttribute<ParamArrayAttribute>(inherit: false) != null;
#else
            return Attribute.IsDefined(parameter, typeof(ParamArrayAttribute));
#endif
        }

        /// <summary>
        /// Gets the public, static-scoped methods for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type for which to retrieve the methods.</param>
        /// <returns>The given <paramref name="type"/>'s public, static-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetPublicStaticMethods(this Type type)
        {
#if NET_STANDARD
            return GetMethods(type, isPublic: true, isStatic: true);
#else
            return type.GetMethods(BindingFlags.Public | BindingFlags.Static).WithoutPropertyGetters();
#endif
        }

        /// <summary>
        /// Gets the public, static-scoped method with the given <paramref name="name"/>
        /// from the given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type for which to retrieve the method.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <returns>
        /// The public, static-scoped method with the given <paramref name="name"/> from 
        /// the given <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetPublicStaticMethod(this Type type, string name)
        {
#if NET_STANDARD
            return type.GetPublicStaticMethods().First(m => m.Name == name);
#else
            return type.GetMethod(name, BindingFlags.Public | BindingFlags.Static);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped methods for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type for which to retrieve the methods.</param>
        /// <returns>The given <paramref name="type"/>'s public, instance-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetPublicInstanceMethods(this Type type)
        {
#if NET_STANDARD
            return GetMethods(type, isPublic: true, isStatic: false);
#else
            return type.GetMethods(BindingFlags.Public | BindingFlags.Instance).WithoutPropertyGetters();
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped method with the given <paramref name="name"/>
        /// from the given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type for which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <returns>
        /// The public, instance-scoped method with the given <paramref name="name"/> from 
        /// the given <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetPublicInstanceMethod(this Type type, string name)
        {
#if NET_STANDARD
            return type.GetPublicInstanceMethods().FirstOrDefault(m => m.Name == name);
#else
            return type.GetMethod(name);
#endif
        }

        /// <summary>
        /// Gets the non-public, static-scoped methods for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type for which to retrieve the methods.</param>
        /// <returns>The given <paramref name="type"/>'s non-public, static-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetNonPublicStaticMethods(this Type type)
        {
#if NET_STANDARD
            return GetMethods(type, isPublic: false, isStatic: true);
#else
            return type.GetMethods(BindingFlags.NonPublic | BindingFlags.Static).WithoutPropertyGetters();
#endif
        }

        /// <summary>
        /// Gets the non-public, static-scoped method with the given <paramref name="name"/>
        /// from the given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type for which to retrieve the method.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <returns>
        /// The non-public, static-scoped method with the given <paramref name="name"/> from 
        /// the given <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetNonPublicStaticMethod(this Type type, string name)
        {
#if NET_STANDARD
            return type.GetNonPublicStaticMethods().First(m => m.Name == name);
#else
            return type.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Static);
#endif
        }

        /// <summary>
        /// Gets the non-public, instance-scoped methods for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type for which to retrieve the methods.</param>
        /// <returns>The given <paramref name="type"/>'s non-public, instance-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetNonPublicInstanceMethods(this Type type)
        {
#if NET_STANDARD
            return GetMethods(type, isPublic: false, isStatic: false);
#else
            return type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).WithoutPropertyGetters();
#endif
        }

        #region Helper Methods

#if NET_STANDARD
        private static IEnumerable<MethodInfo> GetMethods(Type type, bool isPublic, bool isStatic)
        {
            while (type != null)
            {
                var methods = type
                    .GetTypeInfo()
                    .DeclaredMethods
                    .WithoutPropertyGettersAnd(m => m.IsPublic == isPublic && m.IsStatic == isStatic);

                foreach (var method in methods)
                {
                    yield return method;
                }

                type = type.GetBaseType();
            }
        }
#else

        private static IEnumerable<MethodInfo> WithoutPropertyGetters(this IEnumerable<MethodInfo> methods)
            => methods.WithoutPropertyGettersAnd(m => true);
#endif
        private static IEnumerable<MethodInfo> WithoutPropertyGettersAnd(
            this IEnumerable<MethodInfo> methods,
            Func<MethodInfo, bool> extraFilter)
        {
            return methods.Where(m => !m.IsSpecialName && extraFilter.Invoke(m));
        }

        #endregion
    }
}
