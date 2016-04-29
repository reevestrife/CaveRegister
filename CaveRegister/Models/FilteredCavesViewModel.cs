using CaveRegister.Model;
using CaveRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaveRegister.Models
{
	public class FilteredCavesViewModel
	{
		public string SearchText { get; set; }
		public IEnumerable<Cave> Caves { get; set; }
		public SelectList CaveStatusSelectList { get; set; }
		public string SelectedCaveStatuses { get; set; }
		public SelectList CaveAttributeSelectList { get; set; }
		public string SelectedCaveAttributes { get; set; }
		public SelectList ExplorationStatusSelectList { get; set; }
		public string SelectedExplorationStatus { get; set; }
		public SelectList LocationStatusSelectList { get; set; }
		public string SelectedLocationStatus { get; set; }
		public bool HideCodelessItems { get; set; }
	}
}