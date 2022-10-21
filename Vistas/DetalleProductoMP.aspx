<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleProductoMP.aspx.cs" Inherits="Vistas.DetalleProductoMP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>
    <script src="https://kit.fontawesome.com/3c33daaf69.js" crossorigin="anonymous"></script> 
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous">
    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>
    <link href="EstilosCssVistas/DetalleProductosss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main">
        <div class="presentacion">
            <div class="Producto">
                <asp:Image ID="imgProducto" runat="server" CssClass="img"/> <%--display block--%>
            </div> 
            <div class="Descripcion">
                <ul>
                    <li><asp:Label ID="lblNombreProducto" runat="server" CssClass="NombreProd"></asp:Label></li>
                    <li>
                        <asp:Label ID="lblCategoria" runat="server" CssClass="Cat"></asp:Label>
                        >
                        <asp:Label ID="lblSubCategoria" runat="server" CssClass="Cat"></asp:Label>
                    </li>
                    <li><asp:Label ID="lblPrecio" runat="server" CssClass="Precio"></asp:Label></li>
                    <li>
                        <ul class="Promocion">
                            <li>
                            <i class="fa-solid fa-shield-halved"></i> 
                            <span>12 Meses de garantia</span> 
                            </li>
                            <li>
                                <i class="fa-solid fa-check"></i>
                                <span>Stock disponible</span>
                            </li>
                            <li>
                                <i class="fa-solid fa-truck"></i>
                                <span>Envio a domicilio</span>
                            </li>
                        </ul>
                   </li>
                    <li><asp:Button ID="btnAgregar" runat="server" Text="Agregar al carrito" Width="201px" OnClick="btnAgregar_Click" cssclass="btn btn-primary"/></li>
                </ul>
            </div>
        </div>

        <div class="especificacionesContenedor">
            <div class="especificacion">
                <h4>Especificaciones</h4>
                <asp:Label ID="lblDescripcion" runat="server" CssClass="Detalle"></asp:Label>
            </div>
            
        </div>
    </div>

    
    
    <div class="MainResenias">
        <div class="ListadoResenias" >
            <h4>Reseñas</h4>
            <asp:Label ID="lblVacio" runat="server" Text="Este producto no cuenta con reseñas" Visible ="false"></asp:Label>
            <div ID="MsgCorrectoDiv" runat="server" visible="false" class="alert alert-success alert-dismissible fade show">
                <strong style="font-size:13px;">Correcto</strong> 
                <asp:Label ID="lblCorrecto" runat="server" Text="" Font-Size="13px"></asp:Label>
                <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
            </div>
            <asp:DataList ID="dlResenias" runat="server"  OnItemDataBound="dlResenias_ItemDataBound" OnDeleteCommand="dlResenias_DeleteCommand">
                <ItemTemplate>
                    <div class="Item">
                        <asp:Label ID="lblDni" runat="server" Text='<%# Eval("DNI_Usuario_Reseña") %>' Visible="false" ></asp:Label>
                        <asp:Label ID="lblResenia" runat="server" Text='<%# Eval("Contenido_Reseña") %>'></asp:Label>
                        <br />
                        <asp:LinkButton ID="lb1" runat="server" Visible="false"><i class="fa-solid fa-star"></i></asp:LinkButton>
                        <asp:LinkButton ID="lb2" runat="server" Visible="false"><i class="fa-solid fa-star"></i></asp:LinkButton>
                        <asp:LinkButton ID="lb3" runat="server" Visible="false"><i class="fa-solid fa-star"></i></asp:LinkButton>
                        <asp:LinkButton ID="lb4" runat="server" Visible="false"><i class="fa-solid fa-star"></i></asp:LinkButton>
                        <asp:LinkButton ID="lb5" runat="server" Visible="false"><i class="fa-solid fa-star"></i></asp:LinkButton>    
                        <asp:Label ID="lblCalificacion" runat="server" Text='<%# Eval("Calificacion_Reseña") %>' Visible="false" ></asp:Label>
                        <asp:LinkButton ID="lnkDelete" runat="server" text="<i class='fa-solid fa-trash'></i>" CommandName="Delete" OnClientClick="return confirm('¿Esta seguro que quiere eliminar esta reseña?')" Visible="false"></asp:LinkButton>
                        <hr />
                        
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div> 

        <div id="AgregarReseñaDiv" runat="server" visible="false" >
            <div class="AgregarReseniaContenedor">
                <ul class="AgregarReseniaUl">
                    <li>
                        <div ID="MsgErrorRsniaDiv" class="alert alert-danger" runat="server" visible="false">
                            <strong style="font-size:13px;">Error</strong> 
                            <asp:Label ID="lblError" runat="server" Font-Size="13px"></asp:Label>
                            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                        </div>
                    </li>
                    <li><h4>Deja tu reseña del producto</h4></li>
                    <li><asp:TextBox ID="txtReseña" textmode="MultiLine" runat="server" style="resize:none;" Height="93px" Width="384px" MaxLength="100" Rows="3"></asp:TextBox></li>
                    <li>
                        <asp:LinkButton ID="str1" runat="server" cssclass="starIngreso" OnClick="str1_Click"><i class="fa-solid fa-star" ></i></asp:LinkButton>
                        <asp:LinkButton ID="str2" runat="server" cssclass="starIngreso" OnClick="str2_Click"><i class="fa-solid fa-star" ></i></asp:LinkButton>
                        <asp:LinkButton ID="str3" runat="server" cssclass="starIngreso" OnClick="str3_Click"><i class="fa-solid fa-star" ></i></asp:LinkButton>
                        <asp:LinkButton ID="str4" runat="server" cssclass="starIngreso" OnClick="str4_Click"><i class="fa-solid fa-star" ></i></asp:LinkButton>
                        <asp:LinkButton ID="str5" runat="server" cssclass="starIngreso" OnClick="str5_Click"><i class="fa-solid fa-star" ></i></asp:LinkButton>
                    </li>
                    <li><asp:Button ID="btnEnviarReseña" runat="server" Text="Enviar Reseña" OnClick="btnEnviarReseña_Click" cssclass="btn btn-primary" OnClientClick="return ValidateInsertReseña();"/></li>
                </ul>
            </div>
        </div>   
    </div>
</asp:Content>
