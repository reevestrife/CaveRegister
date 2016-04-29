using CaveRegister.Models;
using CaveRegister.Contracts;
using CaveRegister.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaveRegister.Model;

namespace CaveRegister.Models
{
	public class ObservableEntityViewModel:ViewModel<ObservableEntity>
	{
		public ObservableEntityViewModel()
		{

		}

		public ObservableEntityViewModel(ApplicationDbContext db, ObservableEntity observableEntity)
		{
			Db = db;
			Model = observableEntity;
			LookupRepository = new LookupRepository(Db); 
			if (Model == null)
			{
				///Cave cannot be left null, because we have to asign the values from cave to all the select lists.
				///If cave is null, this will cause alot more work.
				///If needed cave can be made null again afterwards.
				Model = new ObservableEntity();
			}
			PopulateSelectLists();
		}

		public SelectList ObservableEntityTypeSelectList { get; set; }

		public override void PrepareSave()
		{

		}

		public override void PopulateSelectLists()
		{
			ObservableEntityTypeSelectList = new SelectList(LookupRepository.ObservableEntityTypes, "ObservableEntityTypeID","Name",Model.ObservableEntityTypeId);
		}
	}
}