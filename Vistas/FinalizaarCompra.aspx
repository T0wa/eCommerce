<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinalizaarCompra.aspx.cs" Inherits="Vistas.FinalizaarCompra" %>

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
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            width: 36px;
        }
        .auto-style5 {
            height: 23px;
        }
        .auto-style7 {
            width: 272px;
        }
        .auto-style8 {
            height: 26px;
            width: 272px;
        }
        .auto-style9 {
            height: 23px;
            width: 272px;
        }
        .auto-style10 {
            width: 787px;
        }
        .auto-style11 {
            text-align: center;
        }
        .auto-style13 {
            width: 133px;
        }
        .auto-style14 {
            height: 26px;
            width: 133px;
        }
        .auto-style15 {
            height: 23px;
            width: 133px;
        }
        .auto-style16 {
            text-align: center;
            width: 149px;
        }
        .auto-style17 {
            text-align: center;
            width: 245px;
        }
        .auto-style18 {
            text-align: center;
            width: 217px;
        }
        .auto-style19 {
            height: 38px;
        }
        .auto-style20 {
            width: 272px;
            height: 38px;
        }
        .auto-style21 {
            width: 133px;
            height: 38px;
        }
        .auto-style22 {
            font-size: xx-large;
        }
        .auto-style23 {
            height: 25px;
        }
        .auto-style24 {
            width: 272px;
            height: 25px;
        }
        .auto-style25 {
            width: 133px;
            height: 25px;
        }
        .auto-style26 {
            width: 244px;
        }
        .auto-style27 {
            height: 26px;
            width: 244px;
        }
        .auto-style28 {
            width: 244px;
            height: 38px;
        }
        .auto-style29 {
            width: 244px;
            height: 25px;
        }
        .auto-style30 {
            height: 23px;
            width: 244px;
        }
        .auto-style31 {
            text-align: center;
            width: 174px;
        }
        .auto-style32 {
            height: 26px;
            width: 249px;
        }
    </style>
</head>
<body style="background-image: url(https://t3.ftcdn.net/jpg/04/71/00/20/360_F_471002062_tCBbTqeeMhHgMfCW86mQhdgpETooy3ID.jpg);background-size:cover;">
    <form id="form1" runat="server">   
        <div class="navbar" style="background-color: #e3f2fd; margin-right:30px;margin-left:30px; border-radius:20px;margin-top:10px;">
         <table class="auto-style10">
            <tr>
                <td class="auto-style32">
                    <asp:ImageButton ID="imgBtn_Logo" runat="server" Width="87px" Height="66px" ImageUrl="~/ImagenesHeader/Logo.png" OnClick="imgBtn_Logo_Click" />
                </td>
                <td class="auto-style31">
                    <asp:Label ID="lblNombre" runat="server"></asp:Label>
                </td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style18"><strong>
                    <asp:HyperLink ID="hlUsuario" runat="server" NavigateUrl="~/MiPerfil.aspx">Mi Perfil</asp:HyperLink>
                    </strong></td>
                <td class="auto-style3">
                    <asp:ImageButton ID="imgBtn_Carrito" runat="server" CssClass="auto-style17" Height="50px" Width="43px" style="margin-left: 0px" OnClick="imgBtn_Carrito_Click" ImageUrl="~/ImagenesHeader/changuito.png" />
                </td>
            </tr>
        </table>
       </div>
         <table class="auto-style1">
             <tr>
                 <td class="auto-style26">
                     <strong>
                     <asp:Label ID="lblFinalizar" runat="server" CssClass="auto-style22" Text="Finalizar compra" ForeColor="White"></asp:Label>
                     </strong>
                 </td>
                 <td class="auto-style7">
                     &nbsp;</td>
                 <td class="auto-style13">&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
             <tr>
                 <td class="auto-style26">&nbsp;</td>
                 <td class="auto-style7">
                     <asp:DropDownList ID="ddlTarjetas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTarjetas_SelectedIndexChanged">
                         <asp:ListItem Value="-1">Seleccione una tarjeta</asp:ListItem>
                     </asp:DropDownList>
                 </td>
                 <td class="auto-style13">
                     <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar tarjeta" />
                 </td>
                 <td>&nbsp;</td>
             </tr>
             <tr>
                 <td class="auto-style26">
                     <asp:Label ID="lblNroTarjeta" runat="server" Text="Numero tarjeta: " ForeColor="White"></asp:Label>
                 </td>
                 <td class="auto-style7">
                     <asp:TextBox ID="txtNroTarjeta" runat="server" Width="208px" MaxLength="16"></asp:TextBox>
                 </td>
                 <td class="auto-style13">
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td class="auto-style27">
                     <asp:Label ID="lblCodigoTarjeta" runat="server" Text="Codigo de seguridad:" ForeColor="White"></asp:Label>
                 </td>
                 <td class="auto-style8">
                     <asp:TextBox ID="txtCodigo" runat="server" TextMode="Number" Width="208px"></asp:TextBox>
                 </td>
                 <td class="auto-style14">
                 </td>
                 <td class="auto-style2">
                 </td>
             </tr>
             <tr>
                 <td class="auto-style27">
                     <asp:Label ID="lblFecha" runat="server" Text="Fecha de vencimiento: " ForeColor="White"></asp:Label>
                 </td>
                 <td class="auto-style8">
                     <asp:TextBox ID="txtVencimiento" runat="server" Width="208px" TextMode="Date"></asp:TextBox>
                 </td>
                 <td class="auto-style14">
                     &nbsp;</td>
                 <td class="auto-style2">
                     &nbsp;</td>
             </tr>
             <tr>
                 <td class="auto-style28">&nbsp;</td>
                 <td class="auto-style20">
                     <asp:Button ID="btnAgregarTarjeta" runat="server" Text="Guardar tarjeta" OnClick="btnAgregarTarjeta_Click" />
                 </td>
                 <td class="auto-style21">
                     <asp:Label ID="lblConfirmacionTarjetas" runat="server" ForeColor="White"></asp:Label>
                 </td>
                 <td class="auto-style19"></td>
             </tr>
             <tr>
                 <td class="auto-style26">
                     <asp:Label ID="lblTipoEnvio" runat="server" Text="Envio a domicilio" ForeColor="White"></asp:Label>
                 </td>
                 <td class="auto-style7">
                     <asp:RadioButtonList ID="rblEnvio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblEnvio_SelectedIndexChanged" ForeColor="White">
                         <asp:ListItem>SI</asp:ListItem>
                         <asp:ListItem Selected="True">NO</asp:ListItem>
                     </asp:RadioButtonList>
                 </td>
                 <td class="auto-style13">&nbsp;</td>
                 <td>&nbsp;</td>
             </tr>
             <tr>
                 <td class="auto-style29">
                     <asp:Label ID="lblDireccion" runat="server" Text="Direccion: " ForeColor="White"></asp:Label>
                 </td>
                 <td class="auto-style24">
                     <asp:TextBox ID="txtDireccion" runat="server" Width="208px"></asp:TextBox>
                 </td>
                 <td class="auto-style25"></td>
                 <td class="auto-style23">
                     </td>
             </tr>
             <tr>
                 <td class="auto-style30">
                     <asp:Label ID="lblRango" runat="server" Text="Rango horario:" ForeColor="White"></asp:Label>
                 </td>
                 <td class="auto-style9">
                     <asp:DropDownList ID="ddlRango" runat="server">
                         <asp:ListItem Value="0">De 8:00 a 13:00</asp:ListItem>
                         <asp:ListItem Value="1">de 13:00 a 18:00</asp:ListItem>
                     </asp:DropDownList>
                 </td>
                 <td class="auto-style15"></td>
                 <td class="auto-style5"></td>
             </tr>
             <tr>
                 <td class="auto-style27">
                     <asp:Label ID="lblProvincia" runat="server" Text="Provincia:" ForeColor="White"></asp:Label>
                 </td>
                 <td class="auto-style8">
                     <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                         <asp:ListItem Value="-1">Seleccione la provincia de destino</asp:ListItem>
                     </asp:DropDownList>
                 </td>
                 <td class="auto-style14"></td>
                 <td class="auto-style2"></td>
             </tr>
             <tr>
                 <td class="auto-style27">
                     <asp:Label ID="lblLocalidad" runat="server" Text="Localidad:" ForeColor="White"></asp:Label>
                 </td>
                 <td class="auto-style8">
                     <asp:DropDownList ID="ddlLocalidades" runat="server">
                         <asp:ListItem Value="-1">Seleccione la localidad de destino</asp:ListItem>
                     </asp:DropDownList>
                 </td>
                 <td class="auto-style14"></td>
                 <td class="auto-style2"></td>
             </tr>
             <tr>
                 <td class="auto-style26">&nbsp;</td>
                 <td class="auto-style7">
                     <asp:Button ID="btnConfirmarCompra" runat="server" Text="Confirmar compra" OnClick="btnConfirmarCompra_Click" />
                 </td>
                 <td class="auto-style13">
                     <asp:Label ID="lblConfirmacionCompra" runat="server" ForeColor="White"></asp:Label>
                 </td>
                 <td>&nbsp;</td>
             </tr>
         </table>
    </form>
</body>
</html>

