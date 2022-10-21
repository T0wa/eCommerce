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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        private void EsAdmin()
        {
            if (Session[Globales.usuario] != null && ((Usuarios)Session[Globales.usuario]).EsAdmin == true)
            {
                hlReporteVentas.Visible = true;
                hlFuncionesAdmin.Visible = true;
            }
            else
            {
                hlReporteVentas.Visible = false;
                hlFuncionesAdmin.Visible = false;
            }
        }

        private void NoEstaIniciado()
        {
            if (Session[Globales.usuario] == null)
            {
                hlUsuario.Visible = true;
                lbCerrarSesion.Visible = false;

                hlNombreUsuario.Text = "Sin sesión";
                hlUsuario.Text = "Iniciar sesión";
                hlUsuario.NavigateUrl = "IniciarSesionMP.aspx";
            }
        }

        private void EstaIniciado()
        {
            if (Session[Globales.usuario] != null)
            {
                hlUsuario.Visible = false;
                lbCerrarSesion.Visible = true;

                Usuarios usuarioNombre = (Usuarios)Session[Globales.usuario];
                hlNombreUsuario.Text = usuarioNombre.Nombre + " " + usuarioNombre.Apellido;
                //hlNombreUsuario.NavigateUrl = "MiPerfilMP.aspx";
            }
        }

        private void sesionesUsuario()
        {
            EsAdmin();
            NoEstaIniciado();
            EstaIniciado();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            sesionesUsuario();
        }

        protected void lbCerrarSesion_Click(object sender, EventArgs e)
        {
            Session[Globales.usuario] = null;
            Response.Redirect("~/HomeMp.aspx");
        }

        protected void lbLinkedin_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.linkedin.com/in/santiago-pedrozo-0b8464220/");
        }

        protected void lbGit_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://github.com/santiagopedrozo");
        }

        protected void UtnLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("https://www.frgp.utn.edu.ar/");
        }

        protected void CarritoLb_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarritoMP.aspx");
        }
    }
}