using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BL
{
	public class MaejadorLogin
	{
		DAOLogin daoLogin = new DAOLogin();

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
