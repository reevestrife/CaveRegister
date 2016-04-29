using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace CaveRegister.Helpers
{
	public static partial class HtmlExtensions
	{
		public static MvcHtmlString ClientIdFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
		{
			return MvcHtmlString.Create(
				htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression)));
		}

		public static bool IsInRoles(this IPrincipal User, params string[] asd)
		{
			foreach (var item in asd)
			{
				 if(User.IsInRole(item))
				 {
					 return true;
				 }
			}
			return false;
		}
	}
}