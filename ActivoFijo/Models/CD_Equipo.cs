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
    public class CD_Equipo
    {
        private MySqlConnection cn;
        public CD_Equipo()
        {
            cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ServidorDelosiInventario"].ConnectionString);
        }

        // Listar Producto
        public List<Equipo> listar()
        {
            List<Equipo> listado = new List<Equipo>();
            MySqlCommand cmd = new MySqlCommand("sp_ListarEquipo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Equipo equipo = new Equipo()
                        {
                            IdEquipos = Convert.ToInt32(dr["IdEquipos"]),
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            oMarca = new Marca() { IdMarca = Convert.ToInt32(dr["IdMarca"]), Descripcion = dr["DesMarca"].ToString() },
                            oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(dr["IdCategoria"]), Descripcion = dr["DesCategoria"].ToString() },
                            Precio = Convert.ToDecimal(dr["Precio"], new CultureInfo("es-PE")),
                            oSede = new Sede() { IdSede = Convert.ToInt32(dr["IdSede"]), NomSede = dr["Sede"].ToString() },
                            oModelo = new Modelo() { IdModelo = Convert.ToInt32(dr["IdModelo"]), NomModelo = dr["Modeslo"].ToString() },
                            Serie = dr["Serie"].ToString(),
                            CodInventario = dr["CodInventario"].ToString(),
                            oRazonSocial = new RazonSocial() { IdRazonSocial = Convert.ToInt32(dr["IdRazonSocial"]), NomRazonSocial = dr["NomRazonSocial"].ToString() },
                            Usuario = dr["Usuario"].ToString(),
                            Stock = Convert.ToInt32(dr["Stock"]),
                            GuiaIngreso = dr["GuiaIngreso"].ToString(),
                            oProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(dr["IdProveedor"]), NomProveedor = dr["Proveedor"].ToString() },
                            OrdenCompra = dr["OrdenCompra"].ToString(),
                            OrdenInterna = dr["OrdenInterna"].ToString(),
                            ActivoFijo = dr["ActivoFijo"].ToString(),
                            oAlmacen = new Almacen() { IdAlmacen = Convert.ToInt32(dr["IdAlmacen"]), NomAlmacen = dr["Almacen"].ToString() },
                            CodMaterialSAP = dr["CodMaterialSAP"].ToString(),
                            oPrioridad = new Prioridad() { IdPrioridades = Convert.ToInt32(dr["IdPrioridades"]), NomPrioridad = dr["Nivel-Prioridad"].ToString() },
                            oSistema = new SistemaOperativo() { IdSistema = Convert.ToInt32(dr["IdSistema"]), NombreSistema = dr["SistemaOperativo"].ToString() },
                            DireccionMac = dr["DireccionMac"].ToString(),
                            NombreImagen = dr["NombreImgen"].ToString(),
                            RutaImagen = dr["RutaImagen"].ToString(),
                            FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"]),
                            FechaGarantia = Convert.ToDateTime(dr["FechaGarantia"]),
                            Onservacion = dr["Observacion"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"])
                        };
                        listado.Add(equipo);
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
        // Registrar Equipo
        public int Registrar(Equipo obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_RegistrarEquipo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("p_Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("p_IdMarca", obj.oMarca.IdMarca);
                    cmd.Parameters.AddWithValue("p_IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("p_Precio", obj.Precio);
                    cmd.Parameters.AddWithValue("p_IdSede", obj.oSede.IdSede);
                    cmd.Parameters.AddWithValue("p_IdModelo", obj.oModelo.IdModelo);
                    cmd.Parameters.AddWithValue("p_Serie", obj.Serie);
                    cmd.Parameters.AddWithValue("p_CodInventario", obj.CodInventario);
                    cmd.Parameters.AddWithValue("p_Usuario", obj.Usuario);
                    cmd.Parameters.AddWithValue("p_IdRazonSocial", obj.oRazonSocial.IdRazonSocial);
                    cmd.Parameters.AddWithValue("p_GuiaIngreso", obj.GuiaIngreso);
                    cmd.Parameters.AddWithValue("p_IdProveedor", obj.oProveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("p_OrdenCompra", obj.OrdenCompra);
                    cmd.Parameters.AddWithValue("p_OrdenInterna", obj.OrdenInterna);
                    cmd.Parameters.AddWithValue("p_ActivoFijo", obj.ActivoFijo);
                    cmd.Parameters.AddWithValue("p_IdAlmacen", obj.oAlmacen.IdAlmacen);
                    cmd.Parameters.AddWithValue("p_CodMaterialSAP", obj.CodMaterialSAP);
                    cmd.Parameters.AddWithValue("p_Stock", obj.Stock);
                    cmd.Parameters.AddWithValue("p_IdPrioridades", obj.oPrioridad.IdPrioridades);
                    cmd.Parameters.AddWithValue("p_IdSistema", obj.oSistema.IdSistema);
                    cmd.Parameters.AddWithValue("p_DireccionMac", obj.DireccionMac);
                    cmd.Parameters.AddWithValue("p_FechaGarantia", obj.FechaGarantia);
                    cmd.Parameters.AddWithValue("p_FechaActualizacion", obj.FechaActualizacion);
                    cmd.Parameters.AddWithValue("p_Observacion", obj.Onservacion);
                    cmd.Parameters.AddWithValue("p_Activo", obj.Activo);
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

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

        //Editar Equipo
        public bool Editar(Equipo obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_EditarEquipo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_IdEquipos", obj.IdEquipos);
                    cmd.Parameters.AddWithValue("p_Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("p_Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("p_IdMarca", obj.oMarca.IdMarca);
                    cmd.Parameters.AddWithValue("p_IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("p_Precio", obj.Precio);
                    cmd.Parameters.AddWithValue("p_IdSede", obj.oSede.IdSede);
                    cmd.Parameters.AddWithValue("p_IdModelo", obj.oModelo.IdModelo);
                    cmd.Parameters.AddWithValue("p_Serie", obj.Serie);
                    cmd.Parameters.AddWithValue("p_CodInventario", obj.CodInventario);
                    cmd.Parameters.AddWithValue("p_Usuario", obj.Usuario);
                    cmd.Parameters.AddWithValue("p_IdRazonSocial", obj.oRazonSocial.IdRazonSocial);
                    cmd.Parameters.AddWithValue("p_GuiaIngreso", obj.GuiaIngreso);
                    cmd.Parameters.AddWithValue("p_IdProveedor", obj.oProveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("p_OrdenCompra", obj.OrdenCompra);
                    cmd.Parameters.AddWithValue("p_OrdenInterna", obj.OrdenInterna);
                    cmd.Parameters.AddWithValue("p_ActivoFijo", obj.ActivoFijo);
                    cmd.Parameters.AddWithValue("p_IdAlmacen", obj.oAlmacen.IdAlmacen);
                    cmd.Parameters.AddWithValue("p_CodMaterialSAP", obj.CodMaterialSAP);
                    cmd.Parameters.AddWithValue("p_Stock", obj.Stock);
                    cmd.Parameters.AddWithValue("p_IdPrioridades", obj.oPrioridad.IdPrioridades);
                    cmd.Parameters.AddWithValue("p_IdSistema", obj.oSistema.IdSistema);
                    cmd.Parameters.AddWithValue("p_DireccionMac", obj.DireccionMac);
                    cmd.Parameters.AddWithValue("p_FechaActualizacion", obj.FechaActualizacion);
                    cmd.Parameters.AddWithValue("p_FechaGarantia", obj.FechaGarantia);
                    cmd.Parameters.AddWithValue("p_Observacion", obj.Onservacion);
                    cmd.Parameters.AddWithValue("p_Activo", obj.Activo);
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;


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
        
        // Eliminar Equipo
        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_EliminarEquipo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_IdEquipos", id);
                    cmd.Parameters.Add("p_Resultado", MySqlDbType.Int64).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_Mensaje", MySqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

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


        public bool GuardarDatosImagen(Equipo obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_GuardarDatosImagen", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_RutaImagen", obj.RutaImagen);
                    cmd.Parameters.AddWithValue("p_NombreImagen", obj.NombreImagen);
                    cmd.Parameters.AddWithValue("p_IdEquipos", obj.IdEquipos);

                    cn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return false;
                    }
                    else
                    {
                        Mensaje = "No se pudo Actualizar";
                    }

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