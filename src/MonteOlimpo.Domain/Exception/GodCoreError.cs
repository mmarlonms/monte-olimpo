using MonteOlimpo.Base.CoreException;

namespace MonteOlimpo.Domain.Exception
{
    public class GodCoreError : CoreError
    {
        protected GodCoreError(string key, string message) : base(key, message)
        {
        }

        public static readonly GodCoreError SampleError = new GodCoreError("SampleError", "Exemplo de Core Error");
    }
}