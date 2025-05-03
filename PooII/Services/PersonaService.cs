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
            var personaExistente = _personaRepository.ObtenerPorId(personaDTO.Id);
            if (personaExistente == null)
                return false;

            _mapper.Map(personaDTO, personaExistente); 

            _personaRepository.GuardarCambios();
            return true;
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
             _personaRepository.Eliminar(id);
            _personaRepository.GuardarCambios();
            return true;
        }

        public ICollection<PersonaDTO> ObtenerPersonas()
        {
            return _mapper.Map<ICollection<PersonaDTO>>(_personaRepository.ObtenerTodas());
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

