<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="Cliente.aspx.cs" Inherits="UI.Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form3" runat="server">
         <div class="container">

             <h2>Información Personal</h2>
            <div>
                <div class="form-group"  style="width:50%; float:left;">
                    <div class="col-11" style="width:50%;">
                        <label class="col-xs-4 control-label" for="tCedula">Cédula:</label>    
                        <asp:TextBox runat="server" ID="ced1" Font-Size="X-Small" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-11" style="width:50%;">
                        <label class="col-xs-4 control-label" for="tnombre">Nombre</label> 
                        <asp:TextBox runat="server" ID="NombCli" Font-Size="X-Small" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-11" style="width:50%;">
                        <label class="col-xs-4 control-label" for="tFechN">Fecha de Nacimiento:</label>
                        <asp:TextBox runat="server" ID="FechNaCLi" Font-Size="X-Small" CssClass="form-control"></asp:TextBox>
                    </div>
                     <div class="col-11" style="width:50%;">
                        <label class="col-xs-4 control-label" for="tTel">Teléfono:</label>
                         <asp:TextBox runat="server" ID="Telefo" Font-Size="X-Small" CssClass="form-control"></asp:TextBox>
                    </div>
                     <div class ="col-11" style="width:50%;">
                        <label class="col-xs-4 control-label" for="tWhats">Utiliza whatsapp:</label>
                        <asp:TextBox runat="server" ID="WhatsappC" Font-Size="X-Small" CssClass="form-control"></asp:TextBox>
                    </div>
                     <div class="col-11" style="width:50%;">
                        <label class="col-xs-4 control-label" for="tOcup">Ocupación:</label>
                         <asp:Label runat="server" ID="Ocupac" Font-Size="X-Small" CssClass="form-control"></asp:Label>
                    </div>
                </div>
                
                <div class="form-group" style="width:50%; float:left;">
                    <div class="col-11" style="width:50%;">
                        <label class="col-xs-4 control-label" for="tSex">Sexo:</label>
                        <asp:TextBox runat="server" ID="Sex" Font-Size="X-Small" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-11" style="width:50%;">
                        <label class="col-xs-4 control-label" for="tEdad">Edad</label>
                        <asp:TextBox runat="server" ID="EdadC" Font-Size="X-Small" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-11" style="width:50%;">
                        <label class="col-xs-4 control-label" for="tResid">Residencia</label>
                        <asp:TextBox runat="server" ID="ResidenciaC" Font-Size="X-Small" CssClass="form-control"></asp:TextBox>
                    </div> 
                    <div class="col-11" style="width:50%;">
                        <label class="col-xs-4 control-label" for="tEmail">Email</label>
                        <asp:TextBox runat="server" ID="EmailC" Font-Size="X-Small" CssClass="form-control"></asp:TextBox>
                    </div>  
                    <div class="col-11" style="width:50%;">
                        <label class="col-xs-4 control-label" for="tFechIngr" >Fecha de Ingreso</label>
                        <asp:TextBox runat="server" ID="FechIngreso" Font-Size="X-Small" CssClass="form-control"></asp:TextBox>
                    </div>
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
                  <a class="nav-item nav-link" id="nav-SM" data-toggle="tab" href="#SM" role="tab" aria-controls="nav-contact" aria-selected="false">Seguimiento Mensual</a>
                  </div>
                </nav>
             <div class="tab-content" id="nav-tabContent">
                  <%--    Historial Medico--%>
                  <div id="HM" class="tab-pane fade show active" role="tabpanel" aria-labelledby="nav-HM">
                       <h5>Historial Médico</h5>
            <div class="col-11" style="width:100%;">
                <label class="form-label" for="tAntFam">Antecedentes Familiares:</label><asp:Label runat="server" ID="AntecedF" Font-Size="Medium"></asp:Label>
            </div>
            <div class="col-11" style="width:100%;">
                 <label class="form-label" for="tPat">Patologías que padece:</label><asp:Label runat="server" ID="Patolg" Font-Size="Medium"></asp:Label>
            </div>
                
            <h6>Consumo de:</h6> 
           
             <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tLic">Licor:     </label><asp:TextBox runat="server" ID="ConsLicC" Font-Size="Medium"></asp:TextBox>
                    <label class="form-label" for="tFrecLic">Frecuencia: </label><asp:TextBox runat="server" ID="FrecLicC" Font-Size="Medium"></asp:TextBox>
                </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tLic">Fuma:     </label><asp:Label runat="server" ID="fumad" Font-Size="Medium"></asp:Label>
                    <label class="form-label" for="tFrecFum">Frecuencia: </label><asp:Label runat="server" ID="FrecFuma" Font-Size="Medium"></asp:Label>
                </div>
             <h6>Medicamentos o suplementos que consume:</h6>   
           <table class="table">
               <tr>
                <th scope="col">Medicamento</th>
                <th scope="col">Motivo</th> 
                <th scope="col">Frecuencia</th>
                <th scope="col">Dosis</th>
               </tr>
              <tr>
                <td> </td>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
               <tr>
                 <td></td>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
               </table> 

             <div class="col-11" style="width:100%;">
                <label class="form-label" for="tFechExm"> Fecha de últimos examenes de sangre o revisión médica:</label><asp:Label runat="server" ID="FechRevMed" Font-Size="Medium"></asp:Label>
            </div>
                    </div> <%--tab hist medico--%>

                  <%--   Habitos alimentarios--%>
                 <div id="HA" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-HA">
                     <h5>Habitos Alimentarios</h5>
          <div class="col-11" style="width:100%;">
                 <label class="form-label" for="tComD">¿Cuántas veces come al día? </label>
                 <asp:Label runat="server" ID="ComeDiario" Font-Size="Medium"></asp:Label>
           </div>
           <div class="col-11" style="width:100%;">
                 <label class="form-label" for="tComeHoraDia">¿Acostumbra a comer a las horas al día? </label>
                 <asp:Label runat="server" ID="ComeHoraDia" Font-Size="Medium"></asp:Label>
           </div>
            <div class="col-11" style="width:100%;">
                 <label class="form-label" for="tComeExprss">¿Cuántas veces a la semana come fuera o pide un express? </label>
                 <asp:Label runat="server" ID="ComeExprss" Font-Size="Medium"></asp:Label>
           </div>
           <div class="col-11" style="width:100%;">
                <label class="form-label" for="tGenerComeAfuera">¿Generalmente que come fuera de la casa?</label>
                <asp:Label runat="server" ID="GenerComeAfuera" Font-Size="Medium"></asp:Label>
           </div>
            <div class="col-11" style="width:100%;">
                <label class="form-label" for="tAzucarB">¿Cuánta azúcar le agrega a las bebidas?</label>
                <asp:Label runat="server" ID="AzucarB" Font-Size="Medium"></asp:Label>
           </div>
            <div class="col-11" style="width:100%;">
                <label class="form-label" for="tAzucarB">¿Los alimentos que cocina los elabora generalmente? </label>
                <asp:Label runat="server" ID="Label1" Font-Size="Medium"></asp:Label>
           </div>
            <div class="col-11" style="width:100%;">
                <label class="form-label" for="tAguaDia">¿Cuántos vasos de agua toma al día? </label>
                <asp:Label runat="server" ID="AguaDia" Font-Size="Medium"></asp:Label>
           </div>
             <div class="col-11" style="width:100%;">
                <label class="form-label" for="tAder">¿Agrega salsa tomate, mayonesa, mantequilla o natilla a la comida? </label>
                <asp:Label runat="server" ID="Aderezos" Font-Size="Medium"></asp:Label>
           </div>
           <h6>Le gusta la mayoría de:</h6>
            <table class="table">
               <tr>
                   <th scope="row">Frutas:</th>
                   <th scope="row">Vegetales:</th>
                   <th scope="row">Leche:</th>
               </tr>
                <tr>
                   <th scope="row">Huevo:</th>
                   <th scope="row">Yogurt:</th>
                   <th scope="row">Carne:</th>
               </tr>
                <tr>
                   <th scope="row">Queso:</th>
                   <th scope="row">Aguacate:</th>
                   <th scope="row">Semillas:</th>
               </tr>
            </table>
            <h6>Recordatorio de 24 Horas</h6>
             <table class="table">
               <tr>
                <th scope="col">Tiempo de Comida</th>
                <th scope="col">Hora</th> 
                <th scope="col">Descripción</th>
               </tr>
              <tr>
                <td>Ayunas</td>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
              <tr>
                <td>Desayuno</td>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
                 <tr>
                <td>Media Mañana</td>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
                 <tr>
                <td>Almuerzo</td>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
                 <tr>
                <td>Media Tarde</td>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
                 <tr>
                <td>Cena</td>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
                 <tr>
                <td>Colación Nocturna</td>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
            </table>
                  </div> <%--tab hab aliment--%>

             <%--    Antropometria--%>
                 <div id="Ant" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-Ant">
                      <h5>Antropometría</h5>
           <div>
            <div class="col-11" style="width:50%; float:left;">
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tEdad">Edad:</label><asp:Label runat="server" ID="AntrEdad" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPesoActual">Peso Actual:</label><asp:Label runat="server" ID="PesoActual" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPesoMaxTeoria">Peso máximo en teoría:</label><asp:Label runat="server" ID="PesoMaxTeoria" Font-Size="Medium"></asp:Label>
                </div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPesoIdeal">Peso meta o ideal: </label><asp:Label runat="server" ID="PesoIdeal" Font-Size="Medium"></asp:Label>
                </div>
                 <div class ="col-11" style="width:50%;">
                    <label class="form-label" for="tEdadMetab">Edad metabólica: </label><asp:Label runat="server" ID="EdadMetab" Font-Size="Medium"></asp:Label>
                </div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tCintura">Cintura:</label><asp:Label runat="server" ID="Cintura" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tAbdm">Abdomen:</label><asp:Label runat="server" ID="Abdomen" Font-Size="Medium"></asp:Label>
                </div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tCadera">Cadera:</label><asp:Label runat="server" ID="Cadera" Font-Size="Medium"></asp:Label>
                </div> 
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tMuslo">Muslo:</label><asp:Label runat="server" ID="Muslo" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPMB">PMB: </label><asp:Label runat="server" ID="PMB" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tCMB">CMB: </label><asp:Label runat="server" ID="CMB" Font-Size="Medium"></asp:Label>
                </div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tAgua">Agua: </label><asp:Label runat="server" ID="Agua" Font-Size="Medium"></asp:Label>
                </div>
                 <div class ="col-11" style="width:50%;">
                    <label class="form-label" for="tComplexión">Complexión: </label><asp:Label runat="server" ID="Complexión" Font-Size="Medium"></asp:Label>
                </div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tMasaOsea">Masa ósea: </label><asp:Label runat="server" ID="MasaOsea" Font-Size="Medium"></asp:Label>
                </div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tTalla">Talla: </label><asp:Label runat="server" ID="Talla" Font-Size="Medium"></asp:Label>
                </div>                 
            </div>

               <%--Columna #2--%>
            <div style="width:50%; float:left;">
                <div class ="col-11" style="width:50%;">
                    <label class="form-label" for="tCircunfMun">Circunferencia muñeca: </label><asp:Label runat="server" ID="CircunfMun" Font-Size="Medium"></asp:Label>
                </div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tIMC">IMC:</label><asp:Label runat="server" ID="IMC" Font-Size="Medium"></asp:Label>
                </div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tGrasaAnalizador">%Grasa analizador:</label><asp:Label runat="server" ID="GrasaAnalizador" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tGrasVisceral"> % Grasa Visceral:</label><asp:Label runat="server" ID="GrasVisceral" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tGrasBascu">% Grasa báscula: </label><asp:Label runat="server" ID="tGrasBascula" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tGB_BI">BI:</label><asp:Label runat="server" ID="GB_BI" Font-Size="Medium"></asp:Label>
                </div> 
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tGB_BD">BD:</label><asp:Label runat="server" ID="GB_BD" Font-Size="Medium"></asp:Label>
                </div>  
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tGB_PI">PI:</label><asp:Label runat="server" ID="GB_PI" Font-Size="Medium"></asp:Label>
                </div>  
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tGB_PD">PD:</label><asp:Label runat="server" ID="GB_PD" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tGB_Tronco">Tronco:</label><asp:Label runat="server" ID="GB_Tronco" Font-Size="Medium"></asp:Label>
                </div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPorcentMusculo">% Músculo:</label><asp:Label runat="server" ID="PorcentMusculo" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPM_BI">BI: </label><asp:Label runat="server" ID="PM_BI" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPM_BD">BD:</label><asp:Label runat="server" ID="PM_BD" Font-Size="Medium"></asp:Label>
                </div>                 
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPM_PI">PI:</label><asp:Label runat="server" ID="PM_PI" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPM_PD">PD:</label><asp:Label runat="server" ID="PM_PD" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPM_Tronco">Tronco</label><asp:Label runat="server" ID="PM_Tronco" Font-Size="Medium"></asp:Label>
                </div> 
               
                </div> <%--Fin columna 2   --%>
            </div>
            <div class="col-11" style="width:100%; float:left;">
                <label class="form-label" for="tObserv">Observación:</label><asp:Label runat="server" ID="Observacion" Font-Size="Medium"></asp:Label>
            </div>
            <br />
            <div class="col-11" style="width:100%; float:left;">
             <div class="col-11" style="width:100%;">
                <label class="form-label" for="tGEB">GEB:</label>
                <asp:Label runat="server" ID="GEB" Font-Size="Medium"></asp:Label>
           </div>
            <div class="col-11" style="width:100%;">
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
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
              <tr>
                <th scope="row">Proteínas</th>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
                 <tr>
                 <th scope="row">Grasas</th>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
            </table>
            <h4>Porciones: </h4>
            <div style="width:25%; float:left;">
                <div class="col-11" style="width:25%;">
                    <label class="form-label" for="tLeche">Leche:</label><asp:Label runat="server" ID="Leche" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:25%;">
                    <label class="form-label" for="tCarnes">Carnes:</label><asp:Label runat="server" ID="Carnes" Font-Size="Medium"></asp:Label>
                </div>
            </div>
             <div style="width:25%; float:left;">
                 <div class="col-11" style="width:25%;">
                    <label class="form-label" for="tVegetales">Vegetales:</label><asp:Label runat="server" ID="PVegetales" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:25%;">
                    <label class="form-label" for="tGrasas">Grasas:</label><asp:Label runat="server" ID="PGrasas" Font-Size="Medium"></asp:Label>
                </div>
            </div>
             <div style="width:25%; float:left;">
                 <div class="col-11" style="width:25%;">
                    <label class="form-label" for="tFruts">Frutas:</label><asp:Label runat="server" ID="PFrutas" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:25%;">
                    <label class="form-label" for="tAzucares">Azúcares:</label><asp:Label runat="server" ID="PAzucares" Font-Size="Medium"></asp:Label>
                </div>
            </div>
             <div style="width:25%; float:left;">
                 <div class="col-11" style="width:25%;">
                    <label class="form-label" for="tHarinas">Harinas:</label><asp:Label runat="server" ID="PHarinas" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:25%;">
                    <label class="form-label" for="tSuplem">Suplementos:</label><asp:Label runat="server" ID="PSuplemnt" Font-Size="Medium"></asp:Label>
                </div>
            </div>
            <br />
            <h4>Distribución de porciones entregadas:</h4>
            <table class="table">
               <tr>
                    <th scope="col">Tiempo de Comida</th>
                    <th scope="col">Hora</th> 
                    <th scope="col">Descripción</th>
               </tr>
                <tr>
                    <th scope="row">Ayunas</th>
                    <td> </td> 
                    <td> </td>
              </tr>
                <tr>
                    <th scope="row">Desayuno</th>
                    <td> </td> 
                    <td> </td>
              </tr>
                <tr>
                    <th scope="row">Media Mañana</th>
                    <td> </td> 
                    <td> </td>
              </tr>
                <tr>
                    <th scope="row">Almuerzo</th>
                    <td> </td> 
                    <td> </td>
              </tr>
                <tr>
                    <th scope="row">Media Tarde</th>
                    <td> </td> 
                    <td> </td>
              </tr>
                <tr>
                    <th scope="row">Cena</th>
                    <td> </td> 
                    <td> </td>
              </tr>
                <tr>
                    <th scope="row">Colación Nocturna</th>
                    <td> </td> 
                    <td> </td>
              </tr>
            </table>
                  </div> <%--tab Antrop--%>

                <%-- Seguimiento Semanal--%>
                 <div id="SS" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-SS">
                      <div class="form-container">
                            <h5>Seguimiento de pesaje semanal:</h5>
                            
                            <div class="row">
                                <div class="col-form-label-lg">
                                    <asp:TextBox ID="sPeso" runat="server"  placeholder="Peso" Font-Size="Small" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col"></div>
                                <div class="col-form-label-lg">
                                   <asp:DropDownList runat="server" ID="sOreja" CssClass="form-control" Font-Size="Small">
										 <asp:ListItem Selected="True" Value="Derecha"> Derecha </asp:ListItem>
                                       <asp:ListItem Value="Izquierda"> Izquierda </asp:ListItem>
									</asp:DropDownList>
                                </div>
                                 <div class="col"></div>
                                <div class="col-form-label-lg">
                                    <asp:TextBox ID="sEjercicio" runat="server" placeholder="Ejercicio" Font-Size="Small" CssClass="form-control"></asp:TextBox>
                                </div>
                                 <div class="col"></div>
                                <div class="col-form-label-lg">
                                    <asp:Button ID="btnAgreg" Text="Agregar" runat="server"  OnClick="btnAgreg_Click"  CssClass="btn btn-primary colorBoton" />
                                </div>
                            </div>
                            
                            <h6>Lista Seguimientos:</h6>
                        <table class="table">
                            <tr>
                                <th scope="col">Sesión</th>
                                <th scope="col">Fecha</th> 
                                <th scope="col">Peso</th>
                                <th scope="col">Oreja</th>
                                <th scope="col">Ejercicio</th>
                           </tr>
                                <asp:Literal ID="LitSeguimiento" runat="server" ></asp:Literal>
                        </table>

                        </div>
                     
                        
                  </div> <%--tab Seg Semanal--%>


                   <%-- Seguimiento Mensual--%>
                 <div id="SM" class="tab-pane fade" role="tabpanel" aria-labelledby="nav-SM">
                      <h4>Seguimientos Nutricionales</h4>
           <%--<div style="width:100%; float:left;">--%>
               <h4>Nuevo Registro</h4>
               <div class="col-11" style="width:50%;">
                <label class="form-label" for="tejeSem">Días de ejercicio semanales: </label>
                <asp:Label runat="server" ID="Label2" Font-Size="Medium"></asp:Label>
               </div>
               <div class="col-11" style="width:50%;">
                <label class="form-label" for="tejeSem">Comidas Extras: </label>
                <asp:Label runat="server" ID="ComidsExtras" Font-Size="Medium"></asp:Label>
               </div>
               <div class="col-11" style="width:50%;">
                <label class="form-label" for="tejeSem">Niveles de Ansiedad semanal y tiempo de comida en donde lo siente : </label>
                <asp:Label runat="server" ID="Label4" Font-Size="Medium"></asp:Label>
               </div>
             <h4>Recordatorio de 24 Horas</h4>
             <table class="table">
               <tr>
                <th scope="col">Tiempo de Comida</th>
                <th scope="col">Hora</th> 
                <th scope="col">Descripción</th>
               </tr>
              <tr>
                <td>Ayunas</td>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
              <tr>
                <td>Desayuno</td>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
                 <tr>
                <td>Media Mañana</td>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
                 <tr>
                <td>Almuerzo</td>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
                 <tr>
                <td>Media Tarde</td>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
                 <tr>
                <td>Cena</td>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
                 <tr>
                <td>Colación Nocturna</td>
                <td> </td> 
                <td> </td>
                <td> </td>
              </tr>
            </table>
          <%-- </div>--%>
            <br />
           <br />
                  </div> <%--tab Seg Mensual--%>

             </div> <%--div tab content--%>

          </div> <%--div del nav--%>
        </div> <%--div container--%>
   </form> 
</asp:Content>
