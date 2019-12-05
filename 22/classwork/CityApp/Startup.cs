using CityApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CityApp
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(option =>
			{ option.RespectBrowserAcceptHeader = true; }).AddXmlSerializerFormatters();
			services.AddSwaggerGen(options => { options.SwaggerDoc("v1", new Info { Title = "Cities", Version = "2.0" }); });
			services.AddSingleton<CityStorage>();
		}
		public void Configure(
			IApplicationBuilder builder,
			IHostingEnvironment enviroment)
		{
			if (enviroment.EnvironmentName == "local")
			{
				builder.UseDeveloperExceptionPage();
			}
			builder.UseSwagger();
			builder.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cities API V1"));
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
