using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CD_Modelo
    {
        private SqlConnection cn;
        public CD_Modelo()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ActivoFijo"].ConnectionString);
        }

        // Listar Modelo
        public List<Modelo> listar()
        {
            List<Modelo> listado = new List<Modelo>();
            SqlCommand cmd = new SqlCommand("sp_ListarModelo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Modelo modelo = new Modelo()
                        {
                            IdModelo = Convert.ToInt32(dr["IdModelo"]),
                            NomModelo = dr["NomModelo"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"])
                        };
                        listado.Add(modelo);
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

        // Crear Modelo
        public int Registrar(Modelo obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarModelo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("NomModelo", obj.NomModelo);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

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

        //Editar Modelo
        public bool Editar(Modelo obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EditarModelo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdModelo", obj.IdModelo);
                    cmd.Parameters.AddWithValue("NomModelo", obj.NomModelo);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

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

        // Eliminar Modelo
        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarModelo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdModelo", id);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

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
    }
}