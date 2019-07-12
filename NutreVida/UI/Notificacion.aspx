<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Notificacion.aspx.cs" Inherits="UI.Notificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


	  <div class="container">
       <form runat="server">
        <h1 class="title">Notificación de mensualidad</h1>
           <asp:Label ID="Fecha" Text="Fecha del Servidor:" runat="server"></asp:Label>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Button ID="RecargarNotif" runat="server" Text="Cargar Lista" CssClass="button button1" Height="51px" Width="216px" Font-Size="Small"/>         
            <br />
            <br />
           <div class="form-container">
            
            <div class="w3-container" id="listaPed">

                <table class="w3-table-allw3-hoverable">
                    <asp:literal runat="server" ID="Notif"></asp:literal> 
                </table>
           </div>
        </div>
       </form>
        
    </div>





	<%--<form runat="server">
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

	</form>--%>

</asp:Content>
