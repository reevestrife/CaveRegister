using CaveRegister.Models;
using CaveRegister.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace CaveRegister.Helpers
{
	public static class Extensions
	{
		public static double? ToDouble(this decimal? dec) {
			if(dec !=null)
				return Convert.ToDouble(dec);
			return null;
		}

		//public static void PopulateRelatedEntitesFromIDs(this Cave cave)
		//{
		//	cave.ExplorationStatus = LookupRepository.ExplorationStatusList.Where(p => p.ExplorationStatusID == cave.ExplorationStatusID).FirstOrDefault();
		//	cave.LocationStatus = LookupRepository.LocationStatusList.Where(p => p.LocationStatusID == cave.LocationStatusID).FirstOrDefault();
		//	cave.Province = LookupRepository.ProvinceList.Where(p => p.ProvinceID == cave.ProvinceID).FirstOrDefault();
		//}

		public static EntityKey GetEntityKey<T>(this DbContext context, T entity)
	where T : class
		{
			var oc = ((IObjectContextAdapter)context).ObjectContext;
			ObjectStateEntry ose;
			if (null != entity && oc.ObjectStateManager
									.TryGetObjectStateEntry(entity, out ose))
			{
				return ose.EntityKey;
			}
			return null;
		}

		public static EntityKey GetEntityKey<T>(this DbContext context
											   , DbEntityEntry<T> dbEntityEntry)
			where T : class
		{
			if (dbEntityEntry != null)
			{
				return GetEntityKey(context, dbEntityEntry.Entity);
			}
			return null;
		}
	}
}