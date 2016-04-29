using CaveRegister.EF;
using CaveRegister.Helpers;
using CaveRegister.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaveRegister.Controllers
{
    public class ExportController : Controller
    {
		ApplicationDbContext db = new ApplicationDbContext();
        // GET: Export
        public FileResult Index()
        {
			ImageHelper.MergeImages();
			var folder = KmlHelpers.PlacemarkFolder(db.Caves);

			MemoryStream stream = new MemoryStream();
			KmlHelpers.ExportCaveRegister(stream,folder);
			stream.Seek(0, SeekOrigin.Begin); //rewind stream to the begining before we download
			return File(stream, "application/vnd.google-earth.kmz", "testKMZ.kmz");
        }
    }
}