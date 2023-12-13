using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CD_PCGerencial
    {
        private MySqlConnection cn;
        public CD_PCGerencial()
        {
            cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ServidorDelosi"].ConnectionString);
        }

        // Listar PC Gerencial
        public List<PCGerencial> listarPCGerencial()
        {
            List<PCGerencial> listado = new List<PCGerencial>();
            MySqlCommand cmd = new MySqlCommand("ListarKDS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PCGerencial usuario = new PCGerencial()
                        {
                            IdPcdGerencial = Convert.ToInt32(dr["IdKds"]),
                            cod_marca = dr["empresa"].ToString(),
                            cod_tienda = dr["marca"].ToString(),
                            tienda = dr["tienda"].ToString(),
                            ip_gerente = dr["nombre_tienda"].ToString(),
                            nom_pc_gerencial = dr["departamento"].ToString(),
                            modelo = dr["provincia"].ToString(),
                            serie = dr["distrito"].ToString(),
                            sistema_operativo = dr["ip_kds"].ToString(),
                            memoria_ram = dr["hostname"].ToString(),
                            procesador = dr["serie"].ToString(),
                            status = Convert.ToBoolean(dr["status"]),
                            flg_stado = dr["flg_stado"].ToString(),
                            usuario_crea = dr["usuario_crea"].ToString(),
                            fecha_crea = dr["fecha_crea"].ToString(),
                            usuario_mod = dr["usuario_mod"].ToString(),
                            fecha_mod = dr["fecha_mod"].ToString()

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

        // Registrar
        public int RegistrarPCGerencial(PCGerencial obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("IngresarKDS", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("marca", obj.cod_marca);
                    cmd.Parameters.AddWithValue("tienda", obj.cod_tienda);
                    cmd.Parameters.AddWithValue("nombre_tienda", obj.tienda);
                    cmd.Parameters.AddWithValue("departamento", obj.ip_gerente);
                    cmd.Parameters.AddWithValue("provincia", obj.nom_pc_gerencial);
                    cmd.Parameters.AddWithValue("distrito", obj.modelo);
                    cmd.Parameters.AddWithValue("ip_kds", obj.serie);
                    cmd.Parameters.AddWithValue("hostname", obj.sistema_operativo);
                    cmd.Parameters.AddWithValue("serie", obj.memoria_ram);
                    cmd.Parameters.AddWithValue("procesador", obj.procesador);
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

        // Editar Editar
        public bool EditarPCGerencial(PCGerencial obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("ActualizarKDS", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("empresa", obj.IdPcdGerencial);
                    cmd.Parameters.AddWithValue("marca", obj.cod_marca);
                    cmd.Parameters.AddWithValue("tienda", obj.cod_tienda);
                    cmd.Parameters.AddWithValue("nombre_tienda", obj.tienda);
                    cmd.Parameters.AddWithValue("departamento", obj.ip_gerente);
                    cmd.Parameters.AddWithValue("provincia", obj.nom_pc_gerencial);
                    cmd.Parameters.AddWithValue("distrito", obj.modelo);
                    cmd.Parameters.AddWithValue("ip_kds", obj.serie);
                    cmd.Parameters.AddWithValue("hostname", obj.sistema_operativo);
                    cmd.Parameters.AddWithValue("serie", obj.memoria_ram);
                    cmd.Parameters.AddWithValue("procesador", obj.procesador);
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

        // Eliminar PCGerencial
        public bool EliminarPCGerencial(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM tb_bhd_gen_pc_gerencial WHERE IdPcdGerencial = @id LIMIT 1", cn))
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