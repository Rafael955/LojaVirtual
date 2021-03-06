using LojaVirtual.Configuration;
using LojaVirtual.Domain.Configs;
using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Libraries;
using LojaVirtual.Domain.Libraries.Middleware;
using LojaVirtual.Infrastructure.Data.Context;
using LojaVirtual.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Net.Mail;

namespace LojaVirtual
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
            /*
             *  Session - Configura??o
             */
            services.ConfigureDependencies(Configuration);

            /*SMTP*/
            services.ConfigureSmtpClient(Configuration);

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMemoryCache(); // Guardar os dados na mem?ria
            services.AddSession();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            services.AddSession(options =>
            {
                options.Cookie.IsEssential = true;
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

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseMiddleware<ValidateAntiForgeryTokenMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            /*
             * https://www.site.com.br -> Qual controlador? (Gest?o) -> Rotas
             * https://www.site.com.br/Produto{controlador}/Visualizar{a??o}/10{identificador}
             */

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapControllerRoute(
                //    name: "areas",
                //    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //      name: "areas",
            //      template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            //    );
            //});
        }
    }
}