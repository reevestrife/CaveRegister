using CaveRegister.Model;
using CaveRegister.Models;

namespace CaveRegister.DbInitialisers
{
	public class PotentialTypeInitialiser
	{
		public static void Ininitialise(ApplicationDbContext db)
		{
			db.PotentialTypes.Add(new PotentialType() { PotentialTypeId = PotentialType.Balcony, Description = PotentialType.Balcony });
			db.PotentialTypes.Add(new PotentialType() { PotentialTypeId = PotentialType.Blasting, Description = PotentialType.Blasting });
			db.PotentialTypes.Add(new PotentialType() { PotentialTypeId = PotentialType.Airflow, Description = PotentialType.Airflow });
			db.PotentialTypes.Add(new PotentialType() { PotentialTypeId = PotentialType.Dig, Description = PotentialType.Dig });
			db.PotentialTypes.Add(new PotentialType() { PotentialTypeId = PotentialType.Pit, Description = PotentialType.Pit });
			db.PotentialTypes.Add(new PotentialType() { PotentialTypeId = PotentialType.HammerChisel, Description = PotentialType.HammerChisel });
			db.PotentialTypes.Add(new PotentialType() { PotentialTypeId = PotentialType.Drop, Description = PotentialType.Drop });
			db.PotentialTypes.Add(new PotentialType() { PotentialTypeId = PotentialType.Climb, Description = PotentialType.Climb });
			db.PotentialTypes.Add(new PotentialType() { PotentialTypeId = PotentialType.Squeeze, Description = PotentialType.Squeeze });
			db.PotentialTypes.Add(new PotentialType() { PotentialTypeId = PotentialType.Scuba, Description = PotentialType.Scuba });
		}
	}
}