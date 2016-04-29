using CaveRegister.Model;
using CaveRegister.Models;

namespace CaveRegister.DbInitialisers
{
	public class PotentialTypeInitialiser
	{
		public static void Ininitialise(ApplicationDbContext db)
		{
			db.Potentials.Add(new PotentialType() { PotentialTypeId = PotentialType.Balcony, Description = PotentialType.Balcony });
			db.Potentials.Add(new PotentialType() { PotentialTypeId = PotentialType.Blasting, Description = PotentialType.Blasting });
			db.Potentials.Add(new PotentialType() { PotentialTypeId = PotentialType.Airflow, Description = PotentialType.Airflow });
			db.Potentials.Add(new PotentialType() { PotentialTypeId = PotentialType.Dig, Description = PotentialType.Dig });
			db.Potentials.Add(new PotentialType() { PotentialTypeId = PotentialType.Pit, Description = PotentialType.Pit });
			db.Potentials.Add(new PotentialType() { PotentialTypeId = PotentialType.HammerChisel, Description = PotentialType.HammerChisel });
			db.Potentials.Add(new PotentialType() { PotentialTypeId = PotentialType.Drop, Description = PotentialType.Drop });
			db.Potentials.Add(new PotentialType() { PotentialTypeId = PotentialType.Climb, Description = PotentialType.Climb });
			db.Potentials.Add(new PotentialType() { PotentialTypeId = PotentialType.Squeeze, Description = PotentialType.Squeeze });
			db.Potentials.Add(new PotentialType() { PotentialTypeId = PotentialType.Scuba, Description = PotentialType.Scuba });
		}
	}
}