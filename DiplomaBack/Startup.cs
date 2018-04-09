﻿using DiplomaBack.DAL.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

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
                    .AllowCredentials()
                    .AllowAnyHeader();
            }));
            services.AddRouting();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options => //CookieAuthenticationOptions
            //    {
            //        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            //    });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("MyPolicy");

            app.Use(async (context, next) =>
            {
                await next.Invoke();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute("route0", "api/{controller}/{id?}");
                routes.MapRoute("default", "{controller}/{action}/{id?}");
                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            
            //app.Run(async (context) =>
            //{
            //    if (!context.Session.Keys.Contains("Cart"))
            //    {
            //        context.Session.Set<Cart>("Cart", new Cart());
            //    }
            //    else
            //    {
            //        context.Session.Get<Cart>("Cart");
            //    }
            //});


        }
    }
}
