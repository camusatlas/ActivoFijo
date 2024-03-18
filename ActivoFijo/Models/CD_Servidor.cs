using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ActivoFijo.Models
{
    public class CD_Servidor
    {
        private MySqlConnection cn;
        public CD_Servidor()
        {
            cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ServidorDelosi"].ConnectionString);
        }

        // Listar Servidores
        public List<Servidor> listar()
        {
            List<Servidor> listado = new List<Servidor>();
            MySqlCommand cmd = new MySqlCommand("sp_ListarServidor", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Servidor usuario = new Servidor()
                        {
                            IdTienda = Convert.ToInt32(dr["IdTienda"]),
                            cod_marca = dr["cod_marca"].ToString(),
                            cod_tienda = dr["cod_tienda"].ToString(),
                            tienda = dr["tienda"].ToString(),
                            ip_servidor = dr["ip_servidor"].ToString(),
                            nom_servidor = dr["nom_servidor"].ToString(),
                            modelo = dr["modelo"].ToString(),
                            serie = dr["serie"].ToString(),
                            sistema_operativo = dr["sistema_operativo"].ToString(),
                            version_micros = dr["version_micros"].ToString(),
                            memoria_ram = dr["memoria_ram"].ToString(),
                            tamano_bd = dr["tamano_bd"].ToString(),
                            usuarioregistro = dr["UsuarioRegistro"].ToString(),
                            usuarioactualizacion = dr["UsuarioActualizacion"].ToString(),
                            fecha_registro = dr["FechaRegistro"].ToString(),
                            fecha_actualizada = dr["FechaActualizacion"].ToString(),
                            ultimo_reinicio = dr["ultimo_reinicio"].ToString(),
                            version_facturador = dr["version_facturador"].ToString(),
                            ultima_venta = dr["ultima_venta"].ToString(),
                            flg_estado = dr["flg_estado"].ToString(),
                            usuario_crea = dr["usuario_crea"].ToString(),
                            fecha_crea = dr["fecha_crea"].ToString(),
                            usuario_mod = dr["usuario_mod"].ToString(),
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

        // Detalle
        public Servidor Detalle(int idTienda)
        {
            Servidor servidor = null;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_DetalleServidor", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_IdTienda", idTienda);

                    cn.Open();
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            servidor = new Servidor()
                            {
                                IdTienda = Convert.ToInt32(dr["IdTienda"]),
                                cod_marca = dr["cod_marca"].ToString(),
                                cod_tienda = dr["cod_tienda"].ToString(),
                                tienda = dr["tienda"].ToString(),
                                ip_servidor = dr["ip_servidor"].ToString(),
                                nom_servidor = dr["nom_servidor"].ToString(),
                                modelo = dr["modelo"].ToString(),
                                serie = dr["serie"].ToString(),
                                sistema_operativo = dr["sistema_operativo"].ToString(),
                                version_micros = dr["version_micros"].ToString(),
                                memoria_ram = dr["memoria_ram"].ToString(),
                                tamano_bd = dr["tamano_bd"].ToString(),
                                usuarioregistro = dr["UsuarioRegistro"].ToString(),
                                usuarioactualizacion = dr["UsuarioActualizacion"].ToString(),
                                fecha_registro = dr["FechaRegistro"].ToString(),
                                fecha_actualizada = dr["FechaActualizacion"].ToString(),
                                ultimo_reinicio = dr["ultimo_reinicio"].ToString(),
                                version_facturador = dr["version_facturador"].ToString(),
                                ultima_venta = dr["ultima_venta"].ToString(),
                                flg_estado = dr["flg_estado"].ToString(),
                                usuario_crea = dr["usuario_crea"].ToString(),
                                fecha_crea = dr["fecha_crea"].ToString(),
                                usuario_mod = dr["usuario_mod"].ToString(),
                                status = Convert.ToBoolean(dr["status"])
                            };
                        }
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
            return servidor;
        }

        // Funcion Registrar
        public int Registrar(Servidor obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ResgistrarServidor", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_cod_marca", obj.cod_marca);
                    cmd.Parameters.AddWithValue("p_cod_tienda", obj.cod_tienda);
                    cmd.Parameters.AddWithValue("p_tienda", obj.tienda);
                    cmd.Parameters.AddWithValue("p_ip_servidor", obj.ip_servidor);
                    cmd.Parameters.AddWithValue("p_nom_servidor", obj.nom_servidor);
                    cmd.Parameters.AddWithValue("p_modelo", obj.modelo);
                    cmd.Parameters.AddWithValue("p_serie", obj.serie);
                    cmd.Parameters.AddWithValue("p_sistema_operativo", obj.sistema_operativo);
                    cmd.Parameters.AddWithValue("p_version_micros", obj.version_micros);
                    cmd.Parameters.AddWithValue("p_memoria_ram", obj.memoria_ram);
                    cmd.Parameters.AddWithValue("p_status", obj.status);
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;

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


        // Editar
        public bool Editar(Servidor obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_EditarServidor", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_IdTienda", obj.IdTienda);
                    cmd.Parameters.AddWithValue("p_cod_marca", obj.cod_marca);
                    cmd.Parameters.AddWithValue("p_cod_tienda", obj.cod_tienda);
                    cmd.Parameters.AddWithValue("p_tienda", obj.tienda);
                    cmd.Parameters.AddWithValue("p_ip_servidor", obj.ip_servidor);
                    cmd.Parameters.AddWithValue("p_nom_servidor", obj.nom_servidor);
                    cmd.Parameters.AddWithValue("p_modelo", obj.modelo);
                    cmd.Parameters.AddWithValue("p_serie", obj.serie);
                    cmd.Parameters.AddWithValue("p_sistema_operativo", obj.sistema_operativo);
                    cmd.Parameters.AddWithValue("p_version_micros", obj.version_micros);
                    cmd.Parameters.AddWithValue("p_memoria_ram", obj.memoria_ram);
                    cmd.Parameters.AddWithValue("p_flg_estado", obj.flg_estado);
                    cmd.Parameters.AddWithValue("p_UsuarioRegistro", obj.usuarioregistro);
                    cmd.Parameters.AddWithValue("p_UsuarioActualizacion", obj.usuarioactualizacion);
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

        //// Eliminar
        public bool Eliminarservidor(int tienda, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM tb_bhd_gen_servidor WHERE IdTienda = @id", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", tienda);
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