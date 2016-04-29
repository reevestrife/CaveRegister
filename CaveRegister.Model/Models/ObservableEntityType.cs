namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table("ObservableEntityType")]
    public partial class ObservableEntityType
    {
		public const string Unknown = "Unknown";
		public const string Other = "Other";
		public const string Mammal = "Mammal";
		public const string Bird = "Bird";
		public const string Bug = "Bug";
		public const string Reptile = "Reptile";
		public const string Snake = "Snake";
		public const string Arachnid = "Arachnid";

        public ObservableEntityType()
        {
			ObservableEntities = new HashSet<ObservableEntity>();
        }

		[Key]
		[StringLength(64)]
		public string ObservableEntityTypeId { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Description { get; set; }

		[JsonIgnore]
		public virtual ICollection<ObservableEntity> ObservableEntities { get; set; }
    }
}
