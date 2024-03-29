﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /**
     * Clase SeguimientoNutricional, clase del objeto de seguimientos nutricional completo.
     * @author Yoselyn
    */
    public class SeguimientoNutricional
    {
        //inicio de atributos
        public string Cedula { set; get; }
        public string DiasEjercicio { set; get; }
        public string ComidaExtra { set; get; }
        public string NivelAnsiedad { set; get; }

        /**
        * Método publico constructor que crea el objeto del seguimiento nutricional.
        */
        public SeguimientoNutricional(string cedula, string diasEjercicio, string comidaExtra, string nivelAnsiedad)
        {
            Cedula = cedula;
            DiasEjercicio = diasEjercicio;
            ComidaExtra = comidaExtra;
            NivelAnsiedad = nivelAnsiedad;
        }

        /**
        * Método publico constructor vacio que crea una instanci del objeto.
        */
        public SeguimientoNutricional() { }
    }
}
