<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Notificacion.aspx.cs" Inherits="UI.Notificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	  <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	  <h1 class="h3 mb-2 text-gray-800">Notificaciones de pago</h1>
	<div class="card-body">
                  <div class="table-responsive">
                      
                      <table class="table table-bordered" id="dataTable" style="width:100%; padding:0;">
                          <thead>
                            <tr>
                              <th>Cliente</th>
                              <th>Fecha de pago</th>
                              <th>Acción</th>
                            </tr>
                          </thead>
                           <tbody>
                               <asp:Literal runat="server" ID="LitListaCliente"></asp:Literal>
                            </tbody>
                       </table>
                  </div>
		</div>

</asp:Content>
