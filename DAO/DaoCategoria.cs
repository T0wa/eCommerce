using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO
{
    public class DaoCategoria
    {
        private Conexion cn = new Conexion();

        public DataTable ObtenerCategorias()
        {
            return cn.obtenerTabla("Select * from CategoriasHabilitadas");
        }

        public DataTable ObtenerCategorias(string consulta)
        {
            return cn.obtenerTabla(consulta);
        }

        private void parametrosBajaCat(ref SqlCommand comando, Categorías cat)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = comando.Parameters.Add("@idCat", SqlDbType.Int);
            parametro.Value = cat.IdCategoria;
        }

        public int DarDeBajaCategoria(Categorías cat)
        {
            SqlCommand cmd = new SqlCommand();
            parametrosBajaCat(ref cmd, cat);

            return cn.ejecutarSP(cmd, "SP_EliminarCategoria");
        }

        private void parametrosEditCat(ref SqlCommand comando, Categorías cat)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = comando.Parameters.Add("@idCat", SqlDbType.Int);
            parametro.Value = cat.IdCategoria;

            parametro = comando.Parameters.Add("@Desc", SqlDbType.VarChar, 30);
            parametro.Value = cat.Descripcion;
        }

        public int EditarCategoria(Categorías cat)
        {
            SqlCommand cmd = new SqlCommand();
            parametrosEditCat(ref cmd, cat);

            return cn.ejecutarSP(cmd, "SP_EditarCategoria");
        }

        private void parametrosInsertCat(ref SqlCommand comando, Categorías cat)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = comando.Parameters.Add("@Desc", SqlDbType.VarChar, 30);
            parametro.Value = cat.Descripcion;
        }
        public int InsertCategoria(Categorías cat)
        {
            SqlCommand cmd = new SqlCommand();
            parametrosInsertCat(ref cmd, cat);

            return cn.ejecutarSP(cmd, "SP_AgregarCategoria");
        }

    }
}
