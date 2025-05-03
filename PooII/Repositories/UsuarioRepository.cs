using Microsoft.Extensions.Logging;
using PooII.Data;
using PooII.Entities;
using PooII.Interfaces;
using PooII.Repositories;

namespace PooII.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Context _context;

        public UsuarioRepository(Context context)
        {
            _context = context;
        }

        public Usuario? ObtenerPorId(int personaId)
        {
            return _context.Usuarios.FirstOrDefault(u => u.IdPersona == personaId);
        }

        public Usuario? ObtenerPorLoginPassword(string login, string password)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Login == login && u.Password == password);
        }

        public bool ValidarApiKey(string login, string apiKey)
        {
            return _context.Usuarios.Any(u => u.Login == login && u.ApiKey == apiKey);
        }

        //public Usuario? FindByUsername(string login)
        //{
        //    return _context.Usuarios.FirstOrDefault(u => u.Login == login);
        //}

        //public Usuario? GetUsuario(string login, Persona persona)
        //{
        //    return _context.Usuarios
        //        .Include(u => u.Persona)
        //        .FirstOrDefault(u => u.Login == login && u.IdPersona == persona.Id);
        //}

        public void Actualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public void GuardarCambios()
        {
            _context.SaveChanges();
        }
    }
}