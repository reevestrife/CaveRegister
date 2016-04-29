namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	public partial class Cave_Fossil : Auditable
    {
        public Cave_Fossil()
        {
            MetaFiles = new HashSet<MetaFile>();
            BoneTypes = new HashSet<BoneType>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Cave_FossilId { get; set; }

        [Required]
        [StringLength(64)]
        public string FossilId { get; set; }

        [Required]
        [StringLength(64)]
        public string MediumId { get; set; }

        public int VisitHistoryId { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<MetaFile> MetaFiles { get; set; }

		[JsonIgnore]
        public virtual Fossil Fossil { get; set; }

        public virtual Medium Medium { get; set; }

		[JsonIgnore]
        public virtual VisitHistory VisitHistory { get; set; }

        public virtual ICollection<BoneType> BoneTypes { get; set; }
    }
}
