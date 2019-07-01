using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Newtonsoft.Json;

namespace UI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public ManejadorEvento blObjeto = new ManejadorEvento();
        private Evento product = new Evento("2", "2019-06-05 00:00:00", "2019-06-06 00:00:00", "Cita", "Philippe-Chatrier Court\n Paris, FRA");
        public string json = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //  eventos = blObjeto.cargarDatos();
            string json = JsonConvert.SerializeObject(product);

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }
    }
}