using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class FinalizaarCompra : System.Web.UI.Page
    {
        public void mostrarParteEnvio(bool b)
        {
            if (b)
            {
                lblDireccion.Visible = true;
                lblRango.Visible = true;
                lblProvincia.Visible = true;
                lblLocalidad.Visible = true;
                txtDireccion.Visible = true;
                ddlRango.Visible = true;
                ddlProvincia.Visible = true;
                ddlLocalidades.Visible = true;
            }
            else
            {
                lblDireccion.Visible = false;
                lblRango.Visible = false;
                lblProvincia.Visible = false;
                lblLocalidad.Visible = false;
                txtDireccion.Visible = false;
                txtDireccion.Text = "";
                ddlRango.Visible = false;
                ddlRango.SelectedIndex = 0;
                ddlProvincia.Visible = false;
                ddlProvincia.SelectedIndex = 0;
                ddlLocalidades.Visible = false;
                ddlLocalidades.SelectedIndex = 0;
            }
        }

        public string nombreTarjeta(string numeroTarjeta)
        {
            string nombre;

            if (numeroTarjeta.StartsWith("4"))
                nombre = "Mastercard";
            else if (numeroTarjeta.StartsWith("5"))
                nombre = "Visa";
            else
                nombre = "Tarjeta";

            string ultimosNumeros = numeroTarjeta.Substring(0, 4);

            return nombre + " empezada en " + ultimosNumeros + "...";
        }


        public void cargarddlTarjetas()
        {
            ddlTarjetas.Items.Clear();
            Usuarios user = new Usuarios();
            user = (Usuarios)Session[Globales.usuario];
            string numero;
            LogicaTarjetas lt = new LogicaTarjetas();
            foreach (DataRow dr in lt.tarjetasDeUsuario(user).Rows)
            {
                numero = dr["Numero_Tarjeta"].ToString();
                ddlTarjetas.Items.Add(new ListItem(nombreTarjeta(numero), dr["CodSeguridad_Tarjeta"] + "," + dr["FechaExpiracion_Tarjeta"] + "," + dr["Numero_Tarjeta"]));
            }
        }
        

        public void cargarddlProvincias()
        {
            LogicaProvincias logP = new LogicaProvincias();
            foreach (DataRow dr in logP.getProvincias().Rows)
            {
                ddlProvincia.Items.Add(new ListItem(dr["Nombre_Provincia"].ToString(), dr["Id_Provincia"].ToString()));
            }
        }

        public void cargarddlLocalidades(Provincias prov)
        {
            LogicaProvincias logP = new LogicaProvincias();
            foreach (DataRow dr in logP.getLocalidades(prov).Rows)
            {
                ddlLocalidades.Items.Add(new ListItem(dr["Nombre_Localidad"].ToString(), dr["Id_Localidad"].ToString()));
            }
        }

        //EVENTOS

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Globales.usuario] == null)
                Response.Redirect("iniciarSesion.aspx");

            if (!IsPostBack)
            {
                cargarddlTarjetas();
                cargarddlProvincias();
                mostrarParteEnvio(false);
            }
        }

        protected void rblEnvio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblEnvio.SelectedItem.Text == "SI")
                mostrarParteEnvio(true);
            else
                mostrarParteEnvio(false);
        }

        protected void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {
            Tarjetas tarj = new Tarjetas();
            tarj.NumeroTarjeta = txtNroTarjeta.Text;
            tarj.Usuario = (Usuarios)Session[Globales.usuario];
            tarj.CodigoSeguridad = int.Parse(txtCodigo.Text);
            tarj.FechaExpiracion = Convert.ToDateTime(txtVencimiento.Text);

            LogicaTarjetas logTar = new LogicaTarjetas();
            if (logTar.agregarTarjeta(tarj))
            {
                lblConfirmacionTarjetas.Text = "Se ha agregado la tarjeta.";
            }
            cargarddlTarjetas();
        }

        protected void ddlTarjetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTarjetas.SelectedValue != "-1")
            {
                string[] campos = ddlTarjetas.SelectedItem.Value.Split(',');

                txtCodigo.Text = campos[0];
                txtVencimiento.Text = Convert.ToDateTime(campos[1]).ToString("yyyy-MM-dd");
                txtNroTarjeta.Text = "";
            }
            else
            {
                txtCodigo.Text = "";
                txtVencimiento.Text = "";
                txtNroTarjeta.Text = "";
            }
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLocalidades.Items.Clear();
            ddlLocalidades.Items.Add(new ListItem("Seleccione la localidad de destino", "-1"));

            if (ddlProvincia.SelectedItem.Value != "-1")
            {
                Provincias prov = new Provincias();
                prov.IdProvincia = int.Parse(ddlProvincia.SelectedItem.Value);
                cargarddlLocalidades(prov);
            }
        }

        protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            LogicaFacturas logFac = new LogicaFacturas();
            DataTable dt = new DataTable();
            Facturas fac = new Facturas();
            if (txtNroTarjeta.Text == ddlTarjetas.SelectedItem.Value.Split(',')[2].Trim())
            {
                fac.Tarjeta.NumeroTarjeta = txtNroTarjeta.Text;
                fac.Envio = rblEnvio.SelectedItem.Text == "SI";
                if (rblEnvio.SelectedItem.Text == "SI")
                {
                    fac.DireccionEnvio = txtDireccion.Text;
                    fac.RangoHorario = ddlRango.SelectedItem.Text;
                    fac.Localidad.IdLocalidades = int.Parse(ddlLocalidades.SelectedItem.Value);
                    fac.Localidad.Provincia.IdProvincia = int.Parse(ddlProvincia.SelectedItem.Value);
                }
                dt = (DataTable)Session[Globales.carrito];
                logFac.agregarFactura(fac, dt);
                lblConfirmacionCompra.Text = "Se ha realizado la compra correctamente.";
            }
            else
                lblConfirmacionCompra.Text = "El numero de tarjeta fue incorrecto.";
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LogicaTarjetas logTar = new LogicaTarjetas();
            Tarjetas tarj = new Tarjetas();
            tarj.NumeroTarjeta = ddlTarjetas.SelectedItem.Value.Split(',')[2].Trim();
            if (logTar.eliminarTarjeta(tarj))
                lblConfirmacionTarjetas.Text = "La tarjeta ha sido eliminada exitosamente.";
            else
                lblConfirmacionTarjetas.Text = "No se pudo eliminar la tarjeta.";

            cargarddlTarjetas();
        }

        protected void imgBtn_Carrito_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Carrito.aspx");
        }

        protected void imgBtn_Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}