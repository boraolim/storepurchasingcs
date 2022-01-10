using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta.Modelo
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public Persona oPersona { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public decimal TotalPagar { get; set; }
        public decimal PagoCon { get; set; }
        public decimal Cambio { get; set; }
        public string FechaRegistro { get; set; }
        public List<DetalleVenta> oDetalleVenta { get; set; }
    }
}
