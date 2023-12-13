using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class WorkStation
    {
        public int IdWorkSatation { get; set; }
        public string cod_marca { get; set; }
        public string cod_tienda { get; set; }
        public string tienda { get; set; }
        public string caja { get; set; }
        public string ip_workstation { get; set; }
        public string hostname { get; set; }
        public string tipo { get; set; }
        public string modelo { get; set; }

        public string status { get; set; }
        public string ultima_venta { set; get; }
        public string flg_estado { set; get; }
        public string usuario_crea { set; get; }
        public string fecha_crea { set; get; }
        public string usuario_mod { set; get; }
        public string fecha_mod { set; get; }
        public string version_facturador { set; get; }
    }
}