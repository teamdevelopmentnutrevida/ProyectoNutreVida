using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;
using Newtonsoft.Json;
using System.IO;

namespace BL
{
    public class ManejadorEvento
    {
        private DAOEvento daoEvento = new DAOEvento();


        //public void guardarEvento(string nombreEvento, string descripcionEvento, string horaInicio, string horaFin, string fecha) {
        //    daoEvento.guardarEvento(new TOEvento(nombreEvento, descripcionEvento, horaInicio, horaFin, fecha));
        //}

        public String cargarDatos(){
            string eventos = "";

            return eventos;
        }

        public List<Evento> ListaEvento(String url)
        {
            List<Evento> data = new List<Evento>();
            List<TOEvento> listaTO = daoEvento.listaEventos();
            String Json = string.Empty;

            if (listaTO != null)
            {
                foreach (TOEvento evento in listaTO)
                {
                    Evento ev = new Evento(evento.id, evento.start_date, evento.end_date, evento.text, evento.details);
                    data.Add(ev);

                }

                Json = "{\"data\":" + JsonConvert.SerializeObject(data) + "}";
                String path = url + "Eventos.json";
                File.WriteAllText(path, Json);
                return data;
            }
            else
            {
                return null;
            }
        }

        //public void eliminarEvento(string nombre, string fecha) {
        //    daoEvento.eliminarEvento(nombre, fecha);
        //}


        //public void modificarEvento(string nombre, string descripcion, string horaInicio, string horaFin, string fecha) {
        //    daoEvento.modificarEvento(nombre,  descripcion,  horaInicio, horaFin, fecha);
        //}


    }
}
