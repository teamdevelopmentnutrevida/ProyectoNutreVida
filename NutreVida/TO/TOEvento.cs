using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    /**
   * Crea un objeto de tranferencia de Evento, además de sus metodos set y get
   * @author Tannia
   */
    public class TOEvento
    {
       public string nombreEvento { set;  get;}
        public string decripcionEvento { set; get; }
        public string horaInicio { set; get; }
        public string horaFin { set; get; }
        public string fecha { set; get; }

        public TOEvento(string nombreEvento, string decripcionEvento, string horaInicio, string horaFin, string fecha)
        {
            this.nombreEvento = nombreEvento;
            this.decripcionEvento = decripcionEvento;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.fecha = fecha;
        }
    }
}
