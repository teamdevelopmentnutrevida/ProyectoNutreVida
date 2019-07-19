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

        /**
        * Método publico constructor que crea el objeto del recordatorio de 24 horas para el seguimiento, 
        * contiene el identificador del seguimiento.
        */
        public TOSeguimientoRecordat24H(int seguimiento, string tiempoComida, string hora, string descripcion)
        {
            Seguimiento = seguimiento;
            TiempoComida = tiempoComida;
            Hora = hora;
            Descripcion = descripcion;
        }

        /**
        * Método publico constructor vacío que crea una instancia del objeto.
        */
        public TOSeguimientoRecordat24H() { }

        /**
        * Método publico constructor que crea el objeto del recordatorio de 24 horas para el seguimiento, 
        */
        public TOSeguimientoRecordat24H(string tiempoComida, string hora, string descripcion)
        {
            TiempoComida = tiempoComida;
            Hora = hora;
            Descripcion = descripcion;
        }
    }
}
