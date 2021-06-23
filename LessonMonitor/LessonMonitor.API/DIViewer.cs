using Microsoft.Extensions.DependencyInjection;
using System;

namespace LessonMonitor.API
{
    public class DIViewer
    {
        public static void RunDemo()
        {
            TransientRequest();
            ScopeRequest();
            SingleronRequest();
        }

        private static void TransientRequest()
        {
            var collection = new ServiceCollection();

            collection.AddScoped<DIViewerService>();
            collection.AddScoped<DIViewerAnotherService>();
            collection.AddTransient<DIViewerClient>();

            var provider = collection.BuildServiceProvider();

            using (var scope = provider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<DIViewerService>();
                var serviceAnother = scope.ServiceProvider.GetService<DIViewerAnotherService>();
                var controller = new DIViewerController(service, serviceAnother);

                Console.WriteLine("Transient");
                controller.Print();
                Console.WriteLine("");
            }

            using (var scope = provider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<DIViewerService>();
                var serviceAnother = scope.ServiceProvider.GetService<DIViewerAnotherService>();
                var controller = new DIViewerController(service, serviceAnother);

                Console.WriteLine("Transient");
                controller.Print();
                Console.WriteLine("");
            }
        }

        private static void ScopeRequest()
        {
            // Scope
            {
                var client = new DIViewerClient();
                var service = new DIViewerService(client);
                var serviceAnother = new DIViewerAnotherService(client);
                var controller = new DIViewerController(service, serviceAnother);

                Console.WriteLine("Scope");
                controller.Print();
                Console.WriteLine("");
            }

            {
                var client = new DIViewerClient();
                var service = new DIViewerService(client);
                var serviceAnother = new DIViewerAnotherService(client);
                var controller = new DIViewerController(service, serviceAnother);

                Console.WriteLine("Scope");
                controller.Print();
                Console.WriteLine("");
            }
        }

        private static void SingleronRequest()
        {
            // Singleton
            var client = new DIViewerClient();
            var service = new DIViewerService(client);
            var serviceAnother = new DIViewerAnotherService(client);
            var controller = new DIViewerController(service, serviceAnother);

            Console.WriteLine("Singleton");
            controller.Print();
            Console.WriteLine("");
            controller.Print();
            Console.WriteLine("");
            controller.Print();
            Console.WriteLine("");
        }
    }


    public class DIViewerController
    {
        private readonly Guid _guid;

        public readonly DIViewerService _dIViewerService;
        private readonly DIViewerAnotherService _dIViewerAnotherService;

        public DIViewerController(DIViewerService dIViewerService, DIViewerAnotherService dIViewerAnotherService)
        {
            _guid = Guid.NewGuid();
            _dIViewerService = dIViewerService;
            _dIViewerAnotherService = dIViewerAnotherService;
        }

        public void Print()
        {
            Console.WriteLine(nameof(DIViewerController) + " - " + _guid);
            _dIViewerService.Print();
            _dIViewerAnotherService.Print();
        }

    }

    public class DIViewerService
    {
        private readonly Guid _guid;

        private readonly DIViewerClient _dIViewerClient;

        public DIViewerService(DIViewerClient dIViewerClient)
        {
            _guid = Guid.NewGuid();
            _dIViewerClient = dIViewerClient;
        }

        public void Print()
        {
            Console.WriteLine(nameof(DIViewerService) + " - " + _guid);
            _dIViewerClient.Print();
        }
    }

    public class DIViewerAnotherService
    {
        private readonly Guid _guid;

        private readonly DIViewerClient _dIViewerClient;

        public DIViewerAnotherService(DIViewerClient dIViewerClient)
        {
            _guid = Guid.NewGuid();
            _dIViewerClient = dIViewerClient;
        }

        public void Print()
        {
            Console.WriteLine(nameof(DIViewerAnotherService) + " - " + _guid);
            _dIViewerClient.Print();
        }
    }

    public class DIViewerClient
    {
        private readonly Guid _guid;

        public DIViewerClient()
        {
            _guid = Guid.NewGuid();
        }

        public void Print()
        {
            Console.WriteLine(nameof(DIViewerClient) + " - " + _guid);
        }
    }

}
