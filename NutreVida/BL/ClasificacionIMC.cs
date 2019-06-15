using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClasificacionIMC
    {
        private double[] normal = {18.5,24.9};

        private double[] sobrepeso = { 25, 29.9 };


        public double[] Normal
        {
            get
            {
                return normal;
            }
        }

        public double[] Sobrepeso
        {
            get
            {
                return sobrepeso;
            }
        }
    }
}
