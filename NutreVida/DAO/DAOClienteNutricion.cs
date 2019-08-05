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
    /**
   * Clase que permite la conexión con la base de datos para almacenar los datos del cliente
   * @author Yoselyn
   */
    public class DAOClienteNutricion
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        /**
        * Método público que permite la conexión con la base de datos para recuperar todos los clientes registrados
        * @return una lista de clientes.
        */
        public List<TOClienteNutricion> ListarCliente()
        {
            List<TOClienteNutricion> Lista = new List<TOClienteNutricion>();
            string qry = "Select * from Cliente_Nutricion c,Usuario u where c.Cedula = u.Cedula order by Estado desc";
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
                    Lista.Add(new TOClienteNutricion(Int32.Parse(lector["Cedula"].ToString()), lector["Correo"].ToString(), lector["Nombre"].ToString(), lector["Apellido1"].ToString(),
                        lector["Apellido2"].ToString(), DateTime.Parse(lector["Fecha_Nacimiento"].ToString()), Char.Parse(lector["Sexo"].ToString()),
                        lector["Estado_Civil"].ToString(), Char.Parse(lector["WhatsApp"].ToString()), Int32.Parse(lector["Telefono"].ToString()), lector["Residencia"].ToString(),
                        lector["Ocupacion"].ToString(), DateTime.Parse(lector["FechaIngreso"].ToString()), lector["Consultorio"].ToString(), Int32.Parse(lector["Estado"].ToString())));

                }
                conexion.Close();
                return Lista;
            }
            else
            {
                conexion.Close();
                return null;
            }
        }

        /**
       * Método público que permite la conexión con la base de datos para traer la información personal de un cliente de acuerdo a su numero de cedula
       * @param ced string
       * @return un cliente 
       */
        public TOClienteNutricion TraerInfoPersonal(string ced)
        {
            TOClienteNutricion cliente = new TOClienteNutricion();
            string qry = "Select * from Cliente_Nutricion c,Usuario u where c.Cedula = u.Cedula AND u.Cedula = " + ced;
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

        /**
       * Método público que permite la conexión con la base de datos para deshabilitar el estado de un paciente
       * @param ced string
       * @return un parámetro de tipo booleano que devuelve un true si se cambió en la base o flase si no se cambió.
       */
        public bool DeshabilitarCliente(string ced)
        {
            string query = " UPDATE Cliente_Nutricion SET Estado = 0 WHERE Cedula = " + ced;
            SqlCommand cmd = new SqlCommand(query, conexion);
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                cmd.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
       * Método público que permite la conexión con la base de datos para habilitar el estado de un paciente
       * @param ced string
       * @return un parámetro de tipo booleano que devuelve un true si se cambió en la base o flase si no se cambió.
       */
        public bool HabilitarCliente(string ced)
        {
            string query = " UPDATE Cliente_Nutricion SET Estado = 1 WHERE Cedula = " + ced;
            SqlCommand cmd = new SqlCommand(query, conexion);
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                cmd.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }


        }

        /**
      * Método público que permite la conexión con la base de datos para traer un historial metido de acuerdo al número de cedula de un paciente
      * @param ced object
      * @return un parámetro de tipo TOHistorialMedico
      */
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
                    hm.UltimoExamen = DateTime.Parse(lector["Fecha_Ult_Exm"].ToString());
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

        /**
      * Método público que permite la conexión con la base de datos para traer un historial metido de acuerdo al número de cedula de un paciente
      * @param ced object
      * @return un parámetro de tipo TOHistorialMedico
      */
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


        /**
     * Método público que permite la conexión con la base de datos para traer un antopometria de acuerdo al número de cedula de un paciente
     * @param cedula string
     * @return un parámetro de tipo TOAntropometria
     */
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


        /**
    * Método público que permite la conexión con la base de datos para traer un habito alimentario de acuerdo al número de cedula de un paciente
    * @param cedula string
    * @return un parámetro de tipo TOHabitoAlimentario
    */
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

        /**
   * Método público que permite la conexión con la base de datos para traer una porcion de acuerdo al número de cedula de un paciente
   * @param cedula string
   * @return un parámetro de tipo TOPorciones
   */
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

        /**
   * Método público que permite la conexión con la base de datos para traer una lista de los suplementora alimenticios de acuerdo al número de cedula de un paciente
   * @param cedula object
   * @return un parámetro de tipo List<TOMedicamento>
   */
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

        /**
  * Método público que permite la conexión con la base de datos para traer una lista de la distribución de acuerdo al número de cedula de un paciente
  * @param cedula string
  * @return un parámetro de tipo List<TODistribucionPorciones>
  */
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
                        lector["TiempoComida"].ToString(), lector["Hora"].ToString(), Int32.Parse(lector["Cedula"].ToString())));
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


        /**
          * Método público que permite la conexión con la base de datos para modificar datos del expediente
          * @param cedula string
          * @return un parámetro de tipo bool, que indica si se realizo correctamente la accion o no
          */
        public bool ModificarExpediente(TOClienteNutricion clienteModif, TOHistorialMedico histModif, TOHabitoAlimentario habModif, List<TORecordatorio24H> listRecordModif, TOAntropometria antropModif, TOPorciones porcModif, List<TODistribucionPorciones> distrModif)
        {
            string query = "UPDATE Cliente_Nutricion  SET Fecha_Nacimiento = '"+clienteModif.Fecha_Nacimiento.ToString("yyyy-MM-dd") + "', "+
                "Sexo = '"+clienteModif.Sexo+"', Estado_Civil = '"+clienteModif.Estado_Civil+"',"+
                " Residencia = '"+clienteModif.Residencia+"', Ocupacion = '"+clienteModif.Ocupacion+"',"+
                " FechaIngreso = '"+clienteModif.FechaIngreso.ToString("yyyy-MM-dd") + "', Consultorio = '"+clienteModif.Consultorio+"' WHERE Cedula = "+clienteModif.Cedula+"; ";

            string query2 = "UPDATE Historial_Medico SET Antecedentes_Fam = '"+histModif.Antecedentes+"', Patologias = '"+histModif.Patologias+"',"+
                "Cosumo_Licor = "+histModif.ConsumeLicor+", Fumador = "+histModif.Fuma+", FrecFumar = '"+histModif.FrecFuma+"',"+
                "FrecTomar = '"+histModif.FrecLicor+"', ActividadFisica = '"+histModif.ActividadFisica+"',"+
                "Fecha_Ult_Exm = '" + histModif.UltimoExamen.ToString("yyyy-MM-dd") + "' WHERE Cedula =" + histModif.Cedula+";";

            string query3 = "UPDATE HabitosAlimentario SET ComidasDiarias = "+habModif.ComidaDiaria+","+
                "Com_Hor_Dias = '"+habModif.ComidaHorasDia+"', Afuera_Express = "+habModif.AfueraExpress+","+
                "ComidaFuera = '"+habModif.ComidaFuera+"', AzucarBebida = '"+habModif.AzucarBebida+"',"+
                "ComidaElaborada_Con = '"+habModif.ComidaElaboradCon+"', VasosAguaDiaria = "+habModif.AguaDiaria+", "+
                "Aderezos = '"+habModif.Aderezos+"', Fruta = '"+habModif.Fruta+"', Verdura = '"+habModif.Verdura+"', Leche = '"+habModif.Leche+"', "+
                "Huevo = '"+habModif.Huevo+"', Yogurt = '"+habModif.Yogurt+"', Carne = '"+habModif.Carne+"', Queso = '"+habModif.Queso+"',"+
                "Aguacate = '"+habModif.Aguacate+"', Semillas = '"+habModif.Semillas+"' WHERE Cedula = "+habModif.Cedula+";";

            string query8 = "UPDATE Usuario SET Correo = '"+clienteModif.Correo+"', Nombre = '"+clienteModif.Nombre+"', WhatsApp = '"+clienteModif.WhatsApp+"',"+
                    "Telefono = '"+clienteModif.Telefono+"', Apellido1 = '"+clienteModif.Apellido1+"', Apellido2 = '"+clienteModif.Apellido2+"'"+
                    "WHERE Cedula = "+clienteModif.Cedula+"; ";

            SqlCommand cmd = new SqlCommand(query, conexion);
            SqlCommand cmd2 = new SqlCommand(query2, conexion);
            SqlCommand cmd3 = new SqlCommand(query3, conexion);
            SqlCommand cmd8 = new SqlCommand(query8, conexion);
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd8.ExecuteNonQuery();
                conexion.Close();

                foreach (TORecordatorio24H R in listRecordModif)
                {
                    string query4 = "UPDATE Recordat24H SET Hora = '" + R.Hora+"', Descripcion = '"+R.Descripcion+"' WHERE Cedula = "+R.Cedula+" and TiempoComida = '"+R.TiempoComida+"'; ";
                    SqlCommand cmd4 = new SqlCommand(query4, conexion);
                    conexion.Open();
                    cmd4.ExecuteNonQuery();
                    conexion.Close();
                    
                    
                }

                string query5 = "UPDATE Antropometria SET Talla = "+antropModif.Talla+", "+
                "PesoIdeal = "+antropModif.PesoIdeal+", Edad = "+antropModif.Edad+ ", " +
                "PMB = "+antropModif.PMB+", Peso = "+antropModif.Peso+", PesoMaxTeoria = "+antropModif.PesoMaxTeoria+", " +
                "IMC = "+antropModif.IMC+", PorcGrasaAnalizador = "+antropModif.PorcGrasaAnalizador+ ", " +
                "PorcGr_Bascula = "+antropModif.PorcGr_Bascula+", GB_BI = "+antropModif.GB_BI+", GB_BD = "+antropModif.GB_BD+ ", " +
                "GB_PI = "+antropModif.GB_PI+", GB_PD = "+antropModif.GB_PD+", GB_Tronco = "+antropModif.GB_Tronco+ ", " +
                "AguaCorporal = "+antropModif.AguaCorporal+", MasaOsea = "+antropModif.MasaOsea+", Complexion = "+antropModif.Complexión+ "," +
                "Edad_Metabolica = "+antropModif.EdadMetabolica+", Cintura = "+antropModif.Cintura+", Abdomen = "+antropModif.Abdomen+ "," +
                "Cadera = "+antropModif.Cadera+ ", Muslo_Der = " + antropModif.MusloDer+ ", Muslo_Izq = " + antropModif.MusloIzq+ "," +
                "CBM = "+antropModif.CBM+", CircunfMunneca = "+antropModif.CircunfMunneca+", PorcentGViceral = "+antropModif.PorcentGViceral+ "," +
                "PorcentMusculo = "+antropModif.PorcentMusculo+", PM_BI = "+antropModif.PM_BI+", PM_PD = "+antropModif.PM_PD+ ", " +
                "PM_BD = "+antropModif.PM_BD+", PM_PI = "+antropModif.PM_PI+", PM_Troco = "+antropModif.PM_Tronco+", Observaciones = '"+antropModif.Observaciones+ "'," +
                "GEB = "+antropModif.GEB+", GET = "+antropModif.GET+", CHOPorc = "+antropModif.CHOPorc+", CHOGram = "+antropModif.CHOGram+ "," +
                "CHOkcal = "+antropModif.CHO_kcal+", ProteinaPorc = "+antropModif.ProteinaPorc+", ProteinaGram = "+antropModif.ProteinaGram+ "," +
                "Proteinakcal = "+antropModif.Proteinakcal+", GrasaPorc = "+antropModif.GrasaPorc+", GrasaGram = "+antropModif.GrasaGram+ ", " +
                "Grasakcal = "+antropModif.Grasakcal+" WHERE Cedula = "+antropModif.Cedula+"; ";

                string query6 = "UPDATE  Porciones SET Leche = "+porcModif.Leche+", Carne = "+porcModif.Carne+", Vegetales = "+porcModif.Vegetales+","+
                "Grasa = "+porcModif.Grasa+", Fruta = "+porcModif.Fruta+", Azucar = "+porcModif.Azucar+", Harina = "+porcModif.Harina+","+
                "Suplemento = "+porcModif.Suplemento+" WHERE Cedula = "+porcModif.Cedula+"; ";

                SqlCommand cmd5 = new SqlCommand(query5, conexion);
                SqlCommand cmd6 = new SqlCommand(query6, conexion);
                conexion.Open();
                cmd5.ExecuteNonQuery();
                cmd6.ExecuteNonQuery();
                conexion.Close();

                foreach (TODistribucionPorciones D in distrModif)
                {
                    string query7 = "UPDATE  DistribucionPorcion SET Hora = '"+D.Hora+"', Descripcion = '"+D.Descripcion+"' WHERE Cedula = "+D.Cedula+" and TiempoComida = '"+D.TiempoComida+"'; ";
                    SqlCommand cmd7 = new SqlCommand(query7, conexion);
                    conexion.Open();
                    cmd7.ExecuteNonQuery();
                    conexion.Close();


                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
