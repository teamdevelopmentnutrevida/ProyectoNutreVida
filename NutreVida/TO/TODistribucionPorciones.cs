﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TODistribucionPorciones
    {
        public int Cedula { set; get; }
        public string Descripcion { set; get; }
        public string TiempoComida { set; get; }
        public string Hora { set; get; }


        public TODistribucionPorciones(string descripcion, string tiempoComida, string hora, int cedula)
        {
            
            Descripcion = descripcion;
            TiempoComida = tiempoComida;
            Hora = hora;
			Cedula = cedula;
		}
        public TODistribucionPorciones() { }

    }
}
