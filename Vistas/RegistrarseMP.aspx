<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistrarseMP.aspx.cs" Inherits="Vistas.RegistrarseMP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="EstilosCssVistas/Registrarse.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous">
    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="main">
        <div class="card text-center" style="width: 60%; border: #d5f1f8 solid;">
            <div class="card-header"> Registro </div>
            <div class="card-body font-monospace" style="background-color: #e3f2fd;" >
                <div class="form-floating mb-3">
                    <input id="txtNombre" runat="server" class="form-control" placeholder="name@example.com" type="text" required />
                    <label for="floatingInput" >Nombre</label>
                </div>

                <div class="form-floating mb-3">
                    <input id="txtApellido" runat="server" class="form-control" placeholder="name@example.com"  type="text" required/>
                    <label for="floatingInput" >Apellido</label>
                </div>

                <div class="form-floating mb-3">
                    <input id="txtDni" runat="server" class="form-control" placeholder="name@example.com" type="number" required />
                    <label for="floatingInput" >DNI</label>
                </div>

                <div class="form-floating mb-3">
                    <input id="txtEmail" runat="server" class="form-control" placeholder="name@example.com" type="email" required />
                    <label for="floatingInput" >Email</label>
                </div>

                <div class="form-floating mb-3">
                    <input id="txtContra" runat="server" class="form-control" placeholder="name@example.com" type="password" required/>
                    <label for="floatingInput">Contraseña</label>
                </div>

                <div class="form-floating mb-3">
                    <input id="txtConfirmarContra" runat="server" class="form-control" placeholder="name@example.com" type="password" required />
                    <label for="floatingInput" >Confirmar Contraseña</label>
                </div>

                <div ID="AlertaCorrecto" runat="server" visible="false" class="alert alert-success alert-dismissible fade show">
                    Registrado correctamente
                    <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                </div>

                <div ID="AlertaIncorrecto" runat="server" visible="false" class="alert alert-danger alert-dismissible fade show">
                     No se pudo registrar correctamente.
                    <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                </div>

                <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" OnClick="btnRegistrarse_Click" CssClass="btn btn-primary" />
            </div>

            
        </div>
    </div>
            

</asp:Content>
