using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PooII.Interfaces;

namespace PooII.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {
        //private IPersonaService personaService;
        //public class PersonaController(IPersonaService personaService)
        //{
        //    _personaService = personaService;
        //}

        [HttpPost]
        public IActionResult CrearPersona()
        {
            throw new NotImplementedException();

            //var (user, password) = _personService.CrearPersona(persona);
            //return Ok;
        }

        [HttpGet]
        public IActionResult ObtenerPersonas()
        {
            throw new NotImplementedException();

            //var persons = _personService.ObtenerPersonas();
            //return Ok(persons);
        }

        [HttpGet("{id}"), Authorize]
        public IActionResult ObtenerPersona(int id)
        {
            throw new NotImplementedException();

            //var person = _personService.PersonaPorID(id);
            //return Ok(person);
        }

        [HttpGet("por-identication/{identifacion}")]
        public IActionResult ObtenerPorIdentificacion(string identifacion)
        {
            throw new NotImplementedException();

            // var person = _personService.PersonaPorIdentificacion(identifacion);

            //  return Ok(person);
        }

        [HttpGet("por-edad/{edad}")]
        public IActionResult ObtenerPorEdad(int edad)
        {
            throw new NotImplementedException();

            //    var persons = _personService.PersonaPorEdad(edad);
            //    return Ok(persons);
        }

        [HttpGet("por-Pnombre/{nombre}")]
        public IActionResult ObtenerPorNombre(string nombre)
        {
            throw new NotImplementedException();
            //   var persons = _personService.PersonaPorPNombre(nombre);
            // return Ok(persona);
        }

        [HttpGet("por-Papellido/{apellido}")]
        public IActionResult obtenerPorApellido(string apellido)
        {
            throw new NotImplementedException();
            // var persons = _personService.PersonaPorApellido(apellido);
            //return persona
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarPersona( )
        {
            throw new NotImplementedException();
            //var result = _personService.ActualizarPersona(person);
           // return persona;
        }

        [HttpDelete("{id}")]
        public IActionResult BorrarPersona(int id)
        {
            //var result = _personService.EliminarPersona(id);
            throw new NotImplementedException("");
        }

        [HttpPost("cambiar-password/{id}")]
        public IActionResult CambiarPassword(int id, [FromBody] string newPassword)
        {
            //  var result = _personService.CambiarPassword(id, newPassword);
            // return ok
            throw new NotImplementedException();
        }


    }
}
