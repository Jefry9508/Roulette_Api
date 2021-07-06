using System;
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
        private readonly WinnerService _winnerService;
        private readonly BetService _betService;
        public RoulettesController(RouletteService rouletteService, WinnerService winnerService, BetService betService)
        {
            _rouletteService = rouletteService;
            _winnerService = winnerService;
            _betService = betService;
        }
        [HttpGet]
        public ActionResult<List<Roulette>> Get() 
        {
            var rouletteList = _rouletteService.Get();
            var listResult = new List<object>();
            rouletteList.ForEach(roulette => 
                listResult.Add(new {id = roulette.Id,
                                    name = roulette.name,
                                    state = (roulette.state == true ? "Abierta": "Cerrada")}));

            return Ok(listResult);
        }    
        [HttpGet("{id:length(24)}", Name = "GetRoulette")]
        public ActionResult<Roulette> Get(string id)
        {
            var roulette = _rouletteService.Get(id: id);
            if (roulette == null)
            {
                return NotFound();
            }

            return Ok(new{id = roulette.Id,
                          name = roulette.name,
                          state = (roulette.state == true ? "Abierta": "Cerrada")});
        }
        [HttpPost]
        public ActionResult<object> Create(Roulette roulette)
        {
            roulette.creationDate = DateTime.UtcNow;    
            roulette.lastUpdate = DateTime.UtcNow;   
            roulette.state = false;
            _rouletteService.Create(roulette: roulette);
            return Ok(new {id = roulette.Id});
        }
        [HttpPut("opening/{id:length(24)}")]
        public IActionResult Opening(string id)
        {
            var rouletteFound = _rouletteService.Get(id);
            if (rouletteFound == null)
            {
                return NotFound();
            }
            if (rouletteFound.state == false)
            {
                rouletteFound.currentGameId = Guid.NewGuid().ToString();
                rouletteFound.state = true;
                rouletteFound.lastUpdate = DateTime.UtcNow;
            }else{
                return Ok(new{message = "La ruleta ya se encuentra disponible para apostar."});
            }
            _rouletteService.Update(id: id, rouletteIn: rouletteFound);

            return NoContent();
        }
        [HttpPut("closing/{id:length(24)}")]
        public IActionResult Closing(string id)
        {
            string gameId ;
            var rouletteFound = _rouletteService.Get(id: id);
            if (rouletteFound == null)
            {
                return NotFound();
            }
            if (rouletteFound.state == false)
            {
                return Ok(new{message = "La ruleta aún no se ha abierto"});
            }
            gameId = rouletteFound.currentGameId;
            rouletteFound.state = false;
            rouletteFound.currentGameId = null;
            rouletteFound.lastUpdate = DateTime.UtcNow;
            _rouletteService.Update(id: rouletteFound.Id, rouletteIn: rouletteFound);
            return Ok(FindWinners(gameId: gameId));
        }
        private int GenerateWinningNumber()
        {
            return new Random().Next(0, 36);
        }
        private List<Winner> FindWinners(string gameId)
        {
            List<Winner> winnersList = null;
            var winnigNumber = GenerateWinningNumber();
            var winningBets = _betService.FindWinningBets(gameId: gameId, winningNumber: winnigNumber);
            if (winningBets != null)
            {
                foreach (var bet in winningBets)
                {
                    CreateBetWinners(bet: bet, winningNumber: winnigNumber);
                }
                winnersList = _winnerService.GetByGameId(gameId: gameId);
            }
            return winnersList;
        }
        private void CreateBetWinners(Bet bet, int winningNumber)
        {
            var winner = new Winner();
            winner.rouletteId = bet.rouletteId;
            winner.userId = bet.userId;
            winner.gameId = bet.gameId;
            winner.betType = bet.type;
            winner.betTarget = bet.target;
            winner.winningNumber =  winningNumber;
            winner.earnedMoney = (bet.type == ((int)Roulette_Api.Controllers.BetsController.BetType.color) ? 
                (bet.money*(decimal)1.8) : (bet.money*5));
            winner.date = DateTime.UtcNow;
            _winnerService.Create(winner: winner);
        }
    }
}