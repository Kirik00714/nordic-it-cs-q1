using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace CityApp
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
		}
		public void Configure(
			IApplicationBuilder builder,
			IHostingEnvironment enviroment)
		{
			if (enviroment.EnvironmentName == "local")
			{
				builder.UseDeveloperExceptionPage();
			}
			builder.UseMvc(ConfigureRoutes);
		} 
		private static void ConfigureRoutes(IRouteBuilder builder)
		{
			builder.MapRoute(
				name: "Default", 
				template: "api/{controller}/{action}", 
				defaults: new {Controllers = "City", Action = "List"}
				);
		}

	}
}
