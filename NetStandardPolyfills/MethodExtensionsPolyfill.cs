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
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <returns>The given <paramref name="type"/>'s public, static-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetPublicStaticMethods(this Type type)
        {
#if NET_STANDARD
            return GetPublicStaticMethods(type, name: null);
#else
            return type.GetMethods(BindingFlags.Public | BindingFlags.Static).WithoutPropertyGetters();
#endif
        }

        /// <summary>
        /// Gets the public, static-scoped methods with the given <paramref name="name"/>, for the 
        /// given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the methods to find.</param>
        /// <returns>The given <paramref name="type"/>'s matching public, static-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetPublicStaticMethods(this Type type, string name)
        {
#if NET_STANDARD
            return GetMethods(type, name, isPublic: true, isStatic: true);
#else
            return type.GetPublicStaticMethods().Named(name);
#endif
        }

        /// <summary>
        /// Gets the public, static-scoped method with the given <paramref name="name"/> for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the method.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <returns>
        /// The public, static-scoped method with the given <paramref name="name"/> for the given 
        /// <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetPublicStaticMethod(this Type type, string name)
        {
#if NET_STANDARD
            return type.GetPublicStaticMethods(name).FirstOrDefault();
#else
            return type.GetMethod(name, BindingFlags.Public | BindingFlags.Static);
#endif
        }

        /// <summary>
        /// Gets the public, static-scoped method with the given <paramref name="name"/> for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <param name="parameterCount">The number of parameters the method overload should have.</param>
        /// <returns>
        /// The public, static-scoped method with the given <paramref name="name"/> for the given 
        /// <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetPublicStaticMethod(this Type type, string name, int parameterCount)
        {
#if NET_STANDARD
            return type.GetPublicStaticMethods(name).WithParameterCount(parameterCount);
#else
            return type.GetPublicStaticMethods(name).WithParameterCount(parameterCount);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped methods for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <returns>The given <paramref name="type"/>'s public, instance-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetPublicInstanceMethods(this Type type)
        {
#if NET_STANDARD
            return GetPublicInstanceMethods(type, name: null);
#else
            return type.GetMethods(BindingFlags.Public | BindingFlags.Instance).WithoutPropertyGetters();
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped methods with the given <paramref name="name"/> for the 
        /// given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the methods to find.</param>
        /// <returns>The given <paramref name="type"/>'s matching public, instance-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetPublicInstanceMethods(this Type type, string name)
        {
#if NET_STANDARD
            return GetMethods(type, name, isPublic: true, isStatic: false);
#else
            return type.GetPublicInstanceMethods().Named(name);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped method with the given <paramref name="name"/> for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <returns>
        /// The public, instance-scoped method with the given <paramref name="name"/> for the given 
        /// <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetPublicInstanceMethod(this Type type, string name)
        {
#if NET_STANDARD
            return type.GetPublicInstanceMethods(name).FirstOrDefault();
#else
            return type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped method with the given <paramref name="name"/> for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <param name="parameterCount">The number of parameters the method overload should have.</param>
        /// <returns>
        /// The public, instance-scoped method with the given <paramref name="name"/> for the given 
        /// <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetPublicInstanceMethod(this Type type, string name, int parameterCount)
        {
#if NET_STANDARD
            return type.GetPublicInstanceMethods(name).WithParameterCount(parameterCount);
#else
            return type.GetPublicInstanceMethods(name).WithParameterCount(parameterCount);
#endif
        }

        /// <summary>
        /// Gets the non-public, static-scoped methods for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <returns>The given <paramref name="type"/>'s non-public, static-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetNonPublicStaticMethods(this Type type)
        {
#if NET_STANDARD
            return GetNonPublicStaticMethods(type, name: null);
#else
            return type.GetMethods(BindingFlags.NonPublic | BindingFlags.Static).WithoutPropertyGetters();
#endif
        }

        /// <summary>
        /// Gets the non-public, static-scoped methods with the given <paramref name="name"/> for the 
        /// given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <returns>The given <paramref name="type"/>'s matching non-public, static-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetNonPublicStaticMethods(this Type type, string name)
        {
#if NET_STANDARD
            return GetMethods(type, name, isPublic: false, isStatic: true);
#else
            return type.GetNonPublicStaticMethods().Named(name);
#endif
        }

        /// <summary>
        /// Gets the non-public, static-scoped method with the given <paramref name="name"/> for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the method.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <returns>
        /// The non-public, static-scoped method with the given <paramref name="name"/> for the given 
        /// <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetNonPublicStaticMethod(this Type type, string name)
        {
#if NET_STANDARD
            return type.GetNonPublicStaticMethods(name).FirstOrDefault();
#else
            return type.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Static);
#endif
        }

        /// <summary>
        /// Gets the non-public, static-scoped method with the given <paramref name="name"/> for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <param name="parameterCount">The number of parameters the method overload should have.</param>
        /// <returns>
        /// The non-public, static-scoped method with the given <paramref name="name"/> for the given 
        /// <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetNonPublicStaticMethod(this Type type, string name, int parameterCount)
        {
#if NET_STANDARD
            return type.GetNonPublicStaticMethods(name).WithParameterCount(parameterCount);
#else
            return type.GetNonPublicStaticMethods(name).WithParameterCount(parameterCount);
#endif
        }

        /// <summary>
        /// Gets the non-public, instance-scoped methods for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <returns>The given <paramref name="type"/>'s non-public, instance-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetNonPublicInstanceMethods(this Type type)
        {
#if NET_STANDARD
            return GetNonPublicInstanceMethods(type, name: null);
#else
            return type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).WithoutPropertyGetters();
#endif
        }

        /// <summary>
        /// Gets the non-public, instance-scoped methods with the given <paramref name="name"/> for the 
        /// given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the methods to find.</param>
        /// <returns>The given <paramref name="type"/>'s matching non-public, instance-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetNonPublicInstanceMethods(this Type type, string name)
        {
#if NET_STANDARD
            return GetMethods(type, isPublic: false, isStatic: false);
#else
            return type.GetNonPublicInstanceMethods().Named(name);
#endif
        }

        /// <summary>
        /// Gets the non-public, instance-scoped method with the given <paramref name="name"/> for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <returns>
        /// The non-public, instance-scoped method with the given <paramref name="name"/> for the given 
        /// <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetNonPublicInstanceMethod(this Type type, string name)
        {
#if NET_STANDARD
            return type.GetNonPublicInstanceMethods(name).FirstOrDefault();
#else
            return type.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the non-public, instance-scoped method with the given <paramref name="name"/> for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <param name="parameterCount">The number of parameters the method overload should have.</param>
        /// <returns>
        /// The non-public, instance-scoped method with the given <paramref name="name"/> for the given 
        /// <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetNonPublicInstanceMethod(this Type type, string name, int parameterCount)
        {
#if NET_STANDARD
            return type.GetNonPublicInstanceMethods(name).WithParameterCount(parameterCount);
#else
            return type.GetNonPublicInstanceMethods(name).WithParameterCount(parameterCount);
#endif
        }

        #region Helper Methods

#if NET_STANDARD
        private static IEnumerable<MethodInfo> GetMethods(Type type, bool isPublic, bool isStatic)
            => GetMethods(type, null, isPublic, isStatic);

        private static IEnumerable<MethodInfo> GetMethods(Type type, string name, bool isPublic, bool isStatic)
        {
            while (type != null)
            {
                var methods = type
                    .GetTypeInfo()
                    .DeclaredMethods
                    .WithoutPropertyGettersAnd(m => m.IsPublic == isPublic && m.IsStatic == isStatic);

                if (name != null)
                {
                    methods = methods.Where(m => m.Name == name);
                }

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
        private static IEnumerable<MethodInfo> Named(this IEnumerable<MethodInfo> methods, string name)
        {
            return methods.Where(m => m.Name == name);
        }

        private static MethodInfo WithParameterCount(this IEnumerable<MethodInfo> methods, int parameterCount)
        {
            return methods.FirstOrDefault(m => m.GetParameters().Length == parameterCount);
        }

        private static IEnumerable<MethodInfo> WithoutPropertyGettersAnd(
            this IEnumerable<MethodInfo> methods,
            Func<MethodInfo, bool> extraFilter)
        {
            return methods.Where(m => !m.IsSpecialName && extraFilter.Invoke(m));
        }

        #endregion
    }
}
