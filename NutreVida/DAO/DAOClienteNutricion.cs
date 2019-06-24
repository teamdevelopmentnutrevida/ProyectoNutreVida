using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace DAO
{
    public class DAOClienteNutricion
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        public List<TOClienteNutricion> ListarCliente()
        {
            List<TOClienteNutricion> ListaMedidas = new List<TOClienteNutricion>();
            string qry = "Select * from Cliente_Nutricion c,Usuario u where c.Cedula = u.Cedula order by Apellido1";
            SqlCommand buscar = new SqlCommand(qry, conexion);
            SqlDataReader lector;

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            lector = buscar.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    ListaMedidas.Add(new TOClienteNutricion(Int32.Parse(lector["Cedula"].ToString()), lector["Correo"].ToString(), lector["Nombre"].ToString(), lector["Apellido1"].ToString(),
                        lector["Apellido2"].ToString(), DateTime.Parse(lector["Fecha_Nacimiento"].ToString()), Char.Parse(lector["Sexo"].ToString()),
                        lector["Estado_Civil"].ToString(), Char.Parse(lector["WhatsApp"].ToString()), Int32.Parse(lector["Telefono"].ToString()), lector["Residencia"].ToString(), lector["Ocupacion"].ToString(), DateTime.Parse(lector["FechaIngreso"].ToString()), lector["Consultorio"].ToString()));

                }
                conexion.Close();
                return ListaMedidas;
            }
            else
            {
                conexion.Close();
                return null;
            }
        }

        public TOClienteNutricion TraerInfoPersonal(string ced)
        {
            TOClienteNutricion cliente = new TOClienteNutricion();
            string qry = "Select * from Cliente_Nutricion c,Usuario u where c.Cedula = u.Cedula AND u.Cedula = "+ced;
            SqlCommand buscar = new SqlCommand(qry, conexion);
            SqlDataReader lector;

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            lector = buscar.ExecuteReader();
            if (lector.HasRows)
            {
                lector.Read();
                cliente = new TOClienteNutricion(Int32.Parse(lector["Cedula"].ToString()), lector["Correo"].ToString(), lector["Nombre"].ToString(), lector["Apellido1"].ToString(),
                        lector["Apellido2"].ToString(), DateTime.Parse(lector["Fecha_Nacimiento"].ToString()), Char.Parse(lector["Sexo"].ToString()),
                        lector["Estado_Civil"].ToString(), Char.Parse(lector["WhatsApp"].ToString()), Int32.Parse(lector["Telefono"].ToString()), lector["Residencia"].ToString(), lector["Ocupacion"].ToString(), DateTime.Parse(lector["FechaIngreso"].ToString()), lector["Consultorio"].ToString());
               
                conexion.Close();
                return cliente;
            }
            else
            {
                conexion.Close();
                return null;
            }
        }

        public TOHistorialMedico TraerHistorialMed(object ced)
        {
            TOHistorialMedico hm = new TOHistorialMedico();
            string query = "Select * from Historial_Medico where Cedula = " + ced;
            SqlCommand buscar = new SqlCommand(query, conexion);
            SqlDataReader lector;
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                lector = buscar.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    hm.Cedula = Int32.Parse(lector["Cedula"].ToString());
                    hm.Antecedentes = lector["Antecedentes_Fam"].ToString();
                    hm.Patologias = lector["Patologias"].ToString();
                    hm.ConsumeLicor = Int32.Parse(lector["Cosumo_Licor"].ToString());
                    hm.Fuma = Int32.Parse(lector["Fumador"].ToString());
                    hm.UltimoExamen = DateTime.Parse(lector["Fecha_Ult_Exm"].ToString()).Date + "";
                    hm.FrecFuma = lector["FrecFumar"].ToString();
                    hm.FrecLicor = lector["FrecTomar"].ToString();
                    hm.ActividadFisica = lector["ActividadFisica"].ToString();
                    conexion.Close();
                }
                else
                {
                    conexion.Close();
                    return null;
                }
            }
            catch
            { conexion.Close(); }
            return hm;
        }

        public List<TORecordatorio24H> TraerRecord24H(object ced)
        {
            List<TORecordatorio24H> list = new List<TORecordatorio24H>();
            string qry = "Select * from Recordat24H where Cedula =" + ced;
            SqlCommand buscar = new SqlCommand(qry, conexion);
            SqlDataReader lector;

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            lector = buscar.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    list.Add(new TORecordatorio24H(Int32.Parse(lector["Cedula"].ToString()), lector["TiempoComida"].ToString(), 
                    lector["Hora"].ToString(), lector["Descripcion"].ToString()));
                }
                conexion.Close();
                return list;
            }
            else
            {
                conexion.Close();
                return null;
            }
        }

        public TOAntropometria TraerAntropometria(string cedula)
        {
             string qry = "select * from Antropometria where Cedula = " + cedula;
            SqlCommand cmd = new SqlCommand(qry, conexion);
            SqlDataReader lector;
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                lector = cmd.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    TOAntropometria antrop = new TOAntropometria();
                    antrop.Cedula = Int32.Parse(lector["Cedula"].ToString());
                    antrop.Talla = Decimal.Parse(lector["Talla"].ToString());
                    antrop.PesoIdeal = Decimal.Parse(lector["PesoIdeal"].ToString());
                    antrop.Edad = Decimal.Parse(lector["Edad"].ToString());
                    antrop.PMB = Decimal.Parse(lector["PMB"].ToString());
                    antrop.Peso = Decimal.Parse(lector["Peso"].ToString());
                    antrop.PesoMaxTeoria = Decimal.Parse(lector["PesoMaxTeoria"].ToString());
                    antrop.IMC = Decimal.Parse(lector["IMC"].ToString());
                    antrop.PorcGrasaAnalizador = Decimal.Parse(lector["PorcGrasaAnalizador"].ToString());
                    antrop.PorcGr_Bascula = Decimal.Parse(lector["PorcGr_Bascula"].ToString());
                    antrop.GB_BI = Decimal.Parse(lector["GB_BI"].ToString());
                    antrop.GB_BD = Decimal.Parse(lector["GB_BD"].ToString());
                    antrop.GB_PI = Decimal.Parse(lector["GB_PI"].ToString());
                    antrop.GB_PD = Decimal.Parse(lector["GB_PD"].ToString());
                    antrop.GB_Tronco = Decimal.Parse(lector["GB_Tronco"].ToString());
                    antrop.AguaCorporal = Decimal.Parse(lector["AguaCorporal"].ToString());
                    antrop.MasaOsea = Decimal.Parse(lector["MasaOsea"].ToString());
                    antrop.Complexión = Decimal.Parse(lector["Complexion"].ToString());
                    antrop.EdadMetabolica = Decimal.Parse(lector["Edad_Metabolica"].ToString());
                    antrop.Cintura = Decimal.Parse(lector["Cintura"].ToString());
                    antrop.Abdomen = Decimal.Parse(lector["Abdomen"].ToString());
                    antrop.Cadera = Decimal.Parse(lector["Cadera"].ToString());
                    antrop.MusloDer = Decimal.Parse(lector["Muslo_Der"].ToString());
                    antrop.MusloIzq = Decimal.Parse(lector["Muslo_Izq"].ToString());
                    antrop.CBM = Decimal.Parse(lector["CBM"].ToString());
                    antrop.CircunfMunneca = Decimal.Parse(lector["CircunfMunneca"].ToString());
                    antrop.PorcentGViceral = Decimal.Parse(lector["PorcentGViceral"].ToString());
                    antrop.PorcentMusculo = Decimal.Parse(lector["PorcentMusculo"].ToString());
                    antrop.PM_BI = Decimal.Parse(lector["PM_BI"].ToString());
                    antrop.PM_PD = Decimal.Parse(lector["PM_PD"].ToString());
                    antrop.PM_BD = Decimal.Parse(lector["PM_BD"].ToString());
                    antrop.PM_PI = Decimal.Parse(lector["PM_PI"].ToString());
                    antrop.PM_Tronco = Decimal.Parse(lector["PM_Troco"].ToString());
                    antrop.Observaciones = lector["Observaciones"].ToString();
                    antrop.GEB = Decimal.Parse(lector["GEB"].ToString());
                    antrop.GET = Decimal.Parse(lector["GET"].ToString());
                    antrop.CHOPorc = Decimal.Parse(lector["CHOPorc"].ToString());
                    antrop.CHOGram = Decimal.Parse(lector["CHOGram"].ToString());
                    antrop.CHO_kcal = Decimal.Parse(lector["CHOkcal"].ToString());
                    antrop.ProteinaPorc = Decimal.Parse(lector["ProteinaPorc"].ToString());
                    antrop.ProteinaGram = Decimal.Parse(lector["ProteinaGram"].ToString());
                    antrop.Proteinakcal = Decimal.Parse(lector["Proteinakcal"].ToString());
                    antrop.GrasaPorc = Decimal.Parse(lector["GrasaPorc"].ToString());
                    antrop.GrasaGram = Decimal.Parse(lector["GrasaGram"].ToString());
                    antrop.Grasakcal = Decimal.Parse(lector["Grasakcal"].ToString());
                    conexion.Close();
                    return antrop;
                }
                else
                {
                    conexion.Close();
                    return null;
                }
            }
            catch (SqlException)
            {
                conexion.Close();
                return null;
            }
        }

        public TOHabitoAlimentario ConsultarHabitoAlimentario(string cedula)
        {
            string qry = "select * from HabitosAlimentario where Cedula = " + cedula;
            SqlCommand buscar = new SqlCommand(qry, conexion);
            SqlDataReader lector;

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            lector = buscar.ExecuteReader();
            if (lector.HasRows)
            {
                lector.Read();
                TOHabitoAlimentario hab = new TOHabitoAlimentario(Int32.Parse(cedula), Int32.Parse(lector["ComidasDiarias"].ToString()),
                    Char.Parse(lector["Com_Hor_Dias"].ToString()), Int32.Parse(lector["Afuera_Express"].ToString()),
                    lector["ComidaFuera"].ToString(), lector["AzucarBebida"].ToString(), lector["ComidaElaborada_Con"].ToString(),
                    Decimal.Parse(lector["VasosAguaDiaria"].ToString()), Char.Parse(lector["Aderezos"].ToString()),
                    Char.Parse(lector["Fruta"].ToString()), Char.Parse(lector["Verdura"].ToString()),
                    Char.Parse(lector["Leche"].ToString()), Char.Parse(lector["Huevo"].ToString()),
                    Char.Parse(lector["Yogurt"].ToString()), Char.Parse(lector["Carne"].ToString()),
                    Char.Parse(lector["Queso"].ToString()), Char.Parse(lector["Aguacate"].ToString()),
                    Char.Parse(lector["Semillas"].ToString()));
                conexion.Close();
                return hab;
            }
            else
            {
                conexion.Close();
                return null;
            }
        }

        public TOPorciones TraerPorciones(string cedula)
        {
            string qry = "select * from Porciones where Cedula = " + cedula;
            SqlCommand cmd = new SqlCommand(qry, conexion);
            SqlDataReader lector;
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                lector = cmd.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    TOPorciones porcion = new TOPorciones(Int32.Parse(lector["Cedula"].ToString()), Decimal.Parse(lector["Leche"].ToString()),
                        Decimal.Parse(lector["Carne"].ToString()), Decimal.Parse(lector["Vegetales"].ToString()), Decimal.Parse(lector["Grasa"].ToString()),
                        Decimal.Parse(lector["Fruta"].ToString()), Decimal.Parse(lector["Azucar"].ToString()), Decimal.Parse(lector["Harina"].ToString()), Decimal.Parse(lector["Suplemento"].ToString()));
                    conexion.Close();
                    return porcion;
                }
                else
                {
                    conexion.Close();
                    return null;
                }
            }
            catch (SqlException)
            {
                conexion.Close();
                return null;
            }
        }

        public List<TOMedicamento> ListaSuplMed(object ced)
        {
            List<TOMedicamento> list = new List<TOMedicamento>();
            string qry = "Select * from Medic_Suplem where Cedula =" + ced;
            SqlCommand buscar = new SqlCommand(qry, conexion);
            SqlDataReader lector;

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            lector = buscar.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    list.Add(new TOMedicamento
                        (Int32.Parse(lector["Cedula"].ToString()),
                        lector["Nombre"].ToString(), lector["Motivo"].ToString(),
                    lector["Frecuencia"].ToString(), lector["Dosis"].ToString()));
                }
                conexion.Close();
                return list;
            }
            else
            {
                conexion.Close();
                return null;
            }
        }

        public List<TODistribucionPorciones> TraerDistribucion(string cedula)
        {
            List<TODistribucionPorciones> lista = new List<TODistribucionPorciones>();
            string qry = "select * from DistribucionPorcion where Cedula = " + cedula;
            SqlCommand cmd = new SqlCommand(qry, conexion);
            SqlDataReader lector;
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                lector = cmd.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        lista.Add(new TODistribucionPorciones(lector["Descripcion"].ToString(),
                        lector["TiempoComida"].ToString(), lector["Hora"].ToString(),Int32.Parse(lector["Cedula"].ToString())));
                    }
                    conexion.Close();
                    return lista;
                }
                else
                {
                    conexion.Close();
                    return null;
                }
            }
            catch (SqlException)
            {
                conexion.Close();
                return null;
            }
        }
    }
}
