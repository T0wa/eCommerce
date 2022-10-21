using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace DAO
{
    public class DaoSubCategoria
    {
        private Conexion cn = new Conexion();

        public DataTable ObtenerSubCategorias()
        {
            return cn.obtenerTabla("Select * from SubCategoriasHabilitadas");
        }

        public DataTable ObtenerSubCategorias(String consulta)
        {
            return cn.obtenerTabla(consulta);
        }

        public DataTable ObtenerSubCategoriasXcategoria(int id)
        {
            return cn.obtenerTabla("Select * from SubCategoriasHabilitadas where Id_Categoria_Subcategoria = " + id);
        }
        private void parametrosBajaSubCat(ref SqlCommand comando, SubCategorias Subcat)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = comando.Parameters.Add("@idSubCat", SqlDbType.Int);
            parametro.Value = Subcat.IdSubCategoria;
        }

        public int DarDeBajaSubCategoria(SubCategorias SubCat)
        {
            SqlCommand cmd = new SqlCommand();
            parametrosBajaSubCat(ref cmd, SubCat);

            return cn.ejecutarSP(cmd, "SP_EliminarSubCategoria");
        }

        private void parametrosEditSubCat(ref SqlCommand comando, SubCategorias SubCat)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = comando.Parameters.Add("@idSubCat", SqlDbType.Int);
            parametro.Value = SubCat.IdSubCategoria;

            parametro = comando.Parameters.Add("@Desc", SqlDbType.VarChar, 30);
            parametro.Value = SubCat.Descripcion;
        }

        public int EditarSubCategoria(SubCategorias SubCat)
        {
            SqlCommand cmd = new SqlCommand();
            parametrosEditSubCat(ref cmd, SubCat);

            return cn.ejecutarSP(cmd, "SP_EditarSubCategoria");
        }

        private void parametrosInsertSubCat(ref SqlCommand comando, SubCategorias Subcat)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = comando.Parameters.Add("@Desc", SqlDbType.VarChar, 30);
            parametro.Value = Subcat.Descripcion;
            parametro = comando.Parameters.Add("@Cat", SqlDbType.Int);
            parametro.Value = Subcat.Categoria.IdCategoria;
        }
        public int InsertCategoria(SubCategorias Subcat)
        {
            SqlCommand cmd = new SqlCommand();
            parametrosInsertSubCat(ref cmd, Subcat);

            return cn.ejecutarSP(cmd, "SP_AgregarSubCategoria");
        }
    }
}
