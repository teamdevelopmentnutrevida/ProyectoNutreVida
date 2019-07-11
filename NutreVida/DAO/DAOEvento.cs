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
        public Boolean guardarEvento(TOEvento evento)
        {

            string query1 = "";

            SqlCommand cmd;

            if (!buscarEvento(evento.id))
            {

                query1 = "Insert into Evento values(@tit,@des,@fechaInicio,@fechaFina,@id);";

            }
            else
            {
                query1 = "update Evento set Titulo = @tit, Descripcion = @des, FechaInicio = @fechaInicio, FechaFin = @fechaFina where IDEvento = @id";
            }

            cmd = new SqlCommand(query1, conexion);

            //Asignacion de parametros.
            cmd.Parameters.AddWithValue("@tit", evento.text);
            cmd.Parameters.AddWithValue("@id", evento.id);
            cmd.Parameters.AddWithValue("@des", evento.details);
            cmd.Parameters.AddWithValue("@fechaInicio", evento.start_date);
            cmd.Parameters.AddWithValue("@fechaFina", evento.end_date);

            try
            {
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

        public bool buscarEvento(string id)
        {
            string query1 = "select * from Evento where IDEvento = @id;";

            SqlCommand cmd = new SqlCommand(query1, conexion);

            bool existe = false;
            try
            {

                //Asignacion de parametros.
                cmd.Parameters.AddWithValue("@id", id);

                //Validacion del estado de la conexion.
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }

                string cant = cmd.ExecuteScalar() + "";

                if (!cant.Equals(""))
                {
                    existe = true;
                }

                conexion.Close();

                return existe;
            }
            catch (SqlException)
            {
                return false;
            }
        }

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
                        fechaInicio = fechaInicio.AddHours(-6);
                        String stringFechaInicio = fechaInicio.ToString("yyyy-MM-dd HH:mm:ss");

                        DateTime FechaFin = DateTime.Parse(lector["FechaFin"].ToString());
                        FechaFin = FechaFin.AddHours(-6);
                        String stringFechaFin = FechaFin.ToString("yyyy-MM-dd HH:mm:ss");

                        lista.Add(new TOEvento(lector["IDEvento"].ToString(), stringFechaInicio, stringFechaFin, lector["Titulo"].ToString(), lector["Descripcion"].ToString()));
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
        public Boolean eliminarEvento(string id)
        {
            try
            {
                SqlCommand eliminar = new SqlCommand("delete from Evento where IDEvento = @id;", conexion);
                eliminar.Parameters.AddWithValue("@id", id);
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
        public void modificarEvento(string nombre, string descripcion, string horaInicio, string horaFin, string fecha)
        {
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
