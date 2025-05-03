using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PooII.Entities
{
    public class Usuario
    {
        public int IdPersona { get; set; }
        public string Login { get; private set; } = string.Empty; // <- Solo se puede asignar dentro de la clase
        public string Password { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;

        [ForeignKey("IdPersona")]
        public virtual Persona Persona { get; set; }

        public void EstablecerLogin(string login)
        {
            if (!string.IsNullOrEmpty(Login))
                throw new InvalidOperationException("El login ya ha sido establecido y no puede modificarse.");

            Login = login;
        }

    }
}
