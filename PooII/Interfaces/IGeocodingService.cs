using Newtonsoft.Json.Linq;
using PooII.Interfaces;

namespace PooII.Interfaces
{
    public interface IGeocodingService
    {
        Task<(double latitude, double longitude)> ObtenerCoordenadas(string direccion);
    }
}