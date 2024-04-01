using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CD_Venta
    {
        private MySqlConnection cn;
        public CD_Venta()
        {
            cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ServidorDelosiInventario"].ConnectionString);
        }

        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("usp_RegistrarVenta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("p_TotalProducto", obj.TotalProducto);
                    cmd.Parameters.AddWithValue("p_MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("p_IdTienda", obj.IdTienda);
                    cmd.Parameters.AddWithValue("p_IdTecnico", obj.IdTecnico);
                    cmd.Parameters.AddWithValue("p_Ticket", obj.Ticket);
                    cmd.Parameters.AddWithValue("p_GuiaSalida", obj.GuiaSalida);
                    cmd.Parameters.AddWithValue("p_IdTransaccion", obj.IdTransaccion);
                    cmd.Parameters.AddWithValue("DETALLE_ASIGNACION", DetalleVenta);
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["p_Resultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }

    }
}