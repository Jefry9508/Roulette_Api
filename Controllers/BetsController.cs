using System;
using System.Collections.Generic;
using Roulette_Api.Models;
using Roulette_Api.Services;
using Microsoft.AspNetCore.Mvc;
namespace Roulette_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetsController : ControllerBase
    {
        private readonly BetService _betService;
        private readonly RouletteService _rouletteService;
        public enum BetColor
        {
            Red,
            Black
        }
        public enum BetType{
            number,
            color
        }
        public BetsController(BetService betService, RouletteService roulettesService)
        {
            _betService = betService;
            _rouletteService = roulettesService;
        }
        [HttpPost]
        public ActionResult<object> Create(Bet bet)
        {
            var header = Request.Headers;
            if (!header.ContainsKey(key: "user_id"))
            {
                return Unauthorized(new {message = "No se ha realizado la autenticación de usuario"});
            }
            var roullete = _rouletteService.Get(id: bet.rouletteId);
            if (roullete == null)
            {
                return NotFound(new {message = "La rouletta en la que desea apostar no existe"});
            }
            if (!roullete.state)
            {
                return Ok(new {message = "La ruleta aún no está disponible para apostar."});
            }
            if (bet.type == ((int)BetType.color) && bet.target != ((int)BetColor.Red) && bet.target != ((int)BetColor.Black))
            {
                return BadRequest(new {message = "Color apostado inválido."});
            }
            bet.gameId = roullete.currentGameId;
            bet.userId = header["user_id"];
            bet.date = DateTime.UtcNow;
            _betService.Create(bet: bet);

            return Ok();
        }
    }
}