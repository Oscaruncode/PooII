using System;
using AutoMapper;
using PooII.DTOs;
using PooII.Entities;
using PooII.Helpers;
using PooII.Interfaces;
using PooII.Repositories;
using PooII.Services;

namespace PooII.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<PersonaService> logger;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, ILogger<PersonaService> logger, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            this.logger = logger;
            _mapper = mapper;
        }

        public bool CambiarPassword(int personaId, string newPasswrod)
        {
            var usuario = _usuarioRepository.ObtenerPorId(personaId);
            if (usuario == null)
            {
                logger.LogError("ERROR CAMBIAR_PASSWORD: EL USUARIO NO EXISTE!");
                return false;
            }
            usuario.Password = newPasswrod;
            _usuarioRepository.Actualizar(usuario);
            _usuarioRepository.GuardarCambios();
            return true;
        }

        public Usuario GenerarUsuario(Persona persona)
        {
            var password = PasswordHelper.GenerarPassword();
            var apiKey = ApiKeyHelper.GenerarApiKey();
            var login = ApiKeyHelper.GenerarLogin(persona);

            var usuario = new Usuario()
            {
                IdPersona = persona.Id,
                Password = password,
                ApiKey = apiKey
            };
            usuario.EstablecerLogin(login);
            return usuario;
        }

        public UsuarioDTO ObtenerPorId(int id)
        {
            var usuario = _usuarioRepository.ObtenerPorId(id);
            if (usuario == null)
            {
                logger.LogError("ERROR OBTENER_USUARIO: EL USUARIO NO EXISTE!");
                return null;
            }
            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
            return usuarioDTO;
        }
    }
}