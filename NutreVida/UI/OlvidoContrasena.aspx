<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OlvidoContrasena.aspx.cs" Inherits="UI.OlvidoContrasena" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet" />
    <link href="css/InicioSesionStyles.css" rel="stylesheet" />

    <link rel="shortcut icon" href="img/favicon.ico" />

    <title>NutreVida</title>
</head>
<body>

    <div class="container-fluid" style="height: 100%">

        <div class="row fila">

            <div class="col-lg-9 box">

                <asp:Image ID="ImgInicio" runat="server" ImageUrl="~/img/InicioSesion.jpg" />

            </div>

            <div class="col-lg-3 contenido">

                <div class="container" align="center">

                    <div class="row">

                        <div class="col-md-12 divlogo">
                            <asp:Image ID="Logo" runat="server" ImageUrl="~/img/orage 2.png" data-toggle="tooltip" title="Nutre Vida" />
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-12">

                            <h3 style="font-size: x-large">Olvidó su contraseña</h3>
                            <br />
                            <form id="OlvidoContrForm" runat="server" class="margen">
                                <asp:Label ID="lbCorreo" runat="server" Text="Correo electrónico:" Font-Size="Large"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtCorreo" TextMode="Email" runat="server" data-toggle="tooltip" title="Correo electrónico" Font-Size="Large"></asp:TextBox>
                                <div class="col-sm-10">
                                    <asp:Label ID="lblIncorrecto" runat="server" Text="" Style="color: red"></asp:Label>
                                </div>
                                <br />
                                <asp:Button ID="btnEnviar" CssClass=" btn btn-primary" runat="server" Text="Enviar" OnClick="btnEnviar_Click" data-toggle="tooltip" title="Enviar" />
                                <br /> <br /> 
                                <div class="col-sm-10 ">
                                    <asp:Label ID="lblCorrecto" runat="server" Text="Se le enviará un correo con una contraseña temporal" Style="font-size: Large; font-stretch: extra-condensed"></asp:Label>
                                </div>
                            </form>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 divlogo">
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/img/inicio.png" data-toggle="tooltip" title="Información" />
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>

</body>
</html>

