using FirstCoreApi.Interfaces;
using FirstCoreApi.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var connectionString = Configuration.GetConnectionString("BikeStoreDatabase");
			services.AddDbContextPool<BikeStoresContext>(option => option.UseSqlServer(connectionString));
			services.AddCors();
			services.AddControllers();
			// Register the Swagger generator, defining 1 or more Swagger documents  
			services.AddSwaggerGen();
			services.AddScoped<IBrandsService, BrandService>();
			services.AddScoped<IProductsService, ProductsService>();
			//services.AddTransient<ServiceResolver>(serviceProvider => key =>
			//{
			//	switch (key)
			//	{
			//		case "A":
			//			return serviceProvider.GetService<ServiceA>();
			//		case "B":
			//			return serviceProvider.GetService<ServiceB>();
			//		case "C":
			//			return serviceProvider.GetService<ServiceC>();
			//		default:
			//			throw new KeyNotFoundException(); // or maybe return null, up to you
			//	}
			//});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// Enable middleware to serve generated Swagger as a JSON endpoint.  
			// Enable middleware to serve generated Swagger as a JSON endpoint.  
			app.UseSwagger(c =>
			{
				c.SerializeAsV2 = true;
			});

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),  
			// specifying the Swagger JSON endpoint.  
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
				c.RoutePrefix = string.Empty;
			});

			//app.UseHttpsRedirection();

			// global cors policy
			app.UseCors(x => x
				.AllowAnyMethod()
				.AllowAnyHeader()
				.SetIsOriginAllowed(origin => true) // allow any origin
				.AllowCredentials()); // allow credentials

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
