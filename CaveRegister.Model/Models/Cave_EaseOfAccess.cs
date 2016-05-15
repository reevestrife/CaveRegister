﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveRegister.Model
{
	public class Cave_EaseOfAccess
	{
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int CaveId { get; set; }

		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public string EaseOfAccessId { get; set; }

		public virtual Cave Cave { get; set; }
		public virtual EaseOfAccess EaseOfAccess { get; set; }
	}
}