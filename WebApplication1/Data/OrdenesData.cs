using Microsoft.Data.SqlClient;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class OrdenesData
    {
        public static bool Agregar(Ordenes oOrdenes)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("pa_agregar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mesId", oOrdenes.mes_id);
                cmd.Parameters.AddWithValue("@catOrdId", oOrdenes.ord_fecha_inicio);
                cmd.Parameters.AddWithValue("@ordFechaInicio", oOrdenes.catord_id);
                cmd.Parameters.AddWithValue("@ordEstatus", oOrdenes.ord_estatus);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        public static bool Actualizar(Ordenes oOrdenes)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("pa_actualizarOrden", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ordId", oOrdenes.ord_id);
                cmd.Parameters.AddWithValue("@ordEstatus", oOrdenes.ord_estatus);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        public static List<Mesas> Listar()
        {
            List<Mesas> oListarMesas = new List<Mesas>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("pa_obtenerMesasTotales", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListarMesas.Add(new Mesas()
                            {
                                mes_id = Convert.ToInt32(dr["mes_id"]),
                                mes_lugares = Convert.ToInt32(dr["mes_lugares"]),
                                mes_disponible = Convert.ToInt32(dr["mes_disponible"]),
                                mes_estatus = Convert.ToInt32(dr["mes_estatus"])
                            });
                        }
                    }

                    return oListarMesas;

                }                    
                catch (Exception ex)
                {
                    return oListarMesas;
                }
            }
        }


        public static Ordenes Obtener(int ord_id)
        {
            Ordenes oOrdenes = new Ordenes();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("pa_obtenerOrdenesTotales", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ordId", ord_id);

                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oOrdenes = new Ordenes()
                            {
                                ord_id = Convert.ToInt32(dr["ord_id"]),
                                mes_id = Convert.ToInt32(dr["mes_id"]),
                                catord_id = Convert.ToInt32(dr["catord_id"]),
                                ord_fecha_inicio = Convert.ToDateTime(dr["ord_fecha_inicio"].ToString()),
                                ord_estatus = Convert.ToInt32(dr["ord_estatus"])
                            };
                        }
                    }

                    return oOrdenes;

                }
                catch (Exception ex)
                {
                    return oOrdenes;
                }
            }
        }
    }
}
