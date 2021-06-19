## .NET Standard Polyfills

[![NuGet](http://img.shields.io/nuget/v/AgileObjects.NetStandardPolyfills.svg)](https://www.nuget.org/packages/AgileObjects.NetStandardPolyfills)

A set of Type and Reflection polyfill extension methods for .NET Standard v1.0+ and .NET v3.5+.

### Type Info:

* Type.CanBeNull()
* Type.IsAbstract()
* Type.IsAnonymous()
* Type.IsAssignableTo(Type type)
* Type.IsClass()
* Type.IsClosedTypeOf(Type genericTypeDefinition)
* Type.IsDerivedFrom(Type parentType)
* Type.IsEnum()
* Type.IsEnumerable()
* Type.IsGenericParameter()
* Type.IsGenericType()
* Type.IsInterface()
* Type.IsNullableType()
* Type.IsPrimitive()
* Type.IsPublic()
* Type.IsSealed()
* Type.IsValueType()
* Type.GetAssembly()
* Type.GetAttributes()
* Type.GetBaseType()
* Type.GetConstraints()
* Type.GetConstraintTypes()
* Type.GetInterfaces()
* Type.GetGenericTypeArguments()
* Type.GetNonNullableType()
* Type.GetTypeCode()
* Type.HasAttribute&lt;TAttribute&gt;()

### Constructor Retrieval:

* Type.GetPublicInstanceConstructors()
* Type.GetPublicInstanceConstructor(params Type[] parameterTypes)
* Type.GetNonPublicInstanceConstructors()
* Type.GetNonPublicInstanceConstructor(params Type[] parameterTypes)
* Type.GetStaticConstructor()

### Field Retrieval:

* Type.GetPublicStaticFields()
* Type.GetPublicStaticField(string name)
* Type.GetPublicInstanceFields()
* Type.GetPublicInstanceField(string name)
* Type.GetNonPublicStaticFields()
* Type.GetNonPublicStaticField(string name)
* Type.GetNonPublicInstanceFields()
* Type.GetNonPublicInstanceField(string name)

### Property Retrieval:

* MethodInfo.GetProperty()
* Type.GetPublicStaticProperties()
* Type.GetPublicStaticProperty(string name)
* Type.GetPublicInstanceProperties()
* Type.GetPublicInstanceProperty(string name)
* Type.GetNonPublicStaticProperties()
* Type.GetNonPublicStaticProperty(string name)
* Type.GetNonPublicInstanceProperties()
* Type.GetNonPublicInstanceProperty(string name)

### Method Retrieval:

* Type.GetPublicMethods()
* Type.GetPublicMethod(string name)
* Type.GetPublicMethod(string name, int parameterCount)
* Type.GetPublicMethod(string name, params Type[] parameterTypes)* Type.GetPublicStaticMethods()
* Type.GetPublicStaticMethod(string name)
* Type.GetPublicStaticMethod(string name, int parameterCount)
* Type.GetPublicStaticMethod(string name, params Type[] parameterTypes)
* Type.GetPublicInstanceMethods()
* Type.GetPublicInstanceMethod(string name)
* Type.GetPublicInstanceMethod(string name, int parameterCount)
* Type.GetPublicInstanceMethod(string name, params Type[] parameterTypes)
* Type.GetNonPublicStaticMethods()
* Type.GetNonPublicStaticMethod(string name)
* Type.GetNonPublicStaticMethod(string name, int parameterCount)
* Type.GetNonPublicStaticMethod(string name, params Type[] parameterTypes)
* Type.GetNonPublicInstanceMethods()
* Type.GetNonPublicInstanceMethod(string name)
* Type.GetNonPublicInstanceMethod(string name, int parameterCount)
* Type.GetNonPublicInstanceMethod(string name, params Type[] parameterTypes)

### Member Retrieval:

* Type.GetPublicStaticMembers()
* Type.GetPublicStaticMembers(string name)
* Type.GetPublicStaticMember(string name)
* Type.GetPublicInstanceMembers()
* Type.GetPublicInstanceMembers(string name)
* Type.GetPublicInstanceMember(string name)
* Type.GetNonPublicStaticMembers()
* Type.GetNonPublicStaticMembers(string name)
* Type.GetNonPublicStaticMember(string name)
* Type.GetNonPublicInstanceMembers()
* Type.GetNonPublicInstanceMembers(string name)
* Type.GetNonPublicInstanceMember(string name)

### Operator Retrieval:

* Type.GetOperators(Action<OperatorSelector> matcher = null)
* Type.GetImplicitOperators()
* Type.GetImplicitOperator(Action<OperatorSelector> matcher = null)
* Type.GetExplicitOperators()
* Type.GetExplicitOperator(Action<OperatorSelector> matcher = null)

### Assembly Info:

* Assembly.GetLocation()
* Assembly.GetAllTypes()

### Misc

* ParameterInfo.IsParamsArray()
* PropertyInfo.IsPublic()
* PropertyInfo.IsStatic()
* PropertyInfo.IsReadable()
* PropertyInfo.IsWritable()
* PropertyInfo.IsIndexer()
* PropertyInfo.GetAccessors(bool nonPublic)
* PropertyInfo.GetGetter(bool nonPublic)
* PropertyInfo.GetSetter(bool nonPublic)
* MethodInfo.IsAccessor()
* MethodInfo.IsAccessor(out PropertyInfo property)
* MethodInfo.IsImplicitOperator()
* MethodInfo.IsExplicitOperator()
* MemberInfo.HasAttribute&lt;TAttribute&gt;()

### Download

You can download and install using [the NuGet package](https://www.nuget.org/packages/AgileObjects.NetStandardPolyfills), or clone the repository [on GitHub](https://github.com/agileobjects/NetStandardPolyfills).
