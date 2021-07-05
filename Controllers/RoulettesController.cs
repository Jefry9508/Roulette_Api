using Roulette_Api.Models;
using Roulette_Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Roulette_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoulettesController : ControllerBase
    {
        private readonly RouletteService _rouletteService;
        public RoulettesController(RouletteService rouletteService)
        {
            _rouletteService = rouletteService;
        }
        [HttpGet]
        public ActionResult<List<Roulette>> Get() => 
            _rouletteService.Get();
        [HttpGet("{id:length(24)}", Name = "GetRoulette")]
        public ActionResult<Roulette> Get(string id)
        {
            var roulette = _rouletteService.Get(id: id);
            if (roulette == null)
            {
                return NotFound();
            }

            return roulette;
        }
        [HttpPost]
        public ActionResult<Roulette> Create(Roulette roulette)
        {
            _rouletteService.Create(roulette: roulette);

            return CreatedAtRoute("GetRoulette", new { id = roulette.Id.ToString() }, roulette);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Roulette roulette)
        {
            var book = _rouletteService.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            _rouletteService.Update(id, roulette);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var roulette = _rouletteService.Get(id);

            if (roulette == null)
            {
                return NotFound();
            }

            _rouletteService.Remove(roulette.Id);

            return NoContent();
        }
    }
}