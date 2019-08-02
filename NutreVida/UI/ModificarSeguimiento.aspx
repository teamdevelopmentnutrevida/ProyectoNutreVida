<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ModificarSeguimiento.aspx.cs" Inherits="UI.ModificarSeguimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="js/sweetalert28.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <form id="form3" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-form-label">
                <label class="form-label" for="tejeSem">Días de ejercicio semanales: </label>
                <asp:TextBox runat="server" ID="DiasEjercSem" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Días de ejercicio semanal"></asp:TextBox>
            </div>
            <div class="col-1"></div>
            <div class="col-form-label">
                <label class="form-label" for="tejeSem">Comidas Extras: </label>
                <asp:TextBox runat="server" ID="ComExt" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Comidas Extras"></asp:TextBox>
            </div>
            <div class="col-1"></div>
            <div class="col-form-label">
                <label class="form-label" for="tejeSem">Niveles de Ansiedad semanal y tiempo de comida en donde lo siente : </label>
                <asp:TextBox runat="server" ID="Ansied" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Niveles de Ansiedad"></asp:TextBox>
            </div>
        </div>
        <br />
        <h5>Recordatorio de 24 Horas</h5>
        <table class="table">
            <tr>
                <th scope="col">Tiempo de Comida</th>
                <th scope="col">Hora</th>
                <th scope="col">Descripción</th>
            </tr>
            <tr>
                <td>Ayunas</td>
                <td>
                    <asp:TextBox TextMode="Time"  CssClass="form-control" Font-Size="Small" ID="VerAyunHora" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox CssClass="form-control"  Font-Size="Small" ID="VerAyunDescr" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Desayuno</td>
                <td>
                    <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="VerDesHora" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox CssClass="form-control" Font-Size="Small" ID="VerDesDescrp" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Media Mañana</td>
                <td>
                    <asp:TextBox TextMode="Time"  CssClass="form-control" Font-Size="Small" ID="VerMedManHora" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox CssClass="form-control" Font-Size="Small" ID="VerMedManDesc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Almuerzo</td>
                <td>
                    <asp:TextBox TextMode="Time"  CssClass="form-control" Font-Size="Small" ID="VerAlmHora" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox CssClass="form-control"  Font-Size="Small" ID="VerAlmDesc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Media Tarde</td>
                <td>
                    <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="VerMedTarHora" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox CssClass="form-control"  Font-Size="Small" ID="VerMedTarDesc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Cena</td>
                <td>
                    <asp:TextBox TextMode="Time"  CssClass="form-control" Font-Size="Small" ID="VerCenaHora" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox CssClass="form-control"  Font-Size="Small" ID="VerCenaDesc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Colación Nocturna</td>
                <td>
                    <asp:TextBox TextMode="Time"  CssClass="form-control" Font-Size="Small" ID="VerColNocHora" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox CssClass="form-control"  Font-Size="Small" ID="VerColNocDesc" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <h5>Seguimiento de Antropometría</h5>
        <div class="row">
            <div class="col-form-label">
                <label class="form-label" for="tFecha">Fecha:</label>
                <asp:TextBox ID="VerSAFech" runat="server" CssClass="form-control" Font-Size="Small" TextMode="Date" title="Fecha"></asp:TextBox>
                <label class="form-label" for="tEdad">Edad:</label>
                <asp:TextBox ID="VerSAEdad" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Edad"></asp:TextBox>
                <label class="form-label" for="tTalla">Talla: </label>
                <asp:TextBox ID="VerSATalla" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Talla"></asp:TextBox>
                <label class="form-label" for="tCM">CM:</label>
                <asp:TextBox ID="VerSACM" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="CM"></asp:TextBox>
                <label class="form-label" for="tPesoSegAnt">Peso:</label>
                <asp:TextBox ID="VerSAPeso" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Peso"></asp:TextBox>
                <label class="form-label" for="tImcSegAnt">IMC: </label>
                <asp:TextBox ID="VerSAIMC" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="IMC"></asp:TextBox>
                <label class="form-label" for="tSegAntAgua">Agua: </label>
                <asp:TextBox ID="VerSAAgua"  runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Agua"></asp:TextBox>
                <label class="form-label" for="tSegAntMasa">Masa Osea:</label>
                <asp:TextBox ID="VerSAMasaOsea"  runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Masa Osea"></asp:TextBox>
            </div>
            <div class="col-1"></div>
            <div class="col-form-label">
                <label class="form-label" for="tEddMetab">Edad Metabólica:</label>
                <asp:TextBox ID="VerSAEddMet" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Edad Metabólica"></asp:TextBox>
                <label class="form-label" for="tGrasaAnalizador">Grasa % analizador:</label>
                <asp:TextBox ID="VerSAGrAnaliz" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Grasa % analizador"></asp:TextBox>
                <label class="form-label" for="tGrasBascu">% Grasa báscula: </label>
                <asp:TextBox ID="VerSAGrBasc" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Grasa báscula"></asp:TextBox>
                <label class="form-label" for="tGB_BI">BI:</label>
                <asp:TextBox ID="VerSAGBBI" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Izquierda"></asp:TextBox>
                <label class="form-label" for="tGB_BD">BD:</label>
                <asp:TextBox ID="VerSAGBBD" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Derecho"></asp:TextBox>
                <label class="form-label" for="tGB_PI">PI:</label>
                <asp:TextBox ID="VerSAGBPI" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Pierna Izquierda"></asp:TextBox>
                <label class="form-label" for="tGB_PD">PD:</label>
                <asp:TextBox ID="VerSAGBPD" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Pierna Derecha"></asp:TextBox>
                <label class="form-label" for="tGB_Tronco">Tronco:</label>
                <asp:TextBox ID="VerSAGBTronco" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Tronco"></asp:TextBox>
            </div>
            <div class="col-1"></div>
            <div class="col-form-label">
                <label class="form-label" for="tGrasVisceral">% Grasa Visceral:</label>
                <asp:TextBox ID="VerSAGrVisc"  runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Grasa visceral"></asp:TextBox>
                <label class="form-label" for="tPorcentMusculo">% Músculo:</label>
                <asp:TextBox ID="VerSAPorMusc" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="% Músculo"></asp:TextBox>
                <label class="form-label" for="tPM_BI">BI: </label>
                <asp:TextBox ID="VerSAPMBI"  runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Izquierdo"></asp:TextBox>
                <label class="form-label" for="tPM_BD">BD:</label>
                <asp:TextBox ID="VerSAPMBD"  runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Derecho"></asp:TextBox>
                <label class="form-label" for="tPM_PI">PI:</label>
                <asp:TextBox ID="VerSAPMPI"  runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Pierna Izquierda"></asp:TextBox>
                <label class="form-label" for="tPM_PD">PD:</label>
                <asp:TextBox ID="VerSAPMPD"  runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Pierna Derecha"></asp:TextBox>
                <label class="form-label" for="tPM_Tronco">Tronco</label>
                <asp:TextBox ID="VerSAPMTronco" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Tronco"></asp:TextBox>
            </div>
            <div class="col-1"></div>
            <div class="col-form-label">
                <label class="form-label" for="tCircunfCintura">Circunferencia cintura: </label>
                <asp:TextBox ID="VerSACircunfCint" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Circunferencia de la cintura"></asp:TextBox>
                <label class="form-label" for="tCadeSegAnt">Cadera:</label>
                <asp:TextBox ID="VerSACadera"  runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Cadera"></asp:TextBox>
                <label class="form-label" for="tMusloIzq">Muslo Izquierdo:</label>
                <asp:TextBox ID="VerSAMusIzq"  runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Muslo Izquierdo"></asp:TextBox>
                <label class="form-label" for="tMusloDer">Muslo Derecho:</label>
                <asp:TextBox ID="VerSAMusDer" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Muslo Derecho"></asp:TextBox>
                <label class="form-label" for="tBrazoIzq">Brazo Izquierdo:</label>
                <asp:TextBox ID="VerSABrazIzq" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Izquierdo"></asp:TextBox>
                <label class="form-label" for="tBrazoDer">Brazo Derecho:</label>
                <asp:TextBox ID="VerSABrazDer"  runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Derecho"></asp:TextBox>
                <label class="form-label" for="tPesoMeta">Peso Meta o Ideal:</label>
                <asp:TextBox ID="VerSAPesoMet"  runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Peso Meta o Ideal"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-form-label">
                <label class="form-label" for="SNObserv">Observaciones: </label>
                <asp:TextBox runat="server" ID="VerSNObserv" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Observaciones"></asp:TextBox>
            </div>
        </div>
        <br />
        <br />
        <br />

        <div class="footer navbar-light bg-white shadow">
            <asp:Button ID="Guardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="Guardar_Click" />
            <asp:Button ID="btnAtras" CssClass="boton btn btn-primary" runat="server" Text="Cancelar" OnClick="btnAtras_Click" />
            <br />
        </div>
    </div>      <%--fin container--%>
</form>
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
        .boton {
                margin: 5px;
                margin-right: 55px;
        }
       </style>
    <script>
       function mensajeError(tipo, titulo, mensaje) {
                        Swal.fire({
                            type: tipo,
                            title: titulo,
                            text: mensaje
                        })
        }
    </script>
</asp:Content>
