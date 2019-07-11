using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

    /**
    * Crea un objeto evento Evento, además de sus metodos set y get
    * @author Tannia
    */
    public class Evento
    {

        public Evento(string id, string start_date, string end_date, string text, string details)
        {
            this.id = id;
            this.text = text;
            this.details = details;
            this.start_date = start_date;
            this.end_date = end_date;
        }

        public string id { get; set; }
        public string start_date { set; get; }
        public string end_date { set; get; }
        public string text { set; get; }
        public string details { set; get; }
        


        public Evento() { }
    }
}
