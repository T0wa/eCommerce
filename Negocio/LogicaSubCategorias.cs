using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using Entidades;
using System.Data;
using System.Threading.Tasks;

namespace Negocio
{
    public class LogicaSubCategorias
    {
        private DaoSubCategoria dSCat = new DaoSubCategoria();
        public DataTable getSubCategorias()
        {
            return dSCat.ObtenerSubCategorias();
        }

        public DataTable getSubCategoriasXidCategoria(int id)
        {
            return dSCat.ObtenerSubCategoriasXcategoria(id);
        }

        public DataTable getSubCategorias(string consulta)
        {
            return dSCat.ObtenerSubCategorias();
        }

        public bool EliminarSubCategoria(SubCategorias subCat)
        {
            if (dSCat.DarDeBajaSubCategoria(subCat) == 1)
                return true;
            else
                return false;
        }

        public bool EditarSubCategoria(SubCategorias subCat)
        {
            if (dSCat.EditarSubCategoria(subCat) == 1)
                return true;
            else
                return false;
        }

        public bool InsertSubCategoria(SubCategorias subCat)
        {
            if (dSCat.InsertCategoria(subCat) == 1)
                return true;
            else
                return false;
        }

        public DataTable BusquedaConFiltrosGrdAdmin(string nombre, int idcategoria) //valores 0 significan que no hay filtro de ese campo
        {
            // campos del view: 
            // [Nombre_Producto], [Precio_Producto], [UrlImagen_Producto], [Stock_Producto], [Id_Categoria_Producto], [Id_Subcategoria_Producto], [Id_Producto]
            string consulta = "";

            if (nombre != "")
            {
                if (consulta == "")
                {
                    consulta =
                    "select * from SubCategoriasHabilitadas where [Descripcion_Subcategoria] like '%" + nombre + "%' ";
                }
                else
                {
                    consulta +=
                    " and [Descripcion_Subcategoria] like '%" + nombre + "%'";
                }
            }

            if (idcategoria != -1)
            {
                if (consulta == "")
                {
                    consulta =
                    "select * from SubCategoriasHabilitadas where [Id_Categoria_Subcategoria] = " + idcategoria;
                }
                else
                {
                    consulta +=
                    " and [Id_Categoria_Subcategoria] = " + idcategoria;
                }
            }

            if (consulta == "")
            {
                consulta = "select * from SubCategoriasHabilitadas";
                return dSCat.ObtenerSubCategorias(consulta);
            }

            return dSCat.ObtenerSubCategorias(consulta);
        }

    }
}
