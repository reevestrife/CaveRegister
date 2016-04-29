namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("SurveyType")]
    public partial class SurveyType
    {
		public const string KMLMap = "KmlMap";
		public const string KMLModel = "KmlModel";
		public const string LineSurvey = "LineSurvey";
		public const string Plan = "Plan";
		public const string Elevation = "Elevation";
		public const string ExtendedElevation = "ExtendedElevation";
		public const string Unknown = "Unknown";
		public const string Scanned = "Scanned";
		public const string ThreeD = "3D";

        public SurveyType()
        {
            Surveys = new HashSet<Survey>();
        }

        [StringLength(64)]
        public string SurveyTypeId { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

		[JsonIgnore]
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
