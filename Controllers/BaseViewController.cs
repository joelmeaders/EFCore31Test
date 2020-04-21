using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore31Test2.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BaseViewController<T> : ControllerBase where T : class
	{
		protected readonly Context Context;
		protected readonly DbSet<T> DbSet;

		protected BaseViewController(Context context)
		{
			Context = context;
			DbSet = context.Set<T>();
		}

		[HttpGet]
		[EnableQuery]
		public virtual ActionResult<IQueryable<T>> Get()
		{
			Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return Ok(DbSet.AsQueryable());
		}

		[HttpGet("{id}")]
		[EnableQuery]
		public virtual async Task<ActionResult<IQueryable<T>>> Get([FromODataUri] Guid key)
		{
			try
			{
				Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
				return Ok(await DbSet.FindAsync(key));
			}
			catch
			{
				return NotFound();
			}
		}
	}
}
