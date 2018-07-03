
namespace AgileObjects.NetStandardPolyfills
{
    using System;
#if NET_STANDARD
    using System.Linq;
#endif
    using System.Reflection;
    using Extensions;

    /// <summary>
    /// Provides a set of static methods for obtaining Assembly information in .NET Standard 1.0.
    /// </summary>
    public static class AssemblyExtensionsPolyfill
    {
        /// <summary>
        /// Gets the types defined in this <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The Assembly for which to retrieve the Types.</param>
        /// <returns>
        /// An array that contains all the types that are defined in this <paramref name="assembly"/>.
        /// </returns>
        public static Type[] GetAllTypes(this Assembly assembly)
        {
#if NET_STANDARD
            return assembly.DefinedTypes.Project(ti => ti.AsType()).ToArray();
#else
            return assembly.GetTypes();
#endif
        }
    }
}
