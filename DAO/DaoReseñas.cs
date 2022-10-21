using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DaoReseñas
    {
        private Conexion cn = new Conexion();

        public DataTable ObtenerReseñas()
        {
            return cn.obtenerTabla("Select * from ReseñasHabilitadas");
        }

        private void ParamentrosAgregarReseña(ref SqlCommand cmd, ReseñasProducto res)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = cmd.Parameters.Add("@IDPRODUCTOS", SqlDbType.Int);
            parametro.Value = res.Producto.IdProducto;

            parametro = cmd.Parameters.Add("@DNIUSUARIO", SqlDbType.Char, 10);
            parametro.Value = res.Usuario.Dni;

            parametro = cmd.Parameters.Add("@CONTENIDO", SqlDbType.Text);
            parametro.Value = res.Contenido;

            parametro = cmd.Parameters.Add("@CALIFICACION", SqlDbType.Int);
            parametro.Value = res.Calificación;
        }

        public DataTable ultimas10Reseñas(Productos prod)
        {
            return cn.obtenerTabla("Select Top 10 * From ReseñasHabilitadas Where Id_Producto_Reseña = " + prod.IdProducto + " Order by Fecha_Reseña Desc ");
        }

        public int agregarReseña(ReseñasProducto res)
        {
            SqlCommand cmd = new SqlCommand();
            ParamentrosAgregarReseña(ref cmd, res);

            return cn.ejecutarSP(cmd, "SP_AgregarReseña");
        }

        private void ParamentrosIdentificarReseña(ref SqlCommand cmd, ReseñasProducto res)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = cmd.Parameters.Add("@IDPRODUCTOS", SqlDbType.Int);
            parametro.Value = res.Producto.IdProducto;

            parametro = cmd.Parameters.Add("@DNIUSUARIO", SqlDbType.Char, 10);
            parametro.Value = res.Usuario.Dni;
        }

        public int EliminarReseña(ReseñasProducto res)
        {
            SqlCommand cmd = new SqlCommand();
            ParamentrosIdentificarReseña(ref cmd, res);

            return cn.ejecutarSP(cmd, "SP_EliminarReseña");
        }

        public int VerificarReseña(ReseñasProducto res)
        {
            SqlCommand cmd = new SqlCommand();
            ParamentrosIdentificarReseña(ref cmd, res);

            return cn.ejecutarSP(cmd, "SP_VerificarExistenciaReseña");
        }

    }
}
