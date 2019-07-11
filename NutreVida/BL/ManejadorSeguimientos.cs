﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using TO;

namespace BL
{
    /**
     * Clase ManejadorSeguimiento, maneja los metodos de los seguimientos a la base de datos.
     * @author Yoselyn
    */
    public class ManejadorSeguimientos
    {
        DAOSeguimientos daoSeguimientos = new DAOSeguimientos();

        /**
        * Método publico para agregar los seguimientos semanales a la base de datos.
        * @param SeguimientoSemanal, objeto del tipo seguimiento semanal.
        * @return bool, retorna si se almacenó correctamente o no.
        */
        public bool AgregarSeguimiento(SeguimientoSemanal seguimiento)
        {
            return daoSeguimientos.AgregarSeguimientoSemanal(new TOSeguimientoSemanal(seguimiento.Fecha, seguimiento.Peso, seguimiento.Oreja, seguimiento.Ejercicio, seguimiento.Cedula));
           
        }

        /**
        * Método publico traer la lista de los seguimientos semanales de la base de datos.
        * @param cedula, número de cedula del cliente.
        * @return List, retorna la lista de los seguimientos semanales.
        */
        public List<SeguimientoSemanal> TraerLista(int cedula)
        {
            List<SeguimientoSemanal> listaSeguimiento = new List<SeguimientoSemanal>();
            List<TOSeguimientoSemanal> lista = daoSeguimientos.ListarSeguimSemanal(cedula);
            if (lista != null)
            {
                foreach (TOSeguimientoSemanal seg in lista)
                {
                    listaSeguimiento.Add(new SeguimientoSemanal(seg.Sesion, seg.Fecha, seg.Peso, seg.Oreja, seg.Ejercicio, seg.Cedula));
                }
                return listaSeguimiento;
            }
            else
            {
                return null;
            }
        }

        /**
        * Método publico para agregar los seguimientos mensuales a la base de datos.
        * @param SeguimientoMensual, objeto del tipo seguimiento mensual.
        * @return bool, retorna si se almacenó correctamente o no.
        */
        public bool AgregaSegNutri(SeguimientoMensual seguimiento)
        {

            TOSeguimientoNutricional seg = new TOSeguimientoNutricional();
            List<TOSeguimientoRecordat24H> lisSeg = new List<TOSeguimientoRecordat24H>();
            List<SeguimientoRecordat24H> lista = seguimiento.record;
            TOSeguimientoAntrop segAnt = new TOSeguimientoAntrop();
            seg.Cedula = seguimiento.nutri.Cedula;
            seg.DiasEjercicio = seguimiento.nutri.DiasEjercicio;
            seg.ComidaExtra = seguimiento.nutri.ComidaExtra;
            seg.NivelAnsiedad = seguimiento.nutri.NivelAnsiedad;
            if (lista != null)
            {
                foreach (SeguimientoRecordat24H record in lista)
                {
                    lisSeg.Add(new TOSeguimientoRecordat24H(record.TiempoComida, record.Hora, record.Descripcion));
                }
            }

            segAnt.Edad = seguimiento.antrop.Edad;
            segAnt.Talla = seguimiento.antrop.Talla;
            segAnt.CM = seguimiento.antrop.CM;
            segAnt.Fecha_SA = seguimiento.antrop.Fecha_SA;
            segAnt.Peso = seguimiento.antrop.Peso;
            segAnt.IMC = seguimiento.antrop.IMC;
            segAnt.EdadMetabolica = seguimiento.antrop.EdadMetabolica;
            segAnt.Agua = seguimiento.antrop.Agua;
            segAnt.MasaOsea = seguimiento.antrop.MasaOsea;
            segAnt.PorcGrasaAnalizador = seguimiento.antrop.PorcGrasaAnalizador;
            segAnt.PorcentGViceral = seguimiento.antrop.PorcentGViceral;
            segAnt.PorcGr_Bascula = seguimiento.antrop.PorcGr_Bascula;
            segAnt.GB_BI = seguimiento.antrop.GB_BI;
            segAnt.GB_BD = seguimiento.antrop.GB_BD;
            segAnt.GB_PI = seguimiento.antrop.GB_PI;
            segAnt.GB_PD = seguimiento.antrop.GB_PD;
            segAnt.GB_Tronco = seguimiento.antrop.GB_Tronco;
            segAnt.PorcentMusculo = seguimiento.antrop.PorcentMusculo;
            segAnt.PM_BI = seguimiento.antrop.PM_BI;
            segAnt.PM_PD = seguimiento.antrop.PM_PD;
            segAnt.PM_BD = seguimiento.antrop.PM_BD;
            segAnt.PM_PI = seguimiento.antrop.PM_PI;
            segAnt.PM_Tronco = seguimiento.antrop.PM_Tronco;
            segAnt.CircunfCintura = seguimiento.antrop.CircunfCintura;
            segAnt.Cadera = seguimiento.antrop.Cadera;
            segAnt.MusloIzq = seguimiento.antrop.MusloIzq;
            segAnt.MusloDer = seguimiento.antrop.MusloDer;
            segAnt.BrazoIzq = seguimiento.antrop.BrazoIzq;
            segAnt.BrazoDer = seguimiento.antrop.BrazoDer;
            segAnt.PesoIdeal = seguimiento.antrop.PesoIdeal;
            segAnt.Observaciones = seguimiento.antrop.Observaciones;

            return daoSeguimientos.GuardarSeguimientoMensual(seg, lisSeg, segAnt);

        }

        public List<SeguimientoMensual> TraerListaMensual(int cedula)
        {
            List<TOSeguimientoMensual> seguimientoLista = daoSeguimientos.ListarMensual(cedula);
            List<SeguimientoMensual> mensualLista = new List<SeguimientoMensual>();
            if (seguimientoLista != null)
            {
                foreach (TOSeguimientoMensual seguimiento in seguimientoLista)
                {
                    SeguimientoNutricional seg = new SeguimientoNutricional();
                    List<SeguimientoRecordat24H> lisSeg = new List<SeguimientoRecordat24H>();
                    List<TOSeguimientoRecordat24H> lista = seguimiento.record;
                    SeguimientoAntrop segAnt = new SeguimientoAntrop();
                    seg.Cedula = seguimiento.nutri.Cedula;
                    seg.DiasEjercicio = seguimiento.nutri.DiasEjercicio;
                    seg.ComidaExtra = seguimiento.nutri.ComidaExtra;
                    seg.NivelAnsiedad = seguimiento.nutri.NivelAnsiedad;
                    if (lista != null)
                    {
                        foreach (TOSeguimientoRecordat24H record in lista)
                        {
                            lisSeg.Add(new SeguimientoRecordat24H(record.TiempoComida, record.Hora, record.Descripcion));
                        }
                    }

                    segAnt.Edad = seguimiento.antrop.Edad;
                    segAnt.Talla = seguimiento.antrop.Talla;
                    segAnt.CM = seguimiento.antrop.CM;
                    segAnt.Fecha_SA = seguimiento.antrop.Fecha_SA;
                    segAnt.Peso = seguimiento.antrop.Peso;
                    segAnt.IMC = seguimiento.antrop.IMC;
                    segAnt.EdadMetabolica = seguimiento.antrop.EdadMetabolica;
                    segAnt.Agua = seguimiento.antrop.Agua;
                    segAnt.MasaOsea = seguimiento.antrop.MasaOsea;
                    segAnt.PorcGrasaAnalizador = seguimiento.antrop.PorcGrasaAnalizador;
                    segAnt.PorcentGViceral = seguimiento.antrop.PorcentGViceral;
                    segAnt.PorcGr_Bascula = seguimiento.antrop.PorcGr_Bascula;
                    segAnt.GB_BI = seguimiento.antrop.GB_BI;
                    segAnt.GB_BD = seguimiento.antrop.GB_BD;
                    segAnt.GB_PI = seguimiento.antrop.GB_PI;
                    segAnt.GB_PD = seguimiento.antrop.GB_PD;
                    segAnt.GB_Tronco = seguimiento.antrop.GB_Tronco;
                    segAnt.PorcentMusculo = seguimiento.antrop.PorcentMusculo;
                    segAnt.PM_BI = seguimiento.antrop.PM_BI;
                    segAnt.PM_PD = seguimiento.antrop.PM_PD;
                    segAnt.PM_BD = seguimiento.antrop.PM_BD;
                    segAnt.PM_PI = seguimiento.antrop.PM_PI;
                    segAnt.PM_Tronco = seguimiento.antrop.PM_Tronco;
                    segAnt.CircunfCintura = seguimiento.antrop.CircunfCintura;
                    segAnt.Cadera = seguimiento.antrop.Cadera;
                    segAnt.MusloIzq = seguimiento.antrop.MusloIzq;
                    segAnt.MusloDer = seguimiento.antrop.MusloDer;
                    segAnt.BrazoIzq = seguimiento.antrop.BrazoIzq;
                    segAnt.BrazoDer = seguimiento.antrop.BrazoDer;
                    segAnt.PesoIdeal = seguimiento.antrop.PesoIdeal;
                    segAnt.Observaciones = seguimiento.antrop.Observaciones;

                    SeguimientoMensual s = new SeguimientoMensual();
                    s.antrop = segAnt;
                    s.nutri = seg;
                    s.record = lisSeg;
                    s.Fecha = seguimiento.Fecha;
                    s.idSeg = seguimiento.idSeg;
                    mensualLista.Add(s);
                }
            }
            else { return null; }

            return mensualLista;
        }
    }
}
