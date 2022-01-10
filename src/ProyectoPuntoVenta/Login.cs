using ProyectoPuntoVenta.Logica;
using ProyectoPuntoVenta.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPuntoVenta
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
     
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
     
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtdocumento.Focus();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            Persona oPersona = PersonaLogica.Instancia.Listar().Where(p => p.Documento == txtdocumento.Text && p.Clave == txtclave.Text && p.oTipoPersona.IdTipoPersona != 2).FirstOrDefault();
            if (oPersona != null)
            {
                Form1 frm = new Form1(oPersona);
                frm.Show();
                this.Hide();
                frm.FormClosing += Frm_Closing;
        }
            else
            {
                MessageBox.Show("No se econtraron coincidencias del usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
}

        private void Frm_Closing(object sender, FormClosingEventArgs e)
        {
            txtdocumento.Text = "";
            txtclave.Text = "";
            txtdocumento.Focus();
            this.Show();
        }
    }
}
