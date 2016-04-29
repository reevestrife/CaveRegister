using CaveRegister.Contracts;
using CaveRegister.EF;
using System.Web.Mvc;
using CaveRegister.Model;

namespace CaveRegister.Models
{
	public class ObservationViewModel:ViewModel<Observation>
	{
		public ObservationViewModel()
		{

		}

		public ObservationViewModel(ApplicationDbContext db, Observation observation)
		{
			Db = db;
			Model = observation;
			LookupRepository = new LookupRepository(Db);
			if(Model == null)
			{
				Model = new Observation();
			}
			PopulateSelectLists();
		}
		
		public SelectList ObservableEntitySelectList { get; set; }
		public SelectList TerrainSelectList { get; set; }


		public override void PrepareSave()
		{
			
		}

		public override void PopulateSelectLists()
		{
			ObservableEntitySelectList = new SelectList(LookupRepository.ObservableEntities,"ObservableEntityID","Name",Model.ObservableEntityId);
			TerrainSelectList = new SelectList(LookupRepository.Terrains, "TerrainID", "Name", Model.TerrainId);
		}
	}
}