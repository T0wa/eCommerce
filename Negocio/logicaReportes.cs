using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAO;
using System.Data;
using Entidades;

namespace Negocio
{
   public class logicaReportes
    {
        Conexion con = new Conexion();
        public SqlDataReader dllCat()
        {
            

            SqlDataReader dr;

            dr = con.ejecutarConsulta("Select * FROM Categorias");

            return dr;
        }

        public SqlDataReader ddlFacturas()
        {
            
            SqlDataReader dr;

            dr = con.ejecutarConsulta("Select Id_Factura FROM Facturas WHERE Estado_Factura = 1");

            return dr;
        }

        public SqlDataReader dllSubCat()
        {
            

            SqlDataReader dr;

            dr = con.ejecutarConsulta("Select * FROM Subcategorias");

            return dr;
        }

        public DataTable cargarFacturas()
        {
            Conexion con = new Conexion();

            DataTable Tabla;

            Tabla=con.obtenerTabla("Select * FROM ReportesProducto ORDER BY [Numero de factura] ASC");

            return Tabla;
        }

        public bool borrarFactura(Facturas factura)
        {
            DaoReportes daoR = new DaoReportes();

            if (daoR.ejecutarSP_EliminarReporte(factura) == 1)
            {
                return true;
            }
            else { return false; }
        }

        public DataTable cargarConFiltros(string fechaDesde, string fechaHasta, string precioMin, string precioMax, string cantidadMin, string cantidadMax, string subCategoria, string categoria, string envio, string factura)
        {
            Conexion con = new Conexion();
            DataTable Tabla;
            string consulta = "";

            if (fechaDesde != "" && fechaHasta != "")
            {
                if (consulta == "")
                {
                    consulta = "SELECT * FROM ReportesProducto WHERE [Fecha de la factura] between '" + fechaDesde + "' and '" + fechaHasta + "'";
                }
            }
            if (precioMax.Length != 0 && precioMin.Length != 0)
            {
                if (consulta == "")
                {
                    consulta = "SELECT * FROM ReportesProducto WHERE [Precio total] between " + int.Parse(precioMin) + " and " + int.Parse(precioMax);
                }
                else { consulta += " and [Precio total] between " + int.Parse(precioMin) + " and " + int.Parse(precioMax); }
            }
            if (cantidadMax.Length != 0 && cantidadMin.Length != 0)
            {
                if (consulta == "")
                {
                    consulta = "SELECT * FROM ReportesProducto WHERE Cantidad between " + cantidadMin + " and " + cantidadMax;
                }
                else { consulta += " and Cantidad between " + cantidadMin + " and " + cantidadMax; }
            }
            if (subCategoria != "-1")
            {
                if (consulta == "")
                {
                    consulta = "SELECT * FROM ReportesProducto WHERE [Sub categoría] = '" + subCategoria +"'";
                }
                else { consulta += " and [Sub categoría] = '" + subCategoria + "'"; }
            }
            if (categoria != "-1")
            {
                if (consulta == "")
                {
                    consulta = "SELECT * FROM ReportesProducto WHERE Categoría = '" + categoria + "'";
                }
                else {consulta += " and Categoría = '" + categoria + "'"; }
            }
            if (envio != "")
            {
                if (consulta == "")
                {
                    consulta = "SELECT * FROM ReportesProducto WHERE Envio = " + envio;
                }
                else { consulta += " and Envio = " + envio;}
            }
            if(factura != "-1")
            {
                if (consulta == "")
                {
                    consulta = "SELECT * FROM ReportesProducto WHERE [Numero de factura] = " + factura;
                }
                else { consulta += "and [Numero de factura] = " + factura; }
            }
            if (consulta == "")
            {
                consulta = "Select * FROM ReportesProducto";
            }
           Tabla = con.obtenerTabla(consulta + " ORDER BY [Numero de factura] ASC");
            return Tabla;
        }


        //string consulta = "";
            
        //    if (idcategoria != -1)
        //    {
        //        if(consulta == "")
        //        {
        //            consulta =
        //            "select * from ProductosDeListView where [Id_Categoria_Producto] = " + idcategoria;
        //        }
        //        else
        //        {
        //            consulta +=
        //            " and [Id_Categoria_Producto] = " + idcategoria;
        //        }
        //    }
               
//   if (idsubcategoria != -1)
//{
//    if (consulta == "")
//    {
//        consulta =
//        "select * from ProductosDeListView where [Id_Categoria_Producto] = " + idcategoria + "and [Id_Subcategoria_Producto] = " + idsubcategoria;
//    }
//    else
//    {
//        consulta +=
//        " and [Id_Categoria_Producto] = " + idcategoria + " and [Id_Subcategoria_Producto] = " + idsubcategoria;
//    }
//}

//if (nombre != "")
//{
//    if (consulta == "")
//    {
//        consulta =
//        "select * from ProductosDeListView where [Nombre_Producto] like '%" + nombre + "%' ";
//    }
//    else
//    {
//        consulta +=
//        " and [Nombre_Producto] like '%" + nombre + "%'";
//    }
//}

//if (min != -1 && max != -1)
//{
//    if (consulta == "")
//    {
//        consulta =
//        "select * from ProductosDeListView where [Precio_Producto] between " + min + "and " + max;
//    }
//    else
//    {
//        consulta +=
//        " and [Precio_Producto] between " + min + "and " + max;
//    }
//}

//if (consulta == "")
//{
//    consulta = "select * from ProductosDeListView";
//    return dPr.ObtenerProductosConsulta(consulta);
//}

//return dPr.ObtenerProductosConsulta(consulta);






    }
}
