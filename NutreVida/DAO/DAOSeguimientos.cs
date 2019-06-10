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

        public bool GuardarSeguimientoMensual(TOSeguimientoNutricional seg, List<TOSeguimientoRecordat24H> lisSeg, TOSeguimientoAntrop segAnt)
        {
            throw new NotImplementedException();
        }
    }
}
