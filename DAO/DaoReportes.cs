using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace DAO
{
    public class DaoReportes
    {
        private Conexion conn = new Conexion();
        private void armarParametrosEliminarReporte(ref SqlCommand cmd, Facturas factura)
        {
            SqlParameter sqlP = new SqlParameter();
            sqlP = cmd.Parameters.Add("@idFactura", SqlDbType.Char, 10);
            sqlP.Value = factura.IdFactura.ToString();
        }

        public int ejecutarSP_EliminarReporte(Facturas factura)
        {
            SqlCommand cmd = new SqlCommand();
            armarParametrosEliminarReporte(ref cmd, factura);
            return conn.ejecutarSP(cmd, "SP_EliminarFacturas");
        }
    }
}
