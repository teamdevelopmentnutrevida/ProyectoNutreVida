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
        public static ManejadorEvento manejador = new ManejadorEvento();
        List<BL.Evento> lista = new List<BL.Evento>();
        protected void Page_Load(object sender, EventArgs e)
        {
			if (new ControlSeguridad().validarNutri() == true)
			{
				Response.Redirect("~/InicioSesion.aspx");


			}

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

                    LitListaEventos.Text += "<tr><td> " + c.horaInicio + "-" + c.horaFin + "</td>" +
                         "<td>" + c.nombreEvento + "</td>" + "<td>" + c.decripcionEvento + "</td>" +
                         "<td>" +
                         "<ul class=\"navbar-nav ml-auto\"><li class=\"nav-item dropdown\">" +
                         "<a class=\"dropdown-toggle\" href=\"#\" id=\"" + "drop" + c.nombreEvento + "\" role=\"button\" data-toggle=\"dropdown\" ></a>" +
                         "<ul class=\"dropdown-menu\" role=\"menu\">" +
                        "<div><li class=\"dropdown-item\" onclick=\"Eliminar_Click('" + c.nombreEvento + "', '" + c.fecha + "')\">Eliminar</li> </div>" +
                         "<li class=\"dropdown-item\" onclick=\" ModificarEvento('" + c.nombreEvento + "', '" + c.decripcionEvento + "', '" + c.horaInicio + "', '" + c.horaFin + "', '" + c.fecha + ")\">Modificar </li>" +
                         "</ul></li></ul></td></tr>";
                }

            }
        }


        [System.Web.Services.WebMethod]
        public static void EliminarEvento(string nombre, string fecha)
        {
            manejador.eliminarEvento(nombre, fecha);

        }
        private void ModificarEvento(string nombre, string descripcion, string horaInicio, string horaFin, string fecha)
        {
            BL.Evento evento = new BL.Evento(nombre, descripcion, horaInicio, horaFin, fecha);
            Response.Redirect("Evento.aspx?Valor=" + evento);
            manejador.modificarEvento(nombre, descripcion, horaInicio, horaFin, fecha);
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