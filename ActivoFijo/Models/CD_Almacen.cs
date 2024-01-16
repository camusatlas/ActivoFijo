using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CD_Almacen
    {
        private SqlConnection cn;
        public CD_Almacen()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ActivoFijo"].ConnectionString);
        }

        // Listar Marca
        public List<Almacen> listar()
        {
            List<Almacen> listado = new List<Almacen>();
            SqlCommand cmd = new SqlCommand("sp_ListarAlmacen", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Almacen almacen = new Almacen()
                        {
                            IdAlmacen = Convert.ToInt32(dr["IdAlmacen"]),
                            NomAlmacen = dr["NomAlmacen"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"])
                        };
                        listado.Add(almacen);
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

        // Crear Almacen
        public int Registrar(Almacen obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarAlmacen", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("NomAlmacen", obj.NomAlmacen);
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
        //Editar Almacen
        public bool Editar(Almacen obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EditarAlmacen", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdAlmacen", obj.IdAlmacen);
                    cmd.Parameters.AddWithValue("NomAlmacen", obj.NomAlmacen);
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

        // Eliminar Almacen
        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarAlmacen", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdAlmacen", id);
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