using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Microsoft.VisualBasic;
using System.Web.UI.WebControls.WebParts;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Text;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Net;
using System.Data.SqlClient;
using iTextSharp.text.html.simpleparser;




namespace UI
{
    /**
     * Clase Cliente, muestra la información del expediente y administra la acción del botón.
     * @author Yoselyn
    */
    public partial class Cliente : System.Web.UI.Page
    {

        private static string Cedula = "";
        private static List<SeguimientoSemanal> listaSeguimientos = new List<SeguimientoSemanal>();
        private static List<Medicamento> ListmedicamSupl = new List<Medicamento>();
        private static List<SeguimientoMensual> listaSegNutri = new List<SeguimientoMensual>();
        private static ManejadorSeguimientos manejadorSeg = new ManejadorSeguimientos();
        private static ManejadorExpediente manejExpediente = new ManejadorExpediente();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (new ControlSeguridad().validarNutri() == true)
            {
                Response.Redirect("~/InicioSesion.aspx");
            }

            if (!IsPostBack)
            {
                CargarDatos();
            }


        }
        
        /**
        * Método privado que carga la seccion de la información personal del cliente seleccionado 
        */
        private void CargarDatos()
        {
            Cedula = HttpContext.Current.Session["ced"] as string;
            CargarInfoPersonal();
            CargarHistorialMedico();
            CargarHabitosAlimentarios();
            CargarAntropometría();
            CargarSeguimientoSemanal();
            CargarSeguimientoNutricional();
            CargarAnterior();
           
        }

        /**
        * Método privado que carga la seccion de la información personal del cliente seleccionado 
        */
        private void CargarInfoPersonal()
        {
            if (Cedula != "")
            {
                ClienteNutricion c = manejExpediente.TraerInformación(Cedula);
                if (c != null)
                {
                    ced1.Text = c.Cedula + "";
                    txtOcup.Text = c.Ocupacion;
                    txtTel.Text = c.Telefono + "";
                    ConsultorDropList.Text = c.Consultorio;
                    txtNombre.Text = c.Nombre;
                    txtEmail.Text = c.Correo;
                    if (c.WhatsApp == '1') { dropWhats.Text = "Sí"; } else { dropWhats.Text = "No"; }
                    EdadCliente.Text = CalcularEdad(c.Fecha_Nacimiento);
                    txtPrimerApellido.Text = c.Apellido1;
                    dropEstadoCivil.Text = c.Estado_Civil;
                    txtResid.Text = c.Residencia;
                    FechIngreso.Text = c.FechaIngreso.ToString("yyyy-MM-dd");
                    txtSegundoApellido.Text = c.Apellido2;
                    if (c.Sexo.Equals('F')) { dropSexo.Text = "Femenino"; dropSexo.SelectedValue = "F"; } else { if (c.Sexo.Equals('M')) { dropSexo.Text = "Masculino"; dropSexo.SelectedValue = "M"; } else { dropSexo.Text = "Otro"; dropSexo.SelectedValue = "O"; } }
                    FechNacimi.Text = c.Fecha_Nacimiento.ToString("yyyy-MM-dd");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "mensajeError", "mensajeError('error', 'Error de Carga de Datos', 'Error al cargar los datos del cliente')", true);
                }

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "mensajeError", "mensajeError('error', 'Error de Carga Cédula', 'Error al cargar los datos del cliente')", true);
            }
        }

        /**
        * Método privado para calcular la edad
        * @param fechaNac, fecha de nacimiento del cliente para calcular la edad
        */
        private string CalcularEdad(DateTime fechaNac)
        {
            if (fechaNac.Equals("")) { return ""; }
            else
            {
                int años = DateTime.Now.Year - fechaNac.Year;
                if (fechaNac.Month > DateTime.Now.Month) { return años - 1 + ""; }
                else
                {
                    if (fechaNac.Month == DateTime.Now.Month)
                    {
                        if (fechaNac.Day < DateTime.Now.Day) { return años - 1 + ""; }
                        else { return años + ""; }
                    }
                    else { return años + ""; }
                }
            }
        }

        /**
        * Método privado que carga la seccion de la Historial Médico del cliente seleccionado 
        */
        private void CargarHistorialMedico()
        {
            if (Cedula != "")
            {
                HistorialMedico hm = manejExpediente.TraerHistorial(Cedula);
                if (hm != null)
                {
                    string l = "";
                    string f = "";
                    if (hm.ConsumeLicor == 1) { l = "Sí"; } else { l = "No"; }
                    if (hm.Fuma == 1) { f = "Sí"; } else { f = "No"; }
                    txtAntec.Text = hm.Antecedentes;
                    txtPatol.Text = hm.Patologias;
                    txtActividadFisica.Text = hm.ActividadFisica;
                    DropLicor.Text = l;
                    DropFuma.Text = f;
                    txtFrecLicor.Text = hm.FrecLicor;
                    txtFrecFuma.Text = hm.FrecFuma;
                    FechRevMedica.Text = hm.UltimoExamen;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "mensajeError", "mensajeError('error', 'Error con el Historial Médico', 'Error al cargar datos del Historial Médico')", true);
                }
                CargarTablaMedicamentos();
            }
        }

        /**
       * Método privado que carga la lista de medicamentos o suplementos que el cliente consume
       */
        private void CargarTablaMedicamentos()
        {
           
            ListmedicamSupl = manejExpediente.TraerSuplMed(Cedula);
            if (ListmedicamSupl != null)
            {
                foreach (Medicamento med in ListmedicamSupl)
                {
                    tSuplementoMedico.Text += "<tr><td>" + med.Nombre + "</td><td>" + med.Motivo + "</td><td>" + med.Frecuencia + "</td><td>" + med.Dosis + "</td></tr>";
                }

            }
            else
            {
                tSuplementoMedico.Text = "No consume medicamentos ni suplementos";
            }

        }

        /**
       * Método privado que carga los hábitos alimentarios del cliente seleccionado 
       */
        private void CargarHabitosAlimentarios()
        {
            HabitoAlimentario hab = manejExpediente.TraerHabitosAlimentario(Cedula);
            if (hab != null)
            {
                numeroComidas.Text = hab.ComidaDiaria + "";
                string horasdia = ""; if (hab.ComidaHorasDia == 1) { horasdia = "Sí"; } else { horasdia = "No"; }
                ComeHoras.Text = horasdia;
                txtEspres.Text = hab.AfueraExpress + "";
                txtQueComeFuera.Text = hab.ComidaFuera;
                cantAzucar.Text = hab.AzucarBebida;
                dropCocinaCon.Text = hab.ComidaElaboradCon;
                txtCuantaAgua.Text = hab.AguaDiaria + "";
                string aderez = ""; if (hab.Aderezos.Equals('1')) { aderez = "Sí"; } else { aderez = "No"; }
                dropAderezos.Text = aderez;
                string fruta = ""; if (hab.Fruta.Equals('1')) { fruta = "Sí"; } else { fruta = "No"; }
                dropFrutas.Text = fruta;
                string verdur = ""; if (hab.Verdura.Equals('1')) { verdur = "Sí"; } else { verdur = "No"; }
                dropVeget.Text = verdur;
                string leche = ""; if (hab.Leche.Equals('1')) { leche = "Sí"; } else { leche = "No"; }
                dropLeche.Text = leche;
                string huevo = ""; if (hab.Huevo.Equals('1')) { huevo = "Sí"; } else { huevo = "No"; }
                dropHuevo.Text = huevo;
                string yogurt = ""; if (hab.Yogurt.Equals('1')) { yogurt = "Sí"; } else { yogurt = "No"; }
                dropYogurt.Text = yogurt;
                string carne = ""; if (hab.Carne.Equals('1')) { carne = "Sí"; } else { carne = "No"; }
                dropCarne.Text = carne;
                string queso = ""; if (hab.Queso.Equals('1')) { queso = "Sí"; } else { queso = "No"; }
                dropQueso.Text = queso;
                string aguacate = ""; if (hab.Aguacate.Equals('1')) { aguacate = "Sí"; } else { aguacate = "No"; }
                dropAguacate.Text = aguacate;
                string semillas = ""; if (hab.Semillas.Equals('1')) { semillas = "Sí"; } else { semillas = "No"; }
                dropSemillas.Text = semillas;

                List<Recordatorio24H> record = manejExpediente.TraerRecordatorio24h(Cedula);
                if (record != null)
                {
                    foreach (Recordatorio24H r in record)
                    {
                        if (r.TiempoComida.Equals("Ayunas")) { txtHoraAyunas.Text = r.Hora; txtDescAyunas.Text = r.Descripcion; }
                        if (r.TiempoComida.Equals("Desayuno")) { txtHoraDesayuno.Text = r.Hora; txtDescDesay.Text = r.Descripcion; }
                        if (r.TiempoComida.Equals("Media mañana")) { txtHoraMediaM.Text = r.Hora; txtDescMediaM.Text = r.Descripcion; }
                        if (r.TiempoComida.Equals("Almuerzo")) { txtHoraAlmmuerzo.Text = r.Hora; txtDescAlmuerzo.Text = r.Descripcion; }
                        if (r.TiempoComida.Equals("Tarde")) { txtHoraTarde.Text = r.Hora; txtDescTarde.Text = r.Descripcion; }
                        if (r.TiempoComida.Equals("Cena")) { txtHoraCena.Text = r.Hora; txtDescCena.Text = r.Descripcion; }
                        if (r.TiempoComida.Equals("Colasión nocturna")) { txtHoraColacion.Text = r.Hora; txtDescColacion.Text = r.Descripcion; }
                    }
                }
            }

        }

        /**
        * Método privado que carga los datos de antropometría del cliente seleccionado 
        */
        private void CargarAntropometría()
        {
            Antropometria antrop = ManejadorExpediente.TraerAntrop(Cedula);
            if (antrop != null)
            {
                txtEdad.Text = antrop.Edad + "";
                txtPesoActual.Text = antrop.Peso + "";
                txtPesoMaxTeoria.Text = antrop.PesoMaxTeoria + "";
                txtPesoIdeal.Text = antrop.PesoIdeal + "";
                txtEdadMetabolica.Text = antrop.EdadMetabolica + "";
                txtCintura.Text = antrop.Cintura + "";
                txtAbdomen.Text = antrop.Abdomen + "";
                txtCadera.Text = antrop.Cadera + "";
                txtMusloIzq.Text = antrop.MusloIzq + "";
                txtMusloDer.Text = antrop.MusloDer + "";
                txtPMB.Text = antrop.PMB + "";
                txtCMB.Text = antrop.CBM + "";
                txtAgua.Text = antrop.AguaCorporal + "";
                txtComplexion.Text = antrop.Complexión + "";
                txtMasaOsea.Text = antrop.MasaOsea + "";
                txtTalla.Text = antrop.Talla + "";
                txtGrasaAnalizador.Text = antrop.PorcGrasaAnalizador + "";
                txtGarsaViceral.Text = antrop.PorcentGViceral + "";
                txtGrasaBascula.Text = antrop.PorcGr_Bascula + "";
                txtGB_BI.Text = antrop.GB_BI + "";
                txtGB_BD.Text = antrop.GB_BD + "";
                txtGB_PI.Text = antrop.GB_PI + "";
                txtGB_PD.Text = antrop.GB_PD + "";
                txtGB_Trono.Text = antrop.GB_Tronco + "";
                txtCircunferencia.Text = antrop.CircunfMunneca + "";
                txtIMC.Text = antrop.IMC + "";
                txtPorcentaje.Text = antrop.PorcentMusculo + "";
                txtPM_BI.Text = antrop.PM_BI + "";
                txtPM_BD.Text = antrop.PM_BD + "";
                txtPM_PI.Text = antrop.PM_PI + "";
                txtPM_PD.Text = antrop.PM_PD + "";
                txtPM_Tronco.Text = antrop.PM_Tronco + "";
                txtObservaciones.Text = antrop.Observaciones;
                txtGEB.Text = antrop.GEB + "";
                txtGET.Text = antrop.GET + "";
                choPorc.Text = antrop.CHOPorc + "";
                choGram.Text = antrop.CHOGram + "";
                choKcal.Text = antrop.CHO_kcal + "";
                ProtPorc.Text = antrop.ProteinaPorc + "";
                ProtGram.Text = antrop.ProteinaGram + "";
                protKcal.Text = antrop.Proteinakcal + "";
                GrasPorc.Text = antrop.GrasaPorc + "";
                GrasGram.Text = antrop.GrasaGram + "";
                GrasKcal.Text = antrop.Grasakcal + "";
                Porciones porcion = manejExpediente.TraerPorciones(Cedula);
                if (porcion != null)
                {
                    txtPorcLeche.Text = porcion.Leche + "";
                    txtPorcCarnes.Text = porcion.Carne + "";
                    txtPorcVeget.Text = porcion.Vegetales + "";
                    txtPorcGrasas.Text = porcion.Grasa + "";
                    txtPorcFrutas.Text = porcion.Fruta + "";
                    txtPorcAzucar.Text = porcion.Azucar + "";
                    txtPorcHarinas.Text = porcion.Harina + "";
                    txtPorcSuplem.Text = porcion.Suplemento + "";
                }

                List<DistribucionPorciones> distrib = manejExpediente.TraerDistribPorc(Cedula);
                if (distrib != null)
                {
                    foreach (DistribucionPorciones distr in distrib)
                    {
                        if (distr.TiempoComida.Equals("Ayunas")) { txtHoraAyunasA.Text = distr.Hora; txtDescAyunasA.Text = distr.Descripcion; }
                        if (distr.TiempoComida.Equals("Desayuno")) { txtHoraDesayunoA.Text = distr.Hora; txtDescDesayA.Text = distr.Descripcion; }
                        if (distr.TiempoComida.Equals("Media mañana")) { txtHoraMediaMA.Text = distr.Hora; txtDescMediaMA.Text = distr.Descripcion; }
                        if (distr.TiempoComida.Equals("Almuerzo")) { txtHoraAlmmuerzoA.Text = distr.Hora; txtDescAlmuerzoA.Text = distr.Descripcion; }
                        if (distr.TiempoComida.Equals("Tarde")) { txtHoraTardeA.Text = distr.Hora; txtDescTardeA.Text = distr.Descripcion; }
                        if (distr.TiempoComida.Equals("Cena")) { txtHoraCenaA.Text = distr.Hora; txtDescCenaA.Text = distr.Descripcion; }
                        if (distr.TiempoComida.Equals("Colasión nocturna")) { txtHoraColacionA.Text = distr.Hora; txtDescColacionA.Text = distr.Descripcion; }

                    }
                }
            }

        }

        /**
        * Método privado que carga la lista del seguimiento semanal del cliente seleccionado 
        */
        private void CargarSeguimientoSemanal()
        {
            listaSeguimientos = manejadorSeg.TraerLista(Int32.Parse(Cedula));
            if (listaSeguimientos != null)
            {
                foreach (SeguimientoSemanal seg in listaSeguimientos)
                {
                    LitSeguimiento.Text += "<tr><td>" + seg.Sesion + "</td><td>" + seg.Fecha.ToString("dd/MM/yyyy") + "</td><td>" + seg.Peso + "</td><td>" + seg.Oreja + "</td><td>" + seg.Ejercicio + "</td></tr>";
                }
            }
            else { LitSeguimiento.Text = "No existen Seguimientos Semanales de este cliente."; }
        }

        /**
        * Método protegido Es la accion del boton agregar seguimientos semanales
        * @param acciones y eventos del boton
        */
        protected void btnAgreg_Click(object sender, EventArgs e)
        {
            decimal peso = 0;
            DateTime fechaSeg;
            if (string.IsNullOrEmpty(FechSegSem.Text))
            {
                fechaSeg = DateTime.Now;
            }
            else
            {
                fechaSeg = DateTime.Parse(FechSegSem.Text);
            }
                          
            if (sPeso.Text.Equals("") || sOreja.Text.Equals("") || sEjercicio.Text.Equals(""))
            {Page.ClientScript.RegisterStartupScript(this.GetType(), "mensajeError", "mensajeError('error', 'Error Seguimiento Semanal', 'No deben haber espacios en blanco')", true); }
            else
            {
                try
                {
                    peso = Convert.ToDecimal(sPeso.Text);
                }
                catch (FormatException)
                { Page.ClientScript.RegisterStartupScript(this.GetType(), "mensajeError", "mensajeError('error', 'Error Seguimiento Semanal', 'Error al ingresar el dato de Peso')", true); }

                bool creado = manejadorSeg.AgregarSeguimiento(new SeguimientoSemanal(fechaSeg, Convert.ToDecimal(sPeso.Text), sOreja.SelectedValue, sEjercicio.Text, int.Parse(ced1.Text)));
                if (creado)
                {

                    if (listaSeguimientos != null)
                    {
                        listaSeguimientos.Add(new SeguimientoSemanal(listaSeguimientos[listaSeguimientos.Count - 1].Sesion + 1, DateTime.Now.Date, peso, sOreja.Text, sEjercicio.Text, int.Parse(ced1.Text)));
                        LitSeguimiento.Text += "<tr><td>" + (listaSeguimientos[listaSeguimientos.Count - 1].Sesion) + "</td><td>" + DateTime.Now.Date + "</td><td>" + sPeso.Text + "</td><td>" + sOreja.Text + "</td><td>" + sEjercicio.Text + "</td></tr>";
                    }
                    else
                    {
                        listaSeguimientos = new List<SeguimientoSemanal>();
                        listaSeguimientos.Add(new SeguimientoSemanal(1, DateTime.Now.Date, Convert.ToDecimal(sPeso.Text), sOreja.Text, sEjercicio.Text, int.Parse(ced1.Text)));
                        LitSeguimiento.Text += "<tr><td>" + 1 + "</td><td>" + DateTime.Now.Date + "</td><td>" + sPeso.Text + "</td><td>" + sOreja.Text + "</td><td>" + sEjercicio.Text + "</td></tr>";

                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "mensajeError", "mensajeError('success', 'Bien!', 'Seguimiento Semanal agregado exitosamente!')", true);

                }
            }
            sPeso.Text = string.Empty; sOreja.Text = string.Empty; sEjercicio.Text = string.Empty;
        }

        /**
        * Método protegido, accion para habilitar o no el espacio de la frecuencia del consumo de licor 
        * @param acciones y eventos del boton
        */
        protected void DropLicor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropLicor.SelectedValue == "Sí")
            {
                txtFrecLicor.Enabled = true;
            }
            else
            {
                txtFrecLicor.Enabled = false;
            }
        }

        /**
        * Método protegido, accion para habilitar o no el espacio de la frecuencia de fumar
        * @param acciones y eventos del boton
        */
        protected void DropFuma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropFuma.SelectedValue == "Sí")
            {
                txtFrecFuma.Enabled = true;
            }
            else
            {
                txtFrecFuma.Enabled = false;
            }
        }

        /**
       * Método privado que carga la lista del seguimiento semanal del cliente seleccionado 
       */
        private void CargarSeguimientoNutricional()
        {
            listaSegNutri = manejadorSeg.TraerListaMensual(Int32.Parse(Cedula));
            SegAntFecha.Text = DateTime.Now.ToString();
            if (listaSegNutri != null)
            {
                foreach (SeguimientoMensual seg in listaSegNutri)
                {

                    SeguimMensual.Text += "<tr><td>" + seg.idSeg + "</td>" +
                        "<td>" + seg.Fecha.ToString("dd/MM/yyyy") + "</td>" +
                        "<td> <input id=\"Ver" + seg.idSeg + "\" type= \"submit\" value=\"Ver\" onclick=\"VerSeg("+seg.idSeg+ ")\" class=\"btn btn-secondary\" style=\"width:7rem\"/> </td>" +
                        "<td> <input id=\"mod" + seg.idSeg + "\" type= \"submit\"  onclick=\"Modificar_btn("+seg.idSeg+")\" class=\"btn btn-secondary\" style=\"width:7rem\" value=\"Modificar\"/> </tr>";
                }

                SeguimientoMensual seguim = listaSegNutri.Last<SeguimientoMensual>();
            }
            else { SeguimMensual.Text = "No existen Seguimientos Nutricionales de este cliente."; }
        }

        /**
      * Método privado que carga el ultimo seguimiento mensual del cliente 
      */
        private void CargarAnterior()
        {
            if (listaSegNutri != null)
            {
                SeguimientoMensual anterior = listaSegNutri.Last<SeguimientoMensual>();
                AntDiasEjer.Text = anterior.nutri.DiasEjercicio;
                AntComExtra.Text = anterior.nutri.ComidaExtra;
                AntNAnsied.Text = anterior.nutri.NivelAnsiedad;
                foreach (SeguimientoRecordat24H rec in anterior.record)
                {
                    if (rec.TiempoComida.Equals("Ayunas")) { AntAyunHora.Text = rec.Hora; AntAyunDescr.Text = rec.Descripcion; }
                    else { if (rec.TiempoComida.Equals("Desayuno")) { AntDesHora.Text = rec.Hora; AntDesDescrp.Text = rec.Descripcion; }
                        else { if (rec.TiempoComida.Equals("Media Mañana")) { AntMedManHora.Text = rec.Hora; AntMedManDesc.Text = rec.Descripcion; }
                            else { if (rec.TiempoComida.Equals("Almuerzo")) { AntAlmHora.Text = rec.Hora; AntAlmDesc.Text = rec.Descripcion; }
                                else { if (rec.TiempoComida.Equals("Media Tarde")) { AntMedTarHora.Text = rec.Hora; AntMedTarDesc.Text = rec.Descripcion; }
                                    else { if (rec.TiempoComida.Equals("Cena")) { AntCenaHora.Text = rec.Hora; AntCenaDesc.Text = rec.Descripcion; }
                                        else { if (rec.TiempoComida.Equals("Colación Nocturna")) { AntColNocHora.Text = rec.Hora; AntColNocDesc.Text = rec.Descripcion; }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (anterior.antrop != null)
                {
                    AntSAFech.Text = anterior.antrop.Fecha_SA.ToString("yyyy-MM-dd");
                    AntSAEdad.Text = anterior.antrop.Edad + "";
                    AntSATalla.Text = anterior.antrop.Talla + "";
                    AntSACM.Text = anterior.antrop.CM + "";
                    AntSAPeso.Text = anterior.antrop.Peso + "";
                    AntSAIMC.Text = anterior.antrop.IMC + "";
                    AntSAAgua.Text = anterior.antrop.Agua + "";
                    AntSAMasaOsea.Text = anterior.antrop.MasaOsea + "";
                    AntSAEddMet.Text = anterior.antrop.EdadMetabolica + "";
                    AntSAGrAnaliz.Text = anterior.antrop.PorcGrasaAnalizador + "";
                    AntSAGrBasc.Text = anterior.antrop.PorcGr_Bascula + "";
                    AntSAGBBI.Text = anterior.antrop.GB_BI + "";
                    AntSAGBBD.Text = anterior.antrop.GB_BD + "";
                    AntSAGBPI.Text = anterior.antrop.GB_PI + "";
                    AntSAGBPD.Text = anterior.antrop.GB_PD + "";
                    AntSAGBTronco.Text = anterior.antrop.GB_Tronco + "";
                    AntSAGrVisc.Text = anterior.antrop.PorcentGViceral + "";
                    AntSAPorMusc.Text = anterior.antrop.PorcentMusculo + "";
                    AntSAPMBI.Text = anterior.antrop.PM_BI + "";
                    AntSAPMBD.Text = anterior.antrop.PM_BD + "";
                    AntSAPMPI.Text = anterior.antrop.PM_PI + "";
                    AntSAPMPD.Text = anterior.antrop.PM_PD + "";
                    AntSAPMTronco.Text = anterior.antrop.PM_Tronco + "";
                    AntSACircunfCint.Text = anterior.antrop.CircunfCintura + "";
                    AntSACadera.Text = anterior.antrop.Cadera + "";
                    AntSAMusIza.Text = anterior.antrop.MusloIzq + "";
                    AntSAMusDer.Text = anterior.antrop.MusloDer + "";
                    AntSABrazIzq.Text = anterior.antrop.BrazoIzq + "";
                    AntSABrazDer.Text = anterior.antrop.BrazoDer + "";
                    AntSAPesoMet.Text = anterior.antrop.PesoIdeal + "";
                    AntSNObserv.Text = anterior.antrop.Observaciones;
                }
            }
        }

        /**
       * Método protegido, accion para retroceder entre las pantallas
       * @param acciones y eventos del boton
       */
        protected void BackButton_Click(object sender, EventArgs e)
        {
            SNDiasEjerSem.Text = string.Empty; SNComidasExtras.Text = string.Empty; SNNivAnsiedad.Text = string.Empty;
            SNRecordAyunTime.Text = string.Empty; SNRecAyunasDescr.Text = string.Empty; SNRecordDesayunTime.Text = string.Empty; SNRecordDesayunDescr.Text = string.Empty;
            SNRecordMedManTime.Text = string.Empty; SNRecordMedManTime.Text = string.Empty; SNRecordAlmTime.Text = string.Empty; SNRecordAlmDescrip.Text = string.Empty;
            SNRecordMedTardeTime.Text = string.Empty; SNRecordMedTardeDescr.Text = string.Empty; SNRecordCenaTime.Text = string.Empty; SNRecordCenaDescr.Text = string.Empty;
            SNRecordColTime.Text = string.Empty; SNRecordColDescr.Text = string.Empty;

            SegAntEdad.Text = string.Empty; SegAntTalla.Text = string.Empty; SegAntCM.Text = string.Empty; SegAntPeso.Text = string.Empty; SegAntIMC.Text = string.Empty;
            SegAntAgua.Text = string.Empty; SegAntMasaOsea.Text = string.Empty; SegAntEdadMetabolica.Text = string.Empty; SegAntGrasaAnaliz.Text = string.Empty;
            SegAntGrasBasc.Text = string.Empty; SegAntGBBI.Text = string.Empty; SegAntGBBD.Text = string.Empty; SegAntGBPI.Text = string.Empty; SegAntGBPD.Text = string.Empty; SegAntGBTronco.Text = string.Empty;
            SegAntGrVisceral.Text = string.Empty; SegAntPM.Text = string.Empty; SegAntPMBI.Text = string.Empty; SegAntPMBD.Text = string.Empty; SegAntPMPI.Text = string.Empty;
            SegAntPMPD.Text = string.Empty; SegAntPMTronco.Text = string.Empty; SegAntCircunfCint.Text = string.Empty; SegAntCadera.Text = string.Empty;
            SegAntMusloIzq.Text = string.Empty; SegAntMusloDer.Text = string.Empty; SegAntBrazoIzq.Text = string.Empty; SegAntBrazoDer.Text = string.Empty; SegAntPesoIdeal.Text = string.Empty; SNObservacion.Text = string.Empty;

            Response.Redirect("Expedientes.aspx");
        }

        /**
      * Método protegido, accion para agregar seguimientos
      * @param acciones y eventos del boton
      */
        //protected void MedicButton_Click(object sender, EventArgs e)
        //{
        //    if (tNomMed.Text.Equals("") || tMotvMed.Text.Equals("") || tFrecMed.Text.Equals("") || tDosisMed.Text.Equals(""))
        //    {
        //        Response.Write("<script>alert('No deben haber espacios en blanco')</script>");
        //    }
        //    else
        //    {
        //        Medicamento medicamSupl = new Medicamento();
        //        string tabla = tSuplementoMedico.Text;
        //        tabla += "<tr><td>" + tNomMed.Text + "</td><td>" + tMotvMed.Text + "</td><td>" + tFrecMed.Text + "</td><td>" + tDosisMed.Text + "</td></tr>";
        //        tSuplementoMedico.Text = tabla;


        //        medicamSupl.Cedula = int.Parse(Cedula);

        //        medicamSupl.Nombre = tNomMed.Text;
        //        medicamSupl.Motivo = tMotvMed.Text;
        //        medicamSupl.Frecuencia = tFrecMed.Text;
        //        medicamSupl.Dosis = tDosisMed.Text;
        //        ListmedicamSupl.Add(medicamSupl);

        //        tNomMed.Text = "";
        //        tMotvMed.Text = "";
        //        tFrecMed.Text = "";
        //        tDosisMed.Text = "";
        //    }
        //}

        /**
      * Método protegido, accion para guardar los datos de un seguimiento mensual nuevo
      * @param acciones y eventos del boton
      */
        protected void GuardarSeguimNutri_Click(object sender, EventArgs e)
        {
            SeguimientoMensual nuevo = new SeguimientoMensual();
            SeguimientoAntrop nuevoAntrop = new SeguimientoAntrop();
            List<SeguimientoRecordat24H> nuevoRecord = new List<SeguimientoRecordat24H>();
            SeguimientoNutricional nuevoNutri = new SeguimientoNutricional();

            nuevoNutri.Cedula = Cedula;
            nuevoNutri.DiasEjercicio = SNDiasEjerSem.Text;
            nuevoNutri.ComidaExtra = SNComidasExtras.Text;
            nuevoNutri.NivelAnsiedad = SNNivAnsiedad.Text;

            nuevoRecord.Add(new SeguimientoRecordat24H("Ayunas", SNRecordAyunTime.Text, SNRecAyunasDescr.Text));
            nuevoRecord.Add(new SeguimientoRecordat24H("Desayuno", SNRecordDesayunTime.Text, SNRecordDesayunDescr.Text));
            nuevoRecord.Add(new SeguimientoRecordat24H("Media Mañana", SNRecordMedManTime.Text, SNRecordMedManTime.Text));
            nuevoRecord.Add(new SeguimientoRecordat24H("Almuerzo", SNRecordAlmTime.Text, SNRecordAlmDescrip.Text));
            nuevoRecord.Add(new SeguimientoRecordat24H("Media Tarde", SNRecordMedTardeTime.Text, SNRecordMedTardeDescr.Text));
            nuevoRecord.Add(new SeguimientoRecordat24H("Cena", SNRecordCenaTime.Text, SNRecordCenaDescr.Text));
            nuevoRecord.Add(new SeguimientoRecordat24H("Colación Nocturna", SNRecordColTime.Text, SNRecordColDescr.Text));

            nuevoAntrop.Fecha_SA = DateTime.Now;
            if (SegAntEdad.Text != "") { nuevoAntrop.Edad = Decimal.Parse(SegAntEdad.Text); } else { nuevoAntrop.Edad = Decimal.Parse("0"); }
            if (SegAntTalla.Text != "") { nuevoAntrop.Talla = Decimal.Parse(SegAntTalla.Text); } else { nuevoAntrop.Talla = Decimal.Parse("0"); }
            if (SegAntCM.Text != "") { nuevoAntrop.CM = Decimal.Parse(SegAntCM.Text); } else { nuevoAntrop.CM = Decimal.Parse("0"); }
            if (SegAntPeso.Text != "") { nuevoAntrop.Peso = Decimal.Parse(SegAntPeso.Text); } else { nuevoAntrop.Peso = Decimal.Parse("0"); }
            if (SegAntIMC.Text != "") { nuevoAntrop.IMC = Decimal.Parse(SegAntIMC.Text); } else { nuevoAntrop.IMC = Decimal.Parse("0"); }
            if (SegAntAgua.Text != "") { nuevoAntrop.Agua = Decimal.Parse(SegAntAgua.Text); } else { nuevoAntrop.Agua = Decimal.Parse("0"); }
            if (SegAntMasaOsea.Text != "") { nuevoAntrop.MasaOsea = Decimal.Parse(SegAntMasaOsea.Text); } else { nuevoAntrop.MasaOsea = Decimal.Parse("0"); }
            if (SegAntEdadMetabolica.Text != "") { nuevoAntrop.EdadMetabolica = Decimal.Parse(SegAntEdadMetabolica.Text); } else { nuevoAntrop.EdadMetabolica = Decimal.Parse("0"); }
            if (SegAntGrasaAnaliz.Text != "") { nuevoAntrop.PorcGrasaAnalizador = Decimal.Parse(SegAntGrasaAnaliz.Text); } else { nuevoAntrop.PorcGrasaAnalizador = Decimal.Parse("0"); }
            if (SegAntGrasBasc.Text != "") { nuevoAntrop.PorcGr_Bascula = Decimal.Parse(SegAntGrasBasc.Text); } else { nuevoAntrop.PorcGr_Bascula = Decimal.Parse("0"); }
            if (SegAntGBBI.Text != "") { nuevoAntrop.GB_BI = Decimal.Parse(SegAntGBBI.Text); } else { nuevoAntrop.GB_BI = Decimal.Parse("0"); }
            if (SegAntGBBD.Text != "") { nuevoAntrop.GB_BD = Decimal.Parse(SegAntGBBD.Text); } else { nuevoAntrop.GB_BD = Decimal.Parse("0"); }
            if (SegAntGBPI.Text != "") { nuevoAntrop.GB_PI = Decimal.Parse(SegAntGBPI.Text); } else { nuevoAntrop.GB_PI = Decimal.Parse("0"); }
            if (SegAntGBPD.Text != "") { nuevoAntrop.GB_PD = Decimal.Parse(SegAntGBPD.Text); } else { nuevoAntrop.GB_PD = Decimal.Parse("0"); }
            if (SegAntGBTronco.Text != "") { nuevoAntrop.GB_Tronco = Decimal.Parse(SegAntGBTronco.Text); } else { nuevoAntrop.GB_Tronco = Decimal.Parse("0"); }
            if (SegAntGrVisceral.Text != "") { nuevoAntrop.PorcentGViceral = Decimal.Parse(SegAntGrVisceral.Text); } else { nuevoAntrop.PorcentGViceral = Decimal.Parse("0"); }
            if (SegAntPM.Text != "") { nuevoAntrop.PorcentMusculo = Decimal.Parse(SegAntPM.Text); } else { nuevoAntrop.PorcentMusculo = Decimal.Parse("0"); }
            if (SegAntPMBI.Text != "") { nuevoAntrop.PM_BI = Decimal.Parse(SegAntPMBI.Text); } else { nuevoAntrop.PM_BI = Decimal.Parse("0"); }
            if (SegAntPMBD.Text != "") { nuevoAntrop.PM_BD = Decimal.Parse(SegAntPMBD.Text); } else { nuevoAntrop.PM_BD = Decimal.Parse("0"); }
            if (SegAntPMPI.Text != "") { nuevoAntrop.PM_PI = Decimal.Parse(SegAntPMPI.Text); } else { nuevoAntrop.PM_PI = Decimal.Parse("0"); }
            if (SegAntPMPD.Text != "") { nuevoAntrop.PM_PD = Decimal.Parse(SegAntPMPD.Text); } else { nuevoAntrop.PM_PD = Decimal.Parse("0"); }
            if (SegAntPMTronco.Text != "") { nuevoAntrop.PM_Tronco = Decimal.Parse(SegAntPMTronco.Text); } else { nuevoAntrop.PM_Tronco = Decimal.Parse("0"); }
            if (SegAntCircunfCint.Text != "") { nuevoAntrop.CircunfCintura = Decimal.Parse(SegAntCircunfCint.Text); } else { nuevoAntrop.CircunfCintura = Decimal.Parse("0"); }
            if (SegAntCadera.Text != "") { nuevoAntrop.Cadera = Decimal.Parse(SegAntCadera.Text); } else { nuevoAntrop.Cadera = Decimal.Parse("0"); }
            if (SegAntMusloIzq.Text != "") { nuevoAntrop.MusloIzq = Decimal.Parse(SegAntMusloIzq.Text); } else { nuevoAntrop.MusloIzq = Decimal.Parse("0"); }
            if (SegAntMusloDer.Text != "") { nuevoAntrop.MusloDer = Decimal.Parse(SegAntMusloDer.Text); } else { nuevoAntrop.MusloDer = Decimal.Parse("0"); }
            if (SegAntBrazoIzq.Text != "") { nuevoAntrop.BrazoIzq = Decimal.Parse(SegAntBrazoIzq.Text); } else { nuevoAntrop.BrazoIzq = Decimal.Parse("0"); }
            if (SegAntBrazoDer.Text != "") { nuevoAntrop.BrazoDer = Decimal.Parse(SegAntBrazoDer.Text); } else { nuevoAntrop.BrazoDer = Decimal.Parse("0"); }
            if (SegAntPesoIdeal.Text != "") { nuevoAntrop.PesoIdeal = Decimal.Parse(SegAntPesoIdeal.Text); } else { nuevoAntrop.PesoIdeal = Decimal.Parse("0"); }
            nuevoAntrop.Observaciones = SNObservacion.Text;

            nuevo.antrop = nuevoAntrop;
            nuevo.nutri = nuevoNutri;
            nuevo.record = nuevoRecord;
            nuevo.Fecha = DateTime.Now;

            bool exito = manejadorSeg.AgregaSegNutri(nuevo);
            if (exito == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "mensajeError", "mensajeError('success', 'Bien!', 'Seguimiento Nutricional creado exitosamente!')", true);
                CargarSeguimientoNutricional();

                SNDiasEjerSem.Text = string.Empty; SNComidasExtras.Text = string.Empty; SNNivAnsiedad.Text = string.Empty;
                SNRecordAyunTime.Text = string.Empty; SNRecAyunasDescr.Text = string.Empty; SNRecordDesayunTime.Text = string.Empty; SNRecordDesayunDescr.Text = string.Empty;
                SNRecordMedManTime.Text = string.Empty; SNRecordMedManTime.Text = string.Empty; SNRecordAlmTime.Text = string.Empty; SNRecordAlmDescrip.Text = string.Empty;
                SNRecordMedTardeTime.Text = string.Empty; SNRecordMedTardeDescr.Text = string.Empty; SNRecordCenaTime.Text = string.Empty; SNRecordCenaDescr.Text = string.Empty;
                SNRecordColTime.Text = string.Empty; SNRecordColDescr.Text = string.Empty;

                SegAntEdad.Text = string.Empty; SegAntTalla.Text = string.Empty; SegAntCM.Text = string.Empty; SegAntPeso.Text = string.Empty;SegAntIMC.Text = string.Empty;
                SegAntAgua.Text = string.Empty; SegAntMasaOsea.Text = string.Empty; SegAntEdadMetabolica.Text = string.Empty; SegAntGrasaAnaliz.Text = string.Empty; 
                SegAntGrasBasc.Text = string.Empty; SegAntGBBI.Text = string.Empty; SegAntGBBD.Text = string.Empty; SegAntGBPI.Text = string.Empty; SegAntGBPD.Text = string.Empty; SegAntGBTronco.Text = string.Empty;
                SegAntGrVisceral.Text = string.Empty;  SegAntPM.Text = string.Empty; SegAntPMBI.Text = string.Empty; SegAntPMBD.Text = string.Empty;  SegAntPMPI.Text = string.Empty;
                SegAntPMPD.Text = string.Empty; SegAntPMTronco.Text = string.Empty; SegAntCircunfCint.Text = string.Empty; SegAntCadera.Text = string.Empty; 
                SegAntMusloIzq.Text = string.Empty; SegAntMusloDer.Text = string.Empty; SegAntBrazoIzq.Text = string.Empty; SegAntBrazoDer.Text = string.Empty;SegAntPesoIdeal.Text = string.Empty; SNObservacion.Text = string.Empty;

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "mensajeError", "mensajeError('error', 'Error con Seguimiento Nutricional', 'Error al crear el seguimiento nutricional')", true);
               
            }

        }


        /**
      *  Método web publico y estatico, para guardar el identificador el cual se redirige a la clase VerSeguimiento.aspx,
      *  el cual muestra los datos del seguimiento selecccionado
      * @param acciones y eventos del boton
      */
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static void Ver_Click(string idS)
        {
            HttpContext.Current.Session["idSeguimiento"] = idS;
        }


        /**
      *  Método web publico y estatico, para guardar el identificador el cual se redirige a la clase VerSeguimiento.aspx,
      *  el cual muestra los datos del seguimiento selecccionado
      * @param acciones y eventos del boton
      */
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static void Modif_Click(string idSeg)
        {
            foreach(SeguimientoMensual m in listaSegNutri)
            {
                if(m.idSeg == Int32.Parse(idSeg))
                {
                    HttpContext.Current.Session["SegModif"] = m;
                }
            }
           
        }


        /**
        *  Método protegido, para guardar modificaciones del expediente
        * @param acciones y eventos del boton
        */
        protected void Modificar_Click(object sender, EventArgs e)
        {
            //Datos personales
            ClienteNutricion clienteModif = new ClienteNutricion();
            clienteModif.Cedula = Int32.Parse(Cedula);
            clienteModif.Correo = txtEmail.Text;
            clienteModif.Nombre = txtNombre.Text;
            clienteModif.Apellido1 = txtPrimerApellido.Text;
            clienteModif.Apellido2 = txtSegundoApellido.Text;
            clienteModif.Residencia = txtResid.Text;
            clienteModif.Ocupacion = txtOcup.Text;
            clienteModif.Consultorio = ConsultorDropList.SelectedValue;
            if (!string.IsNullOrEmpty(FechIngreso.Text)) {clienteModif.FechaIngreso = DateTime.Parse(FechIngreso.Text); } else { clienteModif.FechaIngreso = DateTime.Now; }
            if (!string.IsNullOrEmpty(FechNacimi.Text)) { clienteModif.Fecha_Nacimiento = DateTime.Parse(FechNacimi.Text); } else { clienteModif.Fecha_Nacimiento = DateTime.Now; }
            clienteModif.Sexo = char.Parse(dropSexo.SelectedValue);
            clienteModif.Estado_Civil = dropEstadoCivil.SelectedValue;
            char whatsApp = '0'; if (dropWhats.SelectedValue.Equals("Sí")) { whatsApp = '1';}
            int telefono = 0;
            if (whatsApp == '1' && string.IsNullOrEmpty(txtTel.Text))
            { Page.ClientScript.RegisterStartupScript(this.GetType(), "mensajeError", "mensajeError('error', 'Datos faltantes', 'Ingrese un número de teléfono')", true);
                return;
            } else if (whatsApp == '1' && !string.IsNullOrEmpty(txtTel.Text))
            { telefono = int.Parse(txtTel.Text);
            } else if (whatsApp == '0' && !string.IsNullOrEmpty(txtTel.Text))
            { telefono = int.Parse(txtTel.Text);}
            else {telefono = 0;}
            clienteModif.WhatsApp = whatsApp;
            clienteModif.Telefono = telefono;
            clienteModif.Estado = 1;

            //Historial medico
            HistorialMedico histModif = new HistorialMedico();
            histModif.Cedula = Int32.Parse( Cedula);
            histModif.Antecedentes = txtAntec.Text; ;
            histModif.Patologias = txtPatol.Text;
            int consumeLicor = 0;
            if (DropLicor.SelectedValue.Equals("Sí")) {consumeLicor = 1; }
            int fuma = 0;
            if (DropFuma.SelectedValue.Equals("Sí")) { consumeLicor = 1; }
            histModif.ConsumeLicor = consumeLicor;
            histModif.Fuma = fuma;
            if (!string.IsNullOrEmpty(txtFrecFuma.Text)) { histModif.FrecFuma = txtFrecFuma.Text; } else { histModif.FrecFuma = ""; }
            if (!string.IsNullOrEmpty(txtFrecLicor.Text)) { histModif.FrecLicor = txtFrecLicor.Text; } else { histModif.FrecLicor = ""; }
            histModif.UltimoExamen = FechRevMedica.Text;
            histModif.ActividadFisica = txtActividadFisica.Text;
            //List<Medicamento> listaM = ListmedicamSupl;

            //Habitos alimentarios
            HabitoAlimentario habModif = new HabitoAlimentario();
            habModif.Cedula = Int32.Parse(Cedula);
            int ComidaDiaria; if (string.IsNullOrEmpty(numeroComidas.Text)) {ComidaDiaria = 0;} else ComidaDiaria = int.Parse(numeroComidas.Text);
            habModif.ComidaDiaria = ComidaDiaria;
            char ComidaHorasDia = '0'; //drop
            if (ComeHoras.SelectedValue.Equals("Sí")) {ComidaHorasDia = '1'; }
            habModif.ComidaHorasDia = ComidaHorasDia;
            int AfueraExpress;
            if (string.IsNullOrEmpty(txtEspres.Text)) { AfueraExpress = 0; } else AfueraExpress = int.Parse(txtEspres.Text);
            habModif.AfueraExpress = AfueraExpress;
            string ComidaFuera = txtQueComeFuera.Text;
            string AzucarBebida = cantAzucar.Text;
            string ComidaElaboradCon = dropCocinaCon.SelectedValue; //drop
            habModif.ComidaFuera = ComidaFuera;
            habModif.AzucarBebida = AzucarBebida;
            habModif.ComidaElaboradCon = ComidaElaboradCon;
            decimal AguaDiaria; if (string.IsNullOrEmpty(txtCuantaAgua.Text)) {AguaDiaria = 0;} else AguaDiaria = decimal.Parse(txtCuantaAgua.Text);
            habModif.AguaDiaria = AguaDiaria;
            char Aderezos = '0'; if (dropAderezos.SelectedValue.Equals("Sí")) { Aderezos = '1'; }
            habModif.Aderezos = Aderezos;
            char Fruta = '0';  if (dropFrutas.SelectedValue.Equals("Sí")) {Fruta = '1';}
            habModif.Fruta = Fruta;
            char Verdura = '0'; if (dropVeget.SelectedValue.Equals("Sí")) {Verdura = '1'; }
            habModif.Verdura = Verdura;
            char Leche = '0'; if (dropLeche.SelectedValue.Equals("Sí")) { Leche = '1'; }
            habModif.Leche = Leche;
            char Huevo = '0';  if (dropHuevo.SelectedValue.Equals("Sí")) { Huevo = '1';}
            habModif.Huevo = Huevo;
            char Yogurt = '0';  if (dropYogurt.SelectedValue.Equals("Sí")) {Yogurt = '1'; }
            habModif.Yogurt = Yogurt;
            char Carne = '0'; if (dropCarne.SelectedValue.Equals("Sí")) { Carne = '1'; }
            habModif.Carne = Carne;
            char Queso = '0'; if (dropQueso.SelectedValue.Equals("Sí")) { Queso = '1'; }
            habModif.Queso = Queso;
            char Aguacate = '0';  if (dropAguacate.SelectedValue.Equals("Sí")){ Aguacate = '1'; }
            habModif.Aguacate = Aguacate;
            char Semillas = '0';  if (dropSemillas.SelectedValue.Equals("Sí")) {Semillas = '1';}
            habModif.Semillas = Semillas;
          
            List<Recordatorio24H> listRecordModif = new List<Recordatorio24H>();
            listRecordModif.Add(new Recordatorio24H(Int32.Parse(Cedula), "Ayunas", txtHoraAyunas.Text, txtDescAyunas.Text));
            listRecordModif.Add(new Recordatorio24H(Int32.Parse(Cedula), "Desayuno", txtHoraDesayuno.Text, txtDescDesay.Text));
            listRecordModif.Add(new Recordatorio24H(Int32.Parse(Cedula), "Media mañana", txtHoraMediaM.Text, txtDescMediaM.Text));
            listRecordModif.Add(new Recordatorio24H(Int32.Parse(Cedula), "Almuerzo", txtHoraAlmmuerzo.Text, txtDescAlmuerzo.Text));
            listRecordModif.Add(new Recordatorio24H(Int32.Parse(Cedula), "Tarde", txtHoraTarde.Text, txtDescTarde.Text));
            listRecordModif.Add(new Recordatorio24H(Int32.Parse(Cedula), "Cena", txtHoraCena.Text, txtDescCena.Text));
            listRecordModif.Add(new Recordatorio24H(Int32.Parse(Cedula), "Colasión nocturna", txtHoraColacion.Text, txtDescColacion.Text));

            //Antropometria
            Antropometria antropModif = new Antropometria();
            antropModif.Cedula = Int32.Parse(Cedula);
            decimal talla;
            if (string.IsNullOrEmpty(txtTalla.Text)) { talla = 0; }
            else {talla = decimal.Parse(txtTalla.Text);
            }
            antropModif.Talla = talla;
            decimal pesoIdeal;if (string.IsNullOrEmpty(txtPesoIdeal.Text)) { pesoIdeal = 0; } else pesoIdeal = decimal.Parse(txtPesoIdeal.Text);
            antropModif.PesoIdeal = pesoIdeal;
            decimal edad; if (string.IsNullOrEmpty(txtEdad.Text)) {edad = 0; } else edad = decimal.Parse(txtEdad.Text);
            antropModif.Edad = edad;
            decimal pMB; if (string.IsNullOrEmpty(txtPMB.Text)) { pMB = 0;} else pMB = decimal.Parse(txtPMB.Text);
            antropModif.PMB = pMB;
            decimal peso; if (string.IsNullOrEmpty(txtPesoActual.Text)) { peso = 0; } else peso = decimal.Parse(txtPesoActual.Text);
            antropModif.Peso = peso;
            decimal pesoMaxTeoria;if (string.IsNullOrEmpty(txtPesoMaxTeoria.Text)) {pesoMaxTeoria = 0; } else  pesoMaxTeoria = decimal.Parse(txtPesoMaxTeoria.Text);
            antropModif.PesoMaxTeoria = pesoMaxTeoria;
            decimal iMC; if (string.IsNullOrEmpty(txtIMC.Text)) { iMC = 0; } else iMC = decimal.Parse(txtIMC.Text);
            antropModif.IMC = iMC;
            decimal porcGrasaAnalizador; if (string.IsNullOrEmpty(txtGrasaAnalizador.Text)) { porcGrasaAnalizador = 0; } else porcGrasaAnalizador = decimal.Parse(txtGrasaAnalizador.Text);
            antropModif.PorcGrasaAnalizador = porcGrasaAnalizador;
            decimal porcGr_Bascula; if (string.IsNullOrEmpty(txtGrasaBascula.Text)) { porcGr_Bascula = 0; } else porcGr_Bascula = decimal.Parse(txtGrasaBascula.Text);
            antropModif.PorcGr_Bascula = porcGr_Bascula;
            decimal gB_BI; if (string.IsNullOrEmpty(txtGB_BI.Text)) { gB_BI = 0; } else  gB_BI = decimal.Parse(txtGB_BI.Text);
            antropModif.GB_BI = gB_BI;
            decimal gB_BD; if (string.IsNullOrEmpty(txtGB_BD.Text)) { gB_BD = 0; } else gB_BD = decimal.Parse(txtGB_BD.Text);
            antropModif.GB_BD = gB_BD;
            decimal gB_PI; if (string.IsNullOrEmpty(txtGB_PI.Text)) { gB_PI = 0; }  else gB_PI = decimal.Parse(txtGB_PI.Text);
            antropModif.GB_PI = gB_PI;
            decimal gB_PD; if (string.IsNullOrEmpty(txtGB_PD.Text)) { gB_PD = 0; } else gB_PD = decimal.Parse(txtGB_PD.Text);
            antropModif.GB_PD = gB_PD;
            decimal gB_Tronco; if (string.IsNullOrEmpty(txtGB_Trono.Text)) { gB_Tronco = 0; } else  gB_Tronco = decimal.Parse(txtGB_Trono.Text);
            antropModif.GB_Tronco = gB_Tronco;
            decimal aguaCorporal; if (string.IsNullOrEmpty(txtAgua.Text)) { aguaCorporal = 0; } else  aguaCorporal = decimal.Parse(txtAgua.Text);
            antropModif.AguaCorporal = aguaCorporal;
            decimal masaOsea; if (string.IsNullOrEmpty(txtMasaOsea.Text)) { masaOsea = 0; }  else masaOsea = decimal.Parse(txtMasaOsea.Text);
            antropModif.MasaOsea = masaOsea;
            decimal complexión;  if (string.IsNullOrEmpty(txtComplexion.Text)) { complexión = 0; } else  complexión = decimal.Parse(txtComplexion.Text);
            antropModif.Complexión = complexión;
            decimal edadMetabolica; if (string.IsNullOrEmpty(txtEdadMetabolica.Text))  { edadMetabolica = 0; }  else edadMetabolica = decimal.Parse(txtEdadMetabolica.Text);
            antropModif.EdadMetabolica = edadMetabolica;
            decimal cintura; if (string.IsNullOrEmpty(txtCintura.Text)) { cintura = 0; } else  cintura = decimal.Parse(txtCintura.Text);
            antropModif.Cintura = cintura;
            decimal abdomen; if (string.IsNullOrEmpty(txtAbdomen.Text))  { abdomen = 0; } else abdomen = decimal.Parse(txtAbdomen.Text);
            antropModif.Abdomen = abdomen;
            decimal cadera; if (string.IsNullOrEmpty(txtCadera.Text)) { cadera = 0; } else cadera = decimal.Parse(txtCadera.Text);
            antropModif.Cadera = cadera;
            decimal musloIzq; if (string.IsNullOrEmpty(txtMusloIzq.Text)) { musloIzq = 0; }   else  musloIzq = decimal.Parse(txtMusloIzq.Text);
            antropModif.MusloIzq = musloIzq;
            decimal musloDer; if (string.IsNullOrEmpty(txtMusloDer.Text)) { musloDer = 0; }  else  musloDer = decimal.Parse(txtMusloDer.Text);
            antropModif.MusloDer = musloDer;
            decimal cBM; if (string.IsNullOrEmpty(txtCMB.Text)) { cBM = 0; } else  cBM = decimal.Parse(txtCMB.Text);
            antropModif.CBM = cBM;
            decimal circunfMunneca; if (string.IsNullOrEmpty(txtCircunferencia.Text)) { circunfMunneca = 0; } else circunfMunneca = decimal.Parse(txtCircunferencia.Text);
            antropModif.CircunfMunneca = circunfMunneca;
            decimal porcentGViceral; if (string.IsNullOrEmpty(txtGarsaViceral.Text)) { porcentGViceral = 0; } else porcentGViceral = decimal.Parse(txtGarsaViceral.Text);
            antropModif.PorcentGViceral = porcentGViceral;
            decimal porcentMusculo;  if (string.IsNullOrEmpty(txtPorcentaje.Text))  { porcentMusculo = 0; } else porcentMusculo = decimal.Parse(txtPorcentaje.Text);
            antropModif.PorcentMusculo = porcentMusculo;
            decimal pM_BI; if (string.IsNullOrEmpty(txtPM_BI.Text)) { pM_BI = 0; } else pM_BI = decimal.Parse(txtPM_BI.Text);
            antropModif.PM_BI = pM_BI;
            decimal pM_PD; if (string.IsNullOrEmpty(txtPM_PD.Text)) { pM_PD = 0; } else pM_PD = decimal.Parse(txtPM_PD.Text);
            antropModif.PM_PD = pM_PD;
            decimal pM_BD; if (string.IsNullOrEmpty(txtPM_BD.Text)) { pM_BD = 0; } else pM_BD = decimal.Parse(txtPM_BD.Text);
            antropModif.PM_BD = pM_BD;
            decimal pM_PI; if (string.IsNullOrEmpty(txtPM_PI.Text))  { pM_PI = 0; }  else pM_PI = decimal.Parse(txtPM_PI.Text);
            antropModif.PM_PI = pM_PI;
            decimal pM_Tronco; if (string.IsNullOrEmpty(txtPM_Tronco.Text)) { pM_Tronco = 0; } else pM_Tronco = decimal.Parse(txtPM_Tronco.Text);
            antropModif.PM_Tronco = pM_Tronco;
            antropModif.Observaciones = txtObservaciones.Text;
            decimal gEB = 0;if (string.IsNullOrEmpty(txtGEB.Text)) { gEB = 0; } else gEB = decimal.Parse(txtGEB.Text);
            antropModif.GEB = gEB;
            decimal gET = 0; if (string.IsNullOrEmpty(txtGET.Text))  { gET = 0; } else gET = decimal.Parse(txtGET.Text);
            antropModif.GET = gET;
            decimal cHOPorc; if (string.IsNullOrEmpty(choPorc.Text)) { cHOPorc = 0; } else cHOPorc = decimal.Parse(choPorc.Text);
            antropModif.CHOPorc = cHOPorc;
            decimal cHOGram; if (string.IsNullOrEmpty(choGram.Text))  { cHOGram = 0; } else cHOGram = decimal.Parse(choGram.Text);
            antropModif.CHOGram = cHOGram;
            decimal cHO_kcal; if (string.IsNullOrEmpty(choKcal.Text)) { cHO_kcal = 0; } else cHO_kcal = decimal.Parse(choKcal.Text);
            antropModif.CHO_kcal = cHO_kcal;
            decimal proteinaPorc; if (string.IsNullOrEmpty(ProtPorc.Text)) { proteinaPorc = 0; }  else proteinaPorc = decimal.Parse(ProtPorc.Text);
            antropModif.ProteinaPorc = proteinaPorc;
            decimal proteinaGram; if (string.IsNullOrEmpty(ProtGram.Text))  { proteinaGram = 0; } else  proteinaGram = decimal.Parse(ProtGram.Text);
            antropModif.ProteinaGram = proteinaGram;
            decimal proteinakcal;  if (string.IsNullOrEmpty(protKcal.Text))  { proteinakcal = 0; } else  proteinakcal = decimal.Parse(protKcal.Text);
            antropModif.Proteinakcal = proteinakcal;
            decimal grasaPorc;  if (string.IsNullOrEmpty(GrasPorc.Text)) { grasaPorc = 0; } else grasaPorc = decimal.Parse(GrasPorc.Text);
            antropModif.GrasaPorc = grasaPorc;
            decimal grasaGram; if (string.IsNullOrEmpty(GrasGram.Text))  { grasaGram = 0; }  else  grasaGram = decimal.Parse(GrasGram.Text);
            antropModif.GrasaGram = grasaGram;
            decimal grasakcal;   if (string.IsNullOrEmpty(GrasKcal.Text))  { grasakcal = 0; }  else   grasakcal = decimal.Parse(GrasKcal.Text);
            antropModif.Grasakcal = grasakcal;

            Porciones porcModif = new Porciones();
            porcModif.Cedula = Int32.Parse(Cedula);
            decimal leche;  if (string.IsNullOrEmpty(txtPorcLeche.Text))  { leche = 0; }   else   leche = decimal.Parse(txtPorcLeche.Text);
            porcModif.Leche = leche;
            decimal carne; if (string.IsNullOrEmpty(txtPorcCarnes.Text)){ carne = 0; } else carne = decimal.Parse(txtPorcCarnes.Text);
            porcModif.Carne = carne;
            decimal vegetales;  if (string.IsNullOrEmpty(txtPorcVeget.Text))   { vegetales = 0; }  else   vegetales = decimal.Parse(txtPorcVeget.Text);
            porcModif.Vegetales = vegetales;
            decimal grasa;  if (string.IsNullOrEmpty(txtPorcGrasas.Text))  { grasa = 0; }  else  grasa = decimal.Parse(txtPorcGrasas.Text);
            porcModif.Grasa = grasa;
            decimal fruta;  if (string.IsNullOrEmpty(txtPorcFrutas.Text))   {  fruta = 0;   }  else  fruta = decimal.Parse(txtPorcFrutas.Text);
            porcModif.Fruta = fruta;
            decimal azucar;   if (string.IsNullOrEmpty(txtPorcAzucar.Text))   {   azucar = 0;   }  else   azucar = decimal.Parse(txtPorcAzucar.Text);
            porcModif.Azucar = azucar;
            decimal harina;  if (string.IsNullOrEmpty(txtPorcHarinas.Text))  {  harina = 0;  } else  harina = decimal.Parse(txtPorcHarinas.Text);
            porcModif.Harina = harina;
            decimal suplemento; if (string.IsNullOrEmpty(txtPorcSuplem.Text)) { suplemento = 0; } else suplemento = decimal.Parse(txtPorcSuplem.Text);
            porcModif.Suplemento = suplemento;
            
            List<DistribucionPorciones> distrModif = new List<DistribucionPorciones>();
            distrModif.Add(new DistribucionPorciones(txtDescAyunasA.Text, "Ayunas", txtHoraAyunasA.Text, Int32.Parse(Cedula)));
            distrModif.Add(new DistribucionPorciones(txtDescDesayA.Text, "Desayuno", txtHoraDesayunoA.Text, Int32.Parse(Cedula)));
            distrModif.Add(new DistribucionPorciones(txtDescMediaMA.Text, "Media mañana", txtHoraMediaMA.Text, Int32.Parse(Cedula)));
            distrModif.Add(new DistribucionPorciones(txtDescAlmuerzoA.Text, "Almuerzo", txtHoraAlmmuerzoA.Text, Int32.Parse(Cedula)));
            distrModif.Add(new DistribucionPorciones(txtDescTardeA.Text, "Tarde", txtHoraTardeA.Text, Int32.Parse(Cedula)));
            distrModif.Add(new DistribucionPorciones(txtDescCenaA.Text, "Cena", txtHoraCenaA.Text, Int32.Parse(Cedula)));
            distrModif.Add(new DistribucionPorciones(txtDescColacionA.Text, "Colasión nocturna", txtHoraColacionA.Text, Int32.Parse(Cedula)));

            bool exito = manejExpediente.ModificarExped(clienteModif, histModif, habModif, listRecordModif, antropModif, porcModif, distrModif);
            if (exito)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "mensajeError", "mensajeError('success', 'Bien', 'Los datos se modificaron correctamente')", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "mensajeError", "mensajeError('error', 'Ups!', 'Sucedió un error al modificar los datos del expediente')", true);
            }

        }


        /**
        * Método protegido, accion para generar un pdf con el reporte de la consulta
        * @param acciones y eventos del boton
        */

        protected void btnGeneraPDF_Click(object sender, EventArgs e)
		{
			string oldFile = Server.MapPath("/Plantilla.pdf");
			string newFile = Server.MapPath("/Reporte.pdf");


			var reader = new PdfReader(oldFile);
			{
				using (var fileStream = new FileStream(newFile, FileMode.Create, FileAccess.Write))
				{
					var document = new Document(reader.GetPageSizeWithRotation(1));
					var writer = PdfWriter.GetInstance(document, fileStream);

					document.Open();

					for (var i = 1; i <= reader.NumberOfPages; i++)
					{
						document.NewPage();

						var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
						var importedPage = writer.GetImportedPage(reader, i);

						var contentByte = writer.DirectContent;
						contentByte.BeginText();
						contentByte.SetFontAndSize(baseFont, 12);

						if (i==1)
						{
							// select the font properties
							BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
							contentByte.SetColorFill(Color.BLACK);
							contentByte.SetFontAndSize(bf, 12);

							// write the text in the pdf content
							contentByte.BeginText();
                            string nombre;
                            string fecha;
                            string peso;
                            string imc;
                            string grasa;
                            SeguimientoMensual segM = listaSegNutri.Last<SeguimientoMensual>();
                            if (segM != null)
                            {
                                nombre = "Nombre: " + txtNombre.Text + " " + txtPrimerApellido.Text + " " + txtSegundoApellido.Text;
                                fecha = "Fecha: " + System.DateTime.Today.ToShortDateString();
                                peso = "Peso: " + segM.antrop.Peso + " Kg";
                                imc = "IMC: " + segM.antrop.IMC;
                                grasa = "% Grasa: " + segM.antrop.PorcGr_Bascula + "%";
                            }
                            else
                            {
                                nombre = "Nombre: " + txtNombre.Text + " " + txtPrimerApellido.Text + " " + txtSegundoApellido.Text;
                                fecha = "Fecha: " + System.DateTime.Today.ToShortDateString();
                                peso = "Peso: " + txtPesoActual.Text + " Kg";
                                imc = "IMC: " + txtIMC.Text;
                                grasa = "% Grasa: " + txtGrasaAnalizador.Text + "%";
                            }
							// put the alignment and coordinates here
							contentByte.ShowTextAligned(Element.ALIGN_LEFT, nombre, 100, 560, 0);
							contentByte.ShowTextAligned(Element.ALIGN_LEFT, fecha, 100, 540, 0);
							contentByte.ShowTextAligned(Element.ALIGN_LEFT, peso, 100, 520, 0);
							contentByte.ShowTextAligned(Element.ALIGN_LEFT, imc, 100, 500, 0);
							contentByte.ShowTextAligned(Element.ALIGN_LEFT, grasa, 100, 480, 0);
							contentByte.EndText();
						
						}

						contentByte.EndText();
						contentByte.AddTemplate(importedPage, 0, 0);
					}

					document.Close();
					writer.Close();
				}
			}
            ShowPdf(newFile);
		}


		/**
        * Método privado, para mostrar el pdf
        * @param strs la ruta del archivo
        */
		private void ShowPdf(string strS)
		{
			Response.ClearContent();
			Response.ClearHeaders();
			Response.ContentType = "application/pdf";
			Response.AddHeader("Content-Disposition", "attachment; filename=" + strS);
			Response.TransmitFile(strS);
			Response.End();
			Response.Flush();
			Response.Clear();

		}

	}
}
