<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OlvidoContrasena.aspx.cs" Inherits="UI.OlvidoContrasena" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <!-- Bootstrap core CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link href="css/InicioSesionStyles.css" rel="stylesheet" />


    <title>NutreVida</title>
</head>
<body>

    <div class="container-fluid" style="height: 100%">

        <div class="row fila">

            <div class="col-lg-9 box">

                <asp:Image ID="ImgInicio" runat="server" ImageUrl="~/img/InicioSesion.jpg" />

            </div>

            <div class="col-lg-3 contenido">

                <div class="container">

                    <div class="row">

                        <div class="col-md-12 divlogo">

                            <asp:Image ID="Logo" runat="server" ImageUrl="~/img/nutriVital.jfif" />

                        </div>

                    </div>

                    <div class="row">

                        <div class="col-md-12">

                            <form id="OlvidoContrForm" runat="server">

                                <div class="formInicio">

                                    <h1 class="texto-titulo">Olvido 
                            <span class="textoPrimario">Contraseña</span>
                                    </h1>

                                    <div class="form-group">
                                        <asp:Label ID="lbCorreo" runat="server" Text="Correo Electrónico:" CssClass="control-label col-sm-2 texto"></asp:Label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtCorreo" runat="server" placeholder="Digite el correo" CssClass="form-control texto col-sm-10"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">                                        
                                        <div class="col-sm-10 divBoton">
                                            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass=" colorBoton btn btn-primary texto" OnClick="btnEnviar_Click" />
                                        </div>
                                    </div>

                                </div>

                            </form>

                        </div>

                    </div>

                    <div class="row">

                        <div class="col-md-11 info-olvido texto" >
                            <div class="col-md-10">
                                <asp:Label ID="lbNombre" runat="server" Text="Dra. Elky Fernández Palma" CssClass="control-label col-sm-2 texto"></asp:Label>
                            </div>
                            <div class="col-md-10">
                                <asp:Label ID="lbCod" runat="server" Text="Nutricionista Cód CNP 1187-12" CssClass="control-label col-sm-2 texto"></asp:Label>
                            </div>
                            <div class="col-md-10">
                                <asp:Label ID="lbTel" runat="server" Text="Tel:7076-1100" CssClass="control-label col-sm-2 texto"></asp:Label>
                            </div>

                        </div>

                    </div>
                </div>
            </div>

        </div>

    </div>

</body>
</html>

