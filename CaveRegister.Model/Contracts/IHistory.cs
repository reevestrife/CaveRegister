using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveRegister.Model.Contracts
{
	public interface IHistory
	{
		int HistoryId { get; set; }
		int HistoryDate { get; set; }
		int VersionNumber { get; set; }
	}
}
