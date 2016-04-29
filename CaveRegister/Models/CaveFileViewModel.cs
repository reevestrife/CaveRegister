using CaveRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaveRegister.Models
{
	public class CaveFileViewModel
	{
		public int CaveID { get; set; }
		public int FileID { get; set; }
		public string FileTypeID { get; set; }
		public string Description { get; set; }
		public bool IsCoverImage { get; set; }
		public HttpPostedFileBase Data { get; set; }
		public SelectList FileTypeSelectList { get; set; }
	}
}