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
            // Validación básica de la entrada
            if (request == null)
                return BadRequest("La solicitud no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("El nombre de usuario y la contraseña son obligatorios.");

            // Autenticación del usuario
            var user = _usuarioService.ObtenerPorUsuarioPassword(request.Username, request.Password);

            if (user == null)
                return Unauthorized("Nombre de usuario o contraseña inválidos."); // 401

            // Creación del token JWT
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

            // Respuesta 200 OK con el token
            return Ok(new JwtResponse("Bearer " + jwt));
        }

    }
}