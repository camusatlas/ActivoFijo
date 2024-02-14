using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CD_Carrito
    {
        private SqlConnection cn;
        public CD_Carrito()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ActivoFijo"].ConnectionString);
        }

        public bool ExisteCarrito(int idusuario, int idequipo)
        {
            bool resultado = true;

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_ExisteCarrito", cn))
                {
                    cmd.Parameters.AddWithValue("IdUsuario", idusuario);
                    cmd.Parameters.AddWithValue("IdEquipos", idequipo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
            }
            catch (Exception ex)
            {
                resultado = false;
            }
            return resultado;
        }

        public bool OperacionCarrito(int idusuario, int idequipo, bool sumar, out string Mensaje)
        {
            bool resultado = true;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_OperacionCarrito", cn))
                {


                    cmd.Parameters.AddWithValue("IdUsuario", idusuario);
                    cmd.Parameters.AddWithValue("IdEquipos", idequipo);
                    cmd.Parameters.AddWithValue("Sumar", sumar);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

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

        public int CantidadEnCarrito(int idusuario)
        {
            int resultado = 0;

            try
            {
                using (SqlCommand cmd = new SqlCommand("select count(*) from CARRITO where IdUsuario = @IdUsuario", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdUsuario", idusuario);
                    cn.Open();
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                resultado = 0;
            }
            return resultado;
        }

        public List<Carrito> ListarEquipo(int idusuario)
        {
            List<Carrito> listado = new List<Carrito>();
            SqlCommand cmd = new SqlCommand("sp_ObtenerCarritoUsuario", cn);
            cmd.Parameters.AddWithValue("@IdUsuario", idusuario);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Carrito carrito = new Carrito()
                        {
                            oEquipo = new Equipo()
                            {
                                IdEquipos = Convert.ToInt32(dr["IdEquipos"]),
                                Nombre = dr["Nombre"].ToString(),
                                Precio = Convert.ToDecimal(dr["Precio"], new CultureInfo("es-PE")),
                                RutaImagen = dr["RutaImagen"].ToString(),
                                NombreImagen = dr["NombreImagen"].ToString(),
                                oMarca = new Marca() { Descripcion = dr["DesMarca"].ToString() }
                            }, 
                            Cantidad = Convert.ToInt32(dr["Cantidad"])
                        };
                        listado.Add(carrito);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                cn.Close();
            }
            return listado;
        }

        public bool EliminarCarrito(int idusuario, int idequipo)
        {
            bool resultado = true;

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarCarrito", cn))
                {
                    cmd.Parameters.AddWithValue("IdUsuario", idusuario);
                    cmd.Parameters.AddWithValue("IdEquipos", idequipo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
            }
            catch (Exception ex)
            {
                resultado = false;
            }
            return resultado;
        }
    }
}