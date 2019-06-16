using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using TO;

namespace BL
{
    public class Reportes
    {

        public String obtenerPromedioPesoEdad(int edad1,int edad2) {
            DAOReportes reporte = new DAOReportes();

            String promedio = reporte.obtenerPromedioPesoEdad(edad1, edad2); ;

            if (promedio.Equals("")){
                promedio = "0";
            }

            return promedio;
        }

        public List<Antropometria> obtenerIMCEdades() {
            DAOReportes reporte = new DAOReportes();

            List<TOAntropometria> lisTO = reporte.obtenerIMCEdades();
            List<Antropometria> list = new List<Antropometria>();

            foreach (TOAntropometria to in lisTO) {
                Antropometria ant = new Antropometria(to.Cedula, to.Talla, to.Peso, to.Edad);
                list.Add(ant);
            }
            return list;
        }

        public List<String> clasificacionIMC() {

            ClasificacionIMC clasificacion = new ClasificacionIMC();

            List<Antropometria> list  = obtenerIMCEdades();

            List<String> listClasi = new List<string>();
        
            foreach (Antropometria antrop in list) {

                double talla = double.Parse(antrop.Talla + "");

                double peso = double.Parse(antrop.Peso + "");

                double tallaFormato;

                if ((talla + "").Contains(",") || (talla + "").Contains("."))
                {
                    tallaFormato = talla;
                }
                else {
                    String x = (talla + "").Insert(1, ".");
                    tallaFormato = double.Parse(x);
                }               

                double IMC = peso / Math.Pow(tallaFormato, 2);

                if (IMC > clasificacion.Insuficiencia[0] && IMC < clasificacion.Insuficiencia[1]) {
                    listClasi.Add("Insuficiencia");
                }
                if (IMC > clasificacion.Normal[0] && IMC < clasificacion.Normal[1])
                {
                    listClasi.Add("Normal");
                }
                if (IMC > clasificacion.Sobrepeso[0] && IMC < clasificacion.Sobrepeso[1])
                {
                    listClasi.Add("Sobrepeso");
                }
                if (IMC > clasificacion.ObesidadI[0] && IMC < clasificacion.ObesidadI[1])
                {
                    listClasi.Add("ObesidadI");
                }
                if (IMC > clasificacion.ObesidadII[0] && IMC < clasificacion.ObesidadII[1])
                {
                    listClasi.Add("ObesidadII");
                }
                if (IMC > clasificacion.ObesidadIII[0] && IMC < clasificacion.ObesidadIII[1])
                {
                    listClasi.Add("ObesidadIII");
                }
            }

            return listClasi;
        }

        


    }
}
