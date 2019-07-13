using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /**
    * Clase Recordatorio24H, crea un recordatorio de 24 horas
    * @author Yoselyn 
   */
    public class Recordatorio24H
    {
        //inicio de atributos
        public int Cedula { set; get; }
        public string TiempoComida { set; get; }
        public string Hora { set; get; }
        public string Descripcion { set; get; }


        public Recordatorio24H(int cedula, string tiempoComida, string hora, string descripcion)
        {
            Cedula = cedula;
            TiempoComida = tiempoComida;
            Hora = hora;
            Descripcion = descripcion;
        }
        public Recordatorio24H() { }

    }
}
