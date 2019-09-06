using Microsoft.AspNetCore.Mvc;
using MonteOlimpo.ApiBoot;
using MonteOlimpo.Domain.Models;
using MonteOlimpo.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MonteOlimpo.WebApi.Controllers
{
    [ApiController]
    public class GoodController : ApiBaseController
    {
        private readonly IGoodRepository deusRepository;

        public GoodController(IGoodRepository deusRepository)
        {
            this.deusRepository = deusRepository;
        }

        [HttpGet("ObterTodosOsDeusesDoMonteOlimpo")]
        public List<Good> ObterTodosOsDeusesDoMonteOlimpo()
        {
            return this.deusRepository.List().ToList();
        }

        [HttpPost("CriarNovoDeus")]
        public void CriarNovoDeusDoMonteOlimpo(Good deus)
        {
            this.deusRepository.Add(deus);
        }

        [HttpPut("ModificarDeusDoMonteOlimpo")]
        public void ModificarDeusDoMonteOlimpo(Good deus)
        {
            this.deusRepository.Update(deus);
        }
    }
}