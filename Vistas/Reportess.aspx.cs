using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;



namespace Vistas
{
    public partial class Reportess : System.Web.UI.Page
    {
        private void LogicaUsuario()
        {
            if (Session[Globales.usuario] == null)
            {
                hlUsuario.Text = "Ingresar";
                hlUsuario.NavigateUrl = "~/iniciarSesion.aspx";
                lblNombreUsuario.Text = "";
            }
            else
            {
                hlUsuario.Text = "Mi Perfil";
                hlUsuario.NavigateUrl = "~/MiPerfil.aspx";
                Usuarios usuarioNombre = (Usuarios)Session[Globales.usuario];
                lblNombreUsuario.Text = usuarioNombre.Nombre + " " + usuarioNombre.Apellido;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTodosLosDdl();
                cargarGrd();
                LogicaUsuario();
            }
            
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string fechaDesde = "";
            string fechaHasta = "";
            logicaReportes log = new logicaReportes();
            if(txtDesde.Text !="" && txtHasta.Text !="")
            {
                 fechaDesde = calDesde.SelectedDate.ToString("yyyyMMdd");
                 fechaHasta = calHasta.SelectedDate.ToString("yyyyMMdd");
            }

            grdFacturas.DataSource = log.cargarConFiltros(fechaDesde,fechaHasta,txtPreMin.Text, txtPreMax.Text, txtCantMin.Text, txtCantMax.Text, ddlSubCategoria.SelectedValue.ToString(),ddlCategoria.SelectedValue.ToString(),rblEnvio.SelectedValue.ToString(),ddlFactura.SelectedValue.ToString());
            grdFacturas.DataBind();
            limpiarFiltros();

        }

       

        private void CargarTodosLosDdl()
        {
            logicaReportes log = new logicaReportes();

            ddlCategoria.DataSource = log.dllCat();
            ddlCategoria.DataTextField = "Descripcion_Categoria";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("", "-1"));


            ddlSubCategoria.DataSource = log.dllSubCat();
            ddlSubCategoria.DataTextField = "Descripcion_Subcategoria";
            ddlSubCategoria.DataBind();
            ddlSubCategoria.Items.Insert(0, new ListItem("", "-1"));

            ddlFactura.DataSource = log.ddlFacturas();
            ddlFactura.DataTextField = "Id_Factura";
            ddlFactura.DataBind();
            ddlFactura.Items.Insert(0, new ListItem("", "-1"));
        }

        private void cargarGrd()
        {

            logicaReportes log = new logicaReportes();

            grdFacturas.DataSource = log.cargarFacturas();
            grdFacturas.DataBind();

        }

        private void limpiarFiltros()
        {
            TextBox[] filtrados = { txtDesde, txtHasta,txtPreMin, txtPreMax, txtCantMin, txtCantMax };

            for(int i = 0; i < 6; i++)
            {
                filtrados[i].Text = "";
            }

            ddlCategoria.SelectedIndex = 0;
            ddlSubCategoria.SelectedIndex = 0;
            ddlFactura.SelectedIndex = 0;
            rblEnvio.ClearSelection();
            calHasta.SelectedDates.Clear();
            calDesde.SelectedDates.Clear();
            calHasta.Visible = false;
            calDesde.Visible = false;
            lblMensaje.Text = "";
        }

        protected void btnDesde_Click(object sender, EventArgs e)
        {
            calHasta.Visible = false;
            calDesde.Visible = !calDesde.Visible;
            
        }

        protected void btnHasta_Click(object sender, EventArgs e)
        {
            calDesde.Visible = false;
            calHasta.Visible = !calHasta.Visible;
        }


        protected void calDesde_SelectionChanged(object sender, EventArgs e)
        {
            txtDesde.Text = calDesde.SelectedDate.ToShortDateString();
        }

        protected void calHasta_SelectionChanged(object sender, EventArgs e)
        {
            txtHasta.Text = calHasta.SelectedDate.ToShortDateString();
        }

        protected void grdFacturas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Facturas factura = new Facturas();
            logicaReportes log = new logicaReportes();

            factura.IdFactura = int.Parse(grdFacturas.Rows[e.RowIndex].Cells[1].Text);

            if (log.borrarFactura(factura))
            {
                lblMensaje.Text = "Factura borrada exitosamente!!";
                grdFacturas.DataSource = log.cargarFacturas();
                grdFacturas.DataBind();
                CargarTodosLosDdl();
            }
            else { lblMensaje.Text = "Error al borrar la factura"; }
        }

        protected void imgBtn_Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        protected void imgBtn_Carrito_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Carrito.aspx");
        }
    }
}