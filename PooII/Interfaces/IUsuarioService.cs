using Azure;
using PooII.Entities;

namespace PooII.Interfaces
{
    public interface IUsuarioService
    {
        bool guardar(Usuario usuario);
        bool actualizar(Usuario usuario);

        bool CambiarPassword(int personaId, string newPasswrod);
        Usuario GenerarUsuario(Persona persona);
    }
}










// UsuarioDTO GetUserDetails(int personid);

//  bool eliminar(UsuarioPK id);
//List<Usuario> consultarUsuario(Pageable pageable);
// Usuario getUsuarioById(UsuarioPK id);

//string GenerarLogin(Persona persona);
//string GenerarPassword();
//string GenerarApiKey();