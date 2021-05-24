using LessonMonitor.API.Controllers;
using LessonMonitor.BussinesLogic;
using LessonMonitor.Core;
using LessonMonitor.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Net;

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

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ITopicsService, TopicsService>();
            services.AddScoped<ITopicsRepository, TopicsRepository>();
            services.AddScoped<IQuestionsService, QuestionsService>();
            services.AddScoped<IQuestionsRepository, QuestionsRepository>();
            services.AddScoped<IResponseBodyRepository, ResponseBodyRepository>();
            services.AddScoped<IGitHubService, GitHubService>();
            services.AddScoped<IGitHubRepository, GitHubRepository>();
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<MyMiddlewareComponent>();

            app.Use((httpContext, next) =>
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.contoso.com/");

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                // ѕолучить заголовки, св€занные с ответом.
                WebHeaderCollection myWebHeaderCollection = myHttpWebResponse.Headers;

                using StreamWriter file = new("HeaderLines.txt");

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

                // ѕолучите заголовки использу€ new свойства (AllKeys)
                string[] headers = myWebHeaderCollection.AllKeys;

                // перечислить через коллекцию
                foreach (string header in headers)
                {
                    file.WriteLine(myWebHeaderCollection.Get(header));
                }

                file.WriteLine(myWebHeaderCollection);

                myWebHeaderCollection.Clear();

                myHttpWebResponse.Close();

                var task = next();

               return task;
            });

            app.UseAuthorizationMiddleware();
            app.UseProcessingTimeMiddleware();
            app.UseResponseBodyMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
