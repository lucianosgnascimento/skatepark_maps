using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoPista.Business;
using ProjetoPista.Data;
using ProjetoPista.Model.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ProjetoPista.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddControllersWithViews();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
            });

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", options =>
                    {
                        options.Cookie.Name = "CookieAuth";
                        options.LoginPath = "/Secure/Login";

                        //options.ExpireTimeSpan = TimeSpan.FromHours(1);
                        
                        //options.AccessDeniedPath = "/Secure/Login";
                    });
            services.AddRazorPages();
            services.AddMvc();

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=BasePistas;Trusted_Connection=True;");
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsuarioBusiness, UsuarioBusiness>();
            services.AddScoped<IPistaBusiness, PistaBusiness>();
            services.AddScoped<IProfessorBusiness, ProfessorBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
