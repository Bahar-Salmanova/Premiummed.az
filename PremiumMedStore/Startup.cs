﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PremiumMedStore.Data;
using PremiumMedStore.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PremiumMedStore
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
            services.AddLocalization(x => x.ResourcesPath = "Resource");

            //dəstəklənəcək dillərin siyahısı hazırlayırıq//

            var supportedLanguages = new CultureInfo[]
            {
                    new CultureInfo("az-Latn-AZ"),
                    new CultureInfo("en-US"),
                    new CultureInfo("ru-RU"),
            };
            object p = services.Configure<RequestLocalizationOptions>(op =>
            {
                op.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(supportedLanguages[2]);
                op.SupportedCultures = supportedLanguages;
                op.SupportedUICultures = supportedLanguages;
            });

            services.AddDbContext<PremiumDbContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddSingleton<IFileManager, FileManager>();
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
               // app.UseHsts();//
            }
           // app.UseHttpsRedirection();//
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseRequestLocalization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
