using CaveRegister.Model;
using CaveRegister.Models;
using System.Data.Entity.Migrations;

namespace CaveRegister.DbInitialisers
{
	public class GeologyInitialiser
	{
		public static void Ininitialise(ApplicationDbContext db)
		{
			///Rock Type
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.GiantChert, Name = "Giant Chert" });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.Breccia, Name = Geology.Breccia });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.Dolomite, Name = Geology.Dolomite });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.LimeStone, Name = Geology.LimeStone });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.SandstoneQuartzite, Name = "Sandstone Quartzite" });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.Shale, Name = Geology.Shale });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.Marble, Name = Geology.Marble });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.Quartzite, Name = Geology.Quartzite });
			///Super Group
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.TransvaalSuperGroup, Name = "Transvaal SuperGroup" });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.WolkbergSuperGroup, Name = "Wolkberg SuperGroup" });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.WaterbergSuperGroup, Name = "Waterberg SuperGroup" });
			///Group
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.ChuniespoortGroup, Name = "Chuniespoort Group" });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.WaterbergGroup, Name = "Waterberg Group" });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.PretoriaGroup, Name = "Pretoria Group" });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.BlackReefGroup, Name = "BlackReef Group" });
			///Formations
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.MonteChristoFormation, Name = "MonteChristo Formation" });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.EcclesFormation, Name = "Eccles Formation" });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.BlackReefFormation, Name = "Black Reef Formation" });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.LytteltonFomration, Name = "Lyttelton Fomration" });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.OaktreeFormation, Name = "Oaktree Formation" });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.FriscoFormation, Name = "Frisco Formation" });
			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.MatjiesRiverFormation, Name = "MatjiesRiver Formation" });

			db.Geologies.AddOrUpdate(new Geology() { GeologyId = Geology.RooihoogteFormation, Name = "Rooihoogte Formation" });
			

			
		}
	}
}