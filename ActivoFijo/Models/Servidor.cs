using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class Servidor
    {
        public int IdTienda { get; set; }
        public string cod_marca { get; set; }
        public string cod_tienda { get; set; }
        public string tienda { get; set; }
        public string ip_servidor { get; set; }
        public string nom_servidor { get; set; }
        public string modelo { get; set; }
        public string serie { get; set; }
        public string sistema_operativo { get; set; }
        public string version_micros { get; set; }
        public string memoria_ram { get; set; }
        public string tamano_bd { get; set; }
        public string status { get; set; }
        public string ultimo_reinicio { get; set; }
        public string version_facturador { get; set; }
        public string ultima_venta { get; set; }
        public string flg_estado { get; set; }
        public string usuario_crea { get; set; }
        public string fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public string fecha_mod { get; set; }
        public string idtecnico { get; set; }
        public string fecha_asignado { get; set; }
    }
}