using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using System.Web;

namespace CaveRegister.Helpers
{
	public static class GeographyHelpers
	{
		/// <summary>
		/// Convert Degrees minutes seconds, to decimal degrees
		/// </summary>
		/// <param name="input">degrees minutes seconds</param>
		/// <returns></returns>
		public static double DMStoDecimal(string input)
		{
			double sd = 0.0;
			double min = 0.0;
			double sec = 0.0;
			double deg = 0.0;
			string direction = input.Substring((input.Length - 1), 1);
			input = input.Replace(direction, "");
			input = input.Replace("\"", ""); //remove seconds indicator
			//string sign = "";



			string[] degreeSplit = input.Split('°');
			deg = Convert.ToDouble(degreeSplit[0].Trim());

			string[] minuteSplit = degreeSplit[1].Split('\'');
			min = Convert.ToDouble(minuteSplit[0].Trim());

			sec = Convert.ToDouble(minuteSplit[1].Trim());

			//string[] arr = input.Split(new char[] { ' ' });
			//min = Convert.ToDouble(arr[1]);
			//string[] arr1 = arr[2].Split(new char[] { '.' });
			//sec = Convert.ToDouble(arr1[0]);
			//deg = Convert.ToDouble(arr[0]);
			min = min / ((double)60);
			sec = sec / ((double)3600);
			sd = deg + min + sec;

			//if (!(string.IsNullOrEmpty(sign)))
			//{
			//	sd = sd * (-1);
			//}

			if ((direction.ToUpper() == "S") || (direction.ToUpper() == "W"))
			{
				sd = sd * (-1);
			}
			return sd;
			//sd = Math.Round(sd, 6);
			//string sdnew = Convert.ToString(sd);
			//string sdnew1 = "";

			//sdnew1 = string.Format("{0:0.000000}", sd);
			//EXPECTED OUTPUT -77.03333
		}

		/// <summary>
		/// Decimal degrees to Degrees Minutes Seconds
		/// </summary>
		/// <param name="dec"></param>
		/// <returns></returns>
		public static string decimalToDMS(decimal dec)
		{
			int d = (int)dec;
			int m = (int)((dec - d) * 60);
			decimal s = ((((dec - d) * 60) - m) * 60);

			return d + "° " + m + "' " + s + "\"";
		}


		public static DbGeography ToDbGeography(double latitude, double longitude)
		{
			var dbGeog = DbGeography.FromText("POINT(" + longitude.ToString(CultureInfo.CreateSpecificCulture("en-US")) + " " + latitude.ToString(CultureInfo.CreateSpecificCulture("en-US")) + ")");
			return dbGeog;
		}

		public static DbGeography ToDbGeography(double latitude, double longitude, double elevation)
		{
			var dbGeog = DbGeography.FromText("POINT(" + longitude.ToString(CultureInfo.CreateSpecificCulture("en-US")) + " " + latitude.ToString(CultureInfo.CreateSpecificCulture("en-US")) +  " " + elevation.ToString(CultureInfo.CreateSpecificCulture("en-US")) +")");
			return dbGeog;
		}
	}

	public class GeoAngle
	{
		public bool IsNegative { get; set; }
		public int Degrees { get; set; }
		public int Mins { get; set; }
		public int Sec { get; set; }
		public int MilliSec { get; set; }

		public static GeoAngle FromDouble(double ExaDegree)
		{

			while (ExaDegree < -180.0) ExaDegree += 360.0;

			while (ExaDegree > 180.0) ExaDegree -= 360.0;

			var result = new GeoAngle();


			result.IsNegative = ExaDegree < 0;
			ExaDegree = Math.Abs(ExaDegree);


			result.Degrees = (int)Math.Floor(ExaDegree);
			var delta = ExaDegree - result.Degrees;


			var Sec = (int)Math.Floor(3600.0 * delta);
			result.Sec = Sec % 60;
			result.Mins = (int)Math.Floor(Sec / 60.0);
			delta = delta * 3600.0 - Sec;


			result.MilliSec = (int)(1000.0 * delta);

			return result;
		}



		public override string ToString()
		{
			var degrees = this.IsNegative
				? -this.Degrees
				: this.Degrees;

			return string.Format(
				"{0}° {1:00}' {2:00}\"",
				degrees,
				this.Mins,
				this.Sec);
		}



		public string ToString(string format)
		{
			switch (format)
			{
				case "NS":
					return string.Format(
						"{0}° {1:00}' {2:00}\".{3:000} {4}",
						this.Degrees,
						this.Mins,
						this.Sec,
						this.MilliSec,
						this.IsNegative ? 'S' : 'N');

				case "WE":
					return string.Format(
						"{0}° {1:00}' {2:00}\".{3:000} {4}",
						this.Degrees,
						this.Mins,
						this.Sec,
						this.MilliSec,
						this.IsNegative ? 'W' : 'E');

				default:
					throw new NotImplementedException();
			}
		}
	}
}