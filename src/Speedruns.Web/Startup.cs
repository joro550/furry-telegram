using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Speedruns.Web.Areas.Identity;
using Speedruns.Web.Users;

namespace Speedruns.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services
                .AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>
                >();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                CatalogContextSeed.SeedAsync(app)
                    .Wait();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }

    public class CatalogContextSeed
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            // var context = (CatalogContext)applicationBuilder
            //     .ApplicationServices.GetService(typeof(CatalogContext));
            // using (context)
            // {
            //     context.Database.Migrate();
            //     if (!context.CatalogBrands.Any())
            //     {
            //         context.CatalogBrands.AddRange(
            //             GetPreconfiguredCatalogBrands());
            //         await context.SaveChangesAsync();
            //     }
            //     if (!context.CatalogTypes.Any())
            //     {
            //         context.CatalogTypes.AddRange(
            //             GetPreconfiguredCatalogTypes());
            //         await context.SaveChangesAsync();
            //     }
            // }
        }
    }
}