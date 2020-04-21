using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore31Test2.Models
{
	public class Entity2 : BaseModel
	{
		public string Name { get; set; }
		public Guid Entity1Id { get; set; }


		public virtual Entity1 Entity1 { get; set; }
		public virtual ICollection<Entity3> Entity3 { get; set; }
	}
}
