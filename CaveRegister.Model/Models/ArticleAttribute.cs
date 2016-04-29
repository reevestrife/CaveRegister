namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("ArticleAttribute")]
    public partial class ArticleAttribute
    {
        public ArticleAttribute()
        {
            Articles = new HashSet<Article>();
        }

        [StringLength(64)]
        public string ArticleAttributeId { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

		[JsonIgnore]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
