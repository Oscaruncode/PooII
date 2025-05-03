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

        [HttpGet("Actuales")]
        public async Task<IActionResult> GetUbicacionesActuales()
        {
            var actuales = _ubicacionServices.UbicacionesActuales();

            return Ok(actuales);
        }

        [HttpGet("historial/{personaID}")]
        public async Task<IActionResult> HistorialPersona(int personaID)
        {
            var historial = _ubicacionServices.HistorialPersona(personaID);

            if (historial == null || !historial.Any())
            {
                return NotFound("No se encontró historial para esta persona.");
            }

            return Ok(historial);
        }

        [HttpPost]
        public async Task<IActionResult> AddUbicacion([FromBody] UbicacionRequestDTO request)
        {
            if (request == null || string.IsNullOrEmpty(request.Direccion))
            {
                return BadRequest("La direccion es requerida");
            }

            var (success, message, ubicacion) = await _ubicacionServices.AddUbicacionAsync(request.PersonaId, request.Direccion);

            if (!success) return BadRequest(message);

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
