namespace AgileObjects.NetStandardPolyfills
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides a set of static methods methods for obtaining reflection information in .NET Standard 1.0 and .NET 4.0.
    /// </summary>
    public static class ReflectionExtensionsPolyfill
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
        /// Gets the public, instance-scoped members for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the member.</param>
        /// <returns>
        /// The public, instance-scoped members for the given <paramref name="type"/>.
        /// </returns>
        public static IEnumerable<MemberInfo> GetPublicInstanceMembers(this Type type)
        {
#if NET_STANDARD
            const int PUBLIC_INSTANCE = 20;

            return GetMembers(type, PUBLIC_INSTANCE);
#else
            return type.GetMembers(BindingFlags.Public | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped members with the given <paramref name="name"/>
        /// for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the members.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <returns>
        /// The public, instance-scoped members with the given <paramref name="name"/> for 
        /// the given <paramref name="type"/>.
        /// </returns>
        public static IEnumerable<MemberInfo> GetPublicInstanceMembers(this Type type, string name)
        {
#if NET_STANDARD
            return type.GetPublicInstanceMembers().Where(m => m.Name == name);
#else
            return type.GetMember(name, BindingFlags.Public | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped fields for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type for which to retrieve the fields.</param>
        /// <returns>The given <paramref name="type"/>'s public, instance-scoped fields.</returns>
        public static IEnumerable<FieldInfo> GetPublicInstanceFields(this Type type)
        {
#if NET_STANDARD
            return type.GetFields().Where(f => f.IsPublic && !f.IsStatic);
#else
            return type.GetFields(BindingFlags.Public | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped properties for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type for which to retrieve the properties.</param>
        /// <returns>The given <paramref name="type"/>'s public, instance-scoped properties.</returns>
        public static IEnumerable<PropertyInfo> GetPublicInstanceProperties(this Type type)
        {
#if NET_STANDARD
            return type.GetProperties().Where(p =>
                !(p.GetMethod ?? p.SetMethod).IsStatic &&
                ((p.GetMethod != null && p.GetMethod.IsPublic) || (p.SetMethod != null && p.SetMethod.IsPublic)));
#else
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped property with the given <paramref name="name"/>
        /// from the given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type for which to retrieve the property.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <returns>
        /// The public, instance-scoped property with the given <paramref name="name"/> from 
        /// the given <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static PropertyInfo GetPublicInstanceProperty(this Type type, string name)
        {
#if NET_STANDARD
            return type.GetProperty(name);
#else
            return type.GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
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
            return type.GetMethods().WithoutPropertyGettersAnd(m => !m.IsStatic);
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
            return type.GetMethod(name);
#else
            return type.GetMethod(name);
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
            const int NON_PUBLIC_INSTANCE = 36;

            return GetMethods(type, NON_PUBLIC_INSTANCE);
#else
            return type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).WithoutPropertyGetters();
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
            return type.GetMethods().WithoutPropertyGettersAnd(m => m.IsStatic);
#else
            return type.GetMethods(BindingFlags.Public | BindingFlags.Static).WithoutPropertyGetters();
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
            const int NON_PUBLIC_STATIC = 40;

            return GetMethods(type, NON_PUBLIC_STATIC);
#else
            return type.GetMethods(BindingFlags.NonPublic | BindingFlags.Static).WithoutPropertyGetters();
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
            const int NON_PUBLIC_STATIC = 40;

            return GetMethods(type, NON_PUBLIC_STATIC).First(m => m.Name == name);
#else
            return type.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Static);
#endif
        }

        #region Helper Methods

#if NET_STANDARD
        private static readonly MethodInfo _getMembersMethod = typeof(TypeExtensions)
            .GetPublicStaticMethods()
            .First(m => (m.Name == "GetMembers") && (m.GetParameters().Length == 2));

        private static IEnumerable<MemberInfo> GetMembers(Type type, int bindingFlagsConstant)
        {
            var members = (IEnumerable<MemberInfo>)_getMembersMethod
                .Invoke(null, new object[] { type, bindingFlagsConstant });

            return members;
        }

        private static readonly MethodInfo _getMethodsMethod = typeof(TypeExtensions)
            .GetPublicStaticMethods()
            .First(m => (m.Name == "GetMethods") && (m.GetParameters().Length == 2));

        private static IEnumerable<MethodInfo> GetMethods(Type type, int bindingFlagsConstant)
        {
            var methods = (IEnumerable<MethodInfo>)_getMethodsMethod
                .Invoke(null, new object[] { type, bindingFlagsConstant });

            return methods.WithoutPropertyGetters();
        }
#endif

        private static IEnumerable<MethodInfo> WithoutPropertyGetters(this IEnumerable<MethodInfo> methods)
            => methods.WithoutPropertyGettersAnd(m => true);

        private static IEnumerable<MethodInfo> WithoutPropertyGettersAnd(
            this IEnumerable<MethodInfo> methods,
            Func<MethodInfo, bool> extraFilter)
        {
            return methods.Where(m => !m.IsSpecialName && extraFilter.Invoke(m));
        }

        #endregion
    }
}
