using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BL;

namespace UI
{

    /**
     * Clase Agenda, muestra la agenda del consultorio bajo 3 distintas vistas: semana, mes y día y permite crear eventos.
     * @author Tannia
    */
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {          

            ManejadorEvento maneja = new ManejadorEvento();

            if (IsPostBack)
            {
                string json = txtJson.Value;

                if (json.Contains("{"))
                {
                    maneja.guardarEvento(json);
                }
                else
                    maneja.eliminarEvento(json);          
                
            }
            
            String url = Server.MapPath("~/");
            maneja.ListaEvento(url);
            
        }

        /**
        * Método protegido cuya función es el evento del botón btn1
        * @param object, sender
        * @param EventArgs, e
        */
        protected void btn1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }
    }
}