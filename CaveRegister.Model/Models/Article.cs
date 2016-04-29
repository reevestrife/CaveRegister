namespace CaveRegister.Model
{
	using CaveRegister.Model.Contracts;
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;
	using System.Web.Mvc;

    [Table("Article")]
    public partial class Article : Auditable, IEntityWithURL
    {
        public Article()
        {
            Caves = new HashSet<Cave>();
			MetaFiles = new HashSet<MetaFile>();
			ArticleAttributes = new HashSet<ArticleAttribute>();
        }

		[Key]
        public int ArticleId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        
		[AllowHtml]
		[UIHint("tinymce_full_compressed")]
        public string Body { get; set; }

        [StringLength(128)]
        public string Source { get; set; }
        
        [StringLength(128)]
        public string Author { get; set; }

        [StringLength(128)]
        public string Tags { get; set; }

		[Display(Name="Start page")]
		public int? StartPage { get; set; }
		[Display(Name = "End page")]
		public int? EndPage { get; set; }

		[StringLength(256)]
		public string URL { get; set; }

        public int PublicationId { get; set; }

		
        public virtual Publication Publication { get; set; }

		[JsonIgnore]
        public virtual ICollection<Cave> Caves { get; set; }
				
		public virtual ICollection<MetaFile> MetaFiles { get; set; }
		
		public virtual ICollection<ArticleAttribute> ArticleAttributes { get; set; }

		
	}
}
