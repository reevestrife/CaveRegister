using CaveRegister.Model;
using CaveRegister.Models;
using MvcTables.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaveRegister.MVCTableModels
{
	public class PublicationEntityTable : MvcTable<PublicationEntity>
	{
		public override void Configure(IStaticTableConfiguration<PublicationEntity> config)
		{
			config.SetAction("ListPublications", "Publicaions")
		   .SetCssClass("table table-striped")
		   .SetDefaultPageSize(15)
		   .HiddenColumnFor(c => c.PublicationEntityId, cfg => cfg.Hide())
		   .ActionLinkColumn(c => c.Description, "Details", "PublicationEntities", o => new { id = o.PublicationEntityId })
		   .PartialColumnFor("_ActionButtons", p => p, cfg => cfg.SetHeaderText("Action"))
		   .ConfigurePagingControl(p => p.SetContainerCssClass("pagination"));
		}
	}
}