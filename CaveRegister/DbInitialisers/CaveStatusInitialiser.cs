using CaveRegister.Model;
using CaveRegister.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace CaveRegister.DbInitialisers
{
	public static class CaveStatusInitialiser
	{
		public static void Ininitialise(ApplicationDbContext db)
		{
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 100, Description = CaveStatus.Collapsed, CaveStatusId = CaveStatus.Collapsed });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 100, Description = CaveStatus.Large, CaveStatusId = CaveStatus.Large });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 100, Description = CaveStatus.Small, CaveStatusId = CaveStatus.Small });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 100, Description = CaveStatus.Cave, CaveStatusId = CaveStatus.Cave });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 100, Description = CaveStatus.Closed, CaveStatusId = CaveStatus.Closed });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 200, Description = "Rock Shelter", CaveStatusId = CaveStatus.RockShelter });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 200, Description = "Blowing Hole", CaveStatusId = CaveStatus.BlowingHole });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 200, Description = "Fossil Site", CaveStatusId = CaveStatus.FossilSite });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 400, Description = CaveStatus.Deep, CaveStatusId = CaveStatus.Deep });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 450, Description = CaveStatus.Sinkhole, CaveStatusId = CaveStatus.Sinkhole });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 500, Description = CaveStatus.Shallow, CaveStatusId = CaveStatus.Shallow });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 600, Description = CaveStatus.Overhang, CaveStatusId = CaveStatus.Overhang });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 700, Description = "GoogleEarth Potential", CaveStatusId = CaveStatus.GoogleEarthPotential });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 100, Description = CaveStatus.Blocked, CaveStatusId = CaveStatus.Blocked });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 800, Description = CaveStatus.Crack, CaveStatusId = CaveStatus.Crack });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 100, Description = CaveStatus.Mine, CaveStatusId = CaveStatus.Mine });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 900, Description = CaveStatus.Unknown, CaveStatusId = CaveStatus.Unknown });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 1000, Description = CaveStatus.Depression, CaveStatusId = CaveStatus.Depression });
			db.CaveStatuses.AddOrUpdate(new CaveStatus() { OrderOfImportance = 1100, Description = CaveStatus.Nothing, CaveStatusId = CaveStatus.Nothing });
		}
	}
}