using ClinicaApp.Models;
using ClinicaApp;
using System.Security.Cryptography;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApp
{
    internal class OperationsDB
    {
        //crea inserta data
        //Persona
        public static void CreateDoctor (
            ClinicaContext db,
            string nombre,
            string apellido,
            string direccion,
            DateTime? fContratacion,
            string telefono,
            DateTime fNacimiento,
            string ci,
            //doctor part
            int ciMedico,
            string turnos,
            string especialidad
            )
        {
            var persona = new Persona 
            {
                Nombre = nombre,
                Apellido = apellido,
                Direccion = direccion,
                FContratacion = fContratacion,
                Telefono = telefono,
                FNacimiento = fNacimiento,
                CI = ci 
            };
            db.Persona.Add(persona);
            db.SaveChanges();

            //crear doctor ligado a esa persona
            var doctor = new Doctor
            {
                IdPersona = persona.Id,
                CiMedico = ciMedico,
                Turnos = turnos,
                Especialidad = especialidad
            };
            db.Doctor.Add(doctor);
            db.SaveChanges();
        }
        public static void CreatePaciente(
            ClinicaContext db,
            string nombre,
            string apellido,
            string direccion,
            string telefono,
            DateTime fNacimiento,
            string ci
            )
        {
            var persona = new Persona
            {
                Nombre = nombre,
                Apellido = apellido,
                Direccion = direccion,
                Telefono = telefono,
                FNacimiento = fNacimiento,
                CI = ci
            };
            db.Persona.Add(persona);
            db.SaveChanges();

            //crear doctor ligado a esa persona
            var paciente = new Paciente
            {
                IdPersona = persona.Id,
            };
            db.Paciente.Add(paciente);
            db.SaveChanges();
        }
        public static void CreateAdministrador(
            ClinicaContext db,
            string nombre,
            string apellido,
            string direccion,
            string telefono,
            DateTime fNacimiento,
            string ci
            )
        {
            var persona = new Persona
            {
                Nombre = nombre,
                Apellido = apellido,
                Direccion = direccion,
                Telefono = telefono,
                FNacimiento = fNacimiento,
                CI = ci
            };
            db.Persona.Add(persona);
            db.SaveChanges();

            //crear doctor ligado a esa persona
            var administrador = new Administrador
            {
                IdPersona = persona.Id,
            };
            db.Administrador.Add(administrador);
            db.SaveChanges();
        }

        public static void CreateFicha(
            ClinicaContext db,
            DateTime fSolicitud,
            DateTime fConsulta,
            string diagnostico,
            string tratamiento,
            string observaciones,
            int idMedico,
            int idPaciente
            )
        {
            try
            {
                var atiende = new Atiende
                {
                    FSolicitud = fSolicitud,
                    FConsulta = fConsulta,
                    Diagnostico = diagnostico,
                    Tratamiento = tratamiento,
                    Observaciones = observaciones,
                    IdMedico = idMedico,
                    IdPaciente = idPaciente
                };
                db.Atiende.Add(atiende);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception($"Database update error: {ex.InnerException?.Message ?? ex.Message}");
            }
 
        }

        public static Doctor? GetDoctorById(
            ClinicaContext db,
            int idPersona
            )
        {
            return db.Doctor.FirstOrDefault(d => d.IdPersona == idPersona);
        }

        public static Paciente? GetPacienteById(
            ClinicaContext db,
            int idPersona
            )
        {
            return db.Paciente.FirstOrDefault(d => d.IdPersona == idPersona);
        }

        public static Administrador? GetAdministradorById(
            ClinicaContext db,
            int idPersona
            )
        {
            return db.Administrador.FirstOrDefault(d => d.IdPersona == idPersona);
        }

        public static List<Atiende> GetFichasByDate(
            ClinicaContext db,
            DateTime date
            )
        {
            return db.Atiende.Where(a => a.FSolicitud == date).ToList();
        }

        public static List<Atiende> GetFichasById(
            ClinicaContext db,
            int idFicha
            )
        {
            return db.Atiende.Where(a => a.IdFicha == idFicha).ToList();
        }

        public static List<Doctor> GetDoctorByEs(
            ClinicaContext db,
            string esp
            )
        {
            var pattern = $"%{esp}";
            var doctors = db.Doctor
                .FromSqlInterpolated($@"
                   select d.*
                   from doctor d
                    where Especialidad LIKE {esp}
                ")
                .Include(d => d.Persona)
                .ToList();


            return doctors;
        }
    }
}
