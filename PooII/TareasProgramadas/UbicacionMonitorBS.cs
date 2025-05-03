using PooII.Entities;
using PooII.Interfaces;

namespace PooII.TareasProgramadas
{
    public class UbicacionMonitorBS : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<UbicacionMonitorBS> _logger;

        public UbicacionMonitorBS(IServiceProvider serviceProvider, ILogger<UbicacionMonitorBS> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var ubicacionRepository = scope.ServiceProvider.GetRequiredService<IUbicacionRepository>();
                var personRepository = scope.ServiceProvider.GetRequiredService<IPersonaRepository>();
                var geocoding = scope.ServiceProvider.GetRequiredService<IGeocodingService>();

                var personas = await personRepository.ObtenerTodasAsync();

                foreach (var person in personas)
                {
                    var ultimaUbicacion = await ubicacionRepository.ObtenerUltimaPorPersona(person.Id);

                    if (ultimaUbicacion == null) continue;
                    try
                    {
                        var (lat, lng) = await geocoding.ObtenerCoordenadas(ultimaUbicacion.Direccion);

                        var nuevaUbicacion = new Ubicacion
                        {
                            IdPersona = person.Id,
                            Direccion = ultimaUbicacion.Direccion,
                            Latitud = lat,
                            Longitud = lng,
                            Fecha = DateTime.UtcNow,
                        };

                        await ubicacionRepository.AgregarAsync(nuevaUbicacion);

                    }
                    catch (Exception ex)
                    {
                        {
                            _logger.LogError(ex, $"No se actualizo la ubicacion de {person.PNombre} (ID:{person.Id}), coordenadas sin cambios");
                        }

                    }
                }
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);

            }
        }
    }
}
