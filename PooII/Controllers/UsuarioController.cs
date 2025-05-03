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
            var result = _usuarioService.CambiarPassword(id, newPassword);
            return Ok(result);
        }

        [HttpGet("/{id}")]
        public IActionResult GetUsuario(int id)
        {
            var usuario = _usuarioService.ObtenerPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

    }
}
