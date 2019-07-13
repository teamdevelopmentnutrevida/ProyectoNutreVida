using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /**
        * Clase ClasificacionIMC, crea el objeto ClasificacionIMC como parte del registro del cliente en los seguimientos
        * @author Yoselyn
        */

    public class ClasificacionIMC
    {
        //inicio de atributos
        private double[] insuficiencia = { 0, 18.5 };

        private double[] normal = {18.5,25};

        private double[] sobrepeso = { 25, 30 };

        private double[] obesidadI = { 30, 35 };

        private double[] obesidadII = { 35, 40 };

        private double[] obesidadIII = { 40, 100 };


        public double[] Insuficiencia
        {
            get
            {
                return insuficiencia;
            }
        }

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

        public double[] ObesidadI
        {
            get
            {
                return obesidadI;
            }
        }

        public double[] ObesidadII
        {
            get
            {
                return obesidadII;
            }
        }

        public double[] ObesidadIII
        {
            get
            {
                return obesidadIII;
            }
        }
    }
}
