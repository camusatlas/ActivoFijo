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
            MySqlCommand cmd = new MySqlCommand("ListarKDS", cn);
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
                            departamento = dr["departamento"].ToString(),
                            provincia = dr["provincia"].ToString(),
                            distrito = dr["distrito"].ToString(),
                            ip_kds = dr["ip_kds"].ToString(),
                            hostname = dr["hostname"].ToString(),
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
                using (MySqlCommand cmd = new MySqlCommand("IngresarKDS", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("empresa", obj.empresa);
                    cmd.Parameters.AddWithValue("marca", obj.marca);
                    cmd.Parameters.AddWithValue("tienda", obj.tienda);
                    cmd.Parameters.AddWithValue("nombre_tienda", obj.nombre_tienda);
                    cmd.Parameters.AddWithValue("departamento", obj.departamento);
                    cmd.Parameters.AddWithValue("provincia", obj.provincia);
                    cmd.Parameters.AddWithValue("distrito", obj.distrito);
                    cmd.Parameters.AddWithValue("ip_kds", obj.ip_kds);
                    cmd.Parameters.AddWithValue("hostname", obj.hostname);
                    cmd.Parameters.AddWithValue("serie", obj.serie);
                    cmd.Parameters.AddWithValue("status", obj.status);
                    cmd.Parameters.Add("Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
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
                using (MySqlCommand cmd = new MySqlCommand("ActualizarKDS", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdKds", obj.IdKds);
                    cmd.Parameters.AddWithValue("empresa", obj.empresa);
                    cmd.Parameters.AddWithValue("marca", obj.marca);
                    cmd.Parameters.AddWithValue("tienda", obj.tienda);
                    cmd.Parameters.AddWithValue("nombre_tienda", obj.nombre_tienda);
                    cmd.Parameters.AddWithValue("departamento", obj.departamento);
                    cmd.Parameters.AddWithValue("provincia", obj.provincia);
                    cmd.Parameters.AddWithValue("distrito", obj.distrito);
                    cmd.Parameters.AddWithValue("ip_kds", obj.ip_kds);
                    cmd.Parameters.AddWithValue("hostname", obj.hostname);
                    cmd.Parameters.AddWithValue("serie", obj.serie);
                    cmd.Parameters.AddWithValue("status", obj.status);
                    cmd.Parameters.Add("Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

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
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM braintech.tb_bhd_gen_kds WHERE IdKds = @id LIMIT 1", cn))
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