using Microsoft.AspNetCore.Mvc;
using MonteOlimpo.Base.ApiBoot;
using MonteOlimpo.Domain.Models;
using MonteOlimpo.Domain.Service;
using System.Collections.Generic;
using System.Linq;

namespace MonteOlimpo.WebApi.Controllers
{
    [ApiController]
    public class GodController : ApiBaseController
    {
        private readonly IGodService godService;

        public GodController(IGodService godService)
        {
            this.godService = godService;
        }

        [HttpGet("GetAllGods")]
        public List<God> GetAllGods()
        {
            return this.godService.GetAll().ToList();
        }

        [HttpGet("GetGod/{id}")]
        public God GetGod(int id)
        {
            return this.godService.GetByID(id);
        }

        [HttpPost("CreateGod")]
        public void CreateGod(God deus)
        {
            this.godService.Create(deus);
        }

        [HttpPut("UpdateGod")]
        public void UpdateGord(God deus)
        {
            this.godService.Update(deus);
        }

        [HttpDelete("DelteGod")]
        public void DelteGod(int id)
        {
            this.godService.Delete(id);
        }

        /// <summary>
        ///     Specification Sample
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListGodsWithMoreTemYears")]
        public List<God> ListGodsWithMoreTemYears()
        {
            return this.godService.ListGodsWithMoreTemYears().ToList();
        }

        /// <summary>
        ///     Specification Sample with AND
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListGodsWithMoreTemYearsAndPairAge")]
        public List<God> ListGodsWithMoreTemYearsAndPairAge()
        {
            return this.godService.ListGodsWithMoreTemYearsAndPairAge().ToList();
        }

        /// <summary>
        ///     Specification Sample with OR
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListGodsWithMoreTemYearsOrGodWithNameMercury")]
        public List<God> ListGodsWithMoreTemYearsOrGodWithNameMercury()
        {
            return this.godService.ListGodsWithMoreTemYearsOrGodWithNameMercury().ToList();
        }

        /// <summary>
        ///     Specification Sample with AND and OR
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListGodsWithMoreTemYearsAndPairAgeOrGodWithNameMercury")]
        public List<God> ListGodsWithMoreTemYearsAndPairAgeOrGodWithNameMercury()
        {
            return this.godService.ListGodsWithMoreTemYearsAndPairAgeOrGodWithNameMercury().ToList();
        }
    }
}