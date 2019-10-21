using MonteOlimpo.Base.CoreException;

namespace MonteOlimpo.Domain.Exception
{
    public class GodCoreException : CoreException<GodCoreError>
    {
        public GodCoreException() : base()
        {

        }

        public GodCoreException(params GodCoreError[] errors)
        {
            AddError(errors);
        }

        public override string Key => "GodCoreException";
    }
}