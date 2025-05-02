using Azure;
using PooII.Entities;

namespace PooII.Interfaces
{
    public interface IUsuarioService
    {
        bool guardar(Usuario usuario);
        bool actualizar(Usuario usuario);
        bool eliminar(UsuarioPK id);
        List<Usuario> consultarUsuario(Pageable pageable);
        Usuario getUsuarioById(UsuarioPK id);

        // UsuarioDTO GetUserDetails(int personid);


        //string GenerarLogin(Persona persona);
        //string GenerarPassword();
        //(Usuario usuario, string password) GenerarUsuario(Persona persona);
        //string GenerarApiKey();
    }
}
