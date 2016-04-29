using CaveRegister.DbInitialisers;
using CaveRegister.Models;
using ExcelToCaveConverter.Helpers;
using System;
using System.IO;
using System.Windows.Forms;

namespace ExcelToCaveConverter
{
	public partial class Form1 : Form
	{
		ApplicationDbContext db = new ApplicationDbContext();
		ExcelCaveContext excelDb = new ExcelCaveContext();
		public Form1()
		{
			InitializeComponent();
		}

		private void btnConvertExcelCaveToCave_Click(object sender, EventArgs e)
		{
			ConvertExcelCaveToCave();
		}


		public string ConvertExcelCaveToCave()
		{
			using (var dbContextTransaction = db.Database.BeginTransaction())
			{
				var excelCaveCOnverter = new ExcelCaveToCaveConverter(db);

				foreach (var excelCave in excelDb.ExcelCaves)
				{
					var cave = excelCaveCOnverter.ConvertToCave(excelCave);
					db.Caves.Add(cave);
				}
				File.WriteAllText("c:\\temp\\excelCaveCOnverter.NotConverted.txt", excelCaveCOnverter.NotConverted.ToString());
				db.SaveChanges();
			}
			db.SaveChanges();
			return "done";
		}


		private bool ImportExcel(string userID)
		{
			string excelfilepath = ("~/App_Data/SASA Cave Register.xlsx");
			ExcelHelper eh = new ExcelHelper(excelfilepath);

			var listOfExcelCaves = eh.ReadExcelCavesFromExcel(db);

			excelDb.ExcelCaves.AddRange(listOfExcelCaves);
			excelDb.SaveChanges();
			return true;
		}

		private void btnInitLookups_Click(object sender, EventArgs e)
		{
			GeologyInitialiser.Ininitialise(db);
			CaveStatusInitialiser.Ininitialise(db);
			db.SaveChanges();
		}
	}
}
