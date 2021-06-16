namespace AgileObjects.NetStandardPolyfills
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Extensions;

    /// <summary>
    /// Provides a set of static methods for obtaining operator information in .NET Standard 1.0+ and .NET 3.5+.
    /// </summary>
    public static class OperatorExtensionsPolyfill
    {
        private const string _implicitOperatorName = "op_Implicit";
        private const string _explicitOperatorName = "op_Explicit";

        /// <summary>
        /// Returns a value indicating whether this <paramref name="method"/> is an implicit operator.
        /// </summary>
        /// <param name="method">The method for which to make the determination.</param>
        /// <returns>True if this <paramref name="method"/> is an implicit operator, otherwise false.</returns>
        public static bool IsImplicitOperator(this MethodInfo method)
            => method.IsSpecialName && method.IsStatic && (method.Name == _implicitOperatorName);

        /// <summary>
        /// Returns a value indicating whether this <paramref name="method"/> is an explicit operator.
        /// </summary>
        /// <param name="method">The method for which to make the determination.</param>
        /// <returns>True if this <paramref name="method"/> is an explicit operator, otherwise false.</returns>
        public static bool IsExplicitOperator(this MethodInfo method)
            => method.IsSpecialName && method.IsStatic && (method.Name == _explicitOperatorName);

        /// <summary>
        /// Gets this <paramref name="type" />'s implicit and explicit operators, optionally of the
        /// type specified by the given <paramref name="matcher"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the operators.</param>
        /// <param name="matcher">An action specifying the type of implicit operator to retrieve.</param>
        /// <returns>This <paramref name="type" />'s implicit and explicit operators.</returns>
        public static IEnumerable<MethodInfo> GetOperators(this Type type, Action<OperatorSelector> matcher = null)
        {
            var operators = type
                .GetPublicStaticMembers()
                .Filter(m => (m.Name == _implicitOperatorName) || (m.Name == _explicitOperatorName))
                .OfType<MethodInfo>();

            if (matcher == null)
            {
                return operators;
            }

            var selector = new OperatorSelector();

            matcher.Invoke(selector);

            return operators.Filter(selector.Matches);
        }

        /// <summary>
        /// Gets this <paramref name="type" />'s implicit operators.
        /// </summary>
        /// <param name="type">The type from which to retrieve the operators.</param>
        /// <returns>This <paramref name="type" />'s implicit operators.</returns>
        public static IEnumerable<MethodInfo> GetImplicitOperators(this Type type)
        {
            return type
                .GetPublicStaticMembers(_implicitOperatorName)
                .OfType<MethodInfo>();
        }

        /// <summary>
        /// Gets this <paramref name="type" />'s implicit operator of the type specified by the given 
        /// <paramref name="matcher"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the operator.</param>
        /// <param name="matcher">An action specifying the type of implicit operator to retrieve.</param>
        /// <returns>
        /// This <paramref name="type" />'s implicit operator of the type specified by the given 
        /// <paramref name="matcher"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetImplicitOperator(this Type type, Action<OperatorSelector> matcher)
        {
            var selector = new OperatorSelector();

            matcher?.Invoke(selector);

            return type.GetImplicitOperators().FirstOrDefault(selector.Matches);
        }

        /// <summary>
        /// Gets this <paramref name="type" />'s explicit operators.
        /// </summary>
        /// <param name="type">The type from which to retrieve the operators.</param>
        /// <returns>This <paramref name="type" />'s explicit operators.</returns>
        public static IEnumerable<MethodInfo> GetExplicitOperators(this Type type)
        {
            return type
                .GetPublicStaticMembers(_explicitOperatorName)
                .OfType<MethodInfo>();
        }

        /// <summary>
        /// Gets this <paramref name="type" />'s explicit operator of the type specified by the given 
        /// <paramref name="matcher"/>.
        /// </summary>
        /// <param name="type">The type from which to retrieve the operator.</param>
        /// <param name="matcher">An action specifying the type of explicit operator to retrieve.</param>
        /// <returns>
        /// This <paramref name="type" />'s explicit operator of the type specified by the given 
        /// <paramref name="matcher"/>, or null if none exists.
        /// </returns>
        public static MethodInfo GetExplicitOperator(this Type type, Action<OperatorSelector> matcher)
        {
            var selector = new OperatorSelector();

            matcher?.Invoke(selector);

            return type.GetExplicitOperators().FirstOrDefault(selector.Matches);
        }

        #region Helper Class

        /// <summary>
        /// Provides options for selecting a particular operator.
        /// </summary>
        public class OperatorSelector
        {
            private Type _fromType;
            private Type _toType;

            internal OperatorSelector()
            {
            }

            /// <summary>
            /// Select the operator which converts the given <typeparamref name="TInput">type</typeparamref>
            /// to the type in question.
            /// </summary>
            /// <typeparam name="TInput">The input type of the operator to select.</typeparam>
            public void From<TInput>() => _fromType = typeof(TInput);

            /// <summary>
            /// Select the operator which converts the type in question to the given 
            /// <typeparamref name="TReturn">return type</typeparamref>.
            /// </summary>
            /// <typeparam name="TReturn">The output type of the operator to select.</typeparam>
            public void To<TReturn>() => _toType = typeof(TReturn);

            internal bool Matches(MethodInfo @operator)
            {
                if (_toType != null)
                {
                    return @operator.ReturnType == _toType;
                }

                if (_fromType != null)
                {
                    return @operator.GetParameters()[0].ParameterType == _fromType;
                }

                throw new InvalidOperationException("No operator From or To type specified.");
            }
        }

        #endregion
    }
}
