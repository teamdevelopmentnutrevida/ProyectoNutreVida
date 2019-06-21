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
                    ListaClient.Add(new ClienteNutricion(cliente.Cedula, cliente.Correo,cliente.Nombre, cliente.Apellido1, cliente.Apellido2, cliente.Fecha_Nacimiento, cliente.Sexo, cliente.Estado_Civil,cliente.WhatsApp, cliente.Telefono, cliente.Residencia, cliente.Ocupacion, cliente.FechaIngreso,cliente.Consultorio));
                }
                return ListaClient;
            }
            else
            {
                return null;
            }
        }

        public ClienteNutricion TraerInformación(string ced)
        {
            ClienteNutricion cliente = new ClienteNutricion();
            TOClienteNutricion TOcliente = daoClienteNutricion.TraerInfoPersonal(ced);
            if (TOcliente != null) {
                cliente.Cedula = TOcliente.Cedula;
                cliente.Correo = TOcliente.Correo;
                cliente.Nombre = TOcliente.Nombre;
                cliente.Apellido1 = TOcliente.Apellido1;
                cliente.Apellido2 = TOcliente.Apellido2;
                cliente.Fecha_Nacimiento = TOcliente.Fecha_Nacimiento;
                cliente.Sexo = TOcliente.Sexo;
                cliente.Estado_Civil = TOcliente.Estado_Civil;
                cliente.WhatsApp = TOcliente.WhatsApp;
                cliente.Telefono = TOcliente.Telefono;
                cliente.Residencia = TOcliente.Residencia;
                cliente.Ocupacion = TOcliente.Ocupacion;
                cliente.FechaIngreso = TOcliente.FechaIngreso;
                cliente.Consultorio = TOcliente.Consultorio;

                return cliente;
            }
            else
            {
                return null;
            }
        }
    }
}
