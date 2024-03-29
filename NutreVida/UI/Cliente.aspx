﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="Cliente.aspx.cs" Inherits="UI.Cliente" %>
   
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <link href="css/sb-admin-2.min.css" rel="stylesheet">
     <script src="js/sweetalert28.js"></script>
      <script type="text/javascript">
        function validarEmail(elemento) {

            var texto = document.getElementById(elemento.id).value;
            var regex = /^[-\w.%+]{1,64}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/i;

            if (!regex.test(texto)) {
                document.getElementById("resultado").innerHTML = "Correo invalido<br/>";

            } else {
                document.getElementById("resultado").innerHTML = "";
            }

        }
    </script>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="js/formulas.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form3" runat="server">
         <div class="container">
                <div class="row">
                <h1 class="h3 mb-2 text-gray-800">Información Personal</h1>
            </div>
            <div class="row">
                    <div class="col-form-label">
                        <label class="form-label" for="tCedula">Cédula:</label> 
                        <asp:TextBox ID="ced1" oninput="validity.valid||(value='');" runat="server" CssClass="form-control" Font-Size="Small" type="number" min="0" data-toggle="tooltip" title="Cedula de identidad" Enabled="false"></asp:TextBox>
                        <label class="form-label" for="tOcup">Ocupación:</label>
                        <asp:TextBox ID="txtOcup" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Ocupación" onKeyPress="javascript:Cambiartexto();"></asp:TextBox>                          
                         <label class="form-label" for="tTel">Teléfono:</label>
                         <asp:TextBox ID="txtTel" runat="server" CssClass="form-control" Font-Size="Small" type="number" oninput="validity.valid||(value='');" min="0" data-toggle="tooltip" title="Número telefónico"  onKeyPress="javascript:Cambiartexto();"></asp:TextBox>    
                        <label class="form-label" for="Consult">Consultorio:</label>
                         <asp:DropDownList runat="server" TabIndex="13" ID="ConsultorDropList" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Consultorio">
                        <asp:ListItem Value="San Ramón"> San Ramón </asp:ListItem>
                        <asp:ListItem Value="Alajuela"> Alajuela </asp:ListItem>
                    </asp:DropDownList>
                    </div>
                    <div class="col-1"></div>
                    <div class="col-form-label">
                         <label class="form-label" for="tnombre">Nombre:</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Nombre"></asp:TextBox>                      
                        <label class="form-label" for="tEmail">Email:</label>
                        <asp:TextBox ID="txtEmail" onkeyup="validarEmail(this)" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Correo electrónico"></asp:TextBox>
                        <label class="form-label" for="tWhats">Utiliza whatsapp:</label>
                       <asp:DropDownList runat="server" ID="dropWhats" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Usa whatsapp">
                            <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                            <asp:ListItem Value="No"> No </asp:ListItem>
                        </asp:DropDownList>
                        <label class="form-label" for="tEdad">Edad:</label>
                        <asp:TextBox ID="EdadCliente" runat="server" TextMode="Number" step="any" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Edad"></asp:TextBox>
                        </div>
                    <div class="col-1"></div>
                    <div class="col-form-label">
                        <label class="form-label" for="tPrimerApellido">Primer apellido:</label>
                        <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Primer apellido"></asp:TextBox>
                        <label class="form-label" for="tEstadoCivil">Estado Civil:</label>
                            <asp:DropDownList runat="server" ID="dropEstadoCivil" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Estado civil">
                                        <asp:ListItem Value="Soltero"> Soltero(a) </asp:ListItem>
                                        <asp:ListItem Value="Casado"> Casado(a) </asp:ListItem>
                                        <asp:ListItem Value="Divorciado"> Divorciado(a) </asp:ListItem>
                                        <asp:ListItem Value="Otro"> Otro </asp:ListItem>
                                    </asp:DropDownList>
                         <label class="form-label" for="tResid">Residencia:</label><asp:Label runat="server" ID="Label9" Font-Size="Medium"></asp:Label>
                        <asp:TextBox ID="txtResid" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Lugar de residencia"></asp:TextBox>
                        <label class="form-label" for="iFechaIngreso">Fecha de Ingreso:</label>
                        <asp:TextBox runat="server" ID="FechIngreso" CssClass="form-control" Font-Size="Small" TextMode="Date" data-toggle="tooltip" title="Fecha de ingreso"></asp:TextBox>               
                        </div>
                    <div class="col-1"></div>
                    <div class="col-form-label">
                        <label class="form-label" for="tSegundoApellido">Segundo apellido:</label>
                        <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Segundo apellido"></asp:TextBox>
                        <label class="form-label" for="tSex">Sexo:</label>
                        <asp:DropDownList runat="server" ID="dropSexo" CssClass="form-control" Font-Size="Small" Font-Bold="False" data-toggle="tooltip" title="Sexo">
                                        <asp:ListItem Value="F"> Femenino </asp:ListItem>
                                        <asp:ListItem Value="M"> Masculino </asp:ListItem>
                                        <asp:ListItem Value="O"> Otro </asp:ListItem>
                                    </asp:DropDownList> 
                        <label class="form-label" for="iFechaNac">Fecha de Nacimiento:</label>
                        <asp:TextBox runat="server" ID="FechNacimi" CssClass="form-control" TextMode="Date" Font-Size="Small" data-toggle="tooltip" title="Fecha de nacimiento"></asp:TextBox>               
                    <br />
                    <br />
                       
                    </div>
                </div>
            <br />
            <div class="col-11" style="width:100%; float:left;">
              <nav>
                  <div class="nav nav-tabs" id="nav-tab" role="tablist">
                    <a class="nav-item nav-link active" id="nav-HM" data-toggle="tab" href="#HM" role="tab" aria-controls="nav-home" aria-selected="true">Historial Médico</a>
                    <a class="nav-item nav-link" id="nav-HA" data-toggle="tab" href="#HA" role="tab" aria-controls="nav-profile" aria-selected="false">Hábitos Alimentarios</a>
                    <a class="nav-item nav-link" id="nav-Ant" data-toggle="tab" href="#Ant" role="tab" aria-controls="nav-contact" aria-selected="false">Antropometría</a>
                   <a class="nav-item nav-link" id="nav-SS" data-toggle="tab" href="#SS" role="tab" aria-controls="nav-contact" aria-selected="false">Seguimiento Semanal</a>
                  <a class="nav-item nav-link" id="nav-SM" data-toggle="tab" href="#SM" role="tab" aria-controls="nav-contact" aria-selected="false">Seguimiento Nutricional</a>
                  </div>
                </nav>
             
             <div class="tab-content" id="nav-tabContent">
                  <%--    Historial Medico--%>

                  <div id="HM" class="tab-pane fade show active" role="tabpanel" aria-labelledby="nav-HM">
					    <br />
            <div class="col-11 margen" style="width: 100%;">
                            <label class="form-label" for="tAntFam">Antecedentes Familiares:</label>
                            <asp:TextBox Width="700px" ID="txtAntec" TextMode="MultiLine" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Antecedentes Familiares"></asp:TextBox>
                        </div>
                        <div class="col-11 margen" style="width: 100%;">
                            <label class="form-label" for="tPat">Patologías que padece:</label>
                            <asp:TextBox Width="700px" ID="txtPatol" runat="server" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Patologías"></asp:TextBox>
                        </div>

                        <div class="col-11 margen" style="width: 100%;">
                            <label class="form-label" for="tActividadFisica">Actividades físicas:</label>
                            <asp:TextBox Width="700px" ID="txtActividadFisica" runat="server" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Actividades físicas"></asp:TextBox>
                        </div>

                        <br />
                        <h5>Consumo de:</h5>

                        <div class="row">
                          <div class="col-form-label">
                            <label class="form-label" for="tLicor">Licor:</label>
                            <asp:DropDownList runat="server" ID="DropLicor" CssClass="form-control" Font-Size="Small" OnSelectedIndexChanged="DropLicor_SelectedIndexChanged" AutoPostBack="true" data-toggle="tooltip" title="Licor">
                                <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                                <asp:ListItem Value="No"> No </asp:ListItem>
                            </asp:DropDownList>
                               <label class="form-label" for="tFum">Fumado:</label>
                              <asp:DropDownList runat="server" ID="DropFuma" CssClass="form-control" Font-Size="Small" OnSelectedIndexChanged="DropFuma_SelectedIndexChanged" AutoPostBack="true" data-toggle="tooltip" title="Fumado">
                                <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                                <asp:ListItem Value="No"> No </asp:ListItem>
                            </asp:DropDownList>
                         </div>
                          <div class="col-1"></div>
                            <div class="col-form-label">
                          
                            <label class="form-label" for="tFrecLic">Frecuencia:</label>
                                <asp:TextBox ID="txtFrecLicor" runat="server" CssClass="form-control" Font-Size="Small" Enabled="false" data-toggle="tooltip" title="Frecuencia de licor"></asp:TextBox>
                         <label class="form-label" for="tfrecFum">Frecuencia:</label>
                            <asp:TextBox ID="txtFrecFuma" runat="server" CssClass="form-control" Font-Size="Small" Enabled="false" data-toggle="tooltip" title="Frecuencia de fumado"></asp:TextBox>
                       
                        </div>
                    </div>
                        <br />

                        <h3>Medicamentos o suplementos que consume:</h3>
                        <div class="row">
                            <div class="col-20">
                                <asp:TextBox ID="tNomMed" runat="server" placeholder="Nombre" CssClass="form-control" Font-Size="Small"></asp:TextBox>
                            </div>
                            <div class="col-20">
                                <asp:TextBox ID="tMotvMed" runat="server" placeholder="Motivo" CssClass="form-control" Font-Size="Small"></asp:TextBox>
                            </div>
                            <div class="col-20">
                                <asp:TextBox ID="tFrecMed" runat="server" placeholder="Frecuencia" CssClass="form-control" Font-Size="Small"></asp:TextBox>
                            </div>
                            <div class="col-20">
                                <asp:TextBox ID="tDosisMed" runat="server" placeholder="Dosis" CssClass="form-control" Font-Size="Small"></asp:TextBox>
                            </div>
                            <div class="col-20">
                                <asp:Button ID="MedicButton" runat="server" Text="Agregar" CssClass=" btn btn-primary" OnClick="MedicButton_Click" />
                            </div>

                        </div>
                        <br />
                        <div class="row">
                            <table class="table">
                                <tr>
                                    <th scope="col">Medicamento</th>
                                    <th scope="col">Motivo</th>
                                    <th scope="col">Frecuencia</th>
                                    <th scope="col">Dosis</th>
                                </tr>
                                <asp:Literal ID="tSuplementoMedico" runat="server"></asp:Literal>
                            </table>

                        </div>
                        <br />
                        <div class="col-11 margen" style="width: 70%;">
                            <label class="form-label" for="tFechExm">Fecha de últimos examenes de sangre o revisión médica: </label>
                            <asp:TextBox runat="server" ID="FechRevMedica" TextMode="Date" CssClass="form-control" Font-Size="Small"></asp:TextBox>
                            
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />
                   
                    </div>
                    <%--tab hist medico--%>

                  <%--   Habitos alimentarios--%>
                 <div id="HA" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-HA">
                   <%--  <h5>Habitos Alimentarios</h5>--%>
                      <br />
					 <div class="row">
                          <div class="col-form-label">
                              <label class="form-label" for="tComD">¿Cuántas veces come al día? </label>
                                <asp:TextBox ID="numeroComidas" runat="server" type="number" min="0" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Cantidad de comidas al día" />
                               <label class="form-label" for="tComeHoraDia">¿Acostumbra a comer a las horas al día? </label>
                                <asp:DropDownList runat="server" ID="ComeHoras" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="¿Come al día?">
                                    <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                <label class="form-label" for="tComeExprss">¿Cuántas veces a la semana come fuera o pide un express? </label>
                                <asp:TextBox ID="txtEspres" runat="server" CssClass="form-control" Font-Size="Small" type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Cantidad de consumo"></asp:TextBox>
                                <label class="form-label" for="tGenerComeAfuera">¿Generalmente que come fuera de la casa?</label>
                                <asp:TextBox ID="txtQueComeFuera" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Comida fuera de la casa"></asp:TextBox>
                                <label class="form-label" for="tAzucarB">¿Cuánta azúcar le agrega a las bebidas?</label>
                                <asp:TextBox ID="cantAzucar" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Cantidad de azúcar en las bebidas"></asp:TextBox>
                                <label class="form-label" for="tAzucarB">¿Los alimentos que cocina los elabora generalmente? </label>
                               <asp:DropDownList runat="server" ID="dropCocinaCon" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Elaboración de alimentos">
                                    <asp:ListItem Value="aceite">Aceite</asp:ListItem>
                                    <asp:ListItem Value="horneado"> Horneado </asp:ListItem>
                                    <asp:ListItem Value="hervido"> Hervido </asp:ListItem>
                                    <asp:ListItem Value="micro"> Microondas </asp:ListItem>
                                </asp:DropDownList>
                                <label class="form-label" for="tAguaDia">¿Cuántos vasos de agua toma al día? </label>
                               <asp:TextBox ID="txtCuantaAgua" runat="server" type="number" min="0" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Agua por día" />
                               <label class="form-label" for="tAder">¿Agrega salsa tomate, mayonesa, mantequilla o natilla a la comida? </label>
                                 <asp:DropDownList runat="server" ID="dropAderezos" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Aderezos a la comida">
                                    <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-1"></div>
                            <div class="col-form-label">
                            <h5>Le gusta la mayoría de:</h5>
                                <label class="form-label" for="lbFrutas">Frutas:</label>
                                <asp:DropDownList runat="server" ID="dropFrutas" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="frutas">
                                    <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                <label class="form-label" for="lbVeget">Vegetales:</label>
                                <asp:DropDownList runat="server" ID="dropVeget" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Vegetales">
                                    <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                <label class="form-label" for="lbLeche">Leche:</label>
                                <asp:DropDownList runat="server" ID="dropLeche" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Leche">
                                    <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                 <label class="form-label" for="lbHuevo">Huevo:</label>
                                <asp:DropDownList runat="server" ID="dropHuevo" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Huevo">
                                    <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                 <label class="form-label" for="lbYogurt">Yogurt:</label>
                                <asp:DropDownList runat="server" ID="dropYogurt" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Yogurt">
                                    <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                 <label class="form-label" for="lbCarne">Carne:</label>
                                <asp:DropDownList runat="server" ID="dropCarne" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Carne">
                                    <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                 <label class="form-label" for="lbQueso">Queso:</label>
                                <asp:DropDownList runat="server" ID="dropQueso" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Queso">
                                    <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                 <label class="form-label" for="lbAguacate">Aguacate:</label>
                                <asp:DropDownList runat="server" ID="dropAguacate" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Aguacate">
                                    <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                 <label class="form-label" for="lbSemillas">Semillas:</label>
                                <asp:DropDownList runat="server" ID="dropSemillas" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Semillas">
                                    <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                     <div class="row">
                        <h5>Recordatorio de 24 Horas</h5>
                        <table class="table">
                            <tr>
                                <th scope="col">Tiempo de Comida</th>
                                <th scope="col">&nbsp;&nbsp; Hora</th>
                                <th scope="col">&nbsp;&nbsp;Descripción</th>
                            </tr>
                            <tr>
                                <td>Ayunas</td>
                                <td>
                                    <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="txtHoraAyunas" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox CssClass="form-control" Font-Size="Small" ID="txtDescAyunas" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Desayuno</td>
                                <td>
                                    <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="txtHoraDesayuno" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox CssClass="form-control" Font-Size="Small" ID="txtDescDesay" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Media Mañana</td>
                                <td>
                                    <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="txtHoraMediaM" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox CssClass="form-control" Font-Size="Small" ID="txtDescMediaM" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Almuerzo</td>
                                <td>
                                    <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="txtHoraAlmmuerzo" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox CssClass="form-control" Font-Size="Small" ID="txtDescAlmuerzo" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Media Tarde</td>
                                <td>
                                    <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="txtHoraTarde" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox CssClass="form-control" Font-Size="Small" ID="txtDescTarde" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Cena</td>
                                <td>
                                    <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="txtHoraCena" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox CssClass="form-control" Font-Size="Small" ID="txtDescCena" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Colación Nocturna</td>
                                <td>
                                    <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="txtHoraColacion" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox CssClass="form-control" Font-Size="Small" ID="txtDescColacion" runat="server"></asp:TextBox></td>
                            </tr>
                        </table>

                    </div>
						   <br />
                        <br />
                        <br />
            
                    </div>
                    <%--tab hab aliment--%>

             <%--    Antropometria--%>
                 <div id="Ant" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-Ant">
					   <br />
                     <div class="row">
                                <div class="col-form-label">
                                    <label class="form-label" for="tEdad">Edad:</label>
                                    <asp:TextBox step="any" ID="txtEdad" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Edad" ></asp:TextBox>
                                    <label class="form-label" for="tTalla">Talla: </label>
                                    <asp:TextBox step="any" onBlur="validarIMC(); validarPesoIdeal(); validarGEB()" ID="txtTalla" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Talla"></asp:TextBox>
                                    <label class="form-label" for="tPesoActual">Peso Actual:</label>
                                    <asp:TextBox step="any" onBlur="validarIMC()" ID="txtPesoActual" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Peso actual"></asp:TextBox>
                                    <label class="form-label" for="tPesoMaxTeoria">Peso máximo en teoría:</label>
                                    <asp:TextBox step="any" ID="txtPesoMaxTeoria" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Peso Máximo en teoría"></asp:TextBox>
                                    <label class="form-label" for="tPesoIdeal">Peso meta o ideal: </label>
                                    <asp:TextBox step="any" onBlur="validarGEB()" ID="txtPesoIdeal" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Peso meta o ideal"></asp:TextBox>
                                    <label class="form-label" for="tEdadMetab">Edad metabólica: </label>
                                    <asp:TextBox step="any" ID="txtEdadMetabolica" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Edad metabólica"></asp:TextBox>
                                    <label class="form-label" for="tCintura">Cintura:</label>
                                    <asp:TextBox step="any" ID="txtCintura" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Cintura"></asp:TextBox>
                                    <label class="form-label" for="tAbdm">Abdomen:</label>
                                    <asp:TextBox step="any" ID="txtAbdomen" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Abdomen"></asp:TextBox>
                                </div>
                                <div class="col-1"></div>
                                <div class="col-form-label">
                                    <label class="form-label" for="tMusloIzq">Muslo Izquierdo:</label>
                                    <asp:TextBox step="any" ID="txtMusloIzq" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Muslo Izquierdo"></asp:TextBox>
                                    <label class="form-label" for="tMusloDer">Muslo Derecho:</label>
                                    <asp:TextBox step="any" ID="txtMusloDer" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Muslo Derecho"></asp:TextBox>
                                    <label class="form-label" for="tPMB">PMB: </label>
                                    <asp:TextBox step="any" ID="txtPMB" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="PMB"></asp:TextBox>
                                    <label class="form-label" for="tCMB">CMB: </label>
                                    <asp:TextBox step="any" ID="txtCMB" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="CMB"></asp:TextBox>
                                    <label class="form-label" for="tAgua">Agua: </label>
                                    <asp:TextBox step="any" ID="txtAgua" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Agua"></asp:TextBox>
                                    <label class="form-label" for="tComplexión">Complexión: </label>
                                    <asp:TextBox step="any" ID="txtComplexion" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Complexión"></asp:TextBox>
                                    <label class="form-label" for="tMasaOsea">Masa ósea: </label>
                                    <asp:TextBox step="any" ID="txtMasaOsea" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Masa ósea"></asp:TextBox>
                                    <label class="form-label" for="tCadera">Cadera:</label>
                                    <asp:TextBox step="any" ID="txtCadera" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Cadera"></asp:TextBox>
                                </div>
                                <div class="col-1"></div>
                                <div class="col-form-label">
                                    <label class="form-label" for="tGrasaAnalizador">%Grasa analizador:</label>
                                    <asp:TextBox step="any" ID="txtGrasaAnalizador" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Grasa analizador"></asp:TextBox>
                                    <label class="form-label" for="tGrasVisceral">% Grasa Visceral:</label>
                                    <asp:TextBox step="any" ID="txtGarsaViceral" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Grasa visceral"></asp:TextBox>
                                    <label class="form-label" for="tGrasBascu">% Grasa báscula: </label>
                                    <asp:TextBox step="any" ID="txtGrasaBascula" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Grasa báscula"></asp:TextBox>
                                    <label class="form-label" for="tGB_BI">BI:</label>
                                    <asp:TextBox step="any" ID="txtGB_BI" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="GB_BI"></asp:TextBox>
                                    <label class="form-label" for="tGB_BD">BD:</label>
                                    <asp:TextBox step="any" ID="txtGB_BD" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="GB_BD"></asp:TextBox>
                                    <label class="form-label" for="tGB_PI">PI:</label>
                                    <asp:TextBox step="any" ID="txtGB_PI" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="GB_PI"></asp:TextBox>
                                    <label class="form-label" for="tGB_PD">PD:</label>
                                    <asp:TextBox step="any" ID="txtGB_PD" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="GB_PD"></asp:TextBox>
                                    <label class="form-label" for="tGB_Tronco">Tronco:</label>
                                    <asp:TextBox step="any" ID="txtGB_Trono" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="GB_Tronco"></asp:TextBox>
                                </div>
                                <div class="col-1"></div>
                                <div class="col-form-label">
                                    <label class="form-label" for="tCircunfMun">Circunferencia muñeca: </label>
                                    <asp:TextBox step="any" ID="txtCircunferencia" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Circunferencia de la muñeca"></asp:TextBox>
                                    <label class="form-label" for="tIMC">IMC:</label>
                                    <asp:TextBox step="any"  ID="txtIMC" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="IMC"></asp:TextBox>
                                    <label class="form-label" for="tPorcentMusculo">% Músculo:</label>
                                    <asp:TextBox step="any" ID="txtPorcentaje" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Músculo"></asp:TextBox>
                                    <label class="form-label" for="tPM_BI">BI: </label>
                                    <asp:TextBox step="any" ID="txtPM_BI" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="PM_BI"></asp:TextBox>
                                    <label class="form-label" for="tPM_BD">BD:</label>
                                    <asp:TextBox step="any" ID="txtPM_BD" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="PM_BD"></asp:TextBox>
                                    <label class="form-label" for="tPM_PI">PI:</label>
                                    <asp:TextBox step="any" ID="txtPM_PI" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="PM_PI"></asp:TextBox>
                                    <label class="form-label" for="tPM_PD">PD:</label>
                                    <asp:TextBox step="any" ID="txtPM_PD" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="PM_PD"></asp:TextBox>
                                    <label class="form-label" for="tPM_Tronco">Tronco</label>
                                    <asp:TextBox step="any" ID="txtPM_Tronco" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="PM_Tronco"></asp:TextBox>
                                </div>
                            </div>
                       
                            <div class="col-11 margen" style="width: 75%;">
                                <label class="form-label margen" for="tObserv">Observación:</label>
                                <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Observaciones"></asp:TextBox>
                            </div>
                      <div class="row">

                                <div class="col-form-label">
                                    <label class="form-label" for="tGEB">GEB:</label>
                                    <asp:TextBox TextMode="Number" onBlur="validarGET()" min="0" step="any" oninput="validity.valid||(value='');" ID="txtGEB" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="GEB" Enabled="True"></asp:TextBox>
                                </div>
                                <div class="col-1"></div>
                                <div class="col-form-label">
                                    <label class="form-label" for="DropTipoActividad">Tipo de actividad:</label>
                                    <asp:DropDownList runat="server" onclick="tipoAct()" onchange="validarGET()" TabIndex="14" ID="DropTipoActividad" CssClass="form-control" Font-Size="Small" Font-Bold="False" data-toggle="tooltip" title="TipoActividad">
                                        <asp:ListItem Selected="True" Value="1.2"> Cama-reposo </asp:ListItem>
                                        <asp:ListItem Value="1.3"> Muy sedentario </asp:ListItem>
                                        <asp:ListItem Value="1.4"> Sedentario </asp:ListItem>
                                        <asp:ListItem Value="1.5"> Ligera </asp:ListItem>
                                        <asp:ListItem Value="1.6"> Ligera moderada </asp:ListItem>
                                        <asp:ListItem Value="1.7"> Moderada </asp:ListItem>
                                        <asp:ListItem Value="1.8"> Pesado </asp:ListItem>
                                        <asp:ListItem Value="2.3"> Muy pesado </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-1"></div>
                                <div class="col-form-label">
                                    <label class="form-label" for="tGET">GET:</label>
                                    <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" ID="txtGET" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="GET"></asp:TextBox>
                                </div>

                            </div>
                     <br />
                        <table class="table">
                            <tr>
                                <th scope="col">Macronutrientes</th>
                                <th scope="col">%</th>
                                <th scope="col">Gramos</th>
                                <th scope="col">kcal</th>
                            </tr>
                            <tr>
                                <th scope="row">CHO</th>
                                <td>
                                    <asp:TextBox TextMode="Number" step="any" min="0" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="choPorc" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox TextMode="Number" step="any" min="0" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="choGram" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox TextMode="Number" step="any" min="0" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="choKcal" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th scope="row">Proteínas</th>
                                <td>
                                    <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="ProtPorc" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="ProtGram" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="protKcal" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th scope="row">Grasas</th>
                                <td>
                                    <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="GrasPorc" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="GrasGram" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="GrasKcal" runat="server"></asp:TextBox></td>
                            </tr>
                        </table>

                        <br />
                        <h5>Porciones: </h5>
                        <div style="width: 25%; float: left;">
                            <div class="col-11" style="width: 80%;">
                                <label class="form-label" for="tLeche">Leche:</label><asp:Label runat="server" ID="Leche" Font-Size="Medium"></asp:Label>
                                <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="txtPorcLeche" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-11" style="width: 80%;">
                                <label class="form-label" for="tCarnes">Carnes:</label><asp:Label runat="server" ID="Carnes" Font-Size="Medium"></asp:Label>
                                <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="txtPorcCarnes" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div style="width: 25%; float: left;">
                            <div class="col-11" style="width: 80%;">
                                <label class="form-label" for="tVegetales">Vegetales:</label><asp:Label runat="server" ID="PVegetales" Font-Size="Medium"></asp:Label>
                                <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="txtPorcVeget" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-11" style="width: 80%;">
                                <label class="form-label" for="tGrasas">Grasas:</label><asp:Label runat="server" ID="PGrasas" Font-Size="Medium"></asp:Label>
                                <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="txtPorcGrasas" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div style="width: 25%; float: left;">
                            <div class="col-11" style="width: 80%;">
                                <label class="form-label" for="tFruts">Frutas:</label><asp:Label runat="server" ID="PFrutas" Font-Size="Medium"></asp:Label>
                                <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="txtPorcFrutas" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-11" style="width: 80%;">
                                <label class="form-label" for="tAzucares">Azúcares:</label><asp:Label runat="server" ID="PAzucares" Font-Size="Medium"></asp:Label>
                                <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="txtPorcAzucar" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div style="width: 25%; float: left;">
                            <div class="col-11" style="width: 80%;">
                                <label class="form-label" for="tHarinas">Harinas:</label><asp:Label runat="server" ID="PHarinas" Font-Size="Medium"></asp:Label>
                                <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="txtPorcHarinas" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-11" style="width: 80%;">
                                <label class="form-label" for="tSuplem">Suplementos:</label><asp:Label runat="server" ID="PSuplemnt" Font-Size="Medium"></asp:Label>
                                <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="txtPorcSuplem" runat="server"></asp:TextBox>
                                <br />
                                <br />

                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                        <h5>Distribución de porciones entregadas:</h5>
                        <table class="table">
                            <tr>
                                <th scope="col">Tiempo de Comida</th>
                                <th scope="col">Hora</th>
                                <th scope="col">Descripción</th>
                            </tr>
                            <tr>
                                <td>Ayunas</td>
                                <td>
                                    <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="txtHoraAyunasA" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox CssClass="form-control" Font-Size="Small" ID="txtDescAyunasA" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Desayuno</td>
                                <td>
                                    <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="txtHoraDesayunoA" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox CssClass="form-control" Font-Size="Small" ID="txtDescDesayA" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Media Mañana</td>
                                <td>
                                    <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="txtHoraMediaMA" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox CssClass="form-control" Font-Size="Small" ID="txtDescMediaMA" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Almuerzo</td>
                                <td>
                                    <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="txtHoraAlmmuerzoA" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox CssClass="form-control" Font-Size="Small" ID="txtDescAlmuerzoA" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Media Tarde</td>
                                <td>
                                    <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="txtHoraTardeA" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox CssClass="form-control" Font-Size="Small" ID="txtDescTardeA" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Cena</td>
                                <td>
                                    <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="txtHoraCenaA" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox CssClass="form-control" Font-Size="Small" ID="txtDescCenaA" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Colación Nocturna</td>
                                <td>
                                    <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="txtHoraColacionA" runat="server"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox CssClass="form-control" Font-Size="Small" ID="txtDescColacionA" runat="server"></asp:TextBox></td>
                            </tr>
                        </table>
					     <br />
                        <br />
                        <br />
                    </div>
                    <%--tab Antrop--%>

                <%-- Seguimiento Semanal--%>
                 <div id="SS" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-SS">
               
                               <br />
                            <div class="row">
                                <div class="col-form-label-lg">
                                <asp:TextBox ID="FechSegSem" runat="server" placeholder="Fecha" Font-Size="Small" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col"></div>
                                <div class="col-form-label-lg">
                                <asp:TextBox ID="sPeso" runat="server" placeholder="Peso" Font-Size="Small" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col"></div>
                                <div class="col-form-label-lg">
                                <asp:DropDownList runat="server" ID="sOreja" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Oreja">
                                       <asp:ListItem Value="" Selected="False" Text="Oreja"></asp:ListItem>
									    <asp:ListItem Value="Derecha"> Derecha </asp:ListItem>
                                        <asp:ListItem Value="Izquierda"> Izquierda </asp:ListItem>
									</asp:DropDownList>
                                    
                                </div>
                                 <div class="col"></div>
                                <div class="col-form-label-lg">
                                    <asp:TextBox ID="sEjercicio" runat="server" placeholder="Ejercicio" Font-Size="Small" CssClass="form-control"></asp:TextBox>
                                </div>
                                 <div class="col"></div>
                                <div class="col-form-label-lg">
                                <asp:Button ID="btnAgreg" Text="Agregar" runat="server" OnClick="btnAgreg_Click" CssClass="btn btn-primary colorBoton" />
                                </div>
                            </div>
                            <br />
                            <%--<h6>Lista Seguimientos:</h6>--%>
                        
                     <table class="table">
                            <tr>
                                <th scope="col">Sesión</th>
                                <th scope="col">Fecha</th> 
                                <th scope="col">Peso</th>
                                <th scope="col">Oreja</th>
                                <th scope="col">Ejercicio</th>
                           </tr>
                            <asp:Literal ID="LitSeguimiento" runat="server"></asp:Literal>
                        </table>
					  
                        <br />
                        <br />
                    
                     
                        
                    </div>
                    <%--tab Seg Semanal--%>
       
                   <%-- Seguimiento Mensual--%>
                <div id="SM" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-SM">
                        <div style="text-align: right;">
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#Modal1">+</button>
                      </div>
                         
                     <table class="table">
                            <tr>
                                <th scope="col">#</th> 
                                <th scope="col">Fecha</th>
                                <th scope="col">Ver</th> 
                                <th scope="col">Modificar</th>
                           </tr>
                                <asp:Literal ID="SeguimMensual" runat="server"></asp:Literal>
                        </table>
                        <br />
      
              
                    <!-- Modal 1 -->
                    <div class="modal fade bd-example-modal-lg" id="Modal1" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                      <div class="modal-dialog modal-xl" role="document">
                        <div class="modal-content">
                          <div class="modal-header">
                            <h5 class="m-0 font-weight-bold text-primary">Nuevo Seguimiento Nutricional </h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                              <span aria-hidden="true">&times;</span>
                            </button>
                          </div>
                                    <div class="modal-body">
                                        <%-- modal body--%>
                              <div class="container">
                            <div class="col-form-label">
                                <button type="button" class="btn btn-secondary" data-toggle="modal" data-target="#Modal2">Ver Anterior</button>
                            </div>
                                 <div class="row">
                                       <div class="col-form-label">
                                            <label class="form-label" for="tejeSem">Días de ejercicio semanales: </label>
                                            <asp:TextBox runat="server" ID="SNDiasEjerSem" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Días de ejercicio semanal"></asp:TextBox>
                                       </div>
                                       <div class="col-1"></div>
                                        <div class="col-form-label">
                                            <label class="form-label" for="tejeSem">Comidas Extras: </label>
                                            <asp:TextBox runat="server" ID="SNComidasExtras" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Comidas Extras"></asp:TextBox>
                                       </div>
                                      <div class="col-1"></div>
                                       <div class="col-form-label">
                                            <label class="form-label" for="tejeSem">Niveles de Ansiedad semanal y tiempo de comida en donde lo siente : </label>
                                             <asp:TextBox runat="server" ID="SNNivAnsiedad" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Niveles de Ansiedad"></asp:TextBox>
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
                                                        <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="SNRecordAyunTime" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" Font-Size="Small" ID="SNRecAyunasDescr" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                       <td>Desayuno</td>
                                                    <td>
                                                        <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="SNRecordDesayunTime" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" Font-Size="Small" ID="SNRecordDesayunDescr" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                       <td>Media Mañana</td>
                                                    <td>
                                                        <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="SNRecordMedManTime" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" Font-Size="Small" ID="RecordMedManDescr" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                       <td>Almuerzo</td>
                                                    <td>
                                                        <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="SNRecordAlmTime" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" Font-Size="Small" ID="SNRecordAlmDescrip" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                       <td>Media Tarde</td>
                                                    <td>
                                                        <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="SNRecordMedTardeTime" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" Font-Size="Small" ID="SNRecordMedTardeDescr" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                       <td>Cena</td>
                                                    <td>
                                                        <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="SNRecordCenaTime" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" Font-Size="Small" ID="SNRecordCenaDescr" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                       <td>Colación Nocturna</td>
                                                    <td>
                                                        <asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="SNRecordColTime" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" Font-Size="Small" ID="SNRecordColDescr" runat="server"></asp:TextBox></td>
                                    </tr>
                                 </table>
                                   <br /> 
                                <button type="button" class="btn btn-secondary" data-toggle="modal" data-target="#Modal3">Ver Anterior</button>  
                                 <h5>Seguimiento de Antropometría</h5>     
                                <div class="row">
                                        <div class="col-form-label">
                                            <label class="form-label" for="tFecha">Fecha:</label>
                                            <asp:TextBox ID="SegAntFecha" runat="server" CssClass="form-control" Font-Size="Small" TextMode="Date" title="Fecha"></asp:TextBox>
                                            <label class="form-label" for="tEdad">Edad:</label>
                                            <asp:TextBox ID="SegAntEdad" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Edad"></asp:TextBox>
                                            <label class="form-label" for="tTalla">Talla: </label>
                                                    <asp:TextBox ID="SegAntTalla" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Talla"></asp:TextBox>
                                            <label class="form-label" for="tCM">CM:</label>
                                                    <asp:TextBox ID="SegAntCM" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="CM"></asp:TextBox>
                                            <label class="form-label" for="tPesoSegAnt">Peso:</label>
                                            <asp:TextBox ID="SegAntPeso" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Peso"></asp:TextBox>
                                            <label class="form-label" for="tImcSegAnt">IMC: </label>
                                                    <asp:TextBox ID="SegAntIMC" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="IMC"></asp:TextBox>
                                            <label class="form-label" for="tSegAntAgua">Agua: </label>
                                                    <asp:TextBox ID="SegAntAgua" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Agua"></asp:TextBox>
                                            <label class="form-label" for="tSegAntMasa">Masa Osea:</label>
                                                    <asp:TextBox ID="SegAntMasaOsea" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Masa Osea"></asp:TextBox>
                                          </div>
                                          <div class="col-1"></div>
                                        <div class="col-form-label">
                                            <label class="form-label" for="tEddMetab">Edad Metabólica:</label>
                                            <asp:TextBox ID="SegAntEdadMetabolica" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Edad Metabólica"></asp:TextBox>
                                            <label class="form-label" for="tGrasaAnalizador">Grasa % analizador:</label>
                                            <asp:TextBox ID="SegAntGrasaAnaliz" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Grasa % analizador"></asp:TextBox>
                                            <label class="form-label" for="tGrasBascu">% Grasa báscula: </label>
                                            <asp:TextBox ID="SegAntGrasBasc" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Grasa báscula"></asp:TextBox>
                                            <label class="form-label" for="tGB_BI">BI:</label>
                                            <asp:TextBox ID="SegAntGBBI" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Izquierda"></asp:TextBox>
                                            <label class="form-label" for="tGB_BD">BD:</label>
                                            <asp:TextBox ID="SegAntGBBD" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Derecho"></asp:TextBox>
                                            <label class="form-label" for="tGB_PI">PI:</label>
                                            <asp:TextBox ID="SegAntGBPI" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Pierna Izquierda"></asp:TextBox>
                                            <label class="form-label" for="tGB_PD">PD:</label>
                                            <asp:TextBox ID="SegAntGBPD" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Pierna Derecha"></asp:TextBox>
                                            <label class="form-label" for="tGB_Tronco">Tronco:</label>
                                            <asp:TextBox ID="SegAntGBTronco" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Tronco"></asp:TextBox>
                                            </div>    
                                  <div class="col-1"></div>
                                       <div class="col-form-label">
                                            <label class="form-label" for="tGrasVisceral">% Grasa Visceral:</label>
                                                    <asp:TextBox ID="SegAntGrVisceral" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Grasa visceral"></asp:TextBox>
                                             <label class="form-label" for="tPorcentMusculo">% Músculo:</label>
                                                    <asp:TextBox ID="SegAntPM" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="% Músculo"></asp:TextBox>
                                            <label class="form-label" for="tPM_BI">BI: </label>
                                            <asp:TextBox ID="SegAntPMBI" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Izquierdo"></asp:TextBox>
                                            <label class="form-label" for="tPM_BD">BD:</label>
                                                    <asp:TextBox ID="SegAntPMBD" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Derecho"></asp:TextBox>
                                            <label class="form-label" for="tPM_PI">PI:</label>
                                                    <asp:TextBox ID="SegAntPMPI" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Pierna Izquierda"></asp:TextBox>
                                            <label class="form-label" for="tPM_PD">PD:</label>
                                                    <asp:TextBox ID="SegAntPMPD" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Pierna Derecha"></asp:TextBox>
                                            <label class="form-label" for="tPM_Tronco">Tronco</label>
                                                    <asp:TextBox ID="SegAntPMTronco" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Tronco"></asp:TextBox>
                                       </div>
                                        <div class="col-1"></div>
                                        <div class="col-form-label">
                                             <label class="form-label" for="tCircunfCintura">Circunferencia cintura: </label>
                                                    <asp:TextBox ID="SegAntCircunfCint" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Circunferencia de la cintura"></asp:TextBox>
                                             <label class="form-label" for="tCadeSegAnt">Cadera:</label>
                                                    <asp:TextBox ID="SegAntCadera" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Cadera"></asp:TextBox>
                                            <label class="form-label" for="tMusloIzq">Muslo Izquierdo:</label>
                                                    <asp:TextBox ID="SegAntMusloIzq" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Muslo Izquierdo"></asp:TextBox>
                                           <label class="form-label" for="tMusloDer">Muslo Derecho:</label>
                                                    <asp:TextBox ID="SegAntMusloDer" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Muslo Derecho"></asp:TextBox>
                                            <label class="form-label" for="tBrazoIzq">Brazo Izquierdo:</label>
                                                    <asp:TextBox ID="SegAntBrazoIzq" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Izquierdo"></asp:TextBox>
                                           <label class="form-label" for="tBrazoDer">Brazo Derecho:</label>
                                                    <asp:TextBox ID="SegAntBrazoDer" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Derecho"></asp:TextBox>
                                           <label class="form-label" for="tPesoMeta">Peso Meta o Ideal:</label>
                                                    <asp:TextBox ID="SegAntPesoIdeal" runat="server" CssClass="form-control" Font-Size="Small" Type="Number" step="any" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Peso Meta o Ideal"></asp:TextBox>
                                        </div>
                                    </div>
                                  <div class="row">
                                       <div class="col-form-label">
                                            <label class="form-label" for="SNObserv">Observaciones: </label>
                                            <asp:TextBox runat="server" ID="SNObservacion" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Observaciones"></asp:TextBox>
                                       </div>
                                  </div>
                          </div>
                                    </div>
                                    <%--fin modal body--%>
                          <div class="modal-footer">
                                        <asp:Button runat="server" OnClick="BackButton_Click" CssClass="btn btn-secondary" data-dismiss="modal" Text="Cancelar" />
                                        <asp:Button runat="server" OnClick="GuardarSeguimNutri_Click" CssClass="btn btn-primary" Text="Guardar" />
                          </div>
                        </div>
                      </div>

                        </div>
                        <%-- Fin modal 1--%>


                      <!-- Modal 2 -->
                    <div id="Modal2" class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                      <div class="modal-dialog modal-lg" role="document">
                        <div class="modal-content">
                          <div class="modal-header">
                            <h5 class="m-0 font-weight-bold text-primary">Seguimiento Nutricional</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                              <span aria-hidden="true">&times;</span>
                            </button>
                          </div>
                                    <div class="modal-body">
                                        <%-- modal body--%>
                              <div class="container">
                                 <div class="row">
                                       <div class="col-form-label">
                                            <label class="form-label" for="tejeSem">Días de ejercicio semanales: </label>
                                            <asp:TextBox runat="server" ID="AntDiasEjer" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Días de ejercicio semanal" Enabled="false"></asp:TextBox>
                                       </div>
                                       <div class="col-1"></div>
                                        <div class="col-form-label">
                                            <label class="form-label" for="tejeSem">Comidas Extras: </label>
                                            <asp:TextBox runat="server" ID="AntComExtra" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Comidas Extras" Enabled="false"></asp:TextBox>
                                       </div>
                                      <div class="col-1"></div>
                                       <div class="col-form-label">
                                            <label class="form-label" for="tejeSem">Niveles de Ansiedad semanal y tiempo de comida en donde lo siente : </label>
                                             <asp:TextBox runat="server" ID="AntNAnsied" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Niveles de Ansiedad" Enabled="false"></asp:TextBox>
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
                                                        <asp:TextBox TextMode="Time" Enabled="false" CssClass="form-control" Font-Size="Small" ID="AntAyunHora" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" Enabled="false" Font-Size="Small" ID="AntAyunDescr" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                       <td>Desayuno</td>
                                                    <td>
                                                        <asp:TextBox TextMode="Time" Enabled="false" CssClass="form-control" Font-Size="Small" ID="AntDesHora" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" Enabled="false" Font-Size="Small" ID="AntDesDescrp" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                       <td>Media Mañana</td>
                                                    <td>
                                                        <asp:TextBox TextMode="Time" Enabled="false" CssClass="form-control" Font-Size="Small" ID="AntMedManHora" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" Enabled="false" Font-Size="Small" ID="AntMedManDesc" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                       <td>Almuerzo</td>
                                                    <td>
                                                        <asp:TextBox TextMode="Time" Enabled="false" CssClass="form-control" Font-Size="Small" ID="AntAlmHora" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" Enabled="false" Font-Size="Small" ID="AntAlmDesc" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                       <td>Media Tarde</td>
                                                    <td>
                                                        <asp:TextBox TextMode="Time" Enabled="false" CssClass="form-control" Font-Size="Small" ID="AntMedTarHora" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" Enabled="false" Font-Size="Small" ID="AntMedTarDesc" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                       <td>Cena</td>
                                                    <td>
                                                        <asp:TextBox TextMode="Time" Enabled="false" CssClass="form-control" Font-Size="Small" ID="AntCenaHora" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" Enabled="false" Font-Size="Small" ID="AntCenaDesc" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                       <td>Colación Nocturna</td>
                                                    <td>
                                                        <asp:TextBox TextMode="Time" Enabled="false" CssClass="form-control" Font-Size="Small" ID="AntColNocHora" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" Enabled="false" Font-Size="Small" ID="AntColNocDesc" runat="server"></asp:TextBox></td>
                                    </tr>
                                 </table>
                                   <br /> 
                                 </div>
                                    </div>
                                    <%--fin modal body--%>
                          <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal" >Atrás</button>
                          </div>
                        </div>
                      </div>

                        </div>
                        <%-- Fin modal 2--%>


                     <!-- Modal 3 -->
                    <div class="modal fade bd-example-modal-lg" id="Modal3" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                      <div class="modal-dialog modal-xl" role="document">
                        <div class="modal-content">
                          <div class="modal-header">
                            <h5 class="m-0 font-weight-bold text-primary">Seguimiento Nutricional Antropometría </h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                              <span aria-hidden="true">&times;</span>
                            </button>
                          </div>
                                    <div class="modal-body">
                                        <%-- modal body--%>
                              <div class="container"> 
                                 <h5>Seguimiento de Antropometría</h5>     
                                <div class="row">
                                        <div class="col-form-label">
                                            <label class="form-label" for="tFecha">Fecha:</label>
                                            <asp:TextBox ID="AntSAFech" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" TextMode="Date" title="Fecha"></asp:TextBox>
                                            <label class="form-label" for="tEdad">Edad:</label>
                                            <asp:TextBox ID="AntSAEdad" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Edad"></asp:TextBox>
                                            <label class="form-label" for="tTalla">Talla: </label>
                                            <asp:TextBox ID="AntSATalla" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Talla"></asp:TextBox>
                                            <label class="form-label" for="tCM">CM:</label>
                                            <asp:TextBox ID="AntSACM" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="CM"></asp:TextBox>
                                            <label class="form-label" for="tPesoSegAnt">Peso:</label>
                                            <asp:TextBox ID="AntSAPeso" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Peso"></asp:TextBox>
                                            <label class="form-label" for="tImcSegAnt">IMC: </label>
                                            <asp:TextBox ID="AntSAIMC" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="IMC"></asp:TextBox>
                                            <label class="form-label" for="tSegAntAgua">Agua: </label>
                                            <asp:TextBox ID="AntSAAgua" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Agua"></asp:TextBox>
                                            <label class="form-label" for="tSegAntMasa">Masa Osea:</label>
                                            <asp:TextBox ID="AntSAMasaOsea" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Masa Osea"></asp:TextBox>
                                          </div>
                                          <div class="col-1"></div>
                                        <div class="col-form-label">
                                            <label class="form-label" for="tEddMetab">Edad Metabólica:</label>
                                            <asp:TextBox ID="AntSAEddMet" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Edad Metabólica"></asp:TextBox>
                                            <label class="form-label" for="tGrasaAnalizador">Grasa % analizador:</label>
                                            <asp:TextBox ID="AntSAGrAnaliz" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Grasa % analizador"></asp:TextBox>
                                            <label class="form-label" for="tGrasBascu">% Grasa báscula: </label>
                                            <asp:TextBox ID="AntSAGrBasc" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Grasa báscula"></asp:TextBox>
                                            <label class="form-label" for="tGB_BI">BI:</label>
                                            <asp:TextBox ID="AntSAGBBI" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Izquierda"></asp:TextBox>
                                            <label class="form-label" for="tGB_BD">BD:</label>
                                            <asp:TextBox ID="AntSAGBBD" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Derecho"></asp:TextBox>
                                            <label class="form-label" for="tGB_PI">PI:</label>
                                            <asp:TextBox ID="AntSAGBPI" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Pierna Izquierda"></asp:TextBox>
                                            <label class="form-label" for="tGB_PD">PD:</label>
                                            <asp:TextBox ID="AntSAGBPD" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Pierna Derecha"></asp:TextBox>
                                            <label class="form-label" for="tGB_Tronco">Tronco:</label>
                                            <asp:TextBox ID="AntSAGBTronco" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Tronco"></asp:TextBox>
                                            </div>    
                                  <div class="col-1"></div>
                                       <div class="col-form-label">
                                            <label class="form-label" for="tGrasVisceral">% Grasa Visceral:</label>
                                            <asp:TextBox ID="AntSAGrVisc" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Grasa visceral"></asp:TextBox>
                                            <label class="form-label" for="tPorcentMusculo">% Músculo:</label>
                                            <asp:TextBox ID="AntSAPorMusc" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="% Músculo"></asp:TextBox>
                                            <label class="form-label" for="tPM_BI">BI: </label>
                                            <asp:TextBox ID="AntSAPMBI" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Izquierdo"></asp:TextBox>
                                            <label class="form-label" for="tPM_BD">BD:</label>
                                            <asp:TextBox ID="AntSAPMBD" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Derecho"></asp:TextBox>
                                            <label class="form-label" for="tPM_PI">PI:</label>
                                            <asp:TextBox ID="AntSAPMPI" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Pierna Izquierda"></asp:TextBox>
                                            <label class="form-label" for="tPM_PD">PD:</label>
                                            <asp:TextBox ID="AntSAPMPD" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Pierna Derecha"></asp:TextBox>
                                            <label class="form-label" for="tPM_Tronco">Tronco</label>
                                            <asp:TextBox ID="AntSAPMTronco" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Tronco"></asp:TextBox>         
                                       </div>
                                        <div class="col-1"></div>
                                        <div class="col-form-label">
                                             <label class="form-label" for="tCircunfCintura">Circunferencia cintura: </label>
                                            <asp:TextBox ID="AntSACircunfCint" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Circunferencia de la cintura"></asp:TextBox>
                                             <label class="form-label" for="tCadeSegAnt">Cadera:</label>
                                            <asp:TextBox ID="AntSACadera" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Cadera"></asp:TextBox>
                                            <label class="form-label" for="tMusloIzq">Muslo Izquierdo:</label>
                                            <asp:TextBox ID="AntSAMusIza" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Muslo Izquierdo"></asp:TextBox>
                                           <label class="form-label" for="tMusloDer">Muslo Derecho:</label>
                                            <asp:TextBox ID="AntSAMusDer" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Muslo Derecho"></asp:TextBox>
                                            <label class="form-label" for="tBrazoIzq">Brazo Izquierdo:</label>
                                            <asp:TextBox ID="AntSABrazIzq" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Izquierdo"></asp:TextBox>
                                           <label class="form-label" for="tBrazoDer">Brazo Derecho:</label>
                                            <asp:TextBox ID="AntSABrazDer" runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Derecho"></asp:TextBox>
                                           <label class="form-label" for="tPesoMeta">Peso Meta o Ideal:</label>
                                            <asp:TextBox ID="AntSAPesoMet"  runat="server" Enabled="false" CssClass="form-control" Font-Size="Small" Type="Number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Peso Meta o Ideal"></asp:TextBox>
                                        </div>
                                    </div>
                                  <div class="row">
                                       <div class="col-form-label">
                                            <label class="form-label" for="SNObserv">Observaciones: </label>
                                            <asp:TextBox runat="server" Enabled="false" ID="AntSNObserv" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Observaciones"></asp:TextBox>
                                       </div>
                                  </div>
                          </div>
                                    </div>
                                    <%--fin modal body--%>

                          <div class="modal-footer">
                             <button type="button" class="btn btn-secondary" data-dismiss="modal">Atrás</button>
                          </div>
                        </div>
                      </div>

                        </div>
                        <%-- Fin modal 3--%>



          </div>  <%--fin seguimiento mensual--%>
                 </div>   <%--fin del tab-content--%>
              </div>  <%-- fin del nav--%>



     <div class="footer navbar-light bg-white shadow">

		 <asp:Button  CssClass="boton btn btn-primary" ID="btnGeneraPDF" runat="server" Text="Generar reporte" OnClick="btnGeneraPDF_Click" Width="11%"/>
	     <asp:Button ID="btnModificar" CssClass="boton btn btn-primary" runat="server" Text="Guardar" OnClick="Modificar_Click" Width="11%" />
         <asp:Button ID="btnAtras" CssClass="boton2 btn btn-primary" runat="server" Text="Atrás" OnClick="BackButton_Click" Width="11%" />
        
         <br />  
	</div>

        </div>
        <%--div container--%>
   </form>
    <script type="text/javascript">
        function Modificar_btn(id) {
           $.ajax({
                type: "POST",
                url: '/Cliente.aspx/Modif_Click',
                data: '{idSeg:' + id + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function () {
                    location.href = "ModificarSeguimiento.aspx";
                },
                error: function () {
                    alert("No funciona");
                }
           });
       }
   </script>
  
   
   <script>
       function mensajeError(tipo, titulo, mensaje) {
                        Swal.fire({
                            type: tipo,
                            title: titulo,
                            text: mensaje
                        })
       }

        function tipoAct() {
            var t = document.getElementById('ContentPlaceHolder1_DropTipoActividad');
            var Cama_reposo_H = 1.2;
            var Muy_sedentario_H = 1.3;
            var Sedentario_H = 1.4;
            var Ligera_H = 1.5;
            var Ligera_moderada_H = 1.7;
            var Moderada_H = 1.8;
            var Pesado_H = 2.1;
            var Muy_pesado_H = 2.3;
            var Cama_reposo_M = 1.2;
            var Muy_sedentario_M = 1.3;
            var Sedentario_M = 1.4;
            var Ligera_M = 1.5;
            var Ligera_moderada_M = 1.6;
            var Moderada_M = 1.7;
            var Pesado_M = 1.8;
            var Muy_pesado_M = 2.3;
            var sexo = document.getElementById('ContentPlaceHolder1_dropSexo').value;
            if (sexo == "M") {
                document.getElementById(t.id).options[0].value = Cama_reposo_H;
                document.getElementById(t.id).options[1].value = Muy_sedentario_H;
                document.getElementById(t.id).options[2].value = Sedentario_H;
                document.getElementById(t.id).options[3].value = Ligera_H;
                document.getElementById(t.id).options[4].value = Ligera_moderada_H;
                document.getElementById(t.id).options[5].value = Moderada_H;
                document.getElementById(t.id).options[6].value = Pesado_H;
                document.getElementById(t.id).options[7].value = Muy_pesado_H;
            } else {
                document.getElementById(t.id).options[0].value = Cama_reposo_M;
                document.getElementById(t.id).options[1].value = Muy_sedentario_M;
                document.getElementById(t.id).options[2].value = Sedentario_M;
                document.getElementById(t.id).options[3].value = Ligera_M;
                document.getElementById(t.id).options[4].value = Ligera_moderada_M;
                document.getElementById(t.id).options[5].value = Moderada_M;
                document.getElementById(t.id).options[6].value = Pesado_M;
                document.getElementById(t.id).options[7].value = Muy_pesado_M;
            }


       }

   </script>
   <script>
        function VerSeg(id) {
           $.ajax({
                type: "POST",
                url: '/Cliente.aspx/Ver_Click',
                data: '{idS:' + id + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function () {
                    location.href = "VerSeguimiento.aspx";
                },
                error: function () {
                    alert("No funciona");
                }
           });
        }
    </script>
  
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
