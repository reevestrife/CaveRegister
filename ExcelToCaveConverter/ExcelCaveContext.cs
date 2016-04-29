namespace ExcelToCaveConverter
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class ExcelCaveContext : DbContext
	{
		public ExcelCaveContext()
			: base("name=ExcelCaveContext")
		{
		}

		public virtual DbSet<ExcelCave> ExcelCaves { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
