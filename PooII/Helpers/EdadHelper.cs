namespace PooII.Helpers
{
        public static class EdadHelper
        {
            public static int CalcularEdad(DateTime fechaNacimiento)
            {
                var hoy = DateTime.Today;
                var edad = hoy.Year - fechaNacimiento.Year;
                if (fechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
                return edad;
            }

            public static string CalcularEdadClinica(DateTime fechaNacimiento)
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