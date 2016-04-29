namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("ChangeLogType")]
    public partial class ChangeLogType
    {
		public const string Insert = "Insert";
		public const string Update = "Update";
		public const string Delete = "Delete";
		public const string NewFeature = "NewFeature";
		public const string BugFix = "BugFix";

        public ChangeLogType()
        {
            ChangeLogs = new HashSet<ChangeLog>();
        }

		[Key]
		[StringLength(64)]
        public string ChangeLogTypeId { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

		[JsonIgnore]
        public virtual ICollection<ChangeLog> ChangeLogs { get; set; }
    }
}
