using ClosedXML.Excel;
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
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }
        DataTable dtventa = new DataTable();
        DataTable dtcompra = new DataTable();
        DataTable dtproducto = new DataTable();

        private void frmReporte_Load(object sender, EventArgs e)
        {
            cboproveedor.Items.Add(new ComboBoxItem() { Value = "0", Text = "Todos" });
            foreach (Proveedor pr in ProveedorLogica.Instancia.Listar()) {
                cboproveedor.Items.Add(new ComboBoxItem() { Value = pr.IdProveedor, Text = pr.RazonSocial });
            }
            cboproveedor.DisplayMember = "Text";
            cboproveedor.ValueMember = "Value";
            cboproveedor.SelectedIndex = 0;


            cbocategoria.Items.Add(new ComboBoxItem() { Value = "0", Text = "Todos" });
            foreach (Categoria c in CategoriaLogica.Instancia.Listar())
            {
                cbocategoria.Items.Add(new ComboBoxItem() { Value = c.IdCategoria, Text = c.Descripcion });
            }
            cbocategoria.DisplayMember = "Text";
            cbocategoria.ValueMember = "Value";
            cbocategoria.SelectedIndex = 0;
        }

        private void btnexportarventa_Click(object sender, EventArgs e)
        {
            if (dgdataventa.Rows.Count > 0)
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Reporte_Venta_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files|*.xlsx";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string informe = "Informe";
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dtventa, informe);
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("No existen datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnconsultarventa_Click(object sender, EventArgs e)
        {
            dtventa = VentaLogica.Instancia.Reporte(txtfechainicio.Value.ToString("dd/MM/yyyy"), txtfechafin.Value.ToString("dd/MM/yyyy"));
            if (dtventa != null)
            {
                dgdataventa.DataSource = dtventa;
            }
        }

        private void btnconsultarcompras_Click(object sender, EventArgs e)
        {
            dtcompra = CompraLogica.Instancia.Reporte(((ComboBoxItem)cboproveedor.SelectedItem).Value.ToString(), txtfechainiciocompra.Value.ToString("dd/MM/yyyy"), txtfechafincompra.Value.ToString("dd/MM/yyyy"));
            if (dtcompra != null)
            {
                dgdatacompra.DataSource = dtcompra;
            }
        }

        private void btnexportarcompras_Click(object sender, EventArgs e)
        {
            if (dgdatacompra.Rows.Count > 0)
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Reporte_Compra_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files|*.xlsx";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dtcompra, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("No existen datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnconsultarproducto_Click(object sender, EventArgs e)
        {
            dtproducto = ProductoLogica.Instancia.Reporte(((ComboBoxItem)cbocategoria.SelectedItem).Value.ToString());
            if (dtproducto != null)
            {
                dgdataproducto.DataSource = dtproducto;
            }
            
        }

        private void btnexportarproducto_Click(object sender, EventArgs e)
        {
            if (dgdataproducto.Rows.Count > 0)
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Reporte_Producto_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files|*.xlsx";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dtproducto, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("No existen datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
