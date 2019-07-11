<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="UI.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Promedio pesos por edad</h1>
        </div>

        <div class="row">

            <!-- Menor de 20 Card -->
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-primary shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters ">
                            <div class="col mr-2">
                                <div class="text-sm font-weight-bold text-primary text-uppercase mb-1">Menor de 20</div>
                                <div class="h2 mb-0 font-weight-bold text-gray-800">
                                    <asp:Label ID="lbMenor20" runat="server" Text="0"></asp:Label>
                                </div>
                            </div>
                            <div class="col-auto">
                                Cantidad:
                                <asp:Label ID="lbCantidadMenor20" runat="server" Text="0"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- 20-30 Card -->
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-success shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters ">
                            <div class="col mr-2">
                                <div class="text-sm font-weight-bold text-success text-uppercase mb-1">20-30</div>
                                <div class="h2 mb-0 font-weight-bold text-gray-800">
                                    <asp:Label ID="lb20_30" runat="server" Text="0"></asp:Label>
                                </div>
                            </div>
                            <div class="col-auto">
                                Cantidad:
                                <asp:Label ID="lbCantidad20_30" runat="server" Text="0"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- 30-40 Card -->
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-info shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters ">
                            <div class="col mr-2">
                                <div class="text-sm font-weight-bold text-info text-uppercase mb-1">30-40</div>
                                <div class="h2 mb-0 font-weight-bold text-gray-800">
                                    <asp:Label ID="lb30_40" runat="server" Text="0"></asp:Label>
                                </div>
                            </div>
                            <div class="col-auto">
                                Cantidad:
                                <asp:Label ID="lbCantidad30_40" runat="server" Text="0"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Mayor de 40 -->
            <div class="col-xl-3 col-md-6 mb-4">
                <div class="card border-left-warning shadow h-100 py-2">
                    <div class="card-body">
                        <div class="row no-gutters ">
                            <div class="col mr-2">
                                <div class="text-sm font-weight-bold text-warning text-uppercase mb-1">Mayor de 40</div>
                                <div class="h2 mb-0 font-weight-bold text-gray-800">
                                    <asp:Label ID="lbMayor40" runat="server" Text="0"></asp:Label>
                                </div>
                            </div>
                            <div class="col-auto">
                                Cantidad:
                                <asp:Label ID="lbCantidadMayor40" runat="server" Text="0"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="d-sm-flex align-items-center justify-content-between mb-4 ">
            <h1 class="h3 mb-0 text-gray-800">Clasificación IMC</h1>
        </div>

        <div class="row">

            <div class="col-xl-8 col-lg-7">

                <!-- Bar Chart -->
                <div class="card shadow mb-4">
                    <!-- Card Header - Dropdown -->
                    <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                  <h6 class="m-0 font-weight-bold text-primary">Clasificación IMC</h6>
                  <div class="dropdown no-arrow">
                    <a class="dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                      <i class="fas fa-ellipsis-v fa-sm fa-fw text-gray-400"></i>
                    </a>
                            <div class="dropdown-menu dropdown-menu-right shadow animated--fade-in" aria-labelledby="dropdownMenuLink">
                                <div class="dropdown-header">Edad:</div>
                                <a class="dropdown-item" href="#" onclick="Modificar_Edad(0,100)">Todo</a>
                                <a class="dropdown-item" href="#" onclick="Modificar_Edad(0,20)">Menor a 20</a>
                                <a class="dropdown-item" href="#" onclick="Modificar_Edad(20,30)">20 a 30</a>
                                <a class="dropdown-item" href="#" onclick="Modificar_Edad(30,40)">30 a 40</a>
                                <a class="dropdown-item" href="#" onclick="Modificar_Edad(40,100)">Mayor a 40</a>
                            </div>
                        </div>
                    </div>
                    <!-- Card Body -->
                    <div class="card-body">
                        <div class="chart-bar">
                            <canvas id="myBarChart"></canvas>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Donut Chart -->
            <div class="col-xl-4 col-lg-5">
                <div class="card shadow mb-4">
                    <!-- Card Header - Dropdown -->
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">Sexo</h6>
                    </div>
                    <!-- Card Body -->
                    <div class="card-body">
                        <div class="chart-pie pt-4">
                            <canvas id="myPieChart"></canvas>
                        </div>
                    </div>
                </div>
            </div>



        </div>

        <!-- Script modificar -->
        <script src="https://code.jquery.com/jquery-3.3.1.min.js"> </script>
        <script type="text/javascript">
            function Modificar_Edad(edad1, edad2) {
                let jsonData = JSON.stringify({ Edad1: edad1, Edad2: edad2 })
                $.ajax({
                    type: "POST",
                    url: '/Reportes.aspx/ModificarEdad',
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    success: function () {                        
                        location.reload();
                    },
                    error: function (response) {
                        alert("No funciona")
                    }
                });
            }

        </script>

	

    </div>
    <!-- /.container-fluid -->

    <!-- Page level plugins -->
    <script src="vendor/chart.js/Chart.min.js"></script>

    <!-- Page level custom scripts -->
    <script src="js/demo/chart-area-demo.js"></script>
    <script src="js/demo/chart-pie-demo.js"></script>
    <script src="js/demo/chart-bar-demo.js"></script>



    <!-- Script Bar chart -->
    <script type="text/javascript">
        // Bar Chart Example
        var ctx = document.getElementById("myBarChart");
        var myBarChart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: ["Insuficiencia", "Normal", "Sobrepeso", "Obesidad I", "Obesidad II", "Obesidad II"],
                datasets: [{
                    backgroundColor: "#4e73df",
                    hoverBackgroundColor: "#2e59d9",
                    borderColor: "#4e73df",
                    data: [<%= Insuficiencia  %>, <%= Normal  %>, <%= Sobrepeso  %>, <%= ObesidadI  %>, <%= ObesidadII  %>, <%= ObesidadIII  %>],
                }],
            },
            options: {
                maintainAspectRatio: false,
                layout: {
                    padding: {
                        left: 10,
                        right: 25,
                        top: 25,
                        bottom: 0
                    }
                },
                scales: {
                    xAxes: [{
                        time: {
                            unit: 'month'
                        },
                        gridLines: {
                            display: false,
                            drawBorder: false
                        },
                        ticks: {
                            maxTicksLimit: 6
                        },
                        maxBarThickness: 25,
                    }],
                    yAxes: [{
                        ticks: {
                            min: 0,
                            max: 25,
                            maxTicksLimit: 10,
                            padding: 10,
                        },
                        gridLines: {
                            color: "rgb(234, 236, 244)",
                            zeroLineColor: "rgb(234, 236, 244)",
                            drawBorder: false,
                            borderDash: [2],
                            zeroLineBorderDash: [2]
                        }
                    }],
                },
                legend: {
                    display: false
                },
                tooltips: {
                    titleMarginBottom: 10,
                    titleFontColor: '#6e707e',
                    titleFontSize: 14,
                    backgroundColor: "rgb(255,255,255)",
                    bodyFontColor: "#858796",
                    borderColor: '#dddfeb',
                    borderWidth: 1,
                    xPadding: 15,
                    yPadding: 15,
                    displayColors: false,
                    caretPadding: 10,
                },
            }
        });
    </script>

    <!-- Script Donut chart -->
    <script>
        var ctx = document.getElementById("myPieChart");
        var myPieChart = new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: ["Hombres", "Mujeres"],
                datasets: [{
                    data: [<%= M  %>, <%= F  %>],
                    backgroundColor: ['#4e73df', '#1cc88a'],
                    hoverBackgroundColor: ['#2e59d9', '#17a673'],
                    hoverBorderColor: "rgba(234, 236, 244, 1)",
                }],
            },
            options: {
                maintainAspectRatio: false,
                tooltips: {
                    backgroundColor: "rgb(255,255,255)",
                    bodyFontColor: "#858796",
                    borderColor: '#dddfeb',
                    borderWidth: 1,
                    xPadding: 15,
                    yPadding: 15,
                    displayColors: false,
                    caretPadding: 10,
                },
                legend: {
                    display: true
                },
                cutoutPercentage: 80,
            },
        });
    </script>



</asp:Content>
