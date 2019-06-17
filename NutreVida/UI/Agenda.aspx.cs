using BL;
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
        ManejadorEvento manejador = new ManejadorEvento();
        List<BL.Evento> lista = new List<BL.Evento>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLista();
            }
        }

        private void CargarLista()
        {
            LitListaEventos.Text = "";
            lista = manejador.ListaEvento(fechaActual());
            if (lista != null)
            {
                foreach (BL.Evento c in lista)
                {

                    LitListaEventos.Text += "<tr><td> " + c.horaInicio + "-" + c.horaFin + "</a></td>" +
                         "<td>" + c.nombreEvento + "</td>" + "<td>" + c.decripcionEvento + "</td>" +
                         "<td>" +
                         "<ul class=\"navbar-nav ml-auto\"><li class=\"nav-item dropdown\">" +
                         "<a class=\"dropdown-toggle\" href=\"#\" id=\"" + "drop" + c.nombreEvento + "\" role=\"button\" data-toggle=\"dropdown\" ></a>" +
                         "<ul class=\"dropdown-menu\" role=\"menu\">" +
                         "<li class=\"dropdown-item\" onclick=\"href='#'\">Eliminar</li>" +
                         "<li class=\"dropdown-item\" onclick=\"ModificarEvento(" + c.nombreEvento + ", " + c.fecha + ")\">Modificar</li>" +
                         "</ul></li></ul></td></tr>";
                }

            }
        }


        private void EliminarEvento(string nombre, string fecha)
        {
            manejador.eliminarEvento(nombre, fecha);
        }
        private void ModificarEvento(string nombre, string fecha)
        {

        }

        protected void btnAgregarEvento_Click(object sender, EventArgs e)
        {
            string valor = fechaActual();
            Response.Redirect("Evento.aspx?Valor=" + valor);
        }

        public string fechaActual() {
            string dia = DateTime.Now.Day + "";
            string mes = DateTime.Now.Month + "";
            string anno = DateTime.Now.Year + "";
            string valor = anno + "-" + mes + "-" + dia;
            return valor;
        }
    }
}