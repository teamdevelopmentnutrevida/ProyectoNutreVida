using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
    /**
     * Client Class, shows the information of the file and manage the button´s action.
     * @author Yoselyn
    */
    public partial class Cliente : System.Web.UI.Page
    {
        
        private static string Cedula = "";
        private static List<SeguimientoSemanal> listaSeguimientos = new List<SeguimientoSemanal>();
        private static ManejadorSeguimientos manejadorSeg = new ManejadorSeguimientos();
        private static ManejadorExpediente manejExpediente = new ManejadorExpediente();
        private static ManejadorErrores manejError = new ManejadorErrores();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();

            }
           
        }

        private void CargarDatos()
        {
            Cedula = (string)Session["ced"];
            CargarInfoPersonal();
            CargarHistorialMedico();
            CargarHabitosAlimentarios();
            CargarAntropometría();
        }

        /**
        * Método publico que carga la seccion de la información personal del cliente seleccionado 
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
                    FechIngreso.Text = c.FechaIngreso.Day+" / "+c.FechaIngreso.Month+" / "+c.FechaIngreso.Year;
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
            if (fechaNac.Equals("")) { return "";}
            else
            {
                 int años = DateTime.Now.Year - fechaNac.Year;
                if (fechaNac.Month > DateTime.Now.Month) { return años - 1 + "";}
                else{
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
                txtEspres.Text = hab.AfueraExpress+"";
                txtQueComeFuera.Text = hab.ComidaFuera;
                cantAzucar.Text = hab.AzucarBebida;
                dropCocinaCon.Text = hab.ComidaElaboradCon;
                txtCuantaAgua.Text = hab.AguaDiaria+"";
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
                   foreach(Recordatorio24H r in record)
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
                txtEdad.Text = antrop.Edad +"";
                txtPesoActual.Text = antrop.Peso + "";
                txtPesoMaxTeoria.Text = antrop.PesoMaxTeoria + "";
                txtPesoIdeal.Text = antrop.PesoIdeal+"";
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
                txtGET.Text = antrop.GET+"";
                choPorc.Text = antrop.CHOPorc+"";
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
                    txtPorcLeche.Text = porcion.Leche+"";
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
        * Método publico que carga la lista del seguimiento semanal del cliente seleccionado 
        */
        private void CargarSeguimientoSemanal()
        {
            listaSeguimientos = manejadorSeg.TraerLista(Int32.Parse(Cedula));
            if (listaSeguimientos != null){
                foreach (SeguimientoSemanal seg in listaSeguimientos) {
                    LitSeguimiento.Text += "<tr><td>" + seg.Sesion + "</td><td>" + seg.Fecha.ToString("dd/MM/yyyy") + "</td><td>" + seg.Peso + "</td><td>" + seg.Oreja + "</td><td>" + seg.Ejercicio + "</td></tr>";} 
            }
            else{LitSeguimiento.Text = "No existen Seguimientos Semanales de este usuario.";}
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
                    peso= Convert.ToDecimal(sPeso.Text);
                }
                catch (FormatException)
                {
                    string y = manejError.ErrorIngresoNumero();
                    Response.Write(y);
                    peso = 0;
                    
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
                        listaSeguimientos.Add(new SeguimientoSemanal(1, DateTime.Now.Date, Convert.ToDecimal(sPeso.Text), sOreja.Text, sEjercicio.Text,int.Parse(ced1.Text)));
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


        protected void OkButton_Click(object sender, EventArgs e)
        {
           
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {

        }

        protected void MedicButton_Click(object sender, EventArgs e)
        {

        }
    }
}