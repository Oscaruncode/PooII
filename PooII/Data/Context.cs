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
                        //Calcular edad clinida y edad
                        entry.Entity.Edad = EdadHelper.CalcularEdad(fechaNacimiento.Value);
                        entry.Entity.EdadClinica = EdadHelper.CalcularEdadClinica(fechaNacimiento.Value);
                    }
                }
            }

            foreach (var entry in ChangeTracker.Entries<Usuario>())
            {
                if (entry.State == EntityState.Modified)
                {
                    var originalLogin = entry.OriginalValues.GetValue<string>(nameof(Usuario.Login));
                    var currentLogin = entry.CurrentValues.GetValue<string>(nameof(Usuario.Login));

                    if (originalLogin != currentLogin)
                    {
                        // Restaurar el valor original del Login para evitar cambiarlo
                        entry.CurrentValues[nameof(Usuario.Login)] = originalLogin;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
