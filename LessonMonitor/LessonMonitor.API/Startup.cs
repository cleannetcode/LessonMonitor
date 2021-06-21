using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Net;
using Microsoft.OpenApi.Models;
using LessonMonitor.BussinesLogic;
using LessonMonitor.Core.Services;
using LessonMonitor.Core.Repositories;
using LessonMonitor.DataAccess.Repositories;

namespace LessonMonitor.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public string[] AllKeys { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LessonMonitor.API", Version = "v1" });
            });

            services.AddScoped<ITopicsService, TopicsService>();
            services.AddScoped<ITopicsRepository, TopicsRepository>();

            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IUsersRepository, UsersRepository>();

            services.AddTransient<IQuestionsService, QuestionsService>();
            services.AddTransient<IQuestionsRepository, QuestionsRepository>();

            services.AddSingleton<IResponseBodyRepository, ResponseBodyRepository>();
            services.AddSingleton<IGitHubService, GitHubService>();
            services.AddSingleton<IGitHubRepository, GitHubRepository>();

            services.AddScoped<IHomeworksService, HomeworksService>();
            services.AddScoped<IHomeworksRepository, HomeworksRepository>();

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

            ErrorMessageRegistry.ReBuild();

            DIViewer.RunDemo();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<MyMiddlewareComponent>();

            app.Use( async (httpContext, next) =>
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.contoso.com/");

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                WebHeaderCollection myWebHeaderCollection = myHttpWebResponse.Headers;

                await using StreamWriter file = new("HeaderLines.txt");

                for (int i = 0; i < myWebHeaderCollection.Count; i++)
                {
                    var header = myWebHeaderCollection.GetKey(i);

                    string[] values = myWebHeaderCollection.GetValues(header);

                    if (values.Length > 0)
                    {
                        for (int j = 0; j < values.Length; j++)
                        {
                            file.WriteLine(values[j]);
                        } 
                    }
                }

                string[] headers = myWebHeaderCollection.AllKeys;

                foreach (string header in headers)
                {
                    file.WriteLine(myWebHeaderCollection.Get(header));
                }

                file.WriteLine(myWebHeaderCollection);

                myWebHeaderCollection.Clear();

                myHttpWebResponse.Close();

                var task = next();

                await task;
            });

            app.UseAuthorizationMiddleware();

            app.UseResponseBodyMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
