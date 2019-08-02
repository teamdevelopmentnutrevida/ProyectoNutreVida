using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
    public partial class VerSeguimiento : System.Web.UI.Page
    {
        List<SeguimientoMensual> listaSegNutri = new List<SeguimientoMensual>();
        ManejadorSeguimientos manejador = new ManejadorSeguimientos();
        string idSeguim;
        string Cedula;
        protected void Page_Load(object sender, EventArgs e)
        {
            idSeguim = HttpContext.Current.Session["idSeguimiento"] as string;
            Cedula = HttpContext.Current.Session["ced"] as string;
            listaSegNutri = manejador.TraerListaMensual(Int32.Parse(Cedula));
            CargarDatos();
        }

        public void CargarDatos()
        {
            int idS = Int32.Parse(idSeguim); 
          
                foreach (SeguimientoMensual s in listaSegNutri)
                {
                    if (s.idSeg == idS)
                    {
                        VerDiasEjercSem.Text = s.nutri.DiasEjercicio;
                        VerComExt.Text = s.nutri.ComidaExtra;
                        VerAnsied.Text = s.nutri.NivelAnsiedad;

                        foreach (SeguimientoRecordat24H rec in s.record)
                        {
                            if (rec.TiempoComida.Equals("Ayunas")) { VerAyunHora.Text = rec.Hora; VerAyunDescr.Text = rec.Descripcion; }
                            else
                            {
                                if (rec.TiempoComida.Equals("Desayuno")) { VerDesHora.Text = rec.Hora; VerDesDescrp.Text = rec.Descripcion; }
                                else
                                {
                                    if (rec.TiempoComida.Equals("Media Mañana")) { VerMedManHora.Text = rec.Hora; VerMedManDesc.Text = rec.Descripcion; }
                                    else
                                    {
                                        if (rec.TiempoComida.Equals("Almuerzo")) { VerAlmHora.Text = rec.Hora; VerAlmDesc.Text = rec.Descripcion; }
                                        else
                                        {
                                            if (rec.TiempoComida.Equals("Media Tarde")) { VerMedTarHora.Text = rec.Hora; VerMedTarDesc.Text = rec.Descripcion; }
                                            else
                                            {
                                                if (rec.TiempoComida.Equals("Cena")) { VerCenaHora.Text = rec.Hora; VerCenaDesc.Text = rec.Descripcion; }
                                                else
                                                {
                                                    if (rec.TiempoComida.Equals("Colación Nocturna")) { VerColNocHora.Text = rec.Hora; VerColNocDesc.Text = rec.Descripcion; }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (s.antrop != null)
                        {
                            VerSAFech.Text = s.antrop.Fecha_SA.ToString("yyyy-MM-dd");
                            VerSAEdad.Text = s.antrop.Edad + "";
                            VerSATalla.Text = s.antrop.Talla + "";
                            VerSACM.Text = s.antrop.CM + "";
                            VerSAPeso.Text = s.antrop.Peso + "";
                            VerSAIMC.Text = s.antrop.IMC + "";
                            VerSAAgua.Text = s.antrop.Agua + "";
                            VerSAMasaOsea.Text = s.antrop.MasaOsea + "";
                            VerSAEddMet.Text = s.antrop.EdadMetabolica + "";
                            VerSAGrAnaliz.Text = s.antrop.PorcGrasaAnalizador + "";
                            VerSAGrBasc.Text = s.antrop.PorcGr_Bascula + "";
                            VerSAGBBI.Text = s.antrop.GB_BI + "";
                            VerSAGBBD.Text = s.antrop.GB_BD + "";
                            VerSAGBPI.Text = s.antrop.GB_PI + "";
                            VerSAGBPD.Text = s.antrop.GB_PD + "";
                            VerSAGBTronco.Text = s.antrop.GB_Tronco + "";
                            VerSAGrVisc.Text = s.antrop.PorcentGViceral + "";
                            VerSAPorMusc.Text = s.antrop.PorcentMusculo + "";
                            VerSAPMBI.Text = s.antrop.PM_BI + "";
                            VerSAPMBD.Text = s.antrop.PM_BD + "";
                            VerSAPMPI.Text = s.antrop.PM_PI + "";
                            VerSAPMPD.Text = s.antrop.PM_PD + "";
                            VerSAPMTronco.Text = s.antrop.PM_Tronco + "";
                            VerSACircunfCint.Text = s.antrop.CircunfCintura + "";
                            VerSACadera.Text = s.antrop.Cadera + "";
                            VerSAMusIzq.Text = s.antrop.MusloIzq + "";
                            VerSAMusDer.Text = s.antrop.MusloDer + "";
                            VerSABrazIzq.Text = s.antrop.BrazoIzq + "";
                            VerSABrazDer.Text = s.antrop.BrazoDer + "";
                            VerSAPesoMet.Text = s.antrop.PesoIdeal + "";
                            VerSNObserv.Text = s.antrop.Observaciones;
                        }
                    }
                }
         }


        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cliente.aspx");
        }
    }
}