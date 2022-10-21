<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Vistas.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous">
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>

    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            font-size: small;
        }
        </style>
</head>
    
<body>
    <script src="FuncionesConfirmaciones.js"></script>

    <form id="form1" runat="server">

        <div>>
            <asp:Label ID="seleccionarDivision" runat="server" Text="Agregar Productos" style="font-size: xx-large"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlEleccionDiv" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="ddlEleccionDiv_SelectedIndexChanged">
                <asp:ListItem Value=""></asp:ListItem>
                <asp:ListItem>Productos</asp:ListItem>
                <asp:ListItem>Categorías</asp:ListItem>
                <asp:ListItem>SubCategorías</asp:ListItem>
                <asp:ListItem>Usuarios</asp:ListItem>
            </asp:DropDownList>
        </div>

       
         <div id="ProductosDiv" runat="server">
            <div style="margin-left:300px">
                <asp:Label ID="lblCat0" runat="server" Text="Categoría:"></asp:Label>
                <asp:DropDownList ID="ddlCategoriasGrd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoriasGrd_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="lblSub0" runat="server" Text="SubCategoría:"></asp:Label>
                <asp:DropDownList ID="ddlSubCategoriaGrd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubCategoriaGrd_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:TextBox ID="txtNombreGrd" runat="server" Width="136px" placeholder="Nombre Producto"></asp:TextBox>
                <asp:Button ID="btn_FiltrarGrdProd" runat="server" OnClick="btn_FiltrarGrdProd_Click" Text=" Filtrar" Width="78px" />
                <asp:Button ID="btn_SacarFiltrarGrdProd" runat="server" OnClick="btn_SacarFiltrarGrdProd_Click" Text=" Quitar filtros" Width="107px" />
                <br />
             </div>
             <asp:GridView ID="grdProductos" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="grdProductos_RowCancelingEdit" OnRowDeleting="grdProductos_RowDeleting" OnRowEditing="grdProductos_RowEditing" OnRowUpdating="grdProductos_RowUpdating" AllowPaging="True" PageSize="5" OnPageIndexChanging="grdProductos_PageIndexChanging1" OnRowDataBound="grdProductos_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                 <AlternatingRowStyle BackColor="White" />
                 <Columns>
                     <asp:CommandField ShowDeleteButton="True" ButtonType="Button" runat="server"/>
                     <asp:CommandField ShowEditButton="true" ButtonType="Button" runat="server" />
                     
                     <asp:TemplateField HeaderText="ID producto">
                         <EditItemTemplate>
                             <asp:Label ID="lbl_eit_IdProducto" runat="server" Text='<%# Bind("Id_Producto") %>'></asp:Label>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_IdProducto" runat="server" Text='<%# Bind("Id_Producto") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Categoría">
                         <EditItemTemplate>
                             <asp:Label ID="lbl_eit_IdCat" runat="server" Text='<%# Bind("Id_Categoria_Producto") %>'></asp:Label>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_IdCat" runat="server" Text='<%# Bind("Id_Categoria_Producto") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Subcategoría">
                         <EditItemTemplate>
                             <asp:DropDownList ID="ddlSubCatEdit" runat="server">
                             </asp:DropDownList>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_IdSubCat" runat="server" Text='<%# Bind("Id_Subcategoria_Producto") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Nombre producto">
                         <EditItemTemplate>
                             <asp:TextBox ID="txtNombreEdit" runat="server" Width="195px" Text='<%# Bind("Nombre_Producto") %>'></asp:TextBox>
                             <br />
                             <asp:RequiredFieldValidator ID="rfvNombreEdit" runat="server" ControlToValidate="txtNombreEdit" CssClass="auto-style6" ErrorMessage="Campo nombre vacio"></asp:RequiredFieldValidator>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Bind("Nombre_Producto") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Descripción">
                         <EditItemTemplate>
                             <asp:TextBox ID="txtDescEdit" runat="server" Height="99px" style="resize:none" Text='<%# Bind("Descripcion_Producto") %>' TextMode="MultiLine" Width="327px"></asp:TextBox>
                             <br />
                             <asp:RequiredFieldValidator ID="rfvDescEdit" runat="server" ControlToValidate="txtDescEdit" CssClass="auto-style6" ErrorMessage="Campo descripción vacio" Font-Size="Smaller"></asp:RequiredFieldValidator>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_Descripcion" runat="server" Text='<%# Bind("Descripcion_Producto") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="unidades en stock">
                         <EditItemTemplate>
                             <asp:TextBox ID="txtStockEdit" runat="server" TextMode="Number" Width="90px" Text='<%# Eval("Stock_Producto") %>'></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvStockEdit" runat="server" ControlToValidate="txtStockEdit" CssClass="auto-style6" ErrorMessage="Campo stock vacio"></asp:RequiredFieldValidator>
                             <br />
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_Stock" runat="server" Text='<%# Bind("Stock_Producto") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Precio">
                         <EditItemTemplate>
                             <asp:TextBox ID="txtPrecioEdit" runat="server" Width="90px" Text='<%# Bind("Precio_Producto") %>'></asp:TextBox>
                             <br />
                             <asp:RequiredFieldValidator ID="rfvPrecioEdit" runat="server" ControlToValidate="txtPrecioEdit" CssClass="auto-style6" ErrorMessage="Campo precio vacio"></asp:RequiredFieldValidator>
                             <br />
                             <asp:CustomValidator ID="cvPrecioEdit" runat="server" ControlToValidate="txtPrecioEdit" CssClass="auto-style6" ErrorMessage="Precio debe ser decimal" OnServerValidate="cvPrecioEdit_ServerValidate"></asp:CustomValidator>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_precio" runat="server" Text='<%# Bind("Precio_Producto") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="url de imagen">
                         <EditItemTemplate>
                             <asp:TextBox ID="txtUrlEdit" runat="server" Width="218px" Text='<%# Eval("UrlImagen_Producto") %>'></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvUrlEdit" runat="server" ControlToValidate="txtUrlEdit" CssClass="auto-style6" ErrorMessage="Campo url vacio"></asp:RequiredFieldValidator>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_Url" runat="server" Text='<%# Bind("UrlImagen_Producto") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
                 <EditRowStyle BackColor="#7C6F57" />
                 <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                 <RowStyle BackColor="#E3EAEB" />
                 <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                 <SortedAscendingCellStyle BackColor="#F8FAFA" />
                 <SortedAscendingHeaderStyle BackColor="#246B61" />
                 <SortedDescendingCellStyle BackColor="#D4DFE1" />
                 <SortedDescendingHeaderStyle BackColor="#15524A" />
             </asp:GridView>
             <br />

             <div ID="MensajeProductosDiv" style="margin-left:600px" runat="server">
                 <br />
             </div>
             
             <br />

             <div style="margin-left:350px">
                 <table class="auto-style8">
                    <tr>
                        <td class="auto-style39">
                            <br />
             <asp:Label ID="lblErrorProductoCarga" runat="server"></asp:Label>
    
                        </td>
                        <td class="auto-style40"><strong>
                            <asp:Label class="label label-default" ID="lblProductos0" runat="server" CssClass="auto-style36" Text="Agregar Productos" style="font-size: xx-large"></asp:Label>
                            </strong></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="auto-style45">
                            <asp:Label ID="lblNombreProd" runat="server" Text="Nombre Producto:"></asp:Label>
                        </td>
                        <td class="auto-style46">
                            <asp:TextBox ID="txtNombreInsert" runat="server" Width="378px"></asp:TextBox>
                        </td>
                        <td class="auto-style47">
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombreInsert" ErrorMessage="RequiredFieldValidator" ValidationGroup="AgregarProd">Campo nombre vacio</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style39">
                            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:"></asp:Label>
                        </td>
                        <td class="auto-style44">
                            <asp:TextBox ID="txtDescripInsert" runat="server" style="resize:none" Width="379px" Height="99px" Rows="10" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvDescrip" runat="server" ControlToValidate="txtDescripInsert" ErrorMessage="RequiredFieldValidator" ValidationGroup="AgregarProd">Campo descripcion vacio</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style39">
                            <asp:Label ID="lblPrecioo" runat="server" Text="Precio:"></asp:Label>
                        </td>
                        <td class="auto-style44">
                            <asp:TextBox ID="txtPrecioInsert" runat="server" TextMode="Number" Width="263px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ControlToValidate="txtPrecioInsert" ErrorMessage="RequiredFieldValidator" ValidationGroup="AgregarProd">Campo precio vacio</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style41">
                            <asp:Label ID="lblStock" runat="server" Text="Stock:"></asp:Label>
                        </td>
                        <td class="auto-style42">
                            <asp:TextBox ID="txtStockInsert" runat="server" Width="263px" TextMode="Number"></asp:TextBox>
                        </td>
                        <td class="auto-style43">
                            <asp:RequiredFieldValidator ID="rfvStock" runat="server" ControlToValidate="txtStockInsert" ErrorMessage="RequiredFieldValidator" ValidationGroup="AgregarProd">Campo stock vacio</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style39">
                            <asp:Label ID="lblCat" runat="server" Text="Categoría:"></asp:Label>
                        </td>
                        <td class="auto-style44">
                            <asp:DropDownList ID="ddlCategoriasAgregar" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoriasAgregar_SelectedIndexChanged" >
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lbl1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style39">
                            <asp:Label ID="lblSub" runat="server" Text="SubCategoría:"></asp:Label>
                        </td>
                        <td class="auto-style44">
                            <asp:DropDownList ID="ddlSubCategoriaAgregar" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lbl2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style39">
                            <asp:Label ID="lblImagenRuta" runat="server" Text="URLimagen:"></asp:Label>
                        </td>
                        <td class="auto-style44">
                            <asp:TextBox ID="txtUrlInsert" runat="server" Width="263px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvImagen" runat="server" ControlToValidate="txtUrlInsert" ErrorMessage="Campo url vacio" ValidationGroup="AgregarProd"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style39">&nbsp;</td>
                        <td class="auto-style1">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Producto" ValidationGroup="AgregarProd" OnClick="btnAgregar_Click" OnClientClick="return ValidateInsertProd();"/>

                            

                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                 </div>
         </div>


             
         
         <div id="CategoriasDiv" runat ="server" style="margin-left:450px">
             &nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="txtDescCat" runat="server" placeholder="Descripción categoría"></asp:TextBox>
             <asp:Button ID="btnFiltrarCat" runat="server" OnClick="btnFiltrarCat_Click" Text="Filtrar" />
             <asp:Button ID="btn_SacarFiltrosCat" runat="server" OnClick="btn_SacarFiltrosCat_Click" Text=" Quitar filtros" Width="78px" />
                 <br />
             <br />
             <asp:GridView ID="grdCategorias" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnRowCancelingEdit="grdCategorias_RowCancelingEdit" OnRowEditing="grdCategorias_RowEditing"  OnRowUpdating="grdCategorias_RowUpdating"  OnPageIndexChanging="grdCategorias_PageIndexChanging" OnRowDeleting="grdCategorias_RowDeleting" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="grdCategorias_RowDataBound" >

                 <AlternatingRowStyle BackColor="White" />
                 <Columns>
                      <asp:CommandField ShowDeleteButton="True" ButtonType="Button" runat="server"/>
                     <asp:CommandField ShowEditButton="true" ButtonType="Button" runat="server" />
                     <asp:TemplateField HeaderText="Id Categoría">
                         <EditItemTemplate>
                             <asp:Label ID="lbl_eit_Id" runat="server" Text='<%# Eval("Id_Categoria") %>'></asp:Label>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_Id" runat="server" Text='<%# Eval("Id_Categoria") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Descripción">
                         <EditItemTemplate>
                             <asp:TextBox ID="txt_eit_descripcion" runat="server" Text='<%# Bind("Descripcion_Categoria") %>'></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_Descripcion" runat="server" Text='<%# Eval("Descripcion_Categoria") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
                 <EditRowStyle BackColor="#7C6F57" />
                 <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                 <RowStyle BackColor="#E3EAEB" />
                 <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                 <SortedAscendingCellStyle BackColor="#F8FAFA" />
                 <SortedAscendingHeaderStyle BackColor="#246B61" />
                 <SortedDescendingCellStyle BackColor="#D4DFE1" />
                 <SortedDescendingHeaderStyle BackColor="#15524A" />
             </asp:GridView>
             <strong>
                            <asp:Label class="label label-default" ID="lblProductos1" runat="server" CssClass="auto-style36" Text="Agregar Categoría" style="font-size: xx-large"></asp:Label>
                            </strong>
             <br />
             <asp:Label ID="lblDescripcionCat" runat="server" Text="Descripción:"></asp:Label>
             <asp:TextBox ID="txt_AgregarDescCat" runat="server" ValidationGroup="AgregarCat"></asp:TextBox>
             <br />
             <asp:RequiredFieldValidator ID="rfvCatInsert" runat="server" ControlToValidate="txt_AgregarDescCat" CssClass="auto-style2" ErrorMessage="Para ingresar una categoría no puede dejar la descripción vacia" ValidationGroup="AgregarCat"></asp:RequiredFieldValidator>
             <br />
             <asp:Button ID="btnAgregarCat" runat="server" OnClick="btnAgregarCat_Click" Text="Agregar" ValidationGroup="AgregarCat"  OnClientClick="return ValidateInsertCategoria();"/>
                 <br />
                 <asp:Label ID="lblAgregadoCatInsert" runat="server"></asp:Label>
         </div>

        <div id="SubCategoriasDiv" runat="server" style="margin-left:450px"> 
                        <asp:Label ID="lblCatSub" runat="server" Text="Categoría:"></asp:Label>
                    <asp:DropDownList ID="ddlCategoriasGrdSub" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoriasGrdSub_SelectedIndexChanged">
                        </asp:DropDownList>
             <asp:TextBox ID="txtDescSubCat" runat="server" placeholder="SubCategoría"></asp:TextBox>
             <asp:Button ID="btnFiltrarSub" runat="server" OnClick="btnFiltrarSub_Click" Text="Filtrar" />
             <asp:Button ID="btn_SacarFiltrosSub" runat="server" OnClick="btn_SacarFiltrosSub_Click" Text=" Quitar filtros" Width="78px" />
                        <br />
             <asp:Label ID="lblErrorSubCategoria" runat="server"></asp:Label>
             <br />
             <asp:GridView ID="grdSubCategorias" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grdSubCategorias_PageIndexChanging" OnRowCancelingEdit="grdSubCategorias_RowCancelingEdit" OnRowDeleting="grdSubCategorias_RowDeleting" OnRowEditing="grdSubCategorias_RowEditing" OnRowUpdating="grdSubCategorias_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="grdSubCategorias_RowDataBound" >
                 <AlternatingRowStyle BackColor="White" />
                 <Columns>
                      <asp:CommandField ShowDeleteButton="True" ButtonType="Button" runat="server"/>
                     <asp:CommandField ShowEditButton="true" ButtonType="Button" runat="server" />
                     <asp:TemplateField HeaderText="ID categoría">
                         <EditItemTemplate>
                             <asp:Label ID="lbl_eit_IdCat_Sub" runat="server" Text='<%# Eval("Id_Categoria_Subcategoria") %>'></asp:Label>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_IdCat_Sub" runat="server" Text='<%# Eval("Id_Categoria_Subcategoria") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="ID SubCategoría">
                         <EditItemTemplate>
                             <asp:Label ID="lbl_eit_SubCat" runat="server" Text='<%# Eval("Id_Subcategoria") %>'></asp:Label>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_SubCat" runat="server" Text='<%# Eval("Id_Subcategoria") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Descripción">
                         <EditItemTemplate>
                             <asp:TextBox ID="txt_eit_DescSub" runat="server" Text='<%# Eval("Descripcion_Subcategoria") %>'></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_DescSub" runat="server" Text='<%# Bind("Descripcion_Subcategoria") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
                 <EditRowStyle BackColor="#7C6F57" />
                 <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                 <RowStyle BackColor="#E3EAEB" />
                 <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                 <SortedAscendingCellStyle BackColor="#F8FAFA" />
                 <SortedAscendingHeaderStyle BackColor="#246B61" />
                 <SortedDescendingCellStyle BackColor="#D4DFE1" />
                 <SortedDescendingHeaderStyle BackColor="#15524A" />
             </asp:GridView>
                        <strong>
                            <asp:Label class="label label-default" ID="lblProductos2" runat="server" CssClass="auto-style36" Text="Agregar SubCategoría" style="font-size: xx-large"></asp:Label>
                            </strong>
             <br />
             <asp:Label ID="lblAgregarCat" runat="server" Text="Categoría:"></asp:Label>
             <asp:DropDownList ID="ddlAgregarCatSub" runat="server" AutoPostBack="True">
             </asp:DropDownList>
             <br />
             <asp:Label ID="lblDescripcionSubCat" runat="server" Text="Descripción:"></asp:Label>
             <asp:TextBox ID="txtDescAgregarSubCat" runat="server" ValidationGroup="AgregarSubCat"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="rfvSubCategoria" runat="server" ControlToValidate="txtDescAgregarSubCat" CssClass="auto-style2" ErrorMessage="Para ingresar una categoría no puede dejar la descripción vacia" ValidationGroup="AgregarSubCat"></asp:RequiredFieldValidator>
             <br />
             <asp:Button ID="btnAgregarSubCat" runat="server" OnClick="btnAgregarSubCat_Click" Text="Agregar" ValidationGroup="AgregarSubCat" OnClientClick="return ValidateInsertSubCategoria();"/>
         </div>

         <div id="UsuariosDiv" runat="server" style="margin-left:400px">
             &nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="txtNombreUsr" runat="server" placeholder="Nombre"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             
             <asp:TextBox ID="txtApellidoUsr" runat="server" placeholder="Apellido"></asp:TextBox>
             <asp:Button ID="btnFiltrarUsr" runat="server" OnClick="btnFiltrarUsr_Click" Text="Filtrar" />
             <asp:Button ID="btnQuitarFiltrosUsr" runat="server" OnClick="btnQuitarFiltrosUsr_Click" Text="Quitar Filtros" />
    &nbsp;<asp:GridView ID="grdUsuarios" runat="server" AllowPaging="True" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnPageIndexChanging="grdUsuarios_PageIndexChanging" OnRowCancelingEdit="grdUsuarios_RowCancelingEdit" OnRowDeleting="grdUsuarios_RowDeleting" OnRowEditing="grdUsuarios_RowEditing" OnRowUpdating="grdUsuarios_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None">
                 <AlternatingRowStyle BackColor="White" />
                 <Columns>
                     <asp:TemplateField HeaderText="DNI">
                         <EditItemTemplate>
                             <asp:Label ID="lbl_eit_dni" runat="server" Text='<%# Bind("DNI_Usuario") %>'></asp:Label>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_dni" runat="server" Text='<%# Bind("DNI_Usuario") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Nombre">
                         <EditItemTemplate>
                             <asp:Label ID="lbl_eit_Nombre" runat="server" Text='<%# Bind("Nombre_Usuario") %>'></asp:Label>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Bind("Nombre_Usuario") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Apellido">
                         <EditItemTemplate>
                             <asp:Label ID="lbl_eit_Apellido" runat="server" Text='<%# Bind("Apellido_Usuario") %>'></asp:Label>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_Apellido" runat="server" Text='<%# Bind("Apellido_Usuario") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Email">
                         <EditItemTemplate>
                             <asp:Label ID="lbl_eit_email" runat="server" Text='<%# Bind("Email_Usuario") %>'></asp:Label>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_email" runat="server" Text='<%# Bind("Email_Usuario") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Contraseña">
                         <EditItemTemplate>
                             <asp:Label ID="lbl_eit_Contra" runat="server" Text='<%# Bind("Contraseña_Usuario") %>'></asp:Label>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_Contra" runat="server" Text='<%# Bind("Contraseña_Usuario") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Admin">
                         <EditItemTemplate>
                             <asp:CheckBox ID="cb_Admin" runat="server" Checked='<%# Bind("EsAdmin_Usuario") %>' />
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="lbl_it_admin" runat="server" Text='<%# Bind("EsAdmin_Usuario") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
                 <EditRowStyle BackColor="#7C6F57" />
                 <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                 <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                 <RowStyle BackColor="#E3EAEB" />
                 <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                 <SortedAscendingCellStyle BackColor="#F8FAFA" />
                 <SortedAscendingHeaderStyle BackColor="#246B61" />
                 <SortedDescendingCellStyle BackColor="#D4DFE1" />
                 <SortedDescendingHeaderStyle BackColor="#15524A" />
             </asp:GridView>
         </div>
    </form>
</body>
</html>
