using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CD_Asignando
    {
        private SqlConnection cn;
        public CD_Asignando()
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ActivoFijo"].ConnectionString);
        }

        public List<Tecnico> ObtenerTecnico()
        {
            List<Tecnico> listado = new List<Tecnico>();
            SqlCommand cmd = new SqlCommand("sp_ListarTecnico", cn);
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
                            Nombres = dr["Descripcion"].ToString()
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


        public List<MarcaTienda> ObtenerMarcaTienda()
        {
            List<MarcaTienda> listado = new List<MarcaTienda>();
            SqlCommand cmd = new SqlCommand("ObtenerMARCATIENDA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MarcaTienda marcatienda = new MarcaTienda()
                        {
                            IdMarcaTienda = dr["IdMarcaTienda"].ToString(),
                            Descripcion = dr["NombreMarca"].ToString()
                        };
                        listado.Add(marcatienda);
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

        public List<Tienda> ObtenerTienda(string idmarcatienda)
        {
            List<Tienda> listado = new List<Tienda>();
            SqlCommand cmd = new SqlCommand("sp_ObtenerTienda", cn);
            cmd.Parameters.AddWithValue("@IdMarcaTienda", idmarcatienda);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Tienda tienda = new Tienda()
                        {
                            IdTienda = dr["IdTienda"].ToString(),
                            Descripcion = dr["Descripcion"].ToString()
                        };
                        listado.Add(tienda);
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
    }
}