using Easv.PetStore.Core.ApplicationService;
using Easv.PetStore.Core.ApplicationService.Services;
using Easv.PetStore.Core.DomainService;
using Easv.PetStore.Infrastructure.Data;
using Easv.PetStore.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Easv.PetStore.ResAPI
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //    //FakeDB.InitializeData();
        //}

        private IConfiguration _conf { get; }

        private IHostingEnvironment _env { get; set; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _conf = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsDevelopment())
            {
                services.AddDbContext<PetStoreAppContext>(
                    opt => opt.UseSqlite("Data Source=petStoreapp.db"));
            }
            else if (_env.IsProduction())
            {
                services.AddDbContext<PetStoreAppContext>(
                    opt => opt
                        .UseSqlServer(_conf.GetConnectionString("DefaultConnection")));
            }

            //services.AddDbContext<PetStoreAppContext>(opt => opt.UseSqlite("Data Source=petstoreApp"));

            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetRepository, PetRepository>();            

            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();

            services.AddMvc().AddJsonOptions(
                options => {
                    options.SerializerSettings.ReferenceLoopHandling
                        = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetStoreAppContext>();
                    DBInitializer.SeedDB(ctx);
                }
            }
            else
            { 
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetStoreAppContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
