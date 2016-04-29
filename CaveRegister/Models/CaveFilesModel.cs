using CaveRegister.Model;
using System.Collections.Generic;


namespace CaveRegister.Models
{
	public class CaveFilesModel
	{
		public int CaveID { get; set; }
		public IEnumerable<MetaFile> CaveFiles { get; set; }
	}
}