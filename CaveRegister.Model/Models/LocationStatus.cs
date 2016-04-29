namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table("Locationtatus")]
	public class LocationStatus
	{
		public const string Confirmed = "Confirmed";
		public const string UnConfirmed = "UnConfirmed";
		public const string Closed = "Closed";
		public const string Missing = "Missing";
		public const string LocationFromGooleMaps = "LocationFromGooleMaps";

		public LocationStatus()
        {
            Caves = new HashSet<Cave>();
        }

        [Key]
        [StringLength(64)]
		public string LocationStatusId { get; set; }

		[JsonIgnore]
        [Required]
        [StringLength(64)]
		[Display(Name="Location Status")]
        public string Description { get; set; }
        public virtual ICollection<Cave> Caves { get; set; }
	}
}
