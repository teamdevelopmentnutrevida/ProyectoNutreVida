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


    }
}
