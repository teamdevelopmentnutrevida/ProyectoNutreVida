﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;
using DAO;

namespace BL
{
    /**
     * Clase ManejadorExpediente, maneja los metodos del expediente en general.
     * @author Yoselyn
    */
    public class ManejadorExpediente
    {

        public static DAOClienteNutricion daoClienteNutricion = new DAOClienteNutricion();
        /**
         * Método publico que trae de la Base de datos la lista de los clientes 
         * @param ced, cedula del cliente
         */
        public List<ClienteNutricion> ListaClientes()
        {
            List<ClienteNutricion> ListaClient = new List<ClienteNutricion>();
            List<TOClienteNutricion> listaTO = daoClienteNutricion.ListarCliente();
            if (listaTO != null)
            {
                foreach (TOClienteNutricion cliente in listaTO)
                {
                    ListaClient.Add(new ClienteNutricion(cliente.Cedula, cliente.Correo,cliente.Nombre, cliente.Apellido1, cliente.Apellido2, cliente.Fecha_Nacimiento, cliente.Sexo, cliente.Estado_Civil,cliente.WhatsApp, cliente.Telefono, cliente.Residencia, cliente.Ocupacion, cliente.FechaIngreso,cliente.Consultorio, cliente.Estado));
                }
                return ListaClient;
            }
            else
            {
                return null;
            }
        }

        /**
        * Método publico que trae de la Base de datos la información personal del cliente
        * @param ced, cedula del cliente
        */
        public ClienteNutricion TraerInformación(string ced)
        {
            ClienteNutricion cliente = new ClienteNutricion();
            TOClienteNutricion TOcliente = daoClienteNutricion.TraerInfoPersonal(ced);
            if (TOcliente != null) {
                cliente.Cedula = TOcliente.Cedula;
                cliente.Correo = TOcliente.Correo;
                cliente.Nombre = TOcliente.Nombre;
                cliente.Apellido1 = TOcliente.Apellido1;
                cliente.Apellido2 = TOcliente.Apellido2;
                cliente.Fecha_Nacimiento = TOcliente.Fecha_Nacimiento;
                cliente.Sexo = TOcliente.Sexo;
                cliente.Estado_Civil = TOcliente.Estado_Civil;
                cliente.WhatsApp = TOcliente.WhatsApp;
                cliente.Telefono = TOcliente.Telefono;
                cliente.Residencia = TOcliente.Residencia;
                cliente.Ocupacion = TOcliente.Ocupacion;
                cliente.FechaIngreso = TOcliente.FechaIngreso;
                cliente.Consultorio = TOcliente.Consultorio;
                cliente.Estado = TOcliente.Estado;
                return cliente;
            }
            else
            {
                return null;
            }
        }

        /**
        * Método publico que elimina o deshabilita a los clientes de la base de datos
        * @param ced, cedula del cliente
        * @return bol, si el cliente se dehabilito con éxito o no.
        */
        public bool EliminarCliente(string ced)
        {
            return daoClienteNutricion.DeshabilitarCliente(ced);
        }

        /**
        * Método publico que habilita a los clientes de la base de datos
        * @param ced, cedula del cliente
        * @return bol, si el cliente se habilito con éxito o no.
        */
        public bool HabilitarCliente(string ced)
        {
            return daoClienteNutricion.HabilitarCliente(ced);
        }

        /**
        * Método publico que trae de la Base de datos el historial médico del cliente seleccionado. 
        * @param ced, cedula del cliente
        */
        public HistorialMedico TraerHistorial(string ced)
        {
            HistorialMedico hist = new HistorialMedico();
            TOHistorialMedico hm = daoClienteNutricion.TraerHistorialMed(ced);
            if (hm != null)
            {
                hist.Cedula = hm.Cedula;
                hist.Antecedentes = hm.Antecedentes;
                hist.Patologias = hm.Patologias;
                hist.ConsumeLicor = hm.ConsumeLicor;
                hist.Fuma = hm.Fuma;
                hist.FrecFuma = hm.FrecFuma;
                hist.FrecLicor = hm.FrecLicor;
                hist.UltimoExamen = hm.UltimoExamen;
                hist.ActividadFisica = hm.ActividadFisica;
                return hist;
            }
            else { return null; }
        }

        /**
        * Método publico que trae de la Base de datos la lista de los medicacmentos o suplementos q consume el cliente seleccionado.
        * @param ced, cedula del cliente
        */
        public List<Medicamento> TraerSuplMed(string cedula)
        {
            List<Medicamento> MedList = new List<Medicamento>();
            List<TOMedicamento> list = daoClienteNutricion.ListaSuplMed(cedula);
            if (list != null)
            {
                foreach (TOMedicamento med in list)
                {
                    MedList.Add(new Medicamento(med.Cedula, med.Nombre, med.Motivo, med.Frecuencia, med.Dosis));
                }

            }
            else { return null; }
            return MedList;
        }

        /**
        * Método publico que trae de la Base de datos la información del hábito alimentario del cliente seleccionado.
        * @param ced, cedula del cliente
        */
        public HabitoAlimentario TraerHabitosAlimentario(string cedula)
        {
            TOHabitoAlimentario hab = daoClienteNutricion.ConsultarHabitoAlimentario(cedula);
            if (hab != null)
            {
                HabitoAlimentario habito = new HabitoAlimentario(hab.Cedula, hab.ComidaDiaria, hab.ComidaHorasDia,
                hab.AfueraExpress, hab.ComidaFuera, hab.AzucarBebida, hab.ComidaElaboradCon, hab.AguaDiaria, hab.Aderezos,
                hab.Fruta, hab.Verdura, hab.Leche, hab.Huevo, hab.Yogurt, hab.Carne, hab.Queso, hab.Aguacate, hab.Semillas);
                return habito;
            }
            return null;
        }

        /**
        * Método publico que trae de la Base de datos la lista del recordatorio de 24 horas para el cliente seleccionado.
        * @param ced, cedula del cliente
        */
        public List<Recordatorio24H> TraerRecordatorio24h(string cedula)
        {
            List<TORecordatorio24H> list = daoClienteNutricion.TraerRecord24H(cedula);
            List<Recordatorio24H> listRec = new List<Recordatorio24H>();
            if (list != null)
            {
                foreach (TORecordatorio24H r in list)
                {
                    listRec.Add(new Recordatorio24H(r.Cedula, r.TiempoComida, r.Hora, r.Descripcion));
                }
                return listRec;
            }
            else
            {
                return null;
            }
        }

        /**
        * Método público que trae de la Base de datos la información de antropomentría del cliente seleccionado. 
        * @param ced, cedula del cliente
        */
        public static Antropometria TraerAntrop(string cedula)
        {
            Antropometria antropom = new Antropometria();
            TOAntropometria antrop = daoClienteNutricion.TraerAntropometria(cedula);
            if (antrop != null)
            {
                antropom.Cedula = antrop.Cedula;
                antropom.Talla = antrop.Talla;
                antropom.PesoIdeal = antrop.PesoIdeal;
                antropom.Edad = antrop.Edad;
                antropom.PMB = antrop.PMB;
                antropom.Peso = antrop.Peso;
                antropom.PesoMaxTeoria = antrop.PesoMaxTeoria;
                antropom.IMC = antrop.IMC;
                antropom.PorcGrasaAnalizador = antrop.PorcGrasaAnalizador;
                antropom.PorcGr_Bascula = antrop.PorcGr_Bascula;
                antropom.GB_BI = antrop.GB_BI;
                antropom.GB_BD = antrop.GB_BD;
                antropom.GB_PI = antrop.GB_PI;
                antropom.GB_PD = antrop.GB_PD;
                antropom.GB_Tronco = antrop.GB_Tronco;
                antropom.AguaCorporal = antrop.AguaCorporal;
                antropom.MasaOsea = antrop.MasaOsea;
                antropom.Complexión = antrop.Complexión;
                antropom.EdadMetabolica = antrop.EdadMetabolica;
                antropom.Cintura = antrop.Cintura;
                antropom.Abdomen = antrop.Abdomen;
                antropom.Cadera = antrop.Cadera;
                antropom.MusloDer = antrop.MusloDer;
                antropom.MusloIzq = antrop.MusloIzq;
                antropom.CBM = antrop.CBM;
                antropom.CircunfMunneca = antrop.CircunfMunneca;
                antropom.PorcentGViceral = antrop.PorcentGViceral;
                antropom.PorcentMusculo = antrop.PorcentMusculo;
                antropom.PM_BI = antrop.PM_BI; antropom.PM_PD = antrop.PM_PD;
                antropom.PM_BD = antrop.PM_BD; antropom.PM_PI = antrop.PM_PI; antropom.PM_Tronco = antrop.PM_Tronco;
                antropom.Observaciones = antrop.Observaciones;
                antropom.GEB = antrop.GEB; antropom.GET = antrop.GET;
                antropom.CHOPorc = antrop.CHOPorc;
                antropom.CHOGram = antrop.CHOGram;
                antropom.CHO_kcal = antrop.CHO_kcal;
                antropom.ProteinaPorc = antrop.ProteinaPorc;
                antropom.ProteinaGram = antrop.ProteinaGram;
                antropom.Proteinakcal = antrop.Proteinakcal;
                antropom.GrasaPorc = antrop.GrasaPorc;
                antropom.GrasaGram = antrop.GrasaGram;
                antropom.Grasakcal = antrop.Grasakcal;
                return antropom;
            }
            else { return null; }
        }

        /**
        * Método público que trae de la Base de datos las porciones asignadas al cliente.
        * @param ced, cedula del cliente
        */
        public Porciones TraerPorciones(string cedula)
        {
            TOPorciones porcion = daoClienteNutricion.TraerPorciones(cedula);
            if (porcion != null)
            {
                return new Porciones(porcion.Cedula, porcion.Leche, porcion.Carne, porcion.Vegetales, porcion.Grasa,
                porcion.Fruta, porcion.Azucar, porcion.Harina, porcion.Suplemento);
            }
            else
            {
                return null;
            }
        }

        /**
        * Método publico que trae de la Base de datos la lista de la distribución de porciones del cliente seleccionado.
        * @param ced, cedula del cliente
        */
        public List<DistribucionPorciones> TraerDistribPorc(string cedula)
        {
            List<DistribucionPorciones> lista = new List<DistribucionPorciones>();
            List<TODistribucionPorciones> dis = daoClienteNutricion.TraerDistribucion(cedula);
            if (dis != null)
            {
                foreach (TODistribucionPorciones distribuc in dis)
                {
                    lista.Add(new DistribucionPorciones(distribuc.Descripcion, distribuc.TiempoComida, distribuc.Hora, distribuc.Cedula));
                }
                return lista;
            }
            else
            {
                return null;
            }
        }

        public bool ModificarExped(ClienteNutricion clienteModif, HistorialMedico histModif, HabitoAlimentario habModif, List<Recordatorio24H> listRecordModif, Antropometria antropModif, Porciones porcModif, List<DistribucionPorciones> distrModif)
        {    TOClienteNutricion cliente = new TOClienteNutricion();
            cliente.Cedula = clienteModif.Cedula; cliente.Nombre = clienteModif.Nombre; cliente.Apellido1 = clienteModif.Apellido1; cliente.Apellido2 = clienteModif.Apellido2; cliente.Fecha_Nacimiento = clienteModif.Fecha_Nacimiento;
            cliente.Sexo = clienteModif.Sexo; cliente.Estado_Civil = clienteModif.Estado_Civil; cliente.WhatsApp = clienteModif.WhatsApp; cliente.Telefono = clienteModif.Telefono; cliente.Residencia = clienteModif.Residencia;
            cliente.Ocupacion = clienteModif.Ocupacion; cliente.FechaIngreso = clienteModif.FechaIngreso; cliente.Correo = clienteModif.Correo; cliente.Consultorio = clienteModif.Consultorio; cliente.Estado = clienteModif.Estado;

            TOHistorialMedico histmed = new TOHistorialMedico();
            histmed.Cedula = histModif.Cedula; histmed.Antecedentes = histModif.Antecedentes; histmed.Patologias = histModif.Patologias;
            histmed.ConsumeLicor = histModif.ConsumeLicor; histmed.Fuma = histModif.Fuma; histmed.FrecFuma = histModif.FrecFuma;
            histmed.FrecLicor = histModif.FrecLicor; histmed.UltimoExamen = histModif.UltimoExamen; histmed.ActividadFisica = histModif.ActividadFisica;

            TOHabitoAlimentario habAlime = new TOHabitoAlimentario();
            habAlime.Cedula = habModif.Cedula; habAlime.ComidaDiaria = habModif.ComidaDiaria;  habAlime.ComidaHorasDia = habModif.ComidaHorasDia;
            habAlime.AfueraExpress = habModif.AfueraExpress;  habAlime.ComidaFuera = habModif.ComidaFuera;  habAlime.AzucarBebida = habModif.AzucarBebida;
            habAlime.ComidaElaboradCon = habModif.ComidaElaboradCon;  habAlime.AguaDiaria = habModif.AguaDiaria;
            habAlime.Aderezos = habModif.Aderezos;  habAlime.Fruta = habModif.Fruta;  habAlime.Verdura = habModif.Verdura;  habAlime.Leche = habModif.Leche;
            habAlime.Huevo = habModif.Huevo;  habAlime.Yogurt = habModif.Yogurt;  habAlime.Carne = habModif.Carne;
            habAlime.Queso = habModif.Queso;  habAlime.Aguacate = habModif.Aguacate;  habAlime.Semillas = habAlime.Semillas;

            List<TORecordatorio24H> listRecord = new List<TORecordatorio24H>();
            foreach(Recordatorio24H r in listRecordModif)
            {
                listRecord.Add(new TORecordatorio24H(r.Cedula, r.TiempoComida,r.Hora, r.Descripcion));
            }

            TOAntropometria antrop = new TOAntropometria();
            antrop.Cedula = antropModif.Cedula; antrop.Talla = antropModif.Talla; antrop.PesoIdeal = antropModif.PesoIdeal; antrop.Edad = antropModif.Edad; antrop.PMB = antropModif.PMB;
            antrop.Peso = antropModif.Peso;  antrop.PesoMaxTeoria = antropModif.PesoMaxTeoria;  antrop.IMC = antropModif.IMC;  antrop.PorcGrasaAnalizador = antropModif.PorcGrasaAnalizador;  antrop.PorcGr_Bascula = antropModif.PorcGr_Bascula;
            antrop.GB_BI = antropModif.GB_BI;  antrop.GB_BD = antropModif.GB_BD; antrop.GB_PI = antropModif.GB_PI;  antrop.GB_PD = antropModif.GB_PD;  antrop.GB_Tronco = antropModif.GB_Tronco;
            antrop.AguaCorporal = antropModif.AguaCorporal; antrop.MasaOsea = antropModif.MasaOsea;  antrop.Complexión = antropModif.Complexión;  antrop.EdadMetabolica = antropModif.EdadMetabolica;  antrop.Cintura = antropModif.Cintura;
            antrop.Abdomen = antropModif.Abdomen;  antrop.Cadera = antropModif.Cadera;  antrop.MusloDer = antropModif.MusloDer;  antrop.MusloIzq = antropModif.MusloIzq;  antrop.CBM = antropModif.CBM;
            antrop.CircunfMunneca = antropModif.CircunfMunneca;  antrop.PorcentGViceral = antropModif.PorcentGViceral;  antrop.PorcentMusculo = antropModif.PorcentMusculo;  antrop.PM_BI = antropModif.PM_BI;  antrop.PM_PD = antropModif.PM_PD;
            antrop.PM_BD = antropModif.PM_BD;  antrop.PM_PI = antropModif.PM_PI;  antrop.PM_Tronco = antropModif.PM_Tronco;  antrop.Observaciones = antropModif.Observaciones;
            antrop.GEB = antropModif.GEB;  antrop.GET = antropModif.GET;  antrop.CHOPorc = antropModif.CHOPorc;  antrop.CHOGram = antropModif.CHOGram; antrop.CHO_kcal = antropModif.CHO_kcal;
            antrop.ProteinaPorc = antropModif.ProteinaPorc;  antrop.ProteinaGram = antropModif.ProteinaGram;  antrop.Proteinakcal = antropModif.Proteinakcal; antrop.GrasaPorc = antropModif.GrasaPorc; antrop.GrasaGram = antropModif.GrasaGram;  antrop.Grasakcal = antropModif.Grasakcal;

            TOPorciones porc = new TOPorciones();
            porc.Cedula = porcModif.Cedula; porc.Leche = porcModif.Leche; porc.Carne = porcModif.Carne;
            porc.Vegetales = porcModif.Vegetales;  porc.Grasa = porcModif.Grasa;  porc.Fruta = porcModif.Fruta;
            porc.Azucar = porcModif.Azucar;  porc.Harina = porcModif.Harina; porc.Suplemento = porcModif.Suplemento;

            List<TODistribucionPorciones> listDist = new List<TODistribucionPorciones>();
            foreach(DistribucionPorciones d in distrModif)
            {
                listDist.Add(new TODistribucionPorciones(d.Descripcion, d.TiempoComida, d.Hora, d.Cedula));
            }

            return daoClienteNutricion.ModificarExpediente(cliente, histmed, habAlime, listRecord, antrop, porc, listDist);
        }
    }
}
