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
             <div class="card-header py-3">
              <h6 class="m-0 font-weight-bold text-primary">Lista de Clientes</h6>
            </div>
              <div class="card-body">
                  <div class="table-responsive">
                      <asp:Table id="dataTable" runat="server"
                        CellPadding="10" 
                        GridLines="Both"
                        HorizontalAlign="Center"
                        CssClass="table table-bordered">

                        <asp:TableRow>
                            <asp:TableHeaderCell>
                                Cédula
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell>
                               Nombre
                            </asp:TableHeaderCell>
                            <asp:TableHeaderCell>
                               Acción
                            </asp:TableHeaderCell>
                        </asp:TableRow>
                     <asp:TableRow>
                            <asp:TableCell>
                                <asp:LinkButton runat="server" Enabled="true" CommandArgument="116750978" ID="Red" OnClick="Redirigir_Click" Text="22"></asp:LinkButton>
                            </asp:TableCell>
                            <asp:TableCell>
                                Prueba
                            </asp:TableCell>
                          <asp:TableCell>
                               Eliminar
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                     <%-- <table class="table table-bordered" id="dataTable" style="width:100%; padding:0";>
                          <thead>
                            <tr>
                              <th>Cédula</th>
                              <th>Nombre</th>
                              <th>Acción</th>
                            </tr>
                          </thead>
                           <tbody>
                               <tr>
                                   <td><asp:LinkButton runat="server" OnClientClick="Redirigir_Click" Enabled="true" CommandArgument="201110222" ID="Red" OnClick="Redirigir_Click" Text="22"></asp:LinkButton></td>
                                   <td>prueba de prueba</td>
                                   <td>Eliminar</td>
                               </tr>
                               <asp:Literal runat="server" ID="LitListaCliente"></asp:Literal>
                               </tbody>
                       </table>--%>
                  </div>
                 
                  <%-- <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
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
                                    alert("funciona");
                                },
                                error: function () {
                                    alert("No funciona");
                                }
                             });
                      }
                </script>--%>
            </div> 
        </div>
    </div>
        </form>
</asp:Content>
