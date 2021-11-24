using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using el_proyecte_grande_sprint_1.Services;
using el_proyecte_grande_sprint_1.Data;
using Microsoft.EntityFrameworkCore;
using el_proyecte_grande_sprint_1.Repository;

namespace el_proyecte_grande_sprint_1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ProjectLensDatabase")));
            services.AddSingleton<IPictureStorage, PictureStorage>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "project-lens/build";
            //});
            services.AddSingleton<IAzureBlobStorageService, AzureBlobStorageService>();
            services.AddSingleton<IAuthenticationRepository, AuthenticationRepository>();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "project-lens/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "project-lens";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseReactDevelopmentServer(npmScript: "start");
            //    }
            //});
        }
    }
}



