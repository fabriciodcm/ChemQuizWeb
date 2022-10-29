using ChemQuizWeb.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartiesController : ControllerBase
    {
        private readonly IPartyService _partyService;
        public PartiesController(IPartyService partyService)
        {
            _partyService = partyService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _partyService.GetParties();
            if(result.Any())
                return Ok(result);
            return NotFound();
        }
    }
}
