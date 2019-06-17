using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
    public partial class PrimerIngreso : System.Web.UI.Page
    {
        private static List<Medicamento> ListaMedicamSuplem = new List<Medicamento>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


            }
        }

        protected void DropLicor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropLicor.SelectedValue == "Sí")
            {
                txtFrecLicor.Enabled = true;
            }
            else {
                txtFrecLicor.Enabled = false;
            }

        }

        protected void DropFuma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropFuma.SelectedValue == "Sí")
            {
                txtFrecFuma.Enabled = true;
            }
            else {
                txtFrecFuma.Enabled = false;
            }
        }

        protected void capturarRecordatorio()
        {
            string horaAyunas = txtHoraAyunas.Text.ToString();
            string descAyunas = txtDescAyunas.Text;
            string horaDes = txtHoraDesayuno.Text.ToString();
            string descDesay = txtDescDesay.Text;
            string horaMediaM = txtHoraMediaM.Text.ToString();
            string descMediaM = txtDescMediaM.Text;
            string horaAlm = txtHoraAlmmuerzo.Text.ToString();
            string descAlmuerzo = txtDescAlmuerzo.Text;
            string horaTarde = txtHoraTarde.Text.ToString();
            string descTarde = txtDescTarde.Text;
            string horaCena = txtHoraCena.Text.ToString();
            string descCena = txtDescCena.Text;
            string horaColac = txtHoraColacion.Text.ToString();
            string descColac = txtDescColacion.Text;



        }

        protected void capturarRecordatorioAntrop()
        {
            string horaAyunasA = txtHoraAyunasA.Text.ToString();
            string descAyunasA = txtDescAyunasA.Text;
            string horaDesA = txtHoraDesayunoA.Text.ToString();
            string descDesayA = txtDescDesayA.Text;
            string horaMediaMA = txtHoraMediaMA.Text.ToString();
            string descMediaMA = txtDescMediaMA.Text;
            string horaAlmuerzoA = txtHoraAlmmuerzoA.Text.ToString();
            string descAlmuerzoA = txtDescAlmuerzoA.Text;
            string horaTardeA = txtHoraTardeA.Text.ToString();
            string descTardeA = txtDescTardeA.Text;
            string horaCenaA = txtHoraCenaA.Text.ToString();
            string descCenaA = txtDescCenaA.Text;
            string horaColacA = txtHoraColacionA.Text.ToString();
            string descColacA = txtDescColacionA.Text;



        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BL.PrimerIngreso ingreso = new BL.PrimerIngreso();


            ////Datos personales

            if (string.IsNullOrEmpty(txtCed.Text))
            {
                //mensaje de error
                Response.Write("<script>window.alert('Debe registrar un número de cedula');</script>");
                return;

            }

            int cedula = int.Parse(txtCed.Text);

            string correo = txtEmail.Text;
            string nombre = txtNombre.Text;
            string apellido1 = txtPrimerApellido.Text;
            string apellido2 = txtSegundoApellido.Text;
            DateTime fecha_Nacimiento;

            //Validacion de fecha vacia, guarda la fecha del sistema
            if (string.IsNullOrEmpty(iFechaNac.Value))
            {
                fecha_Nacimiento = DateTime.Now;
            }
            else
                fecha_Nacimiento = DateTime.Parse(iFechaNac.Value);

			

            char sexo = char.Parse(dropSexo.SelectedValue);

            string estado_Civil = dropEstadoCivil.SelectedValue;
            char whatsApp = '0';
            if (dropWhats.SelectedValue.Equals("Sí"))
            {
                whatsApp = '1';
            }
            int telefono;

            if (string.IsNullOrEmpty(txtTel.Text))
            {
                telefono = 0;
            }
            else
                telefono = int.Parse(txtTel.Text);
            string residencia = txtResid.Text;
            string ocupacion = txtOcup.Text;
            DateTime fechaIngreso = DateTime.Now;


            ingreso.CrearCliente(cedula, correo, nombre, apellido1, apellido2, fecha_Nacimiento, sexo, estado_Civil, whatsApp, telefono, residencia, ocupacion, fechaIngreso);


            //Historial medico

            string antecedentes = txtAntec.Text; ;
            string patologias = txtPatol.Text;
            int consumeLicor = 0;
            if (DropLicor.SelectedValue.Equals("Sí"))
            {
                consumeLicor = 1;
            }

            int fuma = 0;
            if (DropFuma.SelectedValue.Equals("Sí"))
            {
                consumeLicor = 1;
            }

            string frecFuma = txtFrecFuma.Text;
            string frecLicor = txtFrecLicor.Text;
            string ultimoExamen = fechaExam.Value;
            string actividadFisica = txtActividadFisica.Text;
            List<Medicamento> listaM = ListaMedicamSuplem; // no se si debería validar que la lista tenga al menos un elemento

            HistorialMedico historial = new HistorialMedico(cedula, antecedentes, patologias, consumeLicor, fuma, frecFuma, frecLicor, ultimoExamen, actividadFisica);
            ingreso.AgregarHistorialMedico(historial, listaM);

            //Habitos alimentario
            int ComidaDiaria;
            if (string.IsNullOrEmpty(numeroComidas.Text))
            {
                ComidaDiaria = 0;
            }
            else
                ComidaDiaria = int.Parse(numeroComidas.Text);

            char ComidaHorasDia = '0'; //drop
            if (ComeHoras.SelectedValue.Equals("Sí"))
            {
                ComidaHorasDia = '1';
            }

            int AfueraExpress;
            if (string.IsNullOrEmpty(txtEspres.Text))
            {
                AfueraExpress = 0;
            }
            else
                AfueraExpress = int.Parse(txtEspres.Text);
            string ComidaFuera = txtQueComeFuera.Text;
            string AzucarBebida = cantAzucar.Text;
            string ComidaElaboradCon = dropCocinaCon.SelectedValue; //drop

            decimal AguaDiaria;
            if (string.IsNullOrEmpty(txtCuantaAgua.Text))
            {
                AguaDiaria = 0;
            }
            else
                AguaDiaria = decimal.Parse(txtCuantaAgua.Text);

            char Aderezos = '0'; //drop
            if (dropAderezos.SelectedValue.Equals("Sí"))
            {
                Aderezos = '1';
            }

            char Fruta = '0'; //drop
            if (dropFrutas.SelectedValue.Equals("Sí"))
            {
                Fruta = '1';
            }

            char Verdura = '0'; //drop
            if (dropVeget.SelectedValue.Equals("Sí"))
            {
                Verdura = '1';
            }

            char Leche = '0'; //drop
            if (dropLeche.SelectedValue.Equals("Sí"))
            {
                Leche = '1';
            }

            char Huevo = '0'; //drop
            if (dropHuevo.SelectedValue.Equals("Sí"))
            {
                Huevo = '1';
            }

            char Yogurt = '0'; //drop
            if (dropYogurt.SelectedValue.Equals("Sí"))
            {
                Yogurt = '1';
            }

            char Carne = '0'; //drop
            if (dropCarne.SelectedValue.Equals("Sí"))
            {
                Carne = '1';
            }

            char Queso = '0'; //drop
            if (dropQueso.SelectedValue.Equals("Sí"))
            {
                Queso = '1';
            }

            char Aguacate = '0'; //drop
            if (dropAguacate.SelectedValue.Equals("Sí"))
            {
                Aguacate = '1';
            }

            char Semillas = '0'; //drop
            if (dropSemillas.SelectedValue.Equals("Sí"))
            {
                Semillas = '1';
            }

            HabitoAlimentario habito = new HabitoAlimentario(cedula, ComidaDiaria, ComidaHorasDia, AfueraExpress, ComidaFuera, AzucarBebida, ComidaElaboradCon, AguaDiaria, Aderezos, Fruta, Verdura, Leche, Huevo, Yogurt, Carne, Queso, Aguacate, Semillas);
            List<Recordatorio24H> listaRecordatorio = new List<Recordatorio24H>();

            //ayunas
            listaRecordatorio.Add(new Recordatorio24H(cedula, "Ayunas", txtHoraAyunas.Text, txtDescAyunas.Text));

            //desayuno
            listaRecordatorio.Add(new Recordatorio24H(cedula, "Desayuno", txtHoraDesayuno.Text, txtDescDesay.Text));

            //Media mañana
            listaRecordatorio.Add(new Recordatorio24H(cedula, "Media mañana", txtHoraMediaM.Text, txtDescMediaM.Text));

            //almuerzo
            listaRecordatorio.Add(new Recordatorio24H(cedula, "Almuerzo", txtHoraAlmmuerzo.Text, txtDescAlmuerzo.Text));

            //Media tarde
            listaRecordatorio.Add(new Recordatorio24H(cedula, "Tarde", txtHoraTarde.Text, txtDescTarde.Text));

            //Cena
            listaRecordatorio.Add(new Recordatorio24H(cedula, "Cena", txtHoraCena.Text, txtDescCena.Text));

            //Colacion nocturna
            listaRecordatorio.Add(new Recordatorio24H(cedula, "Colasión nocturna", txtHoraColacion.Text, txtDescColacion.Text));

            ingreso.AgregarHabitosAlimentarios(new HabitoAlimentario(cedula, ComidaDiaria, ComidaHorasDia, AfueraExpress, ComidaFuera, AzucarBebida, ComidaElaboradCon, AguaDiaria, Aderezos, Fruta, Verdura, Leche, Huevo, Yogurt, Carne, Queso, Aguacate, Semillas), listaRecordatorio);

            //Antropometria
            decimal talla;
            if (string.IsNullOrEmpty(txtTalla.Text))
            {
                talla = 0;
            }
            else
                talla = decimal.Parse(txtTalla.Text);

            decimal pesoIdeal;
            if (string.IsNullOrEmpty(txtPesoIdeal.Text))
            {
                pesoIdeal = 0;
            }
            else
                pesoIdeal = decimal.Parse(txtPesoIdeal.Text);



			//if (string.IsNullOrEmpty(txtEdad.Text))
			//{
			//    edad = 0;
			//}
			//else
			//    edad = decimal.Parse(txtEdad.Text);

			//edad calculada
			int edad;
			edad = DateTime.Now.Year - fecha_Nacimiento.Year;

			txtEdad.Text = edad.ToString();


			decimal pMB;
            if (string.IsNullOrEmpty(txtPMB.Text))
            {
                pMB = 0;
            }
            else
                pMB = decimal.Parse(txtPMB.Text);

            decimal peso;
            if (string.IsNullOrEmpty(txtPesoActual.Text))
            {
                peso = 0;
            }
            else
                peso = decimal.Parse(txtPesoActual.Text);

            decimal pesoMaxTeoria;
            if (string.IsNullOrEmpty(txtPesoMaxTeoria.Text))
            {
                pesoMaxTeoria = 0;
            }
            else
                pesoMaxTeoria = decimal.Parse(txtPesoMaxTeoria.Text);

			//IMC calculado
            decimal iMC;
			iMC = peso / (decimal)Math.Sqrt((double)talla);

            //if (string.IsNullOrEmpty(txtIMC.Text))
            //{
            //    iMC = 0;
            //}
            //else
            //    iMC = decimal.Parse(txtIMC.Text);

            decimal porcGrasaAnalizador;
            if (string.IsNullOrEmpty(txtGrasaAnalizador.Text))
            {
                porcGrasaAnalizador = 0;
            }
            else
                porcGrasaAnalizador = decimal.Parse(txtGrasaAnalizador.Text);

            decimal porcGr_Bascula;
            if (string.IsNullOrEmpty(txtGrasaBascula.Text))
            {
                porcGr_Bascula = 0;
            }
            else
                porcGr_Bascula = decimal.Parse(txtGrasaBascula.Text);

            decimal gB_BI;
            if (string.IsNullOrEmpty(txtGB_BI.Text))
            { gB_BI = 0; }
            else
                gB_BI = decimal.Parse(txtGB_BI.Text);

            decimal gB_BD;
            if (string.IsNullOrEmpty(txtGB_BD.Text))
            { gB_BD = 0; }
            else
                gB_BD = decimal.Parse(txtGB_BD.Text);

            decimal gB_PI;
            if (string.IsNullOrEmpty(txtGB_PI.Text))
            { gB_PI = 0; }
            else
                gB_PI = decimal.Parse(txtGB_PI.Text);

            decimal gB_PD;
            if (string.IsNullOrEmpty(txtGB_PD.Text))
            { gB_PD = 0; }
            else
                gB_PD = decimal.Parse(txtGB_PD.Text);

            decimal gB_Tronco;
            if (string.IsNullOrEmpty(txtGB_Trono.Text))
            { gB_Tronco = 0; }
            else
                gB_Tronco = decimal.Parse(txtGB_Trono.Text);

            decimal aguaCorporal;
            if (string.IsNullOrEmpty(txtAgua.Text))
            { aguaCorporal = 0; }
            else
                aguaCorporal = decimal.Parse(txtAgua.Text);

            decimal masaOsea;
            if (string.IsNullOrEmpty(txtMasaOsea.Text))
            { masaOsea = 0; }
            else
                masaOsea = decimal.Parse(txtMasaOsea.Text);

            decimal complexión;
            if (string.IsNullOrEmpty(txtComplexion.Text))
            { complexión = 0; }
            else
                complexión = decimal.Parse(txtComplexion.Text);

            decimal edadMetabolica;
            if (string.IsNullOrEmpty(txtEdadMetabolica.Text))
            { edadMetabolica = 0; }
            else
                edadMetabolica = decimal.Parse(txtEdadMetabolica.Text);

            decimal cintura;
            if (string.IsNullOrEmpty(txtCintura.Text))
            { cintura = 0; }
            else
                cintura = decimal.Parse(txtCintura.Text);

            decimal abdomen;
            if (string.IsNullOrEmpty(txtAbdomen.Text))
            { abdomen = 0; }
            else
                abdomen = decimal.Parse(txtAbdomen.Text);

            decimal cadera;
            if (string.IsNullOrEmpty(txtCadera.Text))
            { cadera = 0; }
            else
                cadera = decimal.Parse(txtCadera.Text);

            decimal muslo;
            if (string.IsNullOrEmpty(txtMuslo.Text))
            { muslo = 0; }
            else
                muslo = decimal.Parse(txtMuslo.Text);

            decimal cBM;
            if (string.IsNullOrEmpty(txtCMB.Text))
            { cBM = 0; }
            else
                cBM = decimal.Parse(txtCMB.Text);

            decimal circunfMunneca;
            if (string.IsNullOrEmpty(txtCircunferencia.Text))
            { circunfMunneca = 0; }
            else
                circunfMunneca = decimal.Parse(txtCircunferencia.Text);

            decimal porcentGViceral;
            if (string.IsNullOrEmpty(txtGarsaViceral.Text))
            { porcentGViceral = 0; }
            else
                porcentGViceral = decimal.Parse(txtGarsaViceral.Text);

            decimal porcentMusculo;
            if (string.IsNullOrEmpty(txtMuslo.Text))
            { porcentMusculo = 0; }
            else
                porcentMusculo = decimal.Parse(txtMuslo.Text);

            decimal pM_BI;
            if (string.IsNullOrEmpty(txtPM_BI.Text))
            { pM_BI = 0; }
            else
                pM_BI = decimal.Parse(txtPM_BI.Text);

            decimal pM_PD;
            if (string.IsNullOrEmpty(txtPM_PD.Text))
            { pM_PD = 0; }
            else
                pM_PD = decimal.Parse(txtPM_PD.Text);

            decimal pM_BD;
            if (string.IsNullOrEmpty(txtPM_BD.Text))
            { pM_BD = 0; }
            else
                pM_BD = decimal.Parse(txtPM_BD.Text);

            decimal pM_PI;
            if (string.IsNullOrEmpty(txtPM_PI.Text))
            { pM_PI = 0; }
            else
                pM_PI = decimal.Parse(txtPM_PI.Text);

            decimal pM_Tronco;
            if (string.IsNullOrEmpty(txtPM_Tronco.Text))
            { pM_Tronco = 0; }
            else
                pM_Tronco = decimal.Parse(txtPM_Tronco.Text);



            string observaciones = txtObservaciones.Text;


			//GEB calculado
            decimal gEB= 0;

			if (edad > 10 && sexo.Equals('F'))
			{
				gEB = 655 + ((decimal)(9.6) * pesoIdeal) + ((decimal)(1.8) * talla) - (decimal)(4.7 * edad);
			} else if (edad > 10 && sexo.Equals('M'))
			{
				gEB = (decimal)(66.5) + ((decimal)(13.7) * pesoIdeal) + (5 * talla) - (decimal)(6.8 * edad);
			} else if (edad < 10)
			{
				gEB = (decimal)22.1 + ((decimal)(31.05) * pesoIdeal) + ((decimal)(1.16) * talla);

			}

			//if (string.IsNullOrEmpty(txtGEB.Text))
			//{ gEB = 0; }
			//else
			//    gEB = decimal.Parse(txtGEB.Text);


			
			decimal gET = 0;
			if (string.IsNullOrEmpty(txtGET.Text))
			{ gET = 0; }
			else
				gET = decimal.Parse(txtGET.Text);

			decimal cHOPorc;
            if (string.IsNullOrEmpty(choPorc.Text))
            { cHOPorc = 0; }
            else
                cHOPorc = decimal.Parse(choPorc.Text);

            decimal cHOGram;
            if (string.IsNullOrEmpty(choGram.Text))
            { cHOGram = 0; }
            else
                cHOGram = decimal.Parse(choGram.Text);

            decimal cHO_kcal;
            if (string.IsNullOrEmpty(choKcal.Text))
            { cHO_kcal = 0; }
            else
                cHO_kcal = decimal.Parse(choKcal.Text);

            decimal proteinaPorc;
            if (string.IsNullOrEmpty(ProtPorc.Text))
            { proteinaPorc = 0; }
            else
                proteinaPorc = decimal.Parse(ProtPorc.Text);

            decimal proteinaGram;
            if (string.IsNullOrEmpty(ProtGram.Text))
            { proteinaGram = 0; }
            else
                proteinaGram = decimal.Parse(ProtGram.Text);

            decimal proteinakcal;
            if (string.IsNullOrEmpty(protKcal.Text))
            { proteinakcal = 0; }
            else
                proteinakcal = decimal.Parse(protKcal.Text);

            decimal grasaPorc;
            if (string.IsNullOrEmpty(GrasPorc.Text))
            { grasaPorc = 0; }
            else
                grasaPorc = decimal.Parse(GrasPorc.Text);

            decimal grasaGram;
            if (string.IsNullOrEmpty(GrasGram.Text))
            { grasaGram = 0; }
            else
                grasaGram = decimal.Parse(GrasGram.Text);

            decimal grasakcal;
            if (string.IsNullOrEmpty(GrasKcal.Text))
            { grasakcal = 0; }
            else
                grasakcal = decimal.Parse(GrasKcal.Text);



            decimal leche;
            if (string.IsNullOrEmpty(txtPorcLeche.Text))
            { leche = 0; }
            else
                leche = decimal.Parse(txtPorcLeche.Text);

            decimal carne;
            if (string.IsNullOrEmpty(txtPorcCarnes.Text))
            { carne = 0; }
            else
                carne = decimal.Parse(txtPorcCarnes.Text);

            decimal vegetales;
            if (string.IsNullOrEmpty(txtPorcVeget.Text))
            { vegetales = 0; }
            else
                vegetales = decimal.Parse(txtPorcVeget.Text);

            decimal grasa;
            if (string.IsNullOrEmpty(txtPorcGrasas.Text))
            { grasa = 0; }
            else
                grasa = decimal.Parse(txtPorcGrasas.Text);

            decimal fruta;
            if (string.IsNullOrEmpty(txtPorcFrutas.Text))
            {
                fruta = 0;
            }
            else
                fruta = decimal.Parse(txtPorcFrutas.Text);

            decimal azucar;
            if (string.IsNullOrEmpty(txtPorcAzuca.Text))
            {
                azucar = 0;
            }
            else
                azucar = decimal.Parse(txtPorcAzuca.Text);

            decimal harina;
            if (string.IsNullOrEmpty(txtPorcHarinas.Text))
            {
                harina = 0;
            }
            else
                harina = decimal.Parse(txtPorcHarinas.Text);

            decimal suplemento;
            if (string.IsNullOrEmpty(txtPorcSuplem.Text))
            {
                suplemento = 0;
            }
            else
                suplemento = decimal.Parse(txtPorcSuplem.Text);



            List<DistribucionPorciones> distribucion = new List<DistribucionPorciones>();

            //ayunas
            distribucion.Add(new DistribucionPorciones(cedula, "Ayunas", txtHoraAyunasA.Text, txtDescAyunasA.Text));

            //desayuno
            distribucion.Add(new DistribucionPorciones(cedula, "Desayuno", txtHoraDesayunoA.Text, txtDescDesayA.Text));

            //Media mañana
            distribucion.Add(new DistribucionPorciones(cedula, "Media mañana", txtHoraMediaMA.Text, txtDescMediaMA.Text));

            //almuerzo
            distribucion.Add(new DistribucionPorciones(cedula, "Almuerzo", txtHoraAlmmuerzoA.Text, txtDescAlmuerzoA.Text));

            //Media tarde
            distribucion.Add(new DistribucionPorciones(cedula, "Tarde", txtHoraTardeA.Text, txtDescTardeA.Text));

            //Cena
            distribucion.Add(new DistribucionPorciones(cedula, "Cena", txtHoraCenaA.Text, txtDescCenaA.Text));

            //Colacion nocturna
            distribucion.Add(new DistribucionPorciones(cedula, "Colasión nocturna", txtHoraColacionA.Text, txtDescColacionA.Text));

            Antropometria antro = new Antropometria(cedula, talla, pesoIdeal, edad, pMB, peso, pesoMaxTeoria, iMC, porcGrasaAnalizador,
                porcGr_Bascula, gB_BI, gB_BD, gB_PI, gB_PD, gB_Tronco, aguaCorporal, masaOsea, complexión, edadMetabolica, cintura, abdomen, cadera,
                muslo, cBM, circunfMunneca, porcentGViceral, porcentMusculo, pM_BI, pM_PD, pM_BD, pM_PI, pM_Tronco, observaciones,
                gEB, gET, cHOPorc, cHOGram, cHO_kcal, proteinaPorc, proteinaGram, proteinakcal, grasaPorc, grasaGram, grasakcal);

            Porciones porcion = new Porciones(cedula, leche, carne, vegetales, grasa, fruta, azucar, harina, suplemento);

            ingreso.AgregarAntropometria(antro, porcion, distribucion);


        }



        protected void BtnAgreg_Click(object sender, EventArgs e)
        {
            if (tNomMed.Text.Equals("") || tMotvMed.Text.Equals("") || tFrecMed.Text.Equals("") || tDosisMed.Text.Equals(""))
            {
                Response.Write("<script>alert('No deben haber espacios en blanco')</script>");
            }
            else
            {
                Medicamento medicamSupl = new Medicamento();
                string tabla = tSuplementoMedico.Text;
                tabla += "<tr><td>" + tNomMed.Text + "</td><td>" + tMotvMed.Text + "</td><td>" + tFrecMed.Text + "</td><td>" + tDosisMed.Text + "</td></tr>";
                tSuplementoMedico.Text = tabla;

                if (string.IsNullOrEmpty(txtCed.Text))
                {
                    //mensaje de error
                    Response.Write("<script>window.alert('Debe registrar un número de cedula');</script>");
                    return;

                }

                medicamSupl.Cedula = int.Parse(txtCed.Text);

                medicamSupl.Nombre = tNomMed.Text;
                medicamSupl.Motivo = tMotvMed.Text;
                medicamSupl.Frecuencia = tFrecMed.Text;
                medicamSupl.Dosis = tDosisMed.Text;
                ListaMedicamSuplem.Add(medicamSupl);

                tNomMed.Text = "";
                tMotvMed.Text = "";
                tFrecMed.Text = "";
                tDosisMed.Text = "";
            }
        }


		//metodo para calcular geb y mostrarlo en el textbox
		public void calcularGEB()
		{
			DateTime fecha_Nacimiento;

			if (string.IsNullOrEmpty(iFechaNac.Value))
			{
				fecha_Nacimiento = DateTime.Now;
			}
			else
				fecha_Nacimiento = DateTime.Parse(iFechaNac.Value);

			decimal talla;
			if (string.IsNullOrEmpty(txtTalla.Text))
			{
				talla = 0;
			}
			else
				talla = decimal.Parse(txtTalla.Text);

			decimal pesoIdeal;
			if (string.IsNullOrEmpty(txtPesoIdeal.Text))
			{
				pesoIdeal = 0;
			}
			else
				pesoIdeal = decimal.Parse(txtPesoIdeal.Text);

			char sexo = char.Parse(dropSexo.SelectedValue);
			decimal gEB = 0;
			int edad;
			edad = DateTime.Now.Year - fecha_Nacimiento.Year;

			if (edad > 10 && sexo.Equals('F'))
			{
				gEB = 655 + ((decimal)(9.6) * pesoIdeal) + ((decimal)(1.8) * talla) - (decimal)(4.7 * edad);
			}
			else if (edad > 10 && sexo.Equals('M'))
			{
				gEB = (decimal)(66.5) + ((decimal)(13.7) * pesoIdeal) + (5 * talla) - (decimal)(6.8 * edad);
			}
			else if (edad < 10)
			{
				gEB = (decimal)22.1 + ((decimal)(31.05) * pesoIdeal) + ((decimal)(1.16) * talla);

			}
			txtGEB.Text = gEB.ToString();
			
		}

		protected void dropSexo_TextChanged(object sender, EventArgs e)
		{
			calcularGEB();
		}

		protected void txtPesoIdeal_TextChanged(object sender, EventArgs e)
		{
			calcularGEB();
		}

		protected void txtTalla_TextChanged(object sender, EventArgs e)
		{
			calcularGEB();
		}
	}
}