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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BL.PrimerIngreso ingreso = new BL.PrimerIngreso();

            //int cedula = int.Parse(txtCed.Text);
            //string correo = txtEmail.Text;
            //string nombre = txtNombre.Text;
            //string apellido1 = txtApellido1.text;
            //string apellido2 = txtApellido.text;
            //DateTime fecha_Nacimiento = txtFechaN.text;
            //char sexo = char.Parse(dropSexo.SelectedValue);
            //string estado_Civil = txtEstadoCivil.text;
            //char whatsApp = char.Parse(dropWhats.SelectedValue);
            //int telefono = int.Parse(txtTel.Text);
            //string residencia = txtResid.Text;
            //string ocupacion = txtOcup.Text;
            //DateTime fechaIngreso ;


            //ingreso.CrearCliente()
        }
    }
}