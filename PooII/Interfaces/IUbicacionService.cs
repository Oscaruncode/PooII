using PooII.Entities;

namespace PooII.Interfaces
{
    public interface IUbicacionServices
    {
        Task<(bool success, string messages, Ubicacion Ubicacion)> AddUbicacionAsync(int personaId, string direccion);
    }
}