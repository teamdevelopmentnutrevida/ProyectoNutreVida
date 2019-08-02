using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
	public partial class Notificacion : System.Web.UI.Page
	{

		private List<ClienteNutricion> lista = new List<ClienteNutricion>();
		public static ManejadorExpediente manejador = new ManejadorExpediente();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (new ControlSeguridad().validarNutri() == true)
			{
				Response.Redirect("~/InicioSesion.aspx");


			}

			CargarLista();
		}



		private void CargarLista()
		{
			DateTime hoy = DateTime.Now.Date;
			String msj = "Buenas, es para confirmar su evaluación de nutrición. Recuerde no comer ni beber 1 hora antes y asistir con ropa liviana.. Se le recuerda que este día ya corresponde el pago de mensualidad. Saludos!";
			LitListaCliente.Text = "";
			lista = manejador.ListaClientes();
			if (lista != null)
			{
				foreach (ClienteNutricion c in lista)
				{

					string est = "";
					DateTime mensual = c.FechaIngreso.Date;
					if (mensual >= hoy)
					{
						LitListaCliente.Text += "<tr>" +
					   "<td><a>" + c.Nombre + " " + c.Apellido1 + "</a></td>" +
							"<td>" + c.FechaIngreso + "</td>" +
						"<td>" + "<a target=\"_blank\" href=\"https://wa.me/506" + c.Telefono + "?text=" + msj + "\">Enviar Mensaje</a> </td></tr>";
					}

				}

			}
		}


	}
}