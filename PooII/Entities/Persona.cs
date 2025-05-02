namespace PooII.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public string Identificacion { get; set; } = string.Empty;
        public string PNombre { get; set; } = string.Empty;
        public string SNombre { get; set; } = string.Empty;
        public string PApellido { get; set; } = string.Empty;
        public string SApellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string EdadClinica { get; set; } = string.Empty;
        public virtual Usuario Usuario { get; set; }
        public ICollection<Ubicacion> Ubicaciones { get; set; } = new List<Ubicacion>();
    }
}