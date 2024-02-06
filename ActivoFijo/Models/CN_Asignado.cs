using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CN_Asignado
    {
        private CD_Asignando objCapaDato = new CD_Asignando();

        public List<MarcaTienda> ObtenerMarcaTienda()
        {
            return objCapaDato.ObtenerMarcaTienda();
        }

        public List<Tienda> ObtenerTienda(string idmarcatienda)
        {
            return objCapaDato.ObtenerTienda(idmarcatienda);
        }
    }
}