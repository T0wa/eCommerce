using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class IniciarSesionMP : System.Web.UI.Page
    {
        
        private LogicaUsuarios logUs = new LogicaUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
 
        protected void btnIngresar_Click1(object sender, EventArgs e)
        {
            Usuarios AuxUs = new Usuarios();

            if (floatingInput.Value.Length.ToString() != "" && floatingPassword.Value.Length.ToString() != "")
            {
                AuxUs.Email = floatingInput.Value;
                AuxUs.Contraseña = floatingPassword.Value;
            }

            if (logUs.verificarQueUsuarioExiste(AuxUs))
            {
                Session["Usuario"] = logUs.getUsuarioSegunMail(AuxUs);
                Usuarios usuarioNombre = (Usuarios)Session["Usuario"];
                Response.Redirect("HomeMp.aspx");
            }
            else
            {
                MsgErrorDiv.Visible = true;
            }
        }

    }
}