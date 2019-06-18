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
                 
                    LitListaCliente.Text += "<tr><td onclick=\"CargarCliente()\"><a href=\"\" onclick=\"CargarCliente()\"> "+c.Cedula+"</a></td>" +
                         "<td>"+c.Nombre +" "+c.Apellido1+"</td>"+
                         "<td><a href=\"\" onclick=\"EliminarCliente("+c.Cedula+")\">Eliminar<a>" +
                        "</td></tr>";
                }

            }
        }

        private void EliminarCliente(string ced)
        {
            Response.Write(ced+"prueba eliminar");
        }
        private void Deshabilitar(string ced)
        {

        }

        protected void hyperlink1_Click(object sender, EventArgs e,string r)
        {
            string ced = r;
            Response.Write(ced + "prueba eliminar");

        }
    }
}