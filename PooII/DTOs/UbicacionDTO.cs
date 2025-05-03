namespace PooII.DTOs
{
    public class UbicacionDTO
    {
        public int Id { get; set; }
       public int IdPersona { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public DateTime fecha { get; set; }
        public string Marca { get; set; } //username from Usuario
    }
}
