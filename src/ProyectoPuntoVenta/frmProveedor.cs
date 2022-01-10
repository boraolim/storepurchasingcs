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
    public partial class frmProveedor : Form
    {
        public frmProveedor()
        {
            InitializeComponent();
        }

        private void frmProveedor_Load(object sender, EventArgs e)
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
            dgdata.Columns.Add("RazonSocial", "Razon Social");
            dgdata.Columns.Add("Correo", "Correo");
            dgdata.Columns.Add("Telefono", "Telefono");

            dgdata.Columns["btnSeleccionar"].Width = 80;
            dgdata.Columns["NumeroDocumento"].Width = 150;
            dgdata.Columns["RazonSocial"].Width = 260;
            dgdata.Columns["Correo"].Width = 300;
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

            foreach (Proveedor p in ProveedorLogica.Instancia.Listar())
            {
                int rowId = dgdata.Rows.Add();
                DataGridViewRow row = dgdata.Rows[rowId];
                row.Cells["Id"].Value = p.IdProveedor.ToString();
                row.Cells["NumeroDocumento"].Value = p.Documento;
                row.Cells["RazonSocial"].Value = p.RazonSocial;
                row.Cells["Correo"].Value = p.Correo;
                row.Cells["Telefono"].Value = p.Telefono;
            }

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            Proveedor objeto = new Proveedor()
            {
                IdProveedor = int.Parse(txtid.Text),
                Documento = txtdocumento.Text.Trim(),
                RazonSocial = txtrazonsocial.Text.Trim(),
                Correo = txtcorreo.Text.Trim(),
                Telefono = txttelefono.Text.Trim()
            };

            var resultado = false;
            if (int.Parse(txtid.Text) == 0)
            {
                int id = ProveedorLogica.Instancia.Registrar(objeto);

                resultado = id != 0 ? true : false;

                if (resultado)
                {
                    int rowId = dgdata.Rows.Add();
                    DataGridViewRow row = dgdata.Rows[rowId];
                    row.Cells["Id"].Value = id.ToString();
                    row.Cells["NumeroDocumento"].Value = txtdocumento.Text.Trim();
                    row.Cells["RazonSocial"].Value = txtrazonsocial.Text.Trim();
                    row.Cells["Correo"].Value = txtcorreo.Text.Trim();
                    row.Cells["Telefono"].Value = txttelefono.Text.Trim();
                }


            }
            else
            {
                resultado = ProveedorLogica.Instancia.Modificar(objeto);
                if (resultado)
                {
                    DataGridViewRow row = dgdata.Rows[int.Parse(txtindex.Text) - 1];
                    row.Cells["Id"].Value = txtid.Text;
                    row.Cells["NumeroDocumento"].Value = txtdocumento.Text.Trim();
                    row.Cells["RazonSocial"].Value = txtrazonsocial.Text.Trim();
                    row.Cells["Correo"].Value = txtcorreo.Text.Trim();
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
            if (e.ColumnIndex >= 0)
            {
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
            if (e.RowIndex < 0)
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

        private void Limpiar()
        {

            txtindex.Text = "0";
            txtid.Text = "0";
            txtdocumento.Text = "";
            txtrazonsocial.Text = "";
            txtcorreo.Text = "";
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
                    txtrazonsocial.Text = dgdata.Rows[index].Cells["RazonSocial"].Value.ToString();
                    txtcorreo.Text = dgdata.Rows[index].Cells["Correo"].Value.ToString();
                    txttelefono.Text = dgdata.Rows[index].Cells["Telefono"].Value.ToString();
                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtindex.Text) > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el proveedor?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    bool respuesta = ProveedorLogica.Instancia.Eliminar(int.Parse(txtid.Text));
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

            if (dgdata.Rows.Count > 0)
            {
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
