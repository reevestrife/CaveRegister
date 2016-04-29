namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;
	using System.Web.Mvc;

    [Table("VisitHistory")]
    public partial class VisitHistory: Auditable
    {
        public VisitHistory()
        {
			Cave_Fossils = new HashSet<Cave_Fossil>();
			Observations = new HashSet<Observation>();
			AttendingApplicationUsers = new HashSet<ApplicationUser>();
        }
		[Key]
        public int VisitHistoryId { get; set; }

        public int CaveId { get; set; }

		[Display(Name = "Date of Visit")]
		[DataType(DataType.Date)]
        public DateTime VistitDate { get; set; }

		[DataType(DataType.Time)]
		public DateTime? TripStartTime { get; set; }

		[DataType(DataType.Time)]
		public DateTime? TripEndTime { get; set; }

        [StringLength(1000)]
		[Display(Name = "Names of non member visitors")]
        public string Visitors { get; set; }

		[Display(Name = "Meet Report")]
		[AllowHtml]
		[UIHint("tinymce_basic")]
        public string MeetReport { get; set; }

		[JsonIgnore]
        public virtual Cave Cave { get; set; }

        public virtual ICollection<Observation> Observations { get; set; }

		public virtual ICollection<Cave_Fossil> Cave_Fossils { get; set; }

		[Display(Name = "Members Present")]
        public virtual ICollection<ApplicationUser> AttendingApplicationUsers { get; set; }
    }
}
