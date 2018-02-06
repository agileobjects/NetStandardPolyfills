namespace AgileObjects.NetStandardPolyfills
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides a set of static methods for obtaining operator information in .NET Standard 1.0 and .NET 4.0.
    /// </summary>
    public static class OperatorExtensionsPolyfill
    {
        private const string ImplicitOperatorName = "op_Implicit";
        private const string ExplicitOperatorName = "op_Explicit";

        /// <summary>
        /// Gets the <paramref name="type" />'s implicit and explicit operators.
        /// </summary>
        /// <param name="type">The type from which to retrieve the operators.</param>
        /// <returns>The <paramref name="type" />'s implicit and explicit operators.</returns>
        public static IEnumerable<MethodInfo> GetOperators(this Type type)
        {
            return type
                .GetPublicStaticMembers()
                .Where(m => (m.Name == ImplicitOperatorName) || (m.Name == ExplicitOperatorName))
                .OfType<MethodInfo>();
        }

        /// <summary>
        /// Gets the <paramref name="type" />'s implicit operators.
        /// </summary>
        /// <param name="type">The type from which to retrieve the operators.</param>
        /// <returns>The <paramref name="type" />'s implicit operators.</returns>
        public static IEnumerable<MethodInfo> GetImplicitOperators(this Type type)
        {
            return type
                .GetPublicStaticMembers(ImplicitOperatorName)
                .OfType<MethodInfo>();
        }

        /// <summary>
        /// Gets the <paramref name="type" />'s implicit operator with the given 
        /// <typeparamref name="TReturn">return type</typeparamref>.
        /// </summary>
        /// <typeparam name="TReturn">The return type of the implicit operator to retrieve.</typeparam>
        /// <param name="type">The type from which to retrieve the operator.</param>
        /// <returns>
        /// The <paramref name="type" />'s implicit operator with the given 
        /// <typeparamref name="TReturn">return type</typeparamref>, or null if none exists.
        /// </returns>
        public static MethodInfo GetImplicitOperator<TReturn>(this Type type)
        {
            return type.GetImplicitOperators()
                .FirstOrDefault(o => o.ReturnType == typeof(TReturn));
        }

        /// <summary>
        /// Gets the <paramref name="type" />'s explicit operators.
        /// </summary>
        /// <param name="type">The type from which to retrieve the operators.</param>
        /// <returns>The <paramref name="type" />'s explicit operators.</returns>
        public static IEnumerable<MethodInfo> GetExplicitOperators(this Type type)
        {
            return type
                .GetPublicStaticMembers(ExplicitOperatorName)
                .OfType<MethodInfo>();
        }

        /// <summary>
        /// Gets the <paramref name="type" />'s explicit operator with the given 
        /// <typeparamref name="TReturn">return type</typeparamref>.
        /// </summary>
        /// <typeparam name="TReturn">The return type of the explicit operator to retrieve.</typeparam>
        /// <param name="type">The type from which to retrieve the operator.</param>
        /// <returns>
        /// The <paramref name="type" />'s explicit operator with the given 
        /// <typeparamref name="TReturn">return type</typeparamref>, or null if none exists.
        /// </returns>
        public static MethodInfo GetExplicitOperator<TReturn>(this Type type)
        {
            return type.GetExplicitOperators()
                .FirstOrDefault(o => o.ReturnType == typeof(TReturn));
        }
    }
}
