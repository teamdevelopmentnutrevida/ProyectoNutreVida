using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /**
    * Clase SeguimientoSemanal, clase del objeto de seguimiento semanal.
    * @author Yoselyn
   */
    public class SeguimientoSemanal
    {
        //inicio de atributos
        public int Sesion { set; get; }
        public DateTime Fecha { set; get; }
        public decimal Peso { set; get; }
        public string Oreja { set; get; }
        public string Ejercicio { set; get; }
        public int Cedula { set; get; }

        /**
         * Método publico constructor vacío que crea el objeto Seguimiento agregando el atribulo sesion.
         */
        public SeguimientoSemanal(int sesion, DateTime fecha, decimal peso, string oreja, string ejercicio, int cedula)
        {
            Sesion = sesion;
            Fecha = fecha;
            Peso = peso;
            Oreja = oreja;
            Ejercicio = ejercicio;
            Cedula = cedula;
        }

        /**
        * Método publico constructor vacío que crea el objeto.
        */
        public SeguimientoSemanal() { }

        /**
         * Método publico constructor que crea el objeto Seguimiento Semanal.
         */
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
