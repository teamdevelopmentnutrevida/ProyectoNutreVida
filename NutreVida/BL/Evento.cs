using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Evento
    {

        string nombreEvento;
        string decripcionEvento;
        string horaInicio;
        string horaFin;
        string fecha;

        public string NombreEvento
        {
            get
            {
                return nombreEvento;
            }

            set
            {
                nombreEvento = value;
            }
        }

        public string DecripcionEvento
        {
            get
            {
                return decripcionEvento;
            }

            set
            {
                decripcionEvento = value;
            }
        }

        public string HoraInicio
        {
            get
            {
                return horaInicio;
            }

            set
            {
                horaInicio = value;
            }
        }

        public string HoraFin
        {
            get
            {
                return horaFin;
            }

            set
            {
                horaFin = value;
            }
        }

        public string Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public Evento(string nombreEvento, string decripcionEvento, string horaInicio, string horaFin, string fecha)
        {
            this.NombreEvento = nombreEvento;
            this.DecripcionEvento = decripcionEvento;
            this.HoraInicio = horaInicio;
            this.HoraFin = horaFin;
            this.Fecha = fecha;
        }
    }
}
