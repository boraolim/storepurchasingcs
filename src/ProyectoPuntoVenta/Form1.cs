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
    public partial class Form1 : Form
    {
        public static Persona oPersona;

        public Form1(Persona objeto= null)
        {
            InitializeComponent();
            oPersona = objeto;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblusuario.Text = oPersona.Nombre;
            lblrol.Text = oPersona.oTipoPersona.Descripcion;

            if (oPersona.oTipoPersona.IdTipoPersona == 2) {
                usuariosToolStripMenuItem.Visible = false;
                gestionToolStripMenuItem.Visible = false;
                proveedoresToolStripMenuItem.Visible = false;
                reporteriaToolStripMenuItem.Visible = false;
                comprasToolStripMenuItem.Visible = false;
            }


            frmVenta frmhijo = new frmVenta(oPersona.IdPersona);
            mostrarformulario(frmhijo, ventasToolStripMenuItem);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frmhijo = new frmCliente();

            mostrarformulario(frmhijo,sender);
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor frmhijo = new frmProveedor();

            mostrarformulario(frmhijo,sender);
        }


        private void gestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestion frmhijo = new frmGestion();

            mostrarformulario(frmhijo,sender);
        }


        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompra frmhijo = new frmCompra(oPersona.IdPersona);

            mostrarformulario(frmhijo,sender);
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVenta frmhijo = new frmVenta(oPersona.IdPersona);

            mostrarformulario(frmhijo,sender);
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario frmhijo = new frmUsuario();

            mostrarformulario(frmhijo,sender);
        }


        private void reporteriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporte frmhijo = new frmReporte();

            mostrarformulario(frmhijo,sender);
        }

        private void mostrarformulario(Form formulario, object senderitem)
        {

            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            foreach (ToolStripMenuItem menu in msMenu.Items)
            {
                menu.BackColor = Color.White;
            }
            ((ToolStripMenuItem)senderitem).BackColor = Color.SkyBlue;

            formulario.MdiParent = this;
            formulario.WindowState = FormWindowState.Maximized;
            formulario.Show();
        }

        private void AcercadeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ModalAcercade frm = new ModalAcercade();
            frm.ShowDialog();
        }

        private void SalirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                this.Close();
            }
        }

        private void msMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
