<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="UI.InicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet"/>

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet"/>
    <link href="css/InicioSesionStyles.css" rel="stylesheet" />



    <title>NutreVida</title>
</head>
<body>

	<style>
	.body {overflow-y:hidden!important;}
</style>

    <div class="container-fluid body" style="height: 100%">

        <div class="row fila">

            <div class="col-md-9 box">

                <asp:Image ID="ImgInicio" runat="server" ImageUrl="~/img/InicioSesion.jpg" />

            </div>

            <div class="col-md-3 contenido">

                <div class="container">

                    <div class="row">

                        <div class="col-md-12 divlogo">

                            <asp:Image ID="Logo" runat="server" ImageUrl="~/img/nutriVital.jfif" />

                        </div>

                    </div>

                    <div class="row">

                        <div class="col-md-12">

                            <form id="InicioSesionForm" runat="server">

                                <div class="formInicio">
                                    <div class="">
                                        <h3 class=" mb-4">
                                            &nbsp;
                                            Inicio Sesión
                                        </h3>
                                        <asp:Label ID="lbCorreo" runat="server" Text="Correo Electrónico:" CssClass="control-label col-sm-2 "></asp:Label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtCorreo" runat="server" placeholder="Digite el correo" CssClass="form-control form-control-user col-md-10"></asp:TextBox>
                                            <%--<asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtCorreo" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>--%>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lbContrasena" runat="server" Text="Contraseña:" CssClass="control-label col-sm-2 "></asp:Label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" placeholder="Digite la contraseña" CssClass="form-control form-control-user col-md-10"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lbOlvidoCont" runat="server" Text="<a href='/OlvidoContrasena.aspx'>Olvidé mi contraseña</a>" CssClass="control-label col-sm-2 small"></asp:Label>
                                        <div class="col-sm-10 divBoton">
                                            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass=" btn btn-primary btn-user btn-block col-md-5" OnClick="btnIngresar_Click" />
                                        </div>
                                    </div>

                                </div>

                            </form>

                        </div>

                    </div>

                    <div class="row">

                        <div class="col-md-11 info-inicio ">
                            <div class="col-md-10">
                                <asp:Label ID="lbNombre" runat="server" Text="Dra. Elky Fernández Palma" CssClass="control-label col-sm-2 "></asp:Label>
                            </div>
                            <div class="col-md-10">
                                <asp:Label ID="lbCod" runat="server" Text="Nutricionista Cód CNP 1187-12" CssClass="control-label col-sm-2 "></asp:Label>
                            </div>
                            <div class="col-md-10">
                                <asp:Label ID="lbTel" runat="server" Text="Tel: 7076-1100" CssClass="control-label col-sm-2 "></asp:Label>
                            </div>

                        </div>

                    </div>
                </div>
            </div>

        </div>

    </div>

</body>
</html>

