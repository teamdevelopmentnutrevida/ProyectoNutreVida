﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    /**
* Crea un objeto del seguimiento semanal, además de sus metodos set y get
* @author Yoselyn
*/
    public class TOSeguimientoSemanal
    {
        public int Sesion { set; get; }
        public DateTime Fecha { set; get; }
        public decimal Peso { set; get; }
        public string Oreja { set; get; }
        public string Ejercicio { set; get; }
        public int Cedula { set; get; }

        /**
        * Método publico constructor que crea el objeto del seguimiento, 
        * contiene el identificador del seguimiento.
        */
        public TOSeguimientoSemanal(int sesion, DateTime fecha, decimal peso, string oreja, string ejercicio, int cedula)
        {
            Sesion = sesion;
            Fecha = fecha;
            Peso = peso;
            Oreja = oreja;
            Ejercicio = ejercicio;
            Cedula = cedula;
        }

        /**
        * Método publico constructor vacío que crea una instancia del objeto
        */
        public TOSeguimientoSemanal() { }

        /**
        * Método publico constructor que crea el objeto del seguimiento.
        */
        public TOSeguimientoSemanal(DateTime fecha, decimal peso, string oreja, string ejercicio, int cedula)
        {
            Fecha = fecha;
            Peso = peso;
            Oreja = oreja;
            Ejercicio = ejercicio;
            Cedula = cedula;
        }
    }
}
