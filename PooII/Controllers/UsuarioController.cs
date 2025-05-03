using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PooII.Interfaces;

namespace PooII.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cambiarpassword/{id}")]
        public IActionResult CambiarPassword(int id, [FromBody] string newPassword)
        {
            if (id <= 0)
            {
                return BadRequest("El ID del usuario debe ser un número positivo.");
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                return BadRequest("La nueva contraseña es obligatoria");
            }

            var result = _usuarioService.CambiarPassword(id, newPassword);

            if (!result)
            {
                return NotFound("No se pudo cambiar la contraseña. Usuario no encontrado o error interno.");
            }

            return NoContent(); // 204: Operación exitosa, sin contenido
        }

        [HttpGet("{id}")] 
        public IActionResult GetUsuario(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID del usuario debe ser un número positivo.");
            }

            var usuario = _usuarioService.ObtenerPorId(id);

            if (usuario == null)
            {
                return NotFound($"No se encontró un usuario con ID {id}.");
            }

            return Ok(usuario); 
        }


    }
}
