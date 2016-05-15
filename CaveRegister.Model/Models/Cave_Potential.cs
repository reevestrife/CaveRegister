namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    public partial class Cave_Potential: Auditable
    {
        public int Cave_PotentialId { get; set; }

        public int CaveId { get; set; }
		[JsonIgnore]
		public virtual Cave Cave { get; set; }
		
		[Required]
		[StringLength(64)]
		public string PotentialTypeId { get; set; }
		public virtual PotentialType PotentialType { get; set; }

		public string Description { get; set; }
	}
}
