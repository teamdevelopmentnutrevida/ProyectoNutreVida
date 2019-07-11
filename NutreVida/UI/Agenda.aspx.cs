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
    public partial class WebForm1 : System.Web.UI.Page
    {

        public String Json;

        protected void Page_Load(object sender, EventArgs e)
        {
            ManejadorEvento maneja = new ManejadorEvento();
            String url = Server.MapPath("~/");
            maneja.ListaEvento(url);
            //string ruta = "C:\\Users\tanni\\Desktop\\Ingeniería\\Proyecto Ingeniería\\NutreVida\\UI\\common\\Eventos.json";
            //string contenido = "";
            //File.WriteAllText(ruta, contenido);

            //Json = ManejadorEvento.Json;
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }
    }
}