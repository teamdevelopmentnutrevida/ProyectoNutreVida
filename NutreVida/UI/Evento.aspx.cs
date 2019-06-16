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

        public string value = "";
        

        protected void Page_Load(object sender, EventArgs e)
        {
            value = Request.QueryString["Valor"];

            String fecha = "";

            String[] fechaDividida = value.Split('-');
            foreach (String x in fechaDividida) {
                if (x.Count() == 2)
                {

                    fecha += "-" + x;
                }
                else if(x.Count() == 1) {

                    fecha += "-0" + x;
                }
                else
                    fecha += x;

            }

            iFecha.Value = fecha;
            llenarDrop(DropDownList1);
            llenarDrop(DropDownList2);
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
            string fecha = value;
            //agenda.GuardarEvento(evento, descripcion, droInicio, driFin, fecha);
        }
    }
}