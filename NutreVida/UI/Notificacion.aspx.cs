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
			LitListaCliente.Text = "";
			lista = manejador.ListaClientes();
			if (lista != null)
			{
				foreach (ClienteNutricion c in lista)
				{

					string est = "";
					if (c.Estado == 1)
					{
						//est = "<a href =\"\" onclick=\"Eliminar_Click(" + c.Nombre + c.Apellido1 + ")\">Deshabilitar</a></td>";
						LitListaCliente.Text += "<tr>" +
					   "<td><a href=\"\" onclick=\"Redirige(" + c.Cedula + ")\">" + c.Cedula + "</a></td>" +
							"<td>" + c.Nombre + " " + c.Apellido1 + "</td>" +
						 "<td>" + est + "</tr>";
					}

				}

			}
		}


	}
}