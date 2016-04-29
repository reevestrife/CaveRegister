using CaveRegister.Model.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveRegister.Model
{
	public abstract class Auditable : ISoftDelete
	{
		[Display(Name = "Last edited date ")]
		public DateTime LastEditDate { get; set; }
		[Display(Name = "Date Created")]
		public DateTime DateCreated { get; set; }
		public bool IsDeleted { get; set; }

		[Display(Name = "Last edited by")]
		public string LasEditApplicationUserId { get; set; }

		[JsonIgnore]
		[Display(Name = "Last edited by")]
		public virtual ApplicationUser LasEditApplicationUser { get; set; }
		
		public string EntityStatusId { get; set; }
		public virtual EntityStatus EntityStatus { get; set; }

		[Required]
		[Display(Name = "Secrecy Level")]
		public int SecrecyLevelId { get; set; }
		public virtual SecrecyLevel SecrecyLevel { get; set; }

		[JsonIgnore]
		public virtual History History { get; set; }
		public int? HistoryId { get; set; }

		public Auditable()
		{
			LastEditDate = DateTime.Now;
			DateCreated = DateTime.Now;
			IsDeleted = false;
		}
	}
}
