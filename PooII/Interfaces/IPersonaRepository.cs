using PooII.Entities;

namespace PooII.Interfaces
{
    public interface IPersonaRepository
    {
        Persona? ObtenerPorId(int id);
        Persona? ObtenerPorIdentificacion(string identificacion);
        IEnumerable<Persona> ObtenerPorEdad(int edad);
        IEnumerable<Persona> ObtenerPorPNombre(string pNombre);
        IEnumerable<Persona> ObtenerPorApellido(string apellido);
        IEnumerable<Persona> ObtenerTodas();
        IEnumerable<Persona> ObtenerPersonaConUbicacion();

        void Crear(Persona persona);
        void Actualizar(Persona persona);
        void Eliminar(int id);

        bool GuardarCambios();
    }
}
