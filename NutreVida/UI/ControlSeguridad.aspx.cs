using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
	public partial class ControlSeguridad : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}
		public void salir()
		{
			Session["usuario"] = null;
		}

		public BLLogin usuario()
		{
			return (BLLogin)Session["usuario"];
		}

		public Boolean validarNutri()
		{
			if (usuario() == null || !usuario().rol.Equals("nutricionista") || usuario().rol.Equals(""))
			{
				return true;
			}
			return false;
		}

		public Boolean validarAdmin()
		{
			if (usuario() == null || !usuario().rol.Equals("admin") || usuario().rol.Equals(""))
			{
				return true;
			}
			return false;
		}

	}
}