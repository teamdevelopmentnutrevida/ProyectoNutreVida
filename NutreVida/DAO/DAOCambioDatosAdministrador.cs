using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{

    /**
   * Clase que permite la conexión con la base de datos para cambiar los datos dle administrador.
   * @author Cristel
   */
    public class DAOCambioDatosAdministrador
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        /**
       * Método público que permite la conexión con la base de datos para almacenar los nuevos datos del administrador
       * @param clave string
       */
        public void cambiarClave(String clave) {
            String query = "update Login set clave = @clave";

            SqlCommand cmd = new SqlCommand(query, conexion);

            cmd.Parameters.AddWithValue("@clave",clave);

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            cmd.ExecuteScalar();


            if (conexion.State != ConnectionState.Closed)
            {
                conexion.Close();
            }
        }
    }
}
