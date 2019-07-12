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
        private static List<SeguimientoMensual> listaSegNutri = new List<SeguimientoMensual>();
        private static ManejadorSeguimientos manejadorSeg = new ManejadorSeguimientos();
        private static ManejadorExpediente manejExpediente = new ManejadorExpediente();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (new ControlSeguridad().validarNutri() == true)
            //{
            //	Response.Redirect("~/InicioSesion.aspx");
            //}

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
                    ConsultDropList.Text = c.Consultorio;
                    txtNombre.Text = c.Nombre;
                    txtEmail.Text = c.Correo;
                    if (c.WhatsApp == '1') { dropWhats.Text = "Sí"; } else { dropWhats.Text = "No"; }
                    EdadCliente.Text = CalcularEdad(c.Fecha_Nacimiento);
                    txtPrimerApellido.Text = c.Apellido1;
                    dropEstadoCivil.Text = c.Estado_Civil;
                    txtResid.Text = c.Residencia;
                    FechIngreso.Text = c.FechaIngreso.Day + " / " + c.FechaIngreso.Month + " / " + c.FechaIngreso.Year;
                    txtSegundoApellido.Text = c.Apellido2;
                    if (c.Sexo == 'F') { dropSexo.Text = "Femenino"; } else { if (c.Sexo == 'M') { dropSexo.Text = "Masculino"; } else { dropSexo.Text = "Otro"; } }
                    FechNacimi.Text = c.Fecha_Nacimiento.Day + " / " + c.Fecha_Nacimiento.Month + " / " + c.Fecha_Nacimiento.Year;
                }

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
                CargarTablaMedicamentos();
            }
        }

        /**
       * Método privado que carga la lista de medicamentos o suplementos que el cliente consume
       */
        private void CargarTablaMedicamentos()
        {
            List<Medicamento> medicamSupl = new List<Medicamento>();
            medicamSupl = manejExpediente.TraerSuplMed(Cedula);
            if (medicamSupl != null)
            {
                foreach (Medicamento med in medicamSupl)
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
                txtPorcentajeMusculo.Text = antrop.PorcentMusculo + "";
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
            if (sPeso.Text.Equals("") || sOreja.Text.Equals("") || sEjercicio.Text.Equals(""))
            { Response.Write("<script>alert('No deben haber espacios en blanco')</script>"); }
            else
            {
                try
                {
                    peso = Convert.ToDecimal(sPeso.Text);
                }
                catch (FormatException)
                {
                    Response.Write("Error al ingresar el Peso.");
                }

                bool creado = manejadorSeg.AgregarSeguimiento(new SeguimientoSemanal(DateTime.Now, Convert.ToDecimal(sPeso.Text), sOreja.SelectedValue, sEjercicio.Text, int.Parse(ced1.Text)));
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
            if (listaSegNutri != null)
            {
                foreach (SeguimientoMensual seg in listaSegNutri)
                {
                    SeguimMensual.Text += "<tr><td>" + seg.idSeg + "</td>" +
                        "<td>" + seg.Fecha.ToString("dd/MM/yyyy")+"</td>"+
                        "<td> <button runat=\"server\" id=\"ver"+ seg.idSeg +"\" onclick=\"Ver_Click\">Ver</button> </td>" +
                        "<td> <asp:Button runat=\"server\" ID=\"mod"+ seg.idSeg + "\" OnClick=\"Modificar_Click\" CommandArgument=\"" + seg.idSeg + "\" Text=\"Modificar\"/> </tr>";
                }

                SeguimientoMensual seguim = listaSegNutri.Last<SeguimientoMensual>();
            }
            else { SeguimMensual.Text = "No existen Seguimientos Nutricionales de este cliente."; }
        }

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
                    AntSAFech.Text = anterior.antrop.Fecha_SA + "";
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
        
        protected void BackButton_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("Expedientes.aspx");
        }

        protected void MedicButton_Click(object sender, EventArgs e)
        {

        }

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
            if(SegAntEdad.Text != "") { nuevoAntrop.Edad = Decimal.Parse(SegAntEdad.Text); } else { nuevoAntrop.Edad = Decimal.Parse("0"); }
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
            if(exito == true)
            {
                Response.Write("Seguimiento Agregado Exitosamente");
            }
            else
            {
                Response.Write("Error al Agregar Seguimiento Nutricional");
            }

        }

        protected void Ver_Click(object sender, EventArgs e)
        {

        }
        protected void Modificar_Click(object sender, EventArgs e)
        {

        }



		protected void btnGeneraPDF_Click(object sender, EventArgs e)
		{
			string oldFile = "C:/Users/Cristel/Source/Repos/ProyectoNutreVida/NutreVida/UI/Plantilla.pdf";
			string newFile = "C:/Users/Cristel/Source/Repos/ProyectoNutreVida/NutreVida/UI/Reporte.pdf";


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
							string nombre = "Nombre: " + txtNombre.Text;
							string fecha = "Fecha: " + System.DateTime.Today.ToShortDateString();
							string peso = "Peso: " + txtPesoActual.Text;
							string imc = "IMC: " + txtIMC.Text;
							string grasa = "% Grasa: " + txtPorcGrasas.Text + "%";
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







			//// open the reader
			//PdfReader reader = new PdfReader(oldFile);
			//Rectangle size = reader.GetPageSizeWithRotation(1);
			//Document document = new Document(size);

			//// open the writer
			//FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
			//PdfWriter writer = PdfWriter.GetInstance(document, fs);
			//document.Open();

			//// the pdf content
			//PdfContentByte cb = writer.DirectContent;

			//// select the font properties
			//BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			//cb.SetColorFill(Color.DARK_GRAY);
			//cb.SetFontAndSize(bf, 8);

			//// write the text in the pdf content
			//cb.BeginText();
			//string text = "AQUI VA LA INFO DEL PACIENTE";
			//// put the alignment and coordinates here
			//cb.ShowTextAligned(1, text, 250, 370, 0);
			//cb.EndText();
			//cb.BeginText();
			//text = "Other random blabla...";
			//// put the alignment and coordinates here
			//cb.ShowTextAligned(2, text, 100, 200, 0);
			//cb.EndText();

			//// create the new page and add it to the pdf
			//PdfImportedPage page = writer.GetImportedPage(reader, 1);
			//cb.AddTemplate(page, 0, 0);

			//// close the streams and voilá the file should be changed :)
			//document.Close();
			//fs.Close();
			//writer.Close();
			//reader.Close();

			ShowPdf(newFile);
		}



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

//StringWriter sw = new StringWriter();
//string html = sw.ToString();

//HtmlTextWriter htmlTextWriter = new HtmlTextWriter(sw);
//txtAbdomen.RenderControl(htmlTextWriter);
//StringReader stringReader = new StringReader(sw.ToString());

//Document Doc = new Document();

//PdfWriter.GetInstance
//(Doc, new FileStream(Environment.GetFolderPath
//(Environment.SpecialFolder.Desktop)
//+ "\\Prueba.pdf", FileMode.Create));
//Doc.Open();

//HTMLWorker htmlparser = new HTMLWorker(Doc);
//htmlparser.Parse(stringReader);

//Chunk c = new Chunk
//("Prueba de un Documento en PDF \n", FontFactory.GetFont("Verdana", 15));

//Paragraph p = new Paragraph();
//p.Alignment = Element.ALIGN_CENTER;
//p.Add(c);

//BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
//Font times = new Font(bfTimes, 12, Font.ITALIC, Color.RED);
//Font times2 = new Font(bfTimes, 12, Font.NORMAL, Color.BLACK);

//Chunk chunk1 = new Chunk
//("\nEste es un parrafo (p1) alineado a la derecha, con letra cursiva y de color rojo. \n\n", times);
//Paragraph p1 = new Paragraph();

//p1.Alignment = Element.ALIGN_RIGHT;
//p1.Add(chunk1);

//Chunk chunk2 = new Chunk
//("Este es un parrafo (p2) con letra normal, color negro, en el que estamos concatenando este texto un texto extraido de un textbox, que dice HOLAAAAAAAAAAAAA'", times2);
//Paragraph p2 = new Paragraph();

//p2.Alignment = Element.ALIGN_JUSTIFIED;
//p2.Add(chunk2);

//Doc.Add(p);
//Doc.Add(p1);
//Doc.Add(p2);

//System.Xml.XmlTextReader xmlReader = new System.Xml.XmlTextReader(new StringReader(html));
//HtmlParser.Parse(Doc, xmlReader);

//Doc.Close();