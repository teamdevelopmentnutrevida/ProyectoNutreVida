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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            BL.ManjeadorOlvidoContrasenna mane = new ManjeadorOlvidoContrasenna();

            if (!mane.validarCorreoCorrecto(txtCorreo.Text))
            {
                lblIncorrecto.Text = "Usuario incorrecto";
            }
            else {
                lblIncorrecto.Text = "Usuario correcto! Se le enviará un correo con una contraseña temporal";
            }
        }
    }
}