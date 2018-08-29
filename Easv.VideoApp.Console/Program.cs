using Easv.PetStore.Core.ApplicationService;
using Easv.PetStore.Core.ApplicationService.Services;
using Easv.PetStore.Core.DomainService;
using Easv.PetStore.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Easv.PetStore.ConsoleApp
{
    class Program
    {
        //Infrastructure.Data

       
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();
        }

        
    }
}
