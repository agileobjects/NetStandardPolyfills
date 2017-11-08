namespace AgileObjects.NetStandardPolyfills.UnitTests
{
    using System;

    internal static class Should
    {
        public static TException Throw<TException>(Action testAction)
            where TException : Exception
        {
            try
            {
                testAction.Invoke();
            }
            catch (TException ex)
            {
                return ex;
            }

            throw new Exception("Expected exception of type " + typeof(TException).Name);
        }
    }
}