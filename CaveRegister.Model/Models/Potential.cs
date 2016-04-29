namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

    [Table("Potential")]
    public partial class PotentialType
    {
		public const string Airflow= "Airflow";
		public const string Dig = "Dig";
		public const string Blasting = "Blasting";
		public const string HammerChisel = "HammerChisel";
		public const string Balcony = "Balcony";
		public const string Bolting = "Bolting";
		public const string Pit = "Pit";
		public const string Drop = "Drop";
		public const string Climb = "Climb";
		public const string Squeeze = "Squeeze";
		public const string Scuba = "Scuba";


		public PotentialType()
        {
            Cave_Potential = new HashSet<Cave_Potential>();
        }

        [StringLength(64)]
        public string PotentialTypeId { get; set; }

        [Required]
        [StringLength(64)]
        public string Description { get; set; }

		[JsonIgnore]
        public virtual ICollection<Cave_Potential> Cave_Potential { get; set; }
    }
}
