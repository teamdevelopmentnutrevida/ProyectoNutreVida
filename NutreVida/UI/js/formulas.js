function validarEdad(t) {
    var fechaN = document.getElementById(t.id);

    if (fechaN.value != "") {

        var hoy = new Date();
        var cumpleanos = new Date(fechaN.value);
        var edad = hoy.getFullYear() - cumpleanos.getFullYear();
        var m = hoy.getMonth() - cumpleanos.getMonth();

        if (m < 0 || (m === 0 && hoy.getDate() < cumpleanos.getDate())) {
            edad--;
        }
            document.getElementById('ContentPlaceHolder1_txtEdad').value = edad;
    }

}

function validarIMC() {
    var peso = document.getElementById('ContentPlaceHolder1_txtPesoActual');

    var talla = document.getElementById('ContentPlaceHolder1_txtTalla');


    if (peso.value != "" && talla.value != "") {

        var tallaFormato;

        if (talla.value.includes(",") || talla.value.includes(".")) {
            tallaFormato = talla.value;
        } else
            tallaFormato = (talla.value / 100);

        var imc = peso.value / Math.pow(tallaFormato, 2);
        document.getElementById('ContentPlaceHolder1_txtIMC').value = imc.toFixed(2);
    }
}

function validarGEB() {
    var pesoIdeal = document.getElementById('ContentPlaceHolder1_txtPesoIdeal');

    var talla = document.getElementById('ContentPlaceHolder1_txtTalla');

    var edad = document.getElementById('ContentPlaceHolder1_txtEdad');

    var sexo = document.getElementById('ContentPlaceHolder1_dropSexo').value;

    var tallaFormato;

    if (talla.value.includes(",") || talla.value.includes(".")) {

        tallaFormato = (talla.value * 100);
    } else
        tallaFormato = talla.value;

    if (pesoIdeal.value != "" && talla.value != "" && edad.value != "") {

        if (sexo == "F" && edad.value > 10) {
            var GEB = 65.5 + (9.6 * pesoIdeal.value) + (1.8 * tallaFormato) - (4.7 * edad.value);
        } else if (sexo == "M" && edad.value > 10) {
            var GEB = 66.5 + (13.7 * pesoIdeal.value) + (5 * tallaFormato) - (6.8 * edad.value);
        } else if (edad.value <= 10) {
            var GEB = 22.1 + (31.05 * pesoIdeal.value) + (1, 16 * tallaFormato);
        }


        document.getElementById('ContentPlaceHolder1_txtGEB').value = GEB.toFixed(2);

        validarGET();
    }
}

function validarGET() {

    var GEB = document.getElementById('ContentPlaceHolder1_txtGEB').value;

    var FA = document.getElementById('ContentPlaceHolder1_DropTipoActividad').value;

    if (GEB != "") {
        var GET = GEB * 1.1 * FA;

        document.getElementById('ContentPlaceHolder1_txtGET').value = GET.toFixed(2);
    }
}

function validarPesoIdeal() {
    var sexo = document.getElementById('ContentPlaceHolder1_dropSexo').value;

    var talla = document.getElementById('ContentPlaceHolder1_txtTalla');

    var pesoIdeal;

    if (talla.value.includes(",") || talla.value.includes(".")) {

        tallaFormato = (talla.value * 100);
    } else
        tallaFormato = talla.value;

    if (talla.value != ""){
        if (sexo == "M"){
            pesoIdeal = tallaFormato - 100 - ((tallaFormato - 150) / 4);
        }else
            pesoIdeal = tallaFormato - 100 - ((tallaFormato - 150) / 2.5);

        document.getElementById('ContentPlaceHolder1_txtPesoIdeal').value = pesoIdeal.toFixed(2);
    }

}

