using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore31Test2.Models
{
	public class Entity3 : BaseModel
	{
		public string Name { get; set; }
		public Guid Entity2Id { get; set; }


		public virtual Entity2 Entity2 { get; set; }
	}
}
