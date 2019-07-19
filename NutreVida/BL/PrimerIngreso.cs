using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;
using DAO;

namespace BL
{
    /**
    * Clase PrimerIngreso, crea los metodos que permiten gestionar el primer ingreso de un cliente
    * @author Cristel
   */
    public class PrimerIngreso
    {
        DAOPrimerIngreso daoClienteNutricion = new DAOPrimerIngreso();

        /**
        * Método publico que permite crear un TOcliente 
        * @param cedula, datos del usuario
        * @param correo, datos del usuario
        * @param nombre, datos del usuario
        * @param apellido1, datos del usuario
        * @param apellido2, datos del usuario
        * @param fecha_Nacimiento, datos del usuario
        * @param sexo, datos del usuario
        * @param estado_Civil, datos del usuario
        * @param whatsApp, datos del usuario
        * @param estado_Civil, datos del usuario
        * @param telefono, datos del usuario
        * @param residencia, datos del usuario
        * @param ocupacion, datos del usuario
        * @param fechaIngreso, datos del usuario
        * @param consultorio, datos del usuario
        * @param estado, datos del usuario
        * @return bool, retorna si se creó correctamente o no.
        */
        public Boolean CrearCliente(int cedula, string correo, string nombre, string apellido1, string apellido2, DateTime fecha_Nacimiento, char sexo, string estado_Civil, char whatsApp, int telefono, string residencia, string ocupacion, DateTime fechaIngreso, string consultorio, int estado)
        {
            if (cedula.Equals(""))
            {
                return false;
            }  
            TOClienteNutricion usuario = new TOClienteNutricion(cedula, correo, nombre, apellido1, apellido2, fecha_Nacimiento, sexo, estado_Civil, whatsApp, telefono, residencia, ocupacion, fechaIngreso, consultorio, estado);
            return daoClienteNutricion.CrearUsuario(usuario);
        }

        /**
        * Método publico que permite agregar un historia medico de un paciente
        * @param historial, objeto de tipo HistorialMedico
        * @param listaMedicamentos, lista de tipo Medicamento
        * @return bool, retorna si se agregó correctamente o no.
        */
        public Boolean AgregarHistorialMedico(HistorialMedico historial, List<Medicamento> listaMedicamentos)
        {
            List<TOMedicamento> lista = new List<TOMedicamento>();
            if (listaMedicamentos.Count != 0 && listaMedicamentos != null)
            {
                foreach (Medicamento medicamento in listaMedicamentos)
                {
                    lista.Add(new TOMedicamento(medicamento.Cedula, medicamento.Nombre, medicamento.Motivo, medicamento.Frecuencia, medicamento.Dosis));
                }
            }
            else
            {
                lista = null;
            }
            return daoClienteNutricion.GuardarHistorial((new TOHistorialMedico(historial.Cedula, historial.Antecedentes,
                historial.Patologias, historial.ConsumeLicor, historial.Fuma, historial.FrecFuma, historial.FrecLicor,
                historial.UltimoExamen, historial.ActividadFisica)), lista);
        }

        /**
        * Método publico que permite agregar un habito alimentario
        * @param habito, objeto de tipo HabitoAlimentario
        * @param listaRecordat, lista de tipo  Recordatorio24H
        * @return bool, retorna si se agregó correctamente o no.
        */
        public Boolean AgregarHabitosAlimentarios(HabitoAlimentario habito, List<Recordatorio24H> listaRecordat)
        {
            List<TORecordatorio24H> lista = new List<TORecordatorio24H>();
            if (listaRecordat.Count != 0 && listaRecordat != null)
            {
                foreach (Recordatorio24H recordatorio in listaRecordat)
                {
                    lista.Add(new TORecordatorio24H(recordatorio.Cedula, recordatorio.TiempoComida, recordatorio.Hora, recordatorio.Descripcion));
                }
            }
            else
            {
                lista = null;
            }
            return daoClienteNutricion.GuardarHabitos(new TOHabitoAlimentario(habito.Cedula, habito.ComidaDiaria, habito.ComidaHorasDia,
                habito.AfueraExpress, habito.ComidaFuera, habito.AzucarBebida, habito.ComidaElaboradCon, habito.AguaDiaria,
                habito.Aderezos, habito.Fruta, habito.Verdura, habito.Leche, habito.Huevo, habito.Yogurt, habito.Carne,
                habito.Queso, habito.Aguacate, habito.Semillas), lista);
        }

        /**
        * Método publico que permite agregar los datos de antropometria de un paciente
        * @param antrop, objeto de tipo Antropometria
        * @param porcion, objeto de tipo Porciones
        * @param Listdistrib, lista de tipo  DistribucionPorciones
        * @return bool, retorna si se agregó correctamente o no.
        */
        public bool AgregarAntropometria(Antropometria antrop, Porciones porcion, List<DistribucionPorciones>  Listdistrib)
        {
            List<TODistribucionPorciones> lista = new List<TODistribucionPorciones>();
            if (Listdistrib.Count != 0 && Listdistrib != null)
            {
                foreach (DistribucionPorciones porciones in Listdistrib)
                {
                    lista.Add(new TODistribucionPorciones(porciones.Descripcion, porciones.TiempoComida, porciones.Hora, porciones.Cedula));
                }
            }
            else
            {
                lista = null;
            }

            TOAntropometria antropom = new TOAntropometria();
            antropom.Cedula = antrop.Cedula; antropom.Talla = antrop.Talla; antropom.PesoIdeal = antrop.PesoIdeal;
            antropom.Edad = antrop.Edad; antropom.PMB = antrop.PMB; antropom.Peso = antrop.Peso; antropom.PesoMaxTeoria = antrop.PesoMaxTeoria;
            antropom.IMC = antrop.IMC; antropom.PorcGrasaAnalizador = antrop.PorcGrasaAnalizador; antropom.PorcGr_Bascula = antrop.PorcGr_Bascula;
            antropom.GB_BI = antrop.GB_BI; antropom.GB_BD = antrop.GB_BD; antropom.GB_PI = antrop.GB_PI;
            antropom.GB_PD = antrop.GB_PD; antropom.GB_Tronco = antrop.GB_Tronco; antropom.AguaCorporal = antrop.AguaCorporal;
            antropom.MasaOsea = antrop.MasaOsea; antropom.Complexión = antrop.Complexión; antropom.EdadMetabolica = antrop.EdadMetabolica;
            antropom.Cintura = antrop.Cintura; antropom.Abdomen = antrop.Abdomen; antropom.Cadera = antrop.Cadera;
            antropom.MusloDer = antrop.MusloDer; antropom.MusloIzq = antrop.MusloIzq; antropom.CBM = antrop.CBM; antropom.CircunfMunneca = antrop.CircunfMunneca;
			antropom.PorcentGViceral = antrop.PorcentGViceral; antropom.PorcentMusculo = antrop.PorcentMusculo; antropom.PM_BI = antrop.PM_BI; antropom.PM_PD = antrop.PM_PD; antropom.PM_BD = antrop.PM_BD;
            antropom.PM_PI = antrop.PM_PI; antropom.PM_Tronco = antrop.PM_Tronco; antropom.Observaciones = antrop.Observaciones;
            antropom.GEB = antrop.GEB; antropom.GET = antrop.GET; antropom.CHOPorc = antrop.CHOPorc;
            antropom.CHOGram = antrop.CHOGram; antropom.CHO_kcal = antrop.CHO_kcal; antropom.ProteinaPorc = antrop.ProteinaPorc;
            antropom.ProteinaGram = antrop.ProteinaGram; antropom.Proteinakcal = antrop.Proteinakcal; antropom.GrasaPorc = antrop.GrasaPorc;
            antropom.GrasaGram = antrop.GrasaGram; antropom.Grasakcal = antrop.Grasakcal;
            TOPorciones porci = new TOPorciones(porcion.Cedula, porcion.Leche, porcion.Carne, porcion.Vegetales, porcion.Grasa,
               porcion.Fruta, porcion.Azucar, porcion.Harina, porcion.Suplemento);

            

            return daoClienteNutricion.GuardarAntropometria(antropom, porci, lista);

        }

        /**
        * Método publico que permite buscar un cliente de acuerdo a su numero de cedula
        * @param cedula, objeto de tipo string
        * @return bool, retorna si se agregó correctamente o no.
        */
        public Boolean buscarCliente(string cedula)
		{
			Boolean cliente = daoClienteNutricion.buscarCedula(cedula);
			return cliente;
		}

    }
}
