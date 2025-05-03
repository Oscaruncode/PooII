using Microsoft.EntityFrameworkCore;
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

        public Persona? ObtenerPorId(int id)
        {
            return _context.Personas.FirstOrDefault(p => p.Id == id);
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
            //Posible correccion coincidencia que contenga o exacto
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

        public IEnumerable<Persona> ObtenerPersonaConUbicacion()
        {
            throw new NotImplementedException();
        }

        bool IPersonaRepository.Crear(Persona persona)
        {
            _context.Personas.Add(persona);
            return true;
        }

        bool IPersonaRepository.Actualizar(Persona persona)
        {
            _context.Personas.Update(persona);
            return true;
        }

        bool IPersonaRepository.Eliminar(int id)
        {
            var persona = ObtenerPorId(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                return true;
            }
            return false;
        }
    }
}
