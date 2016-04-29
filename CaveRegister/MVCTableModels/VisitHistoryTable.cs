using CaveRegister.Model;
using MvcTables.Configuration;

namespace CaveRegister.MVCTableModels
{
	public class VisitHistoryTable : MvcTable<VisitHistory>
	{
		public override void Configure(IStaticTableConfiguration<VisitHistory> config)
		{
			config.SetAction("ListVisitHistories", "VisitHistories")
		   .SetCssClass("table table-striped")
		   .SetDefaultPageSize(5)
		   .HiddenColumnFor(c => c.CaveId, cfg => cfg.Hide())
		   .HiddenColumnFor(c => c.VisitHistoryId, cfg => cfg.Hide())
		   .ActionLinkColumn(c => c.VistitDate.ToString("yyyy-MM-dd"), "Edit", "VisitHistories", o => new { id = o.VisitHistoryId })
		   .PartialColumnFor("_UsersColumn", c => c.AttendingApplicationUsers)
		   .PartialColumnFor("_ActionButtons", p => p, cfg => cfg.SetHeaderText("Action"))
		   .ConfigurePagingControl(p => p.SetContainerCssClass("pagination"));
		}
	}
}

