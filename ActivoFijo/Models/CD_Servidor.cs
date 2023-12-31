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
        private SqlConnection cn;
        public CD_Servidor()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ActivoFijo"].ConnectionString);
        }

        // Listar Servidores
        public List<Servidor> listar()
        {
            List<Servidor> listado = new List<Servidor>();
            SqlCommand cmd = new SqlCommand("sp_ListarServidor", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
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

        // Funcion Registrar
        public int Registrar(Servidor obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ResgistrarServidor", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("cod_marca", obj.cod_marca);
                    cmd.Parameters.AddWithValue("cod_tienda", obj.cod_tienda);
                    cmd.Parameters.AddWithValue("tienda", obj.tienda);
                    cmd.Parameters.AddWithValue("ip_servidor", obj.ip_servidor);
                    cmd.Parameters.AddWithValue("nom_servidor", obj.nom_servidor);
                    cmd.Parameters.AddWithValue("modelo", obj.modelo);
                    cmd.Parameters.AddWithValue("serie", obj.serie);
                    cmd.Parameters.AddWithValue("sistema_operativo", obj.sistema_operativo);
                    cmd.Parameters.AddWithValue("version_micros", obj.version_micros);
                    cmd.Parameters.AddWithValue("memoria_ram", obj.memoria_ram);
                    cmd.Parameters.AddWithValue("status", obj.status);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

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


        // Editar
        public bool Editar(Servidor obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EditarServidor", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdTienda", obj.IdTienda);
                    cmd.Parameters.AddWithValue("cod_marca", obj.cod_marca);
                    cmd.Parameters.AddWithValue("cod_tienda", obj.cod_tienda);
                    cmd.Parameters.AddWithValue("tienda", obj.tienda);
                    cmd.Parameters.AddWithValue("ip_servidor", obj.ip_servidor);
                    cmd.Parameters.AddWithValue("nom_servidor", obj.nom_servidor);
                    cmd.Parameters.AddWithValue("modelo", obj.modelo);
                    cmd.Parameters.AddWithValue("serie", obj.serie);
                    cmd.Parameters.AddWithValue("sistema_operativo", obj.sistema_operativo);
                    cmd.Parameters.AddWithValue("version_micros", obj.version_micros);
                    cmd.Parameters.AddWithValue("memoria_ram", obj.memoria_ram);
                    cmd.Parameters.AddWithValue("status", obj.status);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

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

        //// Eliminar
        public bool Eliminarservidor(int tienda, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM SERVIDOR WHERE IdTienda = @id", cn))
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