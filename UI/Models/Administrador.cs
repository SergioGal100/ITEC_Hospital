namespace ClinicaApp.Models
{
    internal class Administrador
    {
        public int IdPersona {get; set;} //PK
	    public Persona Persona { get; set; } = null!;

    }
}
