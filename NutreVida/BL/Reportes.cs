using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BL
{
    public class Reportes
    {

        public String obtenerPromedioPesoEdad20() {
            DAOReportes reporte = new DAOReportes();

            return reporte.obtenerPromedioPesoEdad(20,30);
        }

    }
}
