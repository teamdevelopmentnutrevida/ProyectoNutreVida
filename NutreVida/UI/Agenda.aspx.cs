using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class Agenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarEvento_Click(object sender, EventArgs e)
        {
            string dia = DateTime.Now.Day + "";
            string mes = DateTime.Now.Month + "";
            string anno = DateTime.Now.Year + "";
            string valor = anno + "-" + mes + "-" + dia;

            Response.Redirect("Evento.aspx?Valor=" + valor);
        }
    }
}