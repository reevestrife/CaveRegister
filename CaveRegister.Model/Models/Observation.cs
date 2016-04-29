namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;
	using System.Web.Mvc;

    [Table("Observation")]
    public partial class Observation :Auditable
    {
		public Observation()
		{
			MetaFiles = new HashSet<MetaFile>();
		}

		[Key]
		public int ObservationId { get; set; }

		public int ObservableEntityId { get; set; }

		public int VisitHistoryId { get; set; }

		[Display(Name = "Minimum")]
		public double? Minimum { get; set; }

		[Display(Name = "Maximum")]
		public double? Maximum { get; set; }

		[Display(Name = "Exact")]
		public double? ExactMeasurement { get; set; }

		[StringLength(128)]
		[Display(Name = "Measurement (text)")]
		public string MeasurementString { get; set; }

		[StringLength(64)]
		public string TerrainId { get; set; }

        [Required]
		[AllowHtml]
		[UIHint("tinymce_full_compressed")]
        public string Description { get; set; }

        public virtual ObservableEntity ObservableEntity { get; set; }

		[JsonIgnore]
        public virtual VisitHistory VisitHistory { get; set; }

		public virtual ICollection<MetaFile> MetaFiles { get; set; }

		public virtual Terrain Terrain { get; set; }
    }
}
