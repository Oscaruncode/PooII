using PooII.Entities;

namespace PooII.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario? ObtenerPorId(int personaId);
        //public Usuario? FindByUsername(string login);
        void Actualizar(Usuario usuario);
        void GuardarCambios();
    }
}
