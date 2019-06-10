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

		protected void capturarRecordatorioAntrop()
		{
			string horaAyunasA = txtHoraAyunasA.Text.ToString();
			string descAyunasA = txtDescAyunasA.Text;
			string horaDesA = txtHoraDesayunoA.Text.ToString();
			string descDesayA = txtDescDesayA.Text;
			string horaMediaMA = txtHoraMediaMA.Text.ToString();
			string descMediaMA = txtDescMediaMA.Text;
			string horaAlmuerzoA = txtHoraAlmmuerzoA.Text.ToString();
			string descAlmuerzoA = txtDescAlmuerzoA.Text;
			string horaTardeA = txtHoraTardeA.Text.ToString();
			string descTardeA = txtDescTardeA.Text;
			string horaCenaA = txtHoraCenaA.Text.ToString();
			string descCenaA = txtDescCenaA.Text;
			string horaColacA = txtHoraColacionA.Text.ToString();
			string descColacA = txtDescColacionA.Text;



		}

		protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BL.PrimerIngreso ingreso = new BL.PrimerIngreso();


            //Datos personales

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
            int consumeLicor = int.Parse(DropLicor.SelectedValue);
            int fuma = int.Parse(DropFuma.SelectedValue);
            string frecFuma = txtFrecFuma.Text;
            string frecLicor = txtFrecLicor.Text;
            string ultimoExamen = fechaExam.Value;
            string actividadFisica = txtActividadFisica.Text;

            HistorialMedico historial = new HistorialMedico(cedula, antecedentes, patologias, consumeLicor, fuma, frecFuma, frecLicor, ultimoExamen, actividadFisica);



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