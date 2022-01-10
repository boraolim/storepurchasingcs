using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta.Modelo
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Clave { get; set; }
        public TipoPersona oTipoPersona { get; set; }
        public bool Estado { get; set; }
    }
}
