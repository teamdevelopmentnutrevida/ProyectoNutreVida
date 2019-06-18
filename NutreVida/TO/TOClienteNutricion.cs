using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TO
{
    public class TOClienteNutricion
    {
        public int Cedula { set; get; }
        public string Nombre { set; get; }
        public string Apellido1 { set; get; }
        public string Apellido2 { set; get; }
        public DateTime Fecha_Nacimiento { set; get; }
        public char Sexo { set; get; }
        public string Estado_Civil { set; get; }
        public char WhatsApp { set; get; }
        public int Telefono { set; get; }
        public string Residencia { set; get; }
        public string Ocupacion { set; get; }
        public DateTime FechaIngreso { set; get; }
        public string Correo { set; get; }
		public string Consultorio { set; get; }


		public TOClienteNutricion(int cedula,string correo, string nombre, string apellido1, string apellido2, DateTime fecha_Nacimiento, char sexo, string estado_Civil,char whatsApp ,int telefono, string residencia, string ocupacion, DateTime fechaIngreso, string consultorio)
        {
            Cedula = cedula;
            Correo = correo;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Fecha_Nacimiento = fecha_Nacimiento;
            Sexo = sexo;
            Estado_Civil = estado_Civil;
            WhatsApp = whatsApp;
            Telefono = telefono;
            Residencia = residencia;
            Ocupacion = ocupacion;
            FechaIngreso = fechaIngreso;
			Consultorio = consultorio;
		
        }



        public TOClienteNutricion()
        {
        }

    }
}
