using Microsoft.EntityFrameworkCore;
using PooII.Data;
using PooII.Entities;
using PooII.Interfaces;

namespace PooII.Repositories
{
    public class UbicacionRepository : IUbicacionRepository
    {
        private readonly Context _context;

        public UbicacionRepository(Context context)
        {
            _context = context;
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
    }
}