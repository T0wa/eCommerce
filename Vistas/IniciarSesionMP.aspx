<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IniciarSesionMP.aspx.cs" Inherits="Vistas.IniciarSesionMP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous">
    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>
    <link href="EstilosCssVistas/IniciarSesion.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <div class="card text-center" style="width: 60%; border: #d5f1f8 solid;">
            <div class="card-header">
            Loggeo
            </div>

            <div class="card-body font-monospace">
                <div>
                    <input type="email" cssclass="Items" class="form-control" ID="floatingInput" runat="server" placeholder="name@example.com" AutoComplete="off">  
                    <br />
                    <input type="password" cssclass="Items" class="form-control" id="floatingPassword" runat="server" placeholder="Password" AutoComplete="off">
                    <br />
                    <asp:Button ID="btnIngresar" runat="server" Text="Iniciar sesión" CssClass="btn btn-primary"  OnClick="btnIngresar_Click1" />
                    <br />
                </div>

                <div class="card-footer text-muted">
                    <asp:Label ID="lblRegistrarse" runat="server" Text="¿no tienes cuenta? Regístrate " CssClass="font-monospace"></asp:Label>
                    <asp:HyperLink ID="hlRedireccionRegistro" runat="server" CssClass="font-monospace" ForeColor="Black" NavigateUrl="~/RegistrarseMP.aspx">aquí</asp:HyperLink>
                </div>
            </div>

            <div ID="MsgErrorDiv" class="alert alert-danger" runat="server" visible="false">
                <strong>Error</strong> Usuario o contraseña incorrecto
                <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
            </div>
        </div>
    </div>
    
</asp:Content>