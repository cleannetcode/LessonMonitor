using HomeWork.Middleware;
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
using System.Threading.Tasks;

namespace HomeWork
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HomeWork", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeWork v1"));
            }

            app.UseRouting();

            app.Use((context, next) =>
            {
                using (var writer = new StreamWriter("UseLoger.txt"))
                {
                    writer.WriteLine($"QueryString: {context.Request.QueryString}");
                    writer.WriteLine($"Method: {context.Request.Method}");
                    writer.WriteLine($"Headers: {context.Request.Headers}");
                    writer.WriteLine($"Body: {context.Request.Body}");
                    writer.WriteLine($"HttpContext: {context.Request.HttpContext}");
                    writer.WriteLine($"Protocol: {context.Request.Protocol}");
                    writer.WriteLine($"ContentLength: {context.Request.ContentLength}");
                    writer.WriteLine($"ContentType: {context.Request.ContentType}");
                    writer.WriteLine($"Cookies: {context.Request.Cookies}");
                    writer.WriteLine($"Path: {context.Request.Path}");
                }

                return next.Invoke();
            });

            app.UseMiddleware<Logger>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
