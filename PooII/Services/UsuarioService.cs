using System;
using AutoMapper;
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

        public bool actualizar(Usuario usuario)
        {
            throw new NotImplementedException();

        }

        public bool CambiarPassword(int personaId, string newPasswrod)
        {
            throw new NotImplementedException();
        }

        public Usuario GenerarUsuario(Persona persona)
        {
            var password = PasswordHelper.GenerarPassword();
            var apiKey = ApiKeyHelper.GenerarApiKey();

            var usuario = new Usuario()
            {
                IdPersona = persona.Id,
                Login = ApiKeyHelper.GenerarLogin(persona),
                Password = password,
                ApiKey = apiKey
            };
            return usuario;
        }

        public bool guardar(Usuario usuario)
        {
           

            throw new NotImplementedException();
        }
    }
}