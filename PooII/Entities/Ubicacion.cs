using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PooII.Entities
{
    public class Ubicacion
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public string Direccion { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("IdPersona")]
        public Persona Persona { get; set; }

    }
}
