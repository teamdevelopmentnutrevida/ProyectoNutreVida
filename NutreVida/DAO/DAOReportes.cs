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

        public String obtenerPromedioPesoEdad(int edad1, int edad2)
        {

            String query = "select AVG(a.Peso) from (select c.peso, Antropometria.Edad,Antropometria.cedula from (select c.*, row_number() over (partition by c.cedula order by c.fechaSesion desc) as rn from SeguimientoSemanal c) c,Antropometria where c.rn = 1 and c.cedula = Antropometria.cedula union SELECT a.peso,a.edad,a.cedula FROM Antropometria a FULL OUTER JOIN SeguimientoSemanal b ON a.cedula = b.cedula WHERE a.cedula IS NULL OR b.cedula IS NULL) a where  edad > @edad1 and edad < @edad2 ;";

            SqlCommand cmd = new SqlCommand(query, conexion);

            cmd.Parameters.AddWithValue("@edad1", edad1);

            cmd.Parameters.AddWithValue("@edad2", edad2);

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

        public int obtenerCantidadPersonasEdad(int edad1, int edad2)
        {

            String query = "select count(cedula) from Antropometria where edad > @edad1 and edad < @edad2 ";

            SqlCommand cmd = new SqlCommand(query, conexion);

            cmd.Parameters.AddWithValue("@edad1", edad1);

            cmd.Parameters.AddWithValue("@edad2", edad2);

            int cantidadPersonas;

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            cantidadPersonas =  int.Parse(cmd.ExecuteScalar().ToString());


            if (conexion.State != ConnectionState.Closed)
            {
                conexion.Close();
            }

            return cantidadPersonas;
        }

        public List<TOAntropometria> obtenerIMCEdades()
        {

            String query = "SELECT a.cedula,a.edad,a.Peso,a.talla FROM(SELECT c.peso,Antropometria.Edad,Antropometria.cedula,Antropometria.talla FROM(SELECT c.*, row_number()OVER(PARTITION BY c.cedula ORDER BY c.fechaSesion DESC)AS rn FROM SeguimientoSemanal c)c,Antropometria WHERE c.rn = 1AND c.cedula = Antropometria.cedula UNION SELECT a.peso,a.edad,a.cedula,a.talla FROM Antropometria a FULL OUTER JOIN SeguimientoSemanal b ON a.cedula =b.cedula WHERE a.cedula IS NULL OR b.cedula IS NULL)a";

            SqlCommand cmd = new SqlCommand(query, conexion);

            List<TOAntropometria> listAntrop = new List<TOAntropometria>();

            SqlDataReader reader;

            conexion.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows) {                

                while (reader.Read()) {

                    String cedul = reader["Cedula"].ToString();

                    if (!cedul.Equals(""))
                    {

                        int cedula = int.Parse(reader["Cedula"].ToString());
                        decimal talla = decimal.Parse(reader["Talla"].ToString());
                        decimal peso = decimal.Parse(reader["Peso"].ToString());
                        decimal edad = decimal.Parse(reader["Edad"].ToString());

                        TOAntropometria antrop = new TOAntropometria(cedula, talla, peso, edad);
                        listAntrop.Add(antrop);
                    }
                    
                }
                conexion.Close();
            }
            else
            {
                conexion.Close();
            }

            return listAntrop;
        }



    }
}
