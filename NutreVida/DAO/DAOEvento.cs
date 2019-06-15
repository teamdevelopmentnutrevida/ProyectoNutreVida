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


        public Boolean gurdarEvento(TOEvento evento)
        {

            string query1 = "Insert into Evento values(@tit,@des,@horaInicio,@horaFina,@fecha);";

            SqlCommand cmd = new SqlCommand(query1, conexion);

            try
            {

                //Asignacion de parametros.
                cmd.Parameters.AddWithValue("@antec", evento.NombreEvento);
                cmd.Parameters.AddWithValue("@patol", evento.DecripcionEvento);
                cmd.Parameters.AddWithValue("@consLic", evento.HoraInicio);
                cmd.Parameters.AddWithValue("@fum", evento.HoraFin);
                cmd.Parameters.AddWithValue("@fechEx", evento.Fecha);

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


        public List<TOEvento> listaEventos() {
            List<TOEvento> lista = new List<TOEvento>();



            return lista;

        }
    }

}
