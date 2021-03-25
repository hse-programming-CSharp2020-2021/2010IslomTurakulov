using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Map("/about", About);
            app.Map("/home", home =>
            {
                home.Map("/calc", Calc);
                home.Map("/myprogram", MyProgram);
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page Not Found");
            });
        }

        private static void About(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Islombek");
            });
        }

        private static void MyProgram(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var str = File.ReadAllText(
                    @"C:\Users\User\Documents\GitHub\2010IslomTurakulov\Module_3\Seminar3_11\Task_1\Startup.cs");
                await context.Response.WriteAsync(str);
            });
        }

        private static void Calc(IApplicationBuilder app)
        {
            app.UseMiddleware<TokenMiddleware>();
        }

    }
}
