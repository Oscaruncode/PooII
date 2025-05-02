namespace PooII.DTOs
{
    public class PersonaDTO
    {
            public int Id { get; set; }
            public string Identificacion { get; set; } = string.Empty;
            public string PNombre { get; set; } = string.Empty;
            public string SNombre { get; set; } = string.Empty;
            public string PApellido { get; set; } = string.Empty;
            public string SApellido { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public DateTime? FechaNacimiento { get; set; }
    }
}