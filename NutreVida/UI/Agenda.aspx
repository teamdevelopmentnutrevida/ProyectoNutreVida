﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agenda.aspx.cs" Inherits="UI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <title>NutreVida</title>
    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet">
    <link href="css/Margen.css" rel="stylesheet" />

    <link rel="shortcut icon" href="img/favicon.ico" />

    <%-- librería para mostrar mensajes al usuario--%>
    <script src="js/sweetalert28.js"></script>
    <meta http-equiv="Content-type" content="text/html; charset=utf-8">
    <title>Calendario Nutre Vida</title>
    <script src='codebase/dhtmlxscheduler.js?v=5.2.1' type="text/javascript" charset="utf-8"></script>
    <link rel='STYLESHEET' type='text/css' href='codebase/dhtmlxscheduler_material.css?v=5.2.1'>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <script src="codebase/ext/dhtmlxscheduler_minical.js?v=5.2.1" type="text/javascript" charset="utf-8"></script>

    <style type="text/css">
        html, body {
            margin: 0px;
            padding: 0px;
            height: 100%;
            overflow: hidden;
        }

        .dhx_calendar_click {
            /* background-color: #C2D5FC !important; */
        }
    </style>

    <script type="text/javascript" charset="utf-8">
        var prev = null;
        var curr = null;
        var next = null;

        function doOnLoad() {
            scheduler.config.multi_day = true;

            var hoy = new Date();

            scheduler.init('scheduler_here', hoy, "month");
            scheduler.load('../Eventos.json?nocache=' + (new Date()).getTime());
            //scheduler.toString();

            var calendar = scheduler.renderCalendar({
                container: "cal_here",
                navigation: true,
                handler: function (date) {
                    scheduler.setCurrentView(date, scheduler.getState().mode);
                }
            });
            scheduler.linkCalendar(calendar);

            scheduler.setCurrentView();
        }

        window.onbeforeunload = function () {
            body = document.getElementsByTagName('body')[0];
            body.style.setProperty('cursor', 'wait', 'important');
        }
    </script>


</head>


<body onload="doOnLoad();" style="cursor: default !important;">
    <div style='float: left; padding: 10px;'>
        <div id="cal_here" style='width: 250px;'></div>
        <br />
        <br />
        <br />
        <form runat="server" align="center">
            <asp:Button ID="btn1" CssClass="boton btn btn-primary" runat="server" Text="Regresar" OnClick="btn1_Click" />
            <asp:Button ID="Button1" runat="server" Style="visibility: hidden; width: 0; height: 0" />
            <textarea id="txtJson" runat="server" style="visibility: hidden; width: 0; height: 0"></textarea>
        </form>
    </div>

    <div id="scheduler_here" class="dhx_cal_container" style='width: auto; height: 100%;'>
        <div class="dhx_cal_navline">
            <div class="dhx_cal_prev_button">&nbsp;</div>
            <div class="dhx_cal_next_button">&nbsp;</div>
            <div class="dhx_cal_today_button"></div>
            <div class="dhx_cal_date"></div>
            <div class="dhx_cal_tab" name="day_tab" style="right: 204px;"></div>
            <div class="dhx_cal_tab" name="week_tab" style="right: 140px;"></div>
            <div class="dhx_cal_tab" name="month_tab" style="right: 76px;"></div>
        </div>
        <div class="dhx_cal_header">
        </div>
        <div class="dhx_cal_data">
        </div>
    </div>

</body>
</html>
