using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PooII.Entities;
using PooII.Interfaces;
using PooII.JWT.Config;

namespace PooII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public AuthController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("/authenticate")]
        public IActionResult Authenticate([FromBody] JwtRequest request)
        {

            var user = _usuarioService.ObtenerPorUsuarioPassword(request.Username, request.Password);
            if (user == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Constants.GetSigningKey(Constants.SUPER_SECRET_KEY);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, "ROLE_USER")
                }),
                Expires = DateTime.UtcNow.AddMilliseconds(Constants.TOKEN_EXPIRATION_TIME),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string jwt = tokenHandler.WriteToken(token);

            return Ok(new JwtResponse("Bearer " + jwt));
        }
    }
}