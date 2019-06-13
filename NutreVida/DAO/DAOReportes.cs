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

        public String obtenerClasificacionIMC(int cedula) {

            String query = "select IMC from Antropometria where cedula = @ced";

            SqlCommand cmd = new SqlCommand(query, conexion);

            cmd.Parameters.AddWithValue("ced",cedula);

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            cmd.ExecuteNonQuery();


            if (conexion.State != ConnectionState.Closed)
            {
                conexion.Close();
            }

            


            return "";
        }

    }
}
