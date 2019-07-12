<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="UI.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	  <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
	 <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
	   <script src="js/sweetalert28.js"></script>
    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet">
    <link href="css/Margen.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	
	<form runat="server">
	<div class="container">
    <div class="row">
       
        <div class="col-md-6">
			<div class="table table-bordered shadow rounded">
				<h2 style="margin:15px; text-align:center">Cambiar contraseña</h2><br />
				<asp:Label style="margin:4px" ID="lbCorreo" runat="server" Text="Usuario: "></asp:Label><asp:Label ID="lbUsuario" runat="server" Text=""></asp:Label><br /><br />
				<asp:Label style="margin:4px" ID="lbContraAct" runat="server" Text="Contraseña actual: "></asp:Label>
				<asp:TextBox TextMode="Password" Width="500px" style="margin:4px" CssClass="form-control" ID="txtcontraAct" runat="server" ValidationGroup="Cambio"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtcontraAct" ForeColor="Red" ValidationGroup="Cambio"></asp:RequiredFieldValidator>
				<br />
				<asp:Label style="margin:4px" ID="lbContra" runat="server" Text="Nueva contraseña:"></asp:Label><br />
				<asp:TextBox TextMode="Password" Width="500px" style="margin:4px" CssClass="form-control" ID="txtContra" runat="server" ValidationGroup="Cambio"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtContra" ForeColor="Red" ValidationGroup="Cambio"></asp:RequiredFieldValidator>
				<br />
				<asp:Label style="margin:4px" ID="lbRepetir" runat="server" Text="Repetir nueva contraseña:"></asp:Label><br />
				<asp:TextBox TextMode="Password" Width="500px" style="margin:4px" CssClass="form-control" ID="txtRepetir" runat="server" ValidationGroup="Cambio"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtRepetir" ForeColor="Red" ValidationGroup="Cambio"></asp:RequiredFieldValidator>
				<br />
				<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtContra" ControlToValidate="txtRepetir" ErrorMessage="Las contraseñas no coinciden" ForeColor="Red" ValidationGroup="Cambio"></asp:CompareValidator>
				<br />
				<asp:Button style="margin:8px" CssClass="boton btn btn-primary" ID="btnCambiar" runat="server" Text="Guardar cambios" OnClick="btnCambiar_Click" ValidationGroup="Cambio"/>
			</div>

        </div>
        <div class="col-md-6">
			<div class="table table-bordered shadow rounded">
				<h2 style="margin:15px; text-align:center">Agregar usuario</h2><br /><br /><br />
				<asp:Label style="margin:4px" ID="lbCorreoNuevo" runat="server" Text="Correo electrónico: "></asp:Label><br />
				<asp:TextBox Width="500px" style="margin:4px" CssClass="form-control" TextMode="Email" ID="txtCorr" runat="server" ValidationGroup="Nuevo"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtCorr" ForeColor="Red" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
				<br />
				<asp:Label style="margin:4px" ID="lbContUs" runat="server" Text="Contraseña:"></asp:Label><br />
				<asp:TextBox TextMode="Password" Width="500px" style="margin:4px" CssClass="form-control" ID="txtContUsu" runat="server" ValidationGroup="Nuevo"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtContUsu" ForeColor="Red" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
				<br />
				<asp:Label style="margin:4px" ID="lbRepContUs" runat="server" Text="Repetir contraseña:"></asp:Label><br />
				<asp:TextBox TextMode="Password" Width="500px" style="margin:4px" CssClass="form-control" ID="txtxRepCont" runat="server" ValidationGroup="Nuevo"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtxRepCont" ForeColor="Red" ValidationGroup="Nuevo"></asp:RequiredFieldValidator>
				<br />
				<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtContUsu" ControlToValidate="txtxRepCont" ErrorMessage="Las contraseñas no coinciden" ForeColor="Red" ValidationGroup="Nuevo"></asp:CompareValidator>
				<br />
				<asp:Button style="margin:8px" CssClass="boton btn btn-primary" ID="btnGuardar" runat="server" Text="Guadar usuario" OnClick="btnGuardar_Click" ValidationGroup="Nuevo"/>

			</div>
        </div>
     
    </div>
		   <script>
                    function mensajeError(tipo, titulo, mensaje) {
                        Swal.fire({
                            type: tipo,
                            title: titulo,
                            text: mensaje
                        })
                    }
                </script>
</div>
		</form>

				
</asp:Content>
