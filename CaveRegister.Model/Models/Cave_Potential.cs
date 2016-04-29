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

        [Required]
        [StringLength(64)]
        public string PotentialId { get; set; }

        [Required]
        public string Description { get; set; }

		[JsonIgnore]
        public virtual Cave Cave { get; set; }

        public virtual PotentialType PotentialType { get; set; }
    }
}
