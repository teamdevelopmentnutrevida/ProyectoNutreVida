<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Expedientes.aspx.cs" Inherits="UI.Expedientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
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
                      <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                          <thead>
                            <tr>
                              <th>Cédula</th>
                              <th>Nombre</th>
                              <th>Acción</th>
                            </tr>
                          </thead>
                       </table>
                  </div>
            </div> 
        </div>
    </div>
</asp:Content>
