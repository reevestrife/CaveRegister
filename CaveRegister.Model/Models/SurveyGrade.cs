namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("SurveyGrade")]
    public partial class SurveyGrade
    {
		public const string One = "1";
		public const string Two = "2";
		public const string Three = "3";
		public const string Four = "4";
		public const string Five = "5";
		public const string Six = "6";
		public const string X = "X";
		public const string Unknown = "Unknown";

        public SurveyGrade()
        {
            Surveys = new HashSet<Survey>();
        }

        [StringLength(16)]
        public string SurveyGradeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

		[JsonIgnore]
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
