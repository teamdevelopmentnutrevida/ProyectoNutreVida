using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BL
{
    public class ManejadorEvento
    {
        DAOEvento daoEvento = new DAOEvento();

        public void guardarEvento(string nombreEvento, string descripcionEvento, string horaInicio, string horaFin, string fecha) {
            daoEvento.guardarEvento(new TOEvento(nombreEvento, descripcionEvento, horaInicio, horaFin, fecha));
        }


        public List<Evento> ListaEvento(string fecha)
        {
            List<Evento> ListaEvento = new List<Evento>();
            List<TOEvento> listaTO = daoEvento.listaEventos(fecha);
            if (listaTO != null)
            {
                foreach (TOEvento evento in listaTO)
                {
                    ListaEvento.Add(new Evento(evento.nombreEvento, evento.decripcionEvento, evento.horaInicio, evento.horaFin, evento.fecha));
                }
                return ListaEvento;
            }
            else
            {
                return null;
            }
        }

        public void eliminarEvento(string nombre, string fecha) {
            daoEvento.eliminarEvento(nombre, fecha);
        }


        public void modificarEvento(string nombre, string descripcion, string horaInicio, string horaFin, string fecha) {
            daoEvento.modificarEvento(nombre,  descripcion,  horaInicio, horaFin, fecha);
        }


    }
}
