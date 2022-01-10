using ProyectoPuntoVenta.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta.Logica
{
    public class VentaLogica
    {
        private static VentaLogica instancia = null;

        public VentaLogica()
        {

        }

        public static VentaLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new VentaLogica();
                }
                return instancia;
            }
        }

        public List<Venta> ListarVenta() {
            List<Venta> Lista = new List<Venta>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT IdVenta, TipoDocumento,NumeroDocumento,DocumentoCliente,NombreCliente,TotalPagar,PagoCon,Cambio,CONVERT(char(10),FechaRegistro,103)[FechaRegistro] FROM VENTA");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new Venta()
                            {
                                IdVenta = Convert.ToInt32(dr["IdVenta"].ToString()),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                TotalPagar = Convert.ToDecimal(dr["TotalPagar"],new CultureInfo("es-PE")),
                                PagoCon = Convert.ToDecimal(dr["PagoCon"], new CultureInfo("es-PE")),
                                Cambio = Convert.ToDecimal(dr["Cambio"], new CultureInfo("es-PE")),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Lista = new List<Venta>();
                }
            }
            return Lista;
        }


        public List<DetalleVenta> ListarDetalleVenta()
        {
            List<DetalleVenta> Lista = new List<DetalleVenta>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("select dv.IdVenta,p.Nombre,dv.Cantidad,dv.PrecioVenta,dv.SubTotal from DETALLE_VENTA dv");
                    sb.AppendLine("inner join PRODUCTO P on p.IdProducto = dv.IdProducto");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new DetalleVenta()
                            {
                                IdVenta = Convert.ToInt32(dr["IdVenta"].ToString()),
                                oProducto = new Producto() { Nombre = dr["Nombre"].ToString() },
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"], new CultureInfo("es-PE")),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"], new CultureInfo("es-PE"))
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Lista = new List<DetalleVenta>();
                }
            }
            return Lista;
        }


        public bool ControlStock(int idproducto,int cantidad, bool restar)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    string query = string.Format("update producto set Stock = (Stock {0} {1}) where IdProducto = {2}", restar ? "-" : "+", cantidad, idproducto);
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }

            return respuesta;

        }


        public int Registrar(Venta objeto)
        {
            int respuesta = 0;

            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    oConexion.Open();
                    SqlTransaction objTransacion = oConexion.BeginTransaction();


                    sb.AppendLine("declare @idventa int = 0");
                    sb.AppendLine(string.Format("insert into VENTA(TipoDocumento,NumeroDocumento,IdUsuario,DocumentoCliente,NombreCliente,TotalPagar,PagoCon,Cambio) values('{0}',({1}),{2},'{3}','{4}','{5}','{6}','{7}')"
                        , objeto.TipoDocumento
                        , "select right('000000' + cast((select count(*) + 1 from venta) as varchar), 6)"
                        , objeto.oPersona.IdPersona
                        , objeto.DocumentoCliente
                        , objeto.NombreCliente
                        , objeto.TotalPagar.ToString("0.00", new CultureInfo("es-PE"))
                        , objeto.PagoCon.ToString("0.00", new CultureInfo("es-PE"))
                        , objeto.Cambio.ToString("0.00", new CultureInfo("es-PE"))));

                    sb.AppendLine("set @idventa = SCOPE_IDENTITY()");
                    foreach (DetalleVenta dv in objeto.oDetalleVenta)
                    {
                        sb.AppendLine(string.Format("insert into DETALLE_VENTA(IdVenta,IdProducto,Cantidad,PrecioVenta,SubTotal) values({0},{1},{2},'{3}','{4}')",
                            "@idventa", dv.oProducto.IdProducto, dv.Cantidad, dv.PrecioVenta.ToString("0.00", new CultureInfo("es-PE")), dv.SubTotal.ToString("0.00", new CultureInfo("es-PE"))));
                    }
                    sb.AppendLine("select @idventa");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = objTransacion;
                    try
                    {
                        int idventa = 0;
                        int.TryParse(cmd.ExecuteScalar().ToString(), out idventa);

                        if (idventa != 0)
                        {
                            objTransacion.Commit();
                            respuesta = idventa;
                        }
                        else
                        {
                            objTransacion.Rollback();
                            respuesta = idventa;
                        }

                    }
                    catch (Exception e)
                    {
                        objTransacion.Rollback();
                        respuesta = 0;
                    }

                }
                catch (Exception ex)
                {
                    respuesta = 0;
                }
            }
            return respuesta;
        }

        public DataTable Reporte(string fechainicio , string fechafin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SET DATEFORMAT dmy");
                    sb.AppendLine("select convert(char(10),v.FechaRegistro,103)[Fecha Venta],v.TipoDocumento,v.NumeroDocumento,p.Documento[Documento Vendedor],p.Nombre[Nombre Vendedor],v.DocumentoCliente,v.NombreCliente,");
                    sb.AppendLine("convert(varchar(10),v.TotalPagar)[Total Pagar],convert(varchar(10),v.PagoCon)[Pago Con],convert(varchar(10),v.Cambio)[Cambio]   from VENTA v");
                    sb.AppendLine("inner join persona p on p.IdPersona = v.IdUsuario");
                    sb.AppendLine("where convert(date,v.FechaRegistro) between @fechainicio and @fechafin");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("@fechafin", fechafin);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    dt = new DataTable();
                }
            }
            return dt;

        }

    }
}
