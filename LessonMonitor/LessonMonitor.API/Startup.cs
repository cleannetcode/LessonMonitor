using LessonMonitor.BusinessLogic;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;
using LessonMonitor.DataAccess.MSSQL;
using LessonMonitor.DataAccess.MSSQL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;

namespace LessonMonitor.API
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
			services.AddAutoMapper(cfg =>
			{
				cfg.AddProfile<ApiMappingProfile>();
				cfg.AddProfile<DataAccessMappingProfile>();
			});

			services.AddScoped<IHomeworksRepository, HomeworksRepository>();
			services.AddScoped<IHomeworksService, HomeworksService>();

			services.AddScoped<IMembersRepository, MembersRepository>();
			services.AddScoped<IMembersService, MembersService>();

			services.AddDbContext<LessonMonitorDbContext>(builder =>
			{
				builder.UseSqlServer(Configuration.GetConnectionString("LessonMonitorDb"));
			});

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "LessonMonitor.API", Version = "v1" });
			});
		}

		public void Configure([NotNull] IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LessonMonitor.API v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
