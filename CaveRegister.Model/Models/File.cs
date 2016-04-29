using CaveRegister.Model.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveRegister.Model
{
	[Table("File")]
	public class File 
	{
		[Key]
		public int FileId { get; set; }

		[StringLength(256)]
		public string FileName { get; set; }

		[StringLength(256)]
		public string MimeType { get; set; }

		[JsonIgnore]
		public byte[] Data { get; set; }
	}
}
