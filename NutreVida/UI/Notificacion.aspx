<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Notificacion.aspx.cs" Inherits="UI.Notificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	  <meta name="viewport" content="width=device-width, initial-scale=1">
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<form runat="server">
	<div class="container">
			<div class="row">
				<div class="col-sm-7"></div>
				<div class="col-sm-5">
					
					<asp:button ID="btnCita" runat="server" text="Notificaciones de Cita" CssClass="btn btn-primary colorBoton" />	
					<asp:button ID="btnPago" runat="server" text="Notificaciones de Pago" CssClass="btn btn-primary colorBoton" />
				
				</div>
			</div>
		</div>

			<div class="container">
				<div class="row">
					<div class="col-sm-1"></div>
					<div class="col-sm-11">
						 <h1 class="h3 mb-2 text-gray-800">Notificaciones pendientes</h1>
						<br />
						<table style="width: 100%" id="ListaClientes">
							<tr>
								<th>Cliente</th>
								<th>Mensaje</th>
								<th>Enviar</th>
							</tr>
							<tr class="item">
								<td>
									<asp:label runat="server" id="NombCl">Smith Rojas</asp:label>
								</td>
								<td>
									<asp:label runat="server" id="Label1">Nutre Vida le recuerda su cita para este lunes a las 10:00 am</asp:label>
								</td>
								<td>
									<asp:linkbutton runat="server" id="Elim">Enviar</asp:linkbutton>
								</td>
							</tr>
							<tr class="item">
								<td>
									<asp:label runat="server" id="Label2">Jackson Sanchez</asp:label>
								</td>
								<td>
									<asp:label runat="server" id="Label3">Nutre Vida le recuerda que tiene pendiente el pago del mes de Junio</asp:label>
								</td>
								<td>
									<asp:linkbutton runat="server" id="LinkButton2">Enviar</asp:linkbutton>
								</td>
							</tr>
						</table>
					</div>
				</div>
			</div>

	</form>

</asp:Content>
