using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace DAO
{
    public class DAOLogin
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);


        public TOLogin BuscarUsuario(String correo, String contras)
        {
            try
            {
                TOLogin usuario = new TOLogin();
                SqlCommand buscar = new SqlCommand("SELECT * FROM Login WHERE Nombre_usuario = @corrusu and Clave = @contus", conexion);
                buscar.Parameters.AddWithValue("@corrusu", correo);
                buscar.Parameters.AddWithValue("@contus", contras);
                conexion.Open();
                SqlDataReader lector = buscar.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        usuario.correo = lector.GetString(0);
                        usuario.contras = lector.GetString(1);
                        usuario.rol = lector.GetString(2);
                    }
                    lector.Close();
                }
                conexion.Close();
                return usuario;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Boolean validarCorreoCorrecto(String correo)
        {
            String query = "select count(Nombre_usuario) from Login where Nombre_usuario = @cor";

            SqlCommand cmd = new SqlCommand(query, conexion);

            cmd.Parameters.AddWithValue("@cor", correo);

            Boolean valid;

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }


            
            if (int.Parse(cmd.ExecuteScalar().ToString()) != 0)
            {
                valid = true;
            }
            else {
                valid = false;
            }


            if (conexion.State != ConnectionState.Closed)
            {
                conexion.Close();
            }

            return valid;
        }

    }
}
