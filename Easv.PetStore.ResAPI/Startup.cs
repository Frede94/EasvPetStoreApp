using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easv.PetStore.ConsoleApp;
using Easv.PetStore.Core.ApplicationService;
using Easv.PetStore.Core.ApplicationService.Services;
using Easv.PetStore.Core.DomainService;
using Easv.PetStore.Infrastructure.Data;
using Easv.PetStore.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Easv.PetStore.ResAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            FakeDB.InitializeData();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPrinter, Printer>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
