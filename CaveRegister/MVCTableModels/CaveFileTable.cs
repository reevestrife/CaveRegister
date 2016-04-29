using CaveRegister.Model;
using MvcTables.Configuration;

namespace CaveRegister.MVCTableModels
{
	public class CaveFileTable : MvcTable<MetaFile>
	{
		public override void Configure(IStaticTableConfiguration<MetaFile> config)
		{
			config.SetAction("ListCaveFiles", "CaveFiles")
			.SetCssClass("table table-striped")
			.SetDefaultPageSize(5)
			.HiddenColumnFor(c => c.FileId, cfg => cfg.Hide())
			.DisplayForColumn(c => c.Description)
			.DisplayForColumn(c => c.FileType.Description)
			.DisplayForColumn(c => c.LastEditDate)
			.PartialColumnFor("_ActionButtons", p => p, cfg => cfg.SetHeaderText("Action"));
		}
	}
}