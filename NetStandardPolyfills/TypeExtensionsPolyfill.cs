namespace AgileObjects.NetStandardPolyfills
{
    using System;
#if NET_STANDARD
    using System.Collections.Generic;
#endif
    using System.Reflection;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Provides a set of static methods for obtaining type information in .NET Standard 1.0.
    /// </summary>
    public static class TypeExtensionsPolyfill
    {
        /// <summary>
        /// Returns a value indicating if the given <paramref name="type"/> is a class.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if the given <paramref name="type"/> is a class, otherwise false.</returns>
        public static bool IsClass(this Type type)
        {
#if NET_STANDARD
            return type.GetTypeInfo().IsClass;
#else
            return type.IsClass;
#endif
        }

        /// <summary>
        /// Returns a value indicating if the given <paramref name="type"/> is a value type.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if the given <paramref name="type"/> is a value type, otherwise false.</returns>
        public static bool IsValueType(this Type type)
        {
#if NET_STANDARD
            return type.GetTypeInfo().IsValueType;
#else
            return type.IsValueType;
#endif
        }

        /// <summary>
        /// Returns a value indicating if the given <paramref name="type"/> is an interface.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if the given <paramref name="type"/> is an interface, otherwise false.</returns>
        public static bool IsInterface(this Type type)
        {
#if NET_STANDARD
            return type.GetTypeInfo().IsInterface;
#else
            return type.IsInterface;
#endif
        }

        /// <summary>
        /// Returns a value indicating if the given <paramref name="type"/> is sealed.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if the given <paramref name="type"/> is sealed, otherwise false.</returns>
        public static bool IsSealed(this Type type)
        {
#if NET_STANDARD
            return type.GetTypeInfo().IsSealed;
#else
            return type.IsSealed;
#endif
        }

        /// <summary>
        /// Returns a value indicating if the given <paramref name="type"/> is abstract.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if the given <paramref name="type"/> is abstract, otherwise false.</returns>
        public static bool IsAbstract(this Type type)
        {
#if NET_STANDARD
            return type.GetTypeInfo().IsAbstract;
#else
            return type.IsAbstract;
#endif
        }

        /// <summary>
        /// Returns a value indicating if the given <paramref name="type"/> is an
        /// anonymous type. See http://stackoverflow.com/questions/2483023/how-to-test-if-a-type-is-anonymous
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>
        /// True if the given <paramref name="type"/> is an anonymous type, otherwise false.
        /// </returns>
        public static bool IsAnonymous(this Type type)
        {
            return type.IsGenericType() &&
                   type.Name.Contains("AnonymousType") &&
                   (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$")) &&
                   (type.GetAttributes() & TypeAttributes.NotPublic) == TypeAttributes.NotPublic &&
                   type.HasAttribute<CompilerGeneratedAttribute>();
        }

        /// <summary>
        /// Returns a value indicating if the given <paramref name="type"/> is an enum.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if the given <paramref name="type"/> is an enum, otherwise false.</returns>
        public static bool IsEnum(this Type type)
        {
#if NET_STANDARD
            return type.GetTypeInfo().IsEnum;
#else
            return type.IsEnum;
#endif
        }

        /// <summary>
        /// Returns a value indicating if the given <paramref name="type"/> is a generic type.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if the given <paramref name="type"/> is a generic type, otherwise false.</returns>
        public static bool IsGenericType(this Type type)
        {
#if NET_STANDARD
            return type.GetTypeInfo().IsGenericType;
#else
            return type.IsGenericType;
#endif
        }

        /// <summary>
        /// Gets the Assembly to which the given <paramref name="type"/> belongs.
        /// </summary>
        /// <param name="type">The type for which to retrieve the Assembly.</param>
        /// <returns>The Assembly to which the given <paramref name="type"/> belongs.</returns>
        public static Assembly GetAssembly(this Type type)
        {
#if NET_STANDARD
            return type.GetTypeInfo().Assembly;
#else
            return type.Assembly;
#endif
        }

        /// <summary>
        /// Gets the given <paramref name="type"/>'s base type or null if there is none.
        /// </summary>
        /// <param name="type">The type for which to retrieve the base type.</param>
        /// <returns>The given <paramref name="type"/>'s base type or null if there is none.</returns>
        public static Type GetBaseType(this Type type)
        {
#if NET_STANDARD
            return type.GetTypeInfo().BaseType;
#else
            return type.BaseType;
#endif
        }

        /// <summary>
        /// Returns a value indicating if the given <paramref name="childType"/> is derived from
        /// the given <paramref name="parentType"/>.
        /// </summary>
        /// <param name="childType">The descendant type for which to make the determination.</param>
        /// <param name="parentType">The ancestor type for which to make the determination.</param>
        /// <returns>
        /// True if the given <paramref name="childType"/> is derived from the given 
        /// <paramref name="parentType"/>, otherwise false.
        /// </returns>
        public static bool IsDerivedFrom(this Type childType, Type parentType)
        {
#if NET_STANDARD
            return childType.GetTypeInfo().IsSubclassOf(parentType);
#else
            return childType.IsSubclassOf(parentType);
#endif
        }

        /// <summary>
        /// Returns a value indicating if the given <paramref name="type"/> has the Attribute
        /// given in the <typeparamref name="TAttribute"/> type argument.
        /// </summary>
        /// <typeparam name="TAttribute">The Attribute type for which to make the determination.</typeparam>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>
        /// True if the given <paramref name="type"/> has the given <typeparamref name="TAttribute"/>,
        /// otherwise false.
        /// </returns>
        public static bool HasAttribute<TAttribute>(this Type type)
            where TAttribute : Attribute
        {
#if NET_STANDARD
            return type.GetTypeInfo().GetCustomAttribute<TAttribute>(inherit: false) != null;
#else
            return Attribute.IsDefined(type, typeof(TAttribute), inherit: false);
#endif
        }

        /// <summary>
        /// Gets the TypeAttributes value applied to the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type for which to retrieve the TypeAttributes value.</param>
        /// <returns>The TypeAttributes value applied to the given <paramref name="type"/>.</returns>
        public static TypeAttributes GetAttributes(this Type type)
        {
#if NET_STANDARD
            return type.GetTypeInfo().Attributes;
#else
            return type.Attributes;
#endif
        }

#if NET_STANDARD
        private static readonly Dictionary<Type, NetStandardTypeCode> _typeCodesByType = new Dictionary<Type, NetStandardTypeCode>
        {
            {typeof(bool), NetStandardTypeCode.Boolean },
            {typeof(byte), NetStandardTypeCode.Byte },
            {typeof(char), NetStandardTypeCode.Char},
            {typeof(DateTime), NetStandardTypeCode.DateTime},
            {typeof(decimal), NetStandardTypeCode.Decimal},
            {typeof(double), NetStandardTypeCode.Double },
            {typeof(short), NetStandardTypeCode.Int16 },
            {typeof(int), NetStandardTypeCode.Int32 },
            {typeof(long), NetStandardTypeCode.Int64 },
            {typeof(object), NetStandardTypeCode.Object},
            {typeof(sbyte), NetStandardTypeCode.SByte },
            {typeof(float), NetStandardTypeCode.Single },
            {typeof(string), NetStandardTypeCode.String },
            {typeof(ushort), NetStandardTypeCode.UInt16 },
            {typeof(uint), NetStandardTypeCode.UInt32 },
            {typeof(ulong), NetStandardTypeCode.UInt64 },
        };
#endif
        /// <summary>
        /// Gets the appropriate <see cref="NetStandardTypeCode"/> value for the given <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type for which to retrieve the <see cref="NetStandardTypeCode"/>.</param>
        /// <returns>The appropriate <see cref="NetStandardTypeCode"/> value.</returns>
        public static NetStandardTypeCode GetTypeCode(this Type type)
        {
#if NET_STANDARD
            if (type == null)
            {
                return NetStandardTypeCode.Empty;
            }

            if (type.FullName == "System.DBNull")
            {
                return NetStandardTypeCode.DBNull;
            }

            if (type.IsEnum())
            {
                type = Enum.GetUnderlyingType(type);
            }

            NetStandardTypeCode typeCode;

            if (_typeCodesByType.TryGetValue(type, out typeCode))
            {
                return typeCode;
            }

            return NetStandardTypeCode.Object;
#else
            return (NetStandardTypeCode)Type.GetTypeCode(type);
#endif
        }
    }
}
