//using PooII.Entities;
//using PooII.Interfaces;

//namespace PooII.TareasProgramadas
//{
//    public class CronJobService : BackgroundService
//    {
//        private readonly ILogger<CronJobService> _logger;
//        private readonly IPersonaRepository _personaRepository;
//        private readonly IUbicacionRepository _coordenadaRepository;
//        private readonly IGeocoder _geocoder;
//        private readonly TimeSpan _interval = TimeSpan.FromSeconds(30);

//        public CronJobService(
//            ILogger<CronJobService> logger,
//            IPersonaRepository personaRepository,
//            IUbicacionRepository coordenadaRepository,
//            IGeocoder geocoder)
//        {
//            _logger = logger;
//            _personaRepository = personaRepository;
//            _coordenadaRepository = coordenadaRepository;
//            _geocoder = geocoder;
//        }

//        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            while (!stoppingToken.IsCancellationRequested)
//            {
//                try
//                {
//                    _logger.LogInformation($"Cron Task :: Execution Time - {DateTime.Now}");

//                    var listPersonas = _personaRepository.ObtenerTodas();
//                    if (listPersonas != null && listPersonas.Count() > 0)
//                    {
//                        foreach (var persona in listPersonas)
//                        {
//                            var latLng = _geocoder.GetLatLng(persona.Ubicacion);
//                            var coor = latLng.Split(',');

//                            var existing = _coordenadaRepository.getCoordenadasPorPersona(persona.Id);
//                            if (existing == null)
//                            {
//                                _coordenadaRepository.Save(new Ubicacion(persona.Id, persona.PNombre,
//                                    double.Parse(coor[0]), double.Parse(coor[1])));
//                            }
//                            else
//                            {
//                                _coordenadaRepository.Save(new Coordenadas(existing.Id, persona.Id, persona.PNombre,
//                                    double.Parse(coor[0]), double.Parse(coor[1])));
//                            }

//                            _logger.LogInformation($"{latLng} - {DateTime.Now}");
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    _logger.LogError(ex, "Error en el cron job");
//                }

//                await Task.Delay(_interval, stoppingToken);
//            }
//        }
//    }
//}
