using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    public class DaoTarjetas
    {
        private Conexion cn = new Conexion();

        public DataTable obtenerTarjetas()
        {
            return cn.obtenerTabla("Select * from Tarjetas");
        }

        public DataTable obtenerTarjetasDeUsuario(Usuarios us)
        {
            return cn.obtenerTabla("SELECT * FROM Tarjetas WHERE DNI_Usuario_Tarjeta = " + us.Dni);
        }

        private void armarParametrosEliminarTarjeta(ref SqlCommand comando, Tarjetas tarjeta)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = comando.Parameters.Add("@NROTARJETA", SqlDbType.Char, 20);
            parametro.Value = tarjeta.NumeroTarjeta;
        }

        private void armarParametrosAgregarTarjeta(ref SqlCommand comando, Tarjetas tarjeta)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = comando.Parameters.Add("@NROTARJETA", SqlDbType.Char, 20);
            parametro.Value = tarjeta.NumeroTarjeta;

            parametro = comando.Parameters.Add("@DNI", SqlDbType.Char, 10);
            parametro.Value = tarjeta.Usuario.Dni;

            parametro = comando.Parameters.Add("@CODSEGURIDAD", SqlDbType.Char, 3);
            parametro.Value = tarjeta.CodigoSeguridad;

            parametro = comando.Parameters.Add("@FECHAEXP", SqlDbType.Date);
            parametro.Value = tarjeta.FechaExpiracion;
        }

        public int SP_agregarTarjeta(Tarjetas tarjeta)
        {
            SqlCommand cmd = new SqlCommand();
            armarParametrosAgregarTarjeta(ref cmd, tarjeta);
            return cn.ejecutarSP(cmd, "SP_AgregarTarjeta");
        }

        public int eliminarTarjeta(Tarjetas tarjeta)
        {
            SqlCommand cmd = new SqlCommand();
            armarParametrosEliminarTarjeta(ref cmd, tarjeta);
            return cn.ejecutarSP(cmd, "SP_EliminarTarjeta");
        }
    }
}
