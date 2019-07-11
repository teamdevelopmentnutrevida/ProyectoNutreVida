using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
    public partial class OlvidoContrasena : System.Web.UI.Page
    {
        /**
        * Clase OlvidoContrasena, permite al usuario ingresar un correo electronico para proceder a cambiar sus credenciales de acceso al sistema
        * @author Diego
        */
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /**
        *El metodo se encarga de hacer validaciones necesarias para recuperar contrasenna
        * @param object, sender
        * @param EventArgs, e
        */
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            BL.ManjeadorOlvidoContrasenna mane = new ManjeadorOlvidoContrasenna();

            if (!mane.validarCorreoCorrecto(txtCorreo.Text))
            {
                lblIncorrecto.Text = "Usuario incorrecto";
            }
            else {
                mane.enviarCorreo(txtCorreo.Text);
                Response.Redirect("InicioSesion.aspx");
            }
        }
    }
}