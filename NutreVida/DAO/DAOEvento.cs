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

            //try
            //{

                //Asignacion de parametros.
                cmd.Parameters.AddWithValue("@tit", evento.nombreEvento);
                cmd.Parameters.AddWithValue("@des", evento.decripcionEvento);
                cmd.Parameters.AddWithValue("@horaInicio", evento.horaInicio);
                cmd.Parameters.AddWithValue("@horaFina", evento.horaFin);
                cmd.Parameters.AddWithValue("@fecha", evento.fecha);

                //Validacion del estado de la conexion.
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                //Insercion del historial medico.
                cmd.ExecuteNonQuery();
                conexion.Close();

                return true;
            //}
            //catch (SqlException)
            //{
            //    return false;
            //}
        }


        public List<TOEvento> listaEventos(string fecha)
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
                        lista.Add(new TOEvento(lector["Titulo"].ToString(), lector["Descripcion"].ToString(), lector["HoraInicio"].ToString(), lector["HoraFin"].ToString(), lector["Fecha"].ToString()));
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


        public Boolean eliminarEvento(string nombre, string fecha) {
            try
            {
                SqlCommand eliminar = new SqlCommand("delete from Evento where Titulo = @nom and Fecha = @fec;", conexion);
                conexion.Open();
                eliminar.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }

}
