using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaApp.Models
{
    internal class Atiende
    {
        public int IdFicha { get; set; } //PK
        public DateTime? FSolicitud { get; set; }
        public DateTime? FConsulta { get; set; }
        public string Diagnostico { get; set; } = string.Empty;
        public string Tratamiento { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;

        public int IdMedico { get; set; }
        public Doctor Doctor { get; set; } = null!;

        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; } = null!;

    }
}
