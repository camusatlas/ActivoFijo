using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class KDS
    {
        public int IdKds { get; set; }
        public string empresa { get; set; }
        public string marca { get; set; }
        public string tienda { get; set; }
        public string nombre_tienda { get; set; }
        public string ip_kds { get; set; }
        public string hostname { get; set; }
        public string modelo { get; set; }
        public string serie { get; set; }
        public bool status { get; set; }
    }
}