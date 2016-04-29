namespace CaveRegister.Model
{
	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	[Table("Province")]
	public partial class Province
	{
		//SouthAfrica
		public const string Gauteng = "Gauteng";
		public const string Natal = "Natal";
		public const string FreeState = "FreeState";
		public const string Limpopo = "Limpopo";
		public const string NorthWest = "NorthWest";
		public const string WesternCape = "WesternCape";
		public const string EasternCape = "EasternCape";
		public const string NorthernCape = "NorthernCape";
		public const string Mpumalanga = "Mpumalanga";

		//Lesotho
		public const string ThabaTseka = "ThabaTseka";

		//Zimbabwe
		public const string MashonalandWest = "MashonalandWest";
		public const string Manicaland = "Manicaland";
		public const string Midlands = "Midlands";
		public const string Gaza = "Gaza";

		//Botswana
		public const string SouthEast = "SouthEast";
		public const string NorthWestBotswana = "NorthWestBotswana";

		//Zambia
		public const string Lusaka = "Lusaka";

		//Namibia
		public const string Oshikoto = "Oshikoto";
		public const string Otjozondjupa = "Otjozondjupa";
		public const string Tsumeb = "Tsumeb";
		public const string Kunene = "Kunene";
		public const string Hardap = "Hardap";
		public const string Karas = "Karas";
		public const string Khomas = "Khomas";

		//Madagascar
		public const string Mahajanga = "Mahajanga";

		//Swaziland
		public const string Hhohho = "Hhohho";

		//Mozambique
		public const string Manica = "Manica";

		public const string Unknown = "Unknown";

		public Province()
		{
			Caves = new HashSet<Cave>();
		}
		[Key]
		[StringLength(64)]
		public string ProvinceId { get; set; }

		[Required]
		[StringLength(64)]
		[Display(Name = "Province")]
		public string Description { get; set; }

		[Required]
		[StringLength(64)]
		public string CountryId { get; set; }

		[JsonIgnore]
		public DbGeography DbLatLong { get; set; }

		[JsonIgnore]
		public virtual ICollection<Cave> Caves { get; set; }

		public virtual Country Country { get; set; }
	}
}
