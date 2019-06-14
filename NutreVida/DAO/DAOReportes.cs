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
    public class DAOReportes
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        public String obtenerPromedioPesoEdad(int edad1, int edad2) {

            String query = "select AVG(Peso) from Antropometria where edad >=@edad1 and edad <=@edad2";

            SqlCommand cmd = new SqlCommand(query, conexion);

            cmd.Parameters.AddWithValue("edad1", edad1);

            cmd.Parameters.AddWithValue("edad1", edad2);

            String promedioPeso;

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            promedioPeso = "" + cmd.ExecuteScalar();


            if (conexion.State != ConnectionState.Closed)
            {
                conexion.Close();
            }

            return promedioPeso;
        }

        

    }
}
