using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    /**
 * Crea un objeto del medicamento, además de sus metodos set y get
 * @author Yoselyn
 */
    public class TOMedicamento
    {
        public int Cedula { set; get; }
        public string Nombre { set; get; }
        public string Motivo { set; get; }
        public string Frecuencia { set; get; }
        public string Dosis { set; get; }


        public TOMedicamento(int cedula, string nombre, string motivo, string frecuencia, string dosis)
        {
            Cedula = cedula;
            Nombre = nombre;
            Motivo = motivo;
            Frecuencia = frecuencia;
            Dosis = dosis;
        }

        public TOMedicamento() { }
    }
}
