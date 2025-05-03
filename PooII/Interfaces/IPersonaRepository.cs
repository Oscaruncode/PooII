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

        bool Crear(Persona persona);
        bool Actualizar(Persona persona);
        bool Eliminar(int id);
        bool GuardarCambios();

        Task<IEnumerable<Persona>> ObtenerTodasAsync();
        Task<Persona?> ObtenerPorIdAsync(int id);

    }
}
