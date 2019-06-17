using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;
using DAO;

namespace BL
{
    public class ManejadorExpediente
    {

        DAOClienteNutricion daoClienteNutricion = new DAOClienteNutricion();


        /**
                * Método publico que trae de la Base de datos la lista de los clientes 
                * @param ced, cedula del cliente
                */
        public List<ClienteNutricion> ListaClientes()
        {
            List<ClienteNutricion> ListaClient = new List<ClienteNutricion>();
            List<TOClienteNutricion> listaTO = daoClienteNutricion.ListarCliente();
            if (listaTO != null)
            {
                foreach (TOClienteNutricion cliente in listaTO)
                {
                    ListaClient.Add(new ClienteNutricion(cliente.Cedula, cliente.Correo,cliente.Nombre, cliente.Apellido1, cliente.Apellido2, cliente.Fecha_Nacimiento, cliente.Sexo, cliente.Estado_Civil,cliente.WhatsApp, cliente.Telefono, cliente.Residencia, cliente.Ocupacion, cliente.FechaIngreso));
                }
                return ListaClient;
            }
            else
            {
                return null;
            }
        }
    }
}
