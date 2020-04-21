using AspNetCore31Test2.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AspNetCore31Test2
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options): base(options) { }

		public virtual DbSet<Entity1> Entity1s { get; set; }
		public virtual DbSet<Entity2> Entity2s { get; set; }
		public virtual DbSet<Entity3> Entity3s { get; set; }
		public virtual DbSet<ViewEntity1Entity2> ViewEntity1Entity2s { get; set; }
		public virtual DbSet<ViewEntity2Entity3> ViewEntity2Entity3s { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("dbo");

			modelBuilder.Entity<ViewEntity1Entity2>()
				.HasNoKey()
				.ToView("ViewEntity1Entity2");

			modelBuilder.Entity<ViewEntity2Entity3>()
				.HasNoKey()
				.ToView("ViewEntity2Entity3");

			modelBuilder.Entity<Entity1>(entity =>
			{
				entity.HasData(new Entity1 { Id = new Guid("{36471298-E1FF-4516-B1C9-ADD01E95DE06}"), Name = "My First Entity1" });
				entity.HasData(new Entity1 { Id = new Guid("{1E3942DD-E344-4DA6-A822-D5E93E265626}"), Name = "My Second Entity1" });
			});

			modelBuilder.Entity<Entity2>(entity =>
			{
				entity.HasData(new Entity2 { Id = new Guid("{4E8D3154-092C-4360-B4BA-67547AA997F5}"), Name = "My First Entity2", Entity1Id = new Guid("{36471298-E1FF-4516-B1C9-ADD01E95DE06}") });
				entity.HasData(new Entity2 { Id = new Guid("{6BD309A0-243F-4F24-A4F2-B6DAB18BC4FF}"), Name = "My Second Entity2", Entity1Id = new Guid("{1E3942DD-E344-4DA6-A822-D5E93E265626}") });
			});

			modelBuilder.Entity<Entity3>(entity =>
			{
				entity.HasData(new Entity3 { Id = new Guid("{411241D5-4C77-4307-963B-AD316A37FCCD}"), Name = "My First Entity3", Entity2Id = new Guid("{4E8D3154-092C-4360-B4BA-67547AA997F5}") });
				entity.HasData(new Entity3 { Id = new Guid("{34C5D5F6-1BC1-4B28-85A7-5CD71CB4B5FC}"), Name = "My Second Entity3", Entity2Id = new Guid("{4E8D3154-092C-4360-B4BA-67547AA997F5}") });
				entity.HasData(new Entity3 { Id = new Guid("{15196E1B-F4D7-4059-9681-A9F8EF632C12}"), Name = "My Third Entity3", Entity2Id = new Guid("{6BD309A0-243F-4F24-A4F2-B6DAB18BC4FF}") });
			});
		}
	}

}
