using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivoFijo.Models
{
    public class CN_Servidor
    {
        private CD_Servidor objCapaDato = new CD_Servidor();

        public List<Servidor> Listar()
        {
            return objCapaDato.listar();
        }

        // Registrar
        //public int Registrar(Servidor obj, out string Mensaje)
        //{
        //    Mensaje = string.Empty;


        //    if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
        //    {
        //        Mensaje = "El nombre del usuario no puede ser vacio";
        //    }
        //    else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
        //    {
        //        Mensaje = "El apellido del usuario no puede ser vacio";
        //    }
        //    else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
        //    {
        //        Mensaje = "El correo del usuario no puede ser vacio";
        //    }

        //    if (string.IsNullOrEmpty(Mensaje))
        //    {
        //        string clave = "test123";
        //        obj.Clave = CN_Recursos.ConvertirSha256(clave);

        //        return objCapaDato.Registrar(obj, out Mensaje);
        //    }
        //    else
        //    {
        //        return 0;


        //public bool Editar(Usuario obj, out string Mensaje)
        //{
        //    Mensaje = string.Empty;
        //    if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
        //    {
        //        Mensaje = "El nombre del usuario no puede ser vacio";
        //    }
        //    else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
        //    {
        //        Mensaje = "El apellido del usuario no puede ser vacio";
        //    }
        //    else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
        //    {
        //        Mensaje = "El correo del usuario no puede ser vacio";
        //    }

        //    if (string.IsNullOrEmpty(Mensaje))
        //    {
        //        return objCapaDato.Editar(obj, out Mensaje);
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}
        //// Eliminar
        //public bool Eliminar(int id, out string Mensaje)
        //{
        //    return objCapaDato.Eliminar(id, out Mensaje);
        //}

    }



}