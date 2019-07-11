<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="UI.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
           <%--  Modal para el ingresar nuevo seguimiento--%>
                    <div id="id01" class="modal">
  
                      <div class="modal-content animate">
                         <div class="imgcontainer">
                          <span onclick="document.getElementById('id01').style.display='none'" class="close" title="Cerrar">&times;</span>
                          <h4 class="m-0 font-weight-bold text-primary">Nuevo Seguimiento Nutricional </h4>
                        </div>
                    

                    <div class="container">
                   
                            <input type="text" name="yr" disabled="disabled"/>
                            <br />
                        </div>
         

                        <div style="background-color:#f1f1f1">
                          <button type="button" onclick="document.getElementById('id01').style.display='none'" class="cancelbtn">Cancel</button>
                          <asp:Button runat="server" ID="GuardarSeguimNutri" OnClick="GuardarSeguimNutri_Click" CssClass="guardarbtn" Text="Guardar"/>
                        </div>
                      </div>    <%--div content animated--%>
                    </div> <%--div modal--%>

                     <br />
                      <%--  Modal para el seguimiento anterior primera parte--%>
                    <div id="id02" class="modal">
  
                      <div class="modal-content animate">
                         <div class="imgcontainer">
                          <span onclick="CerrarModal2()" class="close" title="Cerrar">&times;</span>
                          <h4 class="m-0 font-weight-bold text-primary">Seguimiento Nutricional</h4>
                        </div>
                    

                    <div class="container">
                      <div class="row">
                           <div class="col-form-label">
                            <label class="form-label" for="tejeSem">Días de ejercicio semanales: </label>
                            <asp:TextBox runat="server" ID="SAntDiasEjeSem" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Días de ejercicio semanal"></asp:TextBox>
                           </div>
                           <div class="col-1"></div>
                            <div class="col-form-label">
                            <label class="form-label" for="tejeSem">Comidas Extras: </label>
                            <asp:TextBox runat="server" ID="SAntComExtra" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Comidas Extras"></asp:TextBox>
                           </div>
                          <div class="col-1"></div>
                           <div class="col-form-label">
                                <label class="form-label" for="tejeSem">Niveles de Ansiedad semanal y tiempo de comida en donde lo siente : </label>
                                 <asp:TextBox runat="server" ID="SAntNivAnsiedad" TextMode="MultiLine" CssClass="form-control" Font-Size="Small" data-toggle="tooltip" title="Niveles de Ansiedad"></asp:TextBox>
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
                               <td><asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="SAntAyunHora" runat="server"></asp:TextBox></td>
                               <td><asp:TextBox CssClass="form-control" Font-Size="Small" ID="SAntAyunDescrip" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                               <td>Desayuno</td>
                               <td><asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="SAntDesAyunHora" runat="server"></asp:TextBox></td>
                               <td><asp:TextBox CssClass="form-control" Font-Size="Small" ID="SAntDesAyunDescrip" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                               <td>Media Mañana</td>
                               <td><asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="SAntMedManHora" runat="server"></asp:TextBox></td>
                               <td><asp:TextBox CssClass="form-control" Font-Size="Small" ID="SAntMedManDescrip" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                               <td>Almuerzo</td>
                               <td><asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="SAntAlmHora" runat="server"></asp:TextBox></td>
                               <td><asp:TextBox CssClass="form-control" Font-Size="Small" ID="SAntAlmDescrip" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                               <td>Media Tarde</td>
                               <td><asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="SAntMedTardHora" runat="server"></asp:TextBox></td>
                               <td><asp:TextBox CssClass="form-control" Font-Size="Small" ID="SAntMedTardDescrip" runat="server"></asp:TextBox></td>
                            </tr>
                           <tr>
                               <td>Cena</td>
                                <td><asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="SAntCenaHora" runat="server"></asp:TextBox></td>
                                <td><asp:TextBox CssClass="form-control" Font-Size="Small" ID="SAntCenaDescrip" runat="server"></asp:TextBox></td>
                           </tr>
                           <tr>
                               <td>Colación Nocturna</td>
                               <td><asp:TextBox TextMode="Time" CssClass="form-control" Font-Size="Small" ID="SAntColNoctHora" runat="server"></asp:TextBox></td>
                               <td><asp:TextBox CssClass="form-control" Font-Size="Small" ID="SAntColNoctDescrip" runat="server"></asp:TextBox></td>
                           </tr>
                           </table>
                             
                            <input type="text" name="ty2" required style="display: none" disabled="disabled"/>
                            <br />
                        </div>
         

                        <div class="container" style="background-color:#f1f1f1">
                          <button type="button" onclick="CerrarModal2()" class="cancelbtn">Atrás</button>
                        </div>
                      </div> <%--div content animated--%>
                    </div>  <%--div modal 2 Anterior primera parte--%>
                     <br />

                      <%--  Modal para el seguimiento antropometria anterior--%>
                    <div id="id03" class="modal">
  
                      <div class="modal-content animate">
                         <div class="imgcontainer">
                          <span onclick="CerrarModal3()" class="close" title="Cerrar">&times;</span>
                          <h4 class="m-0 font-weight-bold text-primary">Tabla de Seguimiento Antropometría</h4>
                        </div>
                    

                    <div class="container">
                             <h5>Seguimiento de Antropometría</h5>
                             <div class="row">
                                <div class="col-form-label">
                                    <label class="form-label" for="tEdad">Edad:</label>
                                    <asp:TextBox ID="TextBox24" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Edad"></asp:TextBox>
                                    <label class="form-label" for="tTalla">Talla: </label>
                                    <asp:TextBox ID="TextBox25" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Talla"></asp:TextBox>
                                    <label class="form-label" for="tCM">CM:</label>
                                    <asp:TextBox ID="TextBox26" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Peso actual"></asp:TextBox>
                                    <label class="form-label" for="tPesoSegAnt">Peso:</label>
                                    <asp:TextBox ID="TextBox27" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Peso Máximo en teoría"></asp:TextBox>
                                    <label class="form-label" for="tImcSegAnt">IMC: </label>
                                    <asp:TextBox ID="TextBox28" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Peso meta o ideal"></asp:TextBox>
                                    <label class="form-label" for="tSegAntAgua">Agua: </label>
                                    <asp:TextBox ID="TextBox29" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Edad metabólica"></asp:TextBox>
                                    <label class="form-label" for="tSegAntMasa">Masa Osea:</label>
                                    <asp:TextBox ID="TextBox30" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Cintura"></asp:TextBox>
                                  </div>
                                  <div class="col-1"></div>
                                <div class="col-form-label">
                                    <label class="form-label" for="tGrasaAnalizador">Grasa % analizador:</label>
                                    <asp:TextBox ID="TextBox31" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Grasa % analizador"></asp:TextBox>
                                    <label class="form-label" for="tGrasBascu">% Grasa báscula: </label>
                                    <asp:TextBox ID="TextBox32" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Grasa báscula"></asp:TextBox>
                                    <label class="form-label" for="tGB_BI">BI:</label>
                                    <asp:TextBox ID="TextBox33" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="GB_BI"></asp:TextBox>
                                    <label class="form-label" for="tGB_BD">BD:</label>
                                    <asp:TextBox ID="TextBox34" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="GB_BD"></asp:TextBox>
                                    <label class="form-label" for="tGB_PI">PI:</label>
                                    <asp:TextBox ID="TextBox35" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="GB_PI"></asp:TextBox>
                                    <label class="form-label" for="tGB_PD">PD:</label>
                                    <asp:TextBox ID="TextBox36" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="GB_PD"></asp:TextBox>
                                    <label class="form-label" for="tGB_Tronco">Tronco:</label>
                                    <asp:TextBox ID="TextBox37" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="GB_Tronco"></asp:TextBox>
                                    </div>    
                          <div class="col-1"></div>
                               <div class="col-form-label">
                                    <label class="form-label" for="tGrasVisceral">% Grasa Visceral:</label>
                                    <asp:TextBox ID="TextBox38" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Grasa visceral"></asp:TextBox>
                                     <label class="form-label" for="tPorcentMusculo">% Músculo:</label>
                                    <asp:TextBox ID="TextBox39" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="% Músculo"></asp:TextBox>
                                    <label class="form-label" for="tPM_BI">BI: </label>
                                    <asp:TextBox ID="TextBox40" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="%M_BI"></asp:TextBox>
                                    <label class="form-label" for="tPM_BD">BD:</label>
                                    <asp:TextBox ID="TextBox41" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="%M_BD"></asp:TextBox>
                                    <label class="form-label" for="tPM_PI">PI:</label>
                                    <asp:TextBox ID="TextBox42" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="%M_PI"></asp:TextBox>
                                    <label class="form-label" for="tPM_PD">PD:</label>
                                    <asp:TextBox ID="TextBox43" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="%M_PD"></asp:TextBox>
                                    <label class="form-label" for="tPM_Tronco">Tronco</label>
                                    <asp:TextBox ID="TextBox44" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="%M_Tronco"></asp:TextBox>         
                               </div>
                                <div class="col-1"></div>
                                <div class="col-form-label">
                                     <label class="form-label" for="tCircunfCintura">Circunferencia cintura: </label>
                                    <asp:TextBox ID="TextBox45" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Circunferencia de la cintura"></asp:TextBox>
                                     <label class="form-label" for="tCadeSegAnt">Cadera:</label>
                                    <asp:TextBox ID="TextBox46" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Cadera"></asp:TextBox>
                                    <label class="form-label" for="tMusloIzq">Muslo Izquierdo:</label>
                                    <asp:TextBox ID="TextBox47" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Muslo Izquierdo"></asp:TextBox>
                                   <label class="form-label" for="tMusloDer">Muslo Derecho:</label>
                                    <asp:TextBox ID="TextBox48" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Muslo Derecho"></asp:TextBox>
                                    <label class="form-label" for="tBrazoIzq">Brazo Izquierdo:</label>
                                    <asp:TextBox ID="TextBox49" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Izquierdo"></asp:TextBox>
                                   <label class="form-label" for="tBrazoDer">Brazo Derecho:</label>
                                    <asp:TextBox ID="TextBox50" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Brazo Derecho"></asp:TextBox>
                                   <label class="form-label" for="tPesoMeta">Peso Meta o Ideal:</label>
                                    <asp:TextBox ID="TextBox51" runat="server" CssClass="form-control" Font-Size="Small" Type="number" min="0" oninput="validity.valid||(value='');" data-toggle="tooltip" title="Peso Meta o Ideal"></asp:TextBox>
                                </div>
                            </div>
                            <input type="text" name="ty5" required style="display: none" disabled="disabled"/>
                            <br />
                        </div>
         

                        <div class="container" style="background-color:#f1f1f1">
                          <button type="button" onclick="CerrarModal3()" class="cancelbtn">Atrás</button>
                        </div>
                      </div> <%--div content animated--%>
                    </div><%--div modal 3 anterior antropometria--%>
                     <br />
    </form>
</body>
</html>
