﻿using Easv.PetStore.Core.ApplicationService;
using Easv.PetStore.Core.ApplicationService.Services;
using Easv.PetStore.Core.DomainService;
using Microsoft.Extensions.DependencyInjection;

namespace Easv.PetStore.ConsoleApp
{
    class Program
    {        
        static void Main(string[] args)
        {
            //FakeDB.InitializeData();

            //var serviceCollection = new ServiceCollection();
            //serviceCollection.AddScoped<IPetService, PetService>();
            //serviceCollection.AddScoped<IPetRepository, PetRepository>();
            //serviceCollection.AddScoped<IPrinter, Printer>();

            //var serviceProvider = serviceCollection.BuildServiceProvider();
            //var printer = serviceProvider.GetRequiredService<IPrinter>();
            //printer.StartUI();
        }        
    }
}
