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
    public class DAOClienteNutricion
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        public List<TOClienteNutricion> ListarCliente()
        {
            List<TOClienteNutricion> ListaMedidas = new List<TOClienteNutricion>();
            string qry = "Select * from Cliente_Nutricion c,Usuario u where c.Cedula = u.Cedula order by Apellido1";
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
                    ListaMedidas.Add(new TOClienteNutricion(Int32.Parse(lector["Cedula"].ToString()), lector["Correo"].ToString(), lector["Nombre"].ToString(), lector["Apellido1"].ToString(),
                        lector["Apellido2"].ToString(), lector["Fecha_Nacimiento"].ToString(), Char.Parse(lector["Sexo"].ToString()),
                        lector["Estado_Civil"].ToString(), Char.Parse(lector["WhatsApp"].ToString()), Int32.Parse(lector["Telefono"].ToString()), lector["Residencia"].ToString(), lector["Ocupacion"].ToString(), DateTime.Parse(lector["FechaIngreso"].ToString())));

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
    }
}
