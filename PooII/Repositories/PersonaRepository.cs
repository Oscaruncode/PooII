using PooII.Data;
using PooII.Entities;
using PooII.Interfaces;

namespace PooII.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly Context _context;

        public PersonaRepository(Context context)
        {
            _context = context;
        }

        public void Crear(Persona persona)
        {
            _context.Personas.Add(persona);
        }

        public void Actualizar(Persona persona)
        {
            _context.Personas.Update(persona);
        }

        public void Eliminar(int id)
        {
            var persona = ObtenerPorId(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
            }
        }

        public Persona? ObtenerPorId(int id)
        {
            return _context.Personas
                .Include(p => p.Usuario)
                .Include(p => p.Ubicacion)
                .FirstOrDefault(p => p.Id == id);
        }

        public Persona? ObtenerPorIdentificacion(string identificacion)
        {
            return _context.Personas.FirstOrDefault(p => p.Identificacion == identificacion);
        }

        public IEnumerable<Persona> ObtenerPorEdad(int edad)
        {
            return _context.Personas.Where(p => p.Edad == edad).ToList();
        }

        public IEnumerable<Persona> ObtenerPorPNombre(string pNombre)
        {
            return _context.Personas.Where(p => p.PNombre.Contains(pNombre)).ToList();
        }

        public IEnumerable<Persona> ObtenerPorApellido(string apellido)
        {
            return _context.Personas.Where(p => p.PApellido.Contains(apellido) || p.SApellido.Contains(apellido)).ToList();
        }

        public IEnumerable<Persona> ObtenerTodas()
        {
            return _context.Personas.ToList();
        }

        public bool GuardarCambios()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
