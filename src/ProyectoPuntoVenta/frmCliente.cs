using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoPuntoVenta.Modelo;
using ProyectoPuntoVenta.Logica;

namespace ProyectoPuntoVenta
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {

            //AGREGAR BOTON ELIMINAR
            DataGridViewButtonColumn Boton = new DataGridViewButtonColumn();

            Boton.HeaderText = "Seleccionar";
            Boton.Width = 80;
            Boton.Text = "";
            Boton.Name = "btnSeleccionar";
            Boton.UseColumnTextForButtonValue = true;

            //AGREGAMOS LOS BOTONES
            dgdata.Columns.Add(Boton);
            dgdata.Columns.Add("Id", "Id");
            dgdata.Columns.Add("NumeroDocumento", "Numero Documento");
            dgdata.Columns.Add("NombreCompleto", "Nombre Completo");
            dgdata.Columns.Add("Direccion", "Dirección");
            dgdata.Columns.Add("Telefono", "Telefono");

            dgdata.Columns["btnSeleccionar"].Width = 100;
            dgdata.Columns["NumeroDocumento"].Width = 150;
            dgdata.Columns["NombreCompleto"].Width = 260;
            dgdata.Columns["Direccion"].Width = 300;
            dgdata.Columns["Id"].Visible = false;

            foreach (DataGridViewColumn cl in dgdata.Columns)
            {
                if (cl.Visible == true && cl.Name != "btnSeleccionar")
                {
                    cbobuscar.Items.Add(new ComboBoxItem() { Value = cl.Name, Text = cl.HeaderText });
                }
            }
            cbobuscar.DisplayMember = "Text";
            cbobuscar.ValueMember = "Value";
            cbobuscar.SelectedIndex = 0;

            foreach (Persona p in PersonaLogica.Instancia.Listar().Where(p=> p.oTipoPersona.IdTipoPersona == 3).ToList()) {
                int rowId = dgdata.Rows.Add();
                DataGridViewRow row = dgdata.Rows[rowId];
                row.Cells["Id"].Value = p.IdPersona.ToString();
                row.Cells["NumeroDocumento"].Value = p.Documento;
                row.Cells["NombreCompleto"].Value = p.Nombre;
                row.Cells["Direccion"].Value = p.Direccion;
                row.Cells["Telefono"].Value = p.Telefono;
            }



        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            Persona objeto = new Persona()
            {
                IdPersona = int.Parse(txtid.Text),
                Documento = txtdocumento.Text.Trim(),
                Nombre = txtnombre.Text.Trim(),
                Direccion = txtdireccion.Text.Trim(),
                Telefono = txttelefono.Text.Trim(),
                Clave = "",
                oTipoPersona = new TipoPersona() { IdTipoPersona = 3}
            };

            var resultado = false;
            if (int.Parse(txtid.Text) == 0)
            {
                int id = PersonaLogica.Instancia.Registrar(objeto);

                resultado = id != 0 ? true : false;

                if (resultado) {
                    int rowId = dgdata.Rows.Add();
                    DataGridViewRow row = dgdata.Rows[rowId];
                    row.Cells["Id"].Value = id.ToString();
                    row.Cells["NumeroDocumento"].Value = txtdocumento.Text.Trim();
                    row.Cells["NombreCompleto"].Value = txtnombre.Text.Trim();
                    row.Cells["Direccion"].Value = txtdireccion.Text.Trim();
                    row.Cells["Telefono"].Value = txttelefono.Text.Trim();
                }
                

            }
            else {
                resultado = PersonaLogica.Instancia.Modificar(objeto);
                if (resultado)
                {
                    DataGridViewRow row = dgdata.Rows[int.Parse(txtindex.Text) - 1];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["NumeroDocumento"].Value = txtdocumento.Text.Trim();
                    row.Cells["NombreCompleto"].Value = txtnombre.Text.Trim();
                    row.Cells["Direccion"].Value = txtdireccion.Text.Trim();
                    row.Cells["Telefono"].Value = txttelefono.Text.Trim();
                }
                
            }

            if (resultado)
                Limpiar();
            else
                MessageBox.Show("No se pudo guardar los cambios\nRevise los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
        }

        private void dgdata_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0){
                string colname = dgdata.Columns[e.ColumnIndex].Name;
                if (colname != "btnSeleccionar")
                {
                    dgdata.Cursor = Cursors.Default;
                }
                else
                {
                    dgdata.Cursor = Cursors.Hand;
                }
            }
           
        }

        private void dgdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex < 0)
                return;
            
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check20.Width;
                var h = Properties.Resources.check20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar() {
            
            txtindex.Text = "0";
            txtid.Text = "0";
            txtdocumento.Text = "";
            txtnombre.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
        }

        private void dgdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgdata.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    txtindex.Text = (index + 1).ToString();
                    txtid.Text = dgdata.Rows[index].Cells["Id"].Value.ToString();
                    txtdocumento.Text = dgdata.Rows[index].Cells["NumeroDocumento"].Value.ToString();
                    txtnombre.Text = dgdata.Rows[index].Cells["NombreCompleto"].Value.ToString();
                    txtdireccion.Text = dgdata.Rows[index].Cells["Direccion"].Value.ToString();
                    txttelefono.Text = dgdata.Rows[index].Cells["Telefono"].Value.ToString();
                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtindex.Text) > 0) {

                if (MessageBox.Show("¿Desea eliminar el cliente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    bool respuesta = PersonaLogica.Instancia.Eliminar(int.Parse(txtid.Text));
                    if (respuesta)
                    {
                        dgdata.Rows.RemoveAt(int.Parse(txtindex.Text) - 1);
                        Limpiar();
                    }
                    else
                        MessageBox.Show("No se pudo eliminar el registro\nRevise los datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                

            }
            
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((ComboBoxItem)cbobuscar.SelectedItem).Value.ToString();

            if (dgdata.Rows.Count > 0) {
                foreach (DataGridViewRow row in dgdata.Rows)
                {
                    string valor = row.Cells[columnaFiltro].Value.ToString().Trim();

                    if (row.Cells[columnaFiltro].Value.ToString().Trim().Contains(txtbuscar.Text.Trim()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }

           
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtbuscar.Text = "";
            foreach (DataGridViewRow row in dgdata.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
