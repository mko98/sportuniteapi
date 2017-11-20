using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using SportUnite.DAL;
using SportUnite.WEBUI.Models;
using SportUnite.BLL;
using SportUnite.Domain.Models;

namespace SportUnite.WEBUI
{
    public class Startup
    {
        IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .Build();
        }

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
            services.AddMemoryCache();
            services.AddSession();

            BLL.Startup.bllDIContainer(services, Configuration);
        }

        public void Configure(IApplicationBuilder app,
                 IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseSession();
            app.UseMvc(routes => {
                routes.MapRoute(name: "Error", template: "Error",
                    defaults: new { controller = "Error", action = "Error" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Home}/{id?}");

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });

            IdentitySeedData.EnsurePopulated(app);
            EntitySeedData.EnsurePopulated(app);
        }
    }
}
