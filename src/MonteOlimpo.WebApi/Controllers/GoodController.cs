using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonteOlimpo.Base.ApiBoot;
using MonteOlimpo.Base.Core.Validations.ValidationsHelpers;
using MonteOlimpo.Domain.Exception;
using MonteOlimpo.Domain.Models;
using MonteOlimpo.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonteOlimpo.WebApi.Controllers
{
    [ApiController]
    public class GodController : ApiBaseController
    {
        private readonly IGodService godService;
        private readonly ILogger<GodController> logger;

        public GodController(IGodService godService, ILogger<GodController> logger)
        {
            this.godService = godService;
            this.logger = logger;
        }

        [HttpGet("GetAllGods")]
        public List<God> GetAllGods()
        {
            return this.godService.GetAll().ToList();
        }

        [Authorize]
        [HttpGet("GetGod/{id}")]
        public God GetGod(int id)
        {
            return this.godService.GetByID(id);
        }

        [HttpGet("GetCoreException")]
        public God GetCoreException()
        {
            throw new GodCoreException(GodCoreError.SampleError);
        }

        [HttpGet("GetException")]
        public God GetException()
        {
            throw new Exception("Sample");
        }

        [HttpPost("CreateGod")]
        public IActionResult CreateGod(God deus)
        {
            return Ok(this.godService.Create(deus));
        }

        [HttpPut("UpdateGod")]
        public void UpdateGord(God deus)
        {
            this.godService.Update(deus);
        }

        [Authorize(Roles = "admin")]
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