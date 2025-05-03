using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PooII.DTOs;
using PooII.Interfaces;

namespace PooII.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UbicacionesController : ControllerBase
    {
        private readonly IGeocodingService _geocodingServices;
        private readonly IUbicacionServices _ubicacionServices;

        public UbicacionesController(IGeocodingService geocodingService, IUbicacionServices ubicacionServices)
        {
            _geocodingServices = geocodingService;
            _ubicacionServices = ubicacionServices;
        }

        /// <summary>
        /// Obtiene todas las ubicaciones actuales registradas.
        /// </summary>
        [HttpGet("Actuales")]
        public async Task<IActionResult> GetUbicacionesActuales()
        {
            var actuales = _ubicacionServices.UbicacionesActuales();

            if (actuales == null || !actuales.Any())
            {
                return NoContent(); // 204 si no hay datos
            }

            return Ok(actuales); // 200 con datos
        }

        /// <summary>
        /// Obtiene el historial de ubicaciones de una persona por su ID.
        /// </summary>
        [HttpGet("historial/{personaID}")]
        public async Task<IActionResult> HistorialPersona(int personaID)
        {
            if (personaID <= 0)
            {
                return BadRequest("El ID de la persona debe ser un valor positivo.");
            }

            var historial = _ubicacionServices.HistorialPersona(personaID);

            if (historial == null || !historial.Any())
            {
                return NotFound("No se encontró historial para esta persona."); // 404
            }

            return Ok(historial); // 200
        }

        [HttpPost]
        public async Task<IActionResult> AddUbicacion([FromBody] UbicacionRequestDTO request)
        {
            if (request == null)
            {
                return BadRequest("La solicitud es inválida."); // 400
            }

            if (string.IsNullOrWhiteSpace(request.Direccion))
            {
                return BadRequest("La dirección es requerida."); // 400
            }

            if (request.PersonaId <= 0)
            {
                return BadRequest("El ID de la persona debe ser un valor positivo."); // 400
            }

            var (success, message, ubicacion) = await _ubicacionServices.AddUbicacionAsync(request.PersonaId, request.Direccion);

            if (!success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message); // 500 si algo salió mal internamente
            }

            var response = new
            {
                Id = ubicacion.Id,
                Direccion = ubicacion.Direccion,
                Latitud = ubicacion.Latitud,
                Longitud = ubicacion.Longitud,
                Fecha = ubicacion.Fecha
            };

            return Ok(response);
        }
    }
}
