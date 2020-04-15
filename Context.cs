using AspNetCore31Test2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore31Test2
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options): base(options) { }

		public virtual DbSet<Entity1> Entity1s { get; set; }
		public virtual DbSet<Entity2> Entity2s { get; set; }
		public virtual DbSet<Entity3> Entity3s { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("dbo");
		}
	}

}
