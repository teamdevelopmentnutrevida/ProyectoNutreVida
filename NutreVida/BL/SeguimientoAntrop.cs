﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /**
     * Clase SeguimientoAntrop, clase del objeto de antropometria para el seguimiento nutricional.
     * @author Yoselyn
    */
    public class SeguimientoAntrop
    {
        //inicio de atributos
        public int id_SegAntrop { set; get; }
        public int Seguimiento { set; get; }
        public decimal Edad { set; get; }
        public decimal Talla { set; get; }
        public decimal CM { set; get; }
        public DateTime Fecha_SA { set; get; }
        public decimal Peso { set; get; }
        public decimal IMC { set; get; }
        public decimal EdadMetabolica { set; get; }
        public decimal Agua { set; get; }
        public decimal MasaOsea { set; get; }
        public decimal PorcGrasaAnalizador { set; get; }
        public decimal PorcentGViceral { set; get; }
        public decimal PorcGr_Bascula { set; get; }
        public decimal GB_BI { set; get; }
        public decimal GB_BD { set; get; }
        public decimal GB_PI { set; get; }
        public decimal GB_PD { set; get; }
        public decimal GB_Tronco { set; get; }
        public decimal PorcentMusculo { set; get; }
        public decimal PM_BI { set; get; }
        public decimal PM_PD { set; get; }
        public decimal PM_BD { set; get; }
        public decimal PM_PI { set; get; }
        public decimal PM_Tronco { set; get; }
        public decimal CircunfCintura { set; get; }
        public decimal Cadera { set; get; }
        public decimal MusloIzq { set; get; }
        public decimal MusloDer { set; get; }
        public decimal BrazoIzq { set; get; }
        public decimal BrazoDer { set; get; }
        public decimal PesoIdeal { set; get; }
        public string Observaciones { set; get; }

        /**
        * Método publico constructor vacío que crea el objeto.
        */
        public SeguimientoAntrop() { }


        /**
         * Método publico constructor que crea el objeto.
         * @param todos los de la clase menos el id_SegAntrop, y el Seguimiento.
         */
        public SeguimientoAntrop(decimal edad, decimal talla, decimal cm, DateTime fecha_SA, decimal peso, decimal iMC, decimal edadMetabolica, decimal agua, decimal masaOsea, decimal porcGrasaAnalizador, decimal porcentGViceral, decimal porcGr_Bascula, decimal gB_BI, decimal gB_BD, decimal gB_PI, decimal gB_PD, decimal gB_Tronco, decimal porcentMusculo, decimal pM_BI, decimal pM_BD, decimal pM_PI, decimal pM_PD, decimal pM_Tronco, decimal circunfCintura, decimal cadera, decimal musloIzq, decimal musloDer, decimal brazoIzq, decimal brazoDer, decimal pesoIdeal, string observaciones)
        {
            Edad = edad;
            Talla = talla;
            CM = cm;
            Fecha_SA = fecha_SA;
            Peso = peso;
            IMC = iMC;
            EdadMetabolica = edadMetabolica;
            Agua = agua;
            MasaOsea = masaOsea;
            PorcGrasaAnalizador = porcGrasaAnalizador;
            PorcentGViceral = porcentGViceral;
            PorcGr_Bascula = porcGr_Bascula;
            GB_BI = gB_BI;
            GB_BD = gB_BD;
            GB_PI = gB_PI;
            GB_PD = gB_PD;
            GB_Tronco = gB_Tronco;
            PorcentMusculo = porcentMusculo;
            PM_BI = pM_BI;
            PM_PD = pM_PD;
            PM_BD = pM_BD;
            PM_PI = pM_PI;
            PM_Tronco = pM_Tronco;
            CircunfCintura = circunfCintura;
            Cadera = cadera;
            MusloIzq = musloIzq;
            MusloDer = musloDer;
            BrazoIzq = brazoIzq;
            BrazoDer = brazoDer;
            PesoIdeal = pesoIdeal;
            Observaciones = observaciones;
        }

        /**
         * Método publico constructor que crea el objeto 
         * @param todos los de la clase
         */
        public SeguimientoAntrop(int id_SegAntrop, int seguimiento, decimal edad, decimal talla, decimal cm, DateTime fecha_SA, decimal peso, decimal iMC, decimal edadMetabolica, decimal agua, decimal masaOsea, decimal porcGrasaAnalizador, decimal porcentGViceral, decimal porcGr_Bascula, decimal gB_BI, decimal gB_BD, decimal gB_PI, decimal gB_PD, decimal gB_Tronco, decimal porcentMusculo, decimal pM_BI, decimal pM_BD, decimal pM_PI, decimal pM_PD, decimal pM_Tronco, decimal circunfCintura, decimal cadera, decimal musloIzq, decimal musloDer, decimal brazoIzq, decimal brazoDer, decimal pesoIdeal, string observaciones)
        {
            this.id_SegAntrop = id_SegAntrop;
            Seguimiento = seguimiento;
            Edad = edad;
            Talla = talla;
            CM = cm;
            Fecha_SA = fecha_SA;
            Peso = peso;
            IMC = iMC;
            EdadMetabolica = edadMetabolica;
            Agua = agua;
            MasaOsea = masaOsea;
            PorcGrasaAnalizador = porcGrasaAnalizador;
            PorcentGViceral = porcentGViceral;
            PorcGr_Bascula = porcGr_Bascula;
            GB_BI = gB_BI;
            GB_BD = gB_BD;
            GB_PI = gB_PI;
            GB_PD = gB_PD;
            GB_Tronco = gB_Tronco;
            PorcentMusculo = porcentMusculo;
            PM_BI = pM_BI;
            PM_PD = pM_PD;
            PM_BD = pM_BD;
            PM_PI = pM_PI;
            PM_Tronco = pM_Tronco;
            CircunfCintura = circunfCintura;
            Cadera = cadera;
            MusloIzq = musloIzq;
            MusloDer = musloDer;
            BrazoIzq = brazoIzq;
            BrazoDer = brazoDer;
            PesoIdeal = pesoIdeal;
            Observaciones = observaciones;
        }

    }

}
