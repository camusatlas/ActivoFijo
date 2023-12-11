using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace CapaDato
{
    internal class CD_Servidor
    {
        private MySqlConnection cn;
        public CD_Servidor()
        {
            cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ServidorDelosi"].ConnectionString);
        }

        // Listar Servidores
        public List<Servidor> listar()
        {
            List<Servidor> listado = new List<Servidor>();
            MySqlCommand cmd = new MySqlCommand("ListarServidor", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Servidor usuario = new Servidor()
                        {
                            cod_marca = dr["Marca"].ToString(),
                            cod_tienda = dr["Código"].ToString(),
                            tienda = dr["Teinda"].ToString(),
                            ip_servidor = dr["IP Servidor"].ToString(),
                            nom_servidor = dr["Hostname"].ToString(),
                            modelo = dr["Modelo"].ToString(),
                            serie = dr["serie"].ToString(),
                            sistema_operativo = dr["Sistema O."].ToString(),
                            version_micros = dr["Version Micros"].ToString(),
                            memoria_ram = dr["memoria Ram"].ToString(),
                            tamano_bd = dr["Tamaño BD"].ToString(),
                            status = dr["Status"].ToString(),
                            ultimo_reinicio = dr["Ultimo Reini."].ToString(),
                            version_facturador = dr["Version Facturador"].ToString(),
                            ultima_venta = dr["Ultima Venta"].ToString(),
                            flg_estado = dr["FLG"].ToString(),
                            usuario_crea = dr["User Cre."].ToString(),
                            fecha_crea = dr["Fecha Crea"].ToString(),
                            usuario_mod = dr["Usuario mod."].ToString(),
                            fecha_mod = dr["Fecha Mod."].ToString(),
                            idtecnico = dr["ID Tecnico"].ToString(),
                            fecha_asignado = dr["Fecha Asigando"].ToString()


                        };
                        listado.Add(usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return listado;
        }

        // Funcion Registrar
        //public int Registrar(Servidor obj, out string Mensaje)
        //{
        //    int idautogenerado = 0;
        //    Mensaje = string.Empty;
        //    try
        //    {
        //        using (SqlCommand cmd = new SqlCommand("Ing_Servidores", cn))
        //        {


        //            cmd.Parameters.AddWithValue("@cod_marca", obj.cod_marca);
        //            cmd.Parameters.AddWithValue("@cod_tienda", obj.cod_tienda);
        //            cmd.Parameters.AddWithValue("@tienda", obj.tienda);
        //            cmd.Parameters.AddWithValue("@ip_servidor", obj.ip_servidor);
        //            cmd.Parameters.AddWithValue("@nom_servidor", obj.nom_servidor);
        //            cmd.Parameters.AddWithValue("@modelo", obj.modelo);
        //            cmd.Parameters.AddWithValue("@serie", obj.serie);
        //            cmd.Parameters.AddWithValue("@sistema_operativo", obj.sistema_operativo);
        //            cmd.Parameters.AddWithValue("@version_micros", obj.version_micros);
        //            cmd.Parameters.AddWithValue("@memoria_ram", obj.memoria_ram);
        //            cmd.Parameters.AddWithValue("@tamano_bd", obj.tamano_bd);
        //            cmd.Parameters.AddWithValue("@status", obj.status);
        //            cmd.Parameters.AddWithValue("@ultimo_reinicio", obj.ultimo_reinicio);
        //            cmd.Parameters.AddWithValue("@version_facturador", obj.version_facturador);
        //            cmd.Parameters.AddWithValue("@ultima_venta", obj.ultima_venta);
        //            cmd.Parameters.AddWithValue("@flg_estado", obj.flg_estado);
        //            cmd.Parameters.AddWithValue("@usuario_crea", obj.usuario_crea);
        //            cmd.Parameters.AddWithValue("@fecha_crea", obj.fecha_crea);
        //            cmd.Parameters.AddWithValue("@usuario_mod", obj.usuario_mod);
        //            cmd.Parameters.AddWithValue("@fecha_mod", obj.fecha_mod);
        //            cmd.Parameters.AddWithValue("@idtecnico", obj.idtecnico);
        //            cmd.Parameters.AddWithValue("@fecha_asignado", obj.fecha_asignado);

        //            cn.Open();
        //            cmd.ExecuteNonQuery();

        //            idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
        //            Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        idautogenerado = 0;
        //        Mensaje = ex.Message;
        //    }
        //    return idautogenerado;
        //}
    }
}
