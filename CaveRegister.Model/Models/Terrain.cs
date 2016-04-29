namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("Terrain")]
    public partial class Terrain
    {
		public const string Twilight = "Twilight";
		public const string FullDarkness = "FullDarkness";

        public Terrain()
        {
            ObservedCaveLives = new HashSet<Observation>();
        }

        [StringLength(64)]
        public string TerrainId { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

		[JsonIgnore]
        public virtual ICollection<Observation> ObservedCaveLives { get; set; }
    }
}
