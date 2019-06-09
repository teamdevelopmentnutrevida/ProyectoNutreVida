using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using TO;

namespace BL
{
    public class ManejadorSeguimientos
    {
        DAOSeguimientos daoSeguimientos = new DAOSeguimientos();
        public bool AgregarSeguimiento(SeguimientoSemanal seguimiento)
        {
            return daoSeguimientos.AgregarSeguimientoSemanal(new TOSeguimientoSemanal(seguimiento.Fecha, seguimiento.Peso, seguimiento.Oreja, seguimiento.Ejercicio, seguimiento.Cedula));
        }

        public List<SeguimientoSemanal> TraerLista(string cedula)
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

        public bool AgregaSegNutri(SeguimientoNutricional nutri, List<SeguimientoRecordat24H> lista, SeguimientoAntrop segAntrop)
        {

            TOSeguimientoNutricional seg = new TOSeguimientoNutricional();
            List<TOSeguimientoRecordat24H> lisSeg = new List<TOSeguimientoRecordat24H>();
            TOSeguimientoAntrop segAnt = new TOSeguimientoAntrop();
            seg.Cedula = nutri.Cedula;
            seg.DiasEjercicio = nutri.DiasEjercicio;
            seg.ComidaExtra = nutri.ComidaExtra;
            seg.NivelAnsiedad = nutri.NivelAnsiedad;
            if (lisSeg != null)
            {
                foreach (SeguimientoRecordat24H record in lista)
                {
                    lisSeg.Add(new TOSeguimientoRecordat24H(record.TiempoComida, record.Descripcion));
                }
            }
            segAnt.Talla = segAntrop.Talla;
            segAnt.PesoIdeal = segAntrop.PesoIdeal;
            segAnt.Edad = segAntrop.Edad;
            segAnt.PMB = segAntrop.PMB;
            segAnt.Fecha_SA = segAntrop.Fecha_SA;
            segAnt.Peso = segAntrop.Peso;
            segAnt.IMC = segAntrop.IMC;
            segAnt.PorcGrasaAnalizador = segAntrop.PorcGrasaAnalizador;
            segAnt.PorcGr_Bascula = segAntrop.PorcGr_Bascula;
            segAnt.GB_BI = segAntrop.GB_BI;
            segAnt.GB_BD = segAntrop.GB_BD;
            segAnt.GB_PI = segAntrop.GB_PI;
            segAnt.GB_PD = segAntrop.GB_PD;
            segAnt.GB_Tronco = segAntrop.GB_Tronco;
            segAnt.PorcentGViceral = segAntrop.PorcentGViceral;
            segAnt.PorcentMusculo = segAntrop.PorcentMusculo;
            segAnt.PM_BI = segAntrop.PM_BI;
            segAnt.PM_PD = segAntrop.PM_PD;
            segAnt.PM_BD = segAntrop.PM_BD;
            segAnt.PM_PI = segAntrop.PM_PI;
            segAnt.PM_Tronco = segAntrop.PM_Tronco;
            segAnt.AguaCorporal = segAntrop.AguaCorporal;
            segAnt.MasaOsea = segAntrop.MasaOsea;
            segAnt.Complexión = segAntrop.Complexión;
            segAnt.EdadMetabolica = segAntrop.EdadMetabolica;
            segAnt.Cintura = segAntrop.Cintura;
            segAnt.Abdomen = segAntrop.Abdomen;
            segAnt.Cadera = segAntrop.Cadera;
            segAnt.Muslo = segAntrop.Muslo;
            segAnt.Brazo = segAntrop.Brazo;
            segAnt.Observaciones = segAntrop.Observaciones;

            return daoSeguimientos.GuardarSeguimientoMensual(seg, lisSeg, segAnt);

        }
    }
}
