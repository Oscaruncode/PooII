using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PooII.Data;
using PooII.DTOs;
using PooII.Entities;
using PooII.Interfaces;

namespace PooII.Repositories
{
    public class UbicacionRepository : IUbicacionRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public UbicacionRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ICollection<Ubicacion> consultarUbicaciones()
        {
            throw new NotImplementedException();
        }
        public Ubicacion getCoordenadasPorPersona(int id_persona)
        {
            throw new NotImplementedException();
        }

        public async Task<Ubicacion?> ObtenerUltimaPorPersona(int personaId)
        {
            return await _context.Ubicaciones
                .Where(u => u.IdPersona == personaId)
                .OrderByDescending(u => u.Fecha).FirstOrDefaultAsync();
        }

        public async Task AgregarAsync(Ubicacion ubicacion)
        {
            await _context.Ubicaciones.AddAsync(ubicacion);
            await _context.SaveChangesAsync();
        }

        ICollection<UbicacionDTO>? IUbicacionRepository.UbicacionesActuales()
        {
            var ubicaciones = _context.Ubicaciones
            .Include(u => u.Persona)
            .ThenInclude(p => p.Usuario)
            .AsEnumerable() // Para agrupar en memoria, ya que EF Core no siempre traduce GroupBy correctamente con navegación compleja
            .GroupBy(u => u.IdPersona)
             .Select(g => g.OrderByDescending(u => u.Fecha).First())
             .Select(u => new UbicacionDTO
        {
            Id = u.Id,
            IdPersona = u.IdPersona,
            latitud = u.Latitud,
            longitud = u.Longitud,
            fecha = u.Fecha,
            Marca = u.Persona.Usuario.Login
        })
        .ToList();

            return ubicaciones;
        }

        public ICollection<UbicacionDTO>? HistorialPersona(int personaId)
        {
            var ubicaciones = _context.Ubicaciones
                .Where(u => u.IdPersona == personaId)
                .Select(u => new UbicacionDTO
                {
                    Id = u.Id,
                    IdPersona = u.IdPersona,
                    latitud = u.Latitud,
                    longitud = u.Longitud,
                    fecha = u.Fecha
                })
                .ToList();
            return ubicaciones;
        }


    }
}