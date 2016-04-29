namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("Fossil")]
    public partial class Fossil
    {
        public Fossil()
        {
            Cave_Fossil = new HashSet<Cave_Fossil>();
        }

        [StringLength(64)]
        public string FossilId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

		[JsonIgnore]
        public virtual ICollection<Cave_Fossil> Cave_Fossil { get; set; }
    }
}
