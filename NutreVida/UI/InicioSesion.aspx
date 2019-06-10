<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="UI.InicioSesion" %>

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

	<div class="container-fluid">


	<div class="row fila">

		<div class="col-lg-9 box">
			<asp:Image ID="ImgInicio" runat="server" ImageUrl="~/img/InicioSesion.jpg" data-toggle="tooltip" title="Nutre Vida" />

		</div>

		<div class="col-lg-3 contenido">


			<div class="container">

				<div class="row">

					<div class="col-md-12 divlogo">

						<asp:Image ID="Logo" runat="server" ImageUrl="~/img/nutriVital.jfif" data-toggle="tooltip" title="Nutre Vida" />

					</div>

				</div>

				<div class="row">

					<div class="col-md-12">

						<h3>Inicio de Sesión</h3>

						<form id="InicioSesionForm" runat="server">
							<asp:Label ID="lbCorreo" runat="server" Text="Correo electrónico:"></asp:Label>
							<br />
							<asp:TextBox ID="txtCorreo" TextMode="Email" runat="server" data-toggle="tooltip" title="Correo electrónico"></asp:TextBox>
                            <br />
							<asp:Label ID="lbContras" runat="server" Text="Contraseña:"></asp:Label>
							<br />
							<asp:TextBox TextMode="Password" ID="txtContras" runat="server" data-toggle="tooltip" title="Contraseña"></asp:TextBox>
							<br />
							<asp:Label ID="lblIncorrecto" runat="server" Text=""></asp:Label>
							<br />
							<asp:Label ID="lbOlvidoCont" runat="server" Text="<a href='/OlvidoContrasena.aspx'>Olvidé mi contraseña</a>" CssClass="control-label col-sm-2 small"></asp:Label>
							<br />
							<asp:Button ID="btnIngresar" CssClass=" btn btn-primary" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" data-toggle="tooltip" title="Ingresar"/>
						</form>
					</div>
				</div>


				<div class="row">
					<div class="col-md-11 info-inicio " data-toggle="tooltip" title="Información médica">
						<asp:Label ID="lbNombre" runat="server" Text="Dra. Elky Fernández Palma" CssClass="control-label"></asp:Label>
						<asp:Label ID="lbCod" runat="server" Text="Nutricionista Cód CNP 1187-12" CssClass="control-label"></asp:Label>
						<asp:Label ID="lbTel" runat="server" Text="Tel:7076-1100" CssClass="control-label"></asp:Label>
					</div>
				</div>
			</div>
		</div>
	</div>

		
	</div>

</body>
</html>

