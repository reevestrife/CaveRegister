namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

    [Table("Geology")]
    public partial class Geology
	{

		#region RockType
		public const string SandstoneQuartzite = "SandstoneQuartzite";
		public const string Dolomite = "Dolomite";
		public const string GiantChert = "GiantChert";
		public const string Breccia = "Breccia";

		public const string Shale = "Shale";
		public const string LimeStone = "LimeStone";
		public const string Marble = "Marble";
		public const string Quartzite = "Quartzite";
		#endregion

		#region SuperGroup
		public const string TransvaalSuperGroup = "TransvaalSuperGroup";
		public const string WolkbergSuperGroup = "WolkbergSuperGroup";
		public const string WaterbergSuperGroup = "WaterbergSuperGroup";
		#endregion

		#region Group
		public const string ChuniespoortGroup = "ChuniespoortGroup";
		public const string WaterbergGroup = "WaterbergGroup";
		public const string PretoriaGroup = "PretoriaGroup";
		public const string BlackReefGroup = "BlackReefGroup";
		#endregion

		#region Formation

		public const string MonteChristoFormation = "MonteChristoFormation";
		public const string EcclesFormation = "EcclesFormation";
		public const string BlackReefFormation = "BlackReefFormation";
		public const string LytteltonFomration = "LytteltonFomration";
		public const string OaktreeFormation = "OaktreeFormation";
		public const string FriscoFormation = "FriscoFormation";
		public const string MatjiesRiverFormation = "MatjiesRiverFormation";
		public const string RooihoogteFormation = "Rooihoogte";
		
		#endregion

		#region Member

		public const string RietspruitMember = "RietspruitMember";

		#endregion

		public Geology()
        {
            Caves = new HashSet<Cave>();
        }

        public string GeologyId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

		[JsonIgnore]
        public virtual ICollection<Cave> Caves { get; set; }
    }
}
