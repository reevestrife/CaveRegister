namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table("ExplorationStatus")]
    public partial class ExplorationStatus
    {
		public const string FullyExploredNoPotential = "FullyExploredNoPotential";
		public const string PartiallyExplored = "PartiallyExplored";
		public const string FullyExploredWithPotential = "FullyExploredWithPotential";
		public const string Potential= "Potential";
		public const string NoPotential = "NoPotential";
		public const string Unexplored = "Unexplored";
		public const string Unknown = "Unknown";

        public ExplorationStatus()
        {
            Caves = new HashSet<Cave>();
        }

        [Key]
		[StringLength(64)]
		[Display(Name = "Exploration Status")]
        public string ExplorationStatusId { get; set; }

        [Required]
		[StringLength(64)]
		[Display(Name="Exploration Status")]
        public string Description { get; set; }

		[JsonIgnore]
        public virtual ICollection<Cave> Caves { get; set; }
    }
}
