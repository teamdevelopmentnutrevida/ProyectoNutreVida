using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{

    /**
* Crea un objeto del seguimiento del recordatorio de 24 horas, además de sus metodos set y get
* @author Yoselyn
*/
    public class TOSeguimientoRecordat24H
    {
        public int Seguimiento { set; get; }
        public string TiempoComida { set; get; }
        public string Hora { set; get; }
        public string Descripcion { set; get; }


        public TOSeguimientoRecordat24H(int seguimiento, string tiempoComida, string hora, string descripcion)
        {
            Seguimiento = seguimiento;
            TiempoComida = tiempoComida;
            Hora = hora;
            Descripcion = descripcion;
        }
        public TOSeguimientoRecordat24H() { }

        public TOSeguimientoRecordat24H(string tiempoComida, string hora, string descripcion)
        {
            TiempoComida = tiempoComida;
            Hora = hora;
            Descripcion = descripcion;
        }
    }
}
