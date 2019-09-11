using Microsoft.AspNetCore.Mvc;
using MonteOlimpo.Base.ApiBoot;
using MonteOlimpo.Domain.Models;
using MonteOlimpo.Domain.Repository;
using MonteOlimpo.Domain.Specifications;
using System.Collections.Generic;
using System.Linq;

namespace MonteOlimpo.WebApi.Controllers
{
    [ApiController]
    public class GodController : ApiBaseController
    {
        private readonly IGodRepository godRepository;

        public GodController(IGodRepository godRepository)
        {
            this.godRepository = godRepository;
        }

        [HttpGet("GetAllGods")]
        public List<God> GetAllGods()
        {
            return this.godRepository.List().ToList();
        }


        [HttpGet("GetGod/{id}")]
        public God GetGod(int id)
        {
            return this.godRepository.GetById(id);
        }

        [HttpPost("CreateGod")]
        public void CreateGod(God deus)
        {
            this.godRepository.Add(deus);
        }

        [HttpPut("UpdateGod")]
        public void UpdateGord(God deus)
        {
            this.godRepository.Update(deus);
        }

        /// <summary>
        ///     Specification Sample
        /// </summary>
        /// <returns></returns>
        [HttpGet("GodWhithMoreTemYeas")]
        public List<God> GodWhithMoreTemYeas()
        {
            return this.godRepository.ListBySpecfication(GodSpecification.GodWithMoreTenYears).ToList();
        }

        /// <summary>
        ///     Specification Sample with AND
        /// </summary>
        /// <returns></returns>
        [HttpGet("GodWhithMoreTemYeasAndPairAge")]
        public List<God> GodWhithMoreTemYeasAndPairAge()
        {
            return this.godRepository.ListBySpecfication(GodSpecification.GodWithMoreTenYears.And(GodSpecification.GodWithPairAge)).ToList();
        }

        /// <summary>
        ///     Specification Sample with OR
        /// </summary>
        /// <returns></returns>
        [HttpGet("GodWhithMoreTemYeasOrGodWithNameMercury")]
        public List<God> GodWhithMoreTemYeasOrPairAge()
        {
            return this.godRepository.ListBySpecfication(GodSpecification.GodWithMoreTenYears.Or(GodSpecification.GodWithNameMercury)).ToList();
        }

        /// <summary>
        ///     Specification Sample with AND and OR
        /// </summary>
        /// <returns></returns>
        [HttpGet("GodWhithMoreTemYeasAndPairAgeOrGodWithNameMercury")]
        public List<God> GodWhithMoreTemYeasAndPairAgeOrGodWithNameMercury()
        {
            return this.godRepository.ListBySpecfication(((GodSpecification.GodWithMoreTenYears.And(GodSpecification.GodWithPairAge)).Or(GodSpecification.GodWithNameMercury))).ToList();
        }

    }
}