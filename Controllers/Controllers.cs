using AspNetCore31Test2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore31Test2.Controllers
{
#pragma warning disable S101 // Types should be named in PascalCase
	public partial class Entity1sController : BaseController<Entity1>
	{
		public Entity1sController(Context context) : base(context) { }
	}

	public partial class Entity2sController : BaseController<Entity2>
	{
		public Entity2sController(Context context) : base(context) { }
	}

	public partial class Entity3sController : BaseController<Entity3>
	{
		public Entity3sController(Context context) : base(context) { }
	}
}
