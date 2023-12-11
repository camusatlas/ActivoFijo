﻿using MySql.Data.MySqlClient;
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
            MySqlCommand cmd = new MySqlCommand("ListarServidor", cn);
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
                            status = dr["status"].ToString(),
                            ultimo_reinicio = dr["ultimo_reinicio"].ToString(),
                            version_facturador = dr["version_facturador"].ToString(),
                            ultima_venta = dr["ultima_venta"].ToString(),
                            flg_estado = dr["flg_estado"].ToString(),
                            usuario_crea = dr["usuario_crea"].ToString(),
                            fecha_crea = dr["fecha_crea"].ToString(),
                            usuario_mod = dr["usuario_mod"].ToString(),
                            fecha_mod = dr["fecha_mod"].ToString(),
                            idtecnico = dr["idtecnico"].ToString(),
                            fecha_asignado = dr["fecha_asignado"].ToString()


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

        // Funcion Registrar
        //public int Registrar(Servidor obj, out string Mensaje)
        //{
        //    int idautogenerado = 0;
        //    Mensaje = string.Empty;
        //    try
        //    {
        //        using (SqlCommand cmd = new SqlCommand("Ing_Servidores", cn))
        //        {


        //            cmd.Parameters.AddWithValue("@cod_marca", obj.cod_marca);
        //            cmd.Parameters.AddWithValue("@cod_tienda", obj.cod_tienda);
        //            cmd.Parameters.AddWithValue("@tienda", obj.tienda);
        //            cmd.Parameters.AddWithValue("@ip_servidor", obj.ip_servidor);
        //            cmd.Parameters.AddWithValue("@nom_servidor", obj.nom_servidor);
        //            cmd.Parameters.AddWithValue("@modelo", obj.modelo);
        //            cmd.Parameters.AddWithValue("@serie", obj.serie);
        //            cmd.Parameters.AddWithValue("@sistema_operativo", obj.sistema_operativo);
        //            cmd.Parameters.AddWithValue("@version_micros", obj.version_micros);
        //            cmd.Parameters.AddWithValue("@memoria_ram", obj.memoria_ram);
        //            cmd.Parameters.AddWithValue("@tamano_bd", obj.tamano_bd);
        //            cmd.Parameters.AddWithValue("@status", obj.status);
        //            cmd.Parameters.AddWithValue("@ultimo_reinicio", obj.ultimo_reinicio);
        //            cmd.Parameters.AddWithValue("@version_facturador", obj.version_facturador);
        //            cmd.Parameters.AddWithValue("@ultima_venta", obj.ultima_venta);
        //            cmd.Parameters.AddWithValue("@flg_estado", obj.flg_estado);
        //            cmd.Parameters.AddWithValue("@usuario_crea", obj.usuario_crea);
        //            cmd.Parameters.AddWithValue("@fecha_crea", obj.fecha_crea);
        //            cmd.Parameters.AddWithValue("@usuario_mod", obj.usuario_mod);
        //            cmd.Parameters.AddWithValue("@fecha_mod", obj.fecha_mod);
        //            cmd.Parameters.AddWithValue("@idtecnico", obj.idtecnico);
        //            cmd.Parameters.AddWithValue("@fecha_asignado", obj.fecha_asignado);

        //            cn.Open();
        //            cmd.ExecuteNonQuery();

        //            idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
        //            Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        idautogenerado = 0;
        //        Mensaje = ex.Message;
        //    }
        //    return idautogenerado;
        //}
        //// Editar
        //public bool Editar(Usuario obj, out string Mensaje)
        //{
        //    bool resultado = false;
        //    Mensaje = string.Empty;
        //    try
        //    {
        //        using (SqlCommand cmd = new SqlCommand("sp_Editar", cn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
        //            cmd.Parameters.AddWithValue("Nombres", obj.Nombres);
        //            cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
        //            cmd.Parameters.AddWithValue("Correo", obj.Correo);
        //            cmd.Parameters.AddWithValue("Activo", obj.Activo);
        //            cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

        //            cn.Open();
        //            cmd.ExecuteNonQuery();

        //            resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
        //            Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado = false;
        //        Mensaje = ex.Message;
        //    }
        //    return resultado;
        //}

        //// Eliminar
        //public bool Eliminar(int id, out string Mensaje)
        //{
        //    bool resultado = false;
        //    Mensaje = string.Empty;
        //    try
        //    {
        //        using (SqlCommand cmd = new SqlCommand("delete top (1) from usuario where IdUsuario = @id", cn))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Parameters.AddWithValue("@id", id);
        //            cn.Open();
        //            resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado = false;
        //        Mensaje = ex.Message;
        //    }
        //    return resultado;
        //}
    }
}