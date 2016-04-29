namespace CaveRegister.Model
{
	using CaveRegister.Model.Contracts;
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("Entrance")]
	public partial class Entrance : Auditable
    {
        public int EntranceId { get; set; }

        public int CaveId { get; set; }

        [Required]
        public DbGeography GeoLocation { get; set; }

		public int Altitude { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public int? FileId { get; set; }

		[JsonIgnore]
        public virtual Cave Cave { get; set; }

		public virtual MetaFile MetaFile { get; set; }
    }
}
