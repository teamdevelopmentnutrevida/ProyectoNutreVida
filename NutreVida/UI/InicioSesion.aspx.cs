using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

			//String usuario = txtNombre.Text;
			//String contra = txtContra.Text;

			//BLUsuario usua = new ManejadorUsuario().buscarUsuario(usuario, contra);
			//if (usua.correo_usuario != null && !usua.correo_usuario.Equals(""))
			//{
			//	Session["usuario"] = usua;
			//	if (usua.rol.Equals("cocina"))
			//	{
			//		Response.Redirect("~/ModuloCocina/Cocina.aspx");
			//	}
			//	else if (usua.rol.Equals("admin"))
			//	{
			//		Response.Redirect("~/Administrador/PaginaPrincipalAdmin.aspx");
			//	}

			//}
			//else
			//{
			//	lblIncorrecto.Text = "Usuario o contraseña incorrecto";
			//}

		}

	
	}
}