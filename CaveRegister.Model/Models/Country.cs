namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("Country")]
    public partial class Country
    {
		public const string SouthAfrica = "SouthAfrica";
		public const string Namibia = "Namibia";
		public const string Botswana = "Botswana";
		public const string Zimbabwe = "Zimbabwe";
		public const string Madagascar = "Madagascar";
		public const string Mozambique = "Mozambique";
		public const string Swaziland = "Swaziland";
		public const string Lesotho = "Lesotho";
		public const string Zambia = "Zambia";
		public const string Unknown = "Unknown";

        public Country()
        {
            Provinces = new HashSet<Province>();
        }
		[Key]
        [StringLength(64)]
        public string CountryId { get; set; }

        [Required]
        [StringLength(64)]
		[Display(Name="Country")]
        public string Description { get; set; }

		[JsonIgnore]
        public virtual ICollection<Province> Provinces { get; set; }
    }
}
