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

            app.UseMiddleware<MyMiddlewareComponent>();

            app.Use((httpContext, next) =>
            {
                var task = next();

                using (FileStream fs = new FileStream(@"..\filelog.txt", FileMode.OpenOrCreate))
                {
                    fs.Write(Encoding.Default.GetBytes("Request:" + "\n"));
                    fs.Write(Encoding.Default.GetBytes("Header:      " + httpContext.Request.Headers.ToString() + "\n"));
                    fs.Write(Encoding.Default.GetBytes("Host:        " + httpContext.Request.Host.ToString() + "\n"));
                    fs.Write(Encoding.Default.GetBytes("HttpContext: " + httpContext.Request.HttpContext.ToString() + "\n"));
                    fs.Write(Encoding.Default.GetBytes("IsHttps:     " + httpContext.Request.IsHttps.ToString() + "\n"));
                    fs.Write(Encoding.Default.GetBytes("Method:      " + httpContext.Request.Method.ToString() + "\n"));
                    fs.Write(Encoding.Default.GetBytes("Path:        " + httpContext.Request.Path.ToString() + "\n"));
                    fs.Write(Encoding.Default.GetBytes("Protocol:    " + httpContext.Request.Protocol.ToString() + "\n"));
                    fs.Write(Encoding.Default.GetBytes("Scheme:      " + httpContext.Request.Scheme.ToString() + "\n"));

                    fs.Write(Encoding.Default.GetBytes("\n" + "Response:" + "\n"));
                    fs.Write(Encoding.Default.GetBytes("Header:      " + httpContext.Response.Headers.ToString() + "\n"));
                    fs.Write(Encoding.Default.GetBytes("StatusCode:  " + httpContext.Response.StatusCode.ToString() + "\n"));
                    fs.Write(Encoding.Default.GetBytes("HttpContext: " + httpContext.Response.HttpContext.ToString() + "\n"));
                    fs.Write(Encoding.Default.GetBytes("HasStarted:  " + httpContext.Response.HasStarted.ToString() + "\n"));
                    fs.Write(Encoding.Default.GetBytes("Body:        " + httpContext.Response.Body.ToString() + "\n"));
                }

                    return task;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
