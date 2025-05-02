using System;
using Microsoft.EntityFrameworkCore;
using PooII.Entities;
using PooII.Helpers;

namespace PooII.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.IdPersona);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Persona)
                .WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(u => u.IdPersona)
                .OnDelete(DeleteBehavior.Cascade); 
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<Persona>())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    var fechaNacimiento = entry.Entity.FechaNacimiento;
                    if (fechaNacimiento.HasValue)
                    {
                        entry.Entity.Edad = EdadHelper.CalcularEdad(fechaNacimiento.Value);
                        entry.Entity.EdadClinica = EdadHelper.CalcularEdadClinica(fechaNacimiento.Value);
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
