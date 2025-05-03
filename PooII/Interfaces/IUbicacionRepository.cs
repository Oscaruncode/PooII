using Azure;
using PooII.Entities;

namespace PooII.Interfaces
{
    public interface IUbicacionRepository
    {
        ICollection<Ubicacion> consultarUbicaciones();
        Ubicacion getCoordenadasPorPersona(int id_persona);
        Task<Ubicacion?> ObtenerUltimaPorPersona(int personaId);
        Task AgregarAsync(Ubicacion ubicacion);
    }
}

//public abstract Page<Coordenadas> findAll(Pageable pageable);

//@Query("SELECT coord FROM COOR coord WHERE coord.persona = :id_persona ")

//    public abstract Coordenadas getCoordenadaXPersona(@Param("id_persona") int persona);