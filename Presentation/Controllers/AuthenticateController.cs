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
    public class AuthenticateController
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IConfiguration _configuration;
        public AuthenticateController(IAuthenticateService authenticateService, IConfiguration configuration)
        {
            _authenticateService = authenticateService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand command)
        {
            List<string> isValidCredentials = command.VerifyCredentials();
            if (isValidCredentials.Any())
                return new BadRequestObjectResult(isValidCredentials.First());
            await _authenticateService.RegisterUser(command);
            return new OkObjectResult("Usuário criado com sucesso");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginCommand command) 
        {
            var isValidUser = await _authenticateService.Authenticate(command.Email, command.Password);
            if (isValidUser)
                return new ObjectResult(GenerateToken(command));
            else
                return new BadRequestObjectResult("Login ou senha inválidos");
        }

        private async Task<UserTokenDTO> GenerateToken(LoginCommand command)
        {
            var claims = new[] 
            {
                new Claim("email", command.Email),
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
