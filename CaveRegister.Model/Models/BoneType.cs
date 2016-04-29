namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("BoneType")]
    public partial class BoneType
    {
		public const string Carpal = "Carpal";
		public const string Tarsal = "Tarsal";
		public const string Teeth = "Teeth";
		public const string Canine = "Canine";
		public const string Incisor = "Incisor";
		public const string Molar = "Molar";
		public const string Premolar = "Premolar";
		public const string Metacarpal = "Metacarpal";
		public const string Metatarsal = "Metatarsal";
		public const string Cranium = "Cranium";
		public const string Mandible = "Mandible";
		public const string Maxilla = "Maxilla";
		public const string Humerus = "Humerus";
		public const string Ulna = "Ulna";
		public const string Radius = "Radius";
		public const string Vertibrae = "Vertibrae";
		public const string Scapula = "Scapula";
		public const string Pelvis = "Pelvis";
		public const string Clavicle = "Clavicle";
		public const string Phalanx = "Phalanx";
		public const string Tibia = "Tibia";
		public const string Fibula = "Fibula";
		public const string Femur = "Femur";
		public const string Sacrum = "Sacrum";
		public const string Rib = "Rib";
		public const string Talus = "Talus";
		public const string Astragulus = "Astragulus";
		public const string Calcaneus = "Calcaneus";
		public const string Sternum = "Sternum";
		public const string Horns = "Horns";
		public const string Patella = "Patella";

        public BoneType()
        {
            Cave_Fossils = new HashSet<Cave_Fossil>();
        }

        [StringLength(64)]
        public string BoneTypeId { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

		[JsonIgnore]
        public virtual ICollection<Cave_Fossil> Cave_Fossils { get; set; }
    }
}
