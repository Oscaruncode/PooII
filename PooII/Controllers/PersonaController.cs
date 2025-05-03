using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PooII.DTOs;
using PooII.Entities;
using PooII.Interfaces;

namespace PooII.Controllers
{
    [ApiController]
    [Route("[controller]")]
   // [Authorize]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpPost("persona")]
        public ActionResult<bool> AgregarPersona([FromBody] PersonaDTO persona)
        {
            return _personaService.CrearPersona(persona);
        }

        [HttpPut("persona")]
        public ActionResult<bool> EditarPersona([FromBody] PersonaDTO persona)
        {
            return _personaService.ActualizarPersona(persona);
        }

        [HttpDelete("persona/{id}")]
        public ActionResult<bool> EliminarPersona(int id)
        {
            return _personaService.EliminarPersona(id);
        }

        [HttpGet("personas")]
        public ActionResult<ICollection<PersonaDTO>> ListadoPersona()
        {
            return Ok(_personaService.ObtenerPersonas());
        }

        // ========== MÉTODOS DE BÚSQUEDA ==========

        [HttpGet("persona/id/{id}")]
        public ActionResult<Persona> GetById(int id)
        {
            return Ok(_personaService.PersonaPorID(id));
        }

        [HttpGet("persona/identificacion/{identificacion}")]
        public ActionResult<Persona> GetById(string identificacion)
        {
            return Ok(_personaService.PersonaPorIdentificacion(identificacion));
        }

        [HttpGet("persona/pnombre/{pnombre}")]
        public ActionResult<List<Persona>> GetByPNombre(string pnombre)
        {
            return Ok(_personaService.PersonaPorPNombre(pnombre));
        }

        [HttpGet("persona/edad/{edad}")]
        public ActionResult<List<Persona>> GetByEdad(int edad)
        {
            return Ok(_personaService.PersonaPorEdad(edad));
        }
    }
}