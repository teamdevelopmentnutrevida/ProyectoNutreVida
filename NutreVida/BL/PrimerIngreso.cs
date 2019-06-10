﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;
using DAO;

namespace BL
{
    public class PrimerIngreso
    {
        DAOPrimerIngreso daoClienteNutricion = new DAOPrimerIngreso();

        public Boolean CrearCliente(int cedula, string correo, string nombre, string apellido1, string apellido2, string fecha_Nacimiento, char sexo, string estado_Civil, char whatsApp, int telefono, string residencia, string ocupacion, string fechaIngreso)
        {
            if (cedula.Equals(""))
            {
                return false;
            }
            TOClienteNutricion usuario = new TOClienteNutricion(cedula, correo, nombre, apellido1, apellido2, fecha_Nacimiento, sexo, estado_Civil, whatsApp, telefono, residencia, ocupacion, fechaIngreso);
            return daoClienteNutricion.CrearUsuario(usuario);
        }

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

        public bool AgregarAntropometria(Antropometria antrop, Porciones porcion, DistribucionPorciones distrib)
        {
            TOAntropometria antropom = new TOAntropometria();
            antropom.Cedula = antrop.Cedula; antropom.Talla = antrop.Talla; antropom.PesoIdeal = antrop.PesoIdeal;
            antropom.Edad = antrop.Edad; antropom.PMB = antrop.PMB; antropom.Peso = antrop.Peso; antropom.PesoMaxTeoria = antrop.PesoMaxTeoria;
            antropom.IMC = antrop.IMC; antropom.PorcGrasaAnalizador = antrop.PorcGrasaAnalizador; antropom.PorcGr_Bascula = antrop.PorcGr_Bascula;
            antropom.GB_BI = antrop.GB_BI; antropom.GB_BD = antrop.GB_BD; antropom.GB_PI = antrop.GB_PI;
            antropom.GB_PD = antrop.GB_PD; antropom.GB_Tronco = antrop.GB_Tronco; antropom.AguaCorporal = antrop.AguaCorporal;
            antropom.MasaOsea = antrop.MasaOsea; antropom.Complexión = antrop.Complexión; antropom.EdadMetabolica = antrop.EdadMetabolica;
            antropom.Cintura = antrop.Cintura; antropom.Abdomen = antrop.Abdomen; antropom.Cadera = antrop.Cadera;
            antropom.Muslo = antrop.Muslo; antropom.CBM = antrop.CBM; antropom.CircunfMunneca = antrop.CircunfMunneca;
            antropom.PorcentMusculo = antrop.PorcentMusculo; antropom.PM_BI = antrop.PM_BI; antropom.PM_PD = antrop.PM_PD; antropom.PM_BD = antrop.PM_BD;
            antropom.PM_PI = antrop.PM_PI; antropom.PM_Tronco = antrop.PM_Tronco; antropom.Observaciones = antrop.Observaciones;
            antropom.GEB = antrop.GEB; antropom.GET = antrop.GET; antropom.CHOPorc = antrop.CHOPorc;
            antropom.CHOGram = antrop.CHOGram; antropom.CHO_kcal = antrop.CHO_kcal; antropom.ProteinaPorc = antrop.ProteinaPorc;
            antropom.ProteinaGram = antrop.ProteinaGram; antropom.Proteinakcal = antrop.Proteinakcal; antropom.GrasaPorc = antrop.GrasaPorc;
            antropom.GrasaGram = antrop.GrasaGram; antropom.Grasakcal = antrop.Grasakcal;
            TOPorciones porci = new TOPorciones(porcion.Cedula, porcion.Leche, porcion.Carne, porcion.Vegetales, porcion.Grasa,
               porcion.Fruta, porcion.Azucar, porcion.Harina, porcion.Suplemento);

            TODistribucionPorciones distribuc = new TODistribucionPorciones(distrib.Cedula, distrib.Descripcion, distrib.TiempoComida, distrib.Hora);

            return daoClienteNutricion.GuardarAntropometria(antropom, porci, distribuc);

        }

    }
}
