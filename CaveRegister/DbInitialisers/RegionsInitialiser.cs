using CaveRegister.Model;
using CaveRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaveRegister.DbInitialisers
{
	public static class RegionsInitialiser
	{
		public static void Ininitialise(ApplicationDbContext db)
		{
			#region Regions
			db.Countries.Add(new Country() { Description = "South-Africa", CountryId = Country.SouthAfrica });
			db.Countries.Add(new Country() { Description = "Namibia", CountryId = Country.Namibia });
			db.Countries.Add(new Country() { Description = "Botswana", CountryId = Country.Botswana });
			db.Countries.Add(new Country() { Description = "Zimbabwe", CountryId = Country.Zimbabwe });
			db.Countries.Add(new Country() { Description = "Madagascar", CountryId = Country.Madagascar });
			db.Countries.Add(new Country() { Description = "Mozambique", CountryId = Country.Mozambique });
			db.Countries.Add(new Country() { Description = "Swaziland", CountryId = Country.Swaziland });
			db.Countries.Add(new Country() { Description = "Lesotho", CountryId = Country.Lesotho });
			db.Countries.Add(new Country() { Description = "Zambia", CountryId = Country.Zambia });
			db.Countries.Add(new Country() { Description = "Unknown", CountryId = Country.Unknown });

			//RSA
			db.Provinces.Add(new Province() { CountryId = Country.SouthAfrica, Description = "Gauteng", ProvinceId = Province.Gauteng });
			db.Provinces.Add(new Province() { CountryId = Country.SouthAfrica, Description = "Eastern Cape", ProvinceId = Province.EasternCape });
			db.Provinces.Add(new Province() { CountryId = Country.SouthAfrica, Description = "FreeState", ProvinceId = Province.FreeState });
			db.Provinces.Add(new Province() { CountryId = Country.SouthAfrica, Description = "Limpopo", ProvinceId = Province.Limpopo });
			db.Provinces.Add(new Province() { CountryId = Country.SouthAfrica, Description = "Mpumalanga", ProvinceId = Province.Mpumalanga });
			db.Provinces.Add(new Province() { CountryId = Country.SouthAfrica, Description = "Kwazulu-Natal", ProvinceId = Province.Natal });
			db.Provinces.Add(new Province() { CountryId = Country.SouthAfrica, Description = "Northern Cape", ProvinceId = Province.NorthernCape });
			db.Provinces.Add(new Province() { CountryId = Country.SouthAfrica, Description = "North-West", ProvinceId = Province.NorthWest });
			db.Provinces.Add(new Province() { CountryId = Country.SouthAfrica, Description = "Western Cape", ProvinceId = Province.WesternCape });
			db.Provinces.Add(new Province() { CountryId = Country.SouthAfrica, Description = "Unknown", ProvinceId = Country.SouthAfrica + Province.Unknown });

			//Lesotho
			db.Provinces.Add(new Province() { CountryId = Country.Lesotho, Description = "Thaba-Tseka", ProvinceId = Province.ThabaTseka });
			db.Provinces.Add(new Province() { CountryId = Country.Lesotho, Description = "Unknown", ProvinceId = Country.Lesotho + Province.Unknown });
			//Zim
			db.Provinces.Add(new Province() { CountryId = Country.Zimbabwe, Description = "Mashonaland West", ProvinceId = Province.MashonalandWest });
			db.Provinces.Add(new Province() { CountryId = Country.Zimbabwe, Description = "Manicaland", ProvinceId = Province.Manicaland });
			db.Provinces.Add(new Province() { CountryId = Country.Zimbabwe, Description = "Midlands", ProvinceId = Province.Midlands });
			db.Provinces.Add(new Province() { CountryId = Country.Zimbabwe, Description = "Gaza", ProvinceId = Province.Gaza });
			db.Provinces.Add(new Province() { CountryId = Country.Zimbabwe, Description = "Unknown", ProvinceId = Country.Zimbabwe + Province.Unknown });

			//Botswana
			db.Provinces.Add(new Province() { CountryId = Country.Botswana, Description = "South-East", ProvinceId = Province.SouthEast });
			db.Provinces.Add(new Province() { CountryId = Country.Botswana, Description = "North-West", ProvinceId = Province.NorthWestBotswana });
			db.Provinces.Add(new Province() { CountryId = Country.Botswana, Description = "Unknown", ProvinceId = Country.Botswana + Province.Unknown });

			//Namibia
			db.Provinces.Add(new Province() { CountryId = Country.Namibia, Description = "Oshikoto", ProvinceId = Province.Oshikoto });
			db.Provinces.Add(new Province() { CountryId = Country.Namibia, Description = "Otjozondjupa", ProvinceId = Province.Otjozondjupa });
			db.Provinces.Add(new Province() { CountryId = Country.Namibia, Description = "Tsumeb", ProvinceId = Province.Tsumeb });
			db.Provinces.Add(new Province() { CountryId = Country.Namibia, Description = "Kunene", ProvinceId = Province.Kunene });
			db.Provinces.Add(new Province() { CountryId = Country.Namibia, Description = "Hardap", ProvinceId = Province.Hardap });
			db.Provinces.Add(new Province() { CountryId = Country.Namibia, Description = "Karas", ProvinceId = Province.Karas });
			db.Provinces.Add(new Province() { CountryId = Country.Namibia, Description = "Khomas", ProvinceId = Province.Khomas });
			db.Provinces.Add(new Province() { CountryId = Country.Namibia, Description = "Unknown", ProvinceId = Country.Namibia + Province.Unknown });

			//Unknown
			db.Provinces.Add(new Province() { CountryId = Country.Unknown, Description = "Unknown", ProvinceId = Province.Unknown });

			//Zambia
			db.Provinces.Add(new Province() { CountryId = Country.Zambia, Description = "Lusaka", ProvinceId = Province.Lusaka });
			db.Provinces.Add(new Province() { CountryId = Country.Zambia, Description = "Unknown", ProvinceId = Country.Zambia + Province.Unknown });

			//Madagascar
			db.Provinces.Add(new Province() { CountryId = Country.Madagascar, Description = "Mahajanga", ProvinceId = Province.Mahajanga });
			db.Provinces.Add(new Province() { CountryId = Country.Madagascar, Description = "Unknown", ProvinceId = Country.Madagascar + Province.Unknown });

			//Mozambique
			db.Provinces.Add(new Province() { CountryId = Country.Mozambique, Description = "Manica", ProvinceId = Province.Manica });
			db.Provinces.Add(new Province() { CountryId = Country.Mozambique, Description = "Unknown", ProvinceId = Country.Mozambique + Province.Unknown });

			//SwaziLand
			db.Provinces.Add(new Province() { CountryId = Country.Swaziland, Description = "Hhohho", ProvinceId = Province.Hhohho });
			db.Provinces.Add(new Province() { CountryId = Country.Swaziland, Description = "Unknown", ProvinceId = Country.Swaziland + Province.Unknown });

			#endregion
		}
	}
}