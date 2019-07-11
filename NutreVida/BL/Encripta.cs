using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{


    /**
    * Clase Encripta, posee los metodos que permiten la encripción de contraseñas
    * @author Tannia
    */

    public class Encripta
    {

        /**
        * Método publico cuya función es encriptar un texto
        * @param string, originalPassword texto a ser encriptado
        */
        public string EncodePassword(string originalPassword)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(originalPassword);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /**
        * Método publico cuya función es desencriptar un texto
        * @param string, originalPassword texto a ser desencriptado
        * @param string, contra
        */
        public Boolean desEncode(string contraEncriptada, string contra)
        {
            Boolean coincide = false;
            string result = string.Empty;


            byte[] decryted = Convert.FromBase64String(contraEncriptada);
            result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            if (result.Equals(contra))
            {
                coincide = true;
            }
            else {
                coincide = false;
            }
            return coincide;
        } 

    }
}
