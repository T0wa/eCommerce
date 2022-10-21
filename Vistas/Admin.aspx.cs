using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Vistas
{
    public partial class Admin : System.Web.UI.Page
    {
        private Productos _producto = new Productos();
        LogicaProductos _LogicaProd = new LogicaProductos();
        
        LogicaSubCategorias _LogicaSubCat = new LogicaSubCategorias();
        private void cargarGrdProductos()
        {
            FiltrosProductos _filtrosSession = Session[Globales.FiltrosGrdAdmin] as FiltrosProductos;
            grdProductos.DataSource = _LogicaProd.BusquedaConFiltrosGrdAdmin(_filtrosSession.IdCat, _filtrosSession.IdSubCat, _filtrosSession.Nombre);
            grdProductos.DataBind();
        }

        private void cargarGrdCategorias()
        {
            LogicaCategorias _LogicaCat = new LogicaCategorias();
            Categorías _CatFiltros = Session[Globales.CategoriasFiltro] as Categorías;
            grdCategorias.DataSource = _LogicaCat.BusquedaConFiltrosGrdAdmin(_CatFiltros.Descripcion);
            grdCategorias.DataBind();
        }

        private void cargarGrdSubCategorias()
        {
            SubCategorias _SubCatFiltros = Session[Globales.SubCategoriasFiltro] as SubCategorias;
            grdSubCategorias.DataSource = _LogicaSubCat.BusquedaConFiltrosGrdAdmin(_SubCatFiltros.Descripcion, _SubCatFiltros.Categoria.IdCategoria);
            grdSubCategorias.DataBind();
        }

        private void cargarGrdUsuarios()
        {
            LogicaUsuarios _LogicaUsr = new LogicaUsuarios();
            Usuarios usr = Session[Globales.UsuarioFiltro] as Usuarios;
            grdUsuarios.DataSource = _LogicaUsr.BusquedaConFiltrosGrdAdmin(usr.Nombre, usr.Apellido);
            grdUsuarios.DataBind();
        }

        private void DeclaracionSessions()
        {
            Session[Globales.FiltrosGrdAdmin] = new FiltrosProductos();
            Session[Globales.ProductosEdit] = new Productos();
            Session[Globales.ProductosInsert] = new Productos();
            Session[Globales.CategoriasFiltro] = new Categorías();
            Session[Globales.SubCategoriasFiltro] = new SubCategorias();
            Session[Globales.UsuarioFiltro] = new Usuarios();
        }

        private void cargadoDDL()
        {
            cargarDDLCategorias(ref ddlCategoriasAgregar);
            cargarDDLCategorias(ref ddlCategoriasGrd);
            cargarDDLSubCategorias(ref ddlSubCategoriaGrd, 1);
            cargarDDLCategorias(ref ddlCategoriasGrdSub);
            cargarDDLCategorias(ref ddlAgregarCatSub);
            ddlAgregarCatSub.Items.Remove(ddlAgregarCatSub.Items.FindByValue("-1"));
        }

        private void cargadoGRD()
        {
            cargarGrdCategorias();
            cargarGrdProductos();
            cargarGrdSubCategorias();
            cargarGrdUsuarios();
        }

        private void VaciarDivs()
        {
            ProductosDiv.Visible = false;
            CategoriasDiv.Visible = false;
            SubCategoriasDiv.Visible = false;
            UsuariosDiv.Visible = false;
            MensajeProductosDiv.Visible = false;
        }
        
        private void SeleccionDivs()
        {
            switch (ddlEleccionDiv.SelectedValue)
            {
                case "Productos":
                    VaciarDivs();
                    ProductosDiv.Visible = true;
                    break;
                case "Categorías":
                    VaciarDivs();
                    CategoriasDiv.Visible = true;
                    break;
                case "SubCategorías":
                    VaciarDivs();
                    SubCategoriasDiv.Visible = true;
                    break;
                case "Usuarios":
                    VaciarDivs();
                    UsuariosDiv.Visible = true;
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DeclaracionSessions();
                cargadoDDL();
                cargadoGRD();
                VaciarDivs();
            }
            SeleccionDivs();   
        }

        protected void ddlEleccionDiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargadoGRD();
        }

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
            ddl.Items.Insert(0, new ListItem("", "-1"));
        }

        private void cargarDDLSubCategorias(ref DropDownList ddl)
        {
            LogicaSubCategorias _logicaSubCat = new LogicaSubCategorias();

            ddl.DataSource = _logicaSubCat.getSubCategorias();
            ddl.DataTextField = "Descripcion_Subcategoria";
            ddl.DataValueField = "Id_Subcategoria";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("", "-1"));
        }

        ///CARGA PRODUCTOS

        private void cargarProductoInsert(ref Productos _producto)
        {
            _producto.Nombre = txtNombreInsert.Text;
            _producto.Descripcion = txtDescripInsert.Text;
            _producto.Precio = decimal.Parse(txtPrecioInsert.Text);
            _producto.Stock = int.Parse(txtStockInsert.Text);
            _producto.Subcategoria.IdSubCategoria = int.Parse(ddlSubCategoriaAgregar.SelectedValue);
            _producto.Subcategoria.Categoria.IdCategoria = int.Parse(ddlCategoriasAgregar.SelectedValue);
            _producto.UrlImage = txtUrlInsert.Text;
            //Response.Write(_producto.Subcategoria.IdSubCategoria.ToString() + _producto.Subcategoria.Categoria.IdCategoria.ToString());
            Response.Write(" nombre: " + _producto.Nombre.ToString() + " descripcion: " + _producto.Descripcion.ToString() + " precio: " + _producto.Precio.ToString() + " categoria: " + _producto.Subcategoria.Categoria.IdCategoria.ToString() + " subcategoria: " + _producto.Subcategoria.IdSubCategoria.ToString() + " stock: " + _producto.Stock.ToString() + " url: " + _producto.UrlImage.ToString());
        }

        protected void grdProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Productos _prod = new Productos();
            //cargarProductoEdit(ref _prod, e);
            LogicaProductos _logicaProd = new LogicaProductos();

            if (_logicaProd.ActualizarProducto(_prod))
            {
                String MensajeAlerta = string.Format("alert('editado correctamente');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }
            else
            {
                String MensajeAlerta = string.Format("alert('No se pudo editar');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }
                        
            CancelarEditingProductos();
        }

        private void cargarProductoEdit(ref Productos _producto, GridViewUpdateEventArgs e)
        {
            LogicaCategorias _logicaCat = new LogicaCategorias();

            _producto.IdProducto = int.Parse(((Label)grdProductos.Rows[e.RowIndex].FindControl("lbl_eit_IdProducto")).Text);
            _producto.Nombre = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txtNombreEdit")).Text;
            _producto.Subcategoria.IdSubCategoria = int.Parse(((DropDownList)grdProductos.Rows[e.RowIndex].FindControl("ddlSubCatEdit")).SelectedValue);
            _producto.Subcategoria.Categoria.IdCategoria = _logicaCat.obtenerCatPorIdSubCat(_producto.Subcategoria.IdSubCategoria);
            _producto.Descripcion = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txtDescEdit")).Text;
            _producto.Precio = decimal.Parse(((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txtPrecioEdit")).Text);
            _producto.Stock = int.Parse(((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txtStockEdit")).Text);
            _producto.UrlImage = ((TextBox)grdProductos.Rows[e.RowIndex].FindControl("txtUrlEdit")).Text;
            Response.Write(" nombre: " + _producto.Nombre.ToString() + " descripcion: " + _producto.Descripcion.ToString() + " precio: " + _producto.Precio.ToString() + " categoria: " + _producto.Subcategoria.Categoria.IdCategoria.ToString() + " subcategoria: " + _producto.Subcategoria.IdSubCategoria.ToString() + " stock: " + _producto.Stock.ToString() + " url: " + _producto.UrlImage.ToString());
            //Response.Write("id "_producto.IdProducto.ToString() + _producto.Subcategoria.Categoria.IdCategoria.ToString() + _producto.Subcategoria.IdSubCategoria.ToString() + _producto.Nombre.ToString());
        }

        protected void grdProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdProductos.EditIndex = e.NewEditIndex;
            cargarGrdProductos();
        }

        private void CancelarEditingProductos()
        {
            grdProductos.EditIndex = -1;
            cargarGrdProductos();
        }

        ///CATEGORIAS
        protected void grdProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            CancelarEditingProductos();
        }

        private void vaciarCamposInsertProd()
        {
            txtNombreInsert.Text = "";
            txtDescripInsert.Text = "";
            txtPrecioInsert.Text = "";
            txtStockInsert.Text = "";
            txtUrlInsert.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Productos _producto = new Productos();
            LogicaProductos _LogicaProd = new LogicaProductos();
            cargarProductoInsert(ref _producto);
            

            if (_producto.Subcategoria.IdSubCategoria == -1 || _producto.Subcategoria.Categoria.IdCategoria == -1)
            {
                String MensajeAlerta = string.Format("alert('Debe elegir una categoria y una subCategoria');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }
            else
            {
                //Response.Write(" nombre: " + _producto.Nombre.ToString() + " descripcion: " + _producto.Descripcion.ToString() + " precio: " + _producto.Precio.ToString() + " categoria: " + _producto.Subcategoria.Categoria.IdCategoria.ToString() + " subcategoria: " + _producto.Subcategoria.IdSubCategoria.ToString() + " stock: " + _producto.Stock.ToString() + " url: " + _producto.UrlImage.ToString());
                if (_LogicaProd.agregarProducto(_producto))
                {
                    String MensajeAlerta = string.Format("alert('Se agrego correctamente el producto');");
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
                    vaciarCamposInsertProd();
                }
                else
                {
                    String MensajeAlerta = string.Format("alert('No se pudo agregar el producto');");
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
                }
                    
            }

        }

        protected void ddlCategoriasGrd_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCat = sender as DropDownList;

            FiltrosProductos _filtrosSessionGrdAdmin = Session[Globales.FiltrosGrdAdmin] as FiltrosProductos;
            _filtrosSessionGrdAdmin.Nombre = txtNombreGrd.Text;
            _filtrosSessionGrdAdmin.IdCat = int.Parse(ddlCat.SelectedValue);
            Session[Globales.FiltrosGrdAdmin] = _filtrosSessionGrdAdmin;

            cargarGrdProductos();
            cargarDDLSubCategorias(ref ddlSubCategoriaGrd, int.Parse(ddlCat.SelectedValue));
        }

        protected void ddlSubCategoriaGrd_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlSubCat = sender as DropDownList;

            FiltrosProductos _filtrosSessionGrdAdmin = Session[Globales.FiltrosGrdAdmin] as FiltrosProductos;
            _filtrosSessionGrdAdmin.IdSubCat = int.Parse(ddlSubCat.SelectedValue);
            Session[Globales.FiltrosGrdAdmin] = _filtrosSessionGrdAdmin;
            cargarGrdProductos();
        }


        ///VISTA PRODUCTOS
        protected void btn_FiltrarGrdProd_Click(object sender, EventArgs e)
        {
            FiltrosProductos _filtrosSessionGrdAdmin = Session[Globales.FiltrosGrdAdmin] as FiltrosProductos;
            _filtrosSessionGrdAdmin.Nombre = txtNombreGrd.Text;
            txtNombreGrd.Text = "";

            cargarGrdProductos();
        }

        protected void btn_SacarFiltrarGrdProd_Click(object sender, EventArgs e)
        {
            Session[Globales.FiltrosGrdAdmin] = new FiltrosProductos();
            cargarGrdProductos();
        }


        ///DELETE PRODUCTOS

        protected void grdProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            _producto.IdProducto = int.Parse(((Label)grdProductos.Rows[e.RowIndex].FindControl("lbl_it_IdProducto")).Text);
            Response.Write(_producto.IdProducto.ToString());

            if (_LogicaProd.BajaProducto(_producto))
            {
                String MensajeAlerta = string.Format("alert('borrado corectaente');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }
            else
            {
                String MensajeAlerta = string.Format("alert('No se pudo borrar');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }

            cargarGrdProductos();
        }
        ///EDIT PRODUCTOS


        private void CancelarEditingCategorias()
        {
            grdCategorias.EditIndex = -1;
            cargarGrdCategorias();
        }

        protected void grdCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            CancelarEditingCategorias();
        }

        protected void grdCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCategorias.PageIndex = e.NewPageIndex;
            cargarGrdCategorias();
        }

        protected void grdCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCategorias.EditIndex = e.NewEditIndex;
            cargarGrdCategorias();
        }

        private bool ValidacionCatEdit(GridViewUpdateEventArgs e)
        {
            string desc = ((TextBox)grdCategorias.Rows[e.RowIndex].FindControl("txt_eit_descripcion")).Text;

            if (desc == "")
                return false;
            else
                return true;
            
        }

        protected void grdCategorias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Categorías _cat = new Categorías();
            LogicaCategorias _LogicaCat = new LogicaCategorias();
            if (ValidacionCatEdit(e))
            {
                _cat.IdCategoria = int.Parse(((Label)grdCategorias.Rows[e.RowIndex].FindControl("lbl_eit_Id")).Text);
                _cat.Descripcion = ((TextBox)grdCategorias.Rows[e.RowIndex].FindControl("txt_eit_descripcion")).Text;

                if (_LogicaCat.EditarCategoria(_cat))
                {
                    String MensajeAlerta = string.Format("alert('cargado correctamente');");
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
                }
                else
                {
                    String MensajeAlerta = string.Format("alert('no pudo ser cargado');");
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
                }
            }
            else
            {
                String MensajeAlerta = string.Format("alert('LA DESCRIPCIÓN NO PUEDE QUEDAR VACIA');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }
            Response.Write(_cat.IdCategoria.ToString() + _cat.Descripcion.ToString());
            CancelarEditingCategorias();
            cargarDDLCategorias(ref ddlAgregarCatSub);
        }

        protected void grdProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductos.PageIndex = e.NewPageIndex;
            cargarGrdProductos();
        }

        //ELIMINAR CATEGORIAS

        protected void grdCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            LogicaCategorias _LogicaCat = new LogicaCategorias();
            Categorías cat = new Categorías();
            cat.IdCategoria = int.Parse(((Label)grdCategorias.Rows[e.RowIndex].FindControl("lbl_it_Id")).Text);
            if (_LogicaCat.darDeBajaCategoria(cat))
            {
                String MensajeAlerta = string.Format("alert('Categoria borrada exitosamente');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }
            else
            {
                String MensajeAlerta = string.Format("alert('La categoria no se pudo borrar');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }

            cargarGrdCategorias();
            cargarDDLCategorias(ref ddlAgregarCatSub);
        }

        protected void btnAgregarCat_Click(object sender, EventArgs e)
        {
            LogicaCategorias _LogicaCat = new LogicaCategorias();
            Categorías cat = new Categorías();
            if(txt_AgregarDescCat.Text == "")
            {
                lblAgregadoCatInsert.Text = "Descripción vacia";
                lblAgregadoCatInsert.ForeColor = Color.Red;
                return;
            }
            else
                cat.Descripcion = txt_AgregarDescCat.Text;

            if (_LogicaCat.InsertCategoria(cat))
            {
                String MensajeAlerta = string.Format("alert('Agregado correctamente');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }
            else
            {
                String MensajeAlerta = string.Format("alert('No se pudo agregar');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }

            cargarGrdCategorias();
            cargarDDLCategorias(ref ddlAgregarCatSub);
        }

        //VISTAS CATEGORIAS

        protected void btnFiltrarCat_Click(object sender, EventArgs e)
        {
            Categorías cat = (Categorías)Session[Globales.CategoriasFiltro];
            cat.Descripcion = txtDescCat.Text;
            Session[Globales.CategoriasFiltro] = cat;
            txt_AgregarDescCat.Text = "";

            cargarGrdCategorias();
        }

        protected void btn_SacarFiltrosCat_Click(object sender, EventArgs e)
        {
            Session[Globales.CategoriasFiltro] = new Categorías();
            txtDescCat.Text = "";
            cargarGrdCategorias();
        }


        ///FILTROS SUBCATEGORIAS
        protected void ddlCategoriasGrdSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubCategorias _SubCatFiltros = Session[Globales.SubCategoriasFiltro] as SubCategorias;
            DropDownList ddlCat = sender as DropDownList;
            _SubCatFiltros.Categoria.IdCategoria = int.Parse(ddlCat.SelectedValue);

            Session[Globales.SubCategoriasFiltro] = _SubCatFiltros;
            cargarGrdSubCategorias();
        }

        protected void btn_SacarFiltrosSub_Click(object sender, EventArgs e)
        {
            Session[Globales.SubCategoriasFiltro] = new SubCategorias();
            txtDescSubCat.Text = "";
            cargarGrdSubCategorias();
        }

        protected void btnFiltrarSub_Click(object sender, EventArgs e)
        {
            SubCategorias _SubCatFiltros = Session[Globales.SubCategoriasFiltro] as SubCategorias;
            _SubCatFiltros.Descripcion = txtDescSubCat.Text;

            Session[Globales.SubCategoriasFiltro] = _SubCatFiltros;
            cargarGrdSubCategorias();
        }

        protected void grdSubCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSubCategorias.PageIndex = e.NewPageIndex;
            cargarGrdSubCategorias();
        }

        protected void grdSubCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int IdSubCat = int.Parse( ((Label)grdSubCategorias.Rows[e.RowIndex].FindControl("lbl_it_SubCat")).Text );
            SubCategorias _cat = new SubCategorias();
            LogicaSubCategorias _LogicaSubCat = new LogicaSubCategorias();
            _cat.IdSubCategoria = IdSubCat;
            if (_LogicaSubCat.EliminarSubCategoria(_cat))
            {
                String MensajeAlerta = string.Format("alert('eliminado correctamente');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }
            else
            {
                String MensajeAlerta = string.Format("alert('No se pudo eliminar');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }

            cargarGrdSubCategorias();
            //Response.Write("SubCategoria a eliminar: " + _cat.IdSubCategoria.ToString());
        }

        protected void grdSubCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdSubCategorias.EditIndex = e.NewEditIndex;
            cargarGrdSubCategorias();
        }

        private void CancelarEditingSubCat()
        {
            grdSubCategorias.EditIndex = -1;
            cargarGrdSubCategorias();
        }

        protected void grdSubCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            CancelarEditingSubCat();
        }

        protected void grdSubCategorias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SubCategorias cat = new SubCategorias();
            cat.IdSubCategoria = int.Parse(((Label)grdSubCategorias.Rows[e.RowIndex].FindControl("lbl_eit_SubCat")).Text);
            
            if(((TextBox)grdSubCategorias.Rows[e.RowIndex].FindControl("txt_eit_DescSub")).Text == "")
            {
                lblAgregadoCatInsert.Text = "Descripción vacia";
                lblAgregadoCatInsert.ForeColor = Color.Red;
                return;
            }
            else
            {
                cat.Descripcion = ((TextBox)grdSubCategorias.Rows[e.RowIndex].FindControl("txt_eit_DescSub")).Text;
            }

            LogicaSubCategorias _LogicaSubCat = new LogicaSubCategorias();
            if (_LogicaSubCat.EditarSubCategoria(cat))
            {
                String MensajeAlerta = string.Format("alert('editado correctamente');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }
            else
            {
                String MensajeAlerta = string.Format("alert('No se pudo editar');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }

            //Response.Write("Descripcion sub a editar: " + cat.Descripcion.ToString());

            CancelarEditingSubCat();
        }

        protected void btnAgregarSubCat_Click(object sender, EventArgs e)
        {
            SubCategorias Subcat = new SubCategorias();

            Subcat.Descripcion = txtDescAgregarSubCat.Text;
            Subcat.Categoria.IdCategoria = int.Parse(ddlAgregarCatSub.SelectedValue);

            LogicaSubCategorias _LogicaSubCat = new LogicaSubCategorias();
            if (_LogicaSubCat.InsertSubCategoria(Subcat))
            {
                String MensajeAlerta = string.Format("alert('SubCategoria agregada correctamente');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
                cargarGrdSubCategorias();
            }
            else
            {
                String MensajeAlerta = string.Format("alert('No se pudo agregar');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }
                
            txtDescAgregarSubCat.Text = "";

            //Response.Write("Subcategoria para agregar: " + Subcat.Descripcion.ToString() + Subcat.Categoria.IdCategoria.ToString());
        }

        ///USUARIOS

        protected void grdUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string dni = ((Label)grdUsuarios.Rows[e.RowIndex].FindControl("lbl_it_dni")).Text;
            Usuarios usr = new Usuarios();
            usr.Dni = int.Parse(dni);
            Response.Write("dni a eliminar: " + usr.Dni.ToString());
            LogicaUsuarios _LogicaUsr = new LogicaUsuarios();
            if (_LogicaUsr.eliminarUsuario(usr))
            {
                String MensajeAlerta = string.Format("alert('Eliminado correctamente');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }
            else
            {
                String MensajeAlerta = string.Format("alert('No se pudo eliminar');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }
            cargarGrdUsuarios();
        }

        protected void grdUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUsuarios.PageIndex = e.NewPageIndex;
            cargarGrdUsuarios();
        }

        protected void grdUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdUsuarios.EditIndex = e.NewEditIndex;
            cargarGrdUsuarios();
        }

        private void cancelingEditUsr()
        {
            grdUsuarios.EditIndex = -1;
            cargarGrdUsuarios();
        }

        protected void grdUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            cancelingEditUsr();
        }

        protected void grdUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string dni = ((Label)grdUsuarios.Rows[e.RowIndex].FindControl("lbl_eit_dni")).Text;
            bool Admin = ((CheckBox)grdUsuarios.Rows[e.RowIndex].FindControl("cb_Admin")).Checked;
            LogicaUsuarios _LogicaUsr = new LogicaUsuarios();
            Usuarios usr = new Usuarios();
            usr.Dni = int.Parse(dni);
            usr.EsAdmin = Admin;

            //Response.Write("Usuario a editar: " + usr.Dni.ToString() + usr.EsAdmin.ToString());
            if (_LogicaUsr.EditarAdminUsuario(usr))
            {
                String MensajeAlerta = string.Format("alert('Editado correctamente');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }
            else
            {
                String MensajeAlerta = string.Format("alert('No se pudo editar');");
                ScriptManager.RegisterClientScriptBlock(Page, typeof(System.Web.UI.Page), "redirect", MensajeAlerta, true);
            }
            cancelingEditUsr();
        }

        protected void btnFiltrarUsr_Click(object sender, EventArgs e)
        {
            Usuarios usr = Session[Globales.UsuarioFiltro] as Usuarios;
            usr.Nombre = txtNombreUsr.Text;
            usr.Apellido = txtApellidoUsr.Text;

            Session[Globales.UsuarioFiltro] = usr;
            cargarGrdUsuarios();
        }

        protected void btnQuitarFiltrosUsr_Click(object sender, EventArgs e)
        {
            Session[Globales.UsuarioFiltro] = new Usuarios();
            txtApellidoUsr.Text = "";
            txtNombreUsr.Text = "";
            cargarGrdUsuarios();
        }

        protected void ddlCategoriasAgregar_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDDLSubCategorias(ref ddlSubCategoriaAgregar, int.Parse( ddlCategoriasAgregar.SelectedValue) );
        }

        protected void grdProductos_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            grdProductos.PageIndex = e.NewPageIndex;
            cargarGrdProductos();
        }

        protected void grdProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList SubCat = (DropDownList)e.Row.FindControl("ddlSubCatEdit");
                    cargarDDLSubCategorias(ref SubCat);
                    SubCat.Items.Remove(SubCat.Items.FindByValue("-1"));
                }
            }

            foreach (Button button in e.Row.Cells[0].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('¿Esta seguro que quiere borrar este producto?')){ return false; };";
                }
            }
        }

        protected void cvPrecioEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(!decimal.TryParse( args.Value , out _))
            {
                args.IsValid = false;
            }
            args.IsValid = true;
        }

        protected void imgBtn_Logo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        protected void grdCategorias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (Button button in e.Row.Cells[0].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('¿Esta seguro que quiere borrar esta categoría?')){ return false; };";
                }
            }
        }

        protected void grdSubCategorias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (Button button in e.Row.Cells[0].Controls.OfType<Button>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('¿Esta seguro que quiere borrar esta Subcategoría?')){ return false; };";
                }
            }
        }

        protected void imgBtn_Carrito_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Carrito.aspx");
        }
    }
}