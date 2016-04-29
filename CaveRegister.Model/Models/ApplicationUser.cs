using CaveRegister.Model.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CaveRegister.Model
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser, IEntityWithURL
	{
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}

		//public int ClubID { get; set; }

		public ApplicationUser()
		{
			CertificationLevels = new HashSet<CertificationLevel>();
			VisitHistories = new HashSet<VisitHistory>();
			LastEditCaves = new HashSet<Cave>();
			LastEditCave_Fossils = new HashSet<Cave_Fossil>();
			LastEditCave_Potentials = new HashSet<Cave_Potential>();
			LastEditEntrances = new HashSet<Entrance>();
			LastEditMetaFiles = new HashSet<MetaFile>();
			LastEditArticles = new HashSet<Article>();
			LastEditObservableEntities = new HashSet<ObservableEntity>();
			LastEditObservations = new HashSet<Observation>();
		}

		public string Name { get; set; }
		public string Surname { get; set; }
		public string ContactNumber { get; set; }
		public string EmergencyContactDetails { get; set; }
		public string EmergencyMedicalDetails { get; set; }

		public string NameAndSurname { get { return string.Concat(this.Name, " ", this.Surname); } }

		/// <summary>
		/// For all the Members present at a visit
		/// </summary>


		
		public virtual ICollection<CertificationLevel> CertificationLevels { get; set; }

		[JsonIgnore]
		public virtual ICollection<Article> LastEditArticles { get; set; }
		[JsonIgnore]
		public virtual ICollection<Cave> LastEditCaves { get; set; }
		[JsonIgnore]
		public virtual ICollection<Cave_Fossil> LastEditCave_Fossils { get; set; }
		[JsonIgnore]
		public virtual ICollection<Cave_Potential> LastEditCave_Potentials { get; set; }
		[JsonIgnore]
		public virtual ICollection<Entrance> LastEditEntrances { get; set; }
		[JsonIgnore]
		public virtual ICollection<ObservableEntity> LastEditObservableEntities { get; set; }
		[JsonIgnore]
		public virtual ICollection<MetaFile> LastEditMetaFiles { get; set; }
		[JsonIgnore]
		public virtual ICollection<Observation> LastEditObservations { get; set; }
		[JsonIgnore]
		public virtual ICollection<Survey> LastEditSurveys { get; set; }
		
		/// <summary>
		/// All Visit Histories this user last edited.
		/// </summary>
		[JsonIgnore]
		public virtual ICollection<VisitHistory> LastEditVisitHistories { get; set; }
		/// <summary>
		/// All the Caving trips this User have been on
		/// </summary>
		[JsonIgnore]
		public virtual ICollection<VisitHistory> VisitHistories { get; set; }
		//public virtual ICollection<Survey> 

		[JsonIgnore]
		public string URL
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}