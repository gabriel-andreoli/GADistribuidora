using GADistribuidora.Domain.Entities;
using GADistribuidora.Domain.Services.Interfaces;
using GADistribuidora.Presentation.Commands;
using GADistribuidora.Presentation.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace GADistribuidora.Presentation.Controllers
{
    [Route("api/v1/authenticate")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public AuthenticateController(IAuthenticateService authenticateService, IConfiguration configuration, IUserService userService)
        {
            _authenticateService = authenticateService;
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult> RegisterUser(RegisterUserCommand command)
        {
            List<string> isValidCredentials = command.VerifyCredentials();
            if (isValidCredentials.Any())
                return BadRequest(isValidCredentials.First());
            await _authenticateService.RegisterUser(command);
            return Created("", "Usuário criado com sucesso");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginCommand command) 
        {
            var isValidUser = await _authenticateService.Authenticate(command.Email, command.Password);
            if (isValidUser)
                return Ok(await GenerateToken(command));
            else
                return BadRequest("Login ou senha inválidos");
        }

        private async Task<UserTokenDTO> GenerateToken(LoginCommand command)
        {
            var user = await _userService.GetByEmail(command.Email);
            if (user == null)
                throw new ArgumentException("Usuário não existente, verifique os dados e tente novamente");

            var claims = new[] 
            {
                new Claim("email", command.Email),
                new Claim("role", ((int)user.Role).ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(120);

            JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _configuration["JTW:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    claims: claims,
                    expires: expiration,
                    signingCredentials: creds);

            return new UserTokenDTO() 
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
