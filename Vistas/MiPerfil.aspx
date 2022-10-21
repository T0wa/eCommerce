<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Vistas.MiPerfil" %>

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

        .auto-style2 {
            width: 435px;
            height: 62px;
        }
        .auto-style4 {
            text-align: center;
            width: 407px;
            height: 62px;
        }
        .auto-style16 {
            text-align: center;
            width: 360px;
            height: 62px;
        }
        .auto-style18 {
            width: 100%;
            height: 64px;
        }
        .auto-style19 {
            width: 100%;
            margin-bottom: 0px;
        }
        .auto-style20 {
            height: 23px;
        }
        .auto-style21 {
            height: 23px;
            width: 198px;
        }
        .auto-style22 {
            width: 198px;
        }
        .auto-style23 {
            font-size: x-large;
        }
        .auto-style29 {
            width: 528px;
        }
        .auto-style30 {
            height: 23px;
            width: 528px;
        }
        .auto-style32 {
            width: 198px;
            height: 26px;
        }
        .auto-style34 {
            width: 528px;
            height: 26px;
        }
        .auto-style35 {
            height: 26px;
        }
        .auto-style36 {
            width: 198px;
            height: 137px;
        }
        .auto-style38 {
            width: 528px;
            height: 137px;
        }
        .auto-style39 {
            height: 137px;
            text-align: center;
        }
        .auto-style40 {
            height: 23px;
            width: 335px;
        }
        .auto-style41 {
            width: 335px;
            height: 137px;
        }
        .auto-style42 {
            width: 335px;
            height: 26px;
        }
        .auto-style43 {
            width: 335px;
        }
        .auto-style44 {
            font-size: small;
        }
        .auto-style45 {
            height: 22px;
            width: 198px;
        }
        .auto-style46 {
            height: 22px;
            width: 335px;
        }
        .auto-style47 {
            height: 22px;
            width: 528px;
            font-size: x-large;
        }
        .auto-style48 {
            height: 22px;
            font-size: x-large;
        }
        .auto-style51 {
            width: 528px;
            font-size: x-large;
            height: 42px;
        }
        .auto-style52 {
            text-align: center;
            height: 62px;
        }
        .auto-style53 {
            text-align: center;
            width: 72px;
            height: 62px;
        }
        .auto-style54 {
            width: 198px;
            height: 42px;
        }
        .auto-style55 {
            width: 335px;
            height: 42px;
        }
        .auto-style56 {
            font-size: x-large;
            height: 42px;
        }
    </style>
</head>
    
<body style="background-image: url(https://static.vecteezy.com/system/resources/previews/007/113/054/non_2x/cream-color-brick-wall-texture-background-grunge-brickwork-for-your-design-backdrop-free-photo.jpg);background-size:cover;">
    <form id="form1" runat="server">
        <div class="navbar" style="background-color: #e3f2fd; margin-right:30px;margin-left:30px; border-radius:20px;margin-top:10px;">
        <table class="auto-style18">
            <tr>
                <td class="auto-style2">
                    <asp:ImageButton ID="imgBtn_Logo" runat="server" Width="85px" ImageUrl="~/ImagenesHeader/Logo.png" Height="55px" OnClick="imgBtn_Logo_Click" />
                </td>
                <td class="auto-style4">
                    <asp:Label ID="lblNombreUsuario" runat="server"></asp:Label>
                </td>
                <td class="auto-style53">&nbsp;</td>
                <td class="auto-style52"></td>
                <td class="auto-style16"><strong>
                    <asp:HyperLink ID="hlUsuario" runat="server" NavigateUrl="~/MiPerfil.aspx">Mi Perfil</asp:HyperLink>
                    </strong></td>
            </tr>
        </table>
        </div>
        <p>
            <br />
            <span class="auto-style23">Mi Perfil</span></p>
        <table class="auto-style19">
            <tr>
                <td class="auto-style45">
                    <asp:Label ID="lblNombreCompleto" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblEsAdmin" runat="server"></asp:Label>
                    <br />
                </td>
                <td class="auto-style46">
                    </td>
                <td class="auto-style47">
                    <asp:LinkButton ID="lbCerrarSesion" runat="server" OnClick="lbCerrarSesion_Click" OnClientClick="return confirm('¿Esta seguro que quiere cerrar sesión?')">Cerrar sesión</asp:LinkButton>
                </td>
                <td class="auto-style48"></td>
            </tr>
            <tr>
                <td class="auto-style54">Cambiar nombre:</td>
                <td class="auto-style55">
                    <asp:TextBox ID="txtCambiarNombre" runat="server" MaxLength="20"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtCambiarNombre" CssClass="auto-style44" ErrorMessage="No puede dejar nombre vacio" ValidationGroup="Perfil"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style51">Mis Compras:</td>
                <td class="auto-style56"></td>
            </tr>
            <tr>
                <td class="auto-style36">Cambiar apellido:</td>
                <td class="auto-style41">
                    <asp:TextBox ID="txtCambiarApellido" runat="server" MaxLength="20"></asp:TextBox>
                    <br />
                </td>
                <td class="auto-style38">
                    <asp:GridView ID="grdFacturas" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanging="grdFacturas_SelectedIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_IdFactura" runat="server" Text='<%# Bind("Id_Factura") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valor Total">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Total" runat="server" Text='<%# Bind("ValorTotal_Factura") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Fecha" runat="server" Text='<%# Bind("FechaEmision_Factura") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                    <br />
                </td>
                <td class="auto-style39">
                    <asp:GridView ID="grdDetalles" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Bind("Nombre_Producto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Precio">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Precio" runat="server" Text='<%# Bind("Precio_Producto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cantidad">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Cantidad" runat="server" Text='<%# Bind("Cantidad_Detalle") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_it_Total0" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style21">Cambiar contraseña:</td>
                <td class="auto-style40">
                    <asp:TextBox ID="txtCambiarContraseña" runat="server" MaxLength="20"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="rfvContra1" runat="server" ControlToValidate="txtCambiarContraseña" CssClass="auto-style44" ErrorMessage="No puede dejar campo contraseña vacio" ValidationGroup="Perfil"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style30">
                    <asp:Label ID="lblNoCompro" runat="server"></asp:Label>
                </td>
                <td class="auto-style20">
                    </td>
            </tr>
            <tr>
                <td class="auto-style32">Confirmar contraseña:</td>
                <td class="auto-style42">
                    <asp:TextBox ID="txtConfirmarCambio" runat="server" MaxLength="20"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="rfvContra2" runat="server" ControlToValidate="txtConfirmarCambio" CssClass="auto-style44" ErrorMessage="No puede dejar campo contraseña vacio" ValidationGroup="Perfil"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style34">
                    <asp:CompareValidator ID="cvContraseña" runat="server" ControlToCompare="txtCambiarContraseña" ControlToValidate="txtConfirmarCambio" ErrorMessage="Las contraseñas no coinciden, verifique" ValidationGroup="Perfil"></asp:CompareValidator>
                </td>
                <td class="auto-style35"></td>
            </tr>
            <tr>
                <td class="auto-style22">Cambiar correo:</td>
                <td class="auto-style43">
                    <asp:TextBox ID="txtCambiarCorreo" runat="server" MaxLength="50"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCambiarCorreo" CssClass="auto-style44" ErrorMessage="No puede dejar campo correo vacio" ValidationGroup="Perfil"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style29">
                    <asp:Button ID="btnModificarPerfil" runat="server" Text="Modificar perfil" OnClick="btnModificarPerfil_Click" OnClientClick="return confirm('¿Esta seguro que quiere modificar su perfil?')" ValidationGroup="Perfil" />
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style22">&nbsp;</td>
                <td class="auto-style43">
                    &nbsp;</td>
                <td class="auto-style29">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:Label ID="lblExitoEnElCambio" runat="server"></asp:Label>
    </form>
</body>
</html>
