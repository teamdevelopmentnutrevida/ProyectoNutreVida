using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SeguimientoMensual
    {
        public int idSeg { set; get; }
        public DateTime Fecha { set; get; }

        public SeguimientoNutricional nutri { set; get; }

        public SeguimientoAntrop antrop { set; get; }

        public List<SeguimientoRecordat24H> record { set; get; }
        public SeguimientoMensual(SeguimientoNutricional nutri, List<SeguimientoRecordat24H> record, SeguimientoAntrop antrop)
        {
            this.nutri = nutri;
            this.antrop = antrop;
            this.record = record;
        }
        public SeguimientoMensual(SeguimientoNutricional nutri, List<SeguimientoRecordat24H> record, SeguimientoAntrop antrop, int id)
        {
            this.idSeg = id;
            this.nutri = nutri;
            this.antrop = antrop;
            this.record = record;
        }

        public SeguimientoMensual() { }

    }
}
