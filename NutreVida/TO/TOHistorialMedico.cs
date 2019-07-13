using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    /**
  * Crea un objeto de tranferencia del historial metico, además de sus metodos set y get
  * @author Yoselyn
  */
    public class TOHistorialMedico
    {
        public int Cedula { set; get; }
        public string Antecedentes { set; get; }
        public string Patologias { set; get; }
        public int ConsumeLicor { set; get; }
        public int Fuma { set; get; }
        public string FrecFuma { set; get; }
        public string FrecLicor { set; get; }
        public string UltimoExamen { set; get; }
        public string ActividadFisica { set; get; }

        public TOHistorialMedico() { }

        public TOHistorialMedico(int cedula, string antecedentes, string patologias, int consumeLicor, int fuma, string frecFuma, string frecLicor, string ultimoExamen, string actividadFisica)
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
