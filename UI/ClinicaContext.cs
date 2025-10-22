using ClinicaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClinicaApp
{

    internal class ClinicaContext : DbContext
    {
        public DbSet<Models.Persona> Persona { get; set; }
        public DbSet<Models.Doctor> Doctor { get; set; }
        public DbSet<Models.Paciente> Paciente { get; set; }
        public DbSet<Models.Administrador> Administrador { get; set; }
        public DbSet<Models.Atiende> Atiende { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=clinica.db",
                sqliteOptionsAction: op =>
                {
                    op.MigrationsAssembly(
                        Assembly.GetExecutingAssembly().FullName
                        );
                });                
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Doctor>()
                .HasKey(p => p.IdPersona);

            modelBuilder.Entity<Doctor>()
                .HasOne(p => p.Persona)
                .WithOne(d => d.Doctor)
                .HasForeignKey<Doctor>(p => p.IdPersona);

            modelBuilder.Entity<Paciente>()
                .HasKey(p => p.IdPersona);

            modelBuilder.Entity<Paciente>()
                .HasOne(p => p.Persona)
                .WithOne(pa => pa.Paciente)
                .HasForeignKey<Paciente>(p => p.IdPersona);

            modelBuilder.Entity<Administrador>()
                .HasKey(p => p.IdPersona);

            modelBuilder.Entity<Administrador>()
                .HasOne(p => p.Persona)
                .WithOne(a => a.Administrador)
                .HasForeignKey<Administrador>(p => p.IdPersona);

            modelBuilder.Entity<Atiende>()
                .HasKey(at => at.IdFicha);

            modelBuilder.Entity<Atiende>()
                .HasOne(d => d.Doctor)
                .WithMany(at => at.Atiende)
                .HasForeignKey(d => d.IdMedico)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Atiende>()
                .HasOne(p => p.Paciente)
                .WithMany(at => at.Atiende)
                .HasForeignKey(p => p.IdPaciente)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

