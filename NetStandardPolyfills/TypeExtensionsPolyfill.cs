﻿namespace AgileObjects.NetStandardPolyfills
{
    using System;
    using System.Collections;
    using System.Linq;
#if NETSTANDARD1_0
    using System.Collections.Generic;
#endif
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using static System.Reflection.GenericParameterAttributes;

    /// <summary>
    /// Provides a set of static methods for obtaining type information in .NET Standard 1.0.
    /// </summary>
    public static class TypeExtensionsPolyfill
    {
        /// <summary>
        /// Returns a value indicating if this <paramref name="type"/> is public.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if this <paramref name="type"/> is public, otherwise false.</returns>
        public static bool IsPublic(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetTypeInfo().IsPublic;
#else
            return type.IsPublic;
#endif
        }

        /// <summary>
        /// Returns a value indicating if this <paramref name="type"/> is a class.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if this <paramref name="type"/> is a class, otherwise false.</returns>
        public static bool IsClass(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetTypeInfo().IsClass;
#else
            return type.IsClass;
#endif
        }

        /// <summary>
        /// Returns a value indicating if this <paramref name="type"/> is a value type.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if this <paramref name="type"/> is a value type, otherwise false.</returns>
        public static bool IsValueType(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetTypeInfo().IsValueType;
#else
            return type.IsValueType;
#endif
        }

        /// <summary>
        /// Returns a value indicating if this <paramref name="type"/> is an interface.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if this <paramref name="type"/> is an interface, otherwise false.</returns>
        public static bool IsInterface(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetTypeInfo().IsInterface;
#else
            return type.IsInterface;
#endif
        }

        /// <summary>
        /// Returns a value indicating if this <paramref name="type"/> is sealed.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if this <paramref name="type"/> is sealed, otherwise false.</returns>
        public static bool IsSealed(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetTypeInfo().IsSealed;
#else
            return type.IsSealed;
#endif
        }

        /// <summary>
        /// Returns a value indicating if this <paramref name="type"/> is abstract.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if this <paramref name="type"/> is abstract, otherwise false.</returns>
        public static bool IsAbstract(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetTypeInfo().IsAbstract;
#else
            return type.IsAbstract;
#endif
        }

        /// <summary>
        /// Returns a value indicating if this <paramref name="type"/> is an anonymous type.
        /// See https://stackoverflow.com/questions/2483023/how-to-test-if-a-type-is-anonymous
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if this <paramref name="type"/> is an anonymous type, otherwise false.</returns>
        public static bool IsAnonymous(this Type type)
        {
            return type.IsGenericType() &&
                   type.Name.Contains("AnonymousType") &&
                   (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$")) &&
#if NET35
                   (type.GetAttributes() & TypeAttributes.NotPublic) == TypeAttributes.NotPublic &&
#else
                   type.GetAttributes().HasFlag(TypeAttributes.NotPublic) &&
#endif
                   type.HasAttribute<CompilerGeneratedAttribute>();
        }

        /// <summary>
        /// Returns a value indicating if this <paramref name="type"/> is an enum.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if this <paramref name="type"/> is an enum, otherwise false.</returns>
        public static bool IsEnum(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetTypeInfo().IsEnum;
#else
            return type.IsEnum;
#endif
        }

        /// <summary>
        /// Determines if this <paramref name="type"/> is an enumerable Type.
        /// </summary>
        /// <param name="type">The Type for which to make the determination.</param>
        /// <returns>True if this <paramref name="type"/> is an enumerable Type, otherwise false.</returns>
        public static bool IsEnumerable(this Type type)
        {
            return type.IsArray ||
                   (type != typeof(string) &&
                    type.IsAssignableTo(typeof(IEnumerable)));
        }

        /// <summary>
        /// Returns a value indicating if this <paramref name="type"/> is a primitive.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if this <paramref name="type"/> is a primitive, otherwise false.</returns>
        public static bool IsPrimitive(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetTypeInfo().IsPrimitive;
#else
            return type.IsPrimitive;
#endif
        }

        /// <summary>
        /// Returns a value indicating if this <paramref name="type"/> is a generic type.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if this <paramref name="type"/> is a generic type, otherwise false.</returns>
        public static bool IsGenericType(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetTypeInfo().IsGenericType;
#else
            return type.IsGenericType;
#endif
        }

        /// <summary>
        /// Returns a value indicating if this <paramref name="type"/> is a closed version of the
        /// given <paramref name="genericTypeDefinition"/>.
        /// </summary>
        /// <param name="type">The type for which to make the determination, e.g. List&lt;string&gt;.</param>
        /// <param name="genericTypeDefinition">
        /// The open generic type for which to make the determination, , e.g. List&lt;&gt;.
        /// </param>
        /// <returns>
        /// True if this <paramref name="type"/> is a closed version of the given 
        /// <paramref name="genericTypeDefinition"/>, otherwise false.
        /// </returns>
        public static bool IsClosedTypeOf(this Type type, Type genericTypeDefinition)
            => type.IsGenericType() && (type.GetGenericTypeDefinition() == genericTypeDefinition);

        /// <summary>
        /// Returns an array of Types that represent the type arguments of a generic type or the 
        /// type parameters of a generic type definition.
        /// </summary>
        /// <param name="type">The type for which to retrieve the generic arguments.</param>
        /// <returns>
        /// An array of Types that represent the type arguments of a generic type, or an empty array 
        /// if this <paramref name="type"/> is not a generic type.
        /// </returns>
        public static Type[] GetGenericTypeArguments(this Type type)
        {
#if NETSTANDARD1_0
            return type.IsConstructedGenericType
                ? type.GetTypeInfo().GenericTypeArguments
                : type.GetTypeInfo().GenericTypeParameters;
#else
            return type.GetGenericArguments();
#endif
        }

        /// <summary>
        /// Determines if this <paramref name="type"/> represents a type paramter in the definition
        /// of a generic type or method.
        /// </summary>
        /// <param name="type">The Type for which to make the determination.</param>
        /// <returns>
        /// True if this <paramref name="type"/> represents a type paramter in the definition of a
        /// generic type or method, otherwise false.
        /// </returns>
        public static bool IsGenericParameter(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetTypeInfo().IsGenericParameter;
#else
            return type.IsGenericParameter;
#endif
        }

        /// <summary>
        /// Gets the GenericParameterAttributes describing this <paramref name="type"/>'s generic
        /// parameter constraints. If this <paramref name="type"/> is not a generic parameter type,
        /// returns GenericParameterAttributes.None.
        /// </summary>
        /// <param name="type">The Type for which to retrieve the GenericParameterAttributes.</param>
        /// <returns>
        /// The GenericParameterAttributes describing this <paramref name="type"/>'s generic
        /// parameter constraints, or GenericParameterAttributes.None if this
        /// <paramref name="type"/> is not a generic parameter type.
        /// </returns>
        public static GenericParameterAttributes GetConstraints(this Type type)
        {
            if (!IsGenericParameter(type))
            {
                return None;
            }

#if NETSTANDARD1_0
            return type.GetTypeInfo().GenericParameterAttributes;
#else
            return type.GenericParameterAttributes;
#endif
        }

#if !FEATURE_ARRAY_EMPTY
        private static readonly Type[] _empty = {};
#endif
        /// <summary>
        /// Gets the Types to which this generic parameter <paramref name="type"/> is constrained,
        /// if applicable. If this <paramref name="type"/> is not a generic parameter type, returns
        /// an empty array.
        /// </summary>
        /// <param name="type">The Type for which to retrieve the constraint Types.</param>
        /// <returns>
        /// The Types to which this generic parameter <paramref name="type"/> is constrained, or
        /// an empty array this <paramref name="type"/> is not a generic parameter type.
        /// </returns>
        public static Type[] GetConstraintTypes(this Type type)
        {
            if (!IsGenericParameter(type))
            {
#if FEATURE_ARRAY_EMPTY
                return Array.Empty<Type>();
#else
                return _empty;
#endif
            }

#if NETSTANDARD1_0
            return type.GetTypeInfo().GetGenericParameterConstraints();
#else
            return type.GetGenericParameterConstraints();
#endif
        }

        /// <summary>
        /// Gets the Assembly to which this <paramref name="type"/> belongs.
        /// </summary>
        /// <param name="type">The type for which to retrieve the Assembly.</param>
        /// <returns>The Assembly to which this <paramref name="type"/> belongs.</returns>
        public static Assembly GetAssembly(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetTypeInfo().Assembly;
#else
            return type.Assembly;
#endif
        }

        /// <summary>
        /// Gets this <paramref name="type"/>'s base type or null if there is none.
        /// </summary>
        /// <param name="type">The type for which to retrieve the base type.</param>
        /// <returns>This <paramref name="type"/>'s base type or null if there is none.</returns>
        public static Type GetBaseType(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetTypeInfo().BaseType;
#else
            return type.BaseType;
#endif
        }

        /// <summary>
        /// Gets all the interfaces implemented or inherited by this <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The Type for which to retrieve the implemented interfaces.</param>
        /// <returns>
        /// An array of Types representing all the interfaces implemented or inherited by this
        /// <paramref name="type"/>, or an empty array if no interfaces are implemented or inherited.
        /// </returns>
        public static Type[] GetAllInterfaces(this Type type)
        {
#if NETSTANDARD1_0
            var allInterfaces = new List<Type>();

            while (type != null)
            {
                allInterfaces.AddRange(type.GetTypeInfo().ImplementedInterfaces);

                type = type.GetBaseType();
            }

            return allInterfaces.Distinct().ToArray();
#else
            return type.GetInterfaces();
#endif
        }

        /// <summary>
        /// Returns a value indicating if this <paramref name="childType"/> is derived from the given
        /// <paramref name="parentType"/>.
        /// </summary>
        /// <param name="childType">The descendant type for which to make the determination.</param>
        /// <param name="parentType">The ancestor type for which to make the determination.</param>
        /// <returns>
        /// True if this <paramref name="childType"/> is derived from the given 
        /// <paramref name="parentType"/>, otherwise false.
        /// </returns>
        public static bool IsDerivedFrom(this Type childType, Type parentType)
        {
#if NETSTANDARD1_0
            return childType.GetTypeInfo().IsSubclassOf(parentType);
#else
            return childType.IsSubclassOf(parentType);
#endif
        }

        /// <summary>
        /// Determines whether an instance of this <paramref name="assignableType"/> can be assigned 
        /// to an instance of this <paramref name="type"/>.
        /// </summary>
        /// <param name="assignableType">The Type the assignability of which should be determined.</param>
        /// <param name="type">The Type to compare with the current type.</param>
        /// <returns>
        /// True if the <paramref name="type"/> and this <paramref name="assignableType"/> represent 
        /// the same type, or if the current <paramref name="assignableType"/> is in the inheritance
        /// hierarchy of the <paramref name="type"/>, or if this <paramref name="assignableType"/> is
        /// an interface that the <paramref name="type"/> implements, or if the
        /// <paramref name="type"/> is a generic type parameter and this
        /// <paramref name="assignableType"/> represents one of its constraints. False if none of
        /// these conditions are true, or if the <paramref name="type"/> is null.
        /// </returns>
        public static bool IsAssignableTo(this Type assignableType, Type type)
        {
#if NETSTANDARD1_0
            return type?.GetTypeInfo().IsAssignableFrom(assignableType.GetTypeInfo()) == true;
#else
            return type?.IsAssignableFrom(assignableType) == true;
#endif
        }

        /// <summary>
        /// Returns a value indicating if this <paramref name="type"/> has the Attribute
        /// given in the <typeparamref name="TAttribute"/> type argument.
        /// </summary>
        /// <typeparam name="TAttribute">The Attribute type for which to make the determination.</typeparam>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>
        /// True if this <paramref name="type"/> has the given <typeparamref name="TAttribute"/>,
        /// otherwise false.
        /// </returns>
        public static bool HasAttribute<TAttribute>(this Type type)
            where TAttribute : Attribute
        {
#if NETSTANDARD1_0
            return type.GetTypeInfo().GetCustomAttribute<TAttribute>(inherit: false) != null;
#else
            return Attribute.IsDefined(type, typeof(TAttribute), inherit: false);
#endif
        }

        /// <summary>
        /// Gets the TypeAttributes value applied to this <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type for which to retrieve the TypeAttributes value.</param>
        /// <returns>The TypeAttributes value applied to this <paramref name="type"/>.</returns>
        public static TypeAttributes GetAttributes(this Type type)
        {
#if NETSTANDARD1_0
            return type.GetTypeInfo().Attributes;
#else
            return type.Attributes;
#endif
        }

        /// <summary>
        /// Returns a value indicating if this <paramref name="type"/> can be null.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if this <paramref name="type"/> can be null, otherwise false.</returns>
        public static bool CanBeNull(this Type type)
        {
            if (!type.IsGenericParameter())
            {
                return type.IsClass() || type.IsInterface() || type.IsNullableType();
            }

            var typeConstraints = type.GetConstraints();

            if ((typeConstraints & ReferenceTypeConstraint) == ReferenceTypeConstraint)
            {
                return true;
            }

            if ((typeConstraints & NotNullableValueTypeConstraint) == NotNullableValueTypeConstraint)
            {
                return false;
            }

            return type.GetConstraintTypes().Any(t => t.CanBeNull());

        }

        /// <summary>
        /// Returns a value indicating if this <paramref name="type"/> is a Nullable&lt;T&gt;.
        /// </summary>
        /// <param name="type">The type for which to make the determination.</param>
        /// <returns>True if this <paramref name="type"/> is a Nullable&lt;T&gt;, otherwise false.</returns>
        public static bool IsNullableType(this Type type)
            => Nullable.GetUnderlyingType(type) != null;

        /// <summary>
        /// Gets the underlying non-nullable Type of this <paramref name="type"/>, or returns this
        /// <paramref name="type"/> if it is not nullable.
        /// </summary>
        /// <param name="type">The Type for which to retrieve the underlying non-nullable Type.</param>
        /// <returns>
        /// The underlying non-nullable Type of this <paramref name="type"/>, or returns this
        /// <paramref name="type"/> if it is not nullable.
        /// </returns>
        public static Type GetNonNullableType(this Type type) => Nullable.GetUnderlyingType(type) ?? type;

#if NETSTANDARD1_0
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
        /// Gets the appropriate <see cref="NetStandardTypeCode"/> value for this <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type for which to retrieve the <see cref="NetStandardTypeCode"/>.</param>
        /// <returns>The appropriate <see cref="NetStandardTypeCode"/> value.</returns>
        public static NetStandardTypeCode GetTypeCode(this Type type)
        {
#if NETSTANDARD1_0
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
