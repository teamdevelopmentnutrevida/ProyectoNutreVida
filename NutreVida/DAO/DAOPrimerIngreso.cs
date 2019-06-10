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
    public class DAOPrimerIngreso
    {
        SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);

        public bool CrearUsuario(TOClienteNutricion tOCliente)
        {
            //falta en la parte grafica ape1,ape2,estadoCivil
            //rol se quema
            //ingres se toma del sistema
            String query1 = "Insert into Usuario values(@ced,@cor,@nomb,@whats,@tel,@ape1,@ape2,@rol);";
            String query2 = "Insert into Cliente_Nutricion values(@fechNac,@sexo,@estCiv,@resid,@ocup,@ced,@ingres);";

            SqlCommand cmd = new SqlCommand(query1, conexion);
            SqlCommand cmd2 = new SqlCommand(query2, conexion);

            try
            {
                //Cliente padre
                //ced, fecha, tel, obs, mens

                cmd.Parameters.AddWithValue("@ced", tOCliente.Cedula);
                cmd.Parameters.AddWithValue("@cor", "Sin Correo");
                cmd.Parameters.AddWithValue("@nomb", tOCliente.Nombre);
                cmd2.Parameters.AddWithValue("@whats", tOCliente.WhatsApp);
                cmd2.Parameters.AddWithValue("@tel", tOCliente.Telefono);
                cmd.Parameters.AddWithValue("@ape1", tOCliente.Apellido1);
                cmd.Parameters.AddWithValue("@ape2", tOCliente.Apellido2);
                cmd.Parameters.AddWithValue("@rol", "clienteNutri");


                cmd2.Parameters.AddWithValue("@fechNac", tOCliente.Fecha_Nacimiento);
                cmd2.Parameters.AddWithValue("@sexo", tOCliente.Sexo);
                cmd2.Parameters.AddWithValue("@estCiv", tOCliente.Estado_Civil);                
                cmd2.Parameters.AddWithValue("@resid", tOCliente.Residencia);
                cmd2.Parameters.AddWithValue("@ocup", tOCliente.Ocupacion);
                cmd2.Parameters.AddWithValue("@ced", tOCliente.Cedula);
                cmd2.Parameters.AddWithValue("@ingres", DateTime.Now);

                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                
                cmd.ExecuteNonQuery();
                
                cmd2.ExecuteNonQuery();

                conexion.Close();

                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
