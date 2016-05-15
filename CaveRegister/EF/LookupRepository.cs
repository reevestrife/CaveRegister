using CaveRegister.Model;
using CaveRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaveRegister.EF
{
	public class LookupRepository
	{
		ApplicationDbContext db;

		public LookupRepository(ApplicationDbContext context)
		{
			db = context;
		}

		private IQueryable<CaveAttribute> GetAllCaveAttributes()
		{
			return db.CaveAttributes;
		}
		private IQueryable<CaveStatus> GetAllCaveStatuses()
		{
			return db.CaveStatuses;
		}
		private IQueryable<EaseOfAccess> GetAllEaseOfAccesses()
		{
			return db.EaseOfAccesses;
		}
		private IQueryable<ExplorationStatus> GetAllExplorationStatuses()
		{
			return db.ExplorationStatuses;
		}
		private IQueryable<Geology> GetAllGeologies()
		{
			return db.Geologies;
		}
		private IQueryable<LocationStatus> GetAllLocationStatuses()
		{
			return db.LocationStatuses;
		}
		private IQueryable<ObservableEntity> GetAllObersvableEntities()
		{
			return db.ObservableEntities;
		}
		private IQueryable<ObservableEntityType> GetAllObersvableEntityTypes()
		{
			return db.ObservableEntityTypes;
		}
		private IQueryable<PotentialType> GetAllPotentials()
		{
			return db.PotentialTypes;
		}
		private IQueryable<Province> GetAllProvinces()
		{
			return db.Provinces;
		}

		private IQueryable<Terrain> GetAllTerrains()
		{
			return db.Terrains;
		}


		private IQueryable<CaveAttribute> _dynamic_caveAttributes;
		public IQueryable<CaveAttribute> CaveAttributes
		{
			get
			{
				if (_dynamic_caveAttributes == null)
				{
					_dynamic_caveAttributes = GetAllCaveAttributes();
				}
				return _dynamic_caveAttributes;
			}
			set
			{
				_dynamic_caveAttributes = value;
			}
		}
		
		private IQueryable<CaveStatus> _dynamic_caveStatuses;
		public IQueryable<CaveStatus> CaveStatuses
		{
			get
			{
				if(_dynamic_caveStatuses == null)
				{
					_dynamic_caveStatuses = GetAllCaveStatuses();
				}
				return _dynamic_caveStatuses;
			}
			set
			{
				_dynamic_caveStatuses = value;
			}
		}

		private IQueryable<EaseOfAccess> _dynamic_easeOfAccesses;
		public IQueryable<EaseOfAccess> EaseOfAccesses
		{
			get
			{
				if (_dynamic_easeOfAccesses == null)
				{
					_dynamic_easeOfAccesses = GetAllEaseOfAccesses();
				}
				return _dynamic_easeOfAccesses;
			}
			set
			{
				_dynamic_easeOfAccesses = value;
			}
		}

		private IQueryable<ExplorationStatus> _dynamic_explorationStatuses;
		public IQueryable<ExplorationStatus> ExplorationStatuses
		{
			get
			{
				if (_dynamic_explorationStatuses == null)
				{
					_dynamic_explorationStatuses = GetAllExplorationStatuses();
				}
				return _dynamic_explorationStatuses;
			}
			set
			{
				_dynamic_explorationStatuses = value;
			}
		}

		private IQueryable<Geology> _dynamic_Geologies;
		public IQueryable<Geology> Geologies
		{
			get
			{
				if (_dynamic_Geologies == null)
				{
					_dynamic_Geologies = GetAllGeologies();
				}
				return _dynamic_Geologies;
			}
			set
			{
				_dynamic_Geologies = value;
			}
		}

		private IQueryable<ObservableEntityType> _dynamic_ObservableEntityTypes;
		public IQueryable<ObservableEntityType> ObservableEntityTypes
		{
			get
			{
				if (_dynamic_ObservableEntityTypes == null)
				{
					_dynamic_ObservableEntityTypes = GetAllObersvableEntityTypes();
				}
				return _dynamic_ObservableEntityTypes;
			}
			set
			{
				_dynamic_ObservableEntityTypes = value;
			}
		}

		private IQueryable<ObservableEntity> _dynamic_ObservableEntities;
		public IQueryable<ObservableEntity> ObservableEntities
		{
			get
			{
				if (_dynamic_ObservableEntities == null)
				{
					_dynamic_ObservableEntities = GetAllObersvableEntities();
				}
				return _dynamic_ObservableEntities;
			}
			set
			{
				_dynamic_ObservableEntities = value;
			}
		}

		
		private IQueryable<LocationStatus> _dynamic_locationStatuses;
		public IQueryable<LocationStatus> LocationStatuses
		{
			get
			{
				if (_dynamic_locationStatuses == null)
				{
					_dynamic_locationStatuses = GetAllLocationStatuses();
				}
				return _dynamic_locationStatuses;
			}
			set
			{
				_dynamic_locationStatuses = value;
			}
		}

		private IQueryable<PotentialType> _dynamic_potentials;
		public IQueryable<PotentialType> Potentials
		{
			get
			{
				if (_dynamic_potentials == null)
				{
					_dynamic_potentials = GetAllPotentials();
				}
				return _dynamic_potentials;
			}
			set
			{
				_dynamic_potentials = value;
			}
		}

		private IQueryable<Province> _dynamic_provinces;
		public IQueryable<Province> Provinces
		{
			get
			{
				if (_dynamic_provinces == null)
				{
					_dynamic_provinces = GetAllProvinces();
				}
				return _dynamic_provinces;
			}
			set
			{
				_dynamic_provinces = value;
			}
		}

		private IQueryable<Terrain> _dynamic_Terrains;
		public IQueryable<Terrain> Terrains
		{
			get
			{
				if (_dynamic_Terrains == null)
				{
					_dynamic_Terrains = GetAllTerrains();
				}
				return _dynamic_Terrains;
			}
			set
			{
				_dynamic_Terrains = value;
			}
		}
	
	}
}
		