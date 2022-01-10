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
    public partial class ImprimirVenta : Form
    {

        StringBuilder linea = new StringBuilder();
        int maxCant = 50;
        int _IdVenta;

        public ImprimirVenta(int idventa = 0)
        {
            InitializeComponent();
            _IdVenta = idventa;
        }

        private void AgregarCaracter(string c) {
            string texto = "";
            for (int i = 0; i < maxCant; i++)
            {
                texto += c;
            }
            linea.AppendLine(texto);
        }

        private void AgregarTextoCentro(string texto) {

            if (texto.Length > maxCant)
            {

            }
            else {
                decimal agregarespacio = Math.Truncate(Convert.ToDecimal((maxCant - texto.Length) / 2));
                string espacios = "";
                for (int i = 0; i< agregarespacio; i++) {
                    espacios += " ";
                }
                linea.AppendLine(espacios + texto);
            }
        }

        private void AgregarDosColumnas(string texto1, string texto2) {
            int cantidadtexto = texto1.Length + texto2.Length;
            if (cantidadtexto > maxCant)
            {

            }
            else {
                int cantidadespacio = maxCant - cantidadtexto;
                string espacios = "";
                for (int i = 0; i < cantidadespacio; i++)
                {
                    espacios += " ";
                }
                linea.AppendLine(texto1 + espacios + texto2);
            }

        }

        private void ImprimirVenta_Load(object sender, EventArgs e)
        {
            string tickettexto = Properties.Resources.Ticket.ToString();
            Tienda otienda = TiendaLogica.Instancia.Obtener();
            Venta oVenta = VentaLogica.Instancia.ListarVenta().Where(v => v.IdVenta == _IdVenta).FirstOrDefault();
            List<DetalleVenta> oDetalleVenta = VentaLogica.Instancia.ListarDetalleVenta().Where(dv => dv.IdVenta == _IdVenta).ToList();

            tickettexto = tickettexto.Replace("¡nombreempresa!", otienda.RazonSocial.ToUpper());
            tickettexto = tickettexto.Replace("¡documentoempresa!", otienda.Documento);
            tickettexto = tickettexto.Replace("¡correoempresa!",otienda.Correo);
            tickettexto = tickettexto.Replace("!telefonoempresa¡", otienda.Telefono);

            tickettexto = tickettexto.Replace("¡tipodocumento!", oVenta.TipoDocumento);
            tickettexto = tickettexto.Replace("¡numerodocumento!", oVenta.NumeroDocumento);
            tickettexto = tickettexto.Replace("¡fechaventa!", oVenta.FechaRegistro);

            StringBuilder tr = new StringBuilder();
            foreach (DetalleVenta dv in oDetalleVenta) {
                tr.AppendLine("<tr>");
                tr.AppendLine("<td width=\"20\">" + dv.Cantidad + "</td>");
                tr.AppendLine("<td width=\"180\">" + dv.oProducto.Nombre + "</td>");
                tr.AppendLine("<td style=\"font-size:14px\">" + dv.PrecioVenta.ToString("0.00", new CultureInfo("es-PE")) + "</td>");
                tr.AppendLine("<td style=\"font-size:14px\">" + dv.SubTotal.ToString("0.00", new CultureInfo("es-PE")) + "</td>");
                tr.AppendLine("</tr>");
            }
            tickettexto = tickettexto.Replace("¡detalleventa!", tr.ToString());

            tickettexto = tickettexto.Replace("¡totalpagar!", oVenta.TotalPagar.ToString("0.00", new CultureInfo("es-PE")));
            tickettexto = tickettexto.Replace("¡pagocon!", oVenta.PagoCon.ToString("0.00", new CultureInfo("es-PE")));
            tickettexto = tickettexto.Replace("¡cambio!", oVenta.Cambio.ToString("0.00", new CultureInfo("es-PE")));

            webBrowser1.DocumentText = tickettexto;


        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintDialog();
        }
    }
}
