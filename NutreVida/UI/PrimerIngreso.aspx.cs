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
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            BL.PrimerIngreso ingreso = new BL.PrimerIngreso();


            //Datos personales

            int cedula = int.Parse(txtCed.Text);

            string correo = txtEmail.Text;
            string nombre = txtNombre.Text;
            //string apellido1 = txtApellido1.text;
            //string apellido2 = txtApellido2.text;
            string fecha_Nacimiento = iFechaNac.Value;
            char sexo = char.Parse(dropSexo.SelectedValue);
            //string estado_Civil = txtEstadoCivil.text;
            char whatsApp = char.Parse(dropWhats.SelectedValue);
            int telefono = int.Parse(txtTel.Text);
            string residencia = txtResid.Text;
            string ocupacion = txtOcup.Text;
            DateTime fechaHoy = DateTime.Now;
            string fechaIngreso = fechaHoy.ToString("d");


            //ingreso.CrearCliente(cedula, correo, nombre, apellido1, apellido2, fecha_Nacimiento, sexo, estado_Civil, whatsApp, telefono, residencia, ocupacion, fechaIngreso);


            //Historial medico

            string antecedentes = txtAntec.Text; ;
            string patologias = txtPatol.Text;
            int consumeLicor = int.Parse(DropLicor.SelectedValue);
            int fuma = int.Parse(DropFuma.SelectedValue);
            string frecFuma = txtFrecFuma.Text;
            string frecLicor = txtFrecLicor.Text;
            string ultimoExamen = fechaExam.Value;
            //string actividadFisica = txtActividadFisica.text;

        }
    }
}