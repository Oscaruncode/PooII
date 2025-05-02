using PooII.Entities;

namespace PooII.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario getUsuario(string login, Persona persona);
        Usuario findByUsername(string login);
        Usuario findByUsernameANDAPIKey(string login, string APIKey);
    }
}