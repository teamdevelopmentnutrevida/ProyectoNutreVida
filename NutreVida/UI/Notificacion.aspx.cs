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
		private ManejadorExpediente manej = new ManejadorExpediente();

		protected void Page_Load(object sender, EventArgs e)
		{
			//if (new ControlSeguridad().validarNutri() == true)
			//{
			//	Response.Redirect("~/InicioSesion.aspx");


			//}

			CrearTablaDatos();
			Fecha.Text = "Fecha del Servidor: " + DateTime.Now;
		}

		private void CrearTablaDatos()
		{
			String msj = "Gimnasio%20Vital%20le%20recuerda%20que%20su%20mensualidad%20ha%20vencido.%20Gracias.";
			List<ClienteNutricion> listaCliente = manej.ListaClientes();
			if (listaCliente != null)
			{
				DateTime hoy = DateTime.Now.Date;
				Notif.Text = "<thead> <tr class=\"w3-light-grey\">" +
							  "<th>Cliente</th><th>FechaPago</th><th>Eviar Mensaje</th> </tr> </thead>";
				foreach (ClienteNutricion cliente in listaCliente)
				{
					DateTime mensual = cliente.FechaIngreso.Date;
					if (mensual >= hoy)
					{

						Notif.Text += "<tr><td>" + cliente.Nombre + cliente.Apellido1 + "</td>" +
							"<td>" + cliente.FechaIngreso + "</td>" +
							"<td>" + "<a href=\"https://wa.me/506" + cliente.Telefono + "?text=" + msj + "\">Enviar Mensaje</a> </td></tr>";
					}
				}
				}
	}
	}
}