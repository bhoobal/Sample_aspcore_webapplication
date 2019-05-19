using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace aspnetapp
{
    public class Startup
    {
        string dbConn;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            dbConn = configuration.GetSection("MySettings").GetSection("DbConnection").Value;
            //string envvariable = Environment.CurrentDirectory.ToString();


        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.Run(async (context) =>
            {
                
                await context.Response.WriteAsync("Hello! This is a sample web application for demo in docker and possible k8s \n ");
                await context.Response.WriteAsync(" \n 1. pod/ container IP address         : " + context.Response.HttpContext.Connection.RemoteIpAddress.ToString());
                await context.Response.WriteAsync(" \n 2. Pod/ Container host name      :" + context.Response.HttpContext.Connection.Id.ToString());
                await context.Response.WriteAsync(" \n 3. DB connection from app settings  :" + dbConn);
                await context.Response.WriteAsync(" \n 4. Environment.CurrentDirectory -->     :" + Environment.CurrentDirectory.ToString());
                await context.Response.WriteAsync(" \n 5. Environment.OSVersion -->        :" + Environment.OSVersion.ToString());
                await context.Response.WriteAsync(" \n 6. Environment variable value -->   :" + Environment.GetEnvironmentVariable("varEnv").ToString());

                //await context.Response.WriteAsync(" \n System.Net.HttpResponseHeader.Server.ToString() -->" + System.Net.HttpResponseHeader.Server..ToString());



                // await context.Response.WriteAsync(" \n 3.Display time - Server time " + context.Response.HttpContext.Connection.
                //A web application
                //1.Display host name
                //2.Display ip address
                //3.Display time - Server time
                //4.Display source ip adderss
                //5.Display A environment variable
                //6.A value from config map
                //7.A value from secrets
                //8.Thank you message



            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
