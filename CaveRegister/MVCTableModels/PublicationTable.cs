using CaveRegister.Model;
using CaveRegister.Models;
using MvcTables.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaveRegister.MVCTableModels 
{
	public class PublicationTable : MvcTable<Publication>
	{
		public override void Configure(IStaticTableConfiguration<Publication> config)
		{
			config.SetAction("ListPublications", "Publications")
		   .SetCssClass("table table-striped")
		   .SetDefaultPageSize(5)
		 //  .HiddenColumnFor(c => c.PublicationEntityID, cfg => cfg.Hide())
		 //  .HiddenColumnFor(c => c.PublicationID, cfg => cfg.Hide())
		   .ActionLinkColumn(c => c.Name, "Details", "VisitHistories", o => new { id = o.PublicationId })
		   .DisplayForColumn(c=> c.PublicationDate)
		   .PartialColumnFor("_ActionButtons", p => p, cfg => cfg.SetHeaderText("Action"))
		   .ConfigurePagingControl(p => p.SetContainerCssClass("pagination"));
		}
	}
}