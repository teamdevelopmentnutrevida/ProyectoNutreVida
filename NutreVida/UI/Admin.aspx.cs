using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace UI
{
	public partial class Admin : System.Web.UI.Page
	{
		BL.MaejadorLogin usuarioLogin = new MaejadorLogin();

		protected void Page_Load(object sender, EventArgs e)
		{
			Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

			if (new ControlSeguridad().validarNutri() == true)
			{
				Response.Redirect("~/InicioSesion.aspx");

			}
			BLLogin usua = (BLLogin)Session["usuario"];
			lbUsuario.Text = usua.correo;
		}

		protected void btnCambiar_Click(object sender, EventArgs e)
		{
			BLLogin usuar = (BLLogin)Session["usuario"];
			string correo = usuar.correo;
			string contrActual = usuar.contras;
			string contras = "";
			contras = txtcontraAct.Text;
			string contraNueva = txtContra.Text;

			if (usuarioLogin.buscarUsuario(correo, contras) == null)
			{
				Page.ClientScript.RegisterStartupScript(this.GetType(), "mensajeError", "mensajeError('error', 'Datos incorrectos', 'Contraseña actual incorrecta')", true);
				return;
			}
			else {

				usuarioLogin.ModifUsuario(correo, contraNueva);
				Page.ClientScript.RegisterStartupScript(this.GetType(), "mensajeError", "mensajeError('success', 'Bien', 'Contraseña modificada correctamente')", true);
			}
		}

		protected void btnGuardar_Click(object sender, EventArgs e)
		{
			string correo = "";
			string contras = "";
			string rol = "nutricionista";

			if (string.IsNullOrEmpty(txtCorr.Text))
			{
				Page.ClientScript.RegisterStartupScript(this.GetType(), "mensajeError", "mensajeError('error', 'Datos faltantes', 'Ingrese un correo electrónico')", true);
				return;
			}
			correo = txtCorr.Text;

			if (usuarioLogin.buscarUsuario(correo))
			{
				Page.ClientScript.RegisterStartupScript(this.GetType(), "mensajeError", "mensajeError('error', 'Datos incorrectos', 'Ya existe un usuario con el correo ingresado')", true);
				return;
			}

			contras = txtContUsu.Text;
			usuarioLogin.CrearUsuario(correo,contras,rol);

			Page.ClientScript.RegisterStartupScript(this.GetType(), "mensajeError", "mensajeError('success', 'Bien', 'Nuevo usuario creado correctamente')", true);
			foreach (Control c in Page.Form.Controls)
			{

				if (c is TextBox)
				{
					var tmpb = c as TextBox;
					tmpb.Text = string.Empty;
				}
			}
		}
	}
}