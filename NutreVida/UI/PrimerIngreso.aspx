<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="PrimerIngreso.aspx.cs" Inherits="UI.PrimerIngreso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<form id="form3" runat="server">
		<div class="container">
			<h3>Complete la información del cliente</h3>
			<br />
			  <div class="col-11" style="width:100%; float:left;">
				 <nav>
                  <div class="nav nav-tabs" id="nav-tab" role="tablist">
					  <a class="nav-item nav-link active" id="nav-DP" data-toggle="tab" href="#DP" role="tab" aria-controls="nav-home" aria-selected="true">Datos Personales</a>
                    <a class="nav-item nav-link" id="nav-HM" data-toggle="tab" href="#HM" role="tab" aria-controls="nav-contact" aria-selected="false">Historial Médico</a>
                    <a class="nav-item nav-link" id="nav-HA" data-toggle="tab" href="#HA" role="tab" aria-controls="nav-contact" aria-selected="false">Hábitos Alimentarios</a>
                    <a class="nav-item nav-link" id="nav-Ant" data-toggle="tab" href="#Ant" role="tab" aria-controls="nav-contact" aria-selected="false">Antropometría</a>
              </div>
                </nav>
				<div class="tab-content" id="nav-tabContent">
                      
						<%--    Datos Personales --%>
					<div id="DP" class="tab-pane fade show active" role="tabpanel" aria-labelledby="nav-DP">
						<br />
						<div>
							<div class="col-11" style="width: 50%; float: left;">
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tCedula">Cédula:</label><asp:Label runat="server" ID="Label2" Font-Size="Medium"></asp:Label>
									<asp:TextBox ID="txtCed" runat="server"></asp:TextBox>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tnombre">Nombre:</label><asp:Label runat="server" ID="Label3" Font-Size="Medium"></asp:Label>
									<asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
								</div>

								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tTel">Teléfono:</label><asp:Label runat="server" ID="Label5" Font-Size="Medium"></asp:Label>
									<asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tEmail">Email:</label><asp:Label runat="server" ID="Label10" Font-Size="Medium"></asp:Label>
									<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
								</div>
								<br />
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tSex">Sexo:</label>
									<asp:DropDownList runat="server" ID="dropSexo">
										<asp:ListItem Selected="True" Value="F"> F </asp:ListItem>
										<asp:ListItem Value="M"> M </asp:ListItem>
									</asp:DropDownList>
								</div>
							</div>
							<div style="width: 50%; float: left;">
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tResid">Residencia</label><asp:Label runat="server" ID="Label9" Font-Size="Medium"></asp:Label>
									<asp:TextBox ID="txtResid" runat="server"></asp:TextBox>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tOcup">Ocupación:</label><asp:Label runat="server" ID="Label7" Font-Size="Medium"></asp:Label>
									<asp:TextBox ID="txtOcup" runat="server"></asp:TextBox>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tFechN">Fecha de Nacimiento:</label><asp:Label runat="server" ID="Label4" Font-Size="Medium"></asp:Label>
									<input id="iFechaNac" type="date" />
								</div>
								<br />
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tWhats">Utiliza whatsapp:</label>
									<asp:DropDownList runat="server" ID="dropWhats">
										<asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
										<asp:ListItem Value="No"> No </asp:ListItem>
									</asp:DropDownList>
								</div>
								<br />
								<br />
							</div>
						</div>
					</div>


					<%--    Historial Medico--%>
					<div id="HM" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-HM">
						<br />
						<div class="col-11" style="width: 100%;">
							<label class="form-label" for="tAntFam">Antecedentes Familiares:</label><asp:Label runat="server" ID="AntecedF" Font-Size="Medium"></asp:Label>
							<br />
							<asp:TextBox Width="700px" ID="txtAntec" runat="server"></asp:TextBox>
						</div>
						<div class="col-11" style="width: 100%;">
							<label class="form-label" for="tPat">Patologías que padece:</label><asp:Label runat="server" ID="Patolg" Font-Size="Medium"></asp:Label>
							<br />
							<asp:TextBox Width="700px" ID="txtPatol" runat="server"></asp:TextBox>
						</div>
						<br />
						<h5>Frecuencia de consumo de:</h5>

						<div class="col-11" style="width: 50%;">
							<label class="form-label" for="tLic">Licor:</label>
							<br />
							<asp:TextBox ID="txtFrecLicor" runat="server"></asp:TextBox>
						</div>
						<div class="col-11" style="width: 50%;">
							<label class="form-label" for="tLic">Fumado:</label>
							<br />
							<asp:TextBox ID="txtFrecFuma" runat="server"></asp:TextBox>
						</div>
						<br />
						<h5>Medicamentos o suplementos que consume:</h5>
						<div class="col-11" style="width: 100%;">
							<label class="form-label" for="tPat">Medicamento:</label><asp:Label runat="server" ID="Label6" Font-Size="Medium"></asp:Label>
							<br />
							<asp:TextBox ID="txtMed" runat="server"></asp:TextBox>
						</div>
						<div class="col-11" style="width: 100%;">
							<label class="form-label" for="tPat">Motivo:</label><asp:Label runat="server" ID="Label8" Font-Size="Medium"></asp:Label>
							<br />
							<asp:TextBox ID="txtMotiv" runat="server"></asp:TextBox>
						</div>
						<div class="col-11" style="width: 100%;">
							<label class="form-label" for="tPat">Frecuencia:</label><asp:Label runat="server" ID="Label11" Font-Size="Medium"></asp:Label>
							<br />
							<asp:TextBox ID="txtFrecMed" runat="server"></asp:TextBox>
						</div>
						<div class="col-11" style="width: 100%;">
							<label class="form-label" for="tPat">Dosis:</label><asp:Label runat="server" ID="Label12" Font-Size="Medium"></asp:Label>
							<br />
							<asp:TextBox ID="txtDosis" runat="server"></asp:TextBox>
						</div>
						<br />
						<div class="col-11" style="width: 100%;">
							<label class="form-label" for="tFechExm">Fecha de últimos examenes de sangre o revisión médica:</label><asp:Label runat="server" ID="FechRevMed" Font-Size="Medium"></asp:Label>
						<input id="fechaExam" type="date" />
						</div>
						<br /><br /><br />
					</div>
					<%--tab hist medico--%>

					<%--   Habitos alimentarios--%>
					<div id="HA" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-HA">
						<br />
						<div class="col-11" style="width: 50%; float: left;">
						<div class="col-11" style="width: 100%;">
							<label class="form-label" for="tComD">¿Cuántas veces come al día? </label>
							<br />
							<asp:TextBox id="numeroComidas" runat="server" type="number" />
						</div>
						<div class="col-11" style="width: 100%;">
							<label class="form-label" for="tComeHoraDia">¿Acostumbra a comer a las horas al día? </label>
							<br />
							<asp:DropDownList runat="server" ID="ComeHoras">
										<asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
										<asp:ListItem Value="No"> No </asp:ListItem>
									</asp:DropDownList>
						</div>
						<div class="col-11" style="width: 100%;">
							<label class="form-label" for="tComeExprss">¿Cuántas veces a la semana come fuera o pide un express? </label>
							<br />
							<asp:TextBox ID="txtEspres" runat="server"></asp:TextBox>
						</div>
						<div class="col-11" style="width: 100%;">
							<label class="form-label" for="tGenerComeAfuera">¿Generalmente que come fuera de la casa?</label>
							<br />
							<asp:TextBox ID="txtQueComeFuera" runat="server"></asp:TextBox>
						</div>
						<div class="col-11" style="width: 100%;">
							<label class="form-label" for="tAzucarB">¿Cuánta azúcar le agrega a las bebidas?</label>
							<br />
							<asp:TextBox ID="cantAzucar" runat="server"></asp:TextBox>
						</div>
						<div class="col-11" style="width: 100%;">
							<label class="form-label" for="tAzucarB">¿Los alimentos que cocina los elabora generalmente? </label>
							<br />
							<asp:DropDownList runat="server" ID="dropCocinaCon">
										<asp:ListItem Selected="True" Value="aceite">Aceite</asp:ListItem>
										<asp:ListItem Value="horneado"> Horneado </asp:ListItem>
								<asp:ListItem Value="hervido"> Hervido </asp:ListItem>
								<asp:ListItem Value="micro"> Microondas </asp:ListItem>
									</asp:DropDownList>
						</div>
						<div class="col-11" style="width: 100%;">
							<label class="form-label" for="tAguaDia">¿Cuántos vasos de agua toma al día? </label>
							<br />
							<asp:TextBox id="txtCuantaAgua" runat="server" type="number" />
						</div>
						<div class="col-11" style="width: 100%;">
							<label class="form-label" for="tAder">¿Agrega salsa tomate, mayonesa, mantequilla o natilla a la comida? </label>
							<br />
							<asp:TextBox ID="txtAderezo" runat="server"></asp:TextBox>
						</div>
						<br />
						</div>

						<div style="width: 50%; float: left;">
						<h5>Le gusta la mayoría de:</h5>
							<br />
							<asp:Label ID="lbFrutas" runat="server" Text="Frutas:"></asp:Label>
							<asp:DropDownList runat="server" ID="dropFrutas">
										<asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
										<asp:ListItem Value="No"> No </asp:ListItem>
									</asp:DropDownList>
							<br />
							<br />
							<asp:Label ID="lbVeget" runat="server" Text="Vegetales:"></asp:Label>
							<asp:DropDownList runat="server" ID="dropVeget">
										<asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
										<asp:ListItem Value="No"> No </asp:ListItem>
									</asp:DropDownList>
							<br />
							<br />
							<asp:Label ID="lbLeche" runat="server" Text="Leche:"></asp:Label>
							<asp:DropDownList runat="server" ID="dropLeche">
										<asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
										<asp:ListItem Value="No"> No </asp:ListItem>
									</asp:DropDownList>
							<br />
							<br />
							<asp:Label ID="lbHuevo" runat="server" Text="Huevo:"></asp:Label>
							<asp:DropDownList runat="server" ID="dropHuevo">
										<asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
										<asp:ListItem Value="No"> No </asp:ListItem>
									</asp:DropDownList>
							<br />
							<br />
							<asp:Label ID="lbYogurt" runat="server" Text="Yogurt:"></asp:Label>
							<asp:DropDownList runat="server" ID="dropYogurt">
										<asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
										<asp:ListItem Value="No"> No </asp:ListItem>
									</asp:DropDownList>
							<br />
							<br />
							<asp:Label ID="lbCarne" runat="server" Text="Carne:"></asp:Label>
							<asp:DropDownList runat="server" ID="dropCarne">
										<asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
										<asp:ListItem Value="No"> No </asp:ListItem>
									</asp:DropDownList>
							<br />
							<br />
							<asp:Label ID="lbQueso" runat="server" Text="Queso:"></asp:Label>
							<asp:DropDownList runat="server" ID="dropQueso">
										<asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
										<asp:ListItem Value="No"> No </asp:ListItem>
									</asp:DropDownList>
							<br />
							<br />
							<asp:Label ID="lbAguacate" runat="server" Text="Aguacate:"></asp:Label>
							<asp:DropDownList runat="server" ID="dropAguacate">
										<asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
										<asp:ListItem Value="No"> No </asp:ListItem>
									</asp:DropDownList>
							<br />
							<br />
							<asp:Label ID="lbSemillas" runat="server" Text="Semillas:"></asp:Label>
							<asp:DropDownList runat="server" ID="dropSemillas">
										<asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem>
										<asp:ListItem Value="No"> No </asp:ListItem>
									</asp:DropDownList>
							</div>
						<br /><br />
						<h5>Recordatorio de 24 Horas</h5>
						<table class="table">
							<tr>
								<th scope="col">Tiempo de Comida</th>
								<th scope="col">Hora</th>
								<th scope="col">Descripción</th>
							</tr>
							<tr>
								<td>Ayunas</td>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<td>Desayuno</td>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<td>Media Mañana</td>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<td>Almuerzo</td>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<td>Media Tarde</td>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<td>Cena</td>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<td>Colación Nocturna</td>
								<td></td>
								<td></td>
								<td></td>
							</tr>
						</table>
					</div>
					<%--tab hab aliment--%>

					<%--    Antropometria--%>
					<div id="Ant" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-Ant">
						<br />
						<div>
							<div class="col-11" style="width: 50%; float: left;">
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tEdad">Edad:</label><asp:Label runat="server" ID="AntrEdad" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tPesoActual">Peso Actual:</label><asp:Label runat="server" ID="PesoActual" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tPesoMaxTeoria">Peso máximo en teoría:</label><asp:Label runat="server" ID="PesoMaxTeoria" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tPesoIdeal">Peso meta o ideal: </label>
									<asp:Label runat="server" ID="PesoIdeal" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tEdadMetab">Edad metabólica: </label>
									<asp:Label runat="server" ID="EdadMetab" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tCintura">Cintura:</label><asp:Label runat="server" ID="Cintura" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tAbdm">Abdomen:</label><asp:Label runat="server" ID="Abdomen" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tCadera">Cadera:</label><asp:Label runat="server" ID="Cadera" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tMuslo">Muslo:</label><asp:Label runat="server" ID="Muslo" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tPMB">PMB: </label>
									<asp:Label runat="server" ID="PMB" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tCMB">CMB: </label>
									<asp:Label runat="server" ID="CMB" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tAgua">Agua: </label>
									<asp:Label runat="server" ID="Agua" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tComplexión">Complexión: </label>
									<asp:Label runat="server" ID="Complexión" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tMasaOsea">Masa ósea: </label>
									<asp:Label runat="server" ID="MasaOsea" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tTalla">Talla: </label>
									<asp:Label runat="server" ID="Talla" Font-Size="Medium"></asp:Label>
								</div>
							</div>

							<%--Columna #2--%>
							<div style="width: 50%; float: left;">
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tCircunfMun">Circunferencia muñeca: </label>
									<asp:Label runat="server" ID="CircunfMun" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tIMC">IMC:</label><asp:Label runat="server" ID="IMC" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tGrasaAnalizador">%Grasa analizador:</label><asp:Label runat="server" ID="GrasaAnalizador" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tGrasVisceral">% Grasa Visceral:</label><asp:Label runat="server" ID="GrasVisceral" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tGrasBascu">% Grasa báscula: </label>
									<asp:Label runat="server" ID="tGrasBascula" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tGB_BI">BI:</label><asp:Label runat="server" ID="GB_BI" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tGB_BD">BD:</label><asp:Label runat="server" ID="GB_BD" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tGB_PI">PI:</label><asp:Label runat="server" ID="GB_PI" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tGB_PD">PD:</label><asp:Label runat="server" ID="GB_PD" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tGB_Tronco">Tronco:</label><asp:Label runat="server" ID="GB_Tronco" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tPorcentMusculo">% Músculo:</label><asp:Label runat="server" ID="PorcentMusculo" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tPM_BI">BI: </label>
									<asp:Label runat="server" ID="PM_BI" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tPM_BD">BD:</label><asp:Label runat="server" ID="PM_BD" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tPM_PI">PI:</label><asp:Label runat="server" ID="PM_PI" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tPM_PD">PD:</label><asp:Label runat="server" ID="PM_PD" Font-Size="Medium"></asp:Label>
								</div>
								<div class="col-11" style="width: 50%;">
									<label class="form-label" for="tPM_Tronco">Tronco</label><asp:Label runat="server" ID="PM_Tronco" Font-Size="Medium"></asp:Label>
								</div>

							</div>
							<%--Fin columna 2   --%>
						</div>
						<div class="col-11" style="width: 100%; float: left;">
							<label class="form-label" for="tObserv">Observación:</label><asp:Label runat="server" ID="Observacion" Font-Size="Medium"></asp:Label>
						</div>
						<br />
						<div class="col-11" style="width: 100%; float: left;">
							<div class="col-11" style="width: 100%;">
								<label class="form-label" for="tGEB">GEB:</label>
								<asp:Label runat="server" ID="GEB" Font-Size="Medium"></asp:Label>
							</div>
							<div class="col-11" style="width: 100%;">
								<label class="form-label" for="tGET">GET:</label>
								<asp:Label runat="server" ID="GET" Font-Size="Medium"></asp:Label>
							</div>
						</div>
						<table class="table">
							<tr>
								<th scope="col">Macronutrientes</th>
								<th scope="col">%</th>
								<th scope="col">Gramos</th>
								<th scope="col">kcal</th>
							</tr>
							<tr>
								<th scope="row">CHO</th>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<th scope="row">Proteínas</th>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<th scope="row">Grasas</th>
								<td></td>
								<td></td>
								<td></td>
							</tr>
						</table>
						<br />
						<h5>Porciones: </h5>
						<div style="width: 25%; float: left;">
							<div class="col-11" style="width: 25%;">
								<label class="form-label" for="tLeche">Leche:</label><asp:Label runat="server" ID="Leche" Font-Size="Medium"></asp:Label>
							</div>
							<div class="col-11" style="width: 25%;">
								<label class="form-label" for="tCarnes">Carnes:</label><asp:Label runat="server" ID="Carnes" Font-Size="Medium"></asp:Label>
							</div>
						</div>
						<div style="width: 25%; float: left;">
							<div class="col-11" style="width: 25%;">
								<label class="form-label" for="tVegetales">Vegetales:</label><asp:Label runat="server" ID="PVegetales" Font-Size="Medium"></asp:Label>
							</div>
							<div class="col-11" style="width: 25%;">
								<label class="form-label" for="tGrasas">Grasas:</label><asp:Label runat="server" ID="PGrasas" Font-Size="Medium"></asp:Label>
							</div>
						</div>
						<div style="width: 25%; float: left;">
							<div class="col-11" style="width: 25%;">
								<label class="form-label" for="tFruts">Frutas:</label><asp:Label runat="server" ID="PFrutas" Font-Size="Medium"></asp:Label>
							</div>
							<div class="col-11" style="width: 25%;">
								<label class="form-label" for="tAzucares">Azúcares:</label><asp:Label runat="server" ID="PAzucares" Font-Size="Medium"></asp:Label>
							</div>
						</div>
						<div style="width: 25%; float: left;">
							<div class="col-11" style="width: 25%;">
								<label class="form-label" for="tHarinas">Harinas:</label><asp:Label runat="server" ID="PHarinas" Font-Size="Medium"></asp:Label>
							</div>
							<div class="col-11" style="width: 25%;">
								<label class="form-label" for="tSuplem">Suplementos:</label><asp:Label runat="server" ID="PSuplemnt" Font-Size="Medium"></asp:Label>
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
								<th scope="row">Ayunas</th>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<th scope="row">Desayuno</th>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<th scope="row">Media Mañana</th>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<th scope="row">Almuerzo</th>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<th scope="row">Media Tarde</th>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<th scope="row">Cena</th>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<th scope="row">Colación Nocturna</th>
								<td></td>
								<td></td>
							</tr>
						</table>
					</div>
					<%--tab Antrop--%>
				</div>
				<%--div tab content--%>
			</div>
			<%--div del nav--%>
		</div>
		<%--div container--%>
	</form>

</asp:Content>
