using CaveRegister.Model;
using CaveRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaveRegister.DbInitialisers
{
	public static class CaveAttributeInitialiser
	{
		public static void Ininitialise(ApplicationDbContext db)
		{
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Airflow, Description = CaveAttribute.Airflow });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.CaveLife, Description = CaveAttribute.CaveLife });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.CaverBobsCanidate, Description = "Caver Bobs Canidate" });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.CO2, Description = CaveAttribute.CO2 });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Challanges, Description = CaveAttribute.Challanges });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Climb, Description = CaveAttribute.Climb });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Decorated, Description = CaveAttribute.Decorated });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Pitch, Description = CaveAttribute.Pitch });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Fossils, Description = CaveAttribute.Fossils });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Flooding, Description = CaveAttribute.Flooding });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Gated, Description = CaveAttribute.Gated });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Ladder, Description = CaveAttribute.Ladder });
			
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Navigation, Description = CaveAttribute.Navigation });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Scuba, Description = CaveAttribute.Scuba });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.SRT, Description = CaveAttribute.SRT });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Squeeze, Description = CaveAttribute.Squeeze });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Sump, Description = CaveAttribute.Sump });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Unstable, Description = CaveAttribute.Unstable });
			
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Tourist, Description = "Tourist Cave" });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Pristine, Description = CaveAttribute.Pristine });

			//Mining
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.GuanoMining, Description = "Guano Mining" });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.CalciteMining, Description = "Calcite Mining" });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.CopperMining, Description = "Copper Mining" });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Mined, Description = CaveAttribute.Mined });

			//Water
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Water, Description = CaveAttribute.Water });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.PerchedWater, Description = "Perched Water" });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.WaterTable, Description = "Water Table" });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.WaterStream, Description = "Water Stream" });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.IntermittentStream, Description = "Intermittent Stream" });

			//Archealogical
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Archeaological, Description = CaveAttribute.Archeaological });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.Pottery, Description = CaveAttribute.Pottery });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.RockPainting, Description = "Rock Painting" });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.ArcheaologicalStructures, Description = "Archeaological Structures" });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.MiningEquipment, Description = "Mining Equipment" });
			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.ArcheaologicalTools, Description = "Archeaological Tools" });

			db.CaveAttributes.Add(new CaveAttribute() { CaveAttributeId = CaveAttribute.MordernBones, Description = "Mordern Bones" });
		}
	}
}