using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
    public partial class Cliente : System.Web.UI.Page
    {
        
        private string Cedula = "";
        private static List<SeguimientoSemanal> listaSeguimientos = new List<SeguimientoSemanal>();
        private static ManejadorSeguimientos manejadorSeg = new ManejadorSeguimientos();
        private static ManejadorErrores manejError = new ManejadorErrores();
        protected void Page_Load(object sender, EventArgs e)
        {
            Cedula = Convert.ToString(Request.QueryString["Cedula"]);
            ced1.Text = Cedula;
            if (!IsPostBack)
            {
                if (Cedula != "")
                {
                    CargarSeguimientoSemanal(Convert.ToInt32(Cedula));
                }
            }
           

        }
        public void CargarSeguimientoSemanal(int ced)
        {
            
            listaSeguimientos = manejadorSeg.TraerLista(ced);
            if (listaSeguimientos != null)
            {
               
                foreach (SeguimientoSemanal seg in listaSeguimientos)
                {
                    LitSeguimiento.Text += "<tr><td>" + seg.Sesion + "</td><td>" + seg.Fecha.ToString("dd/MM/yyyy") + "</td><td>" + seg.Peso + "</td><td>" + seg.Oreja + "</td><td>" + seg.Ejercicio + "</td></tr>";
                }
                
            }
            else
            {
                LitSeguimiento.Text = "No existen Seguimientos Semanales de este usuario.";
            }
        
        }

        protected void btnAgreg_Click(object sender, EventArgs e)
        {
            decimal peso = 0;
            if (sPeso.Text.Equals("") || sOreja.Text.Equals("") || sEjercicio.Text.Equals(""))
            {
                Response.Write("<script>alert('No deben haber espacios en blanco')</script>");
            }
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
    }
}