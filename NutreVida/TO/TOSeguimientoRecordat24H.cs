using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOSeguimientoRecordat24H
    {
        public int Seguimiento { set; get; }
        public string TiempoComida { set; get; }
        public string Descripcion { set; get; }


        public TOSeguimientoRecordat24H(int seguimiento, string tiempoComida, string descripcion)
        {
            Seguimiento = seguimiento;
            TiempoComida = tiempoComida;
            Descripcion = descripcion;
        }
        public TOSeguimientoRecordat24H() { }

        public TOSeguimientoRecordat24H(string tiempoComida, string descripcion)
        {
            TiempoComida = tiempoComida;
            Descripcion = descripcion;
        }
    }
}
