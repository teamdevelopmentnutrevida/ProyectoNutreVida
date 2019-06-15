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
    public class DAOEvento
    {

        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);


        public Boolean guardarEvento(TOEvento evento)
        {

            string query1 = "Insert into Evento values(@tit,@des,@horaInicio,@horaFina,@fecha);";

            SqlCommand cmd = new SqlCommand(query1, conexion);

            try
            {

                //Asignacion de parametros.
                cmd.Parameters.AddWithValue("@antec", evento.nombreEvento);
                cmd.Parameters.AddWithValue("@patol", evento.decripcionEvento);
                cmd.Parameters.AddWithValue("@consLic", evento.horaInicio);
                cmd.Parameters.AddWithValue("@fum", evento.horaFin);
                cmd.Parameters.AddWithValue("@fechEx", evento.fecha);

                //Validacion del estado de la conexion.
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                //Insercion del historial medico.
                cmd.ExecuteNonQuery();
                conexion.Close();

                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }


        public List<TOEvento> listaEventos()
        {
            List<TOEvento> lista = new List<TOEvento>();


            try
            {
                SqlCommand buscar = new SqlCommand("SELECT * FROM Evento", conexion);
                conexion.Open();
                SqlDataReader lector = buscar.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        lista.Add(new TOEvento(lector.GetString(0), lector.GetString(1), lector.GetString(2), lector.GetString(3), lector.GetString(4)));
                    }

                    lector.Close();
                }
                conexion.Close();

                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }

}
