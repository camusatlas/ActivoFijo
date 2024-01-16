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
        private SqlConnection cn;
        public CD_Equipo()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ActivoFijo"].ConnectionString);
        }

        // Listar Producto
        public List<Equipo> listar()
        {
            List<Equipo> listado = new List<Equipo>();
            SqlCommand cmd = new SqlCommand("sp_ListarEquipo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Equipo equipo = new Equipo()
                        {
                            IdEquipos = Convert.ToInt32(dr["IdEquipos"]),
                            Nombre = dr["Nombre"].ToString(),
                            oMarca = new Marca() { IdMarca = Convert.ToInt32(dr["IdMarca"]), Descripcion = dr["DesMarca"].ToString() },
                            oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(dr["IdCategoria"]), Descripcion = dr["DesCategoria"].ToString() },
                            Precio = Convert.ToDecimal(dr["Precio"], new CultureInfo("es-PE")),
                            oSede = new Sede() { IdSede = Convert.ToInt32(dr["IdSede"]), NomSede = dr["Sede"].ToString() },
                            oModelo = new Modelo() { IdModelo = Convert.ToInt32(dr["IdModelo"]), NomModelo = dr["Modeslo"].ToString() },
                            Serie = dr["Serie"].ToString(),
                            CodInventario = dr["CodInventario"].ToString(),
                            Usuario = dr["Usuario"].ToString(),
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
                            EspecificacionesHardware = dr["EspecificacionesHardware"].ToString(),
                            FechaGarantia = dr["FechaGarantia"].ToString(),
                            Onservacion = dr["Onservacion"].ToString(),
                            RutaImagen = dr["RutaImagen"].ToString(),
                            NombreImagen = dr["NombreImagen"].ToString(),
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
                using (SqlCommand cmd = new SqlCommand("sp_RegistrarEquipos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("IdMarca", obj.oMarca.IdMarca);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Precio", obj.Precio);
                    cmd.Parameters.AddWithValue("IdSede", obj.oSede.IdSede);
                    cmd.Parameters.AddWithValue("IdModelo", obj.oModelo.IdModelo);
                    cmd.Parameters.AddWithValue("Serie", obj.Serie);
                    cmd.Parameters.AddWithValue("CodInventario", obj.CodInventario);
                    cmd.Parameters.AddWithValue("GuiaIngreso", obj.GuiaIngreso);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.oProveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("OrdenCompra", obj.OrdenCompra);
                    cmd.Parameters.AddWithValue("OrdenInterna", obj.OrdenInterna);
                    cmd.Parameters.AddWithValue("ActivoFijo", obj.ActivoFijo);
                    cmd.Parameters.AddWithValue("IdAlmacen", obj.oAlmacen.IdAlmacen);
                    cmd.Parameters.AddWithValue("CodMaterialSAP", obj.CodMaterialSAP);
                    cmd.Parameters.AddWithValue("IdPrioridades", obj.oPrioridad.IdPrioridades);
                    cmd.Parameters.AddWithValue("IdSistema", obj.oSistema.IdSistema);
                    cmd.Parameters.AddWithValue("DireccionMac", obj.DireccionMac);
                    cmd.Parameters.AddWithValue("EspecificacionesHardware", obj.EspecificacionesHardware);
                    cmd.Parameters.AddWithValue("FechaGarantia", obj.FechaGarantia);
                    cmd.Parameters.AddWithValue("Onservacion", obj.Onservacion);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

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

        //Editar Equipo
        public bool Editar(Equipo obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EditarEquipo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdEquipos", obj.IdEquipos);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("IdMarca", obj.oMarca.IdMarca);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Precio", obj.Precio);
                    cmd.Parameters.AddWithValue("IdSede", obj.oSede.IdSede);
                    cmd.Parameters.AddWithValue("IdModelo", obj.oModelo.IdModelo);
                    cmd.Parameters.AddWithValue("Serie", obj.Serie);
                    cmd.Parameters.AddWithValue("CodInventario", obj.CodInventario);
                    cmd.Parameters.AddWithValue("GuiaIngreso", obj.GuiaIngreso);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.oProveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("OrdenCompra", obj.OrdenCompra);
                    cmd.Parameters.AddWithValue("OrdenInterna", obj.OrdenInterna);
                    cmd.Parameters.AddWithValue("ActivoFijo", obj.ActivoFijo);
                    cmd.Parameters.AddWithValue("IdAlmacen", obj.oAlmacen.IdAlmacen);
                    cmd.Parameters.AddWithValue("CodMaterialSAP", obj.CodMaterialSAP);
                    cmd.Parameters.AddWithValue("IdPrioridades", obj.oPrioridad.IdPrioridades);
                    cmd.Parameters.AddWithValue("IdSistema", obj.oSistema.IdSistema);
                    cmd.Parameters.AddWithValue("DireccionMac", obj.DireccionMac);
                    cmd.Parameters.AddWithValue("EspecificacionesHardware", obj.EspecificacionesHardware);
                    cmd.Parameters.AddWithValue("FechaGarantia", obj.FechaGarantia);
                    cmd.Parameters.AddWithValue("Onservacion", obj.Onservacion);
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
        /*------------------------------------------------------------------------------------------------------------------------*/
        // Guardar Datos de Imagen
        public bool GuardarDatosImagen(Equipo obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_GuardarDatosImagen", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("RutaImagen", obj.RutaImagen);
                    cmd.Parameters.AddWithValue("NombreImagen", obj.NombreImagen);
                    cmd.Parameters.AddWithValue("IdEquipos", obj.IdEquipos);

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
        /*------------------------------------------------------------------------------------------------------------------------*/
        // Eliminar Equipo
        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_EliminarEquipo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("IdEquipos", id);
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