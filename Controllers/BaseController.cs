using AspNetCore31Test2.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore31Test2.Controllers
{
	public abstract class BaseController<T> : ControllerBase where T : BaseModel
	{
		protected readonly Context Context;
		protected readonly DbSet<T> DbSet;

		protected BaseController(Context context)
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

		[HttpGet]
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

		[HttpPost]
		public virtual async Task<IActionResult> Post([FromBody] T item)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			try
			{
				await DbSet.AddAsync(item);
				await Context.SaveChangesAsync();
				return Created(item);
			}
			catch (Exception e)
			{
				if (await DbSet.AnyAsync(p => p.Id == item.Id))
				{
					return Conflict(item);
				}
				else
				{
					return BadRequest(e);
				}
			}
		}

		[HttpPut]
		public virtual async Task<IActionResult> Put([FromODataUri] Guid key, [FromBody] T item)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				Context.Update(item);
				await Context.SaveChangesAsync();
				return Updated(item);
			}
			catch (Exception e)
			{
				if (!entityExists(item.Id))
				{
					return NotFound(item.Id);
				}
				else
				{
					return StatusCode(500, e);
				}
			}
		}

		private bool entityExists(Guid id)
		{
			return DbSet.Any(item => item.Id == id);
		}

		protected IActionResult Created(T entity) => StatusCode(201, entity);

		protected IActionResult Updated(T entity) => StatusCode(200, entity);
	}
}
