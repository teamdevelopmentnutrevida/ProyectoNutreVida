using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class Evento : System.Web.UI.Page
    {

        public Object value = "";
        string val = "";
        BL.Evento evento = new BL.Evento();
        public ManejadorEvento agenda = new ManejadorEvento();

        protected void Page_Load(object sender, EventArgs e)
        {
            value = Request.QueryString["Valor"];

            if (value.Equals("BL.Evento")) // hacer validacion
            {
                evento = (BL.Evento)value;
            }
            else {
                val = value.ToString();
                string fecha = formatoFecha(val);
                iFecha.Value = fecha;
            }
           
            llenarDrop(DropDownList1);
            llenarDrop(DropDownList2);
        }


        public string formatoFecha(string fechaPre) {
            string fechaNue = "";

            String[] fechaDividida = fechaPre.Split('-');
            foreach (String x in fechaDividida)
            {
                if (x.Count() == 2)
                {

                    fechaNue += "-" + x;
                }
                else if (x.Count() == 1)
                {

                    fechaNue += "-0" + x;
                }
                else
                    fechaNue += x;

            }
            return fechaNue;
        }


        public void llenarDrop(DropDownList drop)
        {
            drop.Items.Add("12:00 am");
            drop.Items.Add("12:30 am");
            drop.Items.Add("1:00 am");
            drop.Items.Add("1:30 am");
            drop.Items.Add("2:00 am");
            drop.Items.Add("2:30 am");
            drop.Items.Add("3:00 am");
            drop.Items.Add("3:30 am");
            drop.Items.Add("4:00 am");
            drop.Items.Add("4:30 am");
            drop.Items.Add("5:00 am");
            drop.Items.Add("5:30 am");
            drop.Items.Add("6:30 am");
            drop.Items.Add("7:00 am");
            drop.Items.Add("7:30 am");
            drop.Items.Add("8:00 am");
            drop.Items.Add("8:30 am");
            drop.Items.Add("9:00 am");
            drop.Items.Add("9:30 am");
            drop.Items.Add("10:00 am");
            drop.Items.Add("10:30 am");
            drop.Items.Add("11:00 am");
            drop.Items.Add("11:30 am");
            drop.Items.Add("12:00 pm");
            drop.Items.Add("12:30 pm");
            drop.Items.Add("1:00 pm");
            drop.Items.Add("1:30 pm");
            drop.Items.Add("2:00 pm");
            drop.Items.Add("2:30 pm");
            drop.Items.Add("3:00 pm");
            drop.Items.Add("3:30 pm");
            drop.Items.Add("4:00 pm");
            drop.Items.Add("4:30 pm");
            drop.Items.Add("5:00 pm");
            drop.Items.Add("5:30 pm");
            drop.Items.Add("6:00 pm");
            drop.Items.Add("6:30 pm");
            drop.Items.Add("7:00 pm");
            drop.Items.Add("7:30 pm");
            drop.Items.Add("8:00 pm");
            drop.Items.Add("8:30 pm");
            drop.Items.Add("9:00 pm");
            drop.Items.Add("9:30 pm");
            drop.Items.Add("10:00 pm");
            drop.Items.Add("10:30 pm");
            drop.Items.Add("11:00 pm");
            drop.Items.Add("11:30 pm");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void buttonEnviar_Click(object sender, EventArgs e)
        {
            string evento = txtEvento.Text;
            string descripcion = txtDescripcion.Text;
            string droInicio = DropDownList1.SelectedValue;
            string driFin = DropDownList2.SelectedValue;
            string fecha = val;
            agenda.guardarEvento(evento, descripcion, droInicio, driFin, fecha);
            Response.Redirect("Agenda.aspx");
        }
    }
}