using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class HomeMp : System.Web.UI.Page
    {
        private FiltrosProductos _filtros = new FiltrosProductos();
        private LogicaProductos _LogicaProd = new LogicaProductos();
        private LogicaSubCategorias _LogicaSubCat = new LogicaSubCategorias();
        private LogicaCategorias _logicaCategorias = new LogicaCategorias();

        private void cargarDDLCategorias(ref DropDownList ddl)
        {
            LogicaCategorias _logicaCat = new LogicaCategorias();

            ddl.DataSource = _logicaCat.getCategorias();
            ddl.DataValueField = "id_categoria";
            ddl.DataTextField = "Descripcion_Categoria";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("", "-1"));
        }

        private void cargarDDLSubCategorias(ref DropDownList ddl, int id)
        {
            LogicaSubCategorias _logicaSubCat = new LogicaSubCategorias();

            ddl.DataSource = _logicaSubCat.getSubCategoriasXidCategoria(id);
            ddl.DataTextField = "Descripcion_Subcategoria";
            ddl.DataValueField = "Id_Subcategoria";
            ddl.DataBind();
            ddl.Visible = true;
            ddl.Items.Insert(0, new ListItem("", "-1"));
        }

        private void cargadoListView()
        {
            FiltrosProductos _filtrosSession = Session[Globales.FiltrosLvHome] as FiltrosProductos;
            lvProductos.DataSource = _LogicaProd.BusquedaConFiltrosLvHome(_filtrosSession.IdCat, _filtrosSession.IdSubCat, _filtrosSession.Nombre, _filtrosSession.PrecioMinimo, _filtrosSession.PrecioMaximo);
            lvProductos.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session[Globales.FiltrosLvHome] = new FiltrosProductos();
                cargadoListView();
                cargarDDLCategorias(ref ddlCategorias);
            }

        }

        protected void imgProducto_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "seleccionProductoDetalle")
            {
                Session[Globales.prodDetalle] = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("DetalleProductoMP.aspx");
                Session["Puntaje"] = -1;
            }
        }

        private bool validarRepeticion(string nombreProd) //true si es valido el id que se va a ingresar
        {
            if (Session[Globales.carrito] == null)
                return true;

            DataTable dt = new DataTable();
            dt = (DataTable)Session[Globales.carrito];

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Nombre"].ToString() == nombreProd)
                    return false;
            }
            return true;
        }

        public void agregarFilaCarrito(Productos prod) //Si la tabla no existe la crea, sino, agrega una fila
        {
            DataTable dt = new DataTable();
            int cantidad = 1;
            DataRow dr = dt.NewRow();

            if (Session[Globales.carrito] == null)
            {
                dt.Columns.Add(new DataColumn("IdProd"));
                dt.Columns.Add(new DataColumn("Nombre"));
                dt.Columns.Add(new DataColumn("Precio"));
                dt.Columns.Add(new DataColumn("Cantidad"));
                dt.Columns.Add(new DataColumn("Total"));
                dt.Columns.Add(new DataColumn("ImgProd"));
            }
            else
                dt = (DataTable)Session[Globales.carrito];

            if (validarRepeticion(prod.Nombre))
            {
                cantidad = 1;
                dr = dt.NewRow();
            }
            else
            {
                foreach (DataRow dtr in dt.Rows)
                {
                    if (dtr["Nombre"].ToString() == prod.Nombre)
                    {
                        cantidad = int.Parse(dtr["Cantidad"].ToString()) + 1;
                        dr = dtr;
                    }
                }
            }

            dr["ImgProd"] = prod.UrlImage;
            dr["IdProd"] = prod.IdProducto;
            dr["Nombre"] = prod.Nombre;
            dr["Precio"] = prod.Precio;

            dr["Cantidad"] = cantidad;
            dr["Total"] = prod.Precio * cantidad;

            if (validarRepeticion(prod.Nombre))
                dt.Rows.Add(dr);

            Session[Globales.carrito] = dt;
        }

        protected void btnAgregarAlCarrito_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ProductoCarrito")
            {
                Productos prodAux = new Productos();
                prodAux.IdProducto = (int.Parse(e.CommandArgument.ToString()));
                agregarFilaCarrito(_LogicaProd.getProducto(prodAux));
            }
        }

        private void VaciadoControles() //vacia todos los filtros que contienen controles
        {
            txtBusqueda.Text = "";
            txtMaximo.Text = "";
            txtMinimo.Text = "";
            cargarDDLCategorias(ref ddlCategorias);
        }


        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            Session[Globales.FiltrosLvHome] = new FiltrosProductos();
            FiltrosProductos _filtrosSession = Session[Globales.FiltrosLvHome] as FiltrosProductos;

            VaciadoControles();
            cargadoListView();
        }

        private bool verificacionFiltrosPrecio()
        {
            bool estado = true;
            if (txtMinimo.Text == "" || txtMaximo.Text == "")
            {
                estado = false;
                return estado;
            }
            else if (Convert.ToInt32(txtMinimo.Text) > Convert.ToInt32(txtMaximo.Text))
            {
                estado = false;
            }

            return estado;
        }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            cargarDDLSubCategorias(ref ddlSubCat, int.Parse(ddl.SelectedValue));

            FiltrosProductos _filtrosSession = Session[Globales.FiltrosLvHome] as FiltrosProductos;
            _filtrosSession.IdCat = int.Parse(ddl.SelectedValue);
            Session[Globales.FiltrosLvHome] = _filtrosSession;
            SubCatDiv.Visible = true;
            cargadoListView();
        }

        protected void ddlSubCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            FiltrosProductos _filtrosSession = Session[Globales.FiltrosLvHome] as FiltrosProductos;
            Response.Write(ddl.SelectedValue);
            _filtrosSession.IdSubCat = int.Parse(ddl.SelectedValue);
            Session[Globales.FiltrosLvHome] = _filtrosSession;
            cargadoListView();
        }

        protected void lbCerrarSesion_Click(object sender, EventArgs e)
        {
            Session[Globales.usuario] = null;
            Response.Redirect("HomeMp.aspx");
        }

        protected void lbBuscar_Click(object sender, EventArgs e)
        {
            int min = -1;
            int max = -1;

            if (txtMinimo.Text != "" && txtMaximo.Text != "")
            {
                min = int.Parse(txtMinimo.Text);
                max = int.Parse(txtMaximo.Text);
            }


            FiltrosProductos _filtrosSession = Session[Globales.FiltrosLvHome] as FiltrosProductos;
            _filtrosSession.PrecioMaximo = max;
            _filtrosSession.PrecioMinimo = min;
            _filtrosSession.Nombre = txtBusqueda.Text;
            Session[Globales.FiltrosLvHome] = _filtrosSession;

            cargadoListView();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int min = -1;
            int max = -1;

            if (txtMinimo.Text != "" && txtMaximo.Text != "")
            {
                min = int.Parse(txtMinimo.Text);
                max = int.Parse(txtMaximo.Text);
            }


            FiltrosProductos _filtrosSession = Session[Globales.FiltrosLvHome] as FiltrosProductos;
            _filtrosSession.PrecioMaximo = max;
            _filtrosSession.PrecioMinimo = min;
            _filtrosSession.Nombre = txtBusqueda.Text;
            Session[Globales.FiltrosLvHome] = _filtrosSession;

            cargadoListView();
        }
    }
}