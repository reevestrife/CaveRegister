using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveRegister.Model
{
	public class CertificationLevel
	{
		//public const string Uncertain = "Uncertain";
		public const string Scuba = "Scuba";
		public const string Advanced = "Advanced";
		public const string Horizontal = "Horizontal";
		public const string Tourist = "Tourist";
		public const string Pristine = "Pristine";
		public const string Vertical = "Vertical";

		[Key]
		public string CertificationLevelId { get; set; }
		public string Description { get; set; }

		public virtual ICollection<Cave> Caves { get; set; }
		public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

		public CertificationLevel()
		{
			Caves = new HashSet<Cave>();
			ApplicationUsers = new HashSet<ApplicationUser>();
		}

	}
}
