using System.Numerics;

namespace ClinicaApp.Models
{
    internal class Persona
    {
        public int Id { get; set; } //PK
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public DateTime? FContratacion { get; set; }
        public string? Telefono { get; set; }
        public DateTime FNacimiento { get; set; }
        public string CI { get; set; } = string.Empty;

        public Doctor? Doctor { get; set; }
        public Paciente? Paciente { get; set; }
        public Administrador? Administrador { get; set; }

    }
}
