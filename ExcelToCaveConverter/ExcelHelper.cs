using CaveRegister.Models;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;


namespace ExcelToCaveConverter.Helpers
{
	public class ExcelHelper
	{

		private static Microsoft.Office.Interop.Excel.Workbook MyBook = null;
		private Microsoft.Office.Interop.Excel.Application MyApp = null;
		private Microsoft.Office.Interop.Excel.Worksheet MySheet = null;
		private int lastRow;

		public ExcelHelper(string path)
		{
			MyApp = new Microsoft.Office.Interop.Excel.Application();
			MyApp.Visible = false;
			MyBook = MyApp.Workbooks.Open(path);
			MySheet = (Microsoft.Office.Interop.Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here
			lastRow = MySheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell).Row;
		//	lastRow = 11;
		}


	

		public List<ExcelCave> ReadExcelCavesFromExcel(ApplicationDbContext db)
		{
			try {
				List<ExcelCave> excelCaveList = new List<ExcelCave>();


				for (int index = 2; index <= lastRow; index++)
				{
					ExcelCave cave = new ExcelCave();
					//cave.CaveID = (-1*idIndex++);
					//var cells = MySheet.get_Range("A" + index.ToString(), "P" + index.ToString()).Cells;
					Microsoft.Office.Interop.Excel.Range cell = null;

					///SASACode - Name
					cell = MySheet.Cells[index, "A"];
					cave.Name = cell.Value != null ? cell.Text : "";

					///Type
					cell = MySheet.Cells[index, "B"];
					cave.Type = cell.Value != null ? cell.Text : "";

					/// Tourist
					cell = MySheet.Cells[index, "C"];
					cave.Tourist = cell.Value != null ? cell.Text : "";

					/// Pristine
					cell = MySheet.Cells[index, "D"];
					cave.Pristine = cell.Value != null ? cell.Text : "";

					/// Certification
					cell = MySheet.Cells[index, "E"];
					cave.Certification = cell.Value != null ? cell.Text : "";

					/// Short Description
					cell = MySheet.Cells[index, "F"];
					cave.ShortDescription = cell.Value != null ? cell.Text : "";

					///CaveFolder
					cell = MySheet.Cells[index, "G"];
					if (cell.Value != null)
					{
						Hyperlink folderHyperlink = cell.Hyperlinks.get_Item(1);
						cave.Folder = folderHyperlink.Address;
					}

					///References
					cell = MySheet.Cells[index, "H"];
					cave.References = cell.Value != null ? cell.Text : "";


					///TotalExtension
					cell = MySheet.Cells[index, "I"];
					cave.TotalExt = cell.Value != null ? cell.Text : "";

					///Horizontal
					cell = MySheet.Cells[index, "J"];
					cave.Horizontal = cell.Value != null ? cell.Text : "";

					///Depth
					cell = MySheet.Cells[index, "K"];
					cave.Depth = cell.Value != null ? cell.Text : "";

					///Survey
					cell = MySheet.Cells[index, "L"];
					cave.Survey = cell.Value != null ? cell.Text : "";

					///Drop
					cell = MySheet.Cells[index, "M"];
					cave.Drop = cell.Value != null ? cell.Text : "";

					///Climb
					cell = MySheet.Cells[index, "N"];
					cave.Climb = cell.Value != null ? cell.Text : "";

					///Dig
					cell = MySheet.Cells[index, "O"];
					cave.Dig = cell.Value != null ? cell.Text : "";

					///Squeeze
					cell = MySheet.Cells[index, "P"];
					cave.Squeeze = cell.Value != null ? cell.Text : "";

					///Scuba
					cell = MySheet.Cells[index, "Q"];
					cave.Scuba = cell.Value != null ? cell.Text : "";

					///Airflow
					cell = MySheet.Cells[index, "R"];
					cave.AirFlow = cell.Value != null ? cell.Text : "";

					///Potential
					cell = MySheet.Cells[index, "S"];
					cave.Potential = cell.Value != null ? cell.Text : "";

					///Ladder
					cell = MySheet.Cells[index, "T"];
					cave.Ladder = cell.Value != null ? cell.Text : "";

					///Navigation
					cell = MySheet.Cells[index, "U"];
					cave.Navigation = cell.Value != null ? cell.Text : "";

					///Flooding
					cell = MySheet.Cells[index, "V"];
					cave.Flooding = cell.Value != null ? cell.Text : "";

					///Gated
					cell = MySheet.Cells[index, "W"];
					cave.Gated = cell.Value != null ? cell.Text : "";

					///Unstable
					cell = MySheet.Cells[index, "X"];
					cave.Unstable = cell.Value != null ? cell.Text : "";

					///Squeeze2
					cell = MySheet.Cells[index, "Y"];
					cave.Squeeze2 = cell.Value != null ? cell.Text : "";

					///Climbs
					cell = MySheet.Cells[index, "Z"];
					cave.Climbs = cell.Value != null ? cell.Text : "";

					///BadAir
					cell = MySheet.Cells[index, "AA"];
					cave.BadAir = cell.Value != null ? cell.Text : "";

					///Scuba2
					cell = MySheet.Cells[index, "AB"];
					cave.Scuba2 = cell.Value != null ? cell.Text : "";

					///Sump
					cell = MySheet.Cells[index, "AC"];
					cave.Sump = cell.Value != null ? cell.Text : "";

					///Srt
					cell = MySheet.Cells[index, "AD"];
					cave.Srt = cell.Value != null ? cell.Text : "";

					///Challanges
					cell = MySheet.Cells[index, "AE"];
					cave.Challanges = cell.Value != null ? cell.Text : "";

					///Decorated
					cell = MySheet.Cells[index, "AF"];
					cave.Decorated = cell.Value != null ? cell.Text : "";

					///LandOwnerName
					cell = MySheet.Cells[index, "AG"];
					cave.LandOwnerName = cell.Value != null ? cell.Text : "";

					///LandOwnerPhone
					cell = MySheet.Cells[index, "AH"];
					cave.LandOwnerPhone = cell.Value != null ? cell.Text : "";

					///LandOwnerEmail
					cell = MySheet.Cells[index, "AI"];
					cave.LandOwnerEmail = cell.Value != null ? cell.Text : "";

					///Permission
					cell = MySheet.Cells[index, "AJ"];
					cave.Permission = cell.Value != null ? cell.Text : "";


					///SuperGroup
					cell = MySheet.Cells[index, "AK"];
					cave.SuperGroup = cell.Value != null ? cell.Text : "";

					///Group
					cell = MySheet.Cells[index, "AL"];
					cave.Group = cell.Value != null ? cell.Text : "";

					///Formation
					cell = MySheet.Cells[index, "AM"];
					cave.Formation = cell.Value != null ? cell.Text : "";

					///Member
					cell = MySheet.Cells[index, "AN"];
					cave.Member = cell.Value != null ? cell.Text : "";



					///RockType
					cell = MySheet.Cells[index, "AO"];
					cave.RockType = cell.Value != null ? cell.Text : "";

					///Horseshoe
					cell = MySheet.Cells[index, "AP"];
					cave.Horseshoe = cell.Value != null ? cell.Text : "";

					///Miniopterus
					cell = MySheet.Cells[index, "AQ"];
					cave.Miniopterus = cell.Value != null ? cell.Text : "";

					///FruitBat
					cell = MySheet.Cells[index, "AR"];
					cave.FruitBat = cell.Value != null ? cell.Text : "";

					///OtherBats
					cell = MySheet.Cells[index, "AS"];
					cave.OtherBats = cell.Value != null ? cell.Text : "";

					///Bats
					cell = MySheet.Cells[index, "AT"];
					cave.Bats = cell.Value != null ? cell.Text : "";

					///Snakes
					cell = MySheet.Cells[index, "AU"];
					cave.Snakes = cell.Value != null ? cell.Text : "";

					///Leopard
					cell = MySheet.Cells[index, "AV"];
					cave.Leopard = cell.Value != null ? cell.Text : "";

					///Antelope
					cell = MySheet.Cells[index, "AW"];
					cave.Antelope = cell.Value != null ? cell.Text : "";

					///Porcupine
					cell = MySheet.Cells[index, "AX"];
					cave.Porcupine = cell.Value != null ? cell.Text : "";

					///Baboons
					cell = MySheet.Cells[index, "AY"];
					cave.Baboons = cell.Value != null ? cell.Text : "";

					///Hyena
					cell = MySheet.Cells[index, "AZ"];
					cave.Hyena = cell.Value != null ? cell.Text : "";

					///Dassie
					cell = MySheet.Cells[index, "BA"];
					cave.Dassie = cell.Value != null ? cell.Text : "";

					///Owl
					cell = MySheet.Cells[index, "BB"];
					cave.Owl = cell.Value != null ? cell.Text : "";

					///Birds
					cell = MySheet.Cells[index, "BC"];
					cave.Birds = cell.Value != null ? cell.Text : "";

					///Fish
					cell = MySheet.Cells[index, "BD"];
					cave.Fish = cell.Value != null ? cell.Text : "";

					///Civet
					cell = MySheet.Cells[index, "BE"];
					cave.Civet = cell.Value != null ? cell.Text : "";

					///Warthog
					cell = MySheet.Cells[index, "BF"];
					cave.Warthog = cell.Value != null ? cell.Text : "";

					///Frogs
					cell = MySheet.Cells[index, "BG"];
					cave.Frogs = cell.Value != null ? cell.Text : "";

					///Habitation
					cell = MySheet.Cells[index, "BH"];
					cave.Habitation = cell.Value != null ? cell.Text : "";

					///CellarSpider
					cell = MySheet.Cells[index, "BI"];
					cave.CellarSpider = cell.Value != null ? cell.Text : "";

					///CaveSpider
					cell = MySheet.Cells[index, "BJ"];
					cave.CaveSpider = cell.Value != null ? cell.Text : "";

					///Spiders
					cell = MySheet.Cells[index, "BK"];
					cave.Spiders = cell.Value != null ? cell.Text : "";

					///Earwigs
					cell = MySheet.Cells[index, "BL"];
					cave.Earwigs = cell.Value != null ? cell.Text : "";

					///Cockroach
					cell = MySheet.Cells[index, "BM"];
					cave.Cockroach = cell.Value != null ? cell.Text : "";

					///Pseudoscorpion
					cell = MySheet.Cells[index, "BN"];
					cave.Pseudoscorpion = cell.Value != null ? cell.Text : "";

					///Pillbugs
					cell = MySheet.Cells[index, "BO"];
					cave.Pillbugs = cell.Value != null ? cell.Text : "";

					///Shrimp
					cell = MySheet.Cells[index, "BP"];
					cave.Shrimp = cell.Value != null ? cell.Text : "";

					///TermiteTunnels
					cell = MySheet.Cells[index, "BQ"];
					cave.TermiteTunnels = cell.Value != null ? cell.Text : "";

					///Silverfish
					cell = MySheet.Cells[index, "BR"];
					cave.Silverfish = cell.Value != null ? cell.Text : "";

					///Centipede
					cell = MySheet.Cells[index, "BS"];
					cave.Centipede = cell.Value != null ? cell.Text : "";

					///Beetle
					cell = MySheet.Cells[index, "BT"];
					cave.Beetle = cell.Value != null ? cell.Text : "";

					///DungBeetle
					cell = MySheet.Cells[index, "BU"];
					cave.DungBeetle = cell.Value != null ? cell.Text : "";

					///Muggies
					cell = MySheet.Cells[index, "BV"];
					cave.Muggies = cell.Value != null ? cell.Text : "";

					///FlyingBugs
					cell = MySheet.Cells[index, "BW"];
					cave.FlyingBugs = cell.Value != null ? cell.Text : "";

					///Bees
					cell = MySheet.Cells[index, "BX"];
					cave.Bees = cell.Value != null ? cell.Text : "";

					///Crustacean
					cell = MySheet.Cells[index, "BY"];
					cave.Crustacean = cell.Value != null ? cell.Text : "";

					///Cricket
					cell = MySheet.Cells[index, "BZ"];
					cave.Cricket = cell.Value != null ? cell.Text : "";

					///CacoonsInWebs
					cell = MySheet.Cells[index, "CA"];
					cave.CacoonsInWebs = cell.Value != null ? cell.Text : "";

					///InsectPods
					cell = MySheet.Cells[index, "CB"];
					cave.InsectPods = cell.Value != null ? cell.Text : "";

					///Fleas
					cell = MySheet.Cells[index, "CC"];
					cave.Fleas = cell.Value != null ? cell.Text : "";

					///AssassinBug
					cell = MySheet.Cells[index, "CD"];
					cave.AssassinBug = cell.Value != null ? cell.Text : "";

					///Snail
					cell = MySheet.Cells[index, "CE"];
					cave.Snail = cell.Value != null ? cell.Text : "";

					///Worm
					cell = MySheet.Cells[index, "CF"];
					cave.Worm = cell.Value != null ? cell.Text : "";

					///Harvestman
					cell = MySheet.Cells[index, "CG"];
					cave.Harvestman = cell.Value != null ? cell.Text : "";

					///BugLife
					cell = MySheet.Cells[index, "CH"];
					cave.BugLife = cell.Value != null ? cell.Text : "";

					///Guano
					cell = MySheet.Cells[index, "CI"];
					cave.Guano = cell.Value != null ? cell.Text : "";

					///Calcite
					cell = MySheet.Cells[index, "CJ"];
					cave.Calcite = cell.Value != null ? cell.Text : "";

					///Copper
					cell = MySheet.Cells[index, "CK"];
					cave.Copper = cell.Value != null ? cell.Text : "";

					///Mining
					cell = MySheet.Cells[index, "CL"];
					cave.Mining = cell.Value != null ? cell.Text : "";

					///PerchedWater
					cell = MySheet.Cells[index, "CM"];
					cave.PerchedWater = cell.Value != null ? cell.Text : "";

					///WaterTable
					cell = MySheet.Cells[index, "CN"];
					cave.WaterTable = cell.Value != null ? cell.Text : "";

					///Stream
					cell = MySheet.Cells[index, "CO"];
					cave.Stream = cell.Value != null ? cell.Text : "";

					///IntermittentStream
					cell = MySheet.Cells[index, "CP"];
					cave.IntermittentStream = cell.Value != null ? cell.Text : "";

					///Water
					cell = MySheet.Cells[index, "CQ"];
					cave.Water = cell.Value != null ? cell.Text : "";

					///FossilHominin
					cell = MySheet.Cells[index, "CR"];
					cave.FossilHominin = cell.Value != null ? cell.Text : "";

					///FossilBaboon
					cell = MySheet.Cells[index, "CS"];
					cave.FossilBaboon = cell.Value != null ? cell.Text : "";

					///FossilOtherPrimate
					cell = MySheet.Cells[index, "CT"];
					cave.FossilOtherPrimate = cell.Value != null ? cell.Text : "";

					///FossilPrimate
					cell = MySheet.Cells[index, "CU"];
					cave.FossilPrimate = cell.Value != null ? cell.Text : "";

					///FossilCanid
					cell = MySheet.Cells[index, "CV"];
					cave.FossilCanid = cell.Value != null ? cell.Text : "";

					///FossilHyena
					cell = MySheet.Cells[index, "CW"];
					cave.FossilHyena = cell.Value != null ? cell.Text : "";

					///FossilFelid
					cell = MySheet.Cells[index, "CX"];
					cave.FossilFelid = cell.Value != null ? cell.Text : "";

					///FossilCarnivore
					cell = MySheet.Cells[index, "CY"];
					cave.FossilCarnivore = cell.Value != null ? cell.Text : "";

					///FossilSuid
					cell = MySheet.Cells[index, "CZ"];
					cave.FossilSuid = cell.Value != null ? cell.Text : "";

					///FossilEquid
					cell = MySheet.Cells[index, "DA"];
					cave.FossilEquid = cell.Value != null ? cell.Text : "";

					///FossilBovid
					cell = MySheet.Cells[index, "DB"];
					cave.FossilBovid = cell.Value != null ? cell.Text : "";

					///FossilMicroFauna
					cell = MySheet.Cells[index, "DC"];
					cave.FossilMicroFauna = cell.Value != null ? cell.Text : "";

					///Fossils
					cell = MySheet.Cells[index, "DD"];
					cave.Fossils = cell.Value != null ? cell.Text : "";

					///Pottery
					cell = MySheet.Cells[index, "DE"];
					cave.Pottery = cell.Value != null ? cell.Text : "";

					///RockPainting
					cell = MySheet.Cells[index, "DF"];
					cave.RockPainting = cell.Value != null ? cell.Text : "";

					///Structures
					cell = MySheet.Cells[index, "DG"];
					cave.Structures = cell.Value != null ? cell.Text : "";

					///MiningEquipment
					cell = MySheet.Cells[index, "DH"];
					cave.MiningEquipment = cell.Value != null ? cell.Text : "";

					///Tools
					cell = MySheet.Cells[index, "DI"];
					cave.Tools = cell.Value != null ? cell.Text : "";

					///Archealogical
					cell = MySheet.Cells[index, "DJ"];
					cave.Archealogical = cell.Value != null ? cell.Text : "";

					///ModernBones
					cell = MySheet.Cells[index, "DK"];
					cave.ModernBones = cell.Value != null ? cell.Text : "";

					///Location
					cell = MySheet.Cells[index, "DL"];
					cave.Location = cell.Value != null ? cell.Text : "";

					///Province
					cell = MySheet.Cells[index, "DM"];
					cave.Province = cell.Value != null ? cell.Text : "";

					///Country
					cell = MySheet.Cells[index, "DN"];
					cave.Country = cell.Value != null ? cell.Text : "";

					///E1Elevation
					cell = MySheet.Cells[index, "DO"];
					cave.E1Elevation = cell.Value != null ? cell.Text : "";

					///E1Lat
					cell = MySheet.Cells[index, "DP"];
					cave.E1Lat = cell.Value != null ? cell.Text : "";

					///E1Long
					cell = MySheet.Cells[index, "DQ"];
					cave.E1Long = cell.Value != null ? cell.Text : "";

					///E2Elevation
					cell = MySheet.Cells[index, "DR"];
					cave.E2Elevation = cell.Value != null ? cell.Text : "";

					///E2Lat
					cell = MySheet.Cells[index, "DS"];
					cave.E2Lat = cell.Value != null ? cell.Text : "";

					///E2Long
					cell = MySheet.Cells[index, "DT"];
					cave.E2Long = cell.Value != null ? cell.Text : "";

					///E3Elevation
					cell = MySheet.Cells[index, "DU"];
					cave.E3Elevation = cell.Value != null ? cell.Text : "";

					///E3Lat
					cell = MySheet.Cells[index, "DV"];
					cave.E3Lat = cell.Value != null ? cell.Text : "";

					///E3Long
					cell = MySheet.Cells[index, "DW"];
					cave.E3Long = cell.Value != null ? cell.Text : "";

					///E4Elevation
					cell = MySheet.Cells[index, "DX"];
					cave.E4Elevation = cell.Value != null ? cell.Text : "";

					///E4Lat
					cell = MySheet.Cells[index, "DY"];
					cave.E4Lat = cell.Value != null ? cell.Text : "";

					///E4Long
					cell = MySheet.Cells[index, "DZ"];
					cave.E4Long = cell.Value != null ? cell.Text : "";

					///E5Elevation
					cell = MySheet.Cells[index, "EA"];
					cave.E5Elevation = cell.Value != null ? cell.Text : "";

					///E5Lat
					cell = MySheet.Cells[index, "EB"];
					cave.E5Lat = cell.Value != null ? cell.Text : "";

					///E5Long
					cell = MySheet.Cells[index, "EC"];
					cave.E5Long = cell.Value != null ? cell.Text : "";

					///Entrances
					cell = MySheet.Cells[index, "ED"];
					cave.Entrances = cell.Value != null ? cell.Text : "";

					///Status
					cell = MySheet.Cells[index, "EE"];
					cave.Status = cell.Value != null ? cell.Text : "";

					excelCaveList.Add(cave);
				}

				return excelCaveList;
			}
			catch(Exception ex)
			{

				throw ex;
			}
		}


		public void write()
		{
			//lastRow += 1;
			//MySheet.Cells[lastRow, 1] = emp.Name;
			//MySheet.Cells[lastRow, 2] = emp.Employee_ID;
			//MySheet.Cells[lastRow, 3] = emp.Email_ID;
			//MySheet.Cells[lastRow, 4] = emp.Number;
			//EmpList.Add(emp);
			//MyBook.Save(); 

			//MyBook.Save();
			//MyBook.Close();

		}
	}
}