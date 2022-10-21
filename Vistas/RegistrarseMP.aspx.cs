using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class RegistrarseMP : System.Web.UI.Page
    {
        
            private LogicaUsuarios logUS = new LogicaUsuarios();


            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                
                }
            }

            protected void btnRegistrarse_Click(object sender, EventArgs e)
            {
                Usuarios user = new Usuarios();
                user.Nombre = txtNombre.Value;
                user.Apellido = txtApellido.Value;
                user.Dni = int.Parse(txtDni.Value);
                user.Email = txtEmail.Value;
                user.Contraseña = txtConfirmarContra.Value;

                if (logUS.agregarUsuario(user))
                {
                    AlertaCorrecto.Visible = true;
                    AlertaIncorrecto.Visible = true;
                }
                else
                {
                    AlertaCorrecto.Visible = false;
                    AlertaIncorrecto.Visible = true;
                }
                LimpiarCampos();
            }

            public void LimpiarCampos()
            {
                foreach (Control control in Form.Controls)
                {
                    if (control is HtmlInputText)
                    {
                        HtmlInputText txtcampo = (HtmlInputText)control;
                        txtcampo.Value = "";
                    }
                    else if (control is HtmlInputGenericControl)
                    {
                        HtmlInputGenericControl txtcampo = (HtmlInputGenericControl)control;
                        txtcampo.Value = "";
                    }
                }
            }

        }
    
}