namespace CaveRegister.Model
{
	using CaveRegister.Model.Contracts;
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("Cave")]
	public partial class Cave : Auditable, IEntityWithURL
    {
        public Cave()
        {
            Articles = new HashSet<Article>();
            CaveStatuses = new HashSet<CaveStatus>();
			CaveAttributes = new HashSet<CaveAttribute>();
			Cave_Potential = new HashSet<Cave_Potential>();
			CertificationLevels = new HashSet<CertificationLevel>();

			Entrances = new HashSet<Entrance>();
			Surveys = new HashSet<Survey>();
			Geologies = new HashSet<Geology>();
			EaseOfAccesses = new HashSet<EaseOfAccess>();
			MetaFiles = new HashSet<MetaFile>();
			VisitHistories = new HashSet<VisitHistory>();

			//Cave_Articles = new HashSet<Cave_Article>();
			//Cave_CaveAttributes = new HashSet<Cave_CaveAttribute>();
			//Cave_CaveStatuses = new HashSet<Cave_CaveStatus>();


			ExplorationStatusId = ExplorationStatus.Unknown;
			//LastEditDate = DateTime.Now;
			DateCreated = DateTime.Now;
			LocationStatusId = LocationStatus.UnConfirmed;
			ProvinceId = Province.Unknown;
        }
		[Key]
        public int CaveId { get; set; }

        [StringLength(10)]
        public string SasaCode { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

		[DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [StringLength(256)]
		[Display(Name = "Folder link")]
        public string Folder { get; set; }

		[Display(Name = "Litrature References")]
        public string Reference { get; set; }

		[Display(Name = "Total Extension")]
        public double? TotalExtension { get; set; }

		public double? Depth { get; set; }

		public double? HorizontalExtent { get; set; }

        [Required]
        [StringLength(64)]
		[Display(Name = "Province")]
        public string ProvinceId { get; set; }

        [StringLength(1000)]
        public string Location { get; set; }

        [StringLength(128)]
		[Display(Name = "Land owner name")]
        public string LandOwnerName { get; set; }

        [StringLength(128)]
		[Display(Name = "Land owner phone")]
		[DataType(DataType.PhoneNumber)]
        public string LandOwnerPhone { get; set; }

        [StringLength(128)]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Land owner email")]
        public string LandOwnerEmail { get; set; }

		[Display(Name = "Landowner Geography")]
		public DbGeography DbGeography_LandOwner { get; set; }

		[Display(Name = "Land owner details")]
		[DataType(DataType.MultilineText)]
        public string LandOwnerDetails { get; set; }

        [Required]
        [StringLength(64)]
		[Display(Name="Exploration Status")]
        public string ExplorationStatusId { get; set; }

		[Required]
		[StringLength(64)]
		[Display(Name = "Location Status")]
		public string LocationStatusId { get; set; }

		

		/// <summary>
		/// Indicate that this location is confirmed to be nothing, and have no interist to the caving community.
		/// This will usualy be a tree with nothing underneath, not even a depression.
		/// </summary>
		public bool IsNothing { get; set; }

		public virtual ICollection<Cave_Potential> Cave_Potential { get; set; }

		[Display(Name = "Exploration Status")]
        public virtual ExplorationStatus ExplorationStatus { get; set; }

		public virtual LocationStatus LocationStatus { get; set; }

        public virtual Province Province { get; set; }

		public virtual ICollection<MetaFile> MetaFiles { get; set; }

		[JsonIgnore]
        public virtual ICollection<VisitHistory> VisitHistories { get; set; }

		public virtual ICollection<Entrance> Entrances { get; set; }

		public virtual ICollection<Survey> Surveys { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

		[Display(Name = "Status")]
		public virtual ICollection<CaveStatus> CaveStatuses { get; set; }

		public virtual ICollection<EaseOfAccess> EaseOfAccesses { get; set; }

		[Display(Name = "Attributes")]
		public virtual ICollection<CaveAttribute> CaveAttributes { get; set; }

		public virtual ICollection<Geology> Geologies { get; set; }

		[Display(Name = "Certification Levels")]
		public virtual ICollection<CertificationLevel> CertificationLevels { get; set; }

		public string DisplayName
		{
			get
			{
				return String.Concat(Name?? "", (SasaCode != null) ? (string.Concat(" (",SasaCode,")")) : "");
			}
		}

		public string URL
		{
			get { return string.Concat("Caves/Details/", this.CaveId); }
		}
	}
}
