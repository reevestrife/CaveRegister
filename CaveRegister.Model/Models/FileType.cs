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
	[Table("FileType")]
    public partial class FileType
	{
		public const string KmlSurvey = "KmlSurvey";
		public const string Other = "Other";
		public const string Image = "Image";
		public const string CoverImage = "CoverImage";
		public const string Survey = "Survey";
		public const string SurveyFiles = "SurveyFiles";
		public const string Document = "Document";

        public FileType()
        {
			MetaFiles = new HashSet<MetaFile>();
        }

		[Key]
		[StringLength(64)]
		public string FileTypeID {get; set;}

		[StringLength(64)]
		[Display(Name="File Type")]
		public string Description { get; set; }

		[JsonIgnore]
		public virtual ICollection<MetaFile> MetaFiles { get; set; }
	}
}
