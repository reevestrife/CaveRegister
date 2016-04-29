using CaveRegister.Models;
using CaveRegister.Contracts;
using CaveRegister.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaveRegister.Model;

namespace CaveRegister.Models
{
	public class CaveViewModel:ViewModel<Cave>
	{
		public CaveViewModel()
		{
			
		}

		public CaveViewModel(ApplicationDbContext db, Cave cave)
		{
			Db = db;
			Model = cave;
			LookupRepository = new LookupRepository(Db);
			if(Model == null)
			{
				///Cave cannot be left null, because we have to asign the values from cave to all the select lists.
				///If cave is null, this will cause alot more work.
				///If needed cave can be made null again afterwards.
				Model = new Cave(); 
			}
			PopulateSelectLists();
		}


		public SelectList CaveAttributeSelectList { get; set; }
		public SelectList CaveStatusSelectList { get; set; }
		public SelectList EaseOfAccessSelectList { get; set; }
		public SelectList ExplorationStatusSelectList { get; set; }
		public SelectList GeologySelectList { get; set; }
		public SelectList LocationStatusSelectList { get; set; }
		public SelectList ProvincesSelectList { get; set; }

		[Display(Name = "Cave Attributes")]
		public List<string> SelectedCaveAttributes { get; set; }

		[Display(Name = "Cave Statuses")]
		[Required]
		public List<string> SelectedCaveStatuses { get; set; }
		
		[Display(Name = "Ease of Access")]
		public List<string> SelectedEaseOfAccesses { get; set; }
		
		[Display(Name = "Geology")]
		public List<string> SelectedGeologies { get; set; }

		public override void PrepareSave()
		{
			var selectedCaveAttributes = Db.CaveAttributes.Where(p => this.SelectedCaveAttributes.Contains(p.CaveAttributeId)).ToList();
			Model.CaveAttributes.Clear();
			foreach (var item in selectedCaveAttributes)
			{
				this.Model.CaveAttributes.Add(item);
			}

			var selectedCaveStatuses = Db.CaveStatuses.Where(p => this.SelectedCaveStatuses.Contains(p.CaveStatusId)).ToList();
			Model.CaveStatuses.Clear();
			foreach (var item in selectedCaveStatuses)
			{
				this.Model.CaveStatuses.Add(item);
			}
			  
			var selectedEaseOfAccesses = Db.EaseOfAccesses.Where(p => this.SelectedEaseOfAccesses.Contains(p.EaseOfAccessId)).ToList();
			Model.EaseOfAccesses.Clear();
			foreach (var item in selectedEaseOfAccesses)
			{
				this.Model.EaseOfAccesses.Add(item);
			}

			var selectedGeologies = Db.Geologies.Where(p => this.SelectedGeologies.Contains(p.GeologyId)).ToList();
			Model.Geologies.Clear();
			foreach (var item in selectedGeologies)
			{
				this.Model.Geologies.Add(item);
			}
		}
				
		public override void PopulateSelectLists()
		{
			///MultiLine Selects:
			CaveAttributeSelectList = new SelectList(LookupRepository.CaveAttributes, "CaveAttributeID", "Description");
			SelectedCaveAttributes = Model.CaveAttributes.Select(p => p.CaveAttributeId).ToList<string>();

			var thisCaveStatuses = Model.CaveStatuses.Select(p => p.CaveStatusId).ToList<string>();
			CaveStatusSelectList = new SelectList(LookupRepository.CaveStatuses, "CaveStatusID", "Description", thisCaveStatuses);
			SelectedCaveStatuses = thisCaveStatuses;

			var thisEaseOfAccesses = Model.EaseOfAccesses.Select(p => p.EaseOfAccessId).ToList<string>();
			EaseOfAccessSelectList = new SelectList(LookupRepository.EaseOfAccesses, "EaseOfAccessID", "Description", thisEaseOfAccesses);
			SelectedEaseOfAccesses = thisEaseOfAccesses;

			var thisGeologies = Model.Geologies.Select(p => p.GeologyId).ToList<string>();
			GeologySelectList = new SelectList(LookupRepository.Geologies, "GeologyID", "Name", thisGeologies);
			SelectedGeologies = thisGeologies;

			///Dropdown selects
			ExplorationStatusSelectList = new SelectList(LookupRepository.ExplorationStatuses, "ExplorationStatusID", "Description",Model.ExplorationStatusId);
			LocationStatusSelectList = new SelectList(LookupRepository.LocationStatuses, "LocationStatusID", "Description",Model.LocationStatusId);
			ProvincesSelectList = new SelectList(LookupRepository.Provinces, "ProvinceID", "Description",Model.ProvinceId);
		}
	}
}