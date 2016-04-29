namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table("CaveStatus")]
    public partial class CaveStatus//:BaseModel
    {
		public const string Blocked = "Blocked";
		public const string Collapsed = "Collapsed";
		public const string Cave = "Cave";
		public const string Closed = "Closed";
		public const string Crack = "Crack";
		public const string Large = "Large";
		public const string Small = "Small";
		public const string Overhang = "Overhang";
		public const string Shallow = "Shallow";
		public const string Deep = "Deep";
		public const string Sinkhole = "Sinkhole";
		public const string Nothing = "Nothing";
		public const string Depression = "Depression";
		public const string Mine = "Mine";
		public const string FossilSite = "FossilSite";
		public const string BlowingHole = "BlowingHole";
		public const string GoogleEarthPotential = "GoogleEarthPotential";
		public const string Unknown = "Unknown";
		public const string RockShelter = "RockShelter";

        public CaveStatus()
        {
            Caves = new HashSet<Cave>();
	//		Cave_CaveStatuses = new HashSet<Cave_CaveStatus>();
        }

        [Key]
        [StringLength(64)]
        public string CaveStatusId { get; set; }

        [Required]
        [StringLength(64)]
        public string Description { get; set; }

		[StringLength(256)]
		public string IconUrl { get; set; }

		public int OrderOfImportance { get; set; }

		[JsonIgnore]
        public virtual ICollection<Cave> Caves { get; set; }

		//public virtual ICollection<Cave_CaveStatus> Cave_CaveStatuses { get; set; }
    }
}
