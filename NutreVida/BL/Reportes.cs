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

        public String obtenerPromedioPesoEdad(int edad1,int edad2) {
            DAOReportes reporte = new DAOReportes();

            return reporte.obtenerPromedioPesoEdad(edad1, edad2);
        }


    }
}
