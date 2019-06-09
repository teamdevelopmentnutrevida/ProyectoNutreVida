<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="PrimerIngreso.aspx.cs" Inherits="UI.PrimerIngreso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



	 <div class="col-11" style="width:100%; float:left;">
	   
        <div class="tab">
		  <button class="tablinks" onclick="openInfo(event, 'DP')">Datos Personales</button>
          <button class="tablinks" onclick="openInfo(event, 'HM')">Historial Médico</button>
          <button class="tablinks" onclick="openInfo(event, 'HA')">Habitos Alimentarios</button>
          <button class="tablinks" onclick="openInfo(event, 'Ant')">Antropometría</button>
        </div>

	     <form id="form3" runat="server">

			  <div id="DP" class="tabcontent">
            <h4>Datos Personales</h4>
				  	<div>
            <div class="col-11" style="width:50%; float:left;">
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tCedula">Cédula:</label><asp:Label runat="server" ID="Label2" Font-Size="Medium"></asp:Label>
					<asp:TextBox ID="TextBox8" runat="server" placeholder="Número de cédula" CssClass="form-control"></asp:TextBox>
					<br />
				</div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tnombre">Nombre</label><asp:Label runat="server" ID="Label3" Font-Size="Medium"></asp:Label>
              <asp:TextBox ID="TextBox9" runat="server" placeholder="Nombre" CssClass="form-control"></asp:TextBox>
					<br />
					  </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tFechN">Fecha de Nacimiento:</label><asp:Label runat="server" ID="Label4" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox10" runat="server" placeholder="Fecha de nacimiento" CssClass="form-control"></asp:TextBox>
					<br />
				</div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tTel">Teléfono:</label><asp:Label runat="server" ID="Label5" Font-Size="Medium"></asp:Label>
               <asp:TextBox ID="TextBox11" runat="server" placeholder="Teléfono" CssClass="form-control"></asp:TextBox>
					 <br />
					  </div>
                 <div class ="col-11" style="width:50%;">
                    <label class="form-label" for="tWhats">Utiliza whatsapp:</label>
                    <asp:DropDownList runat="server" ID="DropDownList2">
                    <asp:ListItem Selected="True" Value="Sí"> Sí </asp:ListItem><asp:ListItem Value="No"> No </asp:ListItem>
                     </asp:DropDownList>
					 <br />
                </div>
                
            </div>
			<br />
            <div style="width:50%; float:left;">
			
                <div class="col-11" style="width:50%;">
			     <label class="form-label" for="tOcup">Ocupación:</label><asp:Label runat="server" ID="Label6" Font-Size="Medium"></asp:Label>
                 <asp:TextBox ID="TextBox12" runat="server" placeholder="Ocupación" CssClass="form-control"></asp:TextBox>
					<br />
				</div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tResid">Residencia</label><asp:Label runat="server" ID="Label7" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox13" runat="server" placeholder="Dirección de residencia" CssClass="form-control"></asp:TextBox>
					<br />
				</div> 
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tEmail">Email</label><asp:Label runat="server" ID="Label8" Font-Size="Medium"></asp:Label>
              <asp:TextBox ID="TextBox14" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox>
					<br />
					  </div>  
				 <div class="col-11" style="width:50%;">
					
                    <label class="form-label" for="tSex">Sexo:</label><asp:Label runat="server" ID="Label9" Font-Size="Medium"></asp:Label>
                <asp:DropDownList runat="server" ID="DropDownList3">
                    <asp:ListItem Selected="True" Value="F"> F </asp:ListItem><asp:ListItem Value="M"> M </asp:ListItem>
                     </asp:DropDownList>
					<br />
				</div>
               
                 <br />
                <br />
                </div>    
			<br /><br />
        </div>
				    <label class="form-label" ></label><asp:Label runat="server" ID="Label1" Font-Size="Medium"></asp:Label>
               
				  </div>

        <div id="HM" class="tabcontent">
            <h4>Historial Medico</h4>
            <div class="col-11" style="width:100%;">
                <label class="form-label" for="tAntFam">Antecedentes Familiares:</label><asp:Label runat="server" ID="Label10" Font-Size="Medium"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Antecedentes" CssClass="form-control"></asp:TextBox>
				
			</div>
            <div class="col-11" style="width:100%;">
                 <label class="form-label" for="tPat">Patologías que padece:</label><asp:Label runat="server" ID="Label11" Font-Size="Medium"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" placeholder="Patologias" CssClass="form-control"></asp:TextBox>
				
			</div>
                
            <h4>Consumo de:</h4> 
           
             <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tLic">Licor:     </label><asp:Label runat="server" ID="Label12" Font-Size="Medium"></asp:Label>
                    <label class="form-label" for="tFrecLic">Frecuencia: </label><asp:Label runat="server" ID="Label13" Font-Size="Medium"></asp:Label>
             <asp:TextBox ID="TextBox3" runat="server" placeholder="Frecuencia" CssClass="form-control"></asp:TextBox>
				   
			 </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tLic">Fuma:     </label><asp:Label runat="server" ID="Label14" Font-Size="Medium"></asp:Label>
                    <label class="form-label" for="tFrecFum">Frecuencia: </label><asp:Label runat="server" ID="Label15" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox4" runat="server" placeholder="Frecuencia" CssClass="form-control"></asp:TextBox>
				
				</div>
             <h4>Medicamentos o suplementos que consume:</h4>   
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
                <label class="form-label" for="tFechExm"> Fecha de últimos examenes de sangre o revisión médica:</label><asp:Label runat="server" ID="Label16" Font-Size="Medium"></asp:Label>
            </div>
        </div>
       
	   
        <div id="HA" class="tabcontent">
          <h4>Habitos Alimentarios</h4>
          <div class="col-11" style="width:100%;">
                 <label class="form-label" for="tComD">¿Cuántas veces come al día? </label>
                 <asp:Label runat="server" ID="Label17" Font-Size="Medium"></asp:Label>
          <asp:TextBox ID="TextBox5" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
				
			   </div>
           <div class="col-11" style="width:100%;">
                 <label class="form-label" for="tComeHoraDia">¿Acostumbra a comer a las horas al día? </label>
                 <asp:Label runat="server" ID="Label18" Font-Size="Medium"></asp:Label>
           <asp:TextBox ID="TextBox6" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
				
		   </div>
            <div class="col-11" style="width:100%;">
                 <label class="form-label" for="tComeExprss">¿Cuántas veces a la semana come fuera o pide un express? </label>
                 <asp:Label runat="server" ID="Label19" Font-Size="Medium"></asp:Label>
           <asp:TextBox ID="TextBox7" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
				
			</div>
           <div class="col-11" style="width:100%;">
                <label class="form-label" for="tGenerComeAfuera">¿Generalmente que come fuera de la casa?</label>
                <asp:Label runat="server" ID="Label20" Font-Size="Medium"></asp:Label>
           <asp:TextBox ID="TextBox15" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
		   </div>
            <div class="col-11" style="width:100%;">
                <label class="form-label" for="tAzucarB">¿Cuánta azúcar le agrega a las bebidas?</label>
                <asp:Label runat="server" ID="Label21" Font-Size="Medium"></asp:Label>
          <asp:TextBox ID="TextBox16" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
				 </div>
            <div class="col-11" style="width:100%;">
                <label class="form-label" for="tAzucarB">¿Los alimentos que cocina los elabora generalmente? </label>
                <asp:Label runat="server" ID="Label22" Font-Size="Medium"></asp:Label>
           <asp:TextBox ID="TextBox17" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
			</div>
            <div class="col-11" style="width:100%;">
                <label class="form-label" for="tAguaDia">¿Cuántos vasos de agua toma al día? </label>
                <asp:Label runat="server" ID="Label23" Font-Size="Medium"></asp:Label>
           </div>
             <div class="col-11" style="width:100%;">
                <label class="form-label" for="tAder">¿Agrega salsa tomate, mayonesa, mantequilla o natilla a la comida? </label>
                <asp:Label runat="server" ID="Label24" Font-Size="Medium"></asp:Label>
           </div>
           <h4>Le gusta la mayoría de:</h4>
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
        </div>
	 
        <div id="Ant" class="tabcontent">
          <h4>Antropometría</h4>
           <div>
            <div class="col-11" style="width:50%; float:left;">
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tEdad">Edad:</label><asp:Label runat="server" ID="Label25" Font-Size="Medium"></asp:Label>
                 <asp:TextBox ID="TextBox18" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
				</div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPesoActual">Peso Actual:</label><asp:Label runat="server" ID="Label26" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox19" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
					 </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPesoMaxTeoria">Peso máximo en teoría:</label><asp:Label runat="server" ID="Label27" Font-Size="Medium"></asp:Label>
                 <asp:TextBox ID="TextBox20" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
				</div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPesoIdeal">Peso meta o ideal: </label><asp:Label runat="server" ID="Label28" Font-Size="Medium"></asp:Label>
                 <asp:TextBox ID="TextBox21" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
				 </div>
                 <div class ="col-11" style="width:50%;">
                    <label class="form-label" for="tEdadMetab">Edad metabólica: </label><asp:Label runat="server" ID="Label29" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox47" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			 </div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tCintura">Cintura:</label><asp:Label runat="server" ID="Label30" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox22" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
					  </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tAbdm">Abdomen:</label><asp:Label runat="server" ID="Label31" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox23" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
					 </div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tCadera">Cadera:</label><asp:Label runat="server" ID="Label32" Font-Size="Medium"></asp:Label>
                </div> 
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tMuslo">Muslo:</label><asp:Label runat="server" ID="Label33" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox24" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
					 </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPMB">PMB: </label><asp:Label runat="server" ID="Label34" Font-Size="Medium"></asp:Label>
                 <asp:TextBox ID="TextBox25" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
				</div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tCMB">CMB: </label><asp:Label runat="server" ID="Label35" Font-Size="Medium"></asp:Label>
                 <asp:TextBox ID="TextBox26" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
				</div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tAgua">Agua: </label><asp:Label runat="server" ID="Label36" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox27" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
					  </div>
                 <div class ="col-11" style="width:50%;">
                    <label class="form-label" for="tComplexión">Complexión: </label><asp:Label runat="server" ID="Label37" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox28" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
					  </div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tMasaOsea">Masa ósea: </label><asp:Label runat="server" ID="Label38" Font-Size="Medium"></asp:Label>
                 <asp:TextBox ID="TextBox29" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
				 </div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tTalla">Talla: </label><asp:Label runat="server" ID="Label39" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox30" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
					  </div>                 
            </div>

               <%--Columna #2--%>
            <div style="width:50%; float:left;">
                <div class ="col-11" style="width:50%;">
                    <label class="form-label" for="tCircunfMun">Circunferencia muñeca: </label><asp:Label runat="server" ID="Label40" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox31" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
					 </div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tIMC">IMC:</label><asp:Label runat="server" ID="Label41" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox32" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
					  </div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tGrasaAnalizador">%Grasa analizador:</label><asp:Label runat="server" ID="Label42" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox33" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
					  </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tGrasVisceral"> % Grasa Visceral:</label><asp:Label runat="server" ID="Label43" Font-Size="Medium"></asp:Label>
                 <asp:TextBox ID="TextBox34" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
				</div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tGrasBascu">% Grasa báscula: </label><asp:Label runat="server" ID="Label44" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox35" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
					 </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tGB_BI">BI:</label><asp:Label runat="server" ID="Label45" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox36" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
					 </div> 
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tGB_BD">BD:</label><asp:Label runat="server" ID="Label46" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox37" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			
					 </div>  
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tGB_PI">PI:</label><asp:Label runat="server" ID="Label47" Font-Size="Medium"></asp:Label>
                 <asp:TextBox ID="TextBox38" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			</div>  
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tGB_PD">PD:</label><asp:Label runat="server" ID="Label48" Font-Size="Medium"></asp:Label>
                 <asp:TextBox ID="TextBox39" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			</div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tGB_Tronco">Tronco:</label><asp:Label runat="server" ID="Label49" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox40" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			 </div>
                 <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPorcentMusculo">% Músculo:</label><asp:Label runat="server" ID="Label50" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox41" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			 </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPM_BI">BI: </label><asp:Label runat="server" ID="Label51" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox42" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			 </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPM_BD">BD:</label><asp:Label runat="server" ID="Label52" Font-Size="Medium"></asp:Label>
                 <asp:TextBox ID="TextBox43" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			</div>                 
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPM_PI">PI:</label><asp:Label runat="server" ID="Label53" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox44" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			 </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPM_PD">PD:</label><asp:Label runat="server" ID="Label54" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox45" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			 </div>
                <div class="col-11" style="width:50%;">
                    <label class="form-label" for="tPM_Tronco">Tronco</label><asp:Label runat="server" ID="Label55" Font-Size="Medium"></asp:Label>
                <asp:TextBox ID="TextBox46" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
			 </div> 
               
                </div> <%--Fin columna 2   --%>
            </div>
            <div class="col-11" style="width:100%; float:left;">
                <label class="form-label" for="tObserv">Observación:</label><asp:Label runat="server" ID="Label56" Font-Size="Medium"></asp:Label>
            </div>
            <br />
            <div class="col-11" style="width:100%; float:left;">
             <div class="col-11" style="width:100%;">
                <label class="form-label" for="tGEB">GEB:</label>
                <asp:Label runat="server" ID="Label57" Font-Size="Medium"></asp:Label>
           </div>
            <div class="col-11" style="width:100%;">
                <label class="form-label" for="tGET">GET:</label>
                <asp:Label runat="server" ID="Label58" Font-Size="Medium"></asp:Label>
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
                    <label class="form-label" for="tLeche">Leche:</label><asp:Label runat="server" ID="Label59" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:25%;">
                    <label class="form-label" for="tCarnes">Carnes:</label><asp:Label runat="server" ID="Label60" Font-Size="Medium"></asp:Label>
                </div>
            </div>
             <div style="width:25%; float:left;">
                 <div class="col-11" style="width:25%;">
                    <label class="form-label" for="tVegetales">Vegetales:</label><asp:Label runat="server" ID="Label61" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:25%;">
                    <label class="form-label" for="tGrasas">Grasas:</label><asp:Label runat="server" ID="Label62" Font-Size="Medium"></asp:Label>
                </div>
            </div>
             <div style="width:25%; float:left;">
                 <div class="col-11" style="width:25%;">
                    <label class="form-label" for="tFruts">Frutas:</label><asp:Label runat="server" ID="Label63" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:25%;">
                    <label class="form-label" for="tAzucares">Azúcares:</label><asp:Label runat="server" ID="Label64" Font-Size="Medium"></asp:Label>
                </div>
            </div>
             <div style="width:25%; float:left;">
                 <div class="col-11" style="width:25%;">
                    <label class="form-label" for="tHarinas">Harinas:</label><asp:Label runat="server" ID="Label65" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col-11" style="width:25%;">
                    <label class="form-label" for="tSuplem">Suplementos:</label><asp:Label runat="server" ID="Label66" Font-Size="Medium"></asp:Label>
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
        </div>     

		    	</form>

        <script>
        function openInfo(evt, sec) {
          var i, tabcontent, tablinks;
          tabcontent = document.getElementsByClassName("tabcontent");
          for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
          }
          tablinks = document.getElementsByClassName("tablinks");
          for (i = 0; i < tablinks.length; i++) {
            tablinks[i].className = tablinks[i].className.replace(" active", "");
          }
          document.getElementById(sec).style.display = "block";
          evt.currentTarget.className += " active";
        }
        </script>
		  
          </div>



</asp:Content>
