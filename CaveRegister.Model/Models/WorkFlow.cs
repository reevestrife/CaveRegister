namespace CaveRegister.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

	[Table("History")]
    public partial class History
    {
		[Key]
        public int HistoryId { get; set; }

        public int EntityId { get; set; }

        [Required]
        [StringLength(64)]
        public string EntityType { get; set; }

        [Required]
        public string SerialisedChanges { get; set; }

        public DateTime ChangeDate { get; set; }

        [Required]
        [StringLength(128)]
        public string ChangedByUserId { get; set; }
    }
}
