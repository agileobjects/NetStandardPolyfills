## .NET Standard Polyfills

[![NuGet](http://img.shields.io/nuget/v/AgileObjects.NetStandardPolyfills.svg)](https://www.nuget.org/packages/AgileObjects.NetStandardPolyfills)
[![Build status](https://ci.appveyor.com/api/projects/status/pjjjlotswo3330g7/branch/master?svg=true)](https://ci.appveyor.com/project/SteveWilkes/netstandardpolyfills/branch/master)

A set of Type and Reflection polyfill extension methods for .NET Standard v1.0 and .NET v4.0.

### Type Info:

* Type.IsAbstract()
* Type.IsAnonymous()
* Type.IsClass()
* Type.IsAssignableTo(Type type)
* Type.IsDerivedFrom(Type parentType)
* Type.IsEnum()
* Type.IsInterface()
* Type.IsGenericType()
* Type.IsPrimitive()
* Type.IsSealed()
* Type.IsValueType()
* Type.GetAttributes()
* Type.GetAssembly()
* Type.GetBaseType()
* Type.GetInterfaces()
* Type.GetGenericTypeArguments()
* Type.GetTypeCode()
* Type.HasAttribute&lt;TAttribute&gt;()

### Constructor Retrieval:

* Type.GetPublicInstanceConstructors()
* Type.GetPublicInstanceConstructor(params Type[] parameterTypes)
* Type.GetNonPublicInstanceConstructors()
* Type.GetNonPublicInstanceConstructor(params Type[] parameterTypes)

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

### Assembly Info:

* Assembly.GetAllTypes()

### Misc

* ParameterInfo.IsParamsArray()
* PropertyInfo.IsPublic()
* PropertyInfo.IsStatic()
* PropertyInfo.IsIndexer()
* PropertyInfo.GetAccessors(bool nonPublic)
* PropertyInfo.GetGetMethod(bool nonPublic)
* PropertyInfo.GetSetMethod(bool nonPublic)

### Download

You can download and install using [the NuGet package](https://www.nuget.org/packages/AgileObjects.NetStandardPolyfills/), or clone the repository [on GitHub](https://github.com/agileobjects/NetStandardPolyfills).
