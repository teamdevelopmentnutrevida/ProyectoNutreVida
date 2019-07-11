using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BL
{

    /**
   * Clase MaejadorLogin, posee los metodos que permiten la busqueda de login
   * @author Diego
   */

    public class MaejadorLogin
	{
		DAOLogin daoLogin = new DAOLogin();

        /**
            *Este metodo se encarga de buscar el usuario mediante el cual se va a iniciar sesion
            *@param correo Es el correo del usuario
            *@param contras Es la contrasenna del usuario
            *@return Retorna un objeto de tipo BLLogin
            */
		public BLLogin buscarUsuario(string correo, string contras)
		{
			TOLogin usuarioTO = daoLogin.BuscarUsuario(correo, contras);
			if (usuarioTO == null)
			{
				return null;
			}
			return new BLLogin(usuarioTO.correo, usuarioTO.contras, usuarioTO.rol);
		}

		/**
		  *Este metodo se encarga de buscar el usuario mediante el cual se va a iniciar sesion
		  *@param correo Es el correo del usuario
		  *@param contras Es la contrasenna del usuario
		  *@return Retorna un objeto de tipo BLLogin
		  */
		public bool buscarUsuario(string correo)
		{
			TOLogin usuarioTO = daoLogin.BuscarUsuario(correo);
			if (usuarioTO == null)
			{
				return false;
			}
			return true;
		}

		/**
            *Este metodo se encarga de crear un nuevo usuario mediante el cual se va a iniciar sesion
            *@param correo Es el correo del usuario
            *@param contras Es la contrasenna del usuario
			*@param rol el rol del usuario
            *@return Retorna un objeto de tipo BLLogin
            */
		public bool CrearUsuario(string correo, string contras, string rol)
		{
			if (correo.Equals(""))
			{
				return false;
			}
			TOLogin login = new TOLogin(correo, contras, rol);
			return daoLogin.CrearUsuario(login);	
		}


		/**
            *Este metodo se encarga de modificar la contraseña de un usuario
            *@param correo Es el correo del usuario
            *@param contras Es la contrasenna del usuario
            *@return true si lo hace bien
            */
		public bool ModifUsuario(string correo, string contras)
		{
			if (correo.Equals(""))
			{
				return false;
			}
			return daoLogin.modificarContras(correo, contras);
		}








	}
}
