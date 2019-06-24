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
            lista = manejador.ListaClientes();
           foreach (ClienteNutricion cl in lista)
            {
                TableRow r = new TableRow();
                TableCell c = new TableCell();
                LinkButton cedBoton = new LinkButton();
                cedBoton.Text = cl.Cedula + "";
                cedBoton.CommandArgument = cl.Cedula+"";
                cedBoton.OnClientClick = "Redirigir_Click";
                c.Controls.Add(cedBoton);
                r.Cells.Add(c);
                
                TableCell c2 = new TableCell();
                c2.Controls.Add(new LiteralControl(cl.Nombre + " " + cl.Apellido1 + " " + cl.Apellido2));
                r.Cells.Add(c2);

                
                TableCell c3 = new TableCell();
                LinkButton ElimBoton = new LinkButton();
                ElimBoton.Text = "Eliminar";
                ElimBoton.CommandArgument = cl.Cedula + "";
                ElimBoton.Click += new EventHandler(EliminarCliente);
                c3.Controls.Add(ElimBoton);
                r.Cells.Add(c3);

                dataTable.Rows.Add(r);
            }
            
            //LitListaCliente.Text = "";
            //lista = manejador.ListaClientes();
            //if (lista != null)
            //{
            //    foreach (ClienteNutricion c in lista)
            //    {
            //        LitListaCliente.Text += "<tr>" +
            //            "<td><asp:LinkButton runat=\"server\" Enabled=\"true\" CommandArgument=\"" + c.Cedula+"\" ID=\"R"+c.Cedula+ "\" OnClick=\"Redirigir_Click\">" + c.Cedula + "</asp:LinkButton></td>" +
            //             "<td>" +c.Nombre +" "+c.Apellido1+"</td>"+
            //             "<td><a href=\"\" onclick=\"Eliminar_Click(" + c.Cedula+ ")\">Eliminar</a></td></tr>";
            //    }

            //}
        }
        //[System.Web.Services.WebMethod]
        public void EliminarCliente(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;
            Console.Write("Funciona "+ yourValue);
        }
       

        public void Redirigir_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;
            Session["ced"] = yourValue;
            Response.Redirect("Cliente.aspx");
        }
    }
}