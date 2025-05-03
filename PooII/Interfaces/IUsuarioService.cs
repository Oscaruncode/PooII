using Azure;
using PooII.DTOs;
using PooII.Entities;

namespace PooII.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioDTO ObtenerPorId(int id);
        bool CambiarPassword(int personaId, string newPasswrod);
        UsuarioDTO? ObtenerPorUsuarioPassword(string login, string password);
        Usuario GenerarUsuario(Persona persona);
        bool ValidateApiKey(string login, string apiKey);
    }
}










// UsuarioDTO GetUserDetails(int personid);

//  bool eliminar(UsuarioPK id);
//List<Usuario> consultarUsuario(Pageable pageable);
// Usuario getUsuarioById(UsuarioPK id);

//string GenerarLogin(Persona persona);
//string GenerarPassword();
//string GenerarApiKey();