using CaveRegister.Model.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveRegister.Model
{
	public abstract class BaseModel : ISoftDelete
	{
		[Display(Name = "Last edited date ")]
		public DateTime LastEditDate { get; set; }
		[Display(Name = "Date Created")]
		public DateTime DateCreated { get; set; }
		public bool IsDeleted { get; set; }

		[Display(Name = "Last edited by")]
		public string LasEditApplicationUser_Id { get; set; }
		[Display(Name = "Last edited by")]
		public virtual ApplicationUser LasEditApplicationUser { get; set; }
		
		public string EntityStatusId { get; set; }
		public virtual EntityStatus EntityStatus { get; set; }

		public virtual History WorkFlow { get; set; }
		public int HistoryId { get; set; }

		public BaseModel()
		{
			LastEditDate = DateTime.Now;
			DateCreated = DateTime.Now;
			IsDeleted = false;
		}
	}
}
