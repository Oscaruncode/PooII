using AutoMapper;
using PooII.DTOs;
using PooII.Entities;
using PooII.Interfaces;

namespace PooII.Services
{
    public class UbicacionServices : IUbicacionServices
    {
        private readonly IUbicacionRepository _ubicacionRepository;
        private readonly IPersonaRepository _personaRepository;
        private readonly IGeocodingService _geocodingService;
        private readonly IMapper _mapper;

        public UbicacionServices(IUbicacionRepository ubicacionRepository, IPersonaRepository personRepository, IGeocodingService geocodingService, IMapper mapper)
        {
            _ubicacionRepository = ubicacionRepository;
            _personaRepository = personRepository;
            _geocodingService = geocodingService;
            _mapper = mapper;
        }

        public async Task<(bool success, string messages, Ubicacion Ubicacion)> AddUbicacionAsync(int personaId, string direccion)
        {
            try
            {
                var persona = await _personaRepository.ObtenerPorIdAsync(personaId);
                if (persona == null)
                {
                    return (false, "La persona no existe", null);
                }

                (double latitude, double longitude) coordinates;

                try
                {
                    coordinates = await _geocodingService.ObtenerCoordenadas(direccion);
                }
                catch (Exception ex)
                {
                    return (false, $"Error al obtener las coordendas {ex.Message}", null);
                }

                var request = new UbicacionRequestDTO { PersonaId = personaId, Direccion = direccion };
                var ubicacion = new Ubicacion
                {
                    IdPersona = personaId,
                    Direccion = direccion
                };
                
                ubicacion.Latitud = coordinates.latitude;
                ubicacion.Longitud = coordinates.longitude;
                ubicacion.Fecha = DateTime.UtcNow;

                await _ubicacionRepository.AgregarAsync(ubicacion);

                return (true, "Ubicacion anadida con exito", ubicacion);
            }
            catch (Exception ex)
            {
                return (false, $"Error al guardar la ubicacion{ex.Message}", null);

            }
        }

        public ICollection<UbicacionDTO>? HistorialPersona(int personaId)
        {
            var ubicaciones = _ubicacionRepository.HistorialPersona(personaId);
            return ubicaciones;
        }

        public ICollection<UbicacionDTO>? UbicacionesActuales()
        {
            return _ubicacionRepository.UbicacionesActuales();
        }


    }
}
