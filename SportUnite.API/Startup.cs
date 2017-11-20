using AutoMapper;
using Halcyon.Web.HAL.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SportUnite.DAL;
using SportUnite.BLL;
using SportUnite.Domain.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace SportUnite.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppEventEntityDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:SportUniteSports:ConnectionString"]));

            services.AddTransient<IManager<Invoice>, InvoiceManager>();
            services.AddTransient<IManager<Sport>, SportManager>();
            services.AddTransient<IManager<SportAttribute>, SportAttributeManager>();
            services.AddTransient<IManager<SportComplex>, SportComplexManager>();
            services.AddTransient<IManager<SportEvent>, SportEventManager>();
            services.AddTransient<IManager<SportHall>, SportHallManager>();
            services.AddTransient<IManager<SportSportAttribute>, SportSportAttributeManager>();

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:SportStoreProducts:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddTransient<IAuthentication, UserAuthentication>();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "SportUnite API", Version = "v1" });
            });
            services.AddMemoryCache();
            services.AddSession();

                BLL.Startup.bllDIContainer(services, Configuration);
            }
        

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });
            }

            Mapper.Initialize(configure =>
            {
                configure.CreateMap<Invoice, InvoiceDto>();

                configure.CreateMap<SportAttribute, SportAttributeDto>();

                configure.CreateMap<SportComplex, SportComplexDto>();

                configure.CreateMap<SportEvent, SportEventDto>();

                configure.CreateMap<SportHall, SportHallDto>();

                configure.CreateMap<Sport, SportDto>();

                configure.CreateMap<InvoiceDto, Invoice>();

                configure.CreateMap<SportAttributeDto, SportAttribute>();

                configure.CreateMap<SportComplexDto, SportComplex>();

                configure.CreateMap<SportEventDto, SportEvent>();

                configure.CreateMap<SportHallDto, SportHall>();

                configure.CreateMap<SportDto, Sport>();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SportUnite API");
            });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
