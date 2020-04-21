using System.Linq;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCore31Test2
{
	public class Startup
	{
		readonly string CORSBasePolicy = "_basePolicy";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<Context>(
				db => db.UseSqlServer(Configuration["ConnectionStrings:Database"]), ServiceLifetime.Scoped);

			services.AddControllers().AddNewtonsoftJson();
			services.AddOData();

			services.AddCors(options =>
			{
				options.AddPolicy(name: CORSBasePolicy,
				builder =>
				{
					// Not secure. Testing purposes only.
					builder
						.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader();
				});
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.EnableDependencyInjection();
				endpoints.Expand().Select().Filter().OrderBy().Count().MaxTop(10);
			});
		}
	}
}
