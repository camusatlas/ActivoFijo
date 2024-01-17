using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CN_Reportes
    {
        private CD_Reporte objCapaDato = new CD_Reporte();

        public DashBoard VerDashBoard()
        {
            return objCapaDato.VerDashBoard();
        }

        public List<Reporte> Ventas(string fechainicio, string fechafin, string idtransaccion)
        {
            return objCapaDato.Ventas(fechainicio, fechafin, idtransaccion);
        }
    }
}