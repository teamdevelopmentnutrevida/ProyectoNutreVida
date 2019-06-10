using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
    public partial class PrimerIngreso : System.Web.UI.Page
    {
        private static List<Medicamento> ListaMedicamSuplem = new List<Medicamento>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
               
            }
        }

        protected void DropLicor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropLicor.SelectedValue == "Sí")
            {
                txtFrecLicor.Enabled = true;
            }
            else {
                txtFrecLicor.Enabled = false;
            }

        }

        protected void DropFuma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropFuma.SelectedValue == "Sí")
            {
                txtFrecFuma.Enabled = true;
            }
            else {
                txtFrecFuma.Enabled = false;
            }
        }

		protected void capturarRecordatorio()
		{
			string horaAyunas = txtHoraAyunas.Text.ToString();
			string descAyunas = txtDescAyunas.Text;
			string horaDes = txtHoraDesayuno.Text.ToString();
			string descDesay = txtDescDesay.Text;
			string horaMediaM = txtHoraMediaM.Text.ToString();
			string descMediaM = txtDescMediaM.Text;
			string horaAlm = txtHoraAlmmuerzo.Text.ToString();
			string descAlmuerzo = txtDescAlmuerzo.Text;
			string horaTarde = txtHoraTarde.Text.ToString();
			string descTarde = txtDescTarde.Text;
			string horaCena = txtHoraCena.Text.ToString();
			string descCena = txtDescCena.Text;
			string horaColac = txtHoraColacion.Text.ToString();
			string descColac = txtDescColacion.Text;


			
		}

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BL.PrimerIngreso ingreso = new BL.PrimerIngreso();


            ////Datos personales

            if (string.IsNullOrEmpty(txtCed.Text))
            {
                //mensaje de error
                Response.Write("<script>window.alert('Debe registrar un número de cedula');</script>");
                return;

            }

            int cedula = int.Parse(txtCed.Text);

            string correo = txtEmail.Text;
            string nombre = txtNombre.Text;
            string apellido1 = txtPrimerApellido.Text;
            string apellido2 = txtSegundoApellido.Text;
            DateTime fecha_Nacimiento = DateTime.Parse(iFechaNac.Value);
            char sexo = char.Parse(dropSexo.SelectedValue);
            string estado_Civil = dropEstadoCivil.SelectedValue;
            char whatsApp = '0';
            if (dropWhats.SelectedValue.Equals("Sí"))
            {
                whatsApp = '1';
            }
            int telefono = int.Parse(txtTel.Text);
            string residencia = txtResid.Text;
            string ocupacion = txtOcup.Text;
            DateTime fechaIngreso = DateTime.Now;


            ingreso.CrearCliente(cedula, correo, nombre, apellido1, apellido2, fecha_Nacimiento, sexo, estado_Civil, whatsApp, telefono, residencia, ocupacion, fechaIngreso);


            //Historial medico

            string antecedentes = txtAntec.Text; ;
            string patologias = txtPatol.Text;
            int consumeLicor = 0;
            if (DropLicor.SelectedValue.Equals("Sí"))
            {
                consumeLicor = 1;
            }

            int fuma = 0;
            if (DropFuma.SelectedValue.Equals("Sí"))
            {
                consumeLicor = 1;
            }

            string frecFuma = txtFrecFuma.Text;
            string frecLicor = txtFrecLicor.Text;
            string ultimoExamen = fechaExam.Value;
            string actividadFisica = txtActividadFisica.Text;
            List<Medicamento> listaM = ListaMedicamSuplem; // no se si debería validar que la lista tenga al menos un elemento

            HistorialMedico historial = new HistorialMedico(cedula, antecedentes, patologias, consumeLicor, fuma, frecFuma, frecLicor, ultimoExamen, actividadFisica);
            ingreso.AgregarHistorialMedico(historial, listaM);

            //Habitos alimentario
            int ComidaDiaria = int.Parse(numeroComidas.Text);

            char ComidaHorasDia = '0'; //drop
            if (ComeHoras.SelectedValue.Equals("Sí"))
            {
                ComidaHorasDia = '1';
            }

            int AfueraExpress = int.Parse(txtEspres.Text);
            string ComidaFuera = txtQueComeFuera.Text;
            string AzucarBebida = cantAzucar.Text;
            string ComidaElaboradCon = dropCocinaCon.SelectedValue; //drop
            decimal AguaDiaria = int.Parse(txtCuantaAgua.Text);

            char Aderezos = '0'; //drop
            if (dropAderezos.SelectedValue.Equals("Sí"))
            {
                Aderezos = '1';
            }

            char Fruta = '0'; //drop
            if (dropFrutas.SelectedValue.Equals("Sí"))
            {
                Fruta = '1';
            }

            char Verdura = '0'; //drop
            if (dropVeget.SelectedValue.Equals("Sí"))
            {
                Verdura = '1';
            }

            char Leche = '0'; //drop
            if (dropLeche.SelectedValue.Equals("Sí"))
            {
                Leche = '1';
            }

            char Huevo = '0'; //drop
            if (dropHuevo.SelectedValue.Equals("Sí"))
            {
                Huevo = '1';
            }

            char Yogurt = '0'; //drop
            if (dropYogurt.SelectedValue.Equals("Sí"))
            {
                Yogurt = '1';
            }

            char Carne = '0'; //drop
            if (dropCarne.SelectedValue.Equals("Sí"))
            {
                Carne = '1';
            }
            
            char Queso = '0'; //drop
            if (dropQueso.SelectedValue.Equals("Sí"))
            {
                Queso = '1';
            }

            char Aguacate = '0'; //drop
            if (dropAguacate.SelectedValue.Equals("Sí"))
            {
                Aguacate = '1';
            }

            char Semillas = '0'; //drop
            if (dropSemillas.SelectedValue.Equals("Sí"))
            {
                Semillas = '1';
            }

            HabitoAlimentario habito = new HabitoAlimentario(cedula, ComidaDiaria, ComidaHorasDia, AfueraExpress, ComidaFuera, AzucarBebida, ComidaElaboradCon, AguaDiaria, Aderezos, Fruta, Verdura, Leche, Huevo, Yogurt, Carne, Queso, Aguacate, Semillas);
            List<Recordatorio24H> listaRecordatorio = new List<Recordatorio24H>();

            //ayunas
            listaRecordatorio.Add( new Recordatorio24H(cedula, "Ayunas", txtHoraAyunas.Text, txtDescAyunas.Text));

            //desayuno
            listaRecordatorio.Add(new Recordatorio24H(cedula, "Desayuno", txtHoraDesayuno.Text, txtDescDesay.Text));

            //Media mañana
            listaRecordatorio.Add(new Recordatorio24H(cedula, "Media mañana", txtHoraMediaM.Text, txtDescMediaM.Text));

            //almuerzo
            listaRecordatorio.Add(new Recordatorio24H(cedula, "Almuerzo", txtHoraAlmmuerzo.Text, txtDescAlmuerzo.Text));

            //Media tarde
            listaRecordatorio.Add(new Recordatorio24H(cedula, "Tarde", txtHoraTarde.Text, txtDescTarde.Text));

            //Cena
            listaRecordatorio.Add(new Recordatorio24H(cedula, "Cena", txtHoraCena.Text, txtDescCena.Text));

            //Colacion nocturna
            listaRecordatorio.Add(new Recordatorio24H(cedula, "Colasión nocturna", txtHoraColacion.Text, txtDescColacion.Text));

            ingreso.AgregarHabitosAlimentarios(new HabitoAlimentario(cedula, ComidaDiaria, ComidaHorasDia, AfueraExpress, ComidaFuera, AzucarBebida, ComidaElaboradCon, AguaDiaria, Aderezos, Fruta, Verdura, Leche, Huevo, Yogurt, Carne, Queso, Aguacate, Semillas), listaRecordatorio);

            //Antropometria


        }



        protected void BtnAgreg_Click(object sender, EventArgs e)
        {
            if (tNomMed.Text.Equals("") || tMotvMed.Text.Equals("") || tFrecMed.Text.Equals("") || tDosisMed.Text.Equals(""))
            {
                Response.Write("<script>alert('No deben haber espacios en blanco')</script>");
            }
            else
            {
                Medicamento medicamSupl = new Medicamento();
                string tabla = tSuplementoMedico.Text;
                tabla += "<tr><td>" + tNomMed.Text + "</td><td>" + tMotvMed.Text + "</td><td>" + tFrecMed.Text + "</td><td>" + tDosisMed.Text + "</td></tr>";
                tSuplementoMedico.Text = tabla;

                if (string.IsNullOrEmpty(txtCed.Text))
                {
                    //mensaje de error
                    Response.Write("<script>window.alert('Debe registrar un número de cedula');</script>");
                    return;
                   
                } 

                medicamSupl.Cedula = int.Parse(txtCed.Text);

                medicamSupl.Nombre = tNomMed.Text;
                medicamSupl.Motivo = tMotvMed.Text;
                medicamSupl.Frecuencia = tFrecMed.Text;
                medicamSupl.Dosis = tDosisMed.Text;
                ListaMedicamSuplem.Add(medicamSupl);

                tNomMed.Text = "";
                tMotvMed.Text = "";
                tFrecMed.Text = "";
                tDosisMed.Text = "";
            }
        }


    }
}