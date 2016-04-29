using CaveRegister.Model;
using CaveRegister.Models;


namespace CaveRegister.DbInitialisers
{
	public static class EaseOfAccessInitialser
	{
		public static void Ininitialise(ApplicationDbContext db)
		{
			db.EaseOfAccesses.Add(new EaseOfAccess() { EaseOfAccessId = EaseOfAccess.Giftneeded, Description = "Gift Needed" });
			db.EaseOfAccesses.Add(new EaseOfAccess() { EaseOfAccessId = EaseOfAccess.Difficult, Description = EaseOfAccess.Difficult });
			db.EaseOfAccesses.Add(new EaseOfAccess() { EaseOfAccessId = EaseOfAccess.Easy, Description = EaseOfAccess.Easy });
			db.EaseOfAccesses.Add(new EaseOfAccess() { EaseOfAccessId = EaseOfAccess.Forbidden, Description = EaseOfAccess.Forbidden });
			db.EaseOfAccesses.Add(new EaseOfAccess() { EaseOfAccessId = EaseOfAccess.Gated, Description = EaseOfAccess.Gated });
			db.EaseOfAccesses.Add(new EaseOfAccess() { EaseOfAccessId = EaseOfAccess.NoticePeriod, Description = "Notice Period" });
			db.EaseOfAccesses.Add(new EaseOfAccess() { EaseOfAccessId = EaseOfAccess.OnceAYear, Description = "Once a Year" });
			db.EaseOfAccesses.Add(new EaseOfAccess() { EaseOfAccessId = EaseOfAccess.Open, Description = EaseOfAccess.Open });
			db.EaseOfAccesses.Add(new EaseOfAccess() { EaseOfAccessId = EaseOfAccess.ResearchOnly, Description = "Research Only" });
			db.EaseOfAccesses.Add(new EaseOfAccess() { EaseOfAccessId = EaseOfAccess.Unknown, Description = EaseOfAccess.Unknown });
			db.EaseOfAccesses.Add(new EaseOfAccess() { EaseOfAccessId = EaseOfAccess.Tourist, Description = EaseOfAccess.Tourist });
			db.EaseOfAccesses.Add(new EaseOfAccess() { EaseOfAccessId = EaseOfAccess.Permit, Description = EaseOfAccess.Permit });
		}
	}
}