﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SeguimientoNutricional
    {
        public string Cedula { set; get; }
        public string DiasEjercicio { set; get; }
        public string ComidaExtra { set; get; }
        public string NivelAnsiedad { set; get; }

        public SeguimientoNutricional(string cedula, string diasEjercicio, string comidaExtra, string nivelAnsiedad)
        {
            Cedula = cedula;
            DiasEjercicio = diasEjercicio;
            ComidaExtra = comidaExtra;
            NivelAnsiedad = nivelAnsiedad;
        }

        public SeguimientoNutricional() { }
    }
}
