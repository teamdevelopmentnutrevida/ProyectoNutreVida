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
        ManejadorExpediente manejador = new ManejadorExpediente();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                CargarLista();
            }
		}

        private void CargarLista()
        {
            LitListaCliente.Text = "";
            lista = manejador.ListaClientes();
            if (lista != null)
            {
                foreach (ClienteNutricion c in lista)
                {
                 
                    LitListaCliente.Text += "<tr>" +
                        "<td><asp:LinkButton runat=\"server\" Enabled=\"true\" CommandArgument=\"" + c.Cedula+"\" ID=\"R"+c.Cedula+ "\" OnClick=\"Redirigir_Click\">" + c.Cedula + "</asp:LinkButton></td>" +
                         "<td>" +c.Nombre +" "+c.Apellido1+"</td>"+
                         "<td><a href=\"\" onclick=\"Eliminar_Click(" + c.Cedula+ ")\">Eliminar</a></td></tr>";
                }

            }
        }
        [System.Web.Services.WebMethod]
        public static void EliminarCliente(string ced)
        {
            Console.Write("Funciona");
        }
        private void Deshabilitar(string ced)
        {

        }

        protected void Redirigir_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;
            Session["ced"] = yourValue;
            Response.Redirect("Cliente.aspx");
        }
    }
}