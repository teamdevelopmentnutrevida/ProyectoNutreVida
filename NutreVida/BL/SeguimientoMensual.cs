using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SeguimientoMensual
    {
        public SeguimientoMensual(SeguimientoNutricional nutri, List<SeguimientoRecordat24H> record, SeguimientoAntrop antrop)
        {
            this.nutri = nutri;
            this.antrop = antrop;
            this.record = record;

        }

        public SeguimientoNutricional nutri { set; get; }

        public SeguimientoAntrop antrop { set; get; }

        public List<SeguimientoRecordat24H> record { set; get; }

    }
}
