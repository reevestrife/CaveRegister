using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpKml;
using SharpKml.Dom;
using SharpKml.Base;
using CaveRegister.Models;
using SharpKml.Engine;
using System.IO;
using CaveRegister.Model;

namespace CaveRegister.Helpers
{
	public static class KmlHelpers
	{


		public static Folder PlacemarkFolder(IQueryable<Cave> caves)
		{

			//List<Placemark> cavePlacemarkList = new List<Placemark>();
			Folder caveFolder = new Folder();
			caveFolder.Name = "Cave Folder";
			foreach (Cave cave in caves)
			{
				foreach (var entrance in cave.Entrances)
				{
					Placemark placemark = new Placemark();
					placemark.Name = cave.Name + " (E" + entrance.Name + ")";
					placemark.Description = new Description() { Text = cave.Description };

					Point point = new Point();
					point.Coordinate = new Vector(entrance.GeoLocation.Latitude ?? 0, entrance.GeoLocation.Longitude ?? 0, entrance.GeoLocation.Elevation ?? 0);

					placemark.Geometry = point;

					caveFolder.AddFeature(placemark);
				}

			}

			return caveFolder;
		}


		public static MemoryStream ExportCaveRegister(MemoryStream stream, Folder folder)
		{
			Kml kml = new Kml();
			kml.Feature = folder;
			KmlFile kmlFile = KmlFile.Create(kml, false);

			//MemoryStream stream = new MemoryStream();
			using (KmzFile kmz = KmzFile.Create(kmlFile))
			{
				kmz.Save(stream);
				kmz.Save(HttpContext.Current.Request.MapPath("~/App_Data/Test2.kmz"));
			}

			return stream;
		}
	}
}