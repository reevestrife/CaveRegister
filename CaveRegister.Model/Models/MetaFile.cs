using CaveRegister.Model.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveRegister.Model
{
	public class MetaFile : Auditable, IEntityWithURL
	{
		public MetaFile()
		{
			Articles = new HashSet<Article>();
			Cave_Fossils = new HashSet<Cave_Fossil>();
			Caves = new HashSet<Cave>();
			Entrances = new HashSet<Entrance>();
			Observations = new HashSet<Observation>();
			Publications = new HashSet<Publication>();
			Surveys = new HashSet<Survey>();
		}


		[Key, ForeignKey("File")]
		public int FileId { get; set; }

		[Required]
		[StringLength(64)]
		public string Title { get; set; }

		[Required]
		[StringLength(256)]
		public string Description { get; set; }

		[Required]
		[StringLength(128)]
		public string Author { get; set; }

		public bool IsCoverImage { get; set; }

		[Required]
		[StringLength(64)]
		public string FileTypeId { get; set; }

		[JsonIgnore]
		public virtual ICollection<Article> Articles { get; set; }

		[JsonIgnore]
		public virtual ICollection<Cave_Fossil> Cave_Fossils { get; set; }

		[JsonIgnore]
		public virtual ICollection<Cave> Caves { get; set; }

		[JsonIgnore]
		public virtual ICollection<Entrance> Entrances { get; set; }

		[JsonIgnore]
		public virtual ICollection<Observation> Observations { get; set; }

		[JsonIgnore]
		public virtual ICollection<Publication> Publications { get; set; }

		[JsonIgnore]
		public virtual ICollection<Survey> Surveys { get; set; }

		public virtual FileType FileType { get; set; }

		public virtual File File { get; set; }

		public string URL
		{
			get { return "notImplemented"; }
		}
	}
}
