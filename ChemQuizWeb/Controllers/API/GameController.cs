using ChemQuizWeb.Data;
using ChemQuizWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [ProducesResponseType(typeof(List<Game>), StatusCodes.Status200OK)]
        public IActionResult Get(string value, long? categoryid) 
        {
            return Ok(gameService.FindByParameters(value,categoryid));
        } 
    }
}
