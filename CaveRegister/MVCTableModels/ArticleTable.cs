using CaveRegister.Model;
using CaveRegister.Models;
using MvcTables.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaveRegister.MVCTableModels
{
	public class ArticleTable : MvcTable<Article>
	{
		public override void Configure(IStaticTableConfiguration<Article> config)
		{
			config.SetAction("ListArticles", "Articles")
		   .SetCssClass("table table-striped")
		   .SetDefaultPageSize(10)
		   .HiddenColumnFor(c => c.ArticleId, cfg => cfg.Hide())
		   .HiddenColumnFor(c => c.PublicationId, cfg => cfg.Hide())
		   .ActionLinkColumn(c => c.Name, "Details", "Articles", o => new { id = o.ArticleId })
		   .DisplayForColumn(c => c.Author)
		   .PartialColumnFor("_CavesCell", p => p, cfg => cfg.SetHeaderText("Caves"))
		   .PartialColumnFor("_ActionButtons", p => p, cfg => cfg.SetHeaderText("Action"))
		   .ConfigurePagingControl(p => p.SetContainerCssClass("pagination"));
		}
	}
}