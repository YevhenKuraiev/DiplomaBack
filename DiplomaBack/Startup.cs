using System.Linq;
using DiplomaBack.BLL.BusinessModels;
using DiplomaBack.DAL.EntityFrameworkCore;
using DiplomaBack.SessionHelpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiplomaBack
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string con = "Server=(localdb)\\mssqllocaldb;Database=deliveryfooddbstore;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(con, b => b.MigrationsAssembly("DiplomaBack")));

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddRouting();
            services.AddScoped<Cart>(SessionCart.GetCart);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc().AddSessionStateTempDataProvider();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("MyPolicy");
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller}/{action}/{id?}");
                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });
            });


            app.Run(async (context) =>
            {
                if (!context.Session.Keys.Contains("Cart"))
                {
                    context.Session.Set<Cart>("Cart", new Cart());
                }
            });
        }
    }
}
