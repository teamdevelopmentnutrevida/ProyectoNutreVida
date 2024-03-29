﻿using BL;
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
        /**
         * Clase InicioSesion, permite el ingreso de los credenciales para iniciar sesion en el sistema
         * @author Diego
       */
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /**
        *Este metodo se encarga de hacer validaciones necesarias para el inicio de sesion
        * @param object, sender
        * @param EventArgs, e
        */
        protected void btnIngresar_Click(object sender, EventArgs e)
		{

			String correo = txtCorreo.Text;
			String contrasena = txtContras.Text;

			BLLogin usua = new MaejadorLogin().buscarUsuario(correo, contrasena);
			if (usua != null && !usua.correo.Equals(""))
			{
				Session["usuario"] = usua;
				if (usua.rol.Equals("admin"))
				{
					Response.Redirect("~/Reportes.aspx");
				}
				else if (usua.rol.Equals("nutricionista"))
				{
					Response.Redirect("~/Reportes.aspx");
				}

			}
			else
			{
				lblIncorrecto.Text = "Usuario o contraseña incorrecto";
			}

		}

	}
}