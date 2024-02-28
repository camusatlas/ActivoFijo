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
    public class CD_KDS
    {
        private MySqlConnection cn;
        public CD_KDS()
        {
            cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ServidorDelosi"].ConnectionString);
        }

        // Listar KDS
        public List<KDS> listarkds()
        {
            List<KDS> listado = new List<KDS>();
            MySqlCommand cmd = new MySqlCommand("sp_ListarKDS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        KDS usuario = new KDS()
                        {
                            IdKds = Convert.ToInt32(dr["IdKds"]),   
                            empresa = dr["empresa"].ToString(),
                            marca = dr["marca"].ToString(),
                            tienda = dr["tienda"].ToString(),
                            nombre_tienda = dr["nombre_tienda"].ToString(),
                            ip_kds = dr["ip_kds"].ToString(),
                            hostname = dr["hostname"].ToString(),
                            modelo = dr["modelo"].ToString(),
                            serie = dr["serie"].ToString(),
                            status = Convert.ToBoolean(dr["status"]),

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

        // Actualizar KDS
        public int Registrar(KDS obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarKDS", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_empresa", obj.empresa);
                    cmd.Parameters.AddWithValue("p_marca", obj.marca);
                    cmd.Parameters.AddWithValue("p_tienda", obj.tienda);
                    cmd.Parameters.AddWithValue("p_nombre_tienda", obj.nombre_tienda);
                    cmd.Parameters.AddWithValue("p_ip_kds", obj.ip_kds);
                    cmd.Parameters.AddWithValue("p_hostname", obj.hostname);
                    cmd.Parameters.AddWithValue("p_modelo", obj.modelo);
                    cmd.Parameters.AddWithValue("p_serie", obj.serie);
                    cmd.Parameters.AddWithValue("p_status", obj.status);
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["p_Resultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;
            }
            return idautogenerado;
        }

        // Editar KDS
        public bool Editar(KDS obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_EditarKDS", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_IdKds", obj.IdKds);
                    cmd.Parameters.AddWithValue("p_empresa", obj.empresa);
                    cmd.Parameters.AddWithValue("p_marca", obj.marca);
                    cmd.Parameters.AddWithValue("p_tienda", obj.tienda);
                    cmd.Parameters.AddWithValue("p_nombre_tienda", obj.nombre_tienda);
                    cmd.Parameters.AddWithValue("p_ip_kds", obj.ip_kds);
                    cmd.Parameters.AddWithValue("p_hostname", obj.hostname);
                    cmd.Parameters.AddWithValue("p_modelo", obj.modelo);
                    cmd.Parameters.AddWithValue("p_serie", obj.serie);
                    cmd.Parameters.AddWithValue("p_status", obj.status);
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["p_Resultado"].Value);
                    Mensaje = cmd.Parameters["p_Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        // Eliminar KDS
        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM tb_bhd_gen_kds WHERE IdKds = @id", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }
    }
}