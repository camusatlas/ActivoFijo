using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CD_Sede
    {
        private SqlConnection cn;
        public CD_Sede()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ActivoFijo"].ConnectionString);
        }

        // Listar Sede
        public List<Sede> listar()
        {
            List<Sede> listado = new List<Sede>();
            SqlCommand cmd = new SqlCommand("ListarSede", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Sede sede = new Sede()
                        {
                            IdSede = Convert.ToInt32(dr["IdSede"]),
                            NomSede = dr["Sede"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"])
                        };
                        listado.Add(sede);
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

        // Registrar Sede
        public int Registrar(Sede obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarSedeUbicacion", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Sede", obj.NomSede);
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

        // Modificar
        public bool Editar(Sede obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarSede", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdSede", obj.IdSede);
                    cmd.Parameters.AddWithValue("Sede", obj.NomSede);
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

        // Eliminar Sede
        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarSede", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdSede", id);
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