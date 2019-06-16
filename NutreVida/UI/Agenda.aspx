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
            BL.Evento eve1 = new BL.Evento("Cita", "Odontologia", "inicio", "fin", "16/06/2019");
            quemados.Add(eve1);

            quemados.Add(new BL.Evento("Spa", "sdc", "sdc", "sdc", "17/06/2019"));
            quemados.Add(new BL.Evento("fiesta", "sdc", "sdc", "sdc", "18/06/2019"));
            quemados.Add(new BL.Evento("cumpleaños", "sd", "sdc", "sd", "30/06/2019"));
        }

        void DayRender(Object source, DayRenderEventArgs e)
        {
            //recorrre para insertar

            cargarCalendario();

            //Add custom text to cell in the Calendar control.
            //if (e.Day.Date.Day == 18)
            //    e.Cell.Controls.Add(new LiteralControl("<br />Holiday"));

        }


        void Selection_Change(Object sender, EventArgs e)
        {
            string evento = Calendar1.SelectedDate.ToShortDateString();

            DateTime evento2 = DateTime.Parse( Calendar1.SelectedDate.ToShortDateString());

            string anno = Calendar1.SelectedDate.Year.ToString();
            string dia = Calendar1.SelectedDate.Day.ToString();
            string mes = Calendar1.SelectedDate.Month.ToString();
            
            string Valor = anno + "-" + mes + "-" + dia;
            Response.Redirect("Evento.aspx?Valor=" + Valor);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string evento = Calendar1.SelectedDate.Year.ToString();
            string Valor = Calendar1.SelectedDate.ToShortDateString();
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

            <h1>Agenda Nutre Vida</h1>
            <div id="holder" class="row">
                <asp:Calendar ID="Calendar1" runat="server"
                    SelectionMode="Day"
                    ShowGridLines="True"
                    OnSelectionChanged="Selection_Change" OnDayRender="DayRender" Height="664px" Width="582px">

                    <SelectedDayStyle BackColor="Yellow"
                        ForeColor="Red"></SelectedDayStyle>
                    <WeekendDayStyle BackColor="gray"></WeekendDayStyle>
                </asp:Calendar>
                <br />
                <div>
                    <asp:Button ID="btnAgregarEvento" runat="server" Text="Agregar Evento" OnClick="btnAgregarEvento_Click"/>
                </div>
                
                &nbsp;
            </div>
        </div>


    </form>
</asp:Content>



