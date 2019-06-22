using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
    /**
     * Client Class, shows the information of the file and manage the button´s action.
     * @author Yoselyn
    */
    public partial class Cliente : System.Web.UI.Page
    {
        
        private string Cedula = "";
        private static List<SeguimientoSemanal> listaSeguimientos = new List<SeguimientoSemanal>();
        private static ManejadorSeguimientos manejadorSeg = new ManejadorSeguimientos();
        private static ManejadorExpediente manejExpediente = new ManejadorExpediente();
        private static ManejadorErrores manejError = new ManejadorErrores();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();

            }
           
        }

        private void CargarDatos()
        {
            Cedula = (string)Session["ced"];
            CargarInfoPersonal();
        }

        /**
        * Método publico que carga la seccion de la información personal del cliente seleccionado 
        * @param ced, cedula del cliente
        */
        
        private void CargarInfoPersonal()
        {
            if (Cedula != "")
            {
                ClienteNutricion c = manejExpediente.TraerInformación(Cedula);
                if (c != null)
                {
                    ced1.Text = c.Cedula + "";
                    txtOcup.Text = c.Ocupacion;
                    txtTel.Text = c.Telefono + "";
                    ConsultDropList.Text = c.Consultorio;
                    txtNombre.Text = c.Nombre;
                    txtEmail.Text = c.Correo;
                    if (c.WhatsApp == '1') { dropWhats.Text = "Sí"; } else { dropWhats.Text = "No"; }
                    EdadCliente.Text = CalcularEdad(c.Fecha_Nacimiento);
                    txtPrimerApellido.Text = c.Apellido1;
                    dropEstadoCivil.Text = c.Estado_Civil;
                    txtResid.Text = c.Residencia;
                    FechIngreso.Text = c.FechaIngreso.Day+" / "+c.FechaIngreso.Month+" / "+c.FechaIngreso.Year;
                    txtSegundoApellido.Text = c.Apellido2;
                    if (c.Sexo == 'F') { dropSexo.Text = "Femenino"; } else { if (c.Sexo == 'M') { dropSexo.Text = "Masculino"; } else { dropSexo.Text = "Otro"; } }
                    FechNacimi.Text = c.Fecha_Nacimiento.Day + " / " + c.Fecha_Nacimiento.Month + " / " + c.Fecha_Nacimiento.Year;
                }
                
            }
        }
        private string CalcularEdad(DateTime fechaNac)
        {
            if (fechaNac.Equals("")) { return "";}
            else
            {
                 int años = DateTime.Now.Year - fechaNac.Year;
                if (fechaNac.Month > DateTime.Now.Month) { return años - 1 + "";}
                else{
                    if (fechaNac.Month == DateTime.Now.Month)
                    {
                        if (fechaNac.Day < DateTime.Now.Day) { return años - 1 + ""; }
                        else { return años + ""; }
                    }
                    else { return años + ""; }
                }
            }
        }
        public void CargarHistorialMedico() { }
        public void CargarHabitosAlimentarios() { }
        public void CargarAntropometría() { }


        /**
        * Método publico que carga la lista del seguimiento semanal del cliente seleccionado 
        * @param ced, cedula del cliente
        */
        public void CargarSeguimientoSemanal(int ced)
        {
            listaSeguimientos = manejadorSeg.TraerLista(ced);
            if (listaSeguimientos != null){
                foreach (SeguimientoSemanal seg in listaSeguimientos) {
                    LitSeguimiento.Text += "<tr><td>" + seg.Sesion + "</td><td>" + seg.Fecha.ToString("dd/MM/yyyy") + "</td><td>" + seg.Peso + "</td><td>" + seg.Oreja + "</td><td>" + seg.Ejercicio + "</td></tr>";} 
            }
            else{LitSeguimiento.Text = "No existen Seguimientos Semanales de este usuario.";}
        }
        /**
        * Método protegido Es la accion del boton agregar seguimientos semanales
        * @param acciones y eventos del boton
        */
        protected void btnAgreg_Click(object sender, EventArgs e)
        {
            decimal peso = 0;
            if (sPeso.Text.Equals("") || sOreja.Text.Equals("") || sEjercicio.Text.Equals(""))
            { Response.Write("<script>alert('No deben haber espacios en blanco')</script>"); }
            else
            {
                try
                {
                    peso= Convert.ToDecimal(sPeso.Text);
                }
                catch (FormatException)
                {
                    string y = manejError.ErrorIngresoNumero();
                    Response.Write(y);
                    peso = 0;
                    
                }

                bool creado = manejadorSeg.AgregarSeguimiento(new SeguimientoSemanal(DateTime.Now, Convert.ToDecimal(sPeso.Text), sOreja.SelectedValue, sEjercicio.Text, int.Parse(ced1.Text)));
                if (creado)
                {

                    if (listaSeguimientos != null)
                    {
                        listaSeguimientos.Add(new SeguimientoSemanal(listaSeguimientos[listaSeguimientos.Count - 1].Sesion + 1, DateTime.Now.Date, peso, sOreja.Text, sEjercicio.Text, int.Parse(ced1.Text)));
                        LitSeguimiento.Text += "<tr><td>" + (listaSeguimientos[listaSeguimientos.Count - 1].Sesion) + "</td><td>" + DateTime.Now.Date + "</td><td>" + sPeso.Text + "</td><td>" + sOreja.Text + "</td><td>" + sEjercicio.Text + "</td></tr>";
                    }
                    else
                    {
                        listaSeguimientos = new List<SeguimientoSemanal>();
                        listaSeguimientos.Add(new SeguimientoSemanal(1, DateTime.Now.Date, Convert.ToDecimal(sPeso.Text), sOreja.Text, sEjercicio.Text,int.Parse(ced1.Text)));
                        LitSeguimiento.Text += "<tr><td>" + 1 + "</td><td>" + DateTime.Now.Date + "</td><td>" + sPeso.Text + "</td><td>" + sOreja.Text + "</td><td>" + sEjercicio.Text + "</td></tr>";

                    }
                }
            }
            sPeso.Text = string.Empty; sOreja.Text = string.Empty; sEjercicio.Text = string.Empty;
        }
        /**
        * Método protegido, accion para habilitar o no el espacio de la frecuencia del consumo de licor 
        * @param acciones y eventos del boton
        */
        protected void DropLicor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropLicor.SelectedValue == "Sí")
            {
                txtFrecLicor.Enabled = true;
            }
            else
            {
                txtFrecLicor.Enabled = false;
            }
        }
        /**
        * Método protegido, accion para habilitar o no el espacio de la frecuencia de fumar
        * @param acciones y eventos del boton
        */
        protected void DropFuma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropFuma.SelectedValue == "Sí")
            {
                txtFrecFuma.Enabled = true;
            }
            else
            {
                txtFrecFuma.Enabled = false;
            }
        }


        protected void OkButton_Click(object sender, EventArgs e)
        {
           
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {

        }

        protected void MedicButton_Click(object sender, EventArgs e)
        {

        }
    }
}