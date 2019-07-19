using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /**
        * Clase DistribucionPorciones, crea el objeto DistribucionPorciones como parte del registro del cliente en los seguimientos
        * @author Yoselyn
        */

    public class DistribucionPorciones
    {
        //inicia atributos
        public int Cedula { set; get; }
        public string Descripcion { set; get; }
        public string TiempoComida { set; get; }
        public string Hora { set; get; }


        public DistribucionPorciones(string descripcion, string tiempoComida, string hora, int cedula)
        { 
            Descripcion = descripcion;
            TiempoComida = tiempoComida;
            Hora = hora;
			Cedula = cedula;
		}
        public DistribucionPorciones() { }

    }
}
