using CaveRegister.Model;
using CaveRegister.Models;

namespace CaveRegister.DbInitialisers
{
	public static class EntityStatusInitialiser
	{
		public static void Ininitialise(ApplicationDbContext db)
		{
			db.EntityStatuses.Add(new EntityStatus() { EntityStatusId = EntityStatus.AwaitingApproval, Name = "Awaiting Approval" });
			db.EntityStatuses.Add(new EntityStatus() { EntityStatusId = EntityStatus.AwaitingDeleteApproval, Name = "Awaiting Approval for Deletion" });
			db.EntityStatuses.Add(new EntityStatus() { EntityStatusId = EntityStatus.Stable, Name = EntityStatus.Stable });
		}
	}
}