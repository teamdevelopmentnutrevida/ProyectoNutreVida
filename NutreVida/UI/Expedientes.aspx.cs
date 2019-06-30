using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
    public partial class Expedientes : System.Web.UI.Page
    {
     
        private List<ClienteNutricion> lista = new List<ClienteNutricion>();
        public static ManejadorExpediente manejador = new ManejadorExpediente();
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

        /**
         * Método privado, que carga la lista de clientes en la tabla.
         */
        private void CargarLista()
        {
            LitListaCliente.Text = "";
            lista = manejador.ListaClientes();
            if (lista != null)
            {
                foreach (ClienteNutricion c in lista)
                {
                    LitListaCliente.Text += "<tr>" +
                       "<td><a href=\"\" onclick=\"Redirige(" + c.Cedula + ")\">" + c.Cedula + "</a></td>" +
                            "<td>" + c.Nombre + " " + c.Apellido1 + "</td>" +
                         "<td><a href=\"\" onclick=\"Eliminar_Click(" + c.Cedula + ")\">Deshabilitar</a></td></tr>";
                }
                
            }
        }

        /**
         * Método WEB público y estático, es el evento de seleccionar la 
         * @param acciones y eventos del boton
         */
        [System.Web.Services.WebMethod]
        public static void EliminarCliente(string ced)
        {
            bool exito = manejador.EliminarCliente(ced);
            
            //LinkButton btn = (LinkButton)(sender);
            //string yourValue = btn.CommandArgument;
            //Console.Write("Funciona "+ yourValue);
        }

        /**
         * Método WEB público y estático, es el evento de seleccionar la cedula del cliente el cual redirige a la información del expediente
         * @param acciones y eventos del boton
         */
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static void Redirigir_Click(string ced)
        {
            HttpContext.Current.Session["ced"] = ced;
         }
        
        
    }
}