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
                 
                    LitListaCliente.Text += "<tr><td><a href=\"Cliente.aspx?Cedula="+c.Cedula+"\">"+c.Cedula+"</a></td>" +
                         "<td>"+c.Nombre +" "+c.Apellido1+"</td>"+
                         "<td>" +
                         "<ul class=\"navbar-nav ml-auto\"><li class=\"nav-item dropdown\">"+
                         "<a class=\"dropdown-toggle\" href=\"#\" id=\""+"drop"+c.Cedula+"\" role=\"button\" data-toggle=\"dropdown\" ></a>"+
                         "<ul class=\"dropdown-menu\" role=\"menu\">"+
                         "<li class=\"dropdown-item\" onclick=\"EliminarCliente("+c.Cedula+")\">Eliminar</li>"+
                         "<li class=\"dropdown-item\" onclick=\"Deshabilitar("+c.Cedula+")\">Deshabilitar</li>"+
                         "</ul></li></ul></td></tr>";
                }

            }
        }

        private void EliminarCliente(string ced)
        {

        }
        private void Deshabilitar(string ced)
        {

        }


    }
}