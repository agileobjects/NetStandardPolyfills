namespace AgileObjects.NetStandardPolyfills
{
    using System;
#if NETSTANDARD1_0
    using System.Linq;
#endif
    using System.Reflection;
#if NETSTANDARD1_0
    using Extensions;
#endif

    /// <summary>
    /// Provides a set of static methods for obtaining Assembly information in .NET Standard 1.0+ and .NET 3.5+.
    /// </summary>
    public static class AssemblyExtensionsPolyfill
    {
        /// <summary>
        /// Gets the absolute path to this <paramref name="assembly"/>'s file on disk.
        /// </summary>
        /// <param name="assembly">The Assembly for which to retrieve the location.</param>
        /// <returns>
        /// The absolute path to this <paramref name="assembly"/>'s file on disk.
        /// </returns>
        public static string GetLocation(this Assembly assembly)
        {
#if NETSTANDARD1_0
            return assembly.GetType()
                .GetPublicInstanceProperty("Location")?
                .GetValue(assembly) as string;
#else
            return assembly.Location;
#endif
        }

        /// <summary>
        /// Gets the types defined in this <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The Assembly for which to retrieve the Types.</param>
        /// <returns>
        /// An array that contains all the types that are defined in this <paramref name="assembly"/>.
        /// </returns>
        public static Type[] GetAllTypes(this Assembly assembly)
        {
#if NETSTANDARD1_0
            return assembly.DefinedTypes.Project(ti => ti.AsType()).ToArray();
#else
            return assembly.GetTypes();
#endif
        }
    }
}
