using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonMonitor.API.Controllers;
using LessonMonitor.BL;
using LessonMonitor.DataAccess;
using LessonMonitor.DataBase;
using LessonMonitor.Domain.Interfaces.BisinessLogic;
using LessonMonitor.Domain.Interfaces.DataAccess;

namespace LessonMonitor.API
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
            services.AddSingleton<DataBaseMock>();
            services.AddTransient<IUsersRepository, UserRepositoryMock>();
            services.AddTransient<IUsersService, UserService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LessonMonitor.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LessonMonitor.API v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseMiddleware<MyMiddlewareComponent>();

            //app.Use((httpContext, next) =>
            //{
            //    var task = next();

            //    return task;
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
