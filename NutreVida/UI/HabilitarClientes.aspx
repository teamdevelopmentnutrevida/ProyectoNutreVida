<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="HabilitarClientes.aspx.cs" Inherits="UI.HabilitarClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="card-body">
                  <div class="table-responsive">
                      
                      <table class="table table-bordered" id="dataTable" style="width:100%; padding:0;">
                          <thead>
                            <tr>
                              <th>Cédula</th>
                              <th>Nombre</th>
                              <th>Acción</th>
                            </tr>
                          </thead>
                           <tbody>
                               
                               <asp:Literal runat="server" ID="LitListaCliente"></asp:Literal>
                            </tbody>
                       </table>
                  </div>
                
                   <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
                  
                  <script type="text/javascript">
                      
                      function Habilitar(num) {
                             $.ajax({
                                type: "POST",
                                url: '/Expedientes.aspx/HabilitarCliente',
                                data: '{ced:' + num + '}',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                async: true,
                                success: function () {
                                    location.reload();
                                },
                                error: function () {
                                    alert("Error al Habilitar el cliente: "+ num);
                                }
                             });
                      }
                </script>
            </div> 


    <div class="footer navbar-light bg-white shadow">

         <asp:Button ID="btnAtras" CssClass="boton2 btn btn-primary" runat="server" Text="Atrás" OnClick="btnAtras_Click" Width="11%" />
        
         <br />  
	</div>
     <style>
		.footer {
			position: fixed;
			left: 0;
			bottom: 0;
			width: 100%;
			height: 45px;
			background-color: #E6E8E7;
			text-align: right;
		}

            .boton2 {
                margin: 5px;
                margin-right: 55px;
            }
       </style>
</asp:Content>
