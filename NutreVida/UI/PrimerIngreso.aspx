<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="PrimerIngreso.aspx.cs" Inherits="UI.PrimerIngreso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

	    <link href="css/sb-admin-2.min.css" rel="stylesheet">

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


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form3" runat="server">
        <div class="container">
             <h2>Información Personal</h2>
            <br />

            <%--<h5>Habitos Alimentarios:</h5>--%>

            <div class="row">
                <div class="col-form-label">
                    <label class="form-label" for="tCedula">Cédula:</label>
                    <asp:TextBox ID="txtCed" oninput="validity.valid||(value='');" runat="server" CssClass="form-control" Font-Size="Small" type="number" min="0" data-toggle="tooltip" title="Cedula de identidad" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valCed" runat="server" ControlToValidate="txtCed" ErrorMessage="Campo obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
					<br />
                    <label class="form-label" for="tOcup">Ocupación:</label>
                    <asp:TextBox ID="txtOcup" TabIndex="5" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Ocupación"></asp:TextBox>
                    <br />
                    <label class="form-label" for="tTel">Teléfono:</label>
                    <asp:TextBox ID="txtTel" runat="server" TabIndex="9" CssClass="form-control" Font-Size="Small" type="number" oninput="validity.valid||(value='');" min="0" data-toggle="tooltip" title="Número telefónico"></asp:TextBox>
					<asp:RequiredFieldValidator ID="valTelef" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtTel" Enabled="False" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <label class="form-label" for="Consult">Consultorio:</label>
                    <asp:DropDownList runat="server" TabIndex="13" ID="ConsultDropList" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Consultorio">
                        <asp:ListItem Selected="True" Value="San Ramón"> San Ramón </asp:ListItem>
                        <asp:ListItem Value="Alajuela"> Alajuela </asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-1"></div>
                <div class="col-form-label">
                    <label class="form-label" for="tnombre">Nombre:</label>
                    <asp:TextBox ID="txtNombre" TabIndex="2" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Nombre"></asp:TextBox>
					<asp:RequiredFieldValidator ID="valNombre" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtNombre" ForeColor="Red"></asp:RequiredFieldValidator>
					 <br />
					 <label class="form-label" for="tEmail">Email:</label>
                    <asp:TextBox ID="txtEmail" TabIndex="6" onkeyup="validarEmail(this)" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Correo electrónico"></asp:TextBox>
                    <br />

                    <label class="form-label" for="tWhats">Utiliza whatsapp:</label>
                    <asp:DropDownList runat="server" TabIndex="10" ID="dropWhats" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Usa whatsapp">
                        <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                        <asp:ListItem Selected="True" Value="No"> No </asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-1"></div>
                <div class="col-form-label">
                    <label class="form-label" for="tPrimerApellido">Primer apellido:</label>
                    <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Primer apellido" TabIndex="3"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valApe1" runat="server" ControlToValidate="txtPrimerApellido" ErrorMessage="Campo obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
					<br />
                    <label class="form-label" for="tEstadoCivil">Estado Civil:</label>
                    <asp:DropDownList runat="server" TabIndex="7" ID="dropEstadoCivil" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Estado civil">
                        <asp:ListItem Selected="True" Value="Soltero"> Soltero(a) </asp:ListItem>
                        <asp:ListItem Value="Casado"> Casado(a) </asp:ListItem>
                        <asp:ListItem Value="Divorciado"> Divorciado(a) </asp:ListItem>
                        <asp:ListItem Value="Otro"> Otro </asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <label class="form-label" for="tResid">Residencia:</label><asp:Label runat="server" ID="Label9" Font-Size="Medium"></asp:Label>
                    <asp:TextBox ID="txtResid" TabIndex="11" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Lugar de residencia"></asp:TextBox>
                </div>
                <div class="col-1"></div>
                <div class="col-form-label">
                    <label class="form-label" for="tSegundoApellido">Segundo apellido:</label>
                    <asp:TextBox ID="txtSegundoApellido" TabIndex="4" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Segundo apellido"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valApe2" runat="server" ErrorMessage="Campo obligatorio" ForeColor="Red" ControlToValidate="txtSegundoApellido"></asp:RequiredFieldValidator>
					<br />
                    <label class="form-label" for="tSex">Sexo:</label>
                    <asp:DropDownList runat="server" TabIndex="8" ID="dropSexo" CssClass="form-control" Font-Size="Small" Font-Bold="False" data-toggle="tooltip" title="Sexo">
                        <asp:ListItem Selected="True" Value="F"> Femenino </asp:ListItem>
                        <asp:ListItem Value="M"> Masculino </asp:ListItem>
                        <asp:ListItem Value="O"> Otro </asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <label class="form-label" for="iFechaNac">Fecha de Nacimiento:</label>
                    <asp:TextBox runat="server" TabIndex="12" ID="iFechaNac" TextMode="Date" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Fecha de nacimiento" OnTextChanged="iFechaNac_TextChanged"></asp:TextBox>
					<asp:RequiredFieldValidator ID="valFechaNac" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="iFechaNac" ForeColor="Red"></asp:RequiredFieldValidator>
					 <br />
                    <br />
                    <div class="col-11" style="width: 100%; float: right;">
                    </div>
                </div>
            </div>

            <br />
            <br />

            <div class="col-11" style="width: 100%; float: left;">
                <nav>
                    <div class="nav nav-tabs" id="nav-tab" role="tablist">
                        <a class="nav-item nav-link active" id="nav-HM" data-toggle="tab" href="#HM" role="tab" aria-controls="nav-home" aria-selected="true">Historial Médico</a>
                        <a class="nav-item nav-link" id="nav-HA" data-toggle="tab" href="#HA" role="tab" aria-controls="nav-contact" aria-selected="false">Hábitos Alimentarios</a>
                        <a class="nav-item nav-link" id="nav-Ant" data-toggle="tab" href="#Ant" role="tab" aria-controls="nav-contact" aria-selected="false">Antropometría</a>
                    </div>
                </nav>
                <div class="tab-content" id="nav-tabContent">




                    <%--<h5>Recordatorio de 24 Horas</h5>--%>
                    <div id="HM" class="tab-pane fade show active" role="tabpanel" aria-labelledby="nav-HM">

                        <br />
                        <div class="col-11 margen" style="width: 100%;">
                            <label class="form-label" for="tAntFam">Antecedentes Familiares:</label><asp:Label runat="server" ID="AntecedF" Font-Size="Medium"></asp:Label>
                            <asp:TextBox Width="700px" ID="txtAntec" TextMode="MultiLine" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Antecedentes Familiares"></asp:TextBox>
                        </div>
                        <div class="col-11 margen" style="width: 100%;">
                            <label class="form-label" for="tPat">Patologías que padece:</label><asp:Label runat="server" ID="Patolg" Font-Size="Medium"></asp:Label>
                            <asp:TextBox Width="700px" ID="txtPatol" TextMode="MultiLine" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Patologías"></asp:TextBox>
                        </div>

                        <div class="col-11 margen" style="width: 100%;">
                            <label class="form-label" for="tActividadFisica">Actividades físicas:</label><asp:Label runat="server" ID="Label14" Font-Size="Medium"></asp:Label>
                            <asp:TextBox Width="700px" ID="txtActividadFisica" TextMode="MultiLine" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Actividades físicas"></asp:TextBox>
                        </div>

                        <br />
                        <h5>Consumo de:</h5>

                        <div class="row">
                            <div class="col-form-label">
                                <label class="form-label" for="tLicor">Licor:</label>
                                <asp:DropDownList runat="server" ID="DropLicor" CssClass="form-control" Font-Size="Small" OnSelectedIndexChanged="DropLicor_SelectedIndexChanged" AutoPostBack="true" data-toggle="tooltip" title="Licor">
                                    <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Selected="True" Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                <label class="form-label" for="tFum">Fumado:</label>
                                <asp:DropDownList runat="server" ID="DropFuma" CssClass="form-control" Font-Size="Small" OnSelectedIndexChanged="DropFuma_SelectedIndexChanged" AutoPostBack="true" data-toggle="tooltip" title="Fumado">
                                    <asp:ListItem Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Selected="True" Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-1"></div>
                            <div class="col-form-label" style="width: 50%">

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

                                <asp:Button ID="btnAgreg" runat="server" Text="Agregar" CssClass=" btn btn-primary" OnClick="BtnAgreg_Click" />

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
                            <asp:Label runat="server" ID="FechRevMed" Font-Size="Medium"></asp:Label>
                            <input id="fechaExam" type="date" runat="server" />
                        </div>
                        <br />
                        <br />
                        <br />
                    </div>
					<%--tab hab aliment--%>
                    <%--    Antropometria--%>
                    <div id="HA" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-HA">
                        <br />

                        <div class="row">
                            <div class="col-form-label">
								<%--tab Antrop--%>
                                <label class="form-label" for="tComD">¿Cuántas veces come al día? </label>
                                <asp:TextBox ID="numeroComidas" runat="server" type="number" min="0" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Cantidad de comidas al día" />
                                <label class="form-label" for="tComeHoraDia">¿Acostumbra a comer a las horas al día? </label>
                                <asp:DropDownList runat="server" ID="ComeHoras" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="¿Come al día?">
                                    <asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
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
                                    <asp:ListItem Selected="True" Value="aceite">Aceite</asp:ListItem>
                                    <asp:ListItem Value="horneado"> Horneado </asp:ListItem>
                                    <asp:ListItem Value="hervido"> Hervido </asp:ListItem>
                                    <asp:ListItem Value="micro"> Microondas </asp:ListItem>
                                </asp:DropDownList>
                                <label class="form-label" for="tAguaDia">¿Cuántos vasos de agua toma al día? </label>
                                <asp:TextBox ID="txtCuantaAgua" runat="server" type="number" min="0" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Agua por día" />
                                <label class="form-label" for="tAder">¿Agrega salsa tomate, mayonesa, mantequilla o natilla a la comida? </label>
                                <asp:DropDownList runat="server" ID="dropAderezos" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Aderezos a la comida">
                                    <asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-1"></div>
                            <div class="col-form-label">
                                <h5>Le gusta la mayoría de:</h5>
                                <label class="form-label" for="lbFrutas">Frutas:</label>
                                <asp:DropDownList runat="server" ID="dropFrutas" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="frutas">
                                    <asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                <label class="form-label" for="lbVeget">Vegetales:</label>
                                <asp:DropDownList runat="server" ID="dropVeget" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Vegetales">
                                    <asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                <label class="form-label" for="lbLeche">Leche:</label>
                                <asp:DropDownList runat="server" ID="dropLeche" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Leche">
                                    <asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                <label class="form-label" for="lbHuevo">Huevo:</label>
                                <asp:DropDownList runat="server" ID="dropHuevo" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Huevo">
                                    <asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                <label class="form-label" for="lbYogurt">Yogurt:</label>
                                <asp:DropDownList runat="server" ID="dropYogurt" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Yogurt">
                                    <asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                <label class="form-label" for="lbCarne">Carne:</label>
                                <asp:DropDownList runat="server" ID="dropCarne" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Carne">
                                    <asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                <label class="form-label" for="lbQueso">Queso:</label>
                                <asp:DropDownList runat="server" ID="dropQueso" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Queso">
                                    <asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                <label class="form-label" for="lbAguacate">Aguacate:</label>
                                <asp:DropDownList runat="server" ID="dropAguacate" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Aguacate">
                                    <asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                                <label class="form-label" for="lbSemillas">Semillas:</label>
                                <asp:DropDownList runat="server" ID="dropSemillas" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Semillas">
                                    <asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>


                        <%--div tab content--%>
                        <br />
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

                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </div>
					<%--div del nav--%>
                    <%--  Funcion que permite mostrar mensajes al usuario--%>


                    <div id="Ant" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-Ant">
                        <br />
                        <div>
                            <div class="row">
                                <div class="col-form-label">
                                    <label class="form-label" for="tEdad">Edad:</label>
                                    <asp:TextBox step="any" ID="txtEdad" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Edad" Enabled="False"></asp:TextBox>
                                    <label class="form-label" for="tPesoActual">Peso Actual:</label>
                                    <asp:TextBox step="any" ID="txtPesoActual" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Peso actual"></asp:TextBox>
                                    <label class="form-label" for="tPesoMaxTeoria">Peso máximo en teoría:</label>
                                    <asp:TextBox step="any" ID="txtPesoMaxTeoria" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Peso Máximo en teoría"></asp:TextBox>
                                    <label class="form-label" for="tPesoIdeal">Peso meta o ideal: </label>
                                    <asp:TextBox step="any" ID="txtPesoIdeal" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Peso meta o ideal"></asp:TextBox>
                                    <label class="form-label" for="tEdadMetab">Edad metabólica: </label>
                                    <asp:TextBox step="any" ID="txtEdadMetabolica" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Edad metabólica" Enabled="False"></asp:TextBox>
                                    <label class="form-label" for="tCintura">Cintura:</label>
                                    <asp:TextBox step="any" ID="txtCintura" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Cintura"></asp:TextBox>
                                    <label class="form-label" for="tAbdm">Abdomen:</label>
                                    <asp:TextBox step="any" ID="txtAbdomen" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Abdomen"></asp:TextBox>
                                    <label class="form-label" for="tCadera">Cadera:</label>
                                    <asp:TextBox step="any" ID="txtCadera" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Cadera"></asp:TextBox>
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
                                    <label class="form-label" for="tTalla">Talla: </label>
                                    <asp:TextBox step="any" ID="txtTalla" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Talla"></asp:TextBox>
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
                                    <asp:TextBox step="any" ID="txtIMC" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="IMC"></asp:TextBox>
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
                                    <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" ID="txtGEB" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="GEB" Enabled="True"></asp:TextBox>
                                </div>
                                <div class="col-1"></div>
                                <div class="col-form-label">
                                    <label class="form-label" for="tGET">GET:</label>
                                    <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" ID="txtGET" runat="server" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="GET"></asp:TextBox>
                                </div>

                            </div>
                            <br />
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
                                        <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="choPorc" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="choGram" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="choKcal" runat="server"></asp:TextBox></td>
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
                                    <asp:TextBox TextMode="Number" min="0" step="any" oninput="validity.valid||(value='');" CssClass="form-control" Font-Size="Small" ID="txtPorcAzuca" runat="server"></asp:TextBox>
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
						<%--div container--%>
                    </div>
                    <%--div tab content--%>
                </div>
                <%--div del nav--%>



                <div class="footer navbar-light bg-white shadow">
                    <asp:Button ID="btnGuardar" CssClass="boton btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    <br />
                </div>

              <%--  Funcion que permite mostrar mensajes al usuario--%>
                <script>
                    function mensajeError(tipo, titulo, mensaje) {
                        Swal.fire({
                            type: tipo,
                            title: titulo,
                            text: mensaje
                        })
                    }
                </script>
            </div>
			</div>
            <%--div container--%>

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
			margin:5px;
			margin-right:55px;
			
		}

	</style>

    </form>

</asp:Content>
