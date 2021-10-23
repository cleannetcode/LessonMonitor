using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //2ой этап конфигурации: создание промежуточных сущностей описание того как наше приложение будет работать
                    //(эти описания не связаны с сетевым взаимодействием, т.к. сетевое взаимодействие уже настроено)
                    //какие у прилежения будут фильтры, будет ли авторизация, доступ к каким ресурсам нужно сделать
                    //какие будут контроллеры, модели, классы, как они будут взаимодействовать, создаваться
                    webBuilder.UseStartup<Startup>(); 
                });
        }
    }
}
