﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class BLLogin
	{
		public string correo { set; get; }
		public string contras { set; get; }
		public string rol { set; get; }

		public BLLogin(string correo, string contras, string rol)
		{
			this.correo = correo;
			this.contras = contras;
			this.rol = rol;
		}
	}
}
