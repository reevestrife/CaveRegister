using CaveRegister.Models;
using CaveRegister.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveRegister.Contracts
{
    public abstract class ViewModel<T>
    {
		protected ApplicationDbContext Db { get; set; }
		protected LookupRepository LookupRepository { get; set; }
		public T Model { get; set; }
		public abstract void PrepareSave();
		public abstract void PopulateSelectLists();
		public virtual void Initialise(ApplicationDbContext db)
		{
			Db = db;
			LookupRepository = new LookupRepository(Db);
		}
    }
}
