using Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace modelo_core_angular
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
            //Sefaz Identity
            IdentityConfig.RegistrarOpcoes(Configuration);
            services.AddAuthentication(IdentityConfig.AuthenticationOptions)
            .AddWsFederation(IdentityConfig.WSFederationOptions)
            .AddCookie("Cookies", IdentityConfig.CookieAuthenticationOptions);
            //Requer a classe IdentityValores, além dessas linhas acima, na aplicação e em cada api que se utilizar de autenticação WSFederation

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<Usuario>();

            services.AddAuthorization(options =>
            {
                var fallbackPolicyBulder = new AuthorizationPolicyBuilder();
                options.FallbackPolicy = fallbackPolicyBulder.RequireAuthenticatedUser().Build();

                options.AddPolicy("COMUM", policy =>
                {
                    policy.RequireRole("COMUM", "GESTOR");
                });
                options.AddPolicy("GESTOR", policy =>
                {
                    policy.RequireRole("GESTOR");
                });
            });

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();

            // Indique no appsettings se será usado o Sefaz.Identity para autorizacao
            if (!string.IsNullOrEmpty(Configuration["authorize"]) && Configuration["authorize"]=="true")
            {
                app.UseAuthorization();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
