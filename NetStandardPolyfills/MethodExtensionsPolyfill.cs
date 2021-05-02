namespace AgileObjects.NetStandardPolyfills
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using Extensions;
#if !NETSTANDARD1_0
    using static System.Reflection.BindingFlags;
#endif

    /// <summary>
    /// Provides a set of static methods for obtaining method and parameter information in .NET Standard 1.0+ and .NET 3.5+.
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
#if NETSTANDARD1_0
            return parameter.GetCustomAttribute<ParamArrayAttribute>(inherit: false) != null;
#else
            return Attribute.IsDefined(parameter, typeof(ParamArrayAttribute));
#endif
        }

        /// <summary>
        /// Returns a value indicating if the <paramref name="method"/> is an extension method.
        /// </summary>
        /// <param name="method">The method for which to make the determination.</param>
        /// <returns>True if the <paramref name="method"/> is an extension method, otherwise false.</returns>
        public static bool IsExtensionMethod(this MethodInfo method)
            => method.IsStatic && method.IsDefined(typeof(ExtensionAttribute), false);

        /// <summary>
        /// Gets the public methods for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <returns>The given <paramref name="type"/>'s public methods.</returns>
        public static IEnumerable<MethodInfo> GetPublicMethods(this Type type)
            => GetPublicMethods(type, name: null);

        /// <summary>
        /// Gets the public methods with the given <paramref name="name"/>, for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the methods to find.</param>
        /// <returns>The given <paramref name="type"/>'s matching public methods.</returns>
        public static IEnumerable<MethodInfo> GetPublicMethods(this Type type, string name)
        {
#if NETSTANDARD1_0
            return GetMethods(type, name, isPublic: true);
#else
            return GetMethods(type, name, Public | Instance | Static);
#endif
        }

        /// <summary>
        /// Gets the public method with the given <paramref name="name"/> for the given 
        /// <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the method.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <returns>
        /// The public method with the given <paramref name="name"/> for the given <paramref name="type"/>, 
        /// or null if none exists.
        /// </returns>
        public static MethodInfo GetPublicMethod(this Type type, string name)
            => type.GetPublicMethods(name).FirstOrDefault();

        /// <summary>
        /// Gets the public method with the given <paramref name="name"/> and <paramref name="parameterCount"/> 
        /// for the given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <param name="parameterCount">The number of parameters the method overload should have.</param>
        /// <returns>
        /// The matching public method for the given <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetPublicMethod(this Type type, string name, int parameterCount)
            => type.GetPublicMethods(name).WithParameterCount(parameterCount);

        /// <summary>
        /// Gets the public method with the given <paramref name="name"/> and <paramref name="parameterTypes"/> 
        /// for the given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <param name="parameterTypes">The Types of the parameters the method overload should have.</param>
        /// <returns>
        /// The matching public method for the given <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetPublicMethod(this Type type, string name, params Type[] parameterTypes)
            => type.GetPublicMethods(name).WithParameterTypes(parameterTypes);

        /// <summary>
        /// Gets the public, static-scoped methods for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <returns>The given <paramref name="type"/>'s public, static-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetPublicStaticMethods(this Type type)
            => GetPublicStaticMethods(type, name: null);

        /// <summary>
        /// Gets the public, static-scoped methods with the given <paramref name="name"/>, for the 
        /// given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the methods to find.</param>
        /// <returns>The given <paramref name="type"/>'s matching public, static-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetPublicStaticMethods(this Type type, string name)
        {
#if NETSTANDARD1_0
            return GetMethods(type, name, isPublic: true, isStatic: true);
#else
            return GetMethods(type, name, Public | Static);
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
            => type.GetPublicStaticMethods(name).FirstOrDefault();

        /// <summary>
        /// Gets the public, static-scoped method with the given <paramref name="name"/> and 
        /// <paramref name="parameterCount"/> for the given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <param name="parameterCount">The number of parameters the method overload should have.</param>
        /// <returns>
        /// The matching public, static-scoped method for the given <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetPublicStaticMethod(this Type type, string name, int parameterCount)
            => type.GetPublicStaticMethods(name).WithParameterCount(parameterCount);

        /// <summary>
        /// Gets the public, static-scoped method with the given <paramref name="name"/> and 
        /// <paramref name="parameterTypes"/> for the given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <param name="parameterTypes">The Types of the parameters the method overload should have.</param>
        /// <returns>
        /// The matching public, static-scoped method for the given <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetPublicStaticMethod(this Type type, string name, params Type[] parameterTypes)
            => type.GetPublicStaticMethods(name).WithParameterTypes(parameterTypes);

        /// <summary>
        /// Gets the public, instance-scoped methods for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <returns>The given <paramref name="type"/>'s public, instance-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetPublicInstanceMethods(this Type type)
            => GetPublicInstanceMethods(type, name: null);

        /// <summary>
        /// Gets the public, instance-scoped methods with the given <paramref name="name"/> for the 
        /// given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the methods to find.</param>
        /// <returns>The given <paramref name="type"/>'s matching public, instance-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetPublicInstanceMethods(this Type type, string name)
        {
#if NETSTANDARD1_0
            return GetMethods(type, name, isPublic: true, isStatic: false);
#else
            return GetMethods(type, name, Public | Instance);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped method with the given <paramref name="name"/> for the 
        /// given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <returns>
        /// The matching public, instance-scoped method for the given <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetPublicInstanceMethod(this Type type, string name)
            => type.GetPublicInstanceMethods(name).FirstOrDefault();

        /// <summary>
        /// Gets the public, instance-scoped method with the given <paramref name="name"/> and 
        /// <paramref name="parameterCount"/> for the given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <param name="parameterCount">The number of parameters the method overload should have.</param>
        /// <returns>
        /// The matching public, instance-scoped method for the given <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetPublicInstanceMethod(this Type type, string name, int parameterCount)
            => type.GetPublicInstanceMethods(name).WithParameterCount(parameterCount);

        /// <summary>
        /// Gets the public, instance-scoped method with the given <paramref name="name"/> and 
        /// <paramref name="parameterTypes"/> for the given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <param name="parameterTypes">The Types of the parameters the method overload should have.</param>
        /// <returns>
        /// The matching public, instance-scoped method for the given <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetPublicInstanceMethod(this Type type, string name, params Type[] parameterTypes)
            => type.GetPublicInstanceMethods(name).WithParameterTypes(parameterTypes);

        /// <summary>
        /// Gets the non-public, static-scoped methods for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <returns>The given <paramref name="type"/>'s non-public, static-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetNonPublicStaticMethods(this Type type)
            => GetNonPublicStaticMethods(type, name: null);

        /// <summary>
        /// Gets the non-public, static-scoped methods with the given <paramref name="name"/> for the 
        /// given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <returns>The given <paramref name="type"/>'s matching non-public, static-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetNonPublicStaticMethods(this Type type, string name)
        {
#if NETSTANDARD1_0
            return GetMethods(type, name, isPublic: false, isStatic: true);
#else
            return GetMethods(type, name, NonPublic | Static);
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
            => type.GetNonPublicStaticMethods(name).FirstOrDefault();

        /// <summary>
        /// Gets the non-public, static-scoped method with the given <paramref name="name"/> and 
        /// <paramref name="parameterCount"/> for the given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <param name="parameterCount">The number of parameters the method overload should have.</param>
        /// <returns>
        /// The matching non-public, static-scoped method for the given <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetNonPublicStaticMethod(this Type type, string name, int parameterCount)
            => type.GetNonPublicStaticMethods(name).WithParameterCount(parameterCount);

        /// <summary>
        /// Gets the non-public, static-scoped method with the given <paramref name="name"/> and 
        /// <paramref name="parameterTypes"/> for the given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <param name="parameterTypes">The Types of the parameters the method overload should have.</param>
        /// <returns>
        /// The matching non-public, static-scoped method for the given <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetNonPublicStaticMethod(this Type type, string name, params Type[] parameterTypes)
            => type.GetNonPublicStaticMethods(name).WithParameterTypes(parameterTypes);

        /// <summary>
        /// Gets the non-public, instance-scoped methods for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <returns>The given <paramref name="type"/>'s non-public, instance-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetNonPublicInstanceMethods(this Type type)
            => GetNonPublicInstanceMethods(type, name: null);

        /// <summary>
        /// Gets the non-public, instance-scoped methods with the given <paramref name="name"/> for the 
        /// given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the methods to find.</param>
        /// <returns>The given <paramref name="type"/>'s matching non-public, instance-scoped methods.</returns>
        public static IEnumerable<MethodInfo> GetNonPublicInstanceMethods(this Type type, string name)
        {
#if NETSTANDARD1_0
            return GetMethods(type, name, isPublic: false, isStatic: false);
#else
            return GetMethods(type, name, NonPublic | Instance);
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
            => type.GetNonPublicInstanceMethods(name).FirstOrDefault();

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
            => type.GetNonPublicInstanceMethods(name).WithParameterCount(parameterCount);

        /// <summary>
        /// Gets the non-public, instance-scoped method with the given <paramref name="name"/> and 
        /// <paramref name="parameterTypes"/> for the given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type from which to retrieve the methods.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <param name="parameterTypes">The Types of the parameters the method overload should have.</param>
        /// <returns>
        /// The matching non-public, instance-scoped method for the given <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetNonPublicInstanceMethod(this Type type, string name, params Type[] parameterTypes)
            => type.GetNonPublicInstanceMethods(name).WithParameterTypes(parameterTypes);

        #region Helper Methods

#if NETSTANDARD1_0
        internal static IEnumerable<MethodInfo> GetMethods(this Type type, bool isPublic, bool? isStatic = null)
            => GetMethods(type, name: null, isPublic: isPublic, isStatic: isStatic);

        private static IEnumerable<MethodInfo> GetMethods(Type type, string name, bool isPublic, bool? isStatic = null)
        {
            return GetMethods(
                type,
                t => t.GetTypeInfo().DeclaredMethods,
                name,
                m => m.IsPublic == isPublic && (!isStatic.HasValue || m.IsStatic == isStatic));
        }
#else
        private static IEnumerable<MethodInfo> GetMethods(Type type, string name, BindingFlags bindingFlags)
            => GetMethods(type, t => t.GetMethods(bindingFlags), name);
#endif
        private static IEnumerable<MethodInfo> GetMethods(
            Type type,
            Func<Type, IEnumerable<MethodInfo>> methodsFactory,
            string name,
            Func<MethodInfo, bool> methodFilter = null)
        {
            methodFilter ??= _ => true;

            return MemberFinder<MethodInfo>.EnumerateMembers(
                type,
                methodsFactory,
                name,
                method => !method.IsSpecialName && methodFilter.Invoke(method),
                MethodHasNotBeenOverridden);
        }

        private static bool MethodHasNotBeenOverridden(MethodBase method, ICollection<MethodInfo> methodsSoFar)
        {
            if (methodsSoFar.Count == 0)
            {
                return true;
            }

            var methodParameterTypes = method
                .GetParameters()
                .Project(p => p.ParameterType)
                .ToArray();

            return methodsSoFar.All(m =>
                (method.Name != m.Name) ||
                !methodParameterTypes.SequenceEqual(m.GetParameters().Project(p => p.ParameterType)));
        }

        private static MethodInfo WithParameterCount(this IEnumerable<MethodInfo> methods, int parameterCount)
        {
            var matchingMethods = methods
                .Filter(m => m.GetParameters().Length == parameterCount)
                .ToArray();

            if (matchingMethods.Length == 0)
            {
                return null;
            }

            if (matchingMethods.Length > 1)
            {
                throw new AmbiguousMatchException(
                    "Multiple methods found with " + parameterCount + " parameter(s)");
            }

            return matchingMethods[0];
        }

        private static MethodInfo WithParameterTypes(this IEnumerable<MethodInfo> methods, Type[] parameterTypes)
        {
            return methods
                .FirstOrDefault(m => m.GetParameters().Project(p => p.ParameterType).SequenceEqual(parameterTypes));
        }

        #endregion
    }
}
