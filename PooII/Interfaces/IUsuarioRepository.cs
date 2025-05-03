using PooII.Entities;

namespace PooII.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario? ObtenerPorId(int personaId);
        Usuario? ObtenerPorLoginPassword(string login, string password);
        void Actualizar(Usuario usuario);
        void GuardarCambios();
        bool ValidarApiKey(string login, string apiKey);

    }
}
