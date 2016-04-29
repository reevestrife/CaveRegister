using CaveRegister.Model;
using CaveRegister.Models;

namespace CaveRegister.DbInitialisers
{
	public static class ChangeLogTypeInitialiser
	{
		public static void Ininitialise(ApplicationDbContext db)
		{
			db.ChangeLogTypes.Add(new ChangeLogType() { ChangeLogTypeId = ChangeLogType.BugFix, Name = "Bug Fix" });
			db.ChangeLogTypes.Add(new ChangeLogType() { ChangeLogTypeId = ChangeLogType.Delete, Name = ChangeLogType.Delete });
			db.ChangeLogTypes.Add(new ChangeLogType() { ChangeLogTypeId = ChangeLogType.Insert, Name = ChangeLogType.Insert });
			db.ChangeLogTypes.Add(new ChangeLogType() { ChangeLogTypeId = ChangeLogType.NewFeature, Name = "New Feature" });
			db.ChangeLogTypes.Add(new ChangeLogType() { ChangeLogTypeId = ChangeLogType.Update, Name = ChangeLogType.Update });
		}
	}
}