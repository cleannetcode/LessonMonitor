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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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

            app.Use(async (context, next) =>
            {
                await next.Invoke();
                
                var path = context.Request.Path;
                var nameLogFile = "log.txt";
                using StreamWriter file = new StreamWriter(nameLogFile, true);
                /*
                 * Подсмотрел на https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file
                 * понятия не имею для чего здесь using, на метаните глянул это чтото для disposable обьектов, а что это также не понятно,
                 * подозреваю за ними нужно следить и освобождать их вручную) думаю это все относится к stream и это должно быть одна большая тема?.
                 * Это на самостоятельное изучение?:-D
                 */
                file.WriteLine(path + " : " + (context.Response.StatusCode != 200 ? "Bad requers" : "Ok"));
                file.Close();
            });

            //app.UseMiddleware<CheckHeaderMiddleware>("TestHeader"); /* Альтернативный вызов */
            app.UseCheckHeader("TestHeader");
            
            app.UseMiddleware<MyMiddlewareComponent>();

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
