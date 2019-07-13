using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{

    /**
* Crea un objeto del seguimiento nutricional, además de sus metodos set y get
* @author Yoselyn
*/
    public class TOSeguimientoNutricional
    {
        public string Cedula { set; get; }
        public string DiasEjercicio { set; get; }
        public string ComidaExtra { set; get; }
        public string NivelAnsiedad { set; get; }

        public TOSeguimientoNutricional(string cedula, string diasEjercicio, string comidaExtra, string nivelAnsiedad)
        {
            Cedula = cedula;
            DiasEjercicio = diasEjercicio;
            ComidaExtra = comidaExtra;
            NivelAnsiedad = nivelAnsiedad;
        }

        public TOSeguimientoNutricional() { }
    }
}
