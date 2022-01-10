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
    public partial class frmCompra : Form
    {
        private static int _IdPersona = 0;
        public frmCompra(int IdPersona = 0)
        {
            InitializeComponent();
            _IdPersona = IdPersona;
        }

        private void frmCompra_Load(object sender, EventArgs e)
        {

            //AGREGAR BOTON ELIMINAR
            DataGridViewButtonColumn Boton = new DataGridViewButtonColumn();

            Boton.HeaderText = "Eliminar";
            Boton.Width = 100;
            Boton.Text = "";
            Boton.Name = "btnEliminar";
            Boton.UseColumnTextForButtonValue = true;

            //AGREGAMOS LOS BOTONES
            dgdata.Columns.Add(Boton);
            dgdata.Columns.Add("IdProducto", "IdProducto");
            dgdata.Columns.Add("Codigo", "Codigo");
            dgdata.Columns.Add("NombreProducto", "Nombre Producto");
            dgdata.Columns.Add("Cantidad", "Cantidad");
            dgdata.Columns.Add("PrecioCompra", "Precio Compra");
            dgdata.Columns.Add("PrecioVenta", "Precio Venta");
            dgdata.Columns.Add("SubTotal", "SubTotal");

            dgdata.Columns["btnEliminar"].Width = 100;
            dgdata.Columns["Codigo"].Width = 150;
            dgdata.Columns["NombreProducto"].Width = 200;
            dgdata.Columns["Cantidad"].Width = 100;
            dgdata.Columns["PrecioCompra"].Width = 100;
            dgdata.Columns["SubTotal"].Width = 100;
            dgdata.Columns["IdProducto"].Visible = false;
            dgdata.Columns["PrecioVenta"].Visible = false;



            cbotipodocumento.Items.Add(new ComboBoxItem() { Value = "Boleta", Text = "Boleta" });
            cbotipodocumento.Items.Add(new ComboBoxItem() { Value = "Factura", Text = "Factura" });
            cbotipodocumento.DisplayMember = "Text";
            cbotipodocumento.ValueMember = "Value";
            cbotipodocumento.SelectedIndex = 0;
        }

        private void btnbuscarproveedor_Click(object sender, EventArgs e)
        {
            using (var form = new ModalProveedor())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtnombreproveedor.Text = form.razonsocial;
                    txtdocumentoproveedor.Text = form.documento;
                    txtidproveedor.Text = form.idproveedor.ToString();
                }
            }
        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            using (var form = new ModalProducto())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtcodigoproducto.Text = form.codigo;
                    txtnombreproducto.Text = form.nombre;
                    txtidproducto.Text = form.idproducto.ToString();
                }
            }
        }

        private void txtpreciocompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else {
                if (txtpreciocompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }

            }
                
        }

        private void txtprecioventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtprecioventa.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            decimal preciocompra = 0;
            decimal precioventa = 0;
            decimal subtotal;
            bool producto_existe = false;

            if (int.Parse(txtidproducto.Text) == 0) {
                MessageBox.Show("Debe seleccionar un producto primero", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            bool errorCompra = false;
            bool errorVenta = false;
            try
            {
                preciocompra = Convert.ToDecimal(txtpreciocompra.Text.Trim(), new CultureInfo("es-PE"));
            }
            catch {
                errorCompra = true;
            }

            try
            {
                precioventa = Convert.ToDecimal(txtprecioventa.Text.Trim(), new CultureInfo("es-PE"));
            }
            catch
            {
                errorVenta = true;
            }

            if (errorCompra) {
                MessageBox.Show("Error al convertir el tipo de moneda - Precio Compra\nEjemplo Formato ##.##", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (errorVenta)
            {
                MessageBox.Show("Error al convertir el tipo de moneda - Precio Venta\nEjemplo Formato ##.##", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            foreach (DataGridViewRow fila in dgdata.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtidproducto.Text) {
                    producto_existe = true;
                    break;
                }
            }

            if (!producto_existe) {
                int rowId = dgdata.Rows.Add();
                DataGridViewRow row = dgdata.Rows[rowId];
                subtotal = Convert.ToDecimal(txtcantidad.Text.Trim()) * preciocompra;

                row.Cells["IdProducto"].Value = txtidproducto.Text;
                row.Cells["Codigo"].Value = txtcodigoproducto.Text.Trim();
                row.Cells["NombreProducto"].Value = txtnombreproducto.Text.Trim();
                row.Cells["Cantidad"].Value = txtcantidad.Text.Trim();
                row.Cells["PrecioCompra"].Value = preciocompra.ToString("0.00", new CultureInfo("es-PE"));
                row.Cells["PrecioVenta"].Value = precioventa.ToString("0.00", new CultureInfo("es-PE"));
                row.Cells["SubTotal"].Value = subtotal.ToString("0.00", new CultureInfo("es-PE"));

                limpiarProducto();
                calcularTotal();
            }

           

        }

        public void limpiarProducto() {
            txtidproducto.Text = "0";
            txtcodigoproducto.Text = "";
            txtnombreproducto.Text = "";
            txtcantidad.Value = 1;
            txtpreciocompra.Text = "";
            txtprecioventa.Text = "";
        }


        private void dgdata_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string colname = dgdata.Columns[e.ColumnIndex].Name;
                if (colname != "btnEliminar")
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

                e.Graphics.DrawImage(Properties.Resources.delete32, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgdata.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    dgdata.Rows.RemoveAt(index);
                    calcularTotal();
                }
            }
        }

        private void btnterminarcompra_Click(object sender, EventArgs e)
        {
            if (txtnumerodocumento.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el numero de documento\npara registrar una compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtnumerodocumento.Focus();
                return;
            }

            if (int.Parse(txtidproveedor.Text.Trim()) == 0) {
                MessageBox.Show("Debe seleccionar un proveedor\npara registrar una compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgdata.Rows.Count < 1) {
                MessageBox.Show("Debe ingresar un producto como minimo\npara registrar una compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Compra oCompra = new Compra() {
                oPersona = new Persona() { IdPersona = _IdPersona },
                oProveedor = new Proveedor() { IdProveedor = int.Parse(txtidproveedor.Text.Trim()) },
                MontoTotal = Convert.ToDecimal(lblmontototal.Text, new CultureInfo("es-PE")),
                TipoDocumento = ((ComboBoxItem)cbotipodocumento.SelectedItem).Value.ToString(),
                NumeroDocumento = txtnumerodocumento.Text.Trim()
            };

            List<DetalleCompra> olista = new List<DetalleCompra>();
            if (dgdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdata.Rows)
                {
                    olista.Add(new DetalleCompra() {
                        oProducto = new Producto() {IdProducto = int.Parse(row.Cells["IdProducto"].Value.ToString()) },
                        Cantidad = int.Parse(row.Cells["Cantidad"].Value.ToString()),
                        PrecioCompra = Convert.ToDecimal(row.Cells["PrecioCompra"].Value.ToString(),new CultureInfo("es-PE")),
                        PrecioVenta = Convert.ToDecimal(row.Cells["PrecioVenta"].Value.ToString(), new CultureInfo("es-PE")),
                        Total = Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString(), new CultureInfo("es-PE"))
                    });
                }
            }
            oCompra.oDetalleCompra = olista;


            if (CompraLogica.Instancia.Registrar(oCompra))
            {
                limpiar();
                MessageBox.Show("La compra fue registrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("No se pudo registrar la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void calcularTotal() {

            decimal total = 0;
            if (dgdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgdata.Rows)
                {
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString(), new CultureInfo("es-PE"));
                }
            }

            lblmontototal.Text = total.ToString("0.00", new CultureInfo("es-PE"));

        }

        private void limpiar() {
            limpiarProducto();
            cbotipodocumento.SelectedIndex = 0;
            txtnumerodocumento.Text = "";
            txtdocumentoproveedor.Text = "";
            txtidproveedor.Text = "0";
            txtnombreproveedor.Text = "";
            dgdata.Rows.Clear();
            lblmontototal.Text = "0";
        }

        private void txtcodigoproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Producto pr = ProductoLogica.Instancia.Listar().Where(p => p.Codigo == txtcodigoproducto.Text.Trim()).FirstOrDefault();
                if (pr != null)
                {
                    txtcodigoproducto.Text = pr.Codigo;
                    txtnombreproducto.Text = pr.Nombre;
                    txtidproducto.Text = pr.IdProducto.ToString();
                }

            }
        }
    }
}
