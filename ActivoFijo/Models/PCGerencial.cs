using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class PCGerencial
    {
        public int IdPcdGerencial { get; set; }
        public string cod_marca { get; set; }
        public string cod_tienda { get; set; }
        public string tienda { get; set; }
        public string ip_gerente { get; set; }
        public string nom_pc_gerencial { get; set; }
        public string modelo { get; set; }
        public string serie { get; set; }
        public string sistema_operativo { get; set; }
        public string memoria_ram { get; set; }
        public string procesador { get; set; }
        public bool status { get; set; }
        public string flg_stado { get; set; }
        public string usuario_crea { get; set; }
        public string fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public string fecha_mod { get; set; }
    }
}