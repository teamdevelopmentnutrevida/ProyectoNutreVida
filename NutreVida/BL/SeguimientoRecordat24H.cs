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
        public string Descripcion { set; get; }


        public SeguimientoRecordat24H(int seguimiento, string tiempoComida, string descripcion)
        {
            Seguimiento = seguimiento;
            TiempoComida = tiempoComida;
            Descripcion = descripcion;
        }
        public SeguimientoRecordat24H() { }

        public SeguimientoRecordat24H(string tiempoComida, string descripcion)
        {
            TiempoComida = tiempoComida;
            Descripcion = descripcion;
        }
    }
}
