using CaveRegister.Model;
using CaveRegister.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaveRegister.Models
{
	public class VisitHistoryViewModel
	{
		public VisitHistoryViewModel()
		{

		}
		public VisitHistoryViewModel(VisitHistory visitHistory)
		{

		}

		public VisitHistory VisitHistory { get; set; }
		public SelectList AttendingApplicationUsersSelectList { get; set; }
		[Display(Name = "Members present")]
		[Required]
		public List<string> SelectedAttendingApplicationUsers { get; set; }
	}
}