using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SeguimientoRecordat24H
    {
        public int Seguimiento { set; get; }
        public string TiempoComida { set; get; }
        public string Hora { set; get; }
        public string Descripcion { set; get; }


        public SeguimientoRecordat24H(int seguimiento, string tiempoComida, string hora, string descripcion)
        {
            Seguimiento = seguimiento;
            TiempoComida = tiempoComida;
            Hora = hora;
            Descripcion = descripcion;
        }
        public SeguimientoRecordat24H() { }

        public SeguimientoRecordat24H(string tiempoComida, string hora, string descripcion)
        {
            TiempoComida = tiempoComida;
            Hora = hora;
            Descripcion = descripcion;
        }
    }
}
