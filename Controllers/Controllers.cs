using AspNetCore31Test2.Models;

namespace AspNetCore31Test2.Controllers
{
	public class EntityOnesController : BaseController<Entity1>
	{
		public EntityOnesController(Context context) : base(context) { }
	}

	public class Entity2sController : BaseController<Entity2>
	{
		public Entity2sController(Context context) : base(context) { }
	}

	public class Entity3sController : BaseController<Entity3>
	{
		public Entity3sController(Context context) : base(context) { }
	}

	public class ViewEntity1Entity2sController : BaseViewController<ViewEntity1Entity2>
	{
		public ViewEntity1Entity2sController(Context context) : base(context) { }
	}

	public class ViewEntity2Entity3sController : BaseViewController<ViewEntity2Entity3>
	{
		public ViewEntity2Entity3sController(Context context) : base(context) { }
	}
}
