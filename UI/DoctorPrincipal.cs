using ClinicaApp;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace UI
{
    public partial class DoctorPrincipal : Form
    {
        private readonly int? _doctorId = 1;
        public DoctorPrincipal()
        {
            InitializeComponent();
            this.Load += DoctorPrincipal_Load;
        }
        private void DoctorPrincipal_Load(object? sender, EventArgs e)
        {
            LoadAtiendeData();
            this.FormClosing += SolicitaConsulta_FormClosing;
        }
        

        // Loads Atiende rows (optionally filtered by doctor) and binds to the grid
        private void LoadAtiendeData()
        {
            try
            {
                using var db = new ClinicaContext();

                var query = db.Atiende
                    .Include(a => a.Doctor).ThenInclude(d => d.Persona)
                    .Include(a => a.Paciente).ThenInclude(p => p.Persona)
                    .AsQueryable();

                if (_doctorId.HasValue)
                {
                    // IdMedico stores the doctor's persona/id as used elsewhere in the app
                    query = query.Where(a => a.IdMedico == _doctorId.Value);
                }

                var items = query
                    .OrderBy(a => a.FSolicitud)
                    .Select(a => new
                    {
                        a.IdFicha,
                        FSolicitud = a.FSolicitud,
                        FConsulta = a.FConsulta,
                        Doctor = a.Doctor != null ? (a.Doctor.Persona.Nombre + " " + a.Doctor.Persona.Apellido) : string.Empty,
                        Paciente = a.Paciente != null ? (a.Paciente.Persona.Nombre + " " + a.Paciente.Persona.Apellido) : string.Empty,
                        a.Diagnostico,
                        a.Tratamiento,
                        a.Observaciones
                    })
                    .ToList();

                dataGridView1.DataSource = items;

                // Optional: nicer date formatting for the grid
                if (dataGridView1.Columns["FSolicitud"] != null)
                    dataGridView1.Columns["FSolicitud"].DefaultCellStyle.Format = "g";
                if (dataGridView1.Columns["FConsulta"] != null)
                    dataGridView1.Columns["FConsulta"].DefaultCellStyle.Format = "g";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Public helper to refresh the grid if needed
        public void RefreshAtiende() => LoadAtiendeData();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SolicitaConsulta_FormClosing(object sender, FormClosingEventArgs e)
        {
            var existing = Application.OpenForms.OfType<Inicio>().FirstOrDefault();
            if (existing != null)
            {
                existing.Show();
            }
            else
            {
                var inicio = new Inicio();
                inicio.Show();
            }
        }
    }
}
