using System.Collections.Generic;
using MonteOlimpo.Base.Core.Domain.Service;
using MonteOlimpo.Domain.Models;

namespace MonteOlimpo.Domain.Service
{
    public interface IGodService : IService<God>
    {
        IList<God> ListGodsWithMoreTemYears();
        IList<God> ListGodsWithMoreTemYearsAndPairAge();
        IList<God> ListGodsWithMoreTemYearsOrGodWithNameMercury();
        IList<God> ListGodsWithMoreTemYearsAndPairAgeOrGodWithNameMercury();
    }
}