namespace AgileObjects.NetStandardPolyfills
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

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
        public static Type[] GetTypes(this Assembly assembly)
        {
#if NET_STANDARD
            return assembly.DefinedTypes.Select(ti => ti.AsType()).ToArray();
#else
            return assembly.GetTypes();
#endif
        }
    }
}
