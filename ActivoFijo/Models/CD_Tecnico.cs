using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CD_Tecnico
    {
        private SqlConnection cn;
        public CD_Tecnico()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ActivoFijo"].ConnectionString);
        }

        // Listar Tecnico
        public List<Tecnico> listar()
        {
            List<Tecnico> listado = new List<Tecnico>();
            SqlCommand cmd = new SqlCommand("sp_ListarCliente", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Tecnico tecnico = new Tecnico()
                        {
                            IdTecnico = Convert.ToInt32(dr["IdTecnico"]),
                            Nombres = dr["Nombres"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"])
                        };
                        listado.Add(tecnico);
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

        // Crear Categoria
        public int Registrar(Tecnico obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_RegistroClientes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Nombres", obj.Nombres);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
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
        public bool Editar(Tecnico obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EditarCliente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdTecnico", obj.IdTecnico);
                    cmd.Parameters.AddWithValue("Nombres", obj.Nombres);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
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

        // Eliminar
        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarCliente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdTecnico", id);
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