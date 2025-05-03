using System;
using AutoMapper;
using Microsoft.Extensions.Logging;
using PooII.DTOs;
using PooII.Entities;
using PooII.Interfaces;

namespace PooII.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly ILogger<PersonaService> logger;
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;
        public PersonaService(IPersonaRepository personaRepository, ILogger<PersonaService> logger, IMapper mapper, IUsuarioService usuarioService)
        {
            _personaRepository = personaRepository;
            this.logger = logger;
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        public bool ActualizarPersona(PersonaDTO personaDTO)
        {
            if (personaDTO == null)
            {
                logger.LogWarning("Intento de actualizar persona con objeto nulo.");
                return false;
            }

            var personaExistente = _personaRepository.ObtenerPorId(personaDTO.Id);
            if (personaExistente == null)
                return false;

            try
            {
                _mapper.Map(personaDTO, personaExistente);
                _personaRepository.GuardarCambios();
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error al actualizar persona con ID {personaDTO.Id}");
                return false;
            }
        }

        public bool CrearPersona(PersonaDTO personaDTO)
        {
            try
            {
                if (personaDTO == null)
                {
                    logger.LogError("ERROR AGREGAR_PERSONA: LA PERSONA ES NULO!");
                    return false;
                }
                else
                {
                    var persona = _mapper.Map<Persona>(personaDTO);

                    var usuario = _usuarioService.GenerarUsuario(persona);
                    persona.Usuario = usuario;
                    _personaRepository.Crear(persona);
                    _personaRepository.GuardarCambios();
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.LogError("ERROR AGREGAR_PERSONA: LA PERSONA NO SE HA GUARDADO!");
                return false;
            }
        }

        public bool EliminarPersona(int id)
        {
            var persona = _personaRepository.ObtenerPorId(id);
            if (persona == null)
                return false;

            try
            {
                _personaRepository.Eliminar(id);
                _personaRepository.GuardarCambios();
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error al eliminar persona con ID {id}.");
                return false;
            }
        }

        public ICollection<PersonaDTO> ObtenerPersonas()
        {
            var personas = _personaRepository.ObtenerTodas();
            return personas == null
                ? new List<PersonaDTO>()
                : _mapper.Map<ICollection<PersonaDTO>>(personas);
        }

        public IEnumerable<PersonaDTO> PersonaPorApellido(string pApellido)
        {
            return _mapper.Map<IEnumerable<PersonaDTO>>(_personaRepository.ObtenerPorApellido(pApellido));
        }

        public IEnumerable<PersonaDTO> PersonaPorEdad(int edad)
        {
            return _mapper.Map<IEnumerable<PersonaDTO>>(_personaRepository.ObtenerPorEdad(edad));
        }

        public PersonaDTO? PersonaPorID(int id)
        {
            return _mapper.Map<PersonaDTO>(_personaRepository.ObtenerPorId(id));
        }

        public PersonaDTO? PersonaPorIdentificacion(string identificacion)
        {
            return _mapper.Map<PersonaDTO>(_personaRepository.ObtenerPorIdentificacion(identificacion));
        }

        public IEnumerable<PersonaDTO> PersonaPorPNombre(string pNombre)
        {
            return _mapper.Map<IEnumerable<PersonaDTO>>(_personaRepository.ObtenerPorPNombre(pNombre));
        }
    }
}

