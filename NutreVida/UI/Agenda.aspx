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

            DateTime evento2 = DateTime.Parse( Calendar1.SelectedDate.ToShortDateString());

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

            <h1>Agenda Nutre Vida</h1>
            <div id="holder" class="row">
                <asp:Calendar ID="Calendar1" runat="server"
                    SelectionMode="Day"
                    ShowGridLines="True"
                    OnSelectionChanged="Selection_Change" OnDayRender="DayRender" Height="664px" Width="582px">

                    <SelectedDayStyle BackColor="Yellow"
                        ForeColor="Red"></SelectedDayStyle>

                    <WeekendDayStyle BackColor="gray"></WeekendDayStyle>

                    <TodayDayStyle BorderColor="#3366ff" Font-Underline="true" BackColor="#3366ff"/>


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



