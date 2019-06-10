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
        private int contPrueba = 0;
        private static List<SeguimientoSemanal> listaSeguimientos = null;
        ManejadorSeguimientos manejadorSeg = new ManejadorSeguimientos();
        ManejadorErrores manejError = new ManejadorErrores();
        protected void Page_Load(object sender, EventArgs e)
        {
                 
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
                    Response.Write("<script>alert('"+y +"')</script>");
                    peso = 0;
                    
                }
                bool creado = manejadorSeg.AgregarSeguimiento(new SeguimientoSemanal(listaSeguimientos.Count, DateTime.Now, Convert.ToDecimal(sPeso.Text), sOreja.Text, sEjercicio.Text, " "));
                if (creado)
                {

                    if (listaSeguimientos != null)
                    {
                        listaSeguimientos.Add(new SeguimientoSemanal(contPrueba  + 1, DateTime.Now.Date, peso, sOreja.Text, sEjercicio.Text, ""));
                        LitSeguimiento.Text += "<tr><td>" + (contPrueba + "</td><td>" + DateTime.Now + "</td><td>" + sPeso.Text + "</td><td>" + sOreja.Text + "</td><td>" + sEjercicio.Text + "</td></tr>");
                    }
                    else
                    {
                        listaSeguimientos = new List<SeguimientoSemanal>();
                        listaSeguimientos.Add(new SeguimientoSemanal(1, DateTime.Now.Date, Convert.ToDecimal(sPeso.Text), sOreja.Text, sEjercicio.Text,""));
                        LitSeguimiento.Text += "<tr><td>" + 1 + "</td><td>" + DateTime.Now + "</td><td>" + sPeso.Text + "</td><td>" + sOreja.Text + "</td><td>" + sEjercicio.Text + "</td></tr>";

                    }
                }
            }
            sPeso.Text = string.Empty; sOreja.Text = string.Empty; sEjercicio.Text = string.Empty;
        }
    }
}