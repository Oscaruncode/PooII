using PooII.Entities;

namespace PooII.Interfaces
{
    public interface IUbicacionService
    {
        ICollection<Ubicacion> consultarUbicaciones();
    }
}

//List<Coordenadas> consultarAllCoordenadas(Pageable pageable);