using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.DependencyInjection;
using System.IO;


namespace Сourse_work
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHsts(options =>
            {
                options.Preload = false;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //env.EnvironmentName = "Production";
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                //app.UseExceptionHandler("/error");
            }
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            //app.Map("/error", ap => ap.Run(async context =>
            //{
            //    await context.Response.WriteAsync("DivideByZeroException occured!");
            //}));
            //app.Map("/home", ap => ap.Run(async context =>
            //{
            //    await context.Response.WriteAsync($"Home page!");
            //}));
            //app.Map("/index", Index);
            //app.Map("/about", About);

            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("main/index.html");
            options.DefaultFileNames.Add("html.html");
            app.UseDefaultFiles(options);

            //app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions() // обрабатывает запросы к каталогу wwwroot/html
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\main")),
                RequestPath = new PathString("/equeue")
            });
            app.UseStaticFiles(new StaticFileOptions() // обрабатывает запросы к каталогу wwwroot/html
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
                RequestPath = new PathString("/equeue/ok")
            });
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////equeue/index.html
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("<h1 align=center>Home</h1>");
            //    //int x = 0;
            //    //int y = 8 / x;
            //    //await context.Response.WriteAsync($"Result = {y}");
            //});

        }
        private static void Index(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Index");
            });
        }
        private static void About(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("About");
            });
        }
    }
}
