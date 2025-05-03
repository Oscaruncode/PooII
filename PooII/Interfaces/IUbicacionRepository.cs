using Azure;
using PooII.DTOs;
using PooII.Entities;

namespace PooII.Interfaces
{
    public interface IUbicacionRepository
    {
        ICollection<Ubicacion> consultarUbicaciones();
        Ubicacion getCoordenadasPorPersona(int id_persona);
        Task<Ubicacion?> ObtenerUltimaPorPersona(int personaId);
        Task AgregarAsync(Ubicacion ubicacion);
        ICollection<UbicacionDTO>? UbicacionesActuales();
        ICollection<UbicacionDTO>? HistorialPersona(int personaId);

    }
}