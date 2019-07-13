using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    /**
* Crea un objeto de recordatorio de porciones, además de sus metodos set y get
* @author Yoselyn
*/
    public class TORecordatorio24H
    {
        public int Cedula { set; get; }
        public string TiempoComida { set; get; }
        public string Hora { set; get; }
        public string Descripcion { set; get; }


        public TORecordatorio24H(int cedula, string tiempoComida, string hora, string descripcion)
        {
            Cedula = cedula;
            TiempoComida = tiempoComida;
            Hora = hora;
            Descripcion = descripcion;
        }
        public TORecordatorio24H() { }

    }
}
