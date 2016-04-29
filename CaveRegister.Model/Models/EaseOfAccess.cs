namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("EaseOfAccess")]
    public partial class EaseOfAccess
    {
		public const string Unknown = "Unknown";
		public const string Open = "Open";
		public const string Forbidden = "Forbidden";
		public const string ResearchOnly = "ResearchOnly";
		public const string Giftneeded = "GiftNeeded";
		public const string Difficult = "Difficult";
		public const string Easy = "Easy";
		public const string NoticePeriod = "NoticePeriod";
		public const string OnceAYear = "OnceAYear";
		public const string Tourist = "Tourist";
		public const string Gated = "Gated";
		public const string Permit = "Permit";

		public EaseOfAccess()
        {
            Caves = new HashSet<Cave>();
        }

        [StringLength(64)]
        public string EaseOfAccessId { get; set; }

        [Required]
        [StringLength(128)]
        public string Description { get; set; }

		[JsonIgnore]
        public virtual ICollection<Cave> Caves { get; set; }
    }
}
