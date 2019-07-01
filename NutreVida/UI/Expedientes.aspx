<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Expedientes.aspx.cs" Inherits="UI.Expedientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <script src="js/CambioClase.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <form runat="server">
    <div class="container-fluid">
        <h1 class="h3 mb-2 text-gray-800">Expedientes</h1>
         <div class="card shadow mb-4">
             <div class="card-header py-3" style="text-align:right;">
              <%--<h6 class="m-0 font-weight-bold text-primary">Lista de Clientes</h6>--%>
              <asp:Button ID="NuevoCliente" runat="server" OnClick="NuevoCliente_Click" CssClass="boton btn btn-primary" Text="+"></asp:Button>
            </div>
             
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
                 <script type="text/javascript">
                      
                     function Redirige(num) {
                          $.ajax({
                                type: "POST",
                                url: '/Expedientes.aspx/Redirigir_Click',
                                data: '{ced:' + num + '}',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                async: true,
                              success: function () {
                                  location.href = "Cliente.aspx";
                                    
                                },
                                error: function () {
                                    alert("No funciona");
                                }
                             });
                     }
                 </script>
                   <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
                  <script type="text/javascript">
                      
                      function Eliminar_Click(num) {
                             $.ajax({
                                type: "POST",
                                url: '/Expedientes.aspx/EliminarCliente',
                                data: '{ced:' + num + '}',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                async: true,
                                success: function () {
                                    location.reload();
                                },
                                error: function () {
                                    alert("Error al Deshabilitar el cliente: "+ num);
                                }
                             });
                      }
                </script>
            </div> 
        </div>
    </div>
        </form>
</asp:Content>
