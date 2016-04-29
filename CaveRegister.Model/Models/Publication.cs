namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("Publication")]
    public partial class Publication
    {
        public Publication()
        {
            Articles = new HashSet<Article>();
        }
		[Key]
        public int PublicationId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public DateTime PublicationDate { get; set; }

        public int PublicationEntityId { get; set; }

        [StringLength(128)]
        public string FileLocation { get; set; }

		public int? FileId { get; set; }

		[JsonIgnore]
        public virtual ICollection<Article> Articles { get; set; }

		public virtual MetaFile File { get; set; }

        public virtual PublicationEntity PublicationEntity { get; set; }
    }
}
