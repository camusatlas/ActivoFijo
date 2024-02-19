using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CD_MarcaTeinda
    {
        private SqlConnection cn;
        public CD_MarcaTeinda()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ActivoFijo"].ConnectionString);
        }

        // Listar MarcaTeinda
        public List<MarcaTeinda> listar()
        {
            List<MarcaTeinda> listado = new List<MarcaTeinda>();
            SqlCommand cmd = new SqlCommand("ListarCategoria", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MarcaTeinda usuario = new MarcaTeinda()
                        {
                            IdMarcaTienda = dr["IdMarcaTienda"].ToString(),
                            NombreMarca = dr["NombreMarca"].ToString()
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

        public void Registrar(MarcaTeinda obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_RegistroCategoria", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdMarcaTienda", obj.IdMarcaTienda);
                    cmd.Parameters.AddWithValue("NombreMarca", obj.NombreMarca);

                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }
    }
}