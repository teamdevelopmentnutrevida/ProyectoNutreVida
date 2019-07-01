using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            
            //Json = ManejadorEvento.Json;
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reportes.aspx");
        }
    }
}