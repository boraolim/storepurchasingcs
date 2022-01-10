using ProyectoPuntoVenta.Logica;
using ProyectoPuntoVenta.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPuntoVenta
{
    public partial class ModalProducto : Form
    {

        public int idproducto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string precioventa { get; set; }
        public string stock { get; set; }

        public ModalProducto()
        {
            InitializeComponent();
        }
        private void ModalProducto_Load(object sender, EventArgs e)
        {

            //AGREGAR BOTON ELIMINAR
            DataGridViewButtonColumn BotonProducto = new DataGridViewButtonColumn();
            BotonProducto.HeaderText = "Seleccionar";
            BotonProducto.Width = 80;
            BotonProducto.Text = "";
            BotonProducto.Name = "btnSeleccionar";
            BotonProducto.UseColumnTextForButtonValue = true;

            //AGREGAMOS LOS BOTONES
            dgdataproducto.Columns.Add(BotonProducto);
            dgdataproducto.Columns.Add("Id", "Id");
            dgdataproducto.Columns.Add("Codigo", "Código");
            dgdataproducto.Columns.Add("Nombre", "Nombre");
            dgdataproducto.Columns.Add("Descripcion", "Descripción");
            dgdataproducto.Columns.Add("Categoria", "Categoria");
            dgdataproducto.Columns.Add("Stock", "Stock");
            dgdataproducto.Columns.Add("PrecioVenta", "PrecioVenta");

            dgdataproducto.Columns["btnSeleccionar"].Width = 90;
            dgdataproducto.Columns["Codigo"].Width = 100;
            dgdataproducto.Columns["Nombre"].Width = 200;
            dgdataproducto.Columns["Descripcion"].Width = 210;
            dgdataproducto.Columns["Categoria"].Width = 150;

            dgdataproducto.Columns["Id"].Visible = false;
            dgdataproducto.Columns["PrecioVenta"].Visible = false;

            foreach (DataGridViewColumn cl in dgdataproducto.Columns)
            {
                if (cl.Visible == true && cl.Name != "btnSeleccionar")
                {
                    cbobuscarproducto.Items.Add(new ComboBoxItem() { Value = cl.Name, Text = cl.HeaderText });
                }
            }
            cbobuscarproducto.DisplayMember = "Text";
            cbobuscarproducto.ValueMember = "Value";
            cbobuscarproducto.SelectedIndex = 0;

            foreach (Producto p in ProductoLogica.Instancia.Listar())
            {
                int rowId = dgdataproducto.Rows.Add();
                DataGridViewRow row = dgdataproducto.Rows[rowId];
                row.Cells["Id"].Value = p.IdProducto.ToString();
                row.Cells["Codigo"].Value = p.Codigo;
                row.Cells["Nombre"].Value = p.Nombre;
                row.Cells["Descripcion"].Value = p.Descripcion;
                row.Cells["Categoria"].Value = p.oCategoria.Descripcion;
                row.Cells["Stock"].Value = p.Stock;
                row.Cells["PrecioVenta"].Value = p.PrecioVenta.ToString("0.00", new CultureInfo("es-PE"));
            }
        }

        private void dgdataproducto_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string colname = dgdataproducto.Columns[e.ColumnIndex].Name;
                if (colname != "btnSeleccionar")
                {
                    dgdataproducto.Cursor = Cursors.Default;
                }
                else
                {
                    dgdataproducto.Cursor = Cursors.Hand;
                }
            }
        }

        private void dgdataproducto_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dgdataproducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgdataproducto.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    idproducto = int.Parse(dgdataproducto.Rows[index].Cells["Id"].Value.ToString());
                    codigo = dgdataproducto.Rows[index].Cells["Codigo"].Value.ToString();
                    nombre = dgdataproducto.Rows[index].Cells["Nombre"].Value.ToString();
                    precioventa = dgdataproducto.Rows[index].Cells["PrecioVenta"].Value.ToString();
                    stock = dgdataproducto.Rows[index].Cells["Stock"].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((ComboBoxItem)cbobuscarproducto.SelectedItem).Value.ToString();

            if (dgdataproducto.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdataproducto.Rows)
                {
                    string valor = row.Cells[columnaFiltro].Value.ToString().Trim();

                    if (row.Cells[columnaFiltro].Value.ToString().Trim().Contains(txtbuscarproducto.Text.Trim()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtbuscarproducto.Text = "";
            foreach (DataGridViewRow row in dgdataproducto.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
