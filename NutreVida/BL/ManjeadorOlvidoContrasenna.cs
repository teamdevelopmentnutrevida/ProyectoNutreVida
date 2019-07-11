using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Net.Mail;
using System.Net;

namespace BL
{
    public class ManjeadorOlvidoContrasenna
    {
        /**
            *Este metodo se encarga de validar que el correo ingresado para cambiar la contrasenna si sea el correcto
            *@param correo Es el correo ingresado
            @return un boolean que dice si el correo es el correcto o no
            */
        public Boolean validarCorreoCorrecto(String correo) {
            DAOLogin login = new DAOLogin();

            return login.validarCorreoCorrecto(correo);
        }

        /**
            *Este metodo se encarga de crear la contrasenna temporal y enviarsela al correo inicado
            *@param correo Es el correo indicado                
            */
        public void enviarCorreo(String correo) {
            correo = "jandiego199847@gmail.com";
            //Crear contrasenna temporal
            int longitud = 7;
            Guid miGuid = Guid.NewGuid();
            string token = Convert.ToBase64String(miGuid.ToByteArray());
            token = token.Replace("=", "").Replace("+", "");
            token = token.Substring(0, longitud);

            //Definir instacia de la clase MailMessage
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(correo));
            email.From = new MailAddress("cambiocontrasenna@gmail.com	");
            email.Subject = "Asunto: Cambio de contraseña ";
            email.Body = "Su contraseña ha sido cambiada por: \n" + token;
            email.IsBodyHtml = false;
            email.Priority = MailPriority.Normal;

            //Definir instancia SMTP
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("cambiocontrasenna@gmail.com", "ElkyNutreVida123");
            smtp.EnableSsl = true;

            string output = null;

            //Se envia el correo
            try
            {
                smtp.Send(email);
                email.Dispose();
                output = "Corre electrónico fue enviado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                output = "Error enviando correo electrónico: " + ex.Message;
            }

            Console.WriteLine(output);

            cambiarClave(token);
        }

        /** 
            *Este metedo se encarga de cambiar la clave por la temporal
            *@param clave Es la clave temporal
            */
        private void cambiarClave(String clave) {
            DAOCambioDatosAdministrador cambio = new DAOCambioDatosAdministrador();
            cambio.cambiarClave(clave);
        }
    }
}
