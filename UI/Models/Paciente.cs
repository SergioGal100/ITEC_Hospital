namespace ClinicaApp.Models
{
    internal class Paciente
    {
        public int IdPersona {get; set;} //PK
	    public Persona Persona { get; set; } = null!;

        public List<Atiende> Atiende { get; set; } = new(); 

    }
}
