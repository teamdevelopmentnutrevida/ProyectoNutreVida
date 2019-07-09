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
   * Clase que permite la conexión con la base de datos para los objetos de tipo Evento.
   * @author Tannia
   */
    public class DAOEvento
    {

        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        /**
        * Método público que permite la conexión con la base de datos para almacenar los eventos
        * @param evento TOEvento
        * @return un parámetro de tipo booleano que devuelve un true si se guradó en la base o flase si no se guardó.
        */
        //public Boolean guardarEvento(TOEvento evento)
        //{

        //    string query1 = "Insert into Evento values(@tit,@des,@horaInicio,@horaFina,@fecha);";

        //    SqlCommand cmd = new SqlCommand(query1, conexion);

        //    try
        //    {

        //        //Asignacion de parametros.
        //        cmd.Parameters.AddWithValue("@tit", evento.nombreEvento);
        //        cmd.Parameters.AddWithValue("@des", evento.decripcionEvento);
        //        cmd.Parameters.AddWithValue("@horaInicio", evento.horaInicio);
        //        cmd.Parameters.AddWithValue("@horaFina", evento.horaFin);
        //        cmd.Parameters.AddWithValue("@fecha", evento.fecha);

        //        //Validacion del estado de la conexion.
        //        if (conexion.State != ConnectionState.Open)
        //        {
        //            conexion.Open();
        //        }

        //        //Insercion del historial medico.
        //        cmd.ExecuteNonQuery();
        //        conexion.Close();

        //        return true;
        //    }
        //    catch (SqlException)
        //    {
        //        return false;
        //    }
        //}

        /**
        * Método público que permite recuperar de la base de datos la lista de eventos
        * @param fecha String
        * @return una lista de eventos
        */
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
                        DateTime fechaInicio = DateTime.Parse(lector["FechaInicio"].ToString());
                        String stringFechaInicio = fechaInicio.ToString("yyyy-MM-dd HH:mm:ss");

                        DateTime FechaFin = DateTime.Parse(lector["FechaFin"].ToString());
                        String stringFechaFin = FechaFin.ToString("yyyy-MM-dd HH:mm:ss");

                        lista.Add(new TOEvento(int.Parse(lector["IDEvento"].ToString()), stringFechaInicio, stringFechaFin, lector["Titulo"].ToString(), lector["Descripcion"].ToString()));
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

        /**
        * Método público que permite eliminar de la base de datos un determinado evento de acuerdo a las parámetros que recibe
        * @param nombre String
        * @param fecha String
        * @return un parámetro de tipo booleano que devuelve un true si se eliminó en la base o false si no se eliminó
        */
        public Boolean eliminarEvento(string nombre, string fecha) {
            try
            {
            SqlCommand eliminar = new SqlCommand("delete from Evento where Titulo = @nom and Fecha = @fec;", conexion);
            eliminar.Parameters.AddWithValue("@nom", nombre);
            eliminar.Parameters.AddWithValue("@fec", fecha);
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

        /**
        * Método público que permite modificar un elemento de la base de datos de acuerdo a ciertos parámetros
        * @param nombre String
        * @param descripción String
        * @param horaInicio String
        * @param horaFin String
        * @param fecha String
        */
        public void modificarEvento(string nombre, string descripcion, string horaInicio, string horaFin, string fecha) {
            try
            {
                SqlCommand eliminar = new SqlCommand("UPDATE Evento set Titulo = @nom, Descripcion = @dec, HoraInicio = @horaInicio, HoraFin = @horaFin, Fecha = @fecha where Titulo = @nom  AND fecha = @fecha;", conexion);
                eliminar.Parameters.AddWithValue("@nom", nombre);
                eliminar.Parameters.AddWithValue("@fec", fecha);
                conexion.Open();
                eliminar.ExecuteNonQuery();
                conexion.Close();
                
            }
            catch (Exception)
            {

            }
        }


    }

}
