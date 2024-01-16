using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class Equipo
    {
        public int IdEquipos { get; set; }
        public string Nombre { get; set; }
        public Marca oMarca { get; set; }
        public Categoria oCategoria { get; set; }
        public decimal Precio { get; set; }
        public string PrecioTexto { get; set; }
        public Sede oSede { get; set; }
        public Modelo oModelo { get; set; }
        public string Serie { get; set; }
        public string CodInventario { get; set; }
        public string Usuario { get; set; }
        public string GuiaIngreso { get; set; }
        public Proveedor oProveedor { get; set; }
        public string OrdenCompra { get; set; }
        public string OrdenInterna { get; set; }
        public string ActivoFijo { get; set; }
        public Almacen oAlmacen { get; set; }
        public string CodMaterialSAP { get; set; }
        public Prioridad oPrioridad { get; set; }
        public SistemaOperativo oSistema { get; set; }
        public string DireccionMac { get; set; }
        public string EspecificacionesHardware { get; set; }
        public string FechaGarantia { get; set; }
        public string Onservacion { get; set; }

        

        public string RutaImagen { get; set; }
        public string NombreImagen { get; set; }
        public bool Activo { get; set; }

        public string Base64 { get; set; }

        public string Extension { get; set; }
    }
}