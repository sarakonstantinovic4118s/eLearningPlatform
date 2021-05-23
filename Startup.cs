using eLearning.Interfaces;
using eLearning.Models;
using eLearning.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eLearning
{
    public class Startup
    {
        // za jednostavnu konfiguraciju preko appsettings.json
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // klasa DatabaseSettings sadrzi informacije iz config fajla:
            services.Configure<DatabaseSettings>(_config.GetSection("DatabaseSettings"));

            // pravljenje veze izmedju interfejsa i servisa
            services.AddSingleton<IDatabaseSettings>(x => x.GetRequiredService<IOptions<DatabaseSettings>>().Value);
            services.AddSingleton<IKorisnikServices, KorisnikServices>();
            services.AddSingleton<IKurseviServices, KurseviServices>();
            services.AddSingleton<ISchoolServices, SchoolServices>();
            services.AddSingleton<IProgramServices, ProgramServices>();
            services.AddSingleton<IKategorijeServices, KategorijeServices>();

            services.AddMvc();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            // Cookie autentifikacija i autorizacija korisnika
            services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", config => 
                {
                    config.LoginPath = "/Learning/Login";
                });

            services.AddAuthorization(config =>
            {
                config.AddPolicy("Admin", adminAuthPolicy => {
                    adminAuthPolicy.RequireAuthenticatedUser();
                    adminAuthPolicy.RequireClaim(ClaimTypes.Role, "Admin");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            // identitet
            app.UseAuthentication();
            // pristup
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Learning}/{action=Index}/{id?}");
            });
        }
    }
}
