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

	}
}
