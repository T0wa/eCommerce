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
    public partial class MiPerfil : System.Web.UI.Page
    {
        LogicaProductos logProd = new LogicaProductos();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Globales.usuario] == null)
                Server.Transfer("iniciarSesion.aspx");  //Si de alguna manera se entra a este formulario sin estar ingresado, se lo redirije a iniciar sesion.

            Usuarios usAux = (Usuarios)Session[Globales.usuario];
            LogicaFacturas logFac = new LogicaFacturas();
            LabelsUsuario(usAux);

            if (!IsPostBack)
            {
                
                if (usAux.EsAdmin)
                    lblEsAdmin.Text = "Usted cuenta con permisos de administrador.";
                else
                    lblEsAdmin.Text = "";

                if (logFac.obtenerFacturaSegunCliente(usAux).Rows.Count > 0)
                {
                    grdFacturas.DataSource = logFac.obtenerFacturaSegunCliente(usAux);
                    grdFacturas.DataBind();
                    lblNoCompro.Text = "";
                }
                else
                    lblNoCompro.Text = "Aun no ha comprado nada!";

                CargadoCampos();
            }
        }

        private void LabelsUsuario(Usuarios usAux)
        {
            lblNombreUsuario.Text = usAux.Nombre + " " + usAux.Apellido;
            lblNombreCompleto.Text = usAux.Nombre + " " + usAux.Apellido;
            lblEmail.Text = usAux.Email;
        }
        private void asignadoTextBoxs(Usuarios usr)
        {
            txtCambiarNombre.Text = usr.Nombre;
            txtCambiarApellido.Text = usr.Apellido;
            txtCambiarContraseña.Text = usr.Contraseña;
            txtCambiarContraseña.Attributes["value"] = txtCambiarContraseña.Text;
            txtConfirmarCambio.Text = usr.Contraseña;
            txtConfirmarCambio.Attributes["value"] = txtConfirmarCambio.Text;
            txtConfirmarCambio.TextMode = TextBoxMode.Password;
            txtCambiarContraseña.TextMode = TextBoxMode.Password;
            txtCambiarCorreo.Text = usr.Email;
        }

        private void CargadoCampos()
        {
            LogicaUsuarios _LogicaUsr = new LogicaUsuarios();
            Usuarios usr = new Usuarios();
            usr.Email = ((Usuarios)Session[Globales.usuario]).Email;
            usr = _LogicaUsr.getUsuarioSegunMail(usr);
            asignadoTextBoxs(usr);
        }

        private void CargarUsuarioEdit(ref Usuarios usAux)
        {
            usAux.Nombre = txtCambiarNombre.Text;
            usAux.Apellido = txtCambiarApellido.Text;
            usAux.Contraseña = txtConfirmarCambio.Text;
            usAux.Email = txtCambiarCorreo.Text;
        }

        private bool VerificarContraseñas()
        {
            if (txtCambiarContraseña.Text == txtConfirmarCambio.Text)
                return true;
            else
                return false;
        }


        protected void btnModificarPerfil_Click(object sender, EventArgs e)
        {
            Usuarios usAux = (Usuarios)Session[Globales.usuario];
            LogicaUsuarios logUs = new LogicaUsuarios();
            CargarUsuarioEdit(ref usAux);
            String MensajeAlerta = string.Format("alert('Perfil modificado correctamente');");
            ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            Session[Globales.usuario] = usAux;
            CargadoCampos();
            LabelsUsuario(usAux);

        }

        protected void grdFacturas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            LogicaFacturas logFac = new LogicaFacturas();
            string idFactura = ((Label)grdFacturas.Rows[e.NewSelectedIndex].FindControl("lbl_it_IdFactura")).Text;
            Facturas facturas = new Facturas();
            facturas.IdFactura = int.Parse(idFactura);
            grdDetalles.DataSource = logFac.obtenerDetalles(facturas);
            grdDetalles.DataBind();
        }

        protected void lbCerrarSesion_Click(object sender, EventArgs e)
        {
            Session[Globales.usuario] = null;
            Response.Redirect("Home.aspx");
        }

        protected void imgBtn_Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}