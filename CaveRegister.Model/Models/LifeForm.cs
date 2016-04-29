namespace CaveRegister.Model
{
	using CaveRegister.Model.Contracts;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("LifeForm")]
	public partial class LifeForm : Auditable, IEntityWithURL
    {
        public LifeForm()
        {
            ObservedCaveLives = new HashSet<ObservableEntity>();
        }

		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LifeFormId { get; set; }

		[Required]
		[StringLength(128)]
		public string LifeFormTypeId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string ScientificName { get; set; }

        public virtual ICollection<ObservableEntity> ObservedCaveLives { get; set; }

		public virtual LifeFormType LifeFormType { get; set; }

		public string URL
		{
			get { throw new NotImplementedException(); }
		}
	}
}
