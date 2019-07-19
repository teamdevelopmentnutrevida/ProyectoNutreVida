using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{

    /**
* Crea un objeto del seguimiento mensual, además de sus metodos set y get
* @author Yoselyn
*/
    public class TOSeguimientoMensual
    {
        public int idSeg { set; get; }
        public DateTime Fecha { set; get; }

        public TOSeguimientoNutricional nutri { set; get; }

        public TOSeguimientoAntrop antrop { set; get; }

        public List<TOSeguimientoRecordat24H> record { set; get; }

        /**
        * Método publico constructor que crea el objeto del seguimiento.
        */
        public TOSeguimientoMensual(TOSeguimientoNutricional nutri, List<TOSeguimientoRecordat24H> record, TOSeguimientoAntrop antrop)
        {
            this.nutri = nutri;
            this.antrop = antrop;
            this.record = record;
        }
        /**
        * Método publico constructor que crea el objeto del seguimiento, 
        * contiene el identificador del seguimiento.
        */
        public TOSeguimientoMensual(TOSeguimientoNutricional nutri, List<TOSeguimientoRecordat24H> record, TOSeguimientoAntrop antrop, int id)
        {
            this.idSeg = id;
            this.nutri = nutri;
            this.antrop = antrop;
            this.record = record;
        }

        /**
        * Método publico constructor vacío que crea una instancia del objeto.
        */
        public TOSeguimientoMensual() { }
    }
}
