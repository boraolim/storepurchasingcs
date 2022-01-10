
using ProyectoPuntoVenta.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta.Logica
{
    class TiendaLogica
    {
        private static TiendaLogica instancia = null;

        public TiendaLogica()
        {

        }

        public static TiendaLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new TiendaLogica();
                }

                return instancia;
            }
        }

        public Tienda Obtener()
        {
            Tienda objeto = new Tienda();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT IdTienda,Documento,RazonSocial,Correo,Telefono FROM TIENDA where idtienda = 1", oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objeto = new Tienda()
                            {
                                Documento = dr["Documento"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString()
                            };
                        }
                    }

                }
                catch (Exception ex)
                {
                    objeto = new Tienda();
                }
            }
            return objeto;
        }

        public bool Modificar(Tienda objeto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("update TIENDA set Documento = @Documento,");
                    sb.AppendLine("RazonSocial = @RazonSocial,");
                    sb.AppendLine("Correo = @Correo,");
                    sb.AppendLine("Telefono = @Telefono");
                    sb.AppendLine("where IdTienda = 1");
                    
                    using (SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion)) {
                        cmd.Parameters.AddWithValue("@Documento", objeto.Documento);
                        cmd.Parameters.AddWithValue("@RazonSocial", objeto.RazonSocial);
                        cmd.Parameters.AddWithValue("@Correo", objeto.Correo);
                        cmd.Parameters.AddWithValue("@Telefono", objeto.Telefono);
                        cmd.CommandType = CommandType.Text;
                        oConexion.Open();
                        cmd.ExecuteNonQuery();
                        respuesta = true;
                    }
                        
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }
    }
}
