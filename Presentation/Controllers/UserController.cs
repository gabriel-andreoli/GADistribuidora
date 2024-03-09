using GADistribuidora.Domain.Repositories.Interfaces;
using GADistribuidora.Domain.Services.Interfaces;
using GADistribuidora.Presentation.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GADistribuidora.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : BaseApplicationController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        [Authorize]        
        public async Task<ActionResult<UserDTO>> GetById(Guid id) 
        {
            var user = await _userService.GetByIdAsync(id);
            return await CustomResponse(System.Net.HttpStatusCode.OK, user);
        }

        [HttpGet("")]
        public async Task<ActionResult<ICollection<UserDTO>>> GetAll() 
        {
            return Ok(_userService.GetAll());
        }
    }
}
