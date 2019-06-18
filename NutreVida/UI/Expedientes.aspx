﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Expedientes.aspx.cs" Inherits="UI.Expedientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <script src="js/CambioClase.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h1 class="h3 mb-2 text-gray-800">Expedientes</h1>
         <div class="card shadow mb-4">
             <div class="card-header py-3">
              <h6 class="m-0 font-weight-bold text-primary">Lista de Clientes</h6>
            </div>
              <div class="card-body">
                  <div class="table-responsive">
                      <table class="table table-bordered" id="dataTable" style="width:100%; padding:0";>
                          <thead>
                            <tr>
                              <th>Cédula</th>
                              <th>Nombre</th>
                              <th>Acción</th>
                            </tr>
                          </thead>
                           <tbody>
                               <tr>
                                    <td><a href="Cliente.aspx" onclick="CargarCliente(22)">1122</a></td>
                                   <td>prueba de prueba</td>
                                   <td>Eliminar</td>
                               </tr>
                               <asp:Literal runat="server" ID="LitListaCliente"></asp:Literal>
                               </tbody>
                       </table>
                  </div>
                   <script type="text/javascript">
                       function CargarCliente(ced) {
                           alert(ced)
                           localStorage.setItem("Ced", ced);
                       }
                   </script>
            </div> 
        </div>
    </div>
</asp:Content>
