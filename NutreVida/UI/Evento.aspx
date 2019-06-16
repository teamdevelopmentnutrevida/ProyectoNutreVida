<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Evento.aspx.cs" Inherits="UI.Evento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Nombre del evento"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEvento" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Hora inicio"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Hora fin"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <div class="col-11 margen" style="width: 100%;">
                                    <label class="form-label" for="iFecha">Fecha:</label>
                                    <asp:Label runat="server" ID="Label5" Font-Size="Medium" data-toggle="tooltip" title="Fecha"></asp:Label>
                                    <input id="iFecha" type="date" runat="server" />
                                </div>
        <br />
        <br />
        <br />
        <asp:Button ID="buttonEnviar" runat="server" OnClick="buttonEnviar_Click" style="height: 26px" Text="Button" />
    
    </div>
    </form>
</asp:Content>
