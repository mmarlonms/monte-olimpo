using MonteOlimpo.Base.Core.Specification;
using MonteOlimpo.Domain.Models;

namespace MonteOlimpo.Domain.Specifications
{
    public static class GodSpecification
    {
        public static readonly BaseSpecification<God> GodWithMoreTenYears =
            new BaseSpecification<God>(p => p.Idade > 10);

        public static readonly BaseSpecification<God> GodWithPairAge =
             new BaseSpecification<God>(p => p.Idade % 2 == 0);

        public static readonly BaseSpecification<God> GodWithNameMercury =
           new BaseSpecification<God>(p => p.Nome.Contains("Mercurio"));
    }
}