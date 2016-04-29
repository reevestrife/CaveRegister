using CaveRegister.Model;

using MvcTables.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaveRegister.MVCTableModels
{
	public class CaveFilterTable : MvcTable<Cave>
	{
		public override void Configure(IStaticTableConfiguration<Cave> config)
		{
			config.SetAction("ListCavesForFilters", "Caves")
				  .SetCssClass("table table-striped")
				  .SetDefaultPageSize(10)
				  .HiddenColumnFor(c => c.CaveId, cfg => cfg.Hide())
				  .PartialColumnFor("_CaveCodeDetailButtonCell", p => p,cfg=> cfg.SetHeaderText("SASA Code"))
				  .PartialColumnFor("_CaveNameDetailButtonCell", p => p,cfg=> cfg.SetHeaderText("Name"))
				  .PartialColumnFor("_CaveStatus", p => p.CaveStatuses)
				  .PartialColumnFor("_CaveAttribute", p => p.CaveAttributes)
				  .DisplayForColumn(c => c.ExplorationStatus.Description)
				  .DisplayForColumn(c => c.LocationStatus.Description)
				  .DisplayForColumn(c => c.Province.Description)
				  .PartialColumnFor("_ActionButtons", p=> p.CaveId,cfg => cfg.SetHeaderText("Action"))
				  //.ActionLinkColumn(c => c.CaveID, "Edit","edit")
				  //.ActionLinkColumn(c => c.CaveID, "Details", "details")
				  //.ActionLinkColumn(c => c.CaveID, "Delete", "delete")
				  .ConfigurePagingControl(p => p.SetContainerCssClass("pagination"));
		}
	}
}