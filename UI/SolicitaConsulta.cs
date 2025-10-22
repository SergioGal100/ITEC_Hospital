using ClinicaApp;
using ClinicaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class SolicitaConsulta : Form
    {
        public SolicitaConsulta()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            this.Load += SolicitaConsulta_Load;
            this.FormClosing += SolicitaConsulta_FormClosing;
        }

        private void SolicitaConsulta_Load(object sender, EventArgs e)
        {
            try
            {
                using var db = new ClinicaContext();

                // Load distinct specialties (one entry per specialty)
                var specialties = db.Doctor
                    .Where(d => !string.IsNullOrWhiteSpace(d.Especialidad))
                    .GroupBy(d => d.Especialidad)
                    .Select(g => new
                    {
                        Especialidad = g.Key!,
                        Display = g.Key
                    })
                    .OrderBy(x => x.Especialidad)
                    .ToList();

                comboBox1.DisplayMember = "Display";
                comboBox1.ValueMember = "Especialidad";
                comboBox1.DataSource = specialties;

                comboBox2.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading specialties: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // SelectedValue is the specialty string because ValueMember = "Especialidad"
                if (comboBox1.SelectedValue is string especialidad && !string.IsNullOrWhiteSpace(especialidad))
                {
                    using var db = new ClinicaContext();

                    var doctors = db.Doctor
                        .Include(d => d.Persona)
                        .Where(d => d.Especialidad == especialidad)
                        .Select(d => new
                        {
                            Id = d.IdPersona,
                            Name = d.Persona.Nombre + " " + d.Persona.Apellido
                        })
                        .OrderBy(x => x.Name)
                        .ToList();

                    comboBox2.DisplayMember = "Name";
                    comboBox2.ValueMember = "Id";
                    comboBox2.DataSource = doctors;
                }
                else
                {
                    comboBox2.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        public void GuardaFicha(string diagnostico = "", string tratamiento = "", string observaciones = "")
        {
            try
            {
                if (!(comboBox2.SelectedValue is int doctorId))
                {
                    MessageBox.Show("Por favor selecciona un doctor antes de guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var fSolicitud = DateTime.Now;
                var fConsulta = dateTimePicker1.Value;

                using var db = new ClinicaContext();

                OperationsDB.CreateFicha(
                    db,
                    fSolicitud,
                    fConsulta,
                    diagnostico,
                    tratamiento,
                    observaciones,
                    idMedico: doctorId,
                    idPaciente: 4
                    );

                MessageBox.Show("Ficha creada de forma correcta", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Simple UI feedback
                button1.Enabled = false;
                button1.Text = "Guardando...";

                // If you later add textboxes for diagnostico/tratamiento/observaciones,
                // pass their Text values to GuardaFicha here.
                GuardaFicha();

                // restore button state
                button1.Enabled = true;
                button1.Text = "ENVIAR SOLICITUD ";
            }
            catch (Exception ex)
            {
                button1.Enabled = true;
                button1.Text = "ENVIAR SOLICITUD ";
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SolicitaConsulta_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // Try to show an existing Inicio instance (if it was hidden),
            // otherwise create and show a new one.
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
