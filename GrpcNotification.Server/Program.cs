using System;
using GrpcNotification.Common.Server;
using GrpcNotification.Common.Server.Infrastructure;

namespace GrpcNotification.Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Notification service is starting.");

            MefManager.Initialize();

            foreach (var service in MefManager.Container.GetExportedValues<IService>())
            {
                service.Start();
            }

            MefManager.Container.GetExportedValue<Logger>().GetLogsAsObservable()
                .Subscribe(x => Console.WriteLine(x));

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }
    }
}