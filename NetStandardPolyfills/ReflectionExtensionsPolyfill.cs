namespace AgileObjects.NetStandardPolyfills
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides a set of static methods methods for obtaining reflection information in .NET Standard 1.0.
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
        /// Gets the public, instance-scoped constructors for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type for which to retrieve the constructors.</param>
        /// <returns>The given <paramref name="type"/>'s public, instance-scoped constructors.</returns>
        public static IEnumerable<ConstructorInfo> GetPublicInstanceConstructors(this Type type)
        {
#if NET_STANDARD
            return type.GetTypeInfo().DeclaredConstructors.Where(c => c.IsPublic && !c.IsStatic);
#else
            return type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the non-public, instance-scoped constructors for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type for which to retrieve the constructors.</param>
        /// <returns>The given <paramref name="type"/>'s non-public, instance-scoped constructors.</returns>
        public static IEnumerable<ConstructorInfo> GetNonPublicInstanceConstructors(this Type type)
        {
#if NET_STANDARD
            return type.GetTypeInfo().DeclaredConstructors.Where(c => !c.IsPublic && !c.IsStatic);
#else
            return type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
#endif
        }

        /// <summary>
        /// Gets the public, instance-scoped member with the given <paramref name="name"/>
        /// from the given <paramref name="type"/>, or null if none exists.
        /// </summary>
        /// <param name="type">The type for which to retrieve the member.</param>
        /// <param name="name">The name of the method to find.</param>
        /// <returns>
        /// The public, instance-scoped member with the given <paramref name="name"/> from 
        /// the given <paramref name="type"/>, or null if none exists.
        /// </returns>
        public static IEnumerable<MemberInfo> GetPublicInstanceMember(this Type type, string name)
        {
#if NET_STANDARD
            return type.GetTypeInfo().DeclaredMembers.Where(m => m.Name == name);
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
            return type.GetTypeInfo().DeclaredFields.Where(f => f.IsPublic && !f.IsStatic);
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
            return type.GetTypeInfo().DeclaredProperties.Where(p =>
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
            return type.GetTypeInfo().GetDeclaredProperty(name);
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
            return type.GetTypeInfo().DeclaredMethods.Where(m => m.IsPublic && !m.IsStatic);
#else
            return type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
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
            return type.GetTypeInfo().DeclaredMethods.Where(m => !m.IsPublic && !m.IsStatic);
#else
            return type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
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
            return type.GetTypeInfo().DeclaredMethods.Where(m => m.IsPublic && m.IsStatic);
#else
            return type.GetMethods(BindingFlags.Public | BindingFlags.Static);
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
            return type.GetTypeInfo().DeclaredMethods.First(m => m.IsPublic && m.IsStatic && (m.Name == name));
#else
            return type.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Static);
#endif
        }
    }
}
