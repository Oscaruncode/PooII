using PooII.DTOs;
using PooII.Entities;

namespace PooII.Interfaces
{
    public interface IPersonaService
    {
        (Usuario Usuario, string password) CrearPersona(PersonaDTO usuarioRegisterDTO);
        IEnumerable<PersonaDTO> ObtenerPersonas();

        PersonaDTO? PersonaPorID(int id);
        PersonaDTO? PersonaPorIdentificacion(string identificacion);
        IEnumerable<PersonaDTO> PersonaPorEdad(int edad);
        IEnumerable<PersonaDTO> PersonaPorPNombre(string pNombre);
        IEnumerable<PersonaDTO> PersonaPorApellido(string pApellido);


        bool ActualizarPersona(Persona persona);
        bool EliminarPersona(int id);
        bool CambiarPassword(int personaId, string newPasswrod);
       // UsuarioDTO GetUserDetails(int personid);


        string GenerarLogin(Persona persona);
        string GenerarPassword();
        (Usuario usuario, string password) GenerarUsuario(Persona persona);
        string GenerarApiKey();
    }
}
