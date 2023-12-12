using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ActivoFijo.Models;

namespace ActivoFijo.Models
{
    public class CN_Servidor
    {
        private CD_Servidor objCapaDato = new CD_Servidor();

        public List<Servidor> ListarServidores()
        {
            return objCapaDato.listar();
        }

        public string RegistrarServidor(Servidor obj)
        {
            string mensaje;
            objCapaDato.Registrar(obj, out mensaje);
            return mensaje;
        }

        public string ActualizarServidor(Servidor obj)
        {
            string mensaje;
            objCapaDato.Editar(obj, out mensaje);
            return mensaje;
        }

        public string EliminarServidor(string tienda)
        {
            string mensaje;
            bool resultado = objCapaDato.Eliminar(tienda, out mensaje);
            return resultado ? "Eliminación exitosa" : mensaje;
        }
    }
}
