namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("Survey")]
	public partial class Survey : Auditable
    {
        public int SurveyId { get; set; }

        public int CaveId { get; set; }

        [Required]
        [StringLength(64)]
        public string SurveyTypeId { get; set; }

        [Required]
        [StringLength(256)]
        public string Description { get; set; }

        [Required]
        [StringLength(16)]
        public string SurveyGradeId { get; set; }

        public int FileId { get; set; }

		[JsonIgnore]
        public virtual Cave Cave { get; set; }

		public virtual MetaFile MetaFile { get; set; }

        public virtual SurveyGrade SurveyGrade { get; set; }

        public virtual SurveyType SurveyType { get; set; }


    }
}
