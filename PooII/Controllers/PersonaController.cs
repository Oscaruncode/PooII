using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PooII.DTOs;
using PooII.Entities;
using PooII.Interfaces;

namespace PooII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpPost("persona")]
        [Authorize]
        public ActionResult AgregarPersona([FromBody] PersonaDTO persona)
        {
            if (persona == null)
                return BadRequest("La información de la persona es obligatoria.");

            if (string.IsNullOrWhiteSpace(persona.PNombre))
                return BadRequest("El nombre es obligatorio.");

            var creada = _personaService.CrearPersona(persona);

            if (!creada)
                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo crear la persona debido a un error interno.");

            return Ok(persona.Id); // 200: operación exitosa
        }

        [Authorize]
        [HttpPut("persona")]
        public ActionResult EditarPersona([FromBody] PersonaDTO persona)
        {
            if (persona == null || persona.Id <= 0)
                return BadRequest("Datos de persona inválidos.");

            var actualizado = _personaService.ActualizarPersona(persona);

            if (!actualizado)
                return NotFound($"No se pudo actualizar. Persona con ID {persona.Id} no encontrada.");

            return NoContent(); // 204: operación exitosa sin contenido
        }

        [Authorize]
        [HttpDelete("persona/{id:int}")]
        public ActionResult EliminarPersona(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser un número positivo.");

            var eliminado = _personaService.EliminarPersona(id);

            if (!eliminado)
                return NotFound($"No se pudo eliminar. Persona con ID {id} no encontrada.");

            return NoContent();
        }

        [HttpGet("personas")]
        public ActionResult<ICollection<PersonaDTO>> ListadoPersona()
        {
            var personas = _personaService.ObtenerPersonas();

            if (personas == null || !personas.Any())
                return NoContent(); // 204: no hay datos

            return Ok(personas); // 200
        }

        // ========== MÉTODOS DE BÚSQUEDA ==========
        [Authorize]
        [HttpGet("id/{id:int}")]
        public ActionResult<Persona> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser un número positivo.");

            var persona = _personaService.PersonaPorID(id);

            if (persona == null)
                return NotFound($"No se encontró una persona con ID {id}.");

            return Ok(persona);
        }

        [Authorize]
        [HttpGet("identificacion/{identificacion}")]
        public ActionResult<Persona> GetByIdentificacion(string identificacion)
        {
            if (string.IsNullOrWhiteSpace(identificacion))
                return BadRequest("La identificación es obligatoria.");

            var persona = _personaService.PersonaPorIdentificacion(identificacion);

            if (persona == null)
                return NotFound($"No se encontró una persona con identificación '{identificacion}'.");

            return Ok(persona);
        }

        [Authorize]
        [HttpGet("pnombre/{pnombre}")]
        public ActionResult<List<Persona>> GetByPNombre(string pnombre)
        {
            if (string.IsNullOrWhiteSpace(pnombre))
                return BadRequest("El primer nombre es obligatorio.");

            var personas = _personaService.PersonaPorPNombre(pnombre);

            if (personas == null || !personas.Any())
                return NotFound($"No se encontraron personas con primer nombre '{pnombre}'.");

            return Ok(personas);
        }

        [Authorize]
        [HttpGet("edad/{edad:int}")]
        public ActionResult<List<Persona>> GetByEdad(int edad)
        {
            if (edad <= 0)
                return BadRequest("La edad debe ser un número positivo.");

            var personas = _personaService.PersonaPorEdad(edad);

            if (personas == null || !personas.Any())
                return NotFound($"No se encontraron personas con edad {edad}.");

            return Ok(personas);
        }

    }
}