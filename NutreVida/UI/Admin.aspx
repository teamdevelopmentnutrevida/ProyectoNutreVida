<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="UI.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	
		<div class="container">
			<div class="row">
				<div class="col-sm-1"></div>
				<div class="col-sm-5">
					<h1>Administrar credenciales</h1>

					<br /><br /><br />

					 <form class="form-horizontal subheading mb-5 form" runat="server">
                        <div class="form-group">
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label CssClass="textareaLabel" ID="lbCorreo" runat="server" Text="Nuevo Correo Electrónico:" ></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtCorreo" runat="server" placeholder="Digite el correo" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label CssClass="textareaLabel"  ID="lbContrasena" runat="server" Text="Nueva Contraseña:"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" placeholder="Digite la contraseña" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
						<div class="form-group">
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label CssClass="textareaLabel" ID="lbRepetir" runat="server" Text="Repetir Nueva Contraseña:"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtRepetir" runat="server" TextMode="Password" placeholder="Repita la nueva contraseña" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
						 <br />
                        <div class="form-group">
                            <div class="col-sm-10">
                               <asp:Button ID="btnGuardar" runat="server" Text="GUARDAR CAMBIOS" CssClass="btn btn-primary colorBoton letrabtn" />
                            </div>
                        </div>

                    </form>

				</div>
			</div>
		</div>
				
</asp:Content>
