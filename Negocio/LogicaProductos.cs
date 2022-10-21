using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Entidades;
using DAO;
using System.Threading.Tasks;

namespace Negocio
{
    public class LogicaProductos
    {
        private DaoProductos dPr = new DaoProductos();

        public DataTable getProductos()
        {
            return dPr.ObtenerProducto();
        }

        public void llenarProductoEditXid(ref Productos prod) //recibe producto con id y lo llena para los campos de edit
        {
            dPr.llenarProductoEdit(dPr.getProductoXid(prod));
        }

        



        public bool BajaProducto(Productos prod)
        {
            if (dPr.DarDeBajaProducto(prod) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool ActualizarProducto(Productos prod)
        {
            if (dPr.ActualizarProducto(prod) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool agregarProducto(Productos prod)
        {
            if (dPr.agregarProducto(prod) == 1)
                return true;
            else
                return false;
        }

        public Productos getProducto(Productos prod)
        {
            return dPr.getProducto(prod);
        }

        //public DataTable comprasDelUsuario(Usuarios usAux)
        //{
        //    return dPr.(usAux);
        //}

        public DataTable ProductosAdmin()
        {
            string consulta =
            "Select * from ProductosHabilitados";

            return dPr.ObtenerProductosConsulta(consulta);
        }

        public DataTable BusquedaConFiltrosGrdAdmin(int idcategoria, int idsubcategoria, string nombre) //valores 0 significan que no hay filtro de ese campo
        {
            // campos del view: 
            // [Nombre_Producto], [Precio_Producto], [UrlImagen_Producto], [Stock_Producto], [Id_Categoria_Producto], [Id_Subcategoria_Producto], [Id_Producto]
            string consulta = "";

            if (idcategoria != -1)
            {
                if (consulta == "")
                {
                    consulta =
                    "select * from ProductosHabilitados where Id_Categoria_Producto = " + idcategoria;
                }
                else
                {
                    consulta +=
                    " and Id_Categoria_Producto = " + idcategoria;
                }
            }

            if (idsubcategoria != -1)
            {
                if (consulta == "")
                {
                    consulta =
                    "select * from ProductosHabilitados where Id_Categoria_Producto = " + idcategoria + "and Id_Subcategoria_Producto = " + idsubcategoria;
                }
                else
                {
                    consulta +=
                    " and Id_Categoria_Producto = " + idcategoria + " and Id_Subcategoria_Producto = " + idsubcategoria;
                }
            }

            if (nombre != "")
            {
                if (consulta == "")
                {
                    consulta =
                    "select * from ProductosHabilitados where Nombre_Producto like '%" + nombre + "%' ";
                }
                else
                {
                    consulta +=
                    " and Nombre_Producto like '%" + nombre + "%'";
                }
            }

            if (consulta == "")
            {
                consulta = "select * from ProductosHabilitados";
                return dPr.ObtenerProductosConsulta(consulta);
            }

            return dPr.ObtenerProductosConsulta(consulta);
        }

        public DataTable BusquedaConFiltrosLvHome(int idcategoria, int idsubcategoria, string nombre, int min, int max) //valores 0 significan que no hay filtro de ese campo
        {
            // campos del view: 
            // [Nombre_Producto], [Precio_Producto], [UrlImagen_Producto], [Stock_Producto], [Id_Categoria_Producto], [Id_Subcategoria_Producto], [Id_Producto]
            // donde estado_producto sea mayor a 0, es decir, habilitado.
            string consulta = "";
            
            if (idcategoria != -1)
            {
                if(consulta == "")
                {
                    consulta =
                    "select * from ProductosDeListView where [Id_Categoria_Producto] = " + idcategoria;
                }
                else
                {
                    consulta +=
                    " and [Id_Categoria_Producto] = " + idcategoria;
                }
            }
               
            if(idsubcategoria != -1)
            {
                if (consulta == "")
                {
                    consulta =
                    "select * from ProductosDeListView where [Id_Categoria_Producto] = " + idcategoria + "and [Id_Subcategoria_Producto] = " + idsubcategoria;
                }
                else
                {
                    consulta +=
                    " and [Id_Categoria_Producto] = " + idcategoria + " and [Id_Subcategoria_Producto] = " + idsubcategoria;
                }
            }

            if(nombre != "")
            {
                if(consulta == "")
                {
                    consulta =
                    "select * from ProductosDeListView where [Nombre_Producto] like '%" + nombre + "%' ";
                }
                else
                {
                    consulta += 
                    " and [Nombre_Producto] like '%" + nombre + "%'";
                }
            }

            if (min != -1 && max != -1)
            {
                if (consulta == "")
                {
                    consulta =
                    "select * from ProductosDeListView where [Precio_Producto] between " + min + "and " + max;
                }
                else
                {
                    consulta += 
                    " and [Precio_Producto] between " + min + "and " + max;
                }
            }

            if (consulta == "")
            {
                consulta = "select * from ProductosDeListView";
                return dPr.ObtenerProductosConsulta(consulta); 
            }

            return dPr.ObtenerProductosConsulta(consulta);
        }
    }
}
