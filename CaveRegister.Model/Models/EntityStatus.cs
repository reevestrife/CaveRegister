namespace CaveRegister.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EntityStatus")]
    public partial class EntityStatus
    {
		public const string AwaitingApproval = "AwaitingApproval";
		public const string AwaitingDeleteApproval = "AwaitingDeleteApproval";
		public const string Stable = "Stable";

        [StringLength(64)]
        public string EntityStatusId { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }
    }
}
