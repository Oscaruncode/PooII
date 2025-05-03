using PooII.Entities;
using PooII.Interfaces;

namespace PooII.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuario findByUsername(string login)
        {
            throw new NotImplementedException();
        }

        public Usuario findByUsernameANDAPIKey(string login, string APIKey)
        {
            throw new NotImplementedException();
        }

        public Usuario getUsuario(string login, Persona persona)
        {
            throw new NotImplementedException();
        }
    }
}
