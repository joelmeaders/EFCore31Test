using System.Linq;
using AspNetCore31Test2.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;

namespace AspNetCore31Test2
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<Context>(
				db => db.UseSqlServer(Configuration["ConnectionStrings:Database"]), ServiceLifetime.Scoped);

			services.AddControllers();
			services.AddOData();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.Select().Filter().OrderBy().Count().MaxTop(10);
				endpoints.MapODataRoute("odata", "odata", GetEdmModel());
			});
		}

		private IEdmModel GetEdmModel()
		{
			var odataBuilder = new ODataConventionModelBuilder();

			odataBuilder.EntitySet<Entity1>("Entity1");
			odataBuilder.EntitySet<Entity2>("Entity2");
			odataBuilder.EntitySet<Entity3>("Entity3");

			return odataBuilder.GetEdmModel();
		}
	}
}
