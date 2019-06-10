using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SeguimientoSemanal
    {
        public int Sesion { set; get; }
        public DateTime Fecha { set; get; }
        public decimal Peso { set; get; }
        public string Oreja { set; get; }
        public string Ejercicio { set; get; }
        public int Cedula { set; get; }

        public SeguimientoSemanal(int sesion, DateTime fecha, decimal peso, string oreja, string ejercicio, int cedula)
        {
            Sesion = sesion;
            Fecha = fecha;
            Peso = peso;
            Oreja = oreja;
            Ejercicio = ejercicio;
            Cedula = cedula;
        }

        public SeguimientoSemanal() { }

        public SeguimientoSemanal(DateTime fecha, decimal peso, string oreja, string ejercicio, int cedula)
        {
            Fecha = fecha;
            Peso = peso;
            Oreja = oreja;
            Ejercicio = ejercicio;
            Cedula = cedula;
        }
    }
}
