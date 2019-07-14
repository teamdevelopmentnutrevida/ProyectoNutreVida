using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
    /**
    * Clase Expediente, muestra una lista con los clientes que poseen expediente.
    * @author Yoselyn
   */
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

            CargarLista();
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
                    
                    string est = "";
                    if(c.Estado == 1) {
                        est = "<a href =\"\" onclick=\"Eliminar_Click(" + c.Cedula + ")\">Deshabilitar</a></td>";
                        LitListaCliente.Text += "<tr>" +
                       "<td><a href=\"\" onclick=\"Redirige(" + c.Cedula + ")\">" + c.Cedula + "</a></td>" +
                            "<td>" + c.Nombre + " " + c.Apellido1 + "</td>" +
                         "<td>" + est + "</tr>";
                    }
                    //else
                    //{
                    //    est = "<a href =\"\" onclick=\"Habilitar(" + c.Cedula + ")\">Habilitar</a></td>";
                    //}

                    
                }
                
            }
        }

        /**
         * Método WEB público y estático, es el evento de seleccionar el boton de deshabilitar 
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
         * Método WEB público y estático, es el evento de seleccionar el boton de habilitar 
         * @param acciones y eventos del boton
         */
        [System.Web.Services.WebMethod]
        public static void HabilitarCliente(string ced)
        {
            bool exito = manejador.HabilitarCliente(ced);
            
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

        protected void NuevoCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrimerIngreso.aspx");
        }
    }
}