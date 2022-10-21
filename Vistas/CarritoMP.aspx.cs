using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class CarritoMP : System.Web.UI.Page
    {
        private void cargarGrilla()
        {
            grdProductosCarrito.DataSource = (DataTable)Session[Globales.carrito];
            grdProductosCarrito.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[Globales.carrito] != null)
                {
                    
                    cargarGrilla();
                    actualizarTotal();
                }
            }
        }

        private void actualizarTotal()
        {
            float totalProd = 0;
            float totalGral = 0;
            var dt = (DataTable)Session[Globales.carrito];

            foreach (DataRow dr in dt.Rows)
            {
                totalProd = float.Parse(dr["Precio"].ToString()) * int.Parse(dr["Cantidad"].ToString());
                
                dr["Total"] = totalProd;
                Session[Globales.carrito] = dt;


                totalGral =+ totalProd;
                lblTotal.Text = "Precio total: $" + totalGral;
            }
            
            cargarGrilla();
        }

        private void setCantidad(ref CommandEventArgs e, int cant)
        {
            var id = e.CommandArgument.ToString();
            var dt = (DataTable)Session[Globales.carrito];

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["IdProd"].ToString() == id)
                {
                    var nro = int.Parse(dr["Cantidad"].ToString());                    
                    nro += cant;

                    if (nro == 0)
                        nro = 1;

                    dr["Cantidad"] = nro;
                    Session[Globales.carrito] = dt;

                    cargarGrilla();
                    actualizarTotal();
                    return;
                }
            }
        }

        protected void lbAgregar_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "Incremento")
                setCantidad(ref e, 1);
            
        }

        protected void lbQuitar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Decremento")
                setCantidad(ref e, -1);
            
            
        }

        protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("FinalizaarCompra.aspx");
        }

        protected void lbEliminar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "EliminadoCarrito")
            {
                var id = int.Parse(e.CommandArgument.ToString());
                var dt = (DataTable)Session[Globales.carrito];

                foreach(DataRow dr in dt.Rows)
                {
                    if(dr["IdProd"].ToString() == id.ToString())
                    {
                        dr.Delete();
                        cargarGrilla();
                        actualizarTotal();
                        return;
                    }
                }

            }
        }

        protected void ProdImg_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DetalleProductoMP.aspx");
        }
    }
}