using ChemQuizWeb.Core.Interfaces.Services;
using ChemQuizWeb.Models.ViewModels;
using ChemQuizWeb.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ChemQuizWeb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private IGameService gameService;

        public GameController(IGameService _gameService)
        {
            gameService = _gameService;
        }

        [HttpGet]
        [Route("search/{value}/{categoryid}")]
        [ProducesResponseType(typeof(List<GameViewModel>), StatusCodes.Status200OK)]
        public IActionResult Get(string value, long? categoryid) 
        {
            var games = from game in gameService.FindByParameters(value, categoryid)
                                        select new GameViewModel(game);
            return Ok(games.ToList());
        } 
    }
}
