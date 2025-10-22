using ClinicaApp;
using ClinicaApp.Models;


namespace UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using var db = new ClinicaContext();
            db.Database.EnsureCreated();
            /*
             * Creación de Doctores
            OperationsDB.CreateDoctor(
                db: db,
                nombre: "Maria",
                apellido: "Gema Ibañez",
                direccion: "Entrada Elena 5, Burgos, Rio 11804",
                fContratacion: new DateTime(2019, 5, 3),
                telefono: "7554432",
                fNacimiento: new DateTime(1996, 8, 2),
                ci: "5900234",
                ciMedico: 59002349,
                turnos: "Tarde",
                especialidad: "Traumatologia"
                );

            OperationsDB.CreateDoctor(
                db: db,
                nombre: "Raquel",
                apellido: "Peña",
                direccion: "Polígono Andrés, 9 Esc. 462, Bilbao, Can 66710",
                fContratacion: new DateTime(2017, 7, 2),
                telefono: "7554432",
                fNacimiento: new DateTime(1975, 5, 22),
                ci: "69342344",
                ciMedico: 69342349,
                turnos: "Mañana",
                especialidad: "Cardiología"
                );

            OperationsDB.CreateDoctor(
                db: db,
                nombre: "Maria",
                apellido: "Gema Ibañez",
                direccion: "Entrada Elena 5, Burgos, Rio 11804",
                fContratacion: new DateTime(2024, 3, 3),
                telefono: "7554432",
                fNacimiento: new DateTime(1985, 1, 2),
                ci: "59034334",
                ciMedico: 590343349,
                turnos: "Noche",
                especialidad: "Oftalmología"
                );
            

            OperationsDB.CreatePaciente(
                db: db,
                nombre: "ITECT_USUARIO",
                apellido: "Evento",
                direccion: "Sucre Bolivia",
                telefono: "446653",
                fNacimiento: new DateTime(2015, 8, 2),
                ci: "445532" 
                );
            */
            Application.Run(new Inicio());
        }
    }
}