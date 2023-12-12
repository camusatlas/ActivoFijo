using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CD_WorkStation
    {
        private MySqlConnection cn;
        public CD_WorkStation()
        {
            cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ServidorDelosi"].ConnectionString);
        }
        public List<WorkStation> listar()
        {
            List<WorkStation> listado = new List<WorkStation>();
            MySqlCommand cmd = new MySqlCommand("ListarServidor", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        WorkStation usuario = new WorkStation()
                        {
                            cod_marca = dr["cod_marca"].ToString(),
                            cod_tienda = dr["cod_tienda"].ToString(),
                            tienda = dr["tienda"].ToString(),
                            caja = dr["caja"].ToString(),
                            ip_workstation = dr["ip_workstation"].ToString(),
                            hostname = dr["hostname"].ToString(),
                            tipo = dr["tipo"].ToString(),
                            modelo = dr["modelo"].ToString(),
                            status = dr["status"].ToString(),
                            ultima_venta = dr["ultima_venta"].ToString(),
                            flg_estado = dr["flg_estado"].ToString(),
                            usuario_crea = dr["usuario_crea"].ToString(),
                            fecha_crea = dr["fecha_crea"].ToString(),
                            usuario_mod = dr["usuario_mod"].ToString(),
                            fecha_mod = dr["fecha_mod"].ToString(),
                            version_facturador = dr["version_facturador"].ToString()

                        };
                        listado.Add(usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return listado;
        }

        // Agregar
        public void RegistrarWorkSation(WorkStation obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("Ing_WorkStation", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cod_marca", obj.cod_marca);
                    cmd.Parameters.AddWithValue("@cod_tienda", obj.cod_tienda);
                    cmd.Parameters.AddWithValue("@tienda", obj.tienda);
                    cmd.Parameters.AddWithValue("@caja", obj.caja);
                    cmd.Parameters.AddWithValue("@ip_workstation", obj.ip_workstation);
                    cmd.Parameters.AddWithValue("@hostname", obj.hostname);

                    cmd.Parameters.Add("@Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    // Obtener el mensaje de salida del procedimiento almacenado
                    Mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }
    }
}