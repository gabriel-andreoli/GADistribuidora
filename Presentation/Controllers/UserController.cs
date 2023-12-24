using GADistribuidora.Domain.Repositories.Interfaces;
using GADistribuidora.Domain.Services.Interfaces;
using GADistribuidora.Presentation.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GADistribuidora.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(Guid id) 
        {
            var user = await _userService.GetByIdAsync(x => x.Id == id);
            if (user == null)
                return BadRequest("O usuário não existe ou foi excluído");
            else
                return Ok(user);
        }
    }
}
