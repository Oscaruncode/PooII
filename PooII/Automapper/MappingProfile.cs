using AutoMapper;
using PooII.DTOs;
using PooII.Entities;

namespace PooII.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Persona, PersonaDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>();
        }
    }
}

