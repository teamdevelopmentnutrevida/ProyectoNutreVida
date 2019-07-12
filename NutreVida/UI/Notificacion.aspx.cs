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
			//if (new ControlSeguridad().validarNutri() == true)
			//{
			//	Response.Redirect("~/InicioSesion.aspx");


			//}

			CargarLista();
			//Fecha.Text = "Fecha del Servidor: " + DateTime.Now;
		}


		private void CargarLista()
		{
			DateTime hoy = DateTime.Now.Date;
			String msj = "Recordatorio de pago";
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
						//est = "<a href =\"\" onclick=\"Eliminar_Click(" + c.Nombre + c.Apellido1 + ")\">Deshabilitar</a></td>";
						LitListaCliente.Text += "<tr>" +
					   "<td><a>" + c.Nombre + " " + c.Apellido1 + "</a></td>" +
							"<td>" + c.FechaIngreso + "</td>" +
						"<td>" + "<a href=\"https://wa.me/506" + c.Telefono + "?text=" + msj + "\">Enviar Mensaje</a> </td></tr>";
					}

				}

			}
		}


	}
}