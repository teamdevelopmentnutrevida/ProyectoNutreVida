﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /**
    * Clase Porciones, crea el objeto Porciones como parte del registro del cliente
    * @author Yoselyn
   */
    public class Porciones
    {
        //inicio de atributos
        public int Cedula { set; get; }
        public decimal Leche { set; get; }
        public decimal Carne { set; get; }
        public decimal Vegetales { set; get; }
        public decimal Grasa { set; get; }
        public decimal Fruta { set; get; }
        public decimal Azucar { set; get; }
        public decimal Harina { set; get; }
        public decimal Suplemento { set; get; }

        public Porciones(int cedula, decimal leche, decimal carne, decimal vegetales, decimal grasa, decimal fruta, decimal azucar, decimal harina, decimal suplemento)
        {
            Cedula = cedula;
            Leche = leche;
            Carne = carne;
            Vegetales = vegetales;
            Grasa = grasa;
            Fruta = fruta;
            Azucar = azucar;
            Harina = harina;
            Suplemento = suplemento;
        }
        public Porciones() { }

    }
}
