using BusinessLogic.BLLs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;

namespace Api
{
	public class Startup
	{
		public static CommonSettings.Settings AppSettings;
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			AppSettings = new Settings();
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			

			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.SuppressModelStateInvalidFilter = true;
			});

			//AutoMapper
			services.AddAutoMapper(typeof(Startup));
			services.AddControllersWithViews();

			//Configuration of dependency injection
			services.AddScoped<IPersonRepository, Person>();
			//end
			services.AddControllers();
			//Autentication
			var key = Encoding.ASCII.GetBytes(AppSettings._jwtSettings.GetJwtKey());
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false,
				};
			});
			//end
			services.AddSwaggerGen(c =>
			{
				

				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Api",
					Version = "v1",
					Description = "A simple api.",
					Contact = new OpenApiContact
					{
						Name = "Leandro Gazabini",
						Email = "leandro.pg@uol.com.br"
					},
				});
				//TAG
				c.TagActionsBy(api =>
				{
					if (api.GroupName != null)
					{
						return new[] { api.GroupName };
					}

					if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
					{
						return new[] { controllerActionDescriptor.ControllerName };
					}

					throw new InvalidOperationException("Unable to determine tag for endpoint.");
				});

				//JWT configuration
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement
					 {
						 {
							   new OpenApiSecurityScheme
								 {
									 Reference = new OpenApiReference
									 {
										 Type = ReferenceType.SecurityScheme,
										 Id = "Bearer"
									 }
								 },
								 new string[] {}
						 }
					 });
				//
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
			}
			else
			{
				//app.UseExceptionHandler("/error"); // implement https://docs.microsoft.com/pt-br/aspnet/core/web-api/handle-errors?view=aspnetcore-5.0
			}


			app.UseHttpsRedirection();

			app.UseRouting();

			//app.Use(async (context, next) =>
			//{
			//	context.Response.Headers.Clear();
			//	await next();
			//});
			//middleware to resolve object return in api in validations.
			//app.UseMiddleware<GenericMiddleware>();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapControllerRoute(name: "api",
											 pattern: "/api/{controller=api}/");


				//
			});

		}
	}
}
