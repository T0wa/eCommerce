<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CarritoMP.aspx.cs" Inherits="Vistas.CarritoMP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous">
    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>
    <link href="EstilosCssVistas/Carritto.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/3c33daaf69.js" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="main">
        
        
        <div class="contenedorCarro">
            <div>
                <h3>Carrito de compra</h3> 
            </div>
            <div class="GrdCarro">
                <asp:GridView ID="grdProductosCarrito" runat="server" CssClass="ItemsCarro" AutoGenerateColumns="False" BorderStyle="None"  >
                      
                    <Columns >
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="eliminar">
                                    <asp:LinkButton id="lbEliminar" cssclass="IconosCarro" runat="server" CommandArgument='<%# Bind("IdProd") %>'  CommandName="EliminadoCarrito" OnCommand="lbEliminar_Command"><i class="fa-solid fa-circle-xmark"></i></asp:LinkButton>
                                </div>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div>
                                    <asp:ImageButton id="ProdImg" cssclass="Izquierda" runat="server" ImageUrl='<%# Bind("ImgProd") %>' width="70px" height="70px" OnClick="ProdImg_Click"></asp:ImageButton>
                                </div>
                                </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div>
                                    <asp:Label ID="lbl_grd_Nombre" cssclass="Izquierda" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="Cant">
                                    <asp:LinkButton ID="lbQuitar" cssclass="IconosCarro" runat="server" CommandArgument='<%# Bind("IdProd") %>' CommandName="Decremento" OnCommand="lbQuitar_Command"><i class="fa-solid fa-minus"></i></asp:LinkButton>
                                    <asp:Label ID="lbl_grd_Cantidad" cssclass="CantText" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                    <asp:LinkButton ID="lbAgregar" cssclass="IconosCarro" runat="server" CommandArgument='<%# Bind("IdProd") %>' CommandName="Incremento" OnCommand="lbAgregar_Command"><i class="fa-solid fa-plus"></i></asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField >
                            <ItemTemplate>
                                <div class="precio">
                                    $
                                    <asp:Label ID="lbl_grd_Total" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>     
                
                    <RowStyle cssclass="Filas"/>
                </asp:GridView>
            </div>
            </div>
                <div class="contenedorConfirmacion">
                    <asp:Label ID="lblTotal" runat="server"  Text="Total precio: "></asp:Label>
                    <asp:Button ID="btnConfirmarCompra" cssclass="Boton" runat="server" Text="Confirmar Compra" OnClick="btnConfirmarCompra_Click" />
                </div>
            </div>
    
</asp:Content>
