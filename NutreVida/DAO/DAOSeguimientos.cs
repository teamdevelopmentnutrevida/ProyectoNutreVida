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
    public class DAOSeguimientos
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);
        public bool AgregarSeguimientoSemanal(TOSeguimientoSemanal tOSeguimientoSemanal)
        {
            string query = "Insert into SeguimientoSemanal values(@sesion,@fech,@peso,@orej,@ejercic,@ced);";
            SqlCommand cmd = new SqlCommand(query, conexion);
            string query2 = "Select max(Sesion) as 'Sesion' from SeguimientoSemanal where Cedula = " + tOSeguimientoSemanal.Cedula;
            SqlCommand cmd2 = new SqlCommand(query2, conexion);
            SqlDataReader lector;
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                int ses = 0;
                lector = cmd2.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    string t = lector["Sesion"].ToString();
                    if (lector["Sesion"].ToString().Equals(""))
                    {
                        ses = 1;
                        conexion.Close();
                    }
                    else
                    {
                        ses = Int32.Parse(lector["Sesion"].ToString()) + 1;
                        conexion.Close();
                    }
                }
                else
                {
                    conexion.Close();
                }

                //Asignacion de parametros.
                cmd.Parameters.AddWithValue("@sesion", ses);
                cmd.Parameters.AddWithValue("@fech", tOSeguimientoSemanal.Fecha);
                cmd.Parameters.AddWithValue("@peso", tOSeguimientoSemanal.Peso);
                cmd.Parameters.AddWithValue("@orej", tOSeguimientoSemanal.Oreja);
                cmd.Parameters.AddWithValue("@ejercic", tOSeguimientoSemanal.Ejercicio);
                cmd.Parameters.AddWithValue("@ced", tOSeguimientoSemanal.Cedula);
                //Validacion del estado de la conexion.
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                cmd.ExecuteNonQuery();
                conexion.Close();
                return true;

            }
            catch (SqlException)
            {
                return false;
            }
        }

        public List<TOSeguimientoSemanal> ListarSeguimSemanal(int cedula)
        {
            List<TOSeguimientoSemanal> ListaMedidas = new List<TOSeguimientoSemanal>();
            string qry = "Select * from SeguimientoSemanal where Cedula = " + cedula;
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
                    ListaMedidas.Add(new TOSeguimientoSemanal(Int32.Parse(lector["Sesion"].ToString()), DateTime.Parse(lector["FechaSesion"].ToString()),
                    decimal.Parse(lector["Peso"].ToString()), lector["Oreja"].ToString(), lector["Ejercicio"].ToString(), Int32.Parse(lector["Cedula"].ToString())));

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

        public bool GuardarSeguimientoMensual(TOSeguimientoMensual seguimiento)
        {
            int idSeg = 0;
            String query1 = "Insert into SeguimNutricion values(@ced, @diaEj , @comE, @niv);";
            String query4 = "Select max(ID_Seguim) as 'IdSeg' from SeguimNutricion";
            SqlCommand cmd = new SqlCommand(query1, conexion);

            SqlCommand cmd4 = new SqlCommand(query4, conexion);
            SqlDataReader lector;
            try
            {

                cmd.Parameters.AddWithValue("@ced", seguimiento.nutri.Cedula);
                cmd.Parameters.AddWithValue("@diaEj", seguimiento.nutri.DiasEjercicio);
                cmd.Parameters.AddWithValue("@comE", seguimiento.nutri.ComidaExtra);
                cmd.Parameters.AddWithValue("@niv", seguimiento.nutri.NivelAnsiedad);

                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                cmd.ExecuteNonQuery();

                lector = cmd4.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    idSeg = Int32.Parse(lector["IdSeg"].ToString());
                    conexion.Close();
                }
                else
                {
                    conexion.Close();
                    return false;
                }

                if (seguimiento.record != null)
                {
                    List<TOSeguimientoRecordat24H> lisSeg = seguimiento.record;
                    foreach (TOSeguimientoRecordat24H seg24 in lisSeg)
                    {
                        String query2 = "Insert into SeguimRecordat24H values(@tiemp,@desc,@idS,@hor);";
                        SqlCommand cmd2 = new SqlCommand(query2, conexion);
                        cmd2.Parameters.AddWithValue("@tiemp", seg24.TiempoComida);
                        cmd2.Parameters.AddWithValue("@desc", seg24.Descripcion);
                        cmd2.Parameters.AddWithValue("@idS", idSeg);
                        cmd2.Parameters.AddWithValue("@hor", seg24.Hora);
                        conexion.Open();
                        cmd2.ExecuteNonQuery();
                        conexion.Close();
                    }

                }
                String query3 = "Insert into SeguimAntropom values(@idSe,@sEdad, @sTalla, @sCm, @sFecha_SA, @sPeso, @sIMC, @sEdadMetabolica," +
                    "@sAgua, @sMasaOsea, @sPorcGrasaAnalizador, @sPorcentGViceral, @sPorcGr_Bascula, @sGB_BI, @sGB_BD, @sGB_PI,@sGB_PD, @sGB_Tronco, "+
                    "@sPorcentMusculo, @sPM_BI, @sPM_bD, @sPM_PI, @sPM_PD, @sPM_Tronco, @sCircunfCintura, @sCadera, @sMusloIzq, @sMusloDer, @sBrazoIzq, @sBrazoDer, "+
                    "@sPesoIdeal, @sObservaciones)";
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                SqlCommand cmd3 = new SqlCommand(query3, conexion);
                TOSeguimientoAntrop segAnt = seguimiento.antrop;
                cmd3.Parameters.AddWithValue("@idSeg", idSeg);
                cmd3.Parameters.AddWithValue("@sEdad", segAnt.Edad);
                cmd3.Parameters.AddWithValue("@sTalla", segAnt.Talla);
                cmd3.Parameters.AddWithValue("@sCm", segAnt.CM);
                cmd3.Parameters.AddWithValue("@sFecha_SA", segAnt.Fecha_SA);
                cmd3.Parameters.AddWithValue("@sPeso", segAnt.Peso);
                cmd3.Parameters.AddWithValue("@sIMC", segAnt.IMC);
                cmd3.Parameters.AddWithValue("@sEdadMetabolica", segAnt.EdadMetabolica);
                cmd3.Parameters.AddWithValue("@sAgua", segAnt.Agua);
                cmd3.Parameters.AddWithValue("@sMasaOsea", segAnt.MasaOsea);
                cmd3.Parameters.AddWithValue("@sPorcGrasaAnalizador", segAnt.PorcGrasaAnalizador);
                cmd3.Parameters.AddWithValue("@sPorcentGViceral", segAnt.PorcentGViceral);
                cmd3.Parameters.AddWithValue("@sPorcGr_Bascula", segAnt.PorcGr_Bascula);
                cmd3.Parameters.AddWithValue("@sGB_BI", segAnt.GB_BI);
                cmd3.Parameters.AddWithValue("@sGB_BD", segAnt.GB_BD);
                cmd3.Parameters.AddWithValue("@sGB_PI", segAnt.GB_PI);
                cmd3.Parameters.AddWithValue("@sGB_PD", segAnt.GB_PD);
                cmd3.Parameters.AddWithValue("@sGB_Tronco", segAnt.GB_Tronco);
                cmd3.Parameters.AddWithValue("@sPorcentMusculo", segAnt.PorcentMusculo); 
                cmd3.Parameters.AddWithValue("@sPM_BI", segAnt.PM_BI); 
                cmd3.Parameters.AddWithValue("@sPM_BD", segAnt.PM_BD); 
                cmd3.Parameters.AddWithValue("@sPM_PI", segAnt.PM_PI); 
                cmd3.Parameters.AddWithValue("@sPM_PD", segAnt.PM_PD); 
                cmd3.Parameters.AddWithValue("@sPM_Tronco", segAnt.PM_Tronco); 
                cmd3.Parameters.AddWithValue("@sCircunfCintura", segAnt.CircunfCintura);
                cmd3.Parameters.AddWithValue("@sCadera", segAnt.Cadera);
                cmd3.Parameters.AddWithValue("@sMusloIzq", segAnt.MusloIzq);
                cmd3.Parameters.AddWithValue("@sMusloDer", segAnt.MusloDer);
                cmd3.Parameters.AddWithValue("@sBrazoIzq", segAnt.BrazoIzq);
                cmd3.Parameters.AddWithValue("@sBrazoDer", segAnt.BrazoDer);
                cmd3.Parameters.AddWithValue("@sPesoIdeal", segAnt.PesoIdeal);
                cmd3.Parameters.AddWithValue("@sObservaciones", segAnt.Observaciones);

                cmd3.ExecuteNonQuery();

                conexion.Close();

                return true;
            }
            catch (SqlException e)
            {
                Console.Write(e.ToString());
                return false;
            }
        }

        public List<TOSeguimientoMensual> ListarMensual(int cedula)
        {
            List<TOSeguimientoMensual> seguimMensual = new List<TOSeguimientoMensual>();
            string qry1 = "Select * from SeguimNutricion where Cedula = @ced";
            SqlCommand command = new SqlCommand(qry1, conexion);
            command.Parameters.AddWithValue("@ced", cedula);

            SqlDataReader lector;
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            lector = command.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int idSeg = Int32.Parse(lector["ID_Seguim"].ToString());
                    TOSeguimientoNutricional nut = new TOSeguimientoNutricional(lector["Cedula"].ToString(), lector["DiasEjercSem"].ToString(), lector["ComidaExtra"].ToString(), lector["NivelAnsiedad"].ToString());
                    TOSeguimientoMensual d = new TOSeguimientoMensual();
                    d.nutri = nut;
                    d.idSeg = idSeg;
                    seguimMensual.Add(d);
                }
                if (conexion.State != ConnectionState.Closed) { conexion.Close(); }
            }
            else
            {
                seguimMensual = null;
                if (conexion.State != ConnectionState.Closed) { conexion.Close(); }
            }
            if (seguimMensual != null)
            {
                foreach (TOSeguimientoMensual seg in seguimMensual)
                {
                    //Buscar la lista de los recordatorios de 24 horas del seguimiento nutricional 'nut'
                    string qry2 = "Select * from SeguimRecordat24H where ID_Seguimiento = @id";
                    SqlCommand cmd = new SqlCommand(qry2, conexion);

                    cmd.Parameters.AddWithValue("@id", seg.idSeg);

                    if (conexion.State != ConnectionState.Closed) { conexion.Close(); }
                    SqlDataReader lector2;
                    List<TOSeguimientoRecordat24H> nutrec = new List<TOSeguimientoRecordat24H>();
                    if (conexion.State != ConnectionState.Open) { conexion.Open(); }
                    lector2 = cmd.ExecuteReader();
                    if (lector2.HasRows)
                    {
                        while (lector2.Read())
                        {
                            nutrec.Add(new TOSeguimientoRecordat24H(int.Parse(lector2["ID_Seguimiento"].ToString()), lector2["TiempoComida"].ToString(), lector2["Hora"].ToString(), lector2["Descripcion"].ToString()));
                        }
                        seg.record = nutrec;
                        conexion.Close();
                    }
                    else { seg.record = null; }

                    //Seleccionar el seguimiento de antropometría del seguiemiento mensual
                    string qry3 = "Select * from SeguimAntropom where ID_Seguim =  @idAntr";
                    SqlCommand cmd3 = new SqlCommand(qry3, conexion);
                    cmd3.Parameters.AddWithValue("@idAntr", seg.idSeg);

                    if (conexion.State != ConnectionState.Closed) { conexion.Close(); }
                    SqlDataReader lector3;
                    TOSeguimientoAntrop nutantrop = null;
                    if (conexion.State != ConnectionState.Open) { conexion.Open(); }
                    lector3 = cmd3.ExecuteReader();
                    if (lector3.HasRows)
                    {
                        lector3.Read();
                        //while (lector2.Read())
                        //{
                        nutantrop = new TOSeguimientoAntrop(int.Parse(lector3["ID_SegAntrop"].ToString()), int.Parse(lector3["ID_Seguim"].ToString()),
                            decimal.Parse(lector3["Edad"].ToString()), decimal.Parse(lector3["Talla"].ToString()), decimal.Parse(lector3["CM"].ToString()),
                         DateTime.Parse(lector3["FechaSeg"].ToString()), decimal.Parse(lector3["Peso"].ToString()), decimal.Parse(lector3["IMC"].ToString()),
                         decimal.Parse(lector3["EdadMetab"].ToString()), decimal.Parse(lector3["Agua"].ToString()), decimal.Parse(lector3["MasaOsea"].ToString()),
                         decimal.Parse(lector3["PorcGrasaAnalizador"].ToString()), decimal.Parse(lector3["PGrasaViceral"].ToString()), 
                         decimal.Parse(lector3["PorcGr_Bascula"].ToString()),decimal.Parse(lector3["GB_BI"].ToString()), decimal.Parse(lector3["GB_BD"].ToString()),
                         decimal.Parse(lector3["GB_PI"].ToString()), decimal.Parse(lector3["GB_PD"].ToString()), decimal.Parse(lector3["GB_Tronco"].ToString()), 
                        decimal.Parse(lector3["PorcentMusculo"].ToString()), decimal.Parse(lector3["PM_BI"].ToString()), decimal.Parse(lector3["PM_BD"].ToString()),
                        decimal.Parse(lector3["PM_PI"].ToString()), decimal.Parse(lector3["PM_PD"].ToString()), decimal.Parse(lector3["PM_Troco"].ToString()),
                        decimal.Parse(lector3["CircunfCintura"].ToString()), decimal.Parse(lector3["Cadera"].ToString()), decimal.Parse(lector3["MusloIzq"].ToString()),
                        decimal.Parse(lector3["MusloDer"].ToString()), decimal.Parse(lector3["BrazoIzq"].ToString()), decimal.Parse(lector3["BrazoDer"].ToString()),
                        decimal.Parse(lector3["PesoIdeal"].ToString()), lector3["Observaciones"].ToString());
                        //}
                        seg.antrop = nutantrop;
                        conexion.Close();
                        seg.Fecha = nutantrop.Fecha_SA;
                    }
                    else { seg.antrop = null; }

                }
            }
            if (conexion.State != ConnectionState.Closed) { conexion.Close(); }
            return seguimMensual;
        }
    }
}
