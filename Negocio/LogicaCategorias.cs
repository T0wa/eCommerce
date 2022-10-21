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
    public class LogicaCategorias
    {
        private DaoCategoria dCat = new DaoCategoria();
        public DataTable getCategorias()
        {
            return dCat.ObtenerCategorias();
        }

        private DataTable GetCategorias(string consulta)
        {
            return dCat.ObtenerCategorias(consulta);
        }

        public bool darDeBajaCategoria(Categorías cat)
        {
            if (dCat.DarDeBajaCategoria(cat) == 1)
                return true;
            else
                return false;
        }

        public int obtenerCatPorIdSubCat(int idSubCat)
        {
            string consulta =
            "select Id_Categoria from CategoriasInnerSubCategorias where Id_Subcategoria = " + idSubCat;
            var dtCat = dCat.ObtenerCategorias(consulta);
            return Convert.ToInt32(dtCat.Rows[0]["Id_Categoria"]);
        }

        public bool EditarCategoria(Categorías cat)
        {
            if (dCat.EditarCategoria(cat) == 1)
                return true;
            else
                return false;
        }

        public bool InsertCategoria(Categorías cat)
        {
            if (dCat.InsertCategoria(cat) == 1)
                return true;
            else
                return false;
        }

        public DataTable BusquedaConFiltrosGrdAdmin(string nombre) //valores 0 significan que no hay filtro de ese campo
        {
            string consulta = "";

            if (nombre != "")
            {
                if (consulta == "")
                {
                    consulta =
                    "select * from CategoriasHabilitadas where [Descripcion_Categoria] like '%" + nombre + "%' and Estado_Categoria > 0";
                }
                else
                {
                    consulta +=
                    " and [Descripcion_Categoria] like '%" + nombre + "%' and Estado_Categoria > 0";
                }
            }

            if (consulta == "")
            {
                consulta = "select * from CategoriasHabilitadas where Estado_Categoria > 0";
                return dCat.ObtenerCategorias(consulta);
            }

            return dCat.ObtenerCategorias(consulta);
        }
    }
}
