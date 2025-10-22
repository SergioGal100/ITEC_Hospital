namespace ClinicaApp.Models
{
    internal class Doctor
    {
        public int CiMedico { get; set; }
        public string Turnos { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;

        public int IdPersona {get; set;} //PK
	    public Persona Persona { get; set; } = null!;
        public List<Atiende> Atiende { get; set; } = new();

    }
}
