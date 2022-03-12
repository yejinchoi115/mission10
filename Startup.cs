﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using m10.Models;
using m9.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace mission10
{
    public class Startup
    {
        public Startup(IConfiguration temp)
        {
            Configuration = temp;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("BookConnection"));
            });
            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();
            services.AddScoped<IShopperRepository, EFShopperRepository>();


            //for razor page
            services.AddRazorPages();

            //for session 
            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddScoped<Basket>(x => SessionBasket.GetBasket(x));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //blazor
            services.AddServerSideBlazor();

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

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "categorypage",
                    pattern: "{categoryType}/Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Index" }
                    );

                endpoints.MapControllerRoute(
                   name: "Paging",
                   pattern: "Page{pageNum}",
                   defaults: new { Controller = "Home", action = "Index", pageNum = 1 }
                   );

                endpoints.MapControllerRoute(
                    name: "category",
                    pattern: "{categoryType}",
                    defaults: new { Controller = "Home", action = "Index", pageNum = 1 }
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapRazorPages();

                //blazor
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");
            });
        }
    }
}
