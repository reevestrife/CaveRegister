using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveRegister.Model
{
	/// <summary>
	/// Secrecy Level Corresponds to some of the User Roles with same names.
	/// Purpose is to Limit certian users to what they can see on the Cave register.
	/// </summary>
	public class SecrecyLevel
	{
		public const int Highest = 100;
		public const int High = 75;
		public const int Normal = 50;
		public const int Low = 25;
		public const int NotSecret = 0;

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int SecrecyLevelId { get; set; }
		[StringLength(32)]
		[Display(Name = "Exploration Status")]
		public string Description { get; set; }
	}
}
