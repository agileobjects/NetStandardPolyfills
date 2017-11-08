## .NET Standard Polyfills

A set of Type and Reflection polyfill extension methods for .NET Standard v1.0 and .NET v4.0.

### Type Info:

* IsAbstract()
* IsAnonymous()
* IsClass()
* IsDerivedFrom(Type parentType)
* IsEnum()
* IsInterface()
* IsGenericType()
* IsPrimitive()
* IsSealed()
* IsValueType()
* GetAttributes()
* GetAssembly()
* GetBaseType()
* GetTypeCode()
* HasAttribute&lt;TAttribute&gt;()

### Constructor Retrieval:

* GetPublicInstanceConstructors()
* GetPublicInstanceConstructor(params Type[] parameterTypes)
* GetNonPublicInstanceConstructors()
* GetNonPublicInstanceConstructor(params Type[] parameterTypes)

### Field Retrieval:

* GetPublicStaticFields()
* GetPublicStaticField(string name)
* GetPublicInstanceFields()
* GetPublicInstanceField(string name)
* GetNonPublicStaticFields()
* GetNonPublicStaticField(string name)
* GetNonPublicInstanceFields()
* GetNonPublicInstanceField(string name)

### Property Retrieval:

* GetPublicStaticProperties()
* GetPublicStaticProperty(string name)
* GetPublicInstanceProperties()
* GetPublicInstanceProperty(string name)
* GetNonPublicStaticProperties()
* GetNonPublicStaticProperty(string name)
* GetNonPublicInstanceProperties()
* GetNonPublicInstanceProperty(string name)

### Method Retrieval:

* GetPublicStaticMethods()
* GetPublicStaticMethod(string name)
* GetPublicStaticMethod(string name, int parameterCount)
* GetPublicStaticMethod(string name, params Type[] parameterTypes)
* GetPublicInstanceMethods()
* GetPublicInstanceMethod(string name)
* GetPublicInstanceMethod(string name, int parameterCount)
* GetPublicInstanceMethod(string name, params Type[] parameterTypes)
* GetNonPublicStaticMethods()
* GetNonPublicStaticMethod(string name)
* GetNonPublicStaticMethod(string name, int parameterCount)
* GetNonPublicStaticMethod(string name, params Type[] parameterTypes)
* GetNonPublicInstanceMethods()
* GetNonPublicInstanceMethod(string name)
* GetNonPublicInstanceMethod(string name, int parameterCount)
* GetNonPublicInstanceMethod(string name, params Type[] parameterTypes)

### Member Retrieval:

* GetPublicStaticMembers()
* GetPublicStaticMembers(string name)
* GetPublicStaticMember(string name)
* GetPublicInstanceMembers()
* GetPublicInstanceMembers(string name)
* GetPublicInstanceMember(string name)
* GetNonPublicStaticMembers()
* GetNonPublicStaticMembers(string name)
* GetNonPublicStaticMember(string name)
* GetNonPublicInstanceMembers()
* GetNonPublicInstanceMembers(string name)
* GetNonPublicInstanceMember(string name)

### Misc

* ParameterInfo.IsParamsArray()
* PropertyInfo.IsPublic()
* PropertyInfo.IsStatic()

### Download

You can download and install using [the NuGet package](https://www.nuget.org/packages/AgileObjects.NetStandardPolyfills/), or clone the repository [on GitHub](https://github.com/agileobjects/NetStandardPolyfills).
