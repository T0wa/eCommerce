using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Entidades;
using System.Threading.Tasks;

namespace DAO
{
    public class DaoProductos
    {
        private Conexion cn = new Conexion();

        public DataTable ObtenerProducto()
        {
            return cn.obtenerTabla("Select * from ProductosHabilitados");
        }

        

        public DataTable ObtenerProductosConsulta(string consulta)
        {
            return cn.obtenerTabla(consulta);
        }

        private void parametrosBajaProd(ref SqlCommand comando, Productos prod)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = comando.Parameters.Add("@idProd", SqlDbType.Int);
            parametro.Value = prod.IdProducto;
        }

        public int DarDeBajaProducto(Productos prod)
        {
            SqlCommand cmd = new SqlCommand();
            parametrosBajaProd(ref cmd, prod);

            return cn.ejecutarSP(cmd, "SP_EliminarProducto");
        }

        private void parametrosActualizarProd(ref SqlCommand comando, Productos prod)
        {
            SqlParameter parametro = new SqlParameter();

            //@idProd INT,
            //@nombre varchar(50),
            //@descrip varchar(400),
            //@cat INT,
            //@subCat INT,
            //@precio decimal,
            //@stock int,
            //@url varchar(150)

            parametro = comando.Parameters.Add("@idProd", SqlDbType.Int);
            parametro.Value = prod.IdProducto;

            parametro = comando.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
            parametro.Value = prod.Nombre;

            parametro = comando.Parameters.Add("@descrip", SqlDbType.VarChar, 400);
            parametro.Value = prod.Descripcion;

            parametro = comando.Parameters.Add("@cat", SqlDbType.Int);
            parametro.Value = prod.Subcategoria.Categoria.IdCategoria;

            parametro = comando.Parameters.Add("@subCat", SqlDbType.Int);
            parametro.Value = prod.Subcategoria.IdSubCategoria;

            parametro = comando.Parameters.Add("@precio", SqlDbType.Decimal);
            parametro.Value = prod.Precio;

            parametro = comando.Parameters.Add("@stock", SqlDbType.Int);
            parametro.Value = prod.Stock;

            parametro = comando.Parameters.Add("@url", SqlDbType.VarChar, 150);
            parametro.Value = prod.UrlImage;
        }

        public int ActualizarProducto(Productos prod)
        {
            SqlCommand cmd = new SqlCommand();
            parametrosActualizarProd(ref cmd, prod);

            return cn.ejecutarSP(cmd, "SP_ModificarProducto");
        }

        private void ParametrosAgregarProd(ref SqlCommand comando, Productos prod)
        {
            SqlParameter parametro = new SqlParameter();

            parametro = comando.Parameters.Add("@NOMBREPRODUCTO", SqlDbType.VarChar, 50);
            parametro.Value = prod.Nombre;

            parametro = comando.Parameters.Add("@DESCPRODUCTO", SqlDbType.VarChar, 400);
            parametro.Value = prod.Descripcion;

            parametro = comando.Parameters.Add("@PRECIO", SqlDbType.Decimal);
            parametro.Value = prod.Precio;

            parametro = comando.Parameters.Add("@IDCATEGORIA", SqlDbType.Int);
            parametro.Value = prod.Subcategoria.Categoria.IdCategoria;

            parametro = comando.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int);
            parametro.Value = prod.Subcategoria.IdSubCategoria;

            parametro = comando.Parameters.Add("@STOCK", SqlDbType.Int);
            parametro.Value = prod.Stock;

            parametro = comando.Parameters.Add("@URLIMAGEN", SqlDbType.VarChar, 100);
            parametro.Value = prod.UrlImage;
        }

        public int agregarProducto(Productos prod)
        {
            SqlCommand cmd = new SqlCommand();
            ParametrosAgregarProd(ref cmd, prod);

            return cn.ejecutarSP(cmd, "SP_AgregarProducto");
        }

        private void cargarProducto(ref Productos prod, DataTable dt)
        {
            prod.Nombre = dt.Rows[0]["Nombre_Producto"].ToString();
            prod.Precio = Convert.ToDecimal(dt.Rows[0]["Precio_Producto"]);
            prod.Descripcion = dt.Rows[0]["Descripcion_Producto"].ToString();
            prod.Stock = Convert.ToInt32(dt.Rows[0]["Stock_Producto"]);
            prod.Estado = Convert.ToBoolean(dt.Rows[0]["Estado_Producto"]);
            prod.UrlImage = dt.Rows[0]["UrlImagen_Producto"].ToString();
        }

        private void cargarCategorias(ref Productos prod, DataTable dt)
        {
            prod.Subcategoria.Categoria.IdCategoria = Convert.ToInt32(dt.Rows[0]["Id_Categoria"]);
            prod.Subcategoria.Categoria.Descripcion = dt.Rows[0]["Descripcion_Categoria"].ToString();
            prod.Subcategoria.Categoria.Estado = Convert.ToBoolean(dt.Rows[0]["Estado_Categoria"]);
        }

        private void cargarSubCategorias(ref Productos prod, DataTable dt)
        {
            prod.Subcategoria.Categoria.IdCategoria = Convert.ToInt32(dt.Rows[0]["Id_Categoria_Subcategoria"]);
            prod.Subcategoria.IdSubCategoria = Convert.ToInt32(dt.Rows[0]["Id_Subcategoria"]);
            prod.Subcategoria.Descripcion = dt.Rows[0]["Descripcion_Subcategoria"].ToString();
            prod.Subcategoria.Estado = Convert.ToBoolean(dt.Rows[0]["Estado_Subcategoria"]);
        }

        public Productos getProducto(Productos prod) //separo en funciones el metodo para que este mas organizado
        {
            DataTable dt = new DataTable();
            dt = cn.obtenerTabla(
            "Select * From Productos inner join Subcategorias " +
            "On Productos.Id_Subcategoria_Producto = Subcategorias.Id_Subcategoria " +
            "and Productos.Id_Categoria_Producto = Subcategorias.Id_Categoria_Subcategoria inner join Categorias " +
            "On Subcategorias.Id_Categoria_Subcategoria = Categorias.Id_Categoria Where Id_Producto = "+ prod.IdProducto /*+  "and estado_producto = 1"*/);

            cargarProducto(ref prod, dt);
            cargarCategorias(ref prod, dt);
            cargarSubCategorias(ref prod, dt);

            return prod;
        }

        public DataTable getProductoXid(Productos prod)
        {
            string consulta =
            "Select * from ProductosHabilitados where Id_Producto = " + prod.IdProducto;
            return ObtenerProductosConsulta(consulta);
        }

        public Productos llenarProductoEdit(DataTable dt)
        {
            Productos prod = new Productos();

            prod.Nombre = dt.Rows[0]["Nombre_Producto"].ToString();
            prod.Precio = Convert.ToDecimal(dt.Rows[0]["Precio_Producto"]);
            prod.Descripcion = dt.Rows[0]["Descripcion_Producto"].ToString();
            prod.Stock = Convert.ToInt32(dt.Rows[0]["Stock_Producto"]);
            prod.Estado = Convert.ToBoolean(dt.Rows[0]["Estado_Producto"]);
            prod.UrlImage = dt.Rows[0]["UrlImagen_Producto"].ToString();

            return prod;
        }

    }
}
