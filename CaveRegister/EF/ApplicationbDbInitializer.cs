using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using CaveRegister.Models;
using CaveRegister.Model;
using System.Data.Entity.Infrastructure;
using CaveRegister.DbInitialisers;

namespace CaveRegister.EF
{
	// This is useful if you do not want to tear down the database each time you run the application.
	//public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
	//{
	//	public override void InitializeDatabase(ApplicationDbContext context)
	//	{
	//			base.InitializeDatabase(context);
	//	}
	//}
	// This example shows you how to create a new database if the Model changes

	

	public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext> //CreateDatabaseIfNotExists //DropCreateDatabaseIfModelChanges
	{
		/*
		public override void InitializeDatabase(ApplicationDbContext context)
		{
			bool dbExists;
			
			dbExists = context.Database.Exists();
			
			if (dbExists)
			{
				// remove all tables
				context.Database.ExecuteSqlCommand("EXEC sp_MSforeachtable @command1 = \"DROP TABLE ?\"");

				// create all tables
				var dbCreationScript = ((IObjectContextAdapter)context).ObjectContext.CreateDatabaseScript();
				context.Database.ExecuteSqlCommand(dbCreationScript);

				Seed(context);
				context.SaveChanges();
			}
			else
			{
				throw new ApplicationException("No database instance");
			}
	  
	  

			//base.InitializeDatabase(context);
		}*/



		protected override void Seed(ApplicationDbContext context)
		{
			InitializeIdentityForEF(context);
			InitializeLookups(context);
			base.Seed(context);
		}

		static ApplicationUser systemUser;

		//Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
		public static void InitializeIdentityForEF(ApplicationDbContext db)
		{
			var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
			var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

			//ApplicationDbContext appContext = new ApplicationDbContext();
			//appContext.Clubs.Add(new CaveRegister.Models.Club() { Name = "SEC" });
			//appContext.SaveChanges();
			
			
			//Create Role Admin if it does not exist
			var role = roleManager.FindByName(Role.Admin);
			if (role == null)
			{
				role = new IdentityRole(Role.Admin);
				//var roleresult = roleManager.Create(role);

				roleManager.Create(role);
				roleManager.Create(new IdentityRole(Role.Contributor));
				roleManager.Create(new IdentityRole(Role.HighestSecrecy));
				roleManager.Create(new IdentityRole(Role.HighSecrecy));
				roleManager.Create(new IdentityRole(Role.LowSecrecy));
				roleManager.Create(new IdentityRole(Role.NormalSecrecy));
				roleManager.Create(new IdentityRole(Role.NotSecret));
				roleManager.Create(new IdentityRole(Role.Observer));
			}

			//var user = userManager.FindByName(name);

			ApplicationUser gerrieUser = userManager.FindByName(SystemAdmin.GerrieEmail); ;
			ApplicationUser stevenTuckerUser = userManager.FindByName(SystemAdmin.StevenEmail); 
			
			if (SystemAdmin.User == null)
			{
				systemUser = new ApplicationUser { UserName = SystemAdmin.Username, Name = SystemAdmin.Name, Surname = "System", Email = SystemAdmin.Email, ContactNumber = "01011010101", EmergencyContactDetails = "bill gates:", EmergencyMedicalDetails = "Blood-Type: binrary" };
				var systemUserResult = userManager.Create(systemUser, SystemAdmin.Password);
				systemUserResult = userManager.SetLockoutEnabled(systemUser.Id, false);
			}
			if(gerrieUser == null)
			{
				gerrieUser = new ApplicationUser { UserName = SystemAdmin.GerrieEmail, Name="Gerrie", Surname="Pretorius", Email = SystemAdmin.GerrieEmail, ContactNumber ="0784234261", EmergencyContactDetails="Roline Pretorius: 0606744515", EmergencyMedicalDetails="Blood-Type: O+"  };
				var result = userManager.Create(gerrieUser, "Cloud!82");
				result = userManager.SetLockoutEnabled(gerrieUser.Id, false);
			}
			if (stevenTuckerUser == null)
			{
				stevenTuckerUser = new ApplicationUser { UserName = "sjtucker135@gmail.com", Name = "Steven", Surname = "Tucker", Email = SystemAdmin.StevenEmail , ContactNumber = "0722989861", EmergencyContactDetails = "Irene Kruger 0724400062", EmergencyMedicalDetails = "CAMAF Vital 16738266" };
				var stevenUserResult = userManager.Create(stevenTuckerUser, "1DeepD@rkHole");
				stevenUserResult = userManager.SetLockoutEnabled(stevenTuckerUser.Id, false);

			}

			// Add user admin to Role Admin if not already added
			var rolesForUser = userManager.GetRoles(SystemAdmin.User.Id);
			if (!rolesForUser.Contains(role.Name))
			{
				userManager.AddToRole(SystemAdmin.User.Id, role.Name);
				userManager.AddToRole(gerrieUser.Id, role.Name);
				userManager.AddToRole(stevenTuckerUser.Id, role.Name);
			}

			
		}

		public static void InitializeLookups(ApplicationDbContext db)
		{

			//if (systemUser == null)
			//{
			//	var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
			//	systemUser = userManager.FindByName(SystemAdmin.Email);
			//}


			if (!db.CaveStatuses.Any(u => u.Description == "Cave"))
			{
				BoneTypeInitialiser.Ininitialise(db);
				CaveStatusInitialiser.Ininitialise(db);
				CaveAttributeInitialiser.Ininitialise(db);
				ChangeLogTypeInitialiser.Ininitialise(db);
				EaseOfAccessInitialser.Ininitialise(db);
				EntityStatusInitialiser.Ininitialise(db);
				CertificationLevelInitialiser.Ininitialise(db);
				RegionsInitialiser.Ininitialise(db);
				PotentialTypeInitialiser.Ininitialise(db);
				GeologyInitialiser.Ininitialise(db);

				db.ExplorationStatuses.Add(new ExplorationStatus() { Description = "Fully Explored - With Potential", ExplorationStatusId = ExplorationStatus.FullyExploredWithPotential });
				db.ExplorationStatuses.Add(new ExplorationStatus() { Description = "Fully Explored - No Potential", ExplorationStatusId = ExplorationStatus.FullyExploredNoPotential });
				db.ExplorationStatuses.Add(new ExplorationStatus() { Description = "Partially Explored", ExplorationStatusId = ExplorationStatus.PartiallyExplored });
				db.ExplorationStatuses.Add(new ExplorationStatus() { Description = ExplorationStatus.Potential, ExplorationStatusId = ExplorationStatus.Potential });
				db.ExplorationStatuses.Add(new ExplorationStatus() { Description = "No Potential", ExplorationStatusId = ExplorationStatus.NoPotential });
				db.ExplorationStatuses.Add(new ExplorationStatus() { Description = ExplorationStatus.Unexplored, ExplorationStatusId = ExplorationStatus.Unexplored });
				db.ExplorationStatuses.Add(new ExplorationStatus() { Description = ExplorationStatus.Unknown, ExplorationStatusId = ExplorationStatus.Unknown });

				db.FileTypes.Add(new FileType() { Description = FileType.Image, FileTypeID = FileType.Image });
				db.FileTypes.Add(new FileType() { Description = "Cover Image", FileTypeID = FileType.CoverImage });
				db.FileTypes.Add(new FileType() { Description = FileType.Document, FileTypeID = FileType.Document });
				db.FileTypes.Add(new FileType() { Description = "Kml Survey", FileTypeID = FileType.KmlSurvey });
				db.FileTypes.Add(new FileType() { Description = FileType.Survey, FileTypeID = FileType.Survey });
				db.FileTypes.Add(new FileType() { Description = "Survey Files & Measurements ", FileTypeID = FileType.SurveyFiles });
				db.FileTypes.Add(new FileType() { Description = FileType.Other, FileTypeID = FileType.Other });

				



				db.ObservableEntityTypes.Add(new ObservableEntityType() { ObservableEntityTypeId = ObservableEntityType.Other, Description = ObservableEntityType.Other, Name = ObservableEntityType.Other });
				db.ObservableEntityTypes.Add(new ObservableEntityType() { ObservableEntityTypeId = ObservableEntityType.Unknown, Description = ObservableEntityType.Unknown, Name = ObservableEntityType.Unknown });
				db.ObservableEntityTypes.Add(new ObservableEntityType() { ObservableEntityTypeId = ObservableEntityType.Bird, Description = ObservableEntityType.Bird, Name = ObservableEntityType.Bird });
				db.ObservableEntityTypes.Add(new ObservableEntityType() { ObservableEntityTypeId = ObservableEntityType.Bug, Description = ObservableEntityType.Bug, Name = ObservableEntityType.Bug });
				db.ObservableEntityTypes.Add(new ObservableEntityType() { ObservableEntityTypeId = ObservableEntityType.Reptile, Description = ObservableEntityType.Reptile, Name = ObservableEntityType.Reptile });
				db.ObservableEntityTypes.Add(new ObservableEntityType() { ObservableEntityTypeId = ObservableEntityType.Mammal, Description = ObservableEntityType.Mammal, Name = ObservableEntityType.Mammal });

				db.SaveChanges();


				db.ObservableEntities.Add(new ObservableEntity() { Name = "Bats - Unidentified", ScientificName = "Bats - Unidentified" , ObservableEntityTypeId = ObservableEntityType.Mammal, LasEditApplicationUserId = SystemAdmin.User.Id, LasEditApplicationUser = SystemAdmin.User});
				db.ObservableEntities.Add(new ObservableEntity() { Name = "Owl - Unidentified", ScientificName = "Owl - Unidentified", ObservableEntityTypeId = ObservableEntityType.Bird, LasEditApplicationUserId = SystemAdmin.User.Id, LasEditApplicationUser = SystemAdmin.User });

				db.LocationStatuses.Add(new LocationStatus() { Description = "Confirmed", LocationStatusId = LocationStatus.Confirmed });
				db.LocationStatuses.Add(new LocationStatus() { Description = "UnConfirmed", LocationStatusId = LocationStatus.UnConfirmed });
				db.LocationStatuses.Add(new LocationStatus() { Description = "Closed", LocationStatusId= LocationStatus.Closed });
				db.LocationStatuses.Add(new LocationStatus() { Description = "Missing", LocationStatusId = LocationStatus.Missing });
				db.LocationStatuses.Add(new LocationStatus() { Description = "Location from Goole Maps", LocationStatusId = LocationStatus.LocationFromGooleMaps });

				db.Mediums.Add(new Medium() { MediumId = Medium.CalcifiedBreccia, Name = "Calcified Brechia" });
				db.Mediums.Add(new Medium() { MediumId = Medium.DeCalcifiedBreccia, Name = "de-Calcified Brechia" });
				db.Mediums.Add(new Medium() { MediumId = Medium.Soil, Name = Medium.Soil });

				

				db.PublicationEntities.Add(new PublicationEntity() { Description = "SASA Bulletin" });
				db.PublicationEntities.Add(new PublicationEntity() { Description = "CROSA Bulletin" });
				db.PublicationEntities.Add(new PublicationEntity() { Description = "The Free Caver" });
				db.PublicationEntities.Add(new PublicationEntity() { Description = "SRT Magazine" });
				db.PublicationEntities.Add(new PublicationEntity() { Description = "SEC Website" });
				db.PublicationEntities.Add(new PublicationEntity() { Description = "Caving.co.za" });
				db.PublicationEntities.Add(new PublicationEntity() { Description = "Darklife.co.za" });

				db.SecrecyLevels.Add(new SecrecyLevel() { Description = "Highest", SecrecyLevelId = SecrecyLevel.Highest });
				db.SecrecyLevels.Add(new SecrecyLevel() { Description = "High", SecrecyLevelId = SecrecyLevel.High });
				db.SecrecyLevels.Add(new SecrecyLevel() { Description = "Normal", SecrecyLevelId = SecrecyLevel.Normal });
				db.SecrecyLevels.Add(new SecrecyLevel() { Description = "Low", SecrecyLevelId = SecrecyLevel.Low });
				db.SecrecyLevels.Add(new SecrecyLevel() { Description = "NotSecret", SecrecyLevelId = SecrecyLevel.NotSecret });

				db.SurveyGrades.Add(new SurveyGrade() { SurveyGradeId = SurveyGrade.Six, Name = SurveyGrade.Six });
				db.SurveyGrades.Add(new SurveyGrade() { SurveyGradeId = SurveyGrade.Five, Name = SurveyGrade.Five });
				db.SurveyGrades.Add(new SurveyGrade() { SurveyGradeId = SurveyGrade.Four, Name = SurveyGrade.Four });
				db.SurveyGrades.Add(new SurveyGrade() { SurveyGradeId = SurveyGrade.Three, Name = SurveyGrade.Three });
				db.SurveyGrades.Add(new SurveyGrade() { SurveyGradeId = SurveyGrade.Two, Name = SurveyGrade.Two });
				db.SurveyGrades.Add(new SurveyGrade() { SurveyGradeId = SurveyGrade.One, Name = SurveyGrade.One });
				db.SurveyGrades.Add(new SurveyGrade() { SurveyGradeId = SurveyGrade.X, Name = SurveyGrade.X });
				db.SurveyGrades.Add(new SurveyGrade() { SurveyGradeId = SurveyGrade.Unknown, Name = SurveyGrade.Unknown });

				db.SurveyTypes.Add(new SurveyType() { SurveyTypeId = SurveyType.Elevation, Name = SurveyType.Elevation });
				db.SurveyTypes.Add(new SurveyType() { SurveyTypeId = SurveyType.ExtendedElevation, Name = SurveyType.ExtendedElevation });
				db.SurveyTypes.Add(new SurveyType() { SurveyTypeId = SurveyType.KMLMap, Name = SurveyType.KMLMap });
				db.SurveyTypes.Add(new SurveyType() { SurveyTypeId = SurveyType.KMLModel, Name = SurveyType.KMLModel });
				db.SurveyTypes.Add(new SurveyType() { SurveyTypeId = SurveyType.LineSurvey, Name = SurveyType.LineSurvey });
				db.SurveyTypes.Add(new SurveyType() { SurveyTypeId = SurveyType.Plan, Name = SurveyType.Plan });
				db.SurveyTypes.Add(new SurveyType() { SurveyTypeId = SurveyType.Scanned, Name = SurveyType.Scanned });
				db.SurveyTypes.Add(new SurveyType() { SurveyTypeId = SurveyType.ThreeD, Name = SurveyType.ThreeD });
				db.SurveyTypes.Add(new SurveyType() { SurveyTypeId = SurveyType.Unknown, Name = SurveyType.Unknown });

				db.Terrains.Add(new Terrain() {  TerrainId= Terrain.FullDarkness, Name= Terrain.FullDarkness});
				db.Terrains.Add(new Terrain() { TerrainId = Terrain.Twilight, Name = Terrain.Twilight });
	
				

				db.SaveChanges();
			}
		}
	}
}