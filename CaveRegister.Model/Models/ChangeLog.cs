namespace CaveRegister.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChangeLog")]
    public partial class ChangeLog
    {
        public int ChangeLogId { get; set; }

        public string ChangeLogTypeId { get; set; }

        [Required]
        [StringLength(256)]
        public string Description { get; set; }

        public virtual ChangeLogType ChangeLogType { get; set; }
    }
}
