using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using CaveRegister.Model;
using CaveRegister.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Metadata.Edm;
using System.Web;
using CaveRegister.Helpers;
using System.Linq;
using CaveRegister.Model.Contracts;
using System.Data.Entity.Validation;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CaveRegister.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

		public virtual DbSet<Article> Articles { get; set; }
		public virtual DbSet<ArticleAttribute> ArticleAttributes { get; set; }
		public virtual DbSet<BoneType> BoneTypes { get; set; }
		public virtual DbSet<Cave> Caves { get; set; }
		public virtual DbSet<Cave_Fossil> Cave_Fossil { get; set; }
		public virtual DbSet<Cave_Potential> Cave_Potential { get; set; }
		public virtual DbSet<CaveAttribute> CaveAttributes { get; set; }
		public virtual DbSet<CaveStatus> CaveStatuses { get; set; }
		public virtual DbSet<CertificationLevel> CertificationLevels { get; set; }
		public virtual DbSet<ChangeLog> ChangeLogs { get; set; }
		public virtual DbSet<ChangeLogType> ChangeLogTypes { get; set; }
		
		public virtual DbSet<Country> Countries { get; set; }
		public virtual DbSet<EaseOfAccess> EaseOfAccesses { get; set; }
		public virtual DbSet<EntityStatus> EntityStatuses { get; set; }
		public virtual DbSet<Entrance> Entrances { get; set; }

		public virtual DbSet<ExcelCave> ExcelCave { get; set; }
		public virtual DbSet<ExplorationStatus> ExplorationStatuses { get; set; }
		public virtual DbSet<File> Files { get; set; }
		public virtual DbSet<FileType> FileTypes { get; set; }
		public virtual DbSet<Fossil> Fossils { get; set; }
		public virtual DbSet<Geology> Geologies { get; set; }
		public virtual DbSet<LocationStatus> LocationStatuses { get; set; }
		public virtual DbSet<Medium> Mediums { get; set; }
		public virtual DbSet<MetaFile> MetaFiles { get; set; }
		public virtual DbSet<ObservableEntity> ObservableEntities { get; set; }
		public virtual DbSet<ObservableEntityType> ObservableEntityTypes { get; set; }
		public virtual DbSet<Observation> Observations { get; set; }
		public virtual DbSet<PotentialType> Potentials { get; set; }
		public virtual DbSet<Province> Provinces { get; set; }
		public virtual DbSet<Publication> Publications { get; set; }
		public virtual DbSet<PublicationEntity> PublicationEntities { get; set; }
		public virtual DbSet<SecrecyLevel> SecrecyLevels { get; set; }
		public virtual DbSet<Survey> Surveys { get; set; }
		public virtual DbSet<SurveyGrade> SurveyGrades { get; set; }
		public virtual DbSet<SurveyType> SurveyTypes { get; set; }
		public virtual DbSet<Terrain> Terrains { get; set; }
		public virtual DbSet<VisitHistory> VisitHistories { get; set; }
		public virtual DbSet<History> Histories { get; set; }
        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

		//public IEnumerable<string> GetPrimaryKeys(DbEntityEntry entry)
		//{
		//	EntitySetBase setBase = ApplicationDbContext.ObjectStateManager
		//.GetObjectStateEntry(entry.Entity).EntitySet;

		//	string[] keyNames = setBase.ElementType.KeyMembers.Select(k => k.Name).ToArray();
		//	string keyName;
		//	if (keyNames != null)
		//		keyName = keyNames.FirstOrDefault();
		//	else
		//		keyName = "(NotFound)";
		//}

		IEnumerable<string> GetPrimaryKeyValue(DbEntityEntry entry)
		{
			var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
			EntitySetBase setBase = objectStateEntry.EntitySet;

			IEnumerable<string> keyNames = setBase.ElementType.KeyMembers.Select(k => k.Name);
			return keyNames;
		}

		

		public override int SaveChanges()
		{
			var context = this;
			var Changed = ChangeTracker.Entries();
			if (Changed != null)
			{
				foreach (var entry in Changed) //.Where(e => e.State == EntityState.Deleted)
				{
					var entityType = entry.Entity.GetType();
					var props = entityType.GetProperties();
					var descProp = props.Where(p => p.Name.ToLower() == "description").FirstOrDefault();
					{
						if(descProp != null)
						{

						}
					}

					if (entry.State != EntityState.Unchanged)
					{
						//entry.State = EntityState.Unchanged;
						if (entry.Entity is Auditable)
						{
							var auditable = entry.Entity as Auditable;
							auditable.LastEditDate = System.DateTime.Now;

							string currentUserID = SystemAdmin.User.Id; ///Set so that there is a user
							if (HttpContext.Current.User != null)
							{
								currentUserID = HttpContext.Current.User.Identity.GetUserId();
								//bm.LasEditApplicationUserI = this.Users.FirstOrDefault(p => p.Id == currentUserID);
								auditable.LasEditApplicationUserId = currentUserID ?? SystemAdmin.User.Id;
							}
							if (entry.State == System.Data.Entity.EntityState.Added)
							{
								auditable.DateCreated = System.DateTime.Now;
							}
							else if (entry.State == System.Data.Entity.EntityState.Modified || entry.State == System.Data.Entity.EntityState.Added)
							{
								auditable.LastEditDate = DateTime.Now;

								History history = new History();
								history.ChangeDate = DateTime.Now;
								history.ChangedByUserId = currentUserID;
								history.EntityId = (int)this.GetEntityKey(auditable).EntityKeyValues.FirstOrDefault().Value;  //(int)entry.Property(GetPrimaryKeyName(auditable.GetType()).CurrentValue;
								history.EntityType = auditable.GetType().FullName;
								history.SerialisedChanges = Newtonsoft.Json.JsonConvert.SerializeObject(auditable);
								auditable.History = history;
							}

							if (auditable.EntityStatusId == null)
							{
								auditable.EntityStatusId = EntityStatus.Stable;
							}

							if (auditable.SecrecyLevelId == 0)
							{
								auditable.SecrecyLevelId = SecrecyLevel.Normal;
							}

						}

					}
					//create adutitable history for record if record is a cave
					
					//if (entry.Entity is Cave && entry.State != System.Data.Entity.EntityState.Deleted)
					//{
					//	Type type = entry.Entity.GetType();
					//	CaveEditHistory caveEditHistory = new CaveEditHistory();
					//	Copy(entry.Entity, caveEditHistory);

					//	var cave = (Cave)entry.Entity;

					//	caveEditHistory.CaveStatuses = String.Join(",", cave.CaveStatuses.Select(p => p.Description).ToArray());
					//	caveEditHistory.CaveAttributes = String.Join(",", cave.CaveAttributes.Select(p => p.Description).ToArray());
					//	context.CaveEditHistories.Add(caveEditHistory);
					//}
					

					if (entry.State == System.Data.Entity.EntityState.Deleted && entry.Entity is ISoftDelete)
					{
						SoftDelete(entry);
					}
				}
			}

			try
			{
				return base.SaveChanges();
			}
			catch (DbEntityValidationException ex)
			{
				// Retrieve the error messages as a list of strings.
				var errorMessages = ex.EntityValidationErrors
						.SelectMany(x => x.ValidationErrors)
						.Select(x => x.ErrorMessage);

				// Join the list to a single string.
				var fullErrorMessage = string.Join("; ", errorMessages);

				// Combine the original exception message with the new one.
				var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

				// Throw a new DbEntityValidationException with the improved exception message.
				throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
			}
		}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


			#region BaseModel LastEnditUser

			modelBuilder.Entity<Article>()
				.HasOptional(e => e.LasEditApplicationUser)
				.WithMany(e => e.LastEditArticles)
				.HasForeignKey(e => e.LasEditApplicationUserId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Cave>()
				.HasOptional(e => e.LasEditApplicationUser)
				.WithMany(e => e.LastEditCaves)
				.HasForeignKey(e => e.LasEditApplicationUserId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Cave_Fossil>()
				.HasOptional(e => e.LasEditApplicationUser)
				.WithMany(e => e.LastEditCave_Fossils)
				.HasForeignKey(e => e.LasEditApplicationUserId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Cave_Potential>()
				.HasOptional(e => e.LasEditApplicationUser)
				.WithMany(e => e.LastEditCave_Potentials)
				.HasForeignKey(e => e.LasEditApplicationUserId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Entrance>()
				.HasOptional(e => e.LasEditApplicationUser)
				.WithMany(e => e.LastEditEntrances)
				.HasForeignKey(e => e.LasEditApplicationUserId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ObservableEntity>()
				.HasOptional(e => e.LasEditApplicationUser)
				.WithMany(e => e.LastEditObservableEntities)
				.HasForeignKey(e => e.LasEditApplicationUserId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<MetaFile>()
				.HasOptional(e => e.LasEditApplicationUser)
				.WithMany(e => e.LastEditMetaFiles)
				.HasForeignKey(e => e.LasEditApplicationUserId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Observation>()
				.HasOptional(e => e.LasEditApplicationUser)
				.WithMany(e => e.LastEditObservations)
				.HasForeignKey(e => e.LasEditApplicationUserId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Survey>()
				.HasOptional(e => e.LasEditApplicationUser)
				.WithMany(e => e.LastEditSurveys)
				.HasForeignKey(e => e.LasEditApplicationUserId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<VisitHistory>()
				.HasOptional(e => e.LasEditApplicationUser)
				.WithMany(e => e.LastEditVisitHistories)
				.HasForeignKey(e => e.LasEditApplicationUserId)
				.WillCascadeOnDelete(false);

			#endregion

			modelBuilder.Entity<Article>()
			.Map(m => m.Requires("IsDeleted").HasValue(false))
			.Ignore(m => m.IsDeleted);

			modelBuilder.Entity<Article>()
				.HasMany(e => e.MetaFiles)
				.WithMany(e => e.Articles)
				.Map(m => m.ToTable("Article_MetaFile").MapLeftKey("ArticleId").MapRightKey("FileId"));

			modelBuilder.Entity<Article>()
				.HasMany(e => e.ArticleAttributes)
				.WithMany(e => e.Articles)
				.Map(m => m.ToTable("Article_ArticleAttribute").MapLeftKey("ArticleId").MapRightKey("ArticleAttributeId"));

			modelBuilder.Entity<Article>()
				.HasMany(e => e.Caves)
				.WithMany(e => e.Articles)
				.Map(m => m.ToTable("Cave_Article").MapLeftKey("ArticleId").MapRightKey("CaveId"));

			modelBuilder.Entity<Article>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Article>()
				.Property(e => e.Source)
				.IsUnicode(false);

			modelBuilder.Entity<Article>()
				.Property(e => e.Author)
				.IsUnicode(false);

			modelBuilder.Entity<Article>()
				.Property(e => e.Tags)
				.IsUnicode(false);

			modelBuilder.Entity<ArticleAttribute>()
				.Property(e => e.ArticleAttributeId)
				.IsUnicode(false);

			modelBuilder.Entity<ArticleAttribute>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<BoneType>()
			.Property(e => e.BoneTypeId)
			.IsUnicode(false);

			modelBuilder.Entity<BoneType>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<BoneType>()
				.HasMany(e => e.Cave_Fossils)
				.WithMany(e => e.BoneTypes)
				.Map(m => m.ToTable("Cave_Fossil_BoneType").MapLeftKey("BoneTypeId").MapRightKey("Cave_FossilId"));

			modelBuilder.Entity<Cave>()
				.Map(m => m.Requires("IsDeleted").HasValue(false))
				.Ignore(m => m.IsDeleted);

			modelBuilder.Entity<Cave>()
				.Property(e => e.SasaCode)
				.IsUnicode(false);

			modelBuilder.Entity<Cave>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Cave>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<Cave>()
				.Property(e => e.Folder)
				.IsUnicode(false);

			modelBuilder.Entity<Cave>()
				.Property(e => e.Reference)
				.IsUnicode(false);

			modelBuilder.Entity<Cave>()
				.Property(e => e.ProvinceId)
				.IsUnicode(false);

			modelBuilder.Entity<Cave>()
				.Property(e => e.Location)
				.IsUnicode(false);

			modelBuilder.Entity<Cave>()
				.Property(e => e.LandOwnerName)
				.IsUnicode(false);

			modelBuilder.Entity<Cave>()
				.Property(e => e.LandOwnerPhone)
				.IsUnicode(false);

			modelBuilder.Entity<Cave>()
				.Property(e => e.LandOwnerEmail)
				.IsUnicode(false);

			modelBuilder.Entity<Cave>()
				.Property(e => e.LandOwnerDetails)
				.IsUnicode(false);

			modelBuilder.Entity<Cave>()
				.Property(e => e.ExplorationStatusId)
				.IsUnicode(false);

			modelBuilder.Entity<Cave>()
				.Property(e => e.LocationStatusId)
				.IsUnicode(false);

			modelBuilder.Entity<Cave>()
				.HasMany(e => e.Cave_Potential)
				.WithRequired(e => e.Cave)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Cave>()
				.HasMany(e => e.Entrances)
				.WithRequired(e => e.Cave)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Cave>()
				.HasMany(e => e.Surveys)
				.WithRequired(e => e.Cave)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Cave>()
				.HasMany(e => e.CaveAttributes)
				.WithMany(e => e.Caves)
				.Map(m => m.ToTable("Cave_Attribute").MapLeftKey("CaveId").MapRightKey("CaveAttributeId"));

			modelBuilder.Entity<Cave>()
				.HasMany(e => e.Geologies)
				.WithMany(e => e.Caves)
				.Map(m => m.ToTable("Cave_Geology").MapLeftKey("CaveId").MapRightKey("GeologyId"));

			modelBuilder.Entity<Cave>()
				.HasMany(e => e.CaveStatuses)
				.WithMany(e => e.Caves)
				.Map(m => m.ToTable("Cave_Status").MapLeftKey("CaveId").MapRightKey("CaveStatusId"));

			modelBuilder.Entity<Cave>()
				.HasMany(e => e.EaseOfAccesses)
				.WithMany(e => e.Caves)
				.Map(m => m.ToTable("Cave_EaseOfAccess").MapLeftKey("CaveId").MapRightKey("EaseOfAccessId"));

			modelBuilder.Entity<Cave>()
				.HasMany(e => e.CertificationLevels)
				.WithMany(e => e.Caves)
				.Map(m => m.ToTable("Cave_CertifcationLevel").MapLeftKey("CaveId").MapRightKey("CertifcationLevel"));


			modelBuilder.Entity<Cave_Fossil>()
				.Property(e => e.FossilId)
				.IsUnicode(false);

			modelBuilder.Entity<Cave_Fossil>()
				.Property(e => e.MediumId)
				.IsUnicode(false);

			modelBuilder.Entity<Cave_Fossil>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<Cave_Fossil>()
				.HasMany(e => e.MetaFiles)
				.WithMany(e => e.Cave_Fossils)
				.Map(m => m.ToTable("Cave_Fossil_MetaFile").MapLeftKey("Cave_FossilId").MapRightKey("FileId"));

			modelBuilder.Entity<Cave_Potential>()
				.Property(e => e.PotentialId)
				.IsUnicode(false);

			modelBuilder.Entity<Cave_Potential>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<CaveAttribute>()
				.Property(e => e.CaveAttributeId)
				.IsUnicode(false);

			modelBuilder.Entity<CaveAttribute>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<CaveAttribute>()
				.HasMany(e => e.Caves)
				.WithMany(e => e.CaveAttributes)
				.Map(m => m.ToTable("Cave_Attribute").MapLeftKey("CaveAttributeId").MapRightKey("CaveId"));

			modelBuilder.Entity<CaveStatus>()
				.Property(e => e.CaveStatusId)
				.IsUnicode(false);

			modelBuilder.Entity<CaveStatus>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<CaveStatus>()
				.Property(e => e.IconUrl)
				.IsUnicode(false);

			modelBuilder.Entity<CaveStatus>()
				.HasMany(e => e.Caves)
				.WithMany(e => e.CaveStatuses)
				.Map(m => m.ToTable("Cave_Status").MapLeftKey("CaveStatusId").MapRightKey("CaveId"));

			modelBuilder.Entity<ChangeLog>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<ChangeLogType>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<ChangeLogType>()
				.HasMany(e => e.ChangeLogs)
				.WithRequired(e => e.ChangeLogType)
				.HasForeignKey(e => e.ChangeLogTypeId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Country>()
				.Property(e => e.CountryId)
				.IsUnicode(false);

			modelBuilder.Entity<Country>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<Country>()
				.HasMany(e => e.Provinces)
				.WithRequired(e => e.Country)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<EaseOfAccess>()
				.Property(e => e.EaseOfAccessId)
				.IsUnicode(false);

			modelBuilder.Entity<EaseOfAccess>()
				.Property(e => e.Description)
				.IsUnicode(false);

			//modelBuilder.Entity<EaseOfAccess>()
			//	.HasMany(e => e.Caves)
			//	.WithMany(e => e.EaseOfAccesses)
			//	.Map(false);

			modelBuilder.Entity<CaveRegister.Model.EntityStatus>()
				.Property(e => e.EntityStatusId)
				.IsUnicode(false);

			modelBuilder.Entity<CaveRegister.Model.EntityStatus>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Entrance>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<ExplorationStatus>()
				.Property(e => e.ExplorationStatusId)
				.IsUnicode(false);

			modelBuilder.Entity<ExplorationStatus>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<ExplorationStatus>()
				.HasMany(e => e.Caves)
				.WithRequired(e => e.ExplorationStatus)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<FileType>()
				.Property(e => e.FileTypeID)
				.IsUnicode(false);

			modelBuilder.Entity<FileType>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<FileType>()
				.HasMany(e => e.MetaFiles)
				.WithRequired(e => e.FileType)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Fossil>()
				.Property(e => e.FossilId)
				.IsUnicode(false);

			modelBuilder.Entity<Fossil>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Fossil>()
				.HasMany(e => e.Cave_Fossil)
				.WithRequired(e => e.Fossil)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Geology>()
				.Property(e => e.GeologyId)
				.IsUnicode(false);

			modelBuilder.Entity<Geology>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<ObservableEntity>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<ObservableEntity>()
				.Property(e => e.ScientificName)
				.IsUnicode(false);

			modelBuilder.Entity<ObservableEntity>()
				.HasMany(e => e.Observations)
				.WithRequired(e => e.ObservableEntity)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ObservableEntityType>()
				.Property(e => e.ObservableEntityTypeId)
				.IsUnicode(false);

			modelBuilder.Entity<ObservableEntityType>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<ObservableEntityType>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<ObservableEntityType>()
				.HasMany(e => e.ObservableEntities)
				.WithRequired(e => e.ObservableEntityType)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<LocationStatus>()
				.Property(e => e.LocationStatusId)
				.IsUnicode(false);

			modelBuilder.Entity<LocationStatus>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<LocationStatus>()
				.HasMany(e => e.Caves)
				.WithRequired(e => e.LocationStatus)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<LocationStatus>()
				.Property(e => e.LocationStatusId)
				.IsUnicode(false);

			modelBuilder.Entity<LocationStatus>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<LocationStatus>()
				.HasMany(e => e.Caves)
				.WithRequired(e => e.LocationStatus)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Medium>()
				.Property(e => e.MediumId)
				.IsUnicode(false);

			modelBuilder.Entity<Medium>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Medium>()
				.HasMany(e => e.Cave_Fossil)
				.WithRequired(e => e.Medium)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<MetaFile>()
				.Property(e => e.FileTypeId)
				.IsUnicode(false);

			modelBuilder.Entity<MetaFile>()
				.Property(e => e.Title)
				.IsUnicode(false);

			modelBuilder.Entity<MetaFile>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<MetaFile>()
				.Property(e => e.Author)
				.IsUnicode(false);

			modelBuilder.Entity<MetaFile>()
				.Map(m => m.Requires("IsDeleted").HasValue(false))
				.Ignore(m => m.IsDeleted);

			modelBuilder.Entity<MetaFile>()
				.Property(e => e.FileTypeId)
				.IsUnicode(false);

			modelBuilder.Entity<Observation>()
				.Property(e => e.TerrainId)
				.IsUnicode(false);

			modelBuilder.Entity<Observation>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<Observation>()
				.Map(m => m.Requires("IsDeleted").HasValue(false))
				.Ignore(m => m.IsDeleted);

			modelBuilder.Entity<Observation>()
				.HasMany(e => e.MetaFiles)
				.WithMany(e => e.Observations)
				.Map(m => m.ToTable("Observation_MetaFile").MapLeftKey("ObservationId").MapRightKey("FileId"));

			modelBuilder.Entity<PotentialType>()
				.Property(e => e.PotentialTypeId)
				.IsUnicode(false);

			modelBuilder.Entity<PotentialType>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<PotentialType>()
				.HasMany(e => e.Cave_Potential)
				.WithRequired(e => e.PotentialType)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Province>()
				.Property(e => e.ProvinceId)
				.IsUnicode(false);

			modelBuilder.Entity<Province>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<Province>()
				.Property(e => e.CountryId)
				.IsUnicode(false);

			modelBuilder.Entity<Province>()
				.HasMany(e => e.Caves)
				.WithRequired(e => e.Province)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Publication>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Publication>()
				.Property(e => e.FileLocation)
				.IsUnicode(false);

			modelBuilder.Entity<Publication>()
				.HasMany(e => e.Articles)
				.WithRequired(e => e.Publication)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<PublicationEntity>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<PublicationEntity>()
				.HasMany(e => e.Publications)
				.WithRequired(e => e.PublicationEntity)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Survey>()
				.Property(e => e.SurveyTypeId)
				.IsUnicode(false);

			modelBuilder.Entity<Survey>()
				.Property(e => e.Description)
				.IsUnicode(false);

			modelBuilder.Entity<Survey>()
				.Property(e => e.SurveyGradeId)
				.IsUnicode(false);

			modelBuilder.Entity<SurveyGrade>()
				.Property(e => e.SurveyGradeId)
				.IsUnicode(false);

			modelBuilder.Entity<SurveyGrade>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<SurveyGrade>()
				.HasMany(e => e.Surveys)
				.WithRequired(e => e.SurveyGrade)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<SurveyType>()
				.Property(e => e.SurveyTypeId)
				.IsUnicode(false);

			modelBuilder.Entity<SurveyType>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<SurveyType>()
				.HasMany(e => e.Surveys)
				.WithRequired(e => e.SurveyType)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Terrain>()
				.Property(e => e.TerrainId)
				.IsUnicode(false);

			modelBuilder.Entity<Terrain>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<VisitHistory>()
				.HasMany(e => e.Cave_Fossils)
				.WithRequired(e => e.VisitHistory)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<VisitHistory>()
				.HasMany(e => e.Observations)
				.WithRequired(e => e.VisitHistory)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<VisitHistory>()
				.HasMany(e => e.AttendingApplicationUsers)
				.WithMany(e => e.VisitHistories)
				.Map(m => m.ToTable("VisitHistory_ApplicationUsers").MapLeftKey("VisitHistoryId").MapRightKey("ApplicationUserId"));

			modelBuilder.Entity<VisitHistory>()
				.Map(m => m.Requires("IsDeleted").HasValue(false))
				.Ignore(m => m.IsDeleted);

			modelBuilder.Entity<History>()
				.Property(e => e.EntityType)
				.IsUnicode(false);

			modelBuilder.Entity<History>()
				.Property(e => e.SerialisedChanges)
				.IsUnicode(false);
		}



		////////////////////

		private void SoftDelete(DbEntityEntry entry)
		{
			Type entryEntityType = entry.Entity.GetType();

			string tableName = GetTableName(entryEntityType);
			string primaryKeyName = GetPrimaryKeyName(entryEntityType);

			string deletequery =
				string.Format(
					"UPDATE {0} SET IsDeleted = 1 WHERE {1} = @id",
						tableName, primaryKeyName);

			Database.ExecuteSqlCommand(
				deletequery,
				new SqlParameter("@id", entry.OriginalValues[primaryKeyName]));

			//Marking it Unchanged prevents the hard delete
			//entry.State = EntityState.Unchanged;
			//So does setting it to Detached:
			//And that is what EF does when it deletes an item
			//http://msdn.microsoft.com/en-us/data/jj592676.aspx
			entry.State = System.Data.Entity.EntityState.Detached;
		}

		private static Dictionary<Type, EntitySetBase> _mappingCache =
		   new Dictionary<Type, EntitySetBase>();

		private EntitySetBase GetEntitySet(Type type)
		{
			if (!_mappingCache.ContainsKey(type))
			{
				ObjectContext octx = ((IObjectContextAdapter)this).ObjectContext;

				string typeName = ObjectContext.GetObjectType(type).Name;

				var es = octx.MetadataWorkspace
								.GetItemCollection(DataSpace.SSpace)
								.GetItems<EntityContainer>()
								.SelectMany(c => c.BaseEntitySets
												.Where(e => e.Name == typeName))
								.FirstOrDefault();

				if (es == null)
					throw new ArgumentException("Entity type not found in GetTableName", typeName);

				_mappingCache.Add(type, es);
			}

			return _mappingCache[type];
		}

		private string GetTableName(Type type)
		{
			EntitySetBase es = GetEntitySet(type);

			return string.Format("[{0}].[{1}]",
				es.MetadataProperties["Schema"].Value,
				es.MetadataProperties["Table"].Value);
		}

		private string GetPrimaryKeyName(Type type)
		{
			EntitySetBase es = GetEntitySet(type);

			return es.ElementType.KeyMembers[0].Name;
		}

		////////////////////
    }
}