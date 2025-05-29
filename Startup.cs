using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyServer
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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                        context.Response.ContentType = "text/html";
                        var html = "<html><body><h1>Request Headers - Version 1</h1><ul>";
                        foreach (var header in context.Request.Headers)
                        {
                            html += $"<li><strong>{header.Key}:</strong> {System.Net.WebUtility.HtmlEncode(string.Join(", ", header.Value))}</li>";
                        }

                        html += "</ul></body></html>";

                        await context.Response.WriteAsync(html);
                });
            });
        }
    }
}
