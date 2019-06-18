using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BL
{
    public class ManjeadorOlvidoContrasenna
    {
        public Boolean validarCorreoCorrecto(String correo) {
            DAOLogin login = new DAOLogin();

            return login.validarCorreoCorrecto(correo);
        }
    }
}
