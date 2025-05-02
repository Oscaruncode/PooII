using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PooII.Entities
{
    public class Usuario
    {
        public int IdPersona { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;

        [ForeignKey("IdPersona")]
        public virtual Persona Persona { get; set; }
    }
}
