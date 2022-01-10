using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta.Modelo
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public Persona oPersona { get; set; }
        public Proveedor oProveedor { get; set; }
        public decimal MontoTotal { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public List<DetalleCompra> oDetalleCompra { get; set; }
    }
}
