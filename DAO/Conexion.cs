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
    public class Conexion
    {
        private string ruta =
       "Data Source=localhost\\sqlexpress;Initial Catalog=TifLabo3;Integrated Security=True";
       ///*base hosting*/ "Data Source=sql5053.site4now.net;Initial Catalog = db_a8ac12_mgsmarter; Persist Security Info=True;User ID = db_a8ac12_mgsmarter_admin; Password=polno2003";
        public SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(ruta);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable obtenerTabla(string consulta)
        {
            SqlConnection cn = ObtenerConexion();
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Tabla");
            cn.Close();

            return ds.Tables["Tabla"];
        }

        public int ejecutarTransaccion(string consulta)
        {
            int filasAfectadas;
            SqlConnection cn = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            try
            {
                filasAfectadas = cmd.ExecuteNonQuery();
            }
            catch
            {
                filasAfectadas = 0;
            }
            cn.Close();

            return filasAfectadas;
        }

        public int ejecutarSP(SqlCommand cmd, string nombreSP)
        {
            int filasCambiadas;
            SqlConnection cn = ObtenerConexion();

            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nombreSP;

            try
            {
                filasCambiadas = cmd.ExecuteNonQuery();
            }
            catch
            {
                filasCambiadas = 0;
            }
            
            cn.Close();

            return filasCambiadas;
        }

        public SqlDataReader cargarDataReader(String consulta, SqlConnection conexion)
        {
            try
            {
                var sqlcomando = new SqlCommand(consulta, conexion);
                SqlDataReader dr = sqlcomando.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int obtenerMaximo(string consulta)
        {
            int max = 0;
            SqlConnection cn = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
                max = Convert.ToInt32(datos[0].ToString());            
            return max;
        }

        public SqlDataReader ejecutarConsulta(String consulta)
        {
            SqlConnection cn = new SqlConnection(ruta);
            cn.Open();

            SqlCommand cmd = new SqlCommand(consulta, cn);

            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

    }
}
