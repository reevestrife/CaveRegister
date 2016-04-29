using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CaveRegister.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

		[Required]
		[Display(Name = "Contact number")]
		public string ContactNumber { get; set; }

		[Required]
		[Display(Name = "Emergency contact details")]
		public string EmergencyContactDetails { get; set; }

		[Required]
		[Display(Name = "Emergency medical details")]
		public string EmergencyMedicalDetails { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}