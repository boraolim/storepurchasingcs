using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta.Modelo
{
    public class DetalleCompra
    {
        public int IdDetalleCompra { get; set; }
        public Producto oProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Total { get; set; }
    }
}
