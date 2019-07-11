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

        public void guardarEvento(string json) {

            Evento even = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Evento>(json);

            //DateTime inicio = DateTime.Parse(even.start_date);

            //inicio = inicio.AddHours(-6);

            //DateTime final = DateTime.Parse(even.end_date);

            //final = final.AddHours(-6);

            daoEvento.guardarEvento(new TOEvento(even.id, even.start_date,even.end_date, even.text,even.details));
        }

        public void eliminarEvento(string id)
        {
            daoEvento.eliminarEvento(id);
        }


        //public void modificarEvento(string nombre, string descripcion, string horaInicio, string horaFin, string fecha) {
        //    daoEvento.modificarEvento(nombre,  descripcion,  horaInicio, horaFin, fecha);
        //}


    }
}
