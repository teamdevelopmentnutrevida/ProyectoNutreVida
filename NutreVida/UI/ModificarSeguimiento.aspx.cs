using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
    public partial class ModificarSeguimiento : System.Web.UI.Page
    {
        public static SeguimientoMensual SegMensual;
        ManejadorSeguimientos manejador = new ManejadorSeguimientos();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (new ControlSeguridad().validarNutri() == true)
            //{
            //    Response.Redirect("~/InicioSesion.aspx");
            //}

            if (!IsPostBack)
            {
                SegMensual = HttpContext.Current.Session["SegModif"] as SeguimientoMensual;
                CargarDatos();
            }
        }

        public void CargarDatos()
        {
            DiasEjercSem.Text = SegMensual.nutri.DiasEjercicio;
            ComExt.Text = SegMensual.nutri.ComidaExtra;
            Ansied.Text = SegMensual.nutri.NivelAnsiedad;
            foreach (SeguimientoRecordat24H R in SegMensual.record)
            {
                if (R.TiempoComida.Equals("Ayunas")) { VerAyunHora.Text = R.Hora; VerAyunDescr.Text = R.Descripcion; }
                else if(R.TiempoComida.Equals("Desayuno")) { VerDesHora.Text = R.Hora; VerDesDescrp.Text = R.Descripcion; }
                else if (R.TiempoComida.Equals("Media Mañana")) { VerMedManHora.Text = R.Hora; VerMedManDesc.Text = R.Descripcion; }
                else if(R.TiempoComida.Equals("Almuerzo")) { VerAlmHora.Text = R.Hora; VerAlmDesc.Text = R.Descripcion; }
                else if (R.TiempoComida.Equals("Media Tarde")) { VerMedTarHora.Text = R.Hora; VerMedTarDesc.Text = R.Descripcion; }
                else if (R.TiempoComida.Equals("Cena")) { VerCenaHora.Text = R.Hora; VerCenaDesc.Text = R.Descripcion; }
                else if (R.TiempoComida.Equals("Colación Nocturna")) { VerColNocHora.Text = R.Hora; VerColNocDesc.Text = R.Descripcion; }
            }
            VerSAFech.Text = (SegMensual.antrop.Fecha_SA.ToString("yyyy-MM-dd"));
            VerSAEdad.Text = SegMensual.antrop.Edad + "";
            VerSATalla.Text = SegMensual.antrop.Talla + "";
            VerSACM.Text = SegMensual.antrop.CM + "";
            VerSAPeso.Text = SegMensual.antrop.Peso + "";
            VerSAIMC.Text = SegMensual.antrop.IMC + "";
            VerSAAgua.Text = SegMensual.antrop.Agua + "";
            VerSAMasaOsea.Text = SegMensual.antrop.MasaOsea + "";
            VerSAEddMet.Text = SegMensual.antrop.EdadMetabolica + "";
            VerSAGrAnaliz.Text = SegMensual.antrop.PorcGrasaAnalizador + "";
            VerSAGrBasc.Text = SegMensual.antrop.PorcGr_Bascula + "";
            VerSAGBBI.Text = SegMensual.antrop.GB_BI + "";
            VerSAGBBD.Text = SegMensual.antrop.GB_BD + "";
            VerSAGBPI.Text = SegMensual.antrop.GB_PI + "";
            VerSAGBPD.Text = SegMensual.antrop.GB_PD + "";
            VerSAGBTronco.Text = SegMensual.antrop.GB_Tronco + "";
            VerSAGrVisc.Text = SegMensual.antrop.PorcentGViceral + "";
            VerSAPorMusc.Text = SegMensual.antrop.PorcentMusculo + "";
            VerSAPMBI.Text = SegMensual.antrop.PM_BI + "";
            VerSAPMBD.Text = SegMensual.antrop.PM_BD + "";
            VerSAPMPI.Text = SegMensual.antrop.PM_PI + "";
            VerSAPMPD.Text = SegMensual.antrop.PM_PD + "";
            VerSAPMTronco.Text = SegMensual.antrop.PM_Tronco + "";
            VerSACircunfCint.Text = SegMensual.antrop.CircunfCintura + "";
            VerSACadera.Text = SegMensual.antrop.Cadera + "";
            VerSAMusIzq.Text = SegMensual.antrop.MusloIzq + "";
            VerSAMusDer.Text = SegMensual.antrop.MusloDer + "";
            VerSABrazIzq.Text = SegMensual.antrop.BrazoIzq + "";
            VerSABrazDer.Text = SegMensual.antrop.BrazoDer + "";
            VerSAPesoMet.Text = SegMensual.antrop.PesoIdeal + "";
            VerSNObserv.Text = SegMensual.antrop.Observaciones + "";

        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cliente.aspx");
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            SegMensual.nutri.DiasEjercicio = DiasEjercSem.Text;
            SegMensual.nutri.ComidaExtra = ComExt.Text;
            SegMensual.nutri.NivelAnsiedad = Ansied.Text;
            foreach (SeguimientoRecordat24H R in SegMensual.record)
            {
                if (R.TiempoComida.Equals("Ayunas")) { R.Hora = VerAyunHora.Text; R.Descripcion = VerAyunDescr.Text; }
                else if (R.TiempoComida.Equals("Desayuno")) { R.Hora = VerDesHora.Text; R.Descripcion = VerDesDescrp.Text; }
                else if (R.TiempoComida.Equals("Media Mañana")) { R.Hora = VerMedManHora.Text; R.Descripcion = VerMedManDesc.Text; }
                else if (R.TiempoComida.Equals("Almuerzo")) { R.Hora = VerAlmHora.Text; R.Descripcion = VerAlmDesc.Text; }
                else if (R.TiempoComida.Equals("Media Tarde")) {  R.Hora = VerMedTarHora.Text;  R.Descripcion = VerMedTarDesc.Text; }
                else if (R.TiempoComida.Equals("Cena")) { R.Hora= VerCenaHora.Text;   R.Descripcion = VerCenaDesc.Text; }
                else if (R.TiempoComida.Equals("Colación Nocturna")) {  R.Hora = VerColNocHora.Text; R.Descripcion = VerColNocDesc.Text; }
            }
            SegMensual.antrop.Fecha_SA = DateTime.Parse(VerSAFech.Text);
            SegMensual.antrop.Edad = decimal.Parse(VerSAEdad.Text);
            SegMensual.antrop.Talla = decimal.Parse(VerSATalla.Text);
            SegMensual.antrop.CM = decimal.Parse(VerSACM.Text);
            SegMensual.antrop.Peso = decimal.Parse(VerSAPeso.Text);
            SegMensual.antrop.IMC = decimal.Parse(VerSAIMC.Text);
            SegMensual.antrop.Agua= decimal.Parse(VerSAAgua.Text);
            SegMensual.antrop.MasaOsea = decimal.Parse(VerSAMasaOsea.Text);
            SegMensual.antrop.EdadMetabolica = decimal.Parse(VerSAEddMet.Text);
            SegMensual.antrop.PorcGrasaAnalizador = decimal.Parse(VerSAGrAnaliz.Text);
            SegMensual.antrop.PorcGr_Bascula = decimal.Parse(VerSAGrBasc.Text);
            SegMensual.antrop.GB_BI = decimal.Parse(VerSAGBBI.Text);
            SegMensual.antrop.GB_BD = decimal.Parse(VerSAGBBD.Text);
            SegMensual.antrop.GB_PI = decimal.Parse(VerSAGBPI.Text);
            SegMensual.antrop.GB_PD = decimal.Parse(VerSAGBPD.Text);
            SegMensual.antrop.GB_Tronco = decimal.Parse(VerSAGBTronco.Text);
            SegMensual.antrop.PorcentGViceral = decimal.Parse(VerSAGrVisc.Text);
            SegMensual.antrop.PorcentMusculo = decimal.Parse(VerSAPorMusc.Text);
            SegMensual.antrop.PM_BI = decimal.Parse(VerSAPMBI.Text);
            SegMensual.antrop.PM_BD = decimal.Parse(VerSAPMBD.Text);
            SegMensual.antrop.PM_PI = decimal.Parse(VerSAPMPI.Text);
            SegMensual.antrop.PM_PD = decimal.Parse(VerSAPMPD.Text);
            SegMensual.antrop.PM_Tronco = decimal.Parse(VerSAPMTronco.Text);
            SegMensual.antrop.CircunfCintura = decimal.Parse(VerSACircunfCint.Text);
            SegMensual.antrop.Cadera = decimal.Parse(VerSACadera.Text);
            SegMensual.antrop.MusloIzq = decimal.Parse(VerSAMusIzq.Text);
            SegMensual.antrop.MusloDer = decimal.Parse(VerSAMusDer.Text);
            SegMensual.antrop.BrazoIzq = decimal.Parse(VerSABrazIzq.Text);
            SegMensual.antrop.BrazoDer = decimal.Parse(VerSABrazDer.Text);
            SegMensual.antrop.PesoIdeal = decimal.Parse(VerSAPesoMet.Text);
           SegMensual.antrop.Observaciones = VerSNObserv.Text;

            bool exito = manejador.ModificarSeguim(SegMensual);
            if (exito)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MensajeÉxito", "mensajeError('success', 'Bien!', 'Seguimiento Nutricional se ha modificado exitosamente!')", true);
                btnAtras.Text = "Atrás";
                Guardar.Visible = false;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MensajeError", "mensajeError('error', 'Error al modificar', 'Error al modificar el seguimiento nutricional')", true);
            }
        }
    }
}