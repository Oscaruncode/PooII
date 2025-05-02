using System.Text.Json.Serialization;
using System;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        public virtual Usuario Usuario { get; set; }
        public virtual Ubicacion Ubicacion { get; set; }

        private void CalcularEdades()
        {
            if (FechaNacimiento.HasValue)
            {
                Edad = CalcularEdad(FechaNacimiento.Value);
                EdadClinica = CalcularEdadClinica(FechaNacimiento.Value);
            }
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            var hoy = DateTime.Today;
            var edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
            return edad;
        }

        private string CalcularEdadClinica(DateTime fechaNacimiento)
        {
            var hoy = DateTime.Today;
            var anio = hoy.Year - fechaNacimiento.Year;
            var mes = hoy.Month - fechaNacimiento.Month;
            var dias = hoy.Day - fechaNacimiento.Day;

            if (dias < 0)
            {
                mes--;
                dias += DateTime.DaysInMonth(hoy.Year, hoy.Month);
            }
            if (mes < 0)
            {
                anio--;
                mes += 12;
            }
            return $"{anio} años {mes} meses {dias} días";
        }
    }
}