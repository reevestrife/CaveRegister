namespace CaveRegister.Model
{
	using CaveRegister.Model.Contracts;
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table("ObservableEntity")]
	public partial class ObservableEntity : Auditable, IEntityWithURL
    {
        public ObservableEntity()
        {
            Observations = new HashSet<Observation>();
        }

		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ObservableEntityId { get; set; }

		[Required]
		[StringLength(128)]
		public string ObservableEntityTypeId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string ScientificName { get; set; }

		[StringLength(128)]
		public string UnitOfMeasure { get; set; }

		[JsonIgnore]
        public virtual ICollection<Observation> Observations { get; set; }

		public virtual ObservableEntityType ObservableEntityType { get; set; }

		public string URL
		{
			get { return "NotImplementedException()"; }
		}
	}
}
