﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /**
        * Clase HistorialMedico, crea el objeto HistorialMedico como parte del registro del historial medico del paciente
        * @author Yoselyn
        */
    public class HistorialMedico
    {
        //inicio de variables 
        public int Cedula { set; get; }
        public string Antecedentes { set; get; }
        public string Patologias { set; get; }
        public int ConsumeLicor { set; get; }
        public int Fuma { set; get; }
        public string FrecFuma { set; get; }
        public string FrecLicor { set; get; }
        public DateTime UltimoExamen { set; get; }
        public string ActividadFisica { set; get; }

        public HistorialMedico() { }

        public HistorialMedico(int cedula, string antecedentes, string patologias, int consumeLicor, int fuma, string frecFuma, string frecLicor, DateTime ultimoExamen, string actividadFisica)
        {
            Cedula = cedula;
            Antecedentes = antecedentes;
            Patologias = patologias;
            ConsumeLicor = consumeLicor;
            Fuma = fuma;
            FrecFuma = frecFuma;
            FrecLicor = frecLicor;
            UltimoExamen = ultimoExamen;
            ActividadFisica = actividadFisica;
        }
    }
}
