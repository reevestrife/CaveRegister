namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("Medium")]
    public partial class Medium
    {
		public const string Soil = "Soil";
		public const string CalcifiedBreccia = "CalcifiedBreccia";
		public const string DeCalcifiedBreccia = "DeCalcifiedBreccia";

        public Medium()
        {
            Cave_Fossil = new HashSet<Cave_Fossil>();
        }

        [StringLength(64)]
        public string MediumId { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

		[JsonIgnore]
        public virtual ICollection<Cave_Fossil> Cave_Fossil { get; set; }
    }
}
