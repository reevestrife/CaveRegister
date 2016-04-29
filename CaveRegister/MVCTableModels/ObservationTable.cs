using CaveRegister.Model;
using CaveRegister.Models;
using MvcTables.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaveRegister.MVCTableModels
{
	public class ObservationTable : MvcTable<Observation>
	{
		public override void Configure(IStaticTableConfiguration<Observation> config)
		{
			config.SetAction("ListObservation", "Observations")
		   .SetCssClass("table table-striped")
		   .SetDefaultPageSize(5)
		   .HiddenColumnFor(c => c.ObservationId, cfg => cfg.Hide())
		   .HiddenColumnFor(c => c.VisitHistoryId, cfg => cfg.Hide())
		   .ActionLinkColumn(c => c.ObservableEntity.Name, "Edit", "Observation", o => new { visitHistoryID = o.VisitHistoryId, observationID= o.ObservationId })
		   //.DisplayForColumn(c=> c.Minimum)
		   //.DisplayForColumn(c => c.Maximum)
		   //.DisplayForColumn(c => c.MeasurementString)
		   .PartialColumnFor("_ActionButtons", p => p, cfg => cfg.SetHeaderText("Action"))
		   .ConfigurePagingControl(p => p.SetContainerCssClass("pagination"));
		}
	}
}


//	
//	;
