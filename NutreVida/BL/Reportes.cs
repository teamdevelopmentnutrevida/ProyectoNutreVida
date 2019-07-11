using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using TO;

namespace BL
{

    /**
   * Clase Reportes, posee los metodos que permiten realizar consultas sobre los pacientes en forma de reportes
   * @author Diego
   */

    public class Reportes
    {
        /**
            *Este metodo obtiene el promedio de peso de las personas segun la edad
            *@param edad1 Es la edad inicio por la que se hara la busqueda
            *@param edad2 Es la edad final por la que se hara la busqueda
            *@return Retorna el digito del promedio de peso      
            */
        public String obtenerPromedioPesoEdad(int edad1,int edad2) {
            DAOReportes reporte = new DAOReportes();

            String promedio = reporte.obtenerPromedioPesoEdad(edad1, edad2); ;

            if (promedio.Equals("")){
                promedio = "0";
            }

            return promedio;
        }

        /**
            *Este metodo obtiene la cantidad de personas que hay segun la edad
            *@param edad1 Es la edad inicio por la que se hara la busqueda
            *@param edad2 Es la edad final por la que se hara la busqueda
            *@return Retorna la cantidad de personas
            */
        public int obtenerCantidadPersonasEdad(int edad1, int edad2)
        {
            DAOReportes reporte = new DAOReportes();

            return reporte.obtenerCantidadPersonasEdad(edad1,edad2);

        }

        /**
            *Este metodo obtiene una lista conlos datos necesarios para obtener el IMC de las personas
            *@param edad1 Es la edad inicio por la que se hara la busqueda
            *@param edad2 Es la edad final por la que se hara la busqueda
            *@return Lista de datos necesarios para calcular el IMC
            */
        private List<Antropometria> obtenerIMCEdades(int edad1, int edad2) {
            DAOReportes reporte = new DAOReportes();

            List<TOAntropometria> lisTO = reporte.obtenerIMCEdades( edad1, edad2);
            List<Antropometria> list = new List<Antropometria>();

            foreach (TOAntropometria to in lisTO) {
                Antropometria ant = new Antropometria(to.Cedula, to.Talla, to.Peso, to.Edad);
                list.Add(ant);
            }
            return list;
        }

        /**
            *Este metodo obtiene el IMC y lo clasifica segun corresponda
            *@param edad1 Es la edad inicio por la que se hara la busqueda
            *@param edad2 Es la edad final por la que se hara la busqueda
            *@return Lista de clasificacion de IMC
            */
        public List<String> clasificacionIMC(int edad1, int edad2) {

            ClasificacionIMC clasificacion = new ClasificacionIMC();

            List<Antropometria> list  = obtenerIMCEdades( edad1, edad2);

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
                    
                    tallaFormato = (talla/100);
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

        /**
            *Este metodo clasifica segun sea el sexo de la persona
            *@param edad1 Es la edad inicio por la que se hara la busqueda
            *@param edad2 Es la edad final por la que se hara la busqueda
            *@return Lista con la clasificacion de genero
            */
        public List<string> cantidadSexo(int edad1,int edad2) {

            DAOReportes repo = new DAOReportes() { };

            return repo.obtenerCantidadSexo( edad1, edad2);
        }

        


    }
}
