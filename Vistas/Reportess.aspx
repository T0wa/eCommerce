<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportess.aspx.cs" Inherits="Vistas.Reportess" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <title></title>    
    <!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous">
<!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>
    <style type="text/css">
        .auto-style3 {
            width: 100%;
        }
        .auto-style4 {
            font-size: large;
        }
        .auto-style5 {
            width: 142px;
        }
        .auto-style7 {
            width: 154px;
            text-align: center;
        }
        .auto-style8 {
            width: 154px;
            text-align: left;
        }
        .auto-style11 {
            height: 59px;
        }
        .auto-style13 {
            width: 142px;
            text-align: left;
            height: 59px;
        }
        .auto-style14 {
            height: 59px;
            width: 154px;
        }
        .auto-style15 {
            font-size: small;
        }
        .auto-style17 {
            height: 59px;
            width: 92px;
        }
        .auto-style19 {
            height: 59px;
            width: 138px;
            text-align: center;
        }
        .auto-style20 {
            margin-left: 6px;
        }
        .auto-style28 {
            width: 276px;
        }
        .auto-style29 {
            width: 256px;
        }
        .auto-style30 {
            width: 138px;
            text-align: center;
        }
        .auto-style32 {
            height: 59px;
            width: 136px;
        }
        .auto-style34 {
            height: 59px;
            width: 109px;
        }
        .auto-style35 {
            width: 109px;
        }
        .auto-style36 {
            width: 136px;
        }
        .auto-style37 {
            width: 138px;
        }
        .auto-style51 {
            text-align: center;
            width: 283px;
            height: 46px;
        }
        .auto-style52 {
            text-align: center;
            width: 6px;
            height: 46px;
        }
        .auto-style53 {
            text-align: center;
            width: 120px;
            height: 46px;
        }
        .auto-style55 {
            font-size: medium;
            height: 46px;
        }
        .auto-style1 {
            width: 1266px;
        }
        .auto-style56 {
            text-align: center;
            width: 157px;
            height: 46px;
        }
        .auto-style57 {
            width: 178px;
        }
        .auto-style58 {
            height: 59px;
            width: 178px;
        }
        .auto-style59 {
            text-align: center;
            width: 104px;
            height: 46px;
        }
    </style>
</head>
<body style="overflow-y:visible; background-image:url(https://cdn.wallpapersafari.com/16/54/cVR2Dv.jpg);background-size:cover;">
    <form id="form1" runat="server">   
        <div style="background-color: #e3f2fd; margin-right:30px;margin-left:30px; border-radius:20px;margin-top:10px;">
            <table class="auto-style1">
            <tr>
                <td class="auto-style59">
                    <asp:ImageButton ID="imgBtn_Logo" runat="server" Width="67px" Height="60px" ImageUrl="~/ImagenesHeader/Logo.png" OnClick="imgBtn_Logo_Click" />
                </td>
                <td class="auto-style51">
                    <asp:Label ID="lblNombreUsuario" runat="server"></asp:Label>
                </td>
                <td class="auto-style52">
                    <strong>&nbsp;&nbsp;
                    </strong>
                </td>
                <td class="auto-style53">&nbsp;</td>
                <td class="auto-style56"><strong>
                    <asp:HyperLink ID="hlUsuario" runat="server">[hlUsuario]</asp:HyperLink>
                    </strong></td>
                <td class="auto-style55">
                    <asp:ImageButton ID="imgBtn_Carrito" runat="server" CssClass="auto-style17" Height="33px" Width="33px" ImageUrl="~/ImagenesHeader/changuito.png" OnClick="imgBtn_Carrito_Click" />
                </td>
            </tr>
        </table>
        </div>
        
       
        <br />
        <table class="auto-style3">
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style37">&nbsp;</td>
                <td class="auto-style36">&nbsp;</td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style57">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style13"><strong>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblFiltrarFecha" runat="server" CssClass="auto-style4" Text="Fechas"></asp:Label>
                    </strong>
                    <br />
                    <asp:Button ID="btnDesde" runat="server" OnClick="btnDesde_Click" Text="Desde" />
&nbsp;<asp:TextBox ID="txtDesde" runat="server" TextMode="DateTime" Width="69px" Enabled="False"></asp:TextBox>
                    <asp:Button ID="btnHasta" runat="server" OnClick="btnHasta_Click" Text="Hasta" Width="53px" />
                    &nbsp;<asp:TextBox ID="txtHasta" runat="server" CssClass="auto-style20" TextMode="DateTime" Width="69px" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style14"><strong>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblFiltrarPrecio" runat="server" CssClass="auto-style4" Text="Precio"></asp:Label>
                    <br />
                    </strong>
                    <asp:Label ID="lblMinimo" runat="server" CssClass="auto-style15" Text="Mínimo"></asp:Label>
                    <strong>
                    <asp:TextBox ID="txtPreMin" runat="server" TextMode="Number" Width="69px"></asp:TextBox>
                    </strong>
                    <asp:Label ID="lblHasta0" runat="server" CssClass="auto-style15" Text="Máximo"></asp:Label>
                    <strong>
                    <asp:TextBox ID="txtPreMax" runat="server" TextMode="Number" Width="69px"></asp:TextBox>
                    </strong></td>
                <td class="auto-style19"><strong>
                    <asp:Label ID="lblFiltrarCant" runat="server" CssClass="auto-style4" Text="Cantidad"></asp:Label>
                    <br />
                    </strong>
                    <asp:Label ID="lblMinimo0" runat="server" CssClass="auto-style15" Text="Mínimo"></asp:Label>
                    <strong>
                    <asp:TextBox ID="txtCantMin" runat="server" TextMode="Number" Width="69px"></asp:TextBox>
                    </strong>
                    <asp:Label ID="lblHasta1" runat="server" CssClass="auto-style15" Text="Máximo"></asp:Label>
                    <strong>
                    <asp:TextBox ID="txtCantMax" runat="server" TextMode="Number" Width="69px"></asp:TextBox>
                    </strong></td>
                <td class="auto-style32"><strong>
                    <asp:Label ID="lblFiltrarSubCat" runat="server" CssClass="auto-style4" Text="Sub categoria"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlSubCategoria" runat="server" Height="16px">
                    </asp:DropDownList>
                    <br />
                    <br />
                    </strong></td>
                <td class="auto-style34"><strong>
                    <asp:Label ID="lblFiltrarCat" runat="server" CssClass="auto-style4" Text="Categoria"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlCategoria" runat="server">
                    </asp:DropDownList>
                    <br />
                    <br />
                    </strong></td>
                <td class="auto-style58"><strong>
                    <asp:Label ID="lblEnvio" runat="server" CssClass="auto-style4" Text="Enviado a domicilio"></asp:Label>
                    <br />
                    <asp:RadioButtonList ID="rblEnvio" runat="server" Font-Size="Small" Height="43px" Width="89px">
                        <asp:ListItem Value="1">SI</asp:ListItem>
                        <asp:ListItem Value="0">NO</asp:ListItem>
                    </asp:RadioButtonList>
                    </strong></td>
                <td class="auto-style11">
                    <strong>
                    <asp:Label ID="lblFiltrarCat0" runat="server" CssClass="auto-style4" Text="Factura"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlFactura" runat="server">
                    </asp:DropDownList>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td class="auto-style30">
                    &nbsp;</td>
                <td class="auto-style36">
                    <asp:Button ID="btnFiltrar" runat="server" Text="Aplicar Filtros" OnClick="btnFiltrar_Click" />
                </td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style57">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Calendar ID="calDesde" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="123px" OnSelectionChanged="calDesde_SelectionChanged" Visible="False" Width="54px">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td class="auto-style30">
                    <br />
                    <br />
                </td>
                <td class="auto-style36">
                    &nbsp;</td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style57">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Calendar ID="calHasta" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="91px" OnSelectionChanged="calHasta_SelectionChanged" Visible="False" Width="90px">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td class="auto-style30">
                    &nbsp;</td>
                <td class="auto-style36">
                    &nbsp;</td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style57">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            </table>
        <table class="auto-style3">
            <tr>
                <td class="auto-style28">
                    <br />
                </td>
                <td class="auto-style29">
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMensaje" runat="server" Font-Bold="True"></asp:Label>
                    <asp:GridView ID="grdFacturas" runat="server" Width="627px" AutoGenerateDeleteButton="True" OnRowDeleting="grdFacturas_RowDeleting" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" BorderWidth="2px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </form>
</body>
</html>
