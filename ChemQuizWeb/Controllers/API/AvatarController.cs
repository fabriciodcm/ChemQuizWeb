using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChemQuizWeb.Data;
using ChemQuizWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChemQuizWeb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvatarController : Controller
    {

        private IService<Avatar> avatarService;

        public AvatarController(IService<Avatar> _avatarService)
        {
            avatarService = _avatarService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<Avatar>), 200)]
        public IActionResult Get() => Ok(avatarService.FindAll());


        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Avatar), 200)]
        public IActionResult Get(long id)
        {
            var avatar = avatarService.FindByID(id);
            if (avatar == null) return NotFound();
            return Ok(avatar);
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Avatar avatar)
        {
            if (avatar == null) return BadRequest();
            return new ObjectResult(avatarService.Create(avatar));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put([FromBody] Avatar avatar)
        {
            if (avatar == null) return BadRequest();//corpo do ooj vazio
            var updatedAvatar = avatarService.Update(avatar);
            if (updatedAvatar == null) return BadRequest();//obj nao existe no banco de dados
            return new ObjectResult(updatedAvatar);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(long id)
        {
            avatarService.Delete(id);
            return NoContent();
        }
    }
}
