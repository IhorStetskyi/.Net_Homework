using System;
using Microsoft.Extensions.DependencyInjection;
using OOP_HW.InjectionsFolder;
using OOP_HW.Interfaces;

namespace OOP_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider container = Startup.ConfigureService();
            IApplication application = container.GetRequiredService<IApplication>();

            while (true)
            {
                application.GetAndShowDocuments(application.AskForDocumentNumber());
            }
        }
    }
}
