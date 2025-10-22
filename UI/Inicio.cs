using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Inicio : Form
    {
        string Doctor = "doctor@ITEC.com.bo";
        string DoctorPassword = "12345";

        string Paciente = "paciente@ITEC.com.bo";
        string PacientePassword = "123456";

        string Administrador = "administrador@ITEC.com.bo";
        string AdministradorPassword = "ad1234";

        
        public Inicio()
        {
            InitializeComponent();

            passwordBox.UseSystemPasswordChar = true;

            button1.Click += Button1_Click;
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            string usuario = usuarioBox.Text;
            string password = passwordBox.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Debe ingresar usuario y contraseña para continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (usuario == this.Doctor && password == this.DoctorPassword)
            {
                MessageBox.Show("Ingreso correcto", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DoctorPrincipal doctorprincipal = new DoctorPrincipal();
                doctorprincipal.Show();
                this.Hide();
            }

            if(usuario == this.Paciente && password == this.PacientePassword)
            {
                MessageBox.Show("Ingreso correcto", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SolicitaConsulta solicitaConsulta = new SolicitaConsulta();
                solicitaConsulta.Show();
                this.Hide();
            }
        }
    }
}
