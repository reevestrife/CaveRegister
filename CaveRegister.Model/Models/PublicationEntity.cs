namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("PublicationEntity")]
    public partial class PublicationEntity
    {
        public PublicationEntity()
        {
            Publications = new HashSet<Publication>();
        }
		[Key]
        public int PublicationEntityId { get; set; }

        [Required]
        [StringLength(128)]
		[Display(Name="Publication")]
        public string Description { get; set; }

		[JsonIgnore]
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
