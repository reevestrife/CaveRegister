using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveRegister.Model
{
	public class CaveAttribute
	{
		public const string Airflow = "Airflow";
		public const string CaveLife = "CaveLife";
		public const string CaverBobsCanidate = "CaverBobsCanidate";
		public const string CO2 = "CO2";
		public const string Challanges = "Challanges";
		public const string Climb = "Climb";
		public const string Decorated = "Decorated";
		public const string Pitch = "Pitch";
		public const string Fossils = "Fossils";
		public const string Flooding = "Flooding";
		public const string Gated = "Gated";
		public const string Ladder = "Ladder";
		public const string Mined = "Mined";
		public const string Navigation = "Navigation";
		public const string Scuba = "Scuba";
		public const string SRT = "SRT";
		public const string Squeeze = "Squeeze";
		public const string Sump = "Sump";
		public const string Unstable = "Unstable";
		public const string Tourist = "Tourist";
		public const string Pristine = "Pristine";


		//Water
		public const string Water = "Water";
		public const string PerchedWater = "PerchedWater";
		public const string WaterTable = "WaterTable";
		public const string WaterStream = "WaterStream";
		public const string IntermittentStream = "IntermittentStream";


		//Mining
		public const string GuanoMining = "GuanoMining";
		public const string CalciteMining = "CalciteMining";
		public const string CopperMining = "CopperMining";
		public const string Mining = "Mining";

		//Archealogical

		public const string Archeaological = "Archeaological";
		public const string Pottery = "Pottery";
		public const string RockPainting = "RockPainting";
		public const string ArcheaologicalStructures = "ArcheaologicalStructures";
		public const string MiningEquipment = "MiningEquipment";
		public const string ArcheaologicalTools = "ArcheaologicalTools";

		public const string MordernBones = "MordernBones";

		public CaveAttribute()
		{
			Caves = new HashSet<Cave>();
		}

		[Key]
		[StringLength(64)]
		public string CaveAttributeId { get; set; }

		[Required]
		[StringLength(64)]
		public string Description { get; set; }

		[JsonIgnore]
		public virtual ICollection<Cave> Caves { get; set; }

		
	}
}
