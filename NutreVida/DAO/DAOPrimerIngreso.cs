using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TO;

namespace DAO
{
    public class DAOPrimerIngreso
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        public bool CrearUsuario(TOClienteNutricion tOCliente)
        {
            //falta en la parte grafica ape1,ape2,estadoCivil
            //rol se quema
            //ingres se toma del sistema
            String query1 = "Insert into Usuario values(@ced,@cor,@nomb,@whats,@tel,@ape1,@ape2,@rol);";
            String query2 = "Insert into Cliente_Nutricion values(@fechNac,@sexo,@estCiv,@resid,@ocup,@ced,@ingres);";

            SqlCommand cmd = new SqlCommand(query1, conexion);
            SqlCommand cmd2 = new SqlCommand(query2, conexion);

            try
            {

                cmd.Parameters.AddWithValue("@ced", tOCliente.Cedula);
                cmd.Parameters.AddWithValue("@cor", tOCliente.Correo);
                cmd.Parameters.AddWithValue("@nomb", tOCliente.Nombre);
                cmd.Parameters.AddWithValue("@whats", tOCliente.WhatsApp);
                cmd.Parameters.AddWithValue("@tel", tOCliente.Telefono);
                cmd.Parameters.AddWithValue("@ape1", tOCliente.Apellido1);
                cmd.Parameters.AddWithValue("@ape2", tOCliente.Apellido2);
                cmd.Parameters.AddWithValue("@rol", "clienteNutri");


                cmd2.Parameters.AddWithValue("@fechNac", tOCliente.Fecha_Nacimiento);
                cmd2.Parameters.AddWithValue("@sexo", tOCliente.Sexo);
                cmd2.Parameters.AddWithValue("@estCiv", tOCliente.Estado_Civil);
                cmd2.Parameters.AddWithValue("@resid", tOCliente.Residencia);
                cmd2.Parameters.AddWithValue("@ocup", tOCliente.Ocupacion);
                cmd2.Parameters.AddWithValue("@ced", tOCliente.Cedula);
                cmd2.Parameters.AddWithValue("@ingres", DateTime.Now);

                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                cmd.ExecuteNonQuery();

                cmd2.ExecuteNonQuery();

                conexion.Close();

                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool GuardarHistorial(TOHistorialMedico historial, List<TOMedicamento> listaMedicamento)
        {
            //En laparte grafica falta consLic,fum
            string query1 = "Insert into Historial_Medico values(@antec,@patol,@consLic,@fum,@fechEx,@ced,@frecFum,@frecTom,@actvFis);";

            SqlCommand cmd = new SqlCommand(query1, conexion);

            try
            {
                //Historial Medico.
                //Asignacion de parametros.
                cmd.Parameters.AddWithValue("@antec", historial.Antecedentes);
                cmd.Parameters.AddWithValue("@patol", historial.Patologias);
                cmd.Parameters.AddWithValue("@consLic", historial.ConsumeLicor);
                cmd.Parameters.AddWithValue("@fum", historial.Fuma);
                cmd.Parameters.AddWithValue("@fechEx", historial.UltimoExamen);
                cmd.Parameters.AddWithValue("@ced", historial.Cedula);
                cmd.Parameters.AddWithValue("@frecFum", historial.FrecFuma);
                cmd.Parameters.AddWithValue("@frecTom", historial.FrecLicor);
                cmd.Parameters.AddWithValue("@actvFis", historial.ActividadFisica);
                //Validacion del estado de la conexion.
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                //Insercion del historial medico.
                cmd.ExecuteNonQuery();
                conexion.Close();
                //Insercion de los medicamentos o suplementos del cliente.
                if (listaMedicamento != null)
                {
                    foreach (TOMedicamento medicamento in listaMedicamento)
                    {
                        string query2 = "Insert into Medic_Suplem values(@ced,@nomb,@mot,@frec,@dosis)";
                        SqlCommand cmd2 = new SqlCommand(query2, conexion);
                        cmd2.Parameters.AddWithValue("@ced", medicamento.Cedula);
                        cmd2.Parameters.AddWithValue("@nomb", medicamento.Nombre);
                        cmd2.Parameters.AddWithValue("@mot", medicamento.Motivo);
                        cmd2.Parameters.AddWithValue("@frec", medicamento.Frecuencia);
                        cmd2.Parameters.AddWithValue("@dosis", medicamento.Dosis);
                        conexion.Open();
                        cmd2.ExecuteNonQuery();
                        conexion.Close();
                    }
                }

                return true;
            }
            catch (SqlException)
            {
                return false;
            }

        }

        public bool GuardarHabitos(TOHabitoAlimentario HabitosAlimentario, List<TORecordatorio24H> listaR)
        {
            String query1 = "Insert into HabitosAlimentario values(@ced,@comDi,@ComHD,@express,@comFue,@azuc,@comElab,@agua,@ader,@frut,@verd,@lech,@huev,@yogurt,@carn,@ques,@aguacat,@semil);";
            SqlCommand cmd = new SqlCommand(query1, conexion);
            try
            {
                cmd.Parameters.AddWithValue("@ced", HabitosAlimentario.Cedula);
                cmd.Parameters.AddWithValue("@comDi", HabitosAlimentario.ComidaDiaria);
                cmd.Parameters.AddWithValue("@ComHD", HabitosAlimentario.ComidaHorasDia);
                cmd.Parameters.AddWithValue("@express", HabitosAlimentario.AfueraExpress);
                cmd.Parameters.AddWithValue("@comFue", HabitosAlimentario.ComidaFuera);
                cmd.Parameters.AddWithValue("@azuc", HabitosAlimentario.AzucarBebida);
                cmd.Parameters.AddWithValue("@comElab", HabitosAlimentario.ComidaElaboradCon);
                cmd.Parameters.AddWithValue("@agua", HabitosAlimentario.AguaDiaria);
                cmd.Parameters.AddWithValue("@ader", HabitosAlimentario.Aderezos);
                cmd.Parameters.AddWithValue("@frut", HabitosAlimentario.Fruta);
                cmd.Parameters.AddWithValue("@verd", HabitosAlimentario.Verdura);
                cmd.Parameters.AddWithValue("@lech", HabitosAlimentario.Leche);
                cmd.Parameters.AddWithValue("@huev", HabitosAlimentario.Huevo);
                cmd.Parameters.AddWithValue("@yogurt", HabitosAlimentario.Yogurt);
                cmd.Parameters.AddWithValue("@carn", HabitosAlimentario.Carne);
                cmd.Parameters.AddWithValue("@ques", HabitosAlimentario.Queso);
                cmd.Parameters.AddWithValue("@aguacat", HabitosAlimentario.Aguacate);
                cmd.Parameters.AddWithValue("@semil", HabitosAlimentario.Semillas);


                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                //inserta 
                cmd.ExecuteNonQuery();
                conexion.Close();
                if (listaR != null)
                {
                    foreach (TORecordatorio24H recordatorio in listaR)
                    {
                        String query2 = "Insert into Recordat24H values(@ced,@tiempC,@hora,@descrip);";
                        SqlCommand cmd2 = new SqlCommand(query2, conexion);
                        cmd2.Parameters.AddWithValue("@ced", recordatorio.Cedula);
                        cmd2.Parameters.AddWithValue("@tiempC", recordatorio.TiempoComida);
                        cmd2.Parameters.AddWithValue("@hora", recordatorio.Hora);
                        cmd2.Parameters.AddWithValue("@descrip", recordatorio.Descripcion);
                        conexion.Open();
                        cmd2.ExecuteNonQuery();
                        conexion.Close();
                    }
                }

                return true;
            }
            catch (SqlException)
            {
                conexion.Close();
                return false;
            }
        }

        public bool GuardarAntropometria(TOAntropometria antropom, TOPorciones porcion, List<TODistribucionPorciones> listDistrib)
        {
            String query1 = "Insert into Antropometria values(@ced, @talla, @pesIdeal, @edad,@pmb, @peso,@pesmax,@imc, @gAnaliz, @grbascu, @gbbi,@gbbd, @gbpi, @gbpd," +
                "@gbtronc, @aguacorp, @masaOsea, @complex,@edadMetab,@cint,@abdomn,@cader,@muslo,@cbm,@circunf,@grviser,@pormuscul,@pmbi,@pmpd,@pmbd," +
                 "@pmpi,@pmtronco,@observ,@geb,@get,@chopor,@chogram,@chokcal,@protpor,@protgram,@protkcal,@grporc,@grgram,@grkcal)";

            String query2 = "Insert into Porciones values( @pced,@pleche,@pcarne,@pveget,@pgrasa,@pfruta,@pazuc,@pharina, @psuplem)";

            

            SqlCommand cmd = new SqlCommand(query1, conexion);
            SqlCommand cmd2 = new SqlCommand(query2, conexion);

            try
            {

                cmd.Parameters.AddWithValue("@ced", antropom.Cedula); cmd.Parameters.AddWithValue("@talla", antropom.Talla);
                cmd.Parameters.AddWithValue("@pesIdeal", antropom.PesoIdeal); cmd.Parameters.AddWithValue("@edad", antropom.Edad);
                cmd.Parameters.AddWithValue("@pmb", antropom.PMB); cmd.Parameters.AddWithValue("@peso", antropom.Peso);
                cmd.Parameters.AddWithValue("@pesmax", antropom.PesoMaxTeoria); cmd.Parameters.AddWithValue("@imc", antropom.IMC);
                cmd.Parameters.AddWithValue("@gAnaliz", antropom.PorcGrasaAnalizador); cmd.Parameters.AddWithValue("@grbascu", antropom.PorcGr_Bascula);
                cmd.Parameters.AddWithValue("@gbbi", antropom.GB_BI); cmd.Parameters.AddWithValue("@gbbd", antropom.GB_BD);
                cmd.Parameters.AddWithValue("@gbpi", antropom.GB_PI); cmd.Parameters.AddWithValue("@gbpd", antropom.GB_PD);
                cmd.Parameters.AddWithValue("@gbtronc", antropom.GB_Tronco); cmd.Parameters.AddWithValue("@aguacorp", antropom.AguaCorporal);
                cmd.Parameters.AddWithValue("@masaOsea", antropom.MasaOsea); cmd.Parameters.AddWithValue("@complex", antropom.Complexión);
                cmd.Parameters.AddWithValue("@edadMetab", antropom.EdadMetabolica); cmd.Parameters.AddWithValue("@cint", antropom.Cintura);
                cmd.Parameters.AddWithValue("@abdomn", antropom.Abdomen); cmd.Parameters.AddWithValue("@cader", antropom.Cadera);
                cmd.Parameters.AddWithValue("@muslo", antropom.Muslo); cmd.Parameters.AddWithValue("@cbm", antropom.CBM);
                cmd.Parameters.AddWithValue("@circunf", antropom.CircunfMunneca); cmd.Parameters.AddWithValue("@grviser", antropom.PorcentGViceral);
                cmd.Parameters.AddWithValue("@pormuscul", antropom.PorcentMusculo); cmd.Parameters.AddWithValue("@pmbi", antropom.PM_BI);
                cmd.Parameters.AddWithValue("@pmpd", antropom.PM_PD); cmd.Parameters.AddWithValue("@pmbd", antropom.PM_BD);
                cmd.Parameters.AddWithValue("@pmpi", antropom.PM_PI); cmd.Parameters.AddWithValue("@pmtronco", antropom.PM_Tronco);
                cmd.Parameters.AddWithValue("@observ", antropom.Observaciones); cmd.Parameters.AddWithValue("@geb", antropom.GEB);
                cmd.Parameters.AddWithValue("@get", antropom.GET); cmd.Parameters.AddWithValue("@chopor", antropom.CHOPorc);
                cmd.Parameters.AddWithValue("@chogram", antropom.CHOGram); cmd.Parameters.AddWithValue("@chokcal", antropom.CHO_kcal);
                cmd.Parameters.AddWithValue("@protpor", antropom.ProteinaPorc); cmd.Parameters.AddWithValue("@protgram", antropom.ProteinaGram);
                cmd.Parameters.AddWithValue("@protkcal", antropom.Proteinakcal); cmd.Parameters.AddWithValue("@grporc", antropom.GrasaPorc);
                cmd.Parameters.AddWithValue("@grgram", antropom.GrasaGram); cmd.Parameters.AddWithValue("@grkcal", antropom.Grasakcal);

                cmd2.Parameters.AddWithValue("@pced", porcion.Cedula); cmd2.Parameters.AddWithValue("@pleche", porcion.Leche);
                cmd2.Parameters.AddWithValue("@pcarne", porcion.Carne); cmd2.Parameters.AddWithValue("@pveget", porcion.Vegetales);
                cmd2.Parameters.AddWithValue("@pgrasa", porcion.Grasa); cmd2.Parameters.AddWithValue("@pfruta", porcion.Fruta);
                cmd2.Parameters.AddWithValue("@pazuc", porcion.Azucar); cmd2.Parameters.AddWithValue("@pharina", porcion.Harina);
                cmd2.Parameters.AddWithValue("@psuplem", porcion.Suplemento);               



                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                //insertar
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                conexion.Close();

                if (listDistrib != null)
                {
                    foreach (TODistribucionPorciones distribucion in listDistrib)
                    {
                        String query3 = "Insert into DistribucionPorcion values(@desc,@tiempCom,@hora,@ced)";
                        SqlCommand cmd3 = new SqlCommand(query3, conexion);
                        cmd3.Parameters.AddWithValue("@ced", distribucion.Cedula);
                        cmd3.Parameters.AddWithValue("@tiempCom", distribucion.TiempoComida);
                        cmd3.Parameters.AddWithValue("@hora", distribucion.Hora);
                        cmd3.Parameters.AddWithValue("@desc", distribucion.Descripcion);
                        conexion.Open();
                        cmd3.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
                return true;
        }
            catch (SqlException)
            {
                return false;
            }
        }


    }
}
