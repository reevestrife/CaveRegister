using CaveRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using CaveRegister.Model;

namespace CaveRegister.EF
{
	public static class SystemAdmin
	{
		private static ApplicationUser _user;
		public static ApplicationUser User
		{
			get
			{
				if(_user == null)
				{
					var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
					_user =  userManager.FindByName(Email);
				}

				return _user;
			}
		}

		public const string Name = "SystemAdmin";
		public const string Username = "reevestrife@gmail.com";
		public const string Email = "reevestrife@gmail.com";
		public const string Password = "C@veSystem3ntranceC0de";

		public const string GerrieEmail= "gw.pretorius@gmail.com";
		public const string StevenEmail = "sjtucker135@gmail.com";

		public const string Gerrie = "Gerrie";
		public const string Steven = "Steven";
	}
}