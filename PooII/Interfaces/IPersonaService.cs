using PooII.DTOs;
using PooII.Entities;

namespace PooII.Interfaces
{
    public interface IPersonaService
    {
        bool CrearPersona(PersonaDTO usuarioRegisterDTO);
        ICollection<PersonaDTO> ObtenerPersonas();

        PersonaDTO? PersonaPorID(int id);
        PersonaDTO? PersonaPorIdentificacion(string identificacion);
        IEnumerable<PersonaDTO> PersonaPorEdad(int edad);
        IEnumerable<PersonaDTO> PersonaPorPNombre(string pNombre);
        IEnumerable<PersonaDTO> PersonaPorApellido(string pApellido);


        bool ActualizarPersona(Persona persona);
        bool EliminarPersona(int id);
        bool CambiarPassword(int personaId, string newPasswrod);
    }
}
