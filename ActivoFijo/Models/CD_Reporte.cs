﻿using MySql.Data.MySqlClient;
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
    public class CD_Reporte
    {
        private MySqlConnection cn;
        public CD_Reporte()
        {
            cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ServidorDelosiInventario"].ConnectionString);
        }

        // Listar Resportes
        public List<Reporte> Ventas(string fechainicio, string fechafin, string idtransaccion)
        {
            List<Reporte> listado = new List<Reporte>();
            MySqlCommand cmd = new MySqlCommand("sp_ReporteVentas", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("fechainicio", fechainicio);
            cmd.Parameters.AddWithValue("fechafin", fechafin);
            cmd.Parameters.AddWithValue("idtransaccion", idtransaccion);

            try
            {
                cn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Reporte reporte = new Reporte()
                        {
                            FechaVenta = dr["FechaVenta"].ToString(),
                            Usuario = dr["Usuario"].ToString(),
                            Tienda = dr["Tienda"].ToString(),
                            Tecnico = dr["Tecnico"].ToString(),
                            Equipo = dr["Producto"].ToString(),
                            Precio = Convert.ToDecimal(dr["Precio"], new CultureInfo("es-PE")),
                            Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                            Total = Convert.ToDecimal(dr["Total"], new CultureInfo("es-PE")),
                            IdTransaccion = dr["IdTransaccion"].ToString()
                        };
                        listado.Add(reporte);
                    }
                }
            }
            catch
            {
                listado = new List<Reporte>();
            }
            return listado;
        }

        // Ver Datos DashBoard
        public DashBoard VerDashBoard()
        {
            DashBoard objeto = new DashBoard();
            MySqlCommand cmd = new MySqlCommand("sp_ReporteDashboard", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objeto = new DashBoard()
                        {
                            TotalCliente = Convert.ToInt32(dr["TotalTecnicos"]),
                            TotalVenta = Convert.ToInt32(dr["TotalSalida"]),
                            TotalEquipo = Convert.ToInt32(dr["TotalEquipos"]),
                        };
                    }
                }
            }
            catch
            {
                objeto = new DashBoard();
            }
            return objeto;
        }
    }
}