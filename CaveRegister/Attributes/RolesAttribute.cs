﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaveRegister.Attributes
{
	public class RolesAttribute : AuthorizeAttribute
	{
		public RolesAttribute(params string[] roles)
		{
			Roles = String.Join(",", roles);
		}
	}
}