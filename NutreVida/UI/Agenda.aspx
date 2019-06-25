<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Agenda.aspx.cs" Inherits="UI.Agenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <link href="css/style.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <script language="C#" runat="server">

        List<BL.Evento> quemados = new List<BL.Evento>();

        public void cargarCalendario()
        {
        }

        void DayRender(Object source, DayRenderEventArgs e)
        {
            //recorrre para insertar directamente al calendario

            cargarCalendario();

            //Add custom text to cell in the Calendar control.
            //if (e.Day.Date.Day == 18)
            //    e.Cell.Controls.Add(new LiteralControl("<br />Holiday"));

        }


        void Selection_Change(Object sender, EventArgs e)
        {
            string evento = Calendar1.SelectedDate.ToShortDateString();

            DateTime evento2 = DateTime.Parse(Calendar1.SelectedDate.ToShortDateString());

            string anno = Calendar1.SelectedDate.Year.ToString();
            string dia = Calendar1.SelectedDate.Day.ToString();
            string mes = Calendar1.SelectedDate.Month.ToString();

            string Valor = anno + "-" + mes + "-" + dia;
            Response.Redirect("Evento.aspx?Valor=" + Valor);

        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<form id="form1" runat="server">

        <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.bundle.min.js"></script>
        <script
            src="https://code.jquery.com/jquery-3.3.1.min.js"
            integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8="
            crossorigin="anonymous"></script>



        <div class="container-fluid theme-showcase">

            <h1 class="h3 mb-2 text-gray-800">Agenda Nutre Vida</h1>
            <div id="holder" class="row">
                <div class="col-md-5">
                    <asp:Calendar ID="Calendar1" runat="server"
                    SelectionMode="Day"
                    ShowGridLines="True"
                    OnSelectionChanged="Selection_Change" OnDayRender="DayRender" Height="284px" Width="421px">

                    <SelectedDayStyle BackColor="Yellow"
                        ForeColor="Red"></SelectedDayStyle>

                    <WeekendDayStyle BackColor="gray"></WeekendDayStyle>

                    <TodayDayStyle BorderColor="#3366ff" Font-Underline="true" BackColor="#3366ff"/>

                </asp:Calendar>
                   

                    <div class="fc-button-group">
                        <div class="fc-button-group">
                            <button type="button" class="fc-month-button fc-button fc-state-default fc-corner-left fc-state-active">month</button>
                            <button type="button" class="fc-basicWeek-button fc-button fc-state-default">week</button>
                            <button type="button" class="fc-basicDay-button fc-button fc-state-default">day</button>
                            <button type="button" class="fc-agenda-button fc-button fc-state-default fc-corner-right">agenda</button>
                            <%--bucar como implementar al calendario--%>
                        </div>
                    </div>
                     

                </div>
                
                <br />
                <div class="col-md-2">
                    <asp:Button ID="btnAgregarEvento" runat="server" Text="Agregar Evento" OnClick="btnAgregarEvento_Click"/>
                </div>

                <div class="card shadow mb-4">
             <div class="card-header py-3">
              <h6 class="m-0 font-weight-bold text-primary">Lista de Eventos:></h6>
            </div>
              <div class="card-body">
                  <div class="table-responsive">
                      <table class="table table-bordered" id="dataTable" style="width:100%; padding:0";>
                          <thead>
                            <tr>
                              <th>Hora</th>
                              <th>Evento</th>
                              <th>Descripción</th>
                              <th>Acción</th>
                            </tr>
                          </thead>
                           <tbody>
                               <asp:Literal runat="server" ID="LitListaEventos"></asp:Literal>
                               </tbody>
                       </table>
                  </div>
            </div> 
        </div>
                &nbsp;
            </div>
        </div>
      
    </form>

<!-- Button to Open the Modal -->
<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">
  Open modal
</button>

<!-- The Modal -->
<div class="modal" id="myModal">
  <div class="modal-dialog">
    <div class="modal-content">

      <!-- Modal Header -->
      <div class="modal-header">
        <h4 class="modal-title">Modificar evento</h4>
        <button type="button" class="close" data-dismiss="modal">&times;</button>
      </div>

      <!-- Modal body -->
      <div class="modal-body">
         <label class="control-label" for="nombreEven">Nombre del evento</label>
        <input type="text" class="form-control" id="nombreEven" placeholder="Nombre del evento" />

          <label class="control-label" for="descripcionEven">Descripción del evento</label>
        <input type="text" class="form-control" id="descripcionEven" placeholder="Nombre del evento" />
      </div>

      <!-- Modal footer -->
      <div class="modal-footer">
       <a href="#" class="btn" data-dismiss="modal">Cerrar</a>
       <a href="#" class="btn btn-primary">Guardar cambios</a>
    </div>

    </div>
  </div>
</div>

      <script type="text/javascript">
          function Eliminar_Click(nombre, fecha) {
              let jsonData = JSON.stringify({ nombre: nombre, fecha: fecha })
              $.ajax({
                  type: "POST",
                  url: '/Agenda.aspx/EliminarEvento',
                  data: jsonData,
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  async: true,
                  success: function () {
                      location.reload();
                      mensaje();
                  },
                  error: function (response) {
                      console.log(response);
                  }
              });
          }

      </script>

      <script type="text/javascript">
          function Modificar_Click(nombre, descripcion, horaInicio, horaFin, fecha) {
              let jsonData = JSON.stringify({ nombre: nombre, descripcion: descripcion, horaInicio: horaInicio, horaFin: horaFin, fecha: fecha })
              $.ajax({
                  type: "POST",
                  url: '/Agenda.aspx/EliminarEvento',
                  data: jsonData,
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  async: true,
                  success: function () {
                      location.reload();
                      mensaje();
                  },
                  error: function (response) {
                      console.log(response);
                  }
              });
          }

      </script>


</asp:Content>
