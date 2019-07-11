using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;


namespace UI
{

    public partial class Reportes : System.Web.UI.Page
    {
        /**
        * Clase Reportes, muestra los principales reportes sobre los clientes registrados en el sistema
        * @author Diego
        */

        //Atributos clasificacion IMC
        public int Insuficiencia = 0;
        public int Normal = 0;
        public int Sobrepeso = 0;
        public int ObesidadI = 0;
        public int ObesidadII = 0;
        public int ObesidadIII = 0;

        //Cantidad sexo
        public int F = 0;
        public int M = 0;

        //Edad por la que se va a filtrar los reportea 
        public static int edad1 = 0;
        public static int edad2 = 100;

        protected void Page_Load(object sender, EventArgs e)
        {
			if (new ControlSeguridad().validarNutri() == true)
			{
				Response.Redirect("~/InicioSesion.aspx");


			}
		
			BL.Reportes report = new BL.Reportes();

            lbMenor20.Text = (report.obtenerPromedioPesoEdad(0, 20).Contains(",") || report.obtenerPromedioPesoEdad(0, 20).Contains(".") ? decimal.Parse(report.obtenerPromedioPesoEdad(0, 20)).ToString("N2") : report.obtenerPromedioPesoEdad(0, 20)) + " kg";

            lbCantidadMenor20.Text = report.obtenerCantidadPersonasEdad(0, 20) + "";

            lb20_30.Text = (report.obtenerPromedioPesoEdad(20, 30).Contains(",") || report.obtenerPromedioPesoEdad(20, 30).Contains(".") ? decimal.Parse(report.obtenerPromedioPesoEdad(20, 30)).ToString("N2") : report.obtenerPromedioPesoEdad(20, 30)) + " kg";

            lbCantidad20_30.Text = report.obtenerCantidadPersonasEdad(20, 30) + "";

            lb30_40.Text = (report.obtenerPromedioPesoEdad(30, 40).Contains(",") || report.obtenerPromedioPesoEdad(30, 40).Contains(".") ? decimal.Parse(report.obtenerPromedioPesoEdad(30, 40)).ToString("N2") : report.obtenerPromedioPesoEdad(30, 40)) + " kg";

            lbCantidad30_40.Text = report.obtenerCantidadPersonasEdad(30, 40) + "";

            lbMayor40.Text = (report.obtenerPromedioPesoEdad(40, 100).Contains(",") || report.obtenerPromedioPesoEdad(40, 100).Contains(".") ? decimal.Parse(report.obtenerPromedioPesoEdad(40, 100)).ToString("N2") : report.obtenerPromedioPesoEdad(40, 100)) + " kg";

            lbCantidadMayor40.Text = report.obtenerCantidadPersonasEdad(40, 100) + "";

            contarClasificacion(report);

            CantidadSexo();

        }
        /**
            *Se encarga de contar la cantidad de personas segun la clasificacion IMC
            *@param repo Es un objeto de tipo Reportes
        */
        private void contarClasificacion(BL.Reportes repo) {
            List<String> listClasi = repo.clasificacionIMC(edad1,edad2);

            Insuficiencia = 0;
            Normal = 0;
            Sobrepeso = 0;
            ObesidadI = 0;
            ObesidadII = 0;
            ObesidadIII = 0;

            foreach (String x in listClasi) {
                if (x.Equals("Insuficiencia")) {
                    Insuficiencia++;
                }
                if (x.Equals("Normal"))
                {
                    Normal++;
                }
                if (x.Equals("Sobrepeso"))
                {
                    Sobrepeso++;
                }
                if (x.Equals("ObesidadI"))
                {
                    ObesidadI++;
                }
                if (x.Equals("ObesidadII"))
                {
                    ObesidadII++;
                }
                if (x.Equals("ObesidadIII"))
                {
                    ObesidadIII++;
                }
            }
        }

        /**
            *Se encarga de contar la cantidad de hombres y mujeres que hay
            */
        private void CantidadSexo() {
            BL.Reportes repo = new BL.Reportes();
            F = 0;
            M = 0;

            List<string> list = repo.cantidadSexo(edad1,edad2);

            foreach (String x in list) {
                if (x.Equals("F"))
                {
                    F++;
                }
                else
                    M++;
            }

        }

        /**
            *Este metodo se encarga de modificar la edad por la que se van a filtrar los reportes
            *@param Edad1 Es un string que contiene una edad
            *@param Edad2 Es un string que contiene una edad
        */
        [System.Web.Services.WebMethod]
        public static void ModificarEdad(string Edad1, string Edad2)
        {
            edad1 = int.Parse(Edad1);
            edad2 = int.Parse(Edad2);
            
        }

	}
}