using Irony.Parsing;
using MySql.Data.MySqlClient;
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
        private MySqlConnection cn;
        public CD_Carrito()
        {
            cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ServidorDelosiInventario"].ConnectionString);
        }

        public bool ExisteCarrito(int idusuario, int idequipo)
        {
            bool resultado = true;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_ExisteCarrito", cn))
                {
                    cmd.Parameters.AddWithValue("p_IdUsuario", idusuario);
                    cmd.Parameters.AddWithValue("p_IdEquipos", idequipo);
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["p_Resultado"].Value);
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
                using (MySqlCommand cmd = new MySqlCommand("sp_OperacionCarrito", cn))
                {


                    cmd.Parameters.AddWithValue("p_IdUsuario", idusuario);
                    cmd.Parameters.AddWithValue("p_IdEquipos", idequipo);
                    cmd.Parameters.AddWithValue("p_Sumar", sumar);
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

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

        public int CantidadEnCarrito(int idusuario)
        {
            int resultado = 0;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("select count(*) from CARRITO where IdUsuario = @IdUsuario", cn))
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
                using (MySqlCommand cmd = new MySqlCommand("sp_ObtenerCarritoUsuario", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_IdUsuario", idusuario);

                    try
                    {
                        cn.Open();
                        using (MySqlDataReader dr = cmd.ExecuteReader())
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
                                        NombreImagen = dr["NombreImgen"].ToString(),
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
                        // También puedes lanzar una excepción aquí o manejarla de otra manera.
                    }
                }
            return listado;
        }

        public bool EliminarCarrito(int idusuario, int idequipo)
        {
            bool resultado = true;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_EliminarCarrito", cn))
                {
                    cmd.Parameters.AddWithValue("p_IdUsuario", idusuario);
                    cmd.Parameters.AddWithValue("p_IdEquipos", idequipo);
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["p_Resultado"].Value);
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