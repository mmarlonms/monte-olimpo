using MonteOlimpo.Base.Core.Service;
using MonteOlimpo.Domain.Models;
using MonteOlimpo.Domain.Repository;
using MonteOlimpo.Domain.Service;
using MonteOlimpo.Domain.Specifications;
using System.Collections.Generic;
using System.Linq;

namespace MonteOlimpo.Service
{
    public class GodService : BaseService<God>, IGodService
    {
        private readonly IGodRepository godRepository;

        public GodService(IGodRepository godRepository) 
            : base(godRepository)
        {
            this.godRepository = godRepository;
        }

        public IList<God> ListGodsWithMoreTemYears()
        {
            return this.godRepository.ListBySpecfication(GodSpecification.GodWithMoreTenYears).ToList();
        }

        public IList<God> ListGodsWithMoreTemYearsAndPairAge()
        {
            return this.godRepository.ListBySpecfication(GodSpecification.GodWithMoreTenYears.And(GodSpecification.GodWithPairAge)).ToList();
        }

        public IList<God> ListGodsWithMoreTemYearsOrGodWithNameMercury()
        {
            return this.godRepository.ListBySpecfication(GodSpecification.GodWithMoreTenYears.Or(GodSpecification.GodWithNameMercury)).ToList();
        }

        public IList<God> ListGodsWithMoreTemYearsAndPairAgeOrGodWithNameMercury()
        {
            return this.godRepository.ListBySpecfication(((GodSpecification.GodWithMoreTenYears.And(GodSpecification.GodWithPairAge)).Or(GodSpecification.GodWithNameMercury))).ToList();
        }
    }
}