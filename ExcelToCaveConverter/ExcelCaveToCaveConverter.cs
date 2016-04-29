using CaveRegister.Helpers;
using CaveRegister.Model;
using CaveRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ExcelToCaveConverter.Helpers
{
	public class ExcelCaveToCaveConverter
	{
		public List<LocationStatus> LocationStatusList { get; set; }
		public List<Province> ProvinceList { get; set; }
		public List<CaveStatus> CaveStatusList { get; set; }
		public List<CaveAttribute> CaveAttributes { get; set; }
		public List<PotentialType> PotentialTypes { get; set; }
		public List<EaseOfAccess> EaseOfAccesses { get; set; }
		public List<CertificationLevel> CertificationLevels { get; set; }
		public List<Geology> Geologies { get; set; }

		public StringBuilder NotConverted = new StringBuilder();


		public ExcelCaveToCaveConverter(ApplicationDbContext db)
		{
			CaveAttributes = db.CaveAttributes.ToList();
			CaveStatusList = db.CaveStatuses.ToList();
			EaseOfAccesses = db.EaseOfAccesses.ToList();
			LocationStatusList = db.LocationStatuses.ToList();
			PotentialTypes = db.Potentials.ToList();
			ProvinceList = db.Provinces.ToList();
			CertificationLevels = db.CertificationLevels.ToList();
			Geologies = db.Geologies.ToList();
		}

		public Cave ConvertToCave(ExcelCave excelCave)
		{
			Cave cave = new Cave();

			//SASACode - Name
			if (!string.IsNullOrEmpty(excelCave.Name))
			{

				int firstSpace = excelCave.Name.IndexOf(' ');
				if (firstSpace > 0)
				{
					cave.SasaCode = excelCave.Name.Substring(0, firstSpace);
					cave.Name = excelCave.Name.Replace(cave.SasaCode, "").Trim();
				}
				else
				{
					cave.Name = excelCave.Name;
				}

			}
			else cave.Name = "-";


			//Type
			if (!string.IsNullOrEmpty(excelCave.Type))
			{
				var statusWords = excelCave.Type.Split(' ');
				foreach (var word in statusWords)
				{
					var caveStatus = CaveStatusList.FirstOrDefault(p => p.Description.ToLower() == word.ToLower());
					if (caveStatus != null)
					{
						cave.CaveStatuses.Add(caveStatus);
					}
					else
					{
						NotConverted.AppendLine($"\"{cave.DisplayName}\" Status:\"{word}\" could not be found as a cave status");
					}
				}
			}

			//Tourist
			if (excelCave.Tourist.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Tourist));
			}

			//Pristine
			if (excelCave.Pristine.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Pristine));
				cave.CertificationLevels.Add(CertificationLevels.FirstOrDefault(p => p.CertificationLevelId == CertificationLevel.Pristine));
			}

			//Certification Level
			if (excelCave.Certification.Trim() == CertificationLevel.Advanced)
			{
				cave.CertificationLevels.Add(CertificationLevels.FirstOrDefault(p => p.CertificationLevelId == CertificationLevel.Advanced));
			}
			if (excelCave.Certification.Trim() == CertificationLevel.Horizontal)
			{
				cave.CertificationLevels.Add(CertificationLevels.FirstOrDefault(p => p.CertificationLevelId == CertificationLevel.Horizontal));
			}
			if (excelCave.Certification.Trim() == CertificationLevel.Pristine)
			{
				cave.CertificationLevels.Add(CertificationLevels.FirstOrDefault(p => p.CertificationLevelId == CertificationLevel.Pristine));
			}
			if (excelCave.Certification.Trim() == CertificationLevel.Scuba)
			{
				cave.CertificationLevels.Add(CertificationLevels.FirstOrDefault(p => p.CertificationLevelId == CertificationLevel.Scuba));
			}
			if (excelCave.Certification.Trim() == CertificationLevel.Tourist)
			{
				cave.CertificationLevels.Add(CertificationLevels.FirstOrDefault(p => p.CertificationLevelId == CertificationLevel.Tourist));
			}
			if (excelCave.Certification.Trim() == CertificationLevel.Vertical)
			{
				cave.CertificationLevels.Add(CertificationLevels.FirstOrDefault(p => p.CertificationLevelId == CertificationLevel.Vertical));
			}


			//Short Description
			cave.Description = excelCave.ShortDescription;

			///CaveFolder
			cave.Folder = excelCave.Folder;
			//if (cell.Value != null)
			//{
			//	Hyperlink folderHyperlink = cell.Hyperlinks.get_Item(1);
			//	cave.Folder = folderHyperlink.Address;
			//}

			///References
			cave.Reference = excelCave.References;

			//TotalExtension
			try
			{
				if (!string.IsNullOrWhiteSpace(excelCave.TotalExt))
				{
					cave.TotalExtension = Convert.ToDouble(excelCave.TotalExt.Trim());
				}
			}
			catch (Exception ex)
			{
				var caveStatus = CaveStatusList.FirstOrDefault(p => p.Description.ToLower() == excelCave.TotalExt.ToLower());
				if (caveStatus != null)
				{
					if (!cave.CaveStatuses.Contains(caveStatus))
					{
						cave.CaveStatuses.Add(caveStatus);
					}
				}
				else
				{
					NotConverted.AppendLine($"Could not convert TotalExtension: {excelCave.TotalExt} for cave \"{cave.DisplayName}\"");
				}
			}

			///Horizontal
			try
			{
				if (!string.IsNullOrWhiteSpace(excelCave.Horizontal))
				{
					cave.HorizontalExtent = Convert.ToDouble(excelCave.Horizontal.Trim());
				}
			}
			catch (Exception ex)
			{
				var caveStatus = CaveStatusList.FirstOrDefault(p => p.Description.ToLower() == excelCave.Horizontal.ToLower());
				if (caveStatus != null)
				{
					if (!cave.CaveStatuses.Contains(caveStatus))
					{
						cave.CaveStatuses.Add(caveStatus);
					}
				}
				else
				{
					NotConverted.AppendLine($"Could not convert Horizontal: {excelCave.Horizontal} for cave \"{cave.DisplayName}\"");
				}
			}

			///Depth
			try
			{
				if (!string.IsNullOrWhiteSpace(excelCave.Depth))
				{
					cave.HorizontalExtent = Convert.ToDouble(excelCave.Depth.Trim());
				}
			}
			catch (Exception ex)
			{
				var caveStatus = CaveStatusList.FirstOrDefault(p => p.Description.ToLower() == excelCave.Depth.ToLower());
				if (caveStatus != null)
				{
					if (!cave.CaveStatuses.Contains(caveStatus))
					{
						cave.CaveStatuses.Add(caveStatus);
					}
				}
				else
				{
					NotConverted.AppendLine($"Could not convert Depth: {excelCave.Depth} for cave \"{cave.DisplayName}\"");
				}
			}

			//Survey - Skipping survey column for now.

			// Drop - Airflow (Column M to R) refers to Potential for the cave.
			//Drop
			if (excelCave.Drop.ToLower().Trim() == "yes")
			{
				var cave_Potential = new Cave_Potential();
				cave_Potential.PotentialType = PotentialTypes.FirstOrDefault(p => p.PotentialTypeId == PotentialType.Drop);
				cave.Cave_Potential.Add(cave_Potential);
			}

			///Climb
			if (excelCave.Climb.ToLower().Trim() == "yes")
			{
				var cave_Potential = new Cave_Potential();
				cave_Potential.PotentialType = PotentialTypes.FirstOrDefault(p => p.PotentialTypeId == PotentialType.Climb);
				cave.Cave_Potential.Add(cave_Potential);
			}

			///Dig
			if (excelCave.Dig.ToLower().Trim() == "yes")
			{
				var cave_Potential = new Cave_Potential();
				cave_Potential.PotentialType = PotentialTypes.FirstOrDefault(p => p.PotentialTypeId == PotentialType.Dig);
				cave.Cave_Potential.Add(cave_Potential);
			}

			///Squeeze
			if (excelCave.Squeeze.ToLower().Trim() == "yes")
			{
				var cave_Potential = new Cave_Potential();
				cave_Potential.PotentialType = PotentialTypes.FirstOrDefault(p => p.PotentialTypeId == PotentialType.Squeeze);
				cave.Cave_Potential.Add(cave_Potential);
			}

			///Scuba
			if (excelCave.Scuba.ToLower().Trim() == "yes")
			{
				var cave_Potential = new Cave_Potential();
				cave_Potential.PotentialType = PotentialTypes.FirstOrDefault(p => p.PotentialTypeId == PotentialType.Scuba);
				cave.Cave_Potential.Add(cave_Potential);
			}

			///Airflow
			if (excelCave.AirFlow.ToLower().Trim() == "yes")
			{
				var cave_Potential = new Cave_Potential();
				cave_Potential.PotentialType = PotentialTypes.FirstOrDefault(p => p.PotentialTypeId == PotentialType.Airflow);
				cave.Cave_Potential.Add(cave_Potential);
			}
			//End of potential columns....
			//Potential - Leaving out for now. 

			///Ladder
			if (excelCave.Ladder.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Ladder));
			}

			///Navigation
			if (excelCave.Navigation.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Navigation));
			}

			///Flooding
			if (excelCave.Flooding.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Flooding));
			}

			///Gated
			if (excelCave.Gated.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Gated));
			}

			///Unstable
			if (excelCave.Unstable.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Unstable));
			}

			///Squeeze
			if (excelCave.Squeeze2.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Squeeze));
			}

			///Climbs
			if (excelCave.Climbs.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Climb));
			}

			///Bad air
			if (excelCave.BadAir.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.CO2));
			}

			///SCUBA
			if (excelCave.Scuba2.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Scuba));
			}

			///SCUBA
			if (excelCave.Sump.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Sump));
			}

			///Srt
			if (excelCave.Srt.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.SRT));
			}

			// Ignore challanges column.


			///Descorated
			if (excelCave.Decorated.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Decorated));
			}

			//Landowener name
			cave.LandOwnerName = excelCave.LandOwnerName;

			//LandOwnerPhone
			cave.LandOwnerPhone = excelCave.LandOwnerPhone;

			//LandOwnerEmail
			cave.LandOwnerEmail = excelCave.LandOwnerEmail;


			///Permission
			switch (excelCave.Permission.Trim().ToLower())
			{
				case "":
				case "unknown":
				case "uncertain":
					{
						cave.EaseOfAccesses.Add(EaseOfAccesses.FirstOrDefault(p => p.EaseOfAccessId == EaseOfAccess.Unknown));
						break;
					}
				case "yes":
					{
						cave.EaseOfAccesses.Add(EaseOfAccesses.FirstOrDefault(p => p.EaseOfAccessId == EaseOfAccess.Easy));
						break;
					}

				case "no":
					{
						cave.EaseOfAccesses.Add(EaseOfAccesses.FirstOrDefault(p => p.EaseOfAccessId == EaseOfAccess.Forbidden));
						break;
					}

				case "tourist":
					{
						cave.EaseOfAccesses.Add(EaseOfAccesses.FirstOrDefault(p => p.EaseOfAccessId == EaseOfAccess.Tourist));
						break;
					}

				case "permit":
					{
						cave.EaseOfAccesses.Add(EaseOfAccesses.FirstOrDefault(p => p.EaseOfAccessId == EaseOfAccess.Permit));
						break;
					}

				case "possible":
					{
						cave.EaseOfAccesses.Add(EaseOfAccesses.FirstOrDefault(p => p.EaseOfAccessId == EaseOfAccess.Difficult));
						break;
					}
				case "research":
					{
						cave.EaseOfAccesses.Add(EaseOfAccesses.FirstOrDefault(p => p.EaseOfAccessId == EaseOfAccess.ResearchOnly));
						break;
					}

				default:
					{
						NotConverted.AppendLine($"Could not convert Permission: {excelCave.Permission} for cave \"{cave.DisplayName}\"");
						break;
					}
			}


			///Supergroup
			switch (excelCave.SuperGroup.Trim().ToLower())
			{
				case "": break;

				case "transvaal":
					{
						cave.Geologies.Add(Geologies.First(p => p.GeologyId == Geology.TransvaalSuperGroup));
						break;
					}

				case "wolkberg":
					{
						cave.Geologies.Add(Geologies.First(p => p.GeologyId == Geology.WolkbergSuperGroup));
						break;
					}

				case "waterberg":
					{
						cave.Geologies.Add(Geologies.First(p => p.GeologyId == Geology.WaterbergSuperGroup));
						break;
					}

				default:
					{
						NotConverted.AppendLine($"Could not convert Supergroup: \"{excelCave.SuperGroup}\" for cave \"{cave.DisplayName}\"");
						break;
					}
			}

			//GROUP
			switch (excelCave.Group.Trim().ToLower())
			{
				case "": break;

				case "chuniespoort":
					{
						cave.Geologies.Add(Geologies.First(p => p.GeologyId == Geology.ChuniespoortGroup));
						break;
					}
				case "waterberg":
					{
						cave.Geologies.Add(Geologies.First(p => p.GeologyId == Geology.WaterbergGroup));
						break;
					}
				case "pretoria":
					{
						cave.Geologies.Add(Geologies.First(p => p.GeologyId == Geology.PretoriaGroup));
						break;
					}
				case "black reef":
				case "blackreef":
					{
						cave.Geologies.Add(Geologies.First(p => p.GeologyId == Geology.BlackReefGroup));
						break;
					}
				default:
					{
						NotConverted.AppendLine($"Could not convert Group: \"{excelCave.Group}\" for cave \"{cave.DisplayName}\"");
						break;
					}
			}

			//Formation
			foreach (var formation in excelCave.Formation.Trim().ToLower().Split('-'))
			{
				var geologyFormation = Geologies.FirstOrDefault(p => p.GeologyId.Replace("Formation", "").ToLower() == formation.Trim());
				if (geologyFormation != null)
				{
					cave.Geologies.Add(geologyFormation);
				}
				else
				{
					switch (formation.Trim())
					{
						case "": break;

						case "eccles":
							{
								cave.Geologies.Add(Geologies.First(p => p.GeologyId == Geology.EcclesFormation));
								break;
							}
						case "monte christo":
							{
								cave.Geologies.Add(Geologies.First(p => p.GeologyId == Geology.MonteChristoFormation));
								break;
							}
						case "black reef":
							{
								cave.Geologies.Add(Geologies.First(p => p.GeologyId == Geology.BlackReefFormation));
								break;
							}
						case "lyttleton":
							{
								cave.Geologies.Add(Geologies.First(p => p.GeologyId == Geology.LytteltonFomration));
								break;
							}
						case "matjies river":
							{
								cave.Geologies.Add(Geologies.First(p => p.GeologyId == Geology.MatjiesRiverFormation));
								break;
							}

						case "rooihoogte":
							{
								cave.Geologies.Add(Geologies.First(p => p.GeologyId == Geology.RooihoogteFormation));
								break;
							}
						default:
							{
								NotConverted.AppendLine($"Could not convert Foramtion: \"{excelCave.Formation}\" for cave \"{cave.DisplayName}\"");
								break;
							}
					}
				}
			}

			//Rock type
			foreach (var rockType in excelCave.RockType.Trim().ToLower().Split('/'))
			{
				var geologyRockType = Geologies.FirstOrDefault(p => p.Name.ToLower() == rockType);
				if (geologyRockType != null)
				{
					cave.Geologies.Add(geologyRockType);
				}
				else
				{
					switch (rockType.Trim())
					{
						case "": break;
						default:
							{
								NotConverted.AppendLine($"Could not convert RockType: \"{excelCave.RockType}\" for cave \"{cave.DisplayName}\"");
								break;
							}
					}
				}
			}


			///Guano Mining
			if (excelCave.Guano.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.GuanoMining));
			}

			///Calcite Mining
			if (excelCave.Calcite.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.CalciteMining));
			}

			///Copper Mining
			if (excelCave.Copper.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.CopperMining));
			}

			///Mining
			if (excelCave.Mining.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Mined));
			}


			///PerchedWater
			if (excelCave.PerchedWater.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.PerchedWater));
			}

			///WaterTable
			if (excelCave.WaterTable.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.WaterTable));
			}

			///Stream
			if (excelCave.Stream.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.WaterStream));
			}

			///Water
			if (excelCave.Water.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Water));
			}

			///Pottery
			if (excelCave.Pottery.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Pottery));
			}

			///RockPainting
			if (excelCave.RockPainting.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.RockPainting));
			}

			///Structures
			if (excelCave.Structures.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.ArcheaologicalStructures));
			}

			///MiningEquipment
			if (excelCave.MiningEquipment.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.MiningEquipment));
			}

			///ArcheaologicalTools
			if (excelCave.Tools.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.ArcheaologicalTools));
			}

			///Archeaological
			if (excelCave.Archealogical.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Archeaological));
			}

			///Archeaological
			if (excelCave.Archealogical.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.Archeaological));
			}

			///MordernBones
			if (excelCave.ModernBones.ToLower().Trim() == "yes")
			{
				cave.CaveAttributes.Add(CaveAttributes.FirstOrDefault(p => p.CaveAttributeId == CaveAttribute.MordernBones));
			}

			//Location
			cave.Location = excelCave.Location;




			string provinceText;
			switch (excelCave.Province.Trim().ToLower())
			{
				case "north west":
					{
						provinceText = "north-west";
						break;
					}

				case "free state":
					{
						provinceText = "freestate";
						break;
					}

				case "":
					{
						provinceText = Province.Unknown.ToLower();
						break;
					}
				default:
					{
						provinceText = excelCave.Province.Trim().ToLower();
						break;
					}
			}

			var province = ProvinceList.FirstOrDefault(p => p.Description.ToLower() == provinceText);
			if (province == null)
			{
				NotConverted.AppendLine($"Could not convert Province: \"{excelCave.Province}\" for cave \"{cave.DisplayName}\"");
				cave.ProvinceId = Province.Unknown;
			}
			else
			{
				cave.ProvinceId = province.ProvinceId;
			}




			Entrance entrance;

			entrance = CreateEntrance(excelCave.E1Elevation, excelCave.E1Long, excelCave.E1Lat,cave.Name, 1, ref NotConverted);//Entrnace 1
			if (entrance != null)
			{
				cave.Entrances.Add(entrance);
				cave.DbGeography_LandOwner = entrance.GeoLocation;
			}

			entrance = CreateEntrance(excelCave.E2Elevation, excelCave.E2Long, excelCave.E2Lat, cave.Name,2, ref NotConverted);//Entrnace 2
			if (entrance != null)
			{
				cave.Entrances.Add(entrance);
				cave.DbGeography_LandOwner = entrance.GeoLocation;
			}

			entrance = CreateEntrance(excelCave.E3Elevation, excelCave.E3Long, excelCave.E2Lat, cave.Name,3, ref NotConverted);//Entrnace 3
			if (entrance != null)
			{
				cave.Entrances.Add(entrance);
				cave.DbGeography_LandOwner = entrance.GeoLocation;
			}

			entrance = CreateEntrance(excelCave.E4Elevation, excelCave.E4Long, excelCave.E2Lat, cave.Name, 4, ref NotConverted);//Entrnace 4
			if (entrance != null)
			{
				cave.Entrances.Add(entrance);
				cave.DbGeography_LandOwner = entrance.GeoLocation;
			}

			entrance = CreateEntrance(excelCave.E5Elevation, excelCave.E5Long, excelCave.E2Lat, cave.Name, 5, ref NotConverted);//Entrnace 5
			if (entrance != null)
			{
				cave.Entrances.Add(entrance);
				cave.DbGeography_LandOwner = entrance.GeoLocation;
			}




			if (cave.TotalExtension > 0)
			{
				cave.CaveStatuses.Add(CaveStatusList.First(p => p.CaveStatusId == CaveStatus.Cave));
			}
			if (cave.Description.ToLower().Contains("sinkhole"))
			{
				cave.CaveStatuses.Add(CaveStatusList.First(p => p.CaveStatusId == CaveStatus.Sinkhole));
			}
			if (cave.Description.ToLower().Contains("blow") || cave.Description.ToLower().Contains("airflow"))
			{
				cave.CaveStatuses.Add(CaveStatusList.First(p => p.CaveStatusId == CaveStatus.BlowingHole));
			}


			var status = LocationStatusList.FirstOrDefault(p => p.LocationStatusId.ToLower() == excelCave.Status.ToLower().Trim());
			if(status != null)
			{
				cave.LocationStatusId = status.LocationStatusId;
				cave.LocationStatus = status;
			}
			else
			{
				NotConverted.AppendLine($"Could not convert Status: \"{excelCave.Status}\" for cave \"{cave.DisplayName}\"");
			}

			return cave;

		}

		private Entrance CreateEntrance(string elevationString, string longitudeString, string lattitudeString,string caveName, int entranceNumber, ref StringBuilder conversionResult)
		{
			string caveEntranceName = caveName;
			if (entranceNumber > 1)
			{
				caveEntranceName += " E" + entranceNumber.ToString();

			}
			 
			string[] exludedWords = new string[] { "N/A", "YES", "UNCERTAIN" };
			double? elevation = null;
			double? lattitude = null;
			double? longitude = null;

			if (!string.IsNullOrEmpty(elevationString))
			{
				if (exludedWords.Contains(elevationString.ToUpper()))
				{
					//cant make this a double... just ignore..
					elevation = null;
				}
				else
				{
					try
					{
						elevation = double.Parse(elevationString);
					}
					catch (Exception)
					{
						NotConverted.AppendLine($"Could not convert Elevation: \"{elevationString}\" for cave entrance \"{caveEntranceName}\"");

					}
				}
			}
			else
			{
				elevation = null;
			}



			if (!string.IsNullOrEmpty(lattitudeString))
			{
				if (exludedWords.Contains(lattitudeString.ToUpper()))
				{
					//cant make this a double... just ignore..
					lattitude = null;
				}
				else
				{
					try
					{
						lattitude = GeographyHelpers.DMStoDecimal(lattitudeString);
					}
					catch (Exception)
					{
						NotConverted.AppendLine($"Could not convert lattitude: \"{lattitudeString}\" for cave entrance \"{caveEntranceName}\"");
					}
				}
			}
			else
			{
				lattitude = null;
			}



			if (!string.IsNullOrEmpty(longitudeString))
			{
				if (exludedWords.Contains(longitudeString.ToUpper()))
				{
					//cant make this a double... just ignore..
					longitude = null;
				}
				else
				{
					try
					{
						longitude = GeographyHelpers.DMStoDecimal(longitudeString);
					}
					catch (Exception)
					{
						NotConverted.AppendLine($"Could not convert lattitude: \"{longitudeString}\" for cave entrance \"{caveEntranceName}\"");
					}
				}
			}
			else
			{
				longitude = null;
			}

			if (longitude.HasValue && lattitude.HasValue)
			{
				try
				{
					Entrance entrance = new Entrance();
					if (elevation.HasValue)
					{
						entrance.GeoLocation = GeographyHelpers.ToDbGeography(lattitude.Value, longitude.Value, elevation.Value);

					}
					else
					{
						entrance.GeoLocation = GeographyHelpers.ToDbGeography(lattitude.Value, longitude.Value);
					}
					entrance.Name = caveEntranceName;
					return entrance;
				}
				catch (Exception ex)
				{
					NotConverted.AppendLine($"Could not create DbGFeography from : lattitude:\"{lattitude}\" longitude:\"{longitude}\" for cave entrance \"{caveEntranceName}\"");
				}
			}
			return null;
		}
	}
}