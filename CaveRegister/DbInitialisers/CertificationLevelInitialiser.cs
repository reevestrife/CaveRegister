using CaveRegister.Model;
using CaveRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaveRegister.DbInitialisers
{
	public static class CertificationLevelInitialiser
	{
		public static void Ininitialise(ApplicationDbContext db)
		{
			db.CertificationLevels.Add(new Model.CertificationLevel() { CertificationLevelId = CertificationLevel.Advanced, Description = CertificationLevel.Advanced });
			db.CertificationLevels.Add(new Model.CertificationLevel() { CertificationLevelId = CertificationLevel.Horizontal, Description = CertificationLevel.Horizontal });
			db.CertificationLevels.Add(new Model.CertificationLevel() { CertificationLevelId = CertificationLevel.Pristine, Description = CertificationLevel.Pristine });
			db.CertificationLevels.Add(new Model.CertificationLevel() { CertificationLevelId = CertificationLevel.Scuba, Description = CertificationLevel.Scuba });
			db.CertificationLevels.Add(new Model.CertificationLevel() { CertificationLevelId = CertificationLevel.Tourist, Description = CertificationLevel.Tourist });
			db.CertificationLevels.Add(new Model.CertificationLevel() { CertificationLevelId = CertificationLevel.Vertical , Description = CertificationLevel.Vertical });
		}
	}
}