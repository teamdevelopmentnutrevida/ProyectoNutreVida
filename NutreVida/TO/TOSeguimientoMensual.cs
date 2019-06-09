using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOSeguimientoMensual
    {
        public TOSeguimientoMensual(TOSeguimientoNutricional nutri, List<TOSeguimientoRecordat24H> record, TOSeguimientoAntrop antrop)
        {
            this.nutri = nutri;
            this.antrop = antrop;
            this.record = record;

        }

        public TOSeguimientoNutricional nutri { set; get; }

        public TOSeguimientoAntrop antrop { set; get; }

        public List<TOSeguimientoRecordat24H> record { set; get; }
    }
}
