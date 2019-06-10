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
        ManejadorSeguimientos manejadorNutrición = new ManejadorSeguimientos();
        protected void Page_Load(object sender, EventArgs e)
        {
                 
        }

        
        protected void btnAgreg_Click(object sender, EventArgs e)
        {

            if (sPeso.Text.Equals("") || sOreja.Text.Equals("") || sEjercicio.Text.Equals(""))
            {
                Response.Write("<script>alert('No deben haber espacios en blanco')</script>");
            }
            else
            {
                bool creado = true;//manejadorNutrición.AgregarSeguimiento(new SeguimientoSemanal(listaSeguimientos.Count, DateTime.Now, Convert.ToDecimal(sPeso.Text), sOreja.Text, sEjercicio.Text, " "));
                if (creado)
                {

                    if (listaSeguimientos != null)
                    {
                        listaSeguimientos.Add(new SeguimientoSemanal(contPrueba  + 1, DateTime.Now.Date, Convert.ToDecimal(sPeso.Text), sOreja.Text, sEjercicio.Text, ""));
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